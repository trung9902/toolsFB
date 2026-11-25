using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public static class AiSecretStore
{
    private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("LushCare.Global.Jev.v1");

    public static string Protect(string plainText)
    {
        if (string.IsNullOrWhiteSpace(plainText)) return "";
        byte[] bytes = Encoding.UTF8.GetBytes(plainText.Trim());
        byte[] encrypted = ProtectedData.Protect(bytes, Entropy, DataProtectionScope.CurrentUser);
        return Convert.ToBase64String(encrypted);
    }

    public static string Unprotect(string protectedValue)
    {
        if (string.IsNullOrWhiteSpace(protectedValue)) return "";
        try
        {
            byte[] encrypted = Convert.FromBase64String(protectedValue);
            byte[] bytes = ProtectedData.Unprotect(encrypted, Entropy, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(bytes);
        }
        catch
        {
            return "";
        }
    }
}

public static class JevSecureConfiguration
{
    private const string FileName = "jev.secure.json";
    private static string ConfigPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings", FileName);

    public static bool HasApiKey => !string.IsNullOrEmpty(GetApiKey());

    public static void SaveApiKey(string apiKey)
    {
        if (string.IsNullOrWhiteSpace(apiKey)) throw new ArgumentException("API key không được để trống.");
        Directory.CreateDirectory(Path.GetDirectoryName(ConfigPath));
        var config = new JObject
        {
            ["version"] = 1,
            ["provider"] = "TypeSafe AI",
            ["model"] = "jev-latest",
            ["protectedApiKey"] = AiSecretStore.Protect(apiKey)
        };
        File.WriteAllText(ConfigPath, config.ToString(Formatting.Indented), new UTF8Encoding(false));
    }

    public static string GetApiKey()
    {
        try
        {
            if (!File.Exists(ConfigPath)) return "";
            JObject config = JObject.Parse(File.ReadAllText(ConfigPath));
            return AiSecretStore.Unprotect((string)config["protectedApiKey"] ?? "");
        }
        catch
        {
            return "";
        }
    }

    public static void DeleteApiKey()
    {
        try { if (File.Exists(ConfigPath)) File.Delete(ConfigPath); } catch { }
    }
}

public sealed class JevChoiceResult
{
    public string Choice { get; set; }
    public double Confidence { get; set; }
    public Dictionary<string, double> Probabilities { get; set; }
    public int InputTokens { get; set; }
    public int OutputTokens { get; set; }
    public double SelectedProbability => Probabilities != null && Choice != null && Probabilities.TryGetValue(Choice, out double value) ? value : 0.0;
}

public sealed class JevNoulResult
{
    public double Probability { get; set; }
    public int InputTokens { get; set; }
    public int OutputTokens { get; set; }
    public bool IsYes(double threshold = 0.7) => Probability > threshold;
    public bool IsNo(double threshold = 0.3) => Probability < threshold;
}

public static class JevResponseParser
{
    public static JevChoiceResult ParseChoice(string json, string questionId)
    {
        JObject root = JObject.Parse(json);
        JObject answer = root["answers"]?[questionId] as JObject;
        if (answer == null || (string)answer["type"] != "choice") throw new InvalidDataException("Phản hồi Jev Choice không hợp lệ.");
        string choice = (string)answer["choice"];
        JObject probabilitiesObject = answer["probabilities"] as JObject;
        if (string.IsNullOrEmpty(choice) || probabilitiesObject == null) throw new InvalidDataException("Jev Choice thiếu choice hoặc probabilities.");
        var probabilities = new Dictionary<string, double>(StringComparer.Ordinal);
        foreach (JProperty property in probabilitiesObject.Properties()) probabilities[property.Name] = property.Value.Value<double>();
        if (!probabilities.ContainsKey(choice)) throw new InvalidDataException("Xác suất của lựa chọn được chọn không tồn tại.");
        return new JevChoiceResult
        {
            Choice = choice,
            Confidence = answer["confidence"]?.Value<double>() ?? 0.0,
            Probabilities = probabilities,
            InputTokens = root["usage"]?["input_tokens"]?.Value<int>() ?? 0,
            OutputTokens = root["usage"]?["output_tokens"]?.Value<int>() ?? 0
        };
    }

    public static JevNoulResult ParseNoul(string json, string questionId)
    {
        JObject root = JObject.Parse(json);
        JObject answer = root["answers"]?[questionId] as JObject;
        if (answer == null || (string)answer["type"] != "noul" || answer["noul"] == null) throw new InvalidDataException("Phản hồi Jev Noul không hợp lệ.");
        double probability = answer["noul"].Value<double>();
        if (probability < 0 || probability > 1) throw new InvalidDataException("Xác suất Jev Noul nằm ngoài khoảng 0..1.");
        return new JevNoulResult
        {
            Probability = probability,
            InputTokens = root["usage"]?["input_tokens"]?.Value<int>() ?? 0,
            OutputTokens = root["usage"]?["output_tokens"]?.Value<int>() ?? 0
        };
    }
}

public sealed class JevClient
{
    public const string Endpoint = "https://api.typesafe.ai/v1/systemone";
    public string Model { get; }
    public int TimeoutMilliseconds { get; set; } = 15000;

    public JevClient(string model = "jev-latest")
    {
        Model = string.IsNullOrWhiteSpace(model) ? "jev-latest" : model;
    }

    public JevNoulResult TestConnection()
    {
        var questions = new JObject
        {
            ["connection_ok"] = new JObject
            {
                ["type"] = "noul",
                ["instructions"] = "Does the state explicitly say that this is a TypeSafe Jev connection test?"
            }
        };
        string json = Send("TypeSafe Jev connection test", questions);
        return JevResponseParser.ParseNoul(json, "connection_ok");
    }

    public JevChoiceResult AskChoice(object state, string questionId, string instructions, IDictionary<string, string> criteria)
    {
        if (criteria == null || criteria.Count < 2) throw new ArgumentException("Choice cần ít nhất hai lựa chọn.");
        var options = new JObject();
        foreach (KeyValuePair<string, string> item in criteria) options[item.Key] = item.Value;
        var questions = new JObject
        {
            [questionId] = new JObject
            {
                ["type"] = "choice",
                ["instructions"] = instructions,
                ["criteria"] = options
            }
        };
        return JevResponseParser.ParseChoice(Send(state, questions), questionId);
    }

    public JevNoulResult AskNoul(object state, string questionId, string instructions, string trueCriteria = null, string falseCriteria = null)
    {
        var question = new JObject
        {
            ["type"] = "noul",
            ["instructions"] = instructions
        };
        if (!string.IsNullOrWhiteSpace(trueCriteria) || !string.IsNullOrWhiteSpace(falseCriteria))
        {
            question["criteria"] = new JObject
            {
                ["true"] = trueCriteria ?? "",
                ["false"] = falseCriteria ?? ""
            };
        }
        var questions = new JObject { [questionId] = question };
        return JevResponseParser.ParseNoul(Send(state, questions), questionId);
    }

    private string Send(object state, JObject questions)
    {
        string apiKey = JevSecureConfiguration.GetApiKey();
        if (string.IsNullOrEmpty(apiKey)) throw new InvalidOperationException("Chưa cấu hình API key Jev.");
        var payload = new JObject
        {
            ["model"] = Model,
            ["state"] = state == null ? JValue.CreateNull() : JToken.FromObject(state),
            ["questions"] = questions
        };
        byte[] body = Encoding.UTF8.GetBytes(payload.ToString(Formatting.None));
        var request = (HttpWebRequest)WebRequest.Create(Endpoint);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        request.Headers[HttpRequestHeader.Authorization] = "Bearer " + apiKey;
        request.Timeout = TimeoutMilliseconds;
        request.ReadWriteTimeout = TimeoutMilliseconds;
        request.ContentLength = body.Length;
        using (Stream stream = request.GetRequestStream()) stream.Write(body, 0, body.Length);
        try
        {
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream())) return reader.ReadToEnd();
        }
        catch (WebException ex)
        {
            string detail = "";
            if (ex.Response != null)
            {
                using (var reader = new StreamReader(ex.Response.GetResponseStream())) detail = reader.ReadToEnd();
            }
            throw new InvalidOperationException("TypeSafe Jev API lỗi: " + (string.IsNullOrWhiteSpace(detail) ? ex.Message : detail), ex);
        }
    }
}
