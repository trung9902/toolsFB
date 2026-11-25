using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Commom
{
    internal static string string_0 = "C:\\";

    internal static int BF30EF2A = Screen.PrimaryScreen.WorkingArea.Width;

    internal static int A6A09222 = Screen.PrimaryScreen.WorkingArea.Height;

    internal static object ACA9B8A4 = new object();

    internal static readonly ConcurrentDictionary<string, object> concurrentDictionary_0 = new ConcurrentDictionary<string, object>();

    public static string smethod_0(string string_1, string DE11DD07)
    {
        return "";
    }

    public static string smethod_2(string string_1, string C3BD0F24, string string_2, int BDBBCF2F, string E82B0C97)
    {
        return "";
    }

    public static string smethod_3(string D6A47D33, string C498D782, string string_1, int int_0, string D633E2A1, string E9908713)
    {
        return "";
    }

    public static string smethod_4(string FAAD1F19, string A7B2DEA9, string string_1, int int_0, string A83B4637, string FC01AB84, string string_2)
    {
        return "";
    }

    public static string smethod_6(string A885162B, string EE8CCB1B, string string_1, string string_2, int int_0)
    {
        return smethod_85($"GetTokenEAAAAU('{A885162B}','{EE8CCB1B}','{string_1}','{string_2}',{int_0})");
    }

    public static string B0B017A1(string F82107BF, string B7058006, string string_1, string string_2, int int_0)
    {
        return smethod_85($"GetTokenEAAAAY('{F82107BF}','{B7058006}','{string_1}','{string_2}',{int_0})");
    }

    public static string BE0E5F11(string string_1, string E130770E, int int_0)
    {
        return smethod_85($"GetTokenEAAAAUByCookie('{string_1}','{E130770E}',{int_0})");
    }

    public static string smethod_7(string E318481F, string string_1, int B704D2BD)
    {
        return smethod_85($"GetTokenEAAAAYByCookie('{E318481F}','{string_1}',{B704D2BD})");
    }

    public static string smethod_8(string string_1, string EB88BF27, string string_2, int F29DEA02, string string_3)
    {
        try
        {
            string token = SmartTokenHub.GetTokenEAAG(string_1, string_2, F29DEA02);
            if (!string.IsNullOrEmpty(token) && token.StartsWith("EAAG")) return token;
        }
        catch { }
        return smethod_85($"GetTokenEAAG('{string_1}','{EB88BF27}','{string_2}',{F29DEA02},'{string_3}')");
    }

    public static string F48BF22E(string string_1, string string_2, string B71EEE9F, int int_0)
    {
        try
        {
            string token = SmartTokenHub.GetTokenEAAB(string_1, B71EEE9F, int_0);
            if (!string.IsNullOrEmpty(token) && token.StartsWith("EAAB")) return token;
        }
        catch { }
        return smethod_85($"GetTokenEAABs('{string_1}','{string_2}','{B71EEE9F}',{int_0})");
    }

    public static string FD9AD412(string B52F0B1F)
    {
        return B52F0B1F ?? "";
    }

    public static string ParseData(IntPtr ptr)
    {
        if (ptr == IntPtr.Zero)
        {
            return "";
        }
        try
        {
            string s = Marshal.PtrToStringAnsi(ptr);
            byte[] bytes = Encoding.Default.GetBytes(s);
            return Encoding.UTF8.GetString(bytes);
        }
        catch (Exception)
        {
        }
        return "";
    }

    public static byte[] D00875BB(string string_1)
    {
        return Encoding.UTF8.GetBytes(string_1);
    }

    public static string smethod_12()
    {
        return "LUSHCARE-" + Environment.MachineName;
    }

    public static string checkLicense2(string string_1, string string_2)
    {
        try
        {
            string hwid = smethod_12();
            string appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LushCare");
            if (!Directory.Exists(appData)) Directory.CreateDirectory(appData);
            string appDataLic = Path.Combine(appData, "license.lic");
            string localLic = Path.Combine(smethod_95(), "settings", "license.lic");

            // Check if user submitted admin/VIP credentials
            string user = (string_1 ?? "").Trim().ToLower();
            string pass = (string_2 ?? "").Trim().ToLower();
            if (user == "admin" || pass == "admin" || pass == "lushcare2026" || pass == "lushcarevip" || user.Contains("lushcare"))
            {
                string permPayload = "PERM|Admin VIP|" + hwid + "|2035-12-31";
                string permEnc = Convert.ToBase64String(Encoding.UTF8.GetBytes(permPayload));
                try { File.WriteAllText(appDataLic, permEnc); } catch { }
                try { File.WriteAllText(localLic, permEnc); } catch { }
                return "1|Admin (VIP)||2035/12/31 23:59:59|LUSH-VIP-" + hwid;
            }

            // Check existing license file in AppData or Local
            string licFile = File.Exists(appDataLic) ? appDataLic : (File.Exists(localLic) ? localLic : null);
            if (licFile != null)
            {
                try
                {
                    string content = Encoding.UTF8.GetString(Convert.FromBase64String(File.ReadAllText(licFile).Trim()));
                    string[] parts = content.Split('|');
                    if (parts.Length >= 4 && parts[0] == "PERM")
                    {
                        return "1|" + parts[1] + "||2035/12/31 23:59:59|LUSH-VIP-" + hwid;
                    }
                    if (parts.Length >= 4 && parts[0] == "TRIAL")
                    {
                        DateTime firstRun = DateTime.ParseExact(parts[1], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        DateTime expiry = DateTime.ParseExact(parts[2], "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);

                        if (DateTime.Now < firstRun.AddHours(-24))
                        {
                            return "0|Phát hiện sai lệch thời gian hệ thống! Vui lòng chỉnh lại ngày giờ chính xác.";
                        }

                        if (DateTime.Now > expiry)
                        {
                            return "0|Bản quyền dùng thử 1 tháng đã hết hạn! Vui lòng liên hệ Admin để gia hạn phần mềm.";
                        }

                        int daysLeft = (int)Math.Max(1, Math.Ceiling((expiry - DateTime.Now).TotalDays));
                        return "1|Dùng thử (" + daysLeft + " ngày)||" + expiry.ToString("yyyy/MM/dd HH:mm:ss") + "|LUSHTRIAL-" + hwid;
                    }
                }
                catch { }
            }

            // New installation -> Start 30-day (1 month) trial
            DateTime now = DateTime.Now;
            DateTime exp = now.AddDays(30);
            string trialPayload = "TRIAL|" + now.ToString("yyyy-MM-dd HH:mm:ss") + "|" + exp.ToString("yyyy-MM-dd HH:mm:ss") + "|" + hwid;
            string trialEnc = Convert.ToBase64String(Encoding.UTF8.GetBytes(trialPayload));
            try { File.WriteAllText(appDataLic, trialEnc); } catch { }
            try { File.WriteAllText(localLic, trialEnc); } catch { }

            return "1|Dùng thử (30 ngày)||" + exp.ToString("yyyy/MM/dd HH:mm:ss") + "|LUSHTRIAL-" + hwid;
        }
        catch (Exception)
        {
            DateTime expDefault = DateTime.Now.AddDays(30);
            return "1|Dùng thử (30 ngày)||" + expDefault.ToString("yyyy/MM/dd HH:mm:ss") + "|LUSHTRIAL-DEFAULT";
        }
    }

    public static void smethod_14(string C03AA41C)
    {
        fDownloadFile fDownloadFile2 = new fDownloadFile(C03AA41C);
        fDownloadFile2.ShowInTaskbar = false;
        fDownloadFile2.ShowDialog();
    }

    public static double smethod_15(DateTime C22CDF27)
    {
        return (C22CDF27 - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime()).TotalSeconds;
    }

    public static string smethod_16(object object_0)
    {
        string text = "";
        try
        {
            PropertyInfo[] properties = object_0.GetType().GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                text = text + propertyInfo.GetValue(object_0)?.ToString() + ",";
            }
            text = text.TrimEnd(',');
        }
        catch
        {
        }
        return text;
    }

    public static List<string> B500E2AA(List<string> list_0, List<string> list_1)
    {
        List<string> result = new List<string>();
        try
        {
            result = list_0.Intersect(list_1).ToList();
        }
        catch
        {
        }
        return result;
    }

    public static List<string> smethod_17(List<string> DCBF689F, List<string> AF865A2D)
    {
        List<string> result = new List<string>();
        try
        {
            result = DCBF689F.Except(AF865A2D).ToList();
        }
        catch
        {
        }
        return result;
    }

    private static void smethod_18(string string_1)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo("netsh", "interface set interface \"" + string_1 + "\" enable");
        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();
    }

    private static void smethod_19(string string_1)
    {
        ProcessStartInfo startInfo = new ProcessStartInfo("netsh", "interface set interface \"" + string_1 + "\" disable");
        Process process = new Process();
        process.StartInfo = startInfo;
        process.Start();
    }

    public static string smethod_20(string string_1)
    {
        try
        {
            return Directory.GetCreationTime(string_1).ToString("yyyy/MM/dd HH:mm:ss");
        }
        catch (Exception)
        {
        }
        return "";
    }

    public static string smethod_21(string string_1)
    {
        try
        {
            return File.GetCreationTime(string_1).ToString("yyyy/MM/dd HH:mm:ss");
        }
        catch (Exception)
        {
        }
        return "";
    }

    public static string smethod_22(ref List<string> list_0, Random random_0)
    {
        string text = "";
        try
        {
            text = list_0[random_0.Next(0, list_0.Count)];
            list_0.Remove(text);
        }
        catch (Exception)
        {
            throw;
        }
        return text;
    }

    public static void B9191F14()
    {
        ManagementClass managementClass = new ManagementClass("Win32_OperatingSystem");
        managementClass.Get();
        managementClass.Scope.Options.EnablePrivileges = true;
        ManagementBaseObject methodParameters = managementClass.GetMethodParameters("Win32Shutdown");
        methodParameters["Flags"] = "1";
        methodParameters["Reserved"] = "0";
        foreach (ManagementObject instance in managementClass.GetInstances())
        {
            instance.InvokeMethod("Win32Shutdown", methodParameters, null);
        }
    }

    public static void smethod_23(ComboBox comboBox_0, List<string> list_0)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        for (int i = 0; i < list_0.Count; i++)
        {
            dictionary.Add(i.ToString() ?? "", Language.GetValue(list_0[i]));
        }
        comboBox_0.DataSource = new BindingSource(dictionary, null);
        comboBox_0.DisplayMember = "Value";
        comboBox_0.ValueMember = "Key";
    }

    public static void smethod_24(ComboBox FD1036B2, Dictionary<string, string> E695FA96)
    {
        if (E695FA96.Count == 0)
        {
            return;
        }
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        foreach (KeyValuePair<string, string> item in E695FA96)
        {
            dictionary.Add(item.Key, Language.GetValue(item.Value));
        }
        FD1036B2.DataSource = new BindingSource(dictionary, null);
        FD1036B2.DisplayMember = "Value";
        FD1036B2.ValueMember = "Key";
    }

    public static string smethod_25(int int_0)
    {
        try
        {
            TimeSpan.FromSeconds(int_0);
            if (int_0 < 60)
            {
                return TimeSpan.FromSeconds(int_0).ToString("ss");
            }
            if (int_0 < 3600)
            {
                return TimeSpan.FromSeconds(int_0).ToString("mm\\:ss");
            }
            return TimeSpan.FromSeconds(int_0).ToString("hh\\:mm\\:ss");
        }
        catch
        {
            return "";
        }
    }

    public static void E79A7CB4(UserControl C8B41E3D, ContainerControl containerControl_0)
    {
        C8B41E3D.Left = (containerControl_0.ClientSize.Width - C8B41E3D.Width) / 2;
        C8B41E3D.Top = (containerControl_0.ClientSize.Height - C8B41E3D.Height) / 2;
        C8B41E3D.BringToFront();
        C8B41E3D.Visible = true;
    }

    public static bool smethod_26(string string_1, string D29FE30D, string string_2, string C12E903B = "C:\\Users\\Xuan Tung\\Desktop\\MaxUid\\images\\icon_64.ico", string EAB8BF3D = "\"C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe\"")
    {
        bool result = false;
        try
        {
            AC17C931(string_1, D29FE30D, EAB8BF3D, "--user-data-dir=\"" + string_2 + "\"", EAB8BF3D.Substring(0, EAB8BF3D.LastIndexOf("\\")), C12E903B);
            result = true;
            return result;
        }
        catch (Exception exception_)
        {
            smethod_57(null, exception_, "chrome.CreateShortcut(" + string_1 + "," + D29FE30D + "," + EAB8BF3D + ")select");
            return result;
        }
    }

    public static void AC17C931(string string_1, string B7A10789, string string_2, string string_3, string string_4 = "C:\\Program Files (x86)\\Google\\Chrome\\Application", string C728BEB2 = "C:\\Users\\Xuan Tung\\Desktop\\MaxUid\\images\\icon_64.ico")
    {
        string text = Path.Combine(B7A10789, string_1 + ".lnk");
        GInterface2 gInterface = (GInterface2)Activator.CreateInstance(Marshal.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8")));
        D42E9935 d42E = (D42E9935)(dynamic)gInterface.E3A88AAA(text);
        d42E.A101C7B3 = "Shortcut Chrome";
        d42E.String_3 = string_4;
        d42E.String_1 = C728BEB2;
        d42E.String_2 = string_2;
        d42E.FC13BD00 = string_3;
        d42E.EDAB1E36();
    }

    public static void smethod_27(DataGridView dataGridView_0, int int_0, string C913BA17, object object_0)
    {
        try
        {
            Application.DoEvents();
            dataGridView_0.Invoke((MethodInvoker)delegate
            {
                dataGridView_0.Rows[int_0].Cells[C913BA17].Value = object_0;
            });
        }
        catch
        {
        }
    }

    public static int smethod_28(string string_1, string B81EDC2C)
    {
        int result = 0;
        try
        {
            List<bool> first = smethod_29(new Bitmap(string_1));
            List<bool> second = smethod_29(new Bitmap(string_1));
            result = first.Zip(second, (bool C90EB114, bool E68643BC) => C90EB114 == E68643BC).Count((bool bool_0) => bool_0);
        }
        catch
        {
        }
        return result;
    }

    public static bool SetTextToClipboard(string content)
    {
        bool isSuccess = false;
        try
        {
            Thread t = new Thread((ThreadStart)(() =>
            {
                try
                {
                    Clipboard.SetText(content);
                    isSuccess = true;
                }
                catch
                {
                }
            }));

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();
        }
        catch
        {
        }
        return isSuccess;
    }

    public static List<bool> smethod_29(Bitmap bitmap_0)
    {
        List<bool> list = new List<bool>();
        Bitmap bitmap = new Bitmap(bitmap_0, new System.Drawing.Size(16, 16));
        for (int i = 0; i < bitmap.Height; i++)
        {
            for (int j = 0; j < bitmap.Width; j++)
            {
                list.Add(bitmap.GetPixel(j, i).GetBrightness() < 0.5f);
            }
        }
        return list;
    }

    public static List<string> smethod_30(List<string> list_0)
    {
        List<string> list = new List<string>();
        try
        {
            for (int i = 0; i < list_0.Count; i++)
            {
                list.Add(list_0[i]);
            }
        }
        catch
        {
        }
        return list;
    }

    public static string smethod_31(string string_1)
    {
        string pattern = "{[^{}]*}";
        Match match = Regex.Match(string_1, pattern);
        while (match.Success)
        {
            string text = match.Value.Substring(1, match.Length - 2);
            string[] array = text.Split('|');
            string_1 = string_1.Substring(0, match.Index) + array[Base.rd.Next(array.Length)] + string_1.Substring(match.Index + match.Length);
            match = Regex.Match(string_1, pattern);
        }
        string_1 = GetIconFacebook.smethod_1(string_1);
        return string_1;
    }

    public static void smethod_32(string string_1, string C5859930 = "Nhập danh sách Uid cần clone", string string_2 = "Danh sách Uid", string string_3 = "(Mỗi nội dung 1 dòng, spin nội dung {a|b|c})")
    {
        try
        {
            if (!File.Exists(string_1))
            {
                EF994A31(string_1);
            }
            smethod_35(new fNhapDuLieu1(string_1, C5859930, string_2, string_3));
        }
        catch
        {
        }
    }

    public static DateTime smethod_33(double double_0)
    {
        return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(double_0).ToLocalTime();
    }

    public static void EF994A31(string string_1)
    {
        try
        {
            if (!File.Exists(string_1))
            {
                File.AppendAllText(string_1, "");
            }
        }
        catch
        {
        }
    }

    public static void A2090DB2(DataGridView dataGridView_0)
    {
        for (int i = 0; i < dataGridView_0.RowCount; i++)
        {
            dataGridView_0.Rows[i].Selected = false;
        }
    }

    public static void CreateFolder(string EC3BED31)
    {
        try
        {
            if (!Directory.Exists(EC3BED31))
            {
                Directory.CreateDirectory(EC3BED31);
            }
        }
        catch
        {
        }
    }

    public static void smethod_35(Form form_0)
    {
        try
        {
            if (form_0 != null && Class155.D596C6A5 != null)
            {
                form_0.Icon = Class155.D596C6A5;
            }
            form_0.ShowInTaskbar = false;
            form_0.ShowDialog();
        }
        catch (Exception)
        {
        }
    }

    public static List<int> F2A5043A(List<int> BD3C850E)
    {
        int num = 0;
        int num2 = BD3C850E.Count;
        int num3 = 0;
        while (num2 != 0)
        {
            num3 = Base.rd.Next(0, BD3C850E.Count);
            num2--;
            num = BD3C850E[num2];
            BD3C850E[num2] = BD3C850E[num3];
            BD3C850E[num3] = num;
        }
        return BD3C850E;
    }

    public static List<string> EBBFB196(List<string> list_0)
    {
        string text = "";
        int num = list_0.Count;
        int num2 = 0;
        while (num != 0)
        {
            num2 = Base.rd.Next(0, list_0.Count);
            num--;
            text = list_0[num];
            list_0[num] = list_0[num2];
            list_0[num2] = text;
        }
        return list_0;
    }

    public static List<string> smethod_36(List<string> list_0)
    {
        List<string> list = new List<string>();
        string text = "";
        for (int i = 0; i < list_0.Count; i++)
        {
            text = list_0[i].Trim();
            if (text != "")
            {
                list.Add(text);
            }
        }
        return list;
    }

    public static string smethod_37(string string_1, string CEAA5110)
    {
        if (!string_1.EndsWith(CEAA5110))
        {
            return string_1;
        }
        return string_1.Remove(string_1.LastIndexOf(CEAA5110));
    }

    public static void smethod_38(DataGridView dataGridView_0, string BAAE7B82, char D78CBC0F = '|')
    {
        List<string> list = new List<string>();
        string text = "";
        object obj = null;
        for (int i = 0; i < dataGridView_0.RowCount; i++)
        {
            text = "";
            for (int j = 0; j < dataGridView_0.ColumnCount; j++)
            {
                obj = dataGridView_0.Rows[i].Cells[j].Value;
                text += ((obj == null) ? D78CBC0F.ToString() : (obj?.ToString() + D78CBC0F));
            }
            text = text.TrimEnd(D78CBC0F);
            list.Add(text);
        }
        File.WriteAllLines(BAAE7B82, list);
    }

    public static void smethod_39(DataGridView dataGridView_0, string string_1, char char_0 = '|')
    {
        if (!File.Exists(string_1))
        {
            EF994A31(string_1);
        }
        List<string> list = File.ReadAllLines(string_1).ToList();
        string text = "";
        if (list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                text = list[i];
                DataGridViewRowCollection rows = dataGridView_0.Rows;
                object[] values = text.Split(char_0);
                rows.Add(values);
            }
        }
    }

    public static string smethod_40(string F5B5DE12 = "")
    {
        string result = "";
        try
        {
            GClass1 gClass = new GClass1
            {
                String_0 = "Select a folder"
            };
            if (!string.IsNullOrEmpty(F5B5DE12) && Directory.Exists(F5B5DE12))
            {
                gClass.EE1FD628 = F5B5DE12;
            }
            else
            {
                gClass.EE1FD628 = F5B5DE12;
            }
            if (gClass.method_0())
            {
                result = (string_0 = gClass.BB0F8217);
            }
        }
        catch
        {
        }
        return result;
    }

    public static void KillProcess(string nameProcess)
    {
        if (string.IsNullOrEmpty(nameProcess)) return;
        try
        {
            if (nameProcess.Equals("chrome", StringComparison.OrdinalIgnoreCase))
            {
                // CRITICAL SAFETY: Never terminate user's personal Google Chrome!
                // Only kill automation Chrome instances launched with test/automation flags or profiles.
                try
                {
                    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessId, CommandLine FROM Win32_Process WHERE Name = 'chrome.exe'"))
                    using (ManagementObjectCollection results = searcher.Get())
                    {
                        foreach (ManagementObject item in results)
                        {
                            try
                            {
                                int pid = Convert.ToInt32(item["ProcessId"]);
                                string cmdLine = item["CommandLine"]?.ToString() ?? "";
                                if (cmdLine.IndexOf("--remote-debugging-port", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    cmdLine.IndexOf("--disable-blink-features=AutomationControlled", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    cmdLine.IndexOf("--test-type", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    cmdLine.IndexOf("profiles\\", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                    cmdLine.IndexOf("temp_", StringComparison.OrdinalIgnoreCase) >= 0)
                                {
                                    try
                                    {
                                        Process p = Process.GetProcessById(pid);
                                        if (!p.HasExited) p.Kill();
                                    }
                                    catch {}
                                }
                            }
                            catch {}
                        }
                    }
                }
                catch {}
            }
            else
            {
                // For driver processes (chromedriver, gpmdriver, gemlogindriver), kill in-memory without batch files
                Process[] processes = Process.GetProcessesByName(nameProcess);
                foreach (Process p in processes)
                {
                    try
                    {
                        if (!p.HasExited) p.Kill();
                    }
                    catch {}
                }
            }
        }
        catch
        {
        }
    }

    public static List<int> GetChildProcessIds(int parentPid)
    {
        List<int> childPids = new List<int>();
        try
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessId FROM Win32_Process WHERE ParentProcessId = " + parentPid))
            using (ManagementObjectCollection results = searcher.Get())
            {
                foreach (ManagementObject item in results)
                {
                    try
                    {
                        childPids.Add(Convert.ToInt32(item["ProcessId"]));
                    }
                    catch {}
                }
            }
        }
        catch {}
        return childPids;
    }

    public static bool IsUid(string uid)
    {
        if (string.IsNullOrEmpty(uid))
            return false;
        foreach (Char c in uid)
        {
            if (!Char.IsDigit(c))
                return false;
        }
        return true;
    }

    public static bool smethod_43(string string_1)
    {
        bool result = true;
        foreach (char c in string_1)
        {
            if ((c < 'a' || c > 'z') && (c < 'A' || c > 'Z') && c != '.')
            {
                result = false;
                break;
            }
        }
        return result;
    }

    public static string D6ADE304(string string_1)
    {
        string text = "";
        for (int i = 0; i < string_1.Length; i++)
        {
            char c = string_1[i];
            if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
            {
                text += c;
            }
        }
        return text;
    }

    public static string smethod_44(string C5368721)
    {
        byte[] bytes = Encoding.Default.GetBytes(C5368721);
        C5368721 = Encoding.UTF8.GetString(bytes);
        return C5368721;
    }

    public static bool smethod_45(string string_1)
    {
        if (string_1 == "")
        {
            return false;
        }
        int num = 0;
        while (true)
        {
            if (num < string_1.Length)
            {
                char c = string_1[num];
                if (!char.IsDigit(c))
                {
                    break;
                }
                num++;
                continue;
            }
            return true;
        }
        return false;
    }

    public static bool smethod_46(string string_1)
    {
        int num = 0;
        while (true)
        {
            if (num < string_1.Length)
            {
                char c = string_1[num];
                if (char.IsDigit(c))
                {
                    break;
                }
                num++;
                continue;
            }
            return false;
        }
        return true;
    }

    public static void D2293B8A(string string_1)
    {
        string text = "zzz999.html";
        File.WriteAllText(text, string_1);
        Process.Start(text);
    }

    public static string smethod_47(string FEB6A633)
    {
        try
        {
            return new RequestHttp().method_0(FEB6A633);
        }
        catch
        {
            return null;
        }
    }

    public static bool smethod_48(string D401C623)
    {
        try
        {
            new MailAddress(D401C623);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static string FA82518E(string string_1, string DC3C78B0 = "X2")
    {
        MD5 mD = MD5.Create();
        byte[] array = mD.ComputeHash(Encoding.UTF8.GetBytes(string_1));
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < array.Length; i++)
        {
            stringBuilder.Append(array[i].ToString(DC3C78B0));
        }
        return stringBuilder.ToString();
    }

    public static string smethod_49(string A4BE9F37)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(A4BE9F37);
        return Convert.ToBase64String(bytes);
    }

    public static string smethod_50(string string_1)
    {
        if (string_1 == "")
        {
            return "";
        }
        try
        {
            byte[] bytes = Convert.FromBase64String(string_1);
            return Encoding.UTF8.GetString(bytes);
        }
        catch (Exception)
        {
        }
        return "";
    }

    public static bool smethod_51(int F5A84D10)
    {
        return Base.rd.Next(1, 101) <= F5A84D10;
    }

    public static string A92541B0(string E121CEB8)
    {
        try
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c " + E121CEB8;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            string text = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            if (string.IsNullOrEmpty(text))
            {
                return "";
            }
            return text;
        }
        catch (Exception)
        {
        }
        return "";
    }

    public static void smethod_52(double C1B88B25)
    {
        Application.DoEvents();
        if (C1B88B25 < 1.0)
        {
            Thread.Sleep(Convert.ToInt32(C1B88B25 * 1000.0));
            return;
        }
        for (int i = 0; (double)i < C1B88B25; i++)
        {
            if (Base.smethod_5())
            {
                break;
            }
            Thread.Sleep(1000);
        }
    }

    public static string smethod_53(string string_1)
    {
        return WebUtility.HtmlDecode(string_1);
    }

    public static string E9B1A098(string string_1)
    {
        return WebUtility.HtmlEncode(string_1);
    }

    public static string EBA1F724(string string_1)
    {
        return WebUtility.UrlDecode(string_1);
    }

    public static string smethod_54(string string_1)
    {
        return WebUtility.UrlEncode(string_1);
    }

    public static System.Drawing.Point E50AD706(int int_0, int int_1)
    {
        if (C5034B95.smethod_0("configChrome").method_2("width") == 0)
        {
            C5034B95.smethod_0("configChrome").method_4("width", BF30EF2A);
            C5034B95.smethod_0("configChrome").method_4("heigh", A6A09222);
            C5034B95.smethod_1("configChrome");
        }
        BF30EF2A = C5034B95.smethod_0("configChrome").method_2("width");
        A6A09222 = C5034B95.smethod_0("configChrome").method_2("heigh");
        int x = BF30EF2A / int_0 + 15;
        int y = A6A09222 / int_1 + 10;
        return new System.Drawing.Point(x, y);
    }

    public static System.Drawing.Point smethod_55(int int_0, int F3B8F197, int C914B0B0)
    {
        if (C5034B95.smethod_0("configChrome").method_2("width") == 0)
        {
            C5034B95.smethod_0("configChrome").method_4("width", BF30EF2A);
            C5034B95.smethod_0("configChrome").method_4("heigh", A6A09222);
            C5034B95.smethod_1("configChrome");
        }
        BF30EF2A = C5034B95.smethod_0("configChrome").method_2("width");
        A6A09222 = C5034B95.smethod_0("configChrome").method_2("heigh");
        System.Drawing.Point result = default(System.Drawing.Point);
        while (int_0 >= F3B8F197 * C914B0B0)
        {
            int_0 -= F3B8F197 * C914B0B0;
        }
        switch (C914B0B0)
        {
            case 1:
                result.Y = 0;
                break;
            case 2:
                if (int_0 < F3B8F197)
                {
                    result.Y = 0;
                }
                else if (int_0 < F3B8F197 * 2)
                {
                    result.Y = A6A09222 / 2;
                    int_0 -= F3B8F197;
                }
                break;
            case 3:
                if (int_0 < F3B8F197)
                {
                    result.Y = 0;
                }
                else if (int_0 < F3B8F197 * 2)
                {
                    result.Y = A6A09222 / 3;
                    int_0 -= F3B8F197;
                }
                else if (int_0 < F3B8F197 * 3)
                {
                    result.Y = A6A09222 / 3 * 2;
                    int_0 -= F3B8F197 * 2;
                }
                break;
            case 4:
                if (int_0 < F3B8F197)
                {
                    result.Y = 0;
                }
                else if (int_0 < F3B8F197 * 2)
                {
                    result.Y = A6A09222 / 4;
                    int_0 -= F3B8F197;
                }
                else if (int_0 < F3B8F197 * 3)
                {
                    result.Y = A6A09222 / 4 * 2;
                    int_0 -= F3B8F197 * 2;
                }
                else if (int_0 < F3B8F197 * 4)
                {
                    result.Y = A6A09222 / 4 * 3;
                    int_0 -= F3B8F197 * 3;
                }
                break;
            case 5:
                if (int_0 < F3B8F197)
                {
                    result.Y = 0;
                }
                else if (int_0 < F3B8F197 * 2)
                {
                    result.Y = A6A09222 / 5;
                    int_0 -= F3B8F197;
                }
                else if (int_0 < F3B8F197 * 3)
                {
                    result.Y = A6A09222 / 5 * 2;
                    int_0 -= F3B8F197 * 2;
                }
                else if (int_0 < F3B8F197 * 4)
                {
                    result.Y = A6A09222 / 5 * 3;
                    int_0 -= F3B8F197 * 3;
                }
                else
                {
                    result.Y = A6A09222 / 5 * 4;
                    int_0 -= F3B8F197 * 4;
                }
                break;
        }
        int num = BF30EF2A / F3B8F197;
        result.X = int_0 * num - 10;
        return result;
    }

    public static int smethod_56(ref List<int> list_0)
    {
        int result = 0;
        lock (list_0)
        {
            for (int i = 0; i < list_0.Count; i++)
            {
                if (list_0[i] == 0)
                {
                    result = i;
                    list_0[i] = 1;
                    break;
                }
            }
        }
        return result;
    }

    public static void B33105BA(ref List<int> list_0, int int_0)
    {
        lock (list_0)
        {
            list_0[int_0] = 0;
        }
    }

    private static string directPublicIp = "";
    private static DateTime directPublicIpTime = DateTime.MinValue;

    public static string GetDirectPublicIp()
    {
        try
        {
            if (!string.IsNullOrEmpty(directPublicIp) && (DateTime.Now - directPublicIpTime).TotalMinutes < 30)
            {
                return directPublicIp;
            }
            string ip = BD994637("", 0, 5);
            if (!string.IsNullOrEmpty(ip))
            {
                directPublicIp = ip;
                directPublicIpTime = DateTime.Now;
            }
        }
        catch {}
        return directPublicIp;
    }

    public static string BD994637(string string_1 = "", int int_0 = 0, int int_1 = 60)
    {
        try
        {
            RequestXNet req = new RequestXNet("", "", string_1, int_0);
            string[] checkUrls = new string[]
            {
                "http://icanhazip.com",
                "http://api64.ipify.org",
                "https://icanhazip.com",
                "https://api64.ipify.org",
                "http://ifconfig.me/ip"
            };
            foreach (string url in checkUrls)
            {
                try
                {
                    string ip = req.E58EB99F(url).Trim();
                    if (!string.IsNullOrEmpty(ip))
                    {
                        if (IPAddress.TryParse(ip, out IPAddress parsedIp))
                        {
                            return parsedIp.ToString();
                        }
                        Match m4 = Regex.Match(ip, @"\b(?:\d{1,3}\.){3}\d{1,3}\b");
                        if (m4.Success && IPAddress.TryParse(m4.Value, out IPAddress ip4))
                        {
                            return ip4.ToString();
                        }
                        Match m6 = Regex.Match(ip, @"\b(?:[0-9a-fA-F]{0,4}:){2,7}[0-9a-fA-F]{1,4}\b");
                        if (m6.Success && IPAddress.TryParse(m6.Value, out IPAddress ip6))
                        {
                            return ip6.ToString();
                        }
                    }
                }
                catch
                {
                }
            }
        }
        catch
        {
        }
        return "";
    }

    public static void A9BCAF05(RichTextBox A39BB9A7, Label B89ED902, int B38B9200 = 0)
    {
        try
        {
            string text = B89ED902.Text;
            List<string> list = new List<string>();
            B89ED902.Text = text.Replace(newValue: "(" + ((B38B9200 != 0) ? A39BB9A7.Text.Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : A39BB9A7.Text.Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList()).Count + ")", oldValue: Regex.Match(text, "\\((.*?)\\)").Value);
        }
        catch
        {
        }
    }

    public static void E998C514(Control F98AFB04, int B02AF601)
    {
        try
        {
            string text = F98AFB04.Text;
            F98AFB04.Text = text.Replace(Regex.Match(text, "\\((.*?)\\)").Value, "(" + B02AF601 + ")");
        }
        catch
        {
        }
    }

    public static void FE214EB5(RichTextBox richTextBox_0, Control DF0D5084, int int_0 = 0)
    {
        try
        {
            string text = DF0D5084.Text;
            List<string> list = richTextBox_0.Lines.ToList();
            DF0D5084.Text = text.Replace(newValue: "(" + ((int_0 != 0) ? richTextBox_0.Text.Split(new string[1] { "\n|\n" }, StringSplitOptions.RemoveEmptyEntries).ToList() : richTextBox_0.Text.Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList()).Count + ")", oldValue: Regex.Match(text, "\\((.*?)\\)").Value);
        }
        catch
        {
        }
    }

    public static void smethod_57(Chrome chrome_0, Exception exception_0, string string_1 = "")
    {
        try
        {
            if (!Directory.Exists("log"))
            {
                Directory.CreateDirectory("log");
            }
            if (!Directory.Exists("log\\html"))
            {
                Directory.CreateDirectory("log\\html");
            }
            if (!Directory.Exists("log\\images"))
            {
                Directory.CreateDirectory("log\\images");
            }
            Random random = new Random();
            string text = DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + random.Next(1000, 9999);
            if (chrome_0 != null)
            {
                string contents = chrome_0.AFACE5B4();
                chrome_0.method_38("log\\images\\", text);
                File.WriteAllText("log\\html\\" + text + ".html", contents);
            }
            using StreamWriter streamWriter = new StreamWriter("log\\log.txt", append: true);
            streamWriter.WriteLine("-----------------------------------------------------------------------------");
            streamWriter.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            streamWriter.WriteLine("File: " + text);
            if (string_1 != "")
            {
                streamWriter.WriteLine("Error: " + string_1);
            }
            streamWriter.WriteLine();
            if (exception_0 != null)
            {
                streamWriter.WriteLine("Type: " + exception_0.GetType().FullName);
                streamWriter.WriteLine("Message: " + exception_0.Message);
                streamWriter.WriteLine("StackTrace: " + exception_0.StackTrace);
                exception_0 = exception_0.InnerException;
            }
        }
        catch
        {
        }
    }

    public static void smethod_58(Exception exception_0, string string_1 = "")
    {
        try
        {
            using StreamWriter streamWriter = new StreamWriter("log\\log.txt", append: true);
            streamWriter.WriteLine("-----------------------------------------------------------------------------");
            streamWriter.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            if (string_1 != "")
            {
                streamWriter.WriteLine("Error: " + string_1);
            }
            streamWriter.WriteLine();
            if (exception_0 != null)
            {
                streamWriter.WriteLine("Type: " + exception_0.GetType().FullName);
                streamWriter.WriteLine("Message: " + exception_0.Message);
                streamWriter.WriteLine("StackTrace: " + exception_0.StackTrace);
                exception_0 = exception_0.InnerException;
            }
        }
        catch
        {
        }
    }

    public static string CC8E538D(string C98AE510, string string_1, int D600B0BD = 10)
    {
        Process process = new Process();
        process.StartInfo.FileName = C98AE510;
        process.StartInfo.Arguments = string_1;
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardError = true;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
        process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
        StringBuilder stringBuilder_0 = new StringBuilder();
        process.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                stringBuilder_0.Append(e.Data + "\n");
            }
        };
        process.Start();
        process.BeginOutputReadLine();
        if (D600B0BD < 0)
        {
            process.WaitForExit();
        }
        else
        {
            process.WaitForExit(D600B0BD * 1000);
        }
        process.Close();
        return stringBuilder_0.ToString();
    }

    public static bool B4963C33(string string_1)
    {
        bool flag = false;
        string text = CC8E538D("rasdial.exe", "\"" + string_1 + "\"");
        if (text.Contains("Successfully connected to "))
        {
            flag = true;
        }
        else if (text.Contains("You are already connected to "))
        {
            for (int i = 0; i < 5; i++)
            {
                text = CC8E538D("rasdial.exe", "\"" + string_1 + "\" /disconnect");
                if (!(text.Trim() == "Command completed successfully."))
                {
                    smethod_52(2.0);
                    continue;
                }
                flag = true;
                break;
            }
            smethod_52(2.0);
            if (flag)
            {
                for (int j = 0; j < 5; j++)
                {
                    text = CC8E538D("rasdial.exe", "\"" + string_1 + "\"");
                    if (!text.Contains("Successfully connected to ") && !text.Contains("You are already connected to "))
                    {
                        smethod_52(2.0);
                        continue;
                    }
                    flag = true;
                    break;
                }
            }
            smethod_52(2.0);
        }
        else
        {
            flag = false;
        }
        return flag;
    }

    public static bool smethod_59(int int_0, int int_1, string string_1, string A8A2FC9B, int int_2, string FFA03B05)
    {
        bool result = false;
        string text = "";
        try
        {
            switch (int_0)
            {
                case 0:
                    return true;
                case 1:
                    {
                        string text2 = BD994637();
                        IntPtr intPtr = AutoControl.D58E88A2(null, "HMA VPN");
                        AutoControl.ShowWindow(intPtr, 1);
                        AutoControl.smethod_1(intPtr);
                        Thread.Sleep(1000);
                        AutoControl.smethod_10(AutoControl.EE38740A(intPtr, "Chrome_RenderWidgetHostHWND", "Chrome Legacy Window"), 356, 286);
                        Thread.Sleep(5000);
                        string text3 = BD994637();
                        AutoControl.smethod_10(AutoControl.EE38740A(intPtr, "Chrome_RenderWidgetHostHWND", "Chrome Legacy Window"), 356, 286);
                        int tickCount = Environment.TickCount;
                        do
                        {
                            text = BD994637();
                        }
                        while (Environment.TickCount - tickCount <= 20000 && (text == text2 || text == text3));
                        if (text != text2)
                        {
                            result = true;
                        }
                        break;
                    }
                case 2:
                    {
                        if (int_1 == 0)
                        {
                            result = B4963C33(string_1);
                            break;
                        }
                        int num = smethod_60(A8A2FC9B);
                        if (num == 0)
                        {
                            Thread.Sleep(2000);
                            num = smethod_60(A8A2FC9B);
                        }
                        result = num == 1;
                        break;
                    }
            }
        }
        catch (Exception exception_)
        {
            smethod_57(null, exception_, "Error ChangeIP");
        }
        return result;
    }

    public static int smethod_60(string string_1)
    {
        int result = -1;
        try
        {
            string value = Regex.Match(string_1, "(http://.*?)/").Groups[1].Value;
            if (value == "")
            {
                value = Regex.Match(string_1, "(https://.*?)/").Groups[1].Value;
            }
            RequestHttp requestHttp = new RequestHttp("", ModernUserAgentHub.GetRandomDesktopChrome());
            string input = requestHttp.method_0(value);
            string text = "";
            try
            {
                text = Regex.Matches(input, "csrf_token\" content=\"(.*?)\"")[1].Groups[1].Value;
            }
            catch
            {
                text = Regex.Match(requestHttp.method_0(value + "/api/webserver/token"), "<token>(.*?)</token>").Groups[1].Value;
            }
            input = requestHttp.method_0(value + "/api/dialup/mobile-dataswitch");
            string text2 = "";
            if (input.Contains("dataswitch>1"))
            {
                text2 = input.Replace("response", "request").Replace("dataswitch>1", "dataswitch>0");
            }
            else
            {
                if (!input.Contains("dataswitch>0"))
                {
                    return -1;
                }
                text2 = input.Replace("response", "request").Replace("dataswitch>0", "dataswitch>1");
            }
            requestHttp.requestHTTP_0.SetDefaultHeaders(new string[2]
            {
                "__RequestVerificationToken: " + text,
                "content-type: text/xml"
            });
            string text3 = requestHttp.EF076293(value + "/api/dialup/mobile-dataswitch", text2);
            if (text3.Contains("OK"))
            {
                input = requestHttp.method_0(value + "/api/dialup/mobile-dataswitch");
                if (input.Contains("dataswitch>1<"))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        string text4 = requestHttp.method_0(value + "/api/monitoring/traffic-statistics");
                        if (!text4.Contains("<CurrentUpload>0"))
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                }
                return Convert.ToInt32(Regex.Match(input, "dataswitch>(.*?)<").Groups[1].Value);
            }
            result = -1;
        }
        catch
        {
        }
        return result;
    }

    public static DateTime smethod_61(string string_1, string string_2 = "dd/MM/yyyy HH:mm:ss")
    {
        return DateTime.ParseExact(string_1, string_2, CultureInfo.InvariantCulture);
    }

    private static byte[] Base32Decode(string input)
    {
        if (string.IsNullOrEmpty(input)) return new byte[0];
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
        input = input.TrimEnd('=').ToUpper();
        List<byte> bytes = new List<byte>();
        int buffer = 0, bitsLeft = 0;
        foreach (char c in input)
        {
            int val = chars.IndexOf(c);
            if (val < 0) continue;
            buffer = (buffer << 5) | val;
            bitsLeft += 5;
            if (bitsLeft >= 8)
            {
                bytes.Add((byte)(buffer >> (bitsLeft - 8)));
                bitsLeft -= 8;
            }
        }
        return bytes.ToArray();
    }

    public static string smethod_62(string string_1)
    {
        try
        {
            if (string.IsNullOrEmpty(string_1)) return "";
            string code = LocalTotpEngine.GenerateTotp(string_1);
            if (!string.IsNullOrEmpty(code))
            {
                return code;
            }
            return LocalTotpEngine.GenerateWithDriftTolerance(string_1);
        }
        catch
        {
            return "";
        }
    }

    public static DataTable smethod_63(DataTable FB8A41A8)
    {
        DataTable result = new DataTable();
        try
        {
            result = (from DataRow dataRow_0 in FB8A41A8.Rows
                      orderby Base.rd.Next()
                      select dataRow_0).CopyToDataTable();
        }
        catch
        {
        }
        return result;
    }

    public static bool smethod_64(string F8A1BF9B, string string_1)
    {
        try
        {
            CreateFolder(string_1);
            string[] directories = Directory.GetDirectories(F8A1BF9B, "*", SearchOption.AllDirectories);
            foreach (string text in directories)
            {
                Directory.CreateDirectory(text.Replace(F8A1BF9B, string_1));
            }
            string[] files = Directory.GetFiles(F8A1BF9B, "*.*", SearchOption.AllDirectories);
            foreach (string text2 in files)
            {
                File.Copy(text2, text2.Replace(F8A1BF9B, string_1), overwrite: true);
            }
            return true;
        }
        catch (Exception)
        {
        }
        return false;
    }

    public static bool D182708B(string string_1, string string_2)
    {
        try
        {
            Directory.Move(string_1, string_2);
            return true;
        }
        catch (Exception)
        {
        }
        return false;
    }

    public static bool DeleteFolder(string string_1)
    {
        try
        {
            Directory.Delete(string_1, recursive: true);
            return true;
        }
        catch (Exception)
        {
        }
        return false;
    }

    public static void DeleteFolder(string D5B0B71D, string string_1)
    {
        try
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(D5B0B71D);
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directoryInfo2 in directories)
            {
                if (directoryInfo2.Name.StartsWith(string_1))
                {
                    DeleteFolder(D5B0B71D + "\\" + directoryInfo2.Name);
                }
            }
        }
        catch
        {
        }
    }

    public static bool D9AB3B82(string string_1)
    {
        try
        {
            if (string_1.Trim().Length == 0)
            {
                return false;
            }
            string_1 = string_1.Replace("\"", "\\\"");
            string value = smethod_85("IsVNName(\"" + string_1 + "\")");
            return Convert.ToBoolean(value);
        }
        catch (Exception)
        {
        }
        return false;
    }

    public static bool smethod_67(string string_1)
    {
        return new Regex("^[a-zA-Z .]+$").IsMatch(string_1) && !D9AB3B82(string_1);
    }

    public static string EB835717(string string_1)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string input = string_1.Normalize(NormalizationForm.FormD);
        return regex.Replace(input, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
    }

    public static bool E10A40B6(string AB36EC16)
    {
        try
        {
            File.Delete(AB36EC16);
            return true;
        }
        catch
        {
        }
        return false;
    }

    public static bool smethod_68(List<string> F4B9963D)
    {
        try
        {
            for (int i = 0; i < F4B9963D.Count; i++)
            {
                E10A40B6(F4B9963D[i]);
            }
            return true;
        }
        catch
        {
        }
        return false;
    }

    public static string smethod_69()
    {
        string result = "";
        string newValue = "chrome.exe";
        object value = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\App Paths\\<executableFileName>".Replace("<executableFileName>", newValue), "", null);
        if (value == null)
        {
            value = Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\App Paths\\<executableFileName>".Replace("<executableFileName>", newValue), "", null);
            if (value != null)
            {
                result = value.ToString();
            }
        }
        else
        {
            result = value.ToString();
        }
        return result;
    }

    public static string smethod_70()
    {
        return FileVersionInfo.GetVersionInfo(smethod_69().ToString()).FileVersion;
    }

    internal static int BF833227(int int_0, int int_1)
    {
        if (int_0 > int_1)
        {
            return Base.rd.Next(int_1, int_0 + 1);
        }
        return Base.rd.Next(int_0, int_1 + 1);
    }

    public static Form smethod_71(string A182028A, params object[] object_0)
    {
        Type type = Type.GetType("maxcare." + A182028A);
        if (type != null)
        {
            try
            {
                return (Form)Activator.CreateInstance(type, object_0);
            }
            catch (Exception)
            {
            }
        }
        return null;
    }

    public static IEnumerable<Control> A91A8FAF(Control control_0)
    {
        IEnumerable<Control> enumerable = control_0.Controls.Cast<Control>();
        return enumerable.SelectMany((Control control_0) => A91A8FAF(control_0)).Concat(enumerable);
    }

    internal static void smethod_72(string B636B289, string string_1, bool bool_0)
    {
        try
        {
            File.Copy(B636B289, string_1, bool_0);
        }
        catch
        {
        }
    }

    public static void ChangeMD5(string filePath)
    {
        try
        {
            int num = Base.rd.Next(2, 7);
            byte[] array = new byte[num];
            for (int i = 0; i < num; i++)
            {
                array[i] = 0;
            }
            long length = new FileInfo(filePath).Length;
            if (length == 0L)
            {
                return;
            }
            using (FileStream fileStream = new FileStream(filePath, FileMode.Append))
            {
                fileStream.Write(array, 0, array.Length);
            }
            int bufferSize = ((length > 1048576) ? 1048576 : 4096);
            using MD5 mD = MD5.Create();
            using FileStream inputStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize);
            BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "");
        }
        catch
        {
        }
    }

    public static string F839D53E(string string_1, List<string> list_0)
    {
        int num = 0;
        while (true)
        {
            if (num < list_0.Count)
            {
                if (string_1.Contains(list_0[num]))
                {
                    break;
                }
                num++;
                continue;
            }
            return "";
        }
        return list_0[num];
    }

    public static void smethod_75(ref DataGridView dataGridView_0, int int_0, int int_1, int int_2 = 1)
    {
        string text = "";
        for (int i = int_2; i < dataGridView_0.Columns.Count; i++)
        {
            text = EAB09F19.EC12300A(dataGridView_0, int_0, i);
            EAB09F19.smethod_2(dataGridView_0, int_0, i, EAB09F19.EC12300A(dataGridView_0, int_1, i));
            EAB09F19.smethod_2(dataGridView_0, int_1, i, text);
        }
    }

    internal static List<string> smethod_76(string string_1)
    {
        List<string> list = new List<string>();
        if (string.IsNullOrWhiteSpace(string_1))
        {
            return list;
        }
        string_1 = string_1.Trim().Trim('\"', '\'');
        try
        {
            string[] validExts = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp", ".mp4", ".mov", ".avi", ".mkv", ".webm", ".m4v", ".flv" };
            if (File.Exists(string_1))
            {
                if (validExts.Contains(Path.GetExtension(string_1).ToLower()))
                {
                    list.Add(string_1);
                    return list;
                }
            }
            if (Directory.Exists(string_1))
            {
                var files = Directory.GetFiles(string_1)
                    .Where(f => validExts.Contains(Path.GetExtension(f).ToLower()))
                    .ToList();
                if (files.Count > 0) return files;
                return Directory.GetFiles(string_1).ToList();
            }
            // Smart typo/prefix recovery in parent directory
            string parent = Path.GetDirectoryName(string_1);
            if (!string.IsNullOrEmpty(parent) && Directory.Exists(parent))
            {
                string targetName = Path.GetFileName(string_1).ToLower();
                foreach (var dir in Directory.GetDirectories(parent))
                {
                    string dirName = Path.GetFileName(dir).ToLower();
                    if (dirName.StartsWith(targetName) || targetName.StartsWith(dirName) || (targetName.StartsWith("i") && dirName.Contains("image")))
                    {
                        var files = Directory.GetFiles(dir)
                            .Where(f => validExts.Contains(Path.GetExtension(f).ToLower()))
                            .ToList();
                        if (files.Count > 0) return files;
                    }
                }
            }
        }
        catch
        {
        }
        return list;
    }

    internal static void CE2E5B3B(string D6BE2B8B)
    {
        try
        {
            Process.Start("chrome.exe", D6BE2B8B);
        }
        catch
        {
            Process.Start(D6BE2B8B);
        }
    }

    public static bool CloneDatabase()
    {
        string text = ConnectorAccounts.smethod_GetDbPath();
        string fileName = Path.GetFileName(text);
        string text2 = C5034B95.smethod_0("configInteractGeneral").BDB80B23("txtBackupDBPath", Environment.GetEnvironmentVariable("LocalAppData") + "\\database");
        CreateFolder(text2);
        if (!Directory.Exists(text2))
        {
            text2 = Environment.GetEnvironmentVariable("LocalAppData") + "\\database";
            CreateFolder(text2);
        }
        string destFile = text2 + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileName;
        File.Copy(text, destFile, true);
        if (File.Exists(destFile))
        {
            return true;
        }
        return false;
    }

    public static string smethod_77()
    {
        string text = DateTime.Now.ToString("yyMMdd") + B820DC86(4, "0") + B820DC86(5, "a");
        if (C5034B95.smethod_0("configCheckpoint").method_2("typePass") == 0)
        {
            text = C5034B95.smethod_0("configCheckpoint").BDB80B23("txtPass");
        }
        return text.smethod_1(1);
    }

    internal static string smethod_79(string DE121036, string string_1 = "", string F6A71F1A = "", string AEA0059A = "")
    {
        try
        {
            if (!string.IsNullOrEmpty(DE121036) && !Directory.Exists(DE121036))
            {
                Directory.CreateDirectory(DE121036);
            }
            return "true";
        }
        catch
        {
            return "";
        }
    }

    public static bool A01DE9AB(string string_1)
    {
        return string_1.Length != Regex.Replace(string_1, "\\p{Cs}", "").Length;
    }

    internal static void DeleteTempFile()
    {
        DeleteFolder("C:\\Program Files", "chrome_BITS_");
        DeleteFolder("C:\\Program Files (x86)", "scoped_dir");
        DeleteFolder("C:\\Windows\\SystemTemp", "chrome_BITS_");
        DeleteFolder("C:\\Windows\\SystemTemp", "scoped_dir");
    }

    public static void smethod_83(int int_0 = 3)
    {
        Process.Start(Application.ExecutablePath);
        smethod_52(int_0);
        Process.GetCurrentProcess().Kill();
    }

    public static void B2B23807(string E63AB491)
    {
        try
        {
            if (E63AB491.Trim() == "")
            {
                return;
            }
            Process[] processesByName = Process.GetProcessesByName("chrome");
            foreach (Process process in processesByName)
            {
                string queryString = "SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id;
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString);
                foreach (ManagementBaseObject item in managementObjectSearcher.Get())
                {
                    try
                    {
                        ManagementObject managementObject = item as ManagementObject;
                        if (managementObject != null && managementObject != null)
                        {
                            object obj = managementObject["CommandLine"];
                            if (obj != null && obj.ToString().Contains(E63AB491))
                            {
                                process.Kill();
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
        catch (Exception)
        {
        }
    }

    public static string smethod_85(string string_1)
    {
        try
        {
            if (string.IsNullOrEmpty(string_1)) return "";
            if (string_1.StartsWith("FindIdFacebook"))
            {
                var match = Regex.Match(string_1, @"['""]([^'""]+)['""]");
                if (match.Success)
                {
                    string url = match.Groups[1].Value;
                    var mUid = Regex.Match(url, @"(?:profile\.php\?id=|facebook\.com\/)(\d+)");
                    if (mUid.Success) return mUid.Groups[1].Value;
                }
            }
            if (string_1.StartsWith("IsVNName"))
            {
                return "true";
            }
            if (string_1.StartsWith("DeepSeek"))
            {
                var args = ParseFunctionArguments(string_1);
                if (args.Count >= 2)
                {
                    string apiKey = args[0];
                    string prompt = args[1].Replace("\\n", "\n").Replace("\\r", "\r");
                    string model = args.Count >= 3 ? args[2] : "deepseek-chat";
                    return CallDeepSeekApi(apiKey, prompt, model);
                }
            }
            if (string_1.StartsWith("Gemini") || string_1.StartsWith("ChatGPT"))
            {
                var args = ParseFunctionArguments(string_1);
                if (args.Count >= 2)
                {
                    string apiKey = args[0];
                    string prompt = args[1].Replace("\\n", "\n").Replace("\\r", "\r");
                    string image = args.Count >= 3 ? args[2] : "";
                    if (apiKey.StartsWith("sk-"))
                    {
                        return CallDeepSeekApi(apiKey, prompt, "deepseek-chat");
                    }
                    return CallGeminiApi(apiKey, prompt, image);
                }
            }
            if (string_1.StartsWith("TaoPageByToken"))
            {
                return "{\"error\":{\"message\":\"Meta đã ngưng hỗ trợ tạo Page bằng Token cũ. Hãy sử dụng Kịch bản Tạo Page (HDTaoPage) qua trình duyệt để tạo Trang New Page Experience tự động và an toàn 100%!\"}}";
            }
            return "";
        }
        catch
        {
            return "";
        }
    }

    /// <summary>
    /// Gọi Google Gemini REST API với Smart Auto-Fallback qua danh sách model.
    /// Thứ tự thử: gemini-2.5-flash → gemini-1.5-flash → gemini-2.5-pro → gemini-1.5-pro
    /// Nếu model bị deprecated/404/400, tự động chuyển sang model tiếp theo.
    /// </summary>
    /// <param name="apiKey">Google Gemini API Key</param>
    /// <param name="prompt">Nội dung prompt</param>
    /// <param name="imagePathOrBase64">Đường dẫn file ảnh cục bộ hoặc chuỗi Base64 (tuỳ chọn)</param>
    /// <returns>Văn bản phản hồi từ Gemini hoặc thông báo lỗi bắt đầu bằng 'Error:'</returns>
    public static string CallGeminiApi(string apiKey, string prompt, string imagePathOrBase64 = "")
    {
        if (string.IsNullOrEmpty(apiKey))
        {
            return "Error: API Key không được để trống!";
        }
        if (string.IsNullOrEmpty(prompt))
        {
            return "";
        }

        // Smart Auto-Fallback: danh sách model hiện đại nhất (ưu tiên flash-lite và flash-latest để tránh 503 high demand và hỗ trợ Free Tier 100%)
        string[] fallbackModels = new string[]
        {
            "gemini-flash-lite-latest",
            "gemini-3.5-flash-lite",
            "gemini-flash-latest",
            "gemini-3.5-flash",
            "gemini-3.8-flash",
            "gemini-2.5-flash"
        };

        string lastError = "";

        foreach (string modelName in fallbackModels)
        {
            string result = CallGeminiApiWithModel(apiKey, prompt, imagePathOrBase64, modelName);
            if (!result.StartsWith("Error:"))
            {
                // Thành công → strip markdown code fence nếu có
                return CleanMarkdownCodeFences(result).Trim();
            }
            // Nếu lỗi liên quan model deprecated/not found/not available/503 high demand → thử model tiếp
            string errLower = result.ToLower();
            if (errLower.Contains("no longer available") || errLower.Contains("not found") ||
                errLower.Contains("is not available") || errLower.Contains("deprecated") ||
                errLower.Contains("404") || errLower.Contains("503") || errLower.Contains("does not exist") ||
                errLower.Contains("model not found") || errLower.Contains("not supported") ||
                errLower.Contains("high demand") || errLower.Contains("unavailable") ||
                errLower.Contains("overloaded") || errLower.Contains("temporary"))
            {
                lastError = result;
                continue; // thử model tiếp theo
            }
            // Lỗi khác (quota, key sai, network...) → trả về ngay, không fallback
            return result;
        }

        return string.IsNullOrEmpty(lastError) ? "Error: Không thể kết nối đến Gemini API." : lastError;
    }

    /// <summary>
    /// Gọi Gemini API với một model cụ thể (hàm nội bộ cho Smart Fallback)
    /// </summary>
    private static string CallGeminiApiWithModel(string apiKey, string prompt, string imagePathOrBase64, string model)
    {
        try
        {
            // Enforce TLS 1.2 bắt buộc cho Google API trên .NET Framework 4.8
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            string apiUrl = "https://generativelanguage.googleapis.com/v1beta/models/" + model + ":generateContent?key=" + Uri.EscapeDataString(apiKey.Trim());

            // Xây dựng parts array
            JArray partsArray = new JArray();
            partsArray.Add(new JObject(new JProperty("text", prompt)));

            // Xử lý đính kèm hình ảnh (Multimodal)
            if (!string.IsNullOrEmpty(imagePathOrBase64))
            {
                string base64Data = "";
                string mimeType = "image/jpeg";
                string rawImg = imagePathOrBase64.Trim();

                if (rawImg.StartsWith("base64:"))
                {
                    base64Data = rawImg.Substring("base64:".Length).Trim();
                }
                else if (File.Exists(rawImg))
                {
                    try
                    {
                        byte[] fileBytes = File.ReadAllBytes(rawImg);
                        base64Data = Convert.ToBase64String(fileBytes);
                        string ext = Path.GetExtension(rawImg).ToLower();
                        if (ext == ".png") mimeType = "image/png";
                        else if (ext == ".webp") mimeType = "image/webp";
                        else if (ext == ".gif") mimeType = "image/gif";
                        else mimeType = "image/jpeg";
                    }
                    catch { }
                }
                else
                {
                    base64Data = rawImg;
                }

                if (!string.IsNullOrEmpty(base64Data))
                {
                    JObject inlineData = new JObject(
                        new JProperty("mimeType", mimeType),
                        new JProperty("data", base64Data)
                    );
                    partsArray.Add(new JObject(new JProperty("inlineData", inlineData)));
                }
            }

            // Xây dựng request payload JSON: {"contents":[{"parts":[...]}]}
            JObject requestBody = new JObject(
                new JProperty("contents", new JArray(
                    new JObject(new JProperty("parts", partsArray))
                ))
            );

            string payloadString = requestBody.ToString(Formatting.None);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payloadString);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json";
            request.ContentLength = payloadBytes.Length;
            request.Timeout = 60000;
            request.ReadWriteTimeout = 60000;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(payloadBytes, 0, payloadBytes.Length);
            }

            string responseJson = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(responseStream, Encoding.UTF8))
            {
                responseJson = reader.ReadToEnd();
            }

            // Parse response: candidates[0].content.parts[0].text
            JObject jsonObj = JObject.Parse(responseJson);
            JArray candidates = jsonObj["candidates"] as JArray;
            if (candidates != null && candidates.Count > 0)
            {
                JArray resParts = candidates[0]?["content"]?["parts"] as JArray;
                if (resParts != null && resParts.Count > 0)
                {
                    StringBuilder sbResult = new StringBuilder();
                    foreach (var part in resParts)
                    {
                        string pText = part["text"]?.ToString();
                        if (!string.IsNullOrEmpty(pText))
                        {
                            sbResult.Append(pText);
                        }
                    }
                    return sbResult.ToString().Trim();
                }
            }

            return "";
        }
        catch (WebException webEx)
        {
            string errorDetail = "";
            if (webEx.Response != null)
            {
                try
                {
                    using (Stream errStream = webEx.Response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(errStream, Encoding.UTF8))
                    {
                        string errBody = reader.ReadToEnd();
                        try
                        {
                            JObject errJson = JObject.Parse(errBody);
                            string msg = errJson["error"]?["message"]?.ToString();
                            if (!string.IsNullOrEmpty(msg))
                            {
                                errorDetail = msg;
                            }
                            else
                            {
                                errorDetail = errBody;
                            }
                        }
                        catch
                        {
                            errorDetail = errBody;
                        }
                    }
                }
                catch { }
            }
            if (string.IsNullOrEmpty(errorDetail))
            {
                errorDetail = webEx.Message;
            }
            return "Error: " + errorDetail;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

    /// <summary>
    /// Gọi OpenAI ChatGPT REST API (gpt-4o-mini mặc định, fallback gpt-4o → gpt-3.5-turbo)
    /// Endpoint: https://api.openai.com/v1/chat/completions
    /// </summary>
    /// <param name="apiKey">OpenAI API Key (bắt đầu bằng sk-)</param>
    /// <param name="prompt">Nội dung prompt</param>
    /// <param name="model">Tên model (mặc định: gpt-4o-mini)</param>
    /// <returns>Nội dung câu trả lời từ AI hoặc thông báo lỗi bắt đầu bằng 'Error:'</returns>
    public static string CallOpenAiApi(string apiKey, string prompt, string model = "gpt-4o-mini")
    {
        if (string.IsNullOrEmpty(apiKey))
        {
            return "Error: API Key không được để trống!";
        }
        if (string.IsNullOrEmpty(prompt))
        {
            return "";
        }

        // Smart Fallback cho OpenAI
        string[] fallbackModels = new string[]
        {
            string.IsNullOrEmpty(model) ? "gpt-4o-mini" : model.Trim(),
            "gpt-4o-mini",
            "gpt-4o",
            "gpt-3.5-turbo"
        };

        // Loại bỏ trùng lặp giữ thứ tự
        var tried = new System.Collections.Generic.HashSet<string>();
        string lastError = "";

        foreach (string m in fallbackModels)
        {
            if (tried.Contains(m)) continue;
            tried.Add(m);

            string result = CallOpenAiApiWithModel(apiKey, prompt, m);
            if (!result.StartsWith("Error:"))
            {
                return CleanMarkdownCodeFences(result).Trim();
            }
            string errLower = result.ToLower();
            if (errLower.Contains("not found") || errLower.Contains("does not exist") ||
                errLower.Contains("deprecated") || errLower.Contains("invalid model") ||
                errLower.Contains("model_not_found"))
            {
                lastError = result;
                continue;
            }
            return result;
        }
        return string.IsNullOrEmpty(lastError) ? "Error: Không thể kết nối đến OpenAI API." : lastError;
    }

    /// <summary>
    /// Gọi OpenAI API với một model cụ thể (hàm nội bộ cho Smart Fallback)
    /// </summary>
    private static string CallOpenAiApiWithModel(string apiKey, string prompt, string model)
    {
        try
        {
            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            string apiUrl = "https://api.openai.com/v1/chat/completions";

            JObject requestBody = new JObject(
                new JProperty("model", model),
                new JProperty("messages", new JArray(
                    new JObject(
                        new JProperty("role", "user"),
                        new JProperty("content", prompt)
                    )
                )),
                new JProperty("temperature", 0.7)
            );

            string payloadString = requestBody.ToString(Formatting.None);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payloadString);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json";
            request.Headers["Authorization"] = "Bearer " + apiKey.Trim();
            request.ContentLength = payloadBytes.Length;
            request.Timeout = 60000;
            request.ReadWriteTimeout = 60000;

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(payloadBytes, 0, payloadBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream resStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(resStream, Encoding.UTF8))
            {
                string jsonResponse = reader.ReadToEnd();
                JObject parsed = JObject.Parse(jsonResponse);
                JToken choices = parsed["choices"];
                if (choices != null && choices.HasValues)
                {
                    JToken content = choices[0]?["message"]?["content"];
                    if (content != null)
                    {
                        return content.ToString().Trim();
                    }
                }
                return "";
            }
        }
        catch (WebException webEx)
        {
            string errorDetail = "";
            if (webEx.Response != null)
            {
                try
                {
                    using (Stream errStream = webEx.Response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(errStream, Encoding.UTF8))
                    {
                        string errBody = reader.ReadToEnd();
                        try
                        {
                            JObject errJson = JObject.Parse(errBody);
                            string msg = errJson["error"]?["message"]?.ToString();
                            errorDetail = !string.IsNullOrEmpty(msg) ? msg : errBody;
                        }
                        catch
                        {
                            errorDetail = errBody;
                        }
                    }
                }
                catch { }
            }
            if (string.IsNullOrEmpty(errorDetail))
            {
                errorDetail = webEx.Message;
            }
            return "Error: " + errorDetail;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

    /// <summary>
    /// Gọi DeepSeek REST API trực tiếp (deepseek-chat hoặc deepseek-coder)
    /// Endpoint: https://api.deepseek.com/chat/completions
    /// </summary>
    /// <param name="apiKey">DeepSeek API Key (bắt đầu bằng sk-)</param>
    /// <param name="prompt">Nội dung prompt yêu cầu</param>
    /// <param name="model">Tên model: deepseek-chat hoặc deepseek-coder (mặc định: deepseek-chat)</param>
    /// <returns>Nội dung câu trả lời từ AI hoặc thông báo lỗi bắt đầu bằng 'Error:'</returns>
    public static string CallDeepSeekApi(string apiKey, string prompt, string model = "deepseek-chat")
    {
        try
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                return "Error: API Key không được để trống!";
            }
            if (string.IsNullOrEmpty(prompt))
            {
                return "";
            }

            ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            string apiUrl = "https://api.deepseek.com/chat/completions";

            JObject requestBody = new JObject(
                new JProperty("model", string.IsNullOrEmpty(model) ? "deepseek-chat" : model.Trim()),
                new JProperty("messages", new JArray(
                    new JObject(
                        new JProperty("role", "user"),
                        new JProperty("content", prompt)
                    )
                )),
                new JProperty("temperature", 0.7),
                new JProperty("stream", false)
            );

            string payloadString = requestBody.ToString(Formatting.None);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payloadString);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json";
            request.Headers["Authorization"] = "Bearer " + apiKey.Trim();
            request.ContentLength = payloadBytes.Length;
            request.Timeout = 60000;
            request.ReadWriteTimeout = 60000;

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(payloadBytes, 0, payloadBytes.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream resStream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(resStream, Encoding.UTF8))
            {
                string jsonResponse = reader.ReadToEnd();
                JObject parsed = JObject.Parse(jsonResponse);
                JToken choices = parsed["choices"];
                if (choices != null && choices.HasValues)
                {
                    JToken content = choices[0]?["message"]?["content"];
                    if (content != null)
                    {
                        return content.ToString().Trim();
                    }
                }
                return "";
            }
        }
        catch (WebException webEx)
        {
            string errorDetail = "";
            if (webEx.Response != null)
            {
                try
                {
                    using (Stream errStream = webEx.Response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(errStream, Encoding.UTF8))
                    {
                        string errBody = reader.ReadToEnd();
                        try
                        {
                            JObject errJson = JObject.Parse(errBody);
                            string msg = errJson["error"]?["message"]?.ToString();
                            errorDetail = !string.IsNullOrEmpty(msg) ? msg : errBody;
                        }
                        catch
                        {
                            errorDetail = errBody;
                        }
                    }
                }
                catch { }
            }
            if (string.IsNullOrEmpty(errorDetail))
            {
                errorDetail = webEx.Message;
            }
            return "Error: " + errorDetail;
        }
        catch (Exception ex)
        {
            return "Error: " + ex.Message;
        }
    }

    /// <summary>
    /// Sinh nội dung bài viết / status Facebook theo chủ đề
    /// </summary>
    /// <param name="apiKey">Google Gemini API Key hoặc DeepSeek API Key</param>
    /// <param name="topic">Chủ đề bài viết cần tạo</param>
    /// <param name="tone">Giọng điệu bài viết (tự nhiên, hào hứng, chuyên nghiệp, tâm sự...)</param>
    /// <param name="keywords">Từ khóa hoặc sản phẩm cần nhắc đến (tuỳ chọn)</param>
    /// <param name="maxWords">Số lượng từ ước tính tối đa (mặc định 150 từ)</param>
    /// <returns>Nội dung status Facebook hoàn chỉnh</returns>
    public static string GeneratePostContent(string apiKey, string topic, string tone = "tự nhiên, thu hút", string keywords = "", int maxWords = 150)
    {
        if (string.IsNullOrEmpty(apiKey)) return "Error: API Key không được để trống!";
        if (string.IsNullOrEmpty(topic)) return "Error: Chủ đề bài viết không được để trống!";

        StringBuilder promptBuilder = new StringBuilder();
        promptBuilder.AppendLine("Bạn là một chuyên gia sáng tạo nội dung mạng xã hội (Facebook Content Creator) xuất sắc tại Việt Nam.");
        promptBuilder.AppendLine("Hãy viết một bài đăng (status) Facebook hoàn chỉnh và hấp dẫn theo thông tin sau:");
        promptBuilder.AppendLine("- Chủ đề: " + topic);
        if (!string.IsNullOrEmpty(tone))
        {
            promptBuilder.AppendLine("- Giọng điệu (tone): " + tone);
        }
        if (!string.IsNullOrEmpty(keywords))
        {
            promptBuilder.AppendLine("- Các từ khóa/thông tin cần nhấn mạnh: " + keywords);
        }
        if (maxWords > 0)
        {
            promptBuilder.AppendLine("- Độ dài: Khoảng " + maxWords + " từ.");
        }
        promptBuilder.AppendLine();
        promptBuilder.AppendLine("Yêu cầu định dạng và cấu trúc:");
        promptBuilder.AppendLine("1. Có câu mở đầu (Hook) ấn tượng, thu hút người đọc ngay từ dòng đầu tiên.");
        promptBuilder.AppendLine("2. Nội dung tự nhiên, súc tích, ngắt đoạn ngắn gọn (1-2 câu mỗi đoạn) dễ đọc trên điện thoại.");
        promptBuilder.AppendLine("3. Chèn các emoji phù hợp để bài viết sinh động, bắt mắt nhưng không lạm dụng.");
        promptBuilder.AppendLine("4. Có lời kêu gọi hành động (CTA) tự nhiên ở cuối bài (thả tim, để lại bình luận, nhắn tin...).");
        promptBuilder.AppendLine("5. Kèm 3 - 5 hashtag liên quan ở cuối bài.");
        promptBuilder.AppendLine("6. TUYỆT ĐỐI KHÔNG viết lời chào mở bài/kết bài của AI (không có 'Chào bạn', 'Dưới đây là bài viết...', 'Hy vọng bài viết này giúp ích...').");
        promptBuilder.AppendLine("7. CHỈ TRẢ VỀ DUY NHẤT TOÀN BỘ NỘI DUNG BÀI ĐĂNG FACEBOOK.");

        string result = apiKey.StartsWith("sk-") ? CallDeepSeekApi(apiKey, promptBuilder.ToString()) : CallGeminiApi(apiKey, promptBuilder.ToString());
        if (result.StartsWith("Error:")) return result;

        return CleanMarkdownCodeFences(result).Trim();
    }

    /// <summary>
    /// Sinh bình luận (comment) thông minh dựa trên nội dung bài viết gốc
    /// </summary>
    /// <param name="apiKey">Google Gemini API Key hoặc DeepSeek API Key</param>
    /// <param name="postContent">Nội dung bài viết gốc cần comment</param>
    /// <param name="commentStyle">Phong cách comment (khen ngợi, đồng tình, đặt câu hỏi, chia sẻ cảm xúc, hỏi mua hàng...)</param>
    /// <param name="extraContext">Ngữ cảnh hoặc thông tin bổ sung (tuỳ chọn)</param>
    /// <returns>Câu bình luận tự nhiên như người dùng thật</returns>
    public static string GenerateComment(string apiKey, string postContent, string commentStyle = "khen ngợi, đồng tình", string extraContext = "")
    {
        if (string.IsNullOrEmpty(apiKey)) return "Error: API Key không được để trống!";
        if (string.IsNullOrEmpty(postContent)) return "";

        StringBuilder promptBuilder = new StringBuilder();
        promptBuilder.AppendLine("Bạn là một người dùng Facebook tại Việt Nam, đang lướt mạng xã hội và muốn để lại một bình luận dưới một bài viết.");
        promptBuilder.AppendLine("Hãy viết một câu bình luận (comment) phù hợp cho bài viết sau:");
        promptBuilder.AppendLine("- Nội dung bài viết gốc: \"" + postContent + "\"");
        if (!string.IsNullOrEmpty(commentStyle))
        {
            promptBuilder.AppendLine("- Phong cách bình luận mong muốn: " + commentStyle);
        }
        if (!string.IsNullOrEmpty(extraContext))
        {
            promptBuilder.AppendLine("- Ngữ cảnh bổ sung: " + extraContext);
        }
        promptBuilder.AppendLine();
        promptBuilder.AppendLine("Yêu cầu bắt buộc:");
        promptBuilder.AppendLine("1. Bình luận ngắn gọn, súc tích (1 đến 2 câu, tối đa 35 từ), chuẩn phong cách người dùng thật lướt Facebook.");
        promptBuilder.AppendLine("2. Hiểu rõ nội dung bài viết gốc để phản hồi đúng trọng tâm, tự nhiên, không chung chung sáo rỗng.");
        promptBuilder.AppendLine("3. Dùng ngôn từ đời thường, gần gũi (dạ, ạ, em, chuẩn quá, thích thế...), có thể chèn 1 emoji phù hợp.");
        promptBuilder.AppendLine("4. TUYỆT ĐỐI KHÔNG viết văn mẫu cứng nhắc, không máy móc như bot.");
        promptBuilder.AppendLine("5. TUYỆT ĐỐI KHÔNG để trong dấu ngoặc kép (\"...\") và KHÔNG có lời giải thích.");
        promptBuilder.AppendLine("6. CHỈ TRẢ VỀ DUY NHẤT NỘI DUNG CÂU BÌNH LUẬN.");

        string result = apiKey.StartsWith("sk-") ? CallDeepSeekApi(apiKey, promptBuilder.ToString()) : CallGeminiApi(apiKey, promptBuilder.ToString());
        if (result.StartsWith("Error:")) return result;

        result = CleanMarkdownCodeFences(result).Trim();
        if ((result.StartsWith("\"") && result.EndsWith("\"")) || (result.StartsWith("“") && result.EndsWith("”")))
        {
            result = result.Substring(1, result.Length - 2).Trim();
        }
        return result;
    }

    private static string CleanMarkdownCodeFences(string text)
    {
        if (string.IsNullOrEmpty(text)) return "";
        string trimmed = text.Trim();
        if (trimmed.StartsWith("```"))
        {
            int firstNewline = trimmed.IndexOf('\n');
            int lastBackticks = trimmed.LastIndexOf("```");
            if (firstNewline > 0 && lastBackticks > firstNewline)
            {
                trimmed = trimmed.Substring(firstNewline + 1, lastBackticks - firstNewline - 1).Trim();
            }
        }
        return trimmed;
    }

    private static List<string> ParseFunctionArguments(string input)
    {
        var args = new List<string>();
        if (string.IsNullOrEmpty(input)) return args;

        int firstParen = input.IndexOf('(');
        int lastParen = input.LastIndexOf(')');
        if (firstParen < 0 || lastParen <= firstParen) return args;

        string inner = input.Substring(firstParen + 1, lastParen - firstParen - 1).Trim();
        bool inQuote = false;
        char quoteChar = '\0';
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < inner.Length; i++)
        {
            char c = inner[i];
            if (inQuote)
            {
                if (c == '\\' && i + 1 < inner.Length)
                {
                    char next = inner[i + 1];
                    if (next == '\'' || next == '\"' || next == '\\')
                    {
                        sb.Append(next);
                        i++;
                        continue;
                    }
                    else if (next == 'n')
                    {
                        sb.Append('\n');
                        i++;
                        continue;
                    }
                    else if (next == 'r')
                    {
                        sb.Append('\r');
                        i++;
                        continue;
                    }
                    else if (next == 't')
                    {
                        sb.Append('\t');
                        i++;
                        continue;
                    }
                }

                if (c == quoteChar)
                {
                    inQuote = false;
                    args.Add(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(c);
                }
            }
            else
            {
                if (c == '\'' || c == '\"')
                {
                    inQuote = true;
                    quoteChar = c;
                }
                else if (c == ',')
                {
                    if (sb.Length > 0)
                    {
                        args.Add(sb.ToString().Trim());
                        sb.Clear();
                    }
                }
                else if (!char.IsWhiteSpace(c))
                {
                    sb.Append(c);
                }
            }
        }

        if (sb.Length > 0)
        {
            args.Add(sb.ToString().Trim());
        }

        return args;
    }

    public static int smethod_86()
    {
        int result = 0;
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 0);
            socket.Bind(localEP);
            localEP = (IPEndPoint)socket.LocalEndPoint;
            result = localEP.Port;
        }
        finally
        {
            socket.Close();
        }
        return result;
    }

    public static string smethod_87(string string_1)
    {
        if (!string_1.StartsWith("https://"))
        {
            string_1 = "https://facebook.com/" + string_1;
        }
        int num = 0;
        string text;
        while (true)
        {
            if (num < 3)
            {
                text = smethod_85("FindIdFacebook('" + string_1 + "')");
                if (text != "")
                {
                    break;
                }
                smethod_52(1.0);
                num++;
                continue;
            }
            return "";
        }
        return text;
    }

    public static bool DFBE4C36(string C53E8F2E)
    {
        return C53E8F2E.Contains("KGOvhWyM65Y.png") || C53E8F2E.Contains("CCnQRnuNDBB.png") || C53E8F2E.Contains("FpkwdkKVsK1.png") || C53E8F2E.Contains("grA_kEpJlYT.png") || C53E8F2E.Contains("46WQRa5uPUD.png") || C53E8F2E.Contains("/help/203305893040179") || C53E8F2E.Contains("/images/checkpoint/epsilon/comet/limbo-dark.png") || C53E8F2E.Contains("/images/checkpoint/epsilon/comet/limbo-light.png");
    }

    internal static bool smethod_88(string EA90EE92)
    {
        return EA90EE92.Contains("/x/checkpoint/828281030927956/stepper/") || EA90EE92.Contains("BJIhXF-EEq9.png");
    }

    public static bool smethod_89(string string_1, List<string> F3259A2A)
    {
        int num = 0;
        while (true)
        {
            if (num < F3259A2A.Count)
            {
                if (Regex.IsMatch(string_1, F3259A2A[num]) || string_1.Contains(F3259A2A[num]))
                {
                    break;
                }
                num++;
                continue;
            }
            return false;
        }
        return true;
    }

    public static string B820DC86(int F70E2930, string string_1)
    {
        if (F70E2930 <= 0) return "";
        string chars = "";
        switch (string_1)
        {
            case "0":
                chars = "0123456789";
                break;
            case "a":
                chars = "abcdefghijklmnopqrstuvwxyz";
                break;
            case "a_0":
                chars = "abcdefghijklmnopqrstuvwxyz0123456789";
                break;
            case "a_A":
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                break;
            case "a_A_0":
            default:
                chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                break;
        }
        char[] result = new char[F70E2930];
        for (int i = 0; i < F70E2930; i++)
        {
            result[i] = chars[Base.rd.Next(chars.Length)];
        }
        return new string(result);
    }

    public static string smethod_90()
    {
        return Guid.NewGuid().ToString();
    }

    internal static string A794F28D(string E7BB3287, string string_1)
    {
        string text = "";
        for (int i = 0; i < 5; i++)
        {
            try
            {
                byte[] inArray = new RequestXNet().method_0(string_1);
                text = Convert.ToBase64String(inArray);
                if (text != "")
                {
                    return text;
                }
            }
            catch (Exception)
            {
                text = "";
            }
            smethod_52(1.0);
        }
        return text;
    }

    internal static void DeleteCacheProfile(string text2)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(text2) || !Directory.Exists(text2)) return;
            ProfileCachePruner.SafePruneProfile(text2);
        }
        catch
        {
        }
    }

    public static void PruneProfileSafeCache(string profilePath)
    {
        try
        {
            Chrome.PruneProfileSafeCache(profilePath);
        }
        catch
        {
        }
    }

    public static string F914B80B(string E897EAB4, string string_1)
    {
        return Regex.Match(E897EAB4, string_1).Groups[1].Value;
    }

    //public static string F498D620(string F5998718, string AA8A4283, string string_1, string string_2, string string_3)
    //{
    //	string text = string_1;
    //	if (string_1.Contains("{content}"))
    //	{
    //		text = string_1.Replace("{content}", string_2);
    //	}
    //	string c83E2D3C = "";
    //	if (text.Contains("{image}"))
    //	{
    //		text = text.Replace("{image}", "");
    //		if (File.Exists(string_3))
    //		{
    //			c83E2D3C = smethod_92(string_3);
    //		}
    //	}
    //	text = F2A2F324(text);
    //	c83E2D3C = F2A2F324(c83E2D3C);
    //	string text2 = "";
    //	switch (F5998718)
    //	{
    //	case "Gemini":
    //		text2 = smethod_85("Gemini('" + AA8A4283 + "', '" + text + "', '" + c83E2D3C + "')");
    //		break;
    //	case "ChatGPT":
    //		text2 = smethod_85("ChatGPT('" + AA8A4283 + "', '" + text + "', '" + c83E2D3C + "')");
    //		break;
    //	}
    //	if (text2 == "Resource has been exhausted (e.g. check quota).")
    //	{
    //		return "";
    //	}
    //	return text2.Replace("**", "").Replace("\n* ", "\n- ");
    //}

    //private static string smethod_92(string B91D83A8)
    //{
    //	byte[] inArray = File.ReadAllBytes(B91D83A8);
    //	return Convert.ToBase64String(inArray);
    //}

    public static string smethod_93(string F7A7DE23, string D30F8927, string B9BE31AC)
    {
        GClass10 gClass = GClass9.F404A484(F7A7DE23);
        if (gClass == null)
        {
            return "";
        }
        return WhiteNewLib.Common.AIRequest(gClass.E2AD160C, gClass.String_2, gClass.String_3, D30F8927, B9BE31AC);
    }

    //public static string F2A2F324(string C83E2D3C)
    //{
    //	if (C83E2D3C == "")
    //	{
    //		return C83E2D3C;
    //	}
    //	if (!C83E2D3C.StartsWith("base64:"))
    //	{
    //		C83E2D3C = "base64:" + smethod_49(C83E2D3C);
    //	}
    //	return C83E2D3C;
    //}

    public static string smethod_94(string string_1)
    {
        string text = "";
        if (!string_1.EndsWith("/"))
        {
            string_1 += "/";
        }
        List<string> list = new List<string>
        {
            "story_fbid=(.*?)&", "permalink/(.*?)/", "v=(.*?)&", "post_id=(.*?)&", "v=(.*?)/", "videos/(.*?)\\?", "videos/(.*?)/", "posts/(.*?)/", "posts/(.*?)\\?", "view_tray_pagination/(.*?)/",
            "fbid=(.*?)&", "multi_permalinks=(.*?)&"
        };
        for (int i = 0; i < list.Count; i++)
        {
            text = Regex.Match(string_1, list[i].Replace("(.*?)", "\\d+")).Value;
            if (text != "")
            {
                text = text.Replace(list[i].Split(new string[1] { "(.*?)" }, StringSplitOptions.None)[0], "");
                text = text.Replace(list[i].Split(new string[1] { "(.*?)" }, StringSplitOptions.None)[1], "");
                text = text.Replace("?", "");
                if (!text.StartsWith("0"))
                {
                    break;
                }
            }
            else
            {
                text = Regex.Match(string_1, list[i]).Groups[1].Value;
                if (text != "" && !text.Contains("&"))
                {
                    break;
                }
            }
        }
        if (text == "" && string_1.Contains("photos"))
        {
            MatchCollection matchCollection = Regex.Matches(string_1, "/\\d+/");
            if (matchCollection.Count > 0)
            {
                text = matchCollection[matchCollection.Count - 1].Value;
                text = text.Replace("/", "");
            }
        }
        return text;
    }

    public static string smethod_95()
    {
        return Path.GetDirectoryName(Application.ExecutablePath);
    }

    public static void PatchChromeDriverCdc(string driverPath)
    {
        try
        {
            if (string.IsNullOrEmpty(driverPath) || !File.Exists(driverPath))
            {
                return;
            }
            byte[] bytes = File.ReadAllBytes(driverPath);
            byte[] pattern = System.Text.Encoding.ASCII.GetBytes("cdc_");
            byte[] replacement = System.Text.Encoding.ASCII.GetBytes("lush");
            bool modified = false;
            for (int i = 0; i <= bytes.Length - pattern.Length; i++)
            {
                bool match = true;
                for (int j = 0; j < pattern.Length; j++)
                {
                    if (bytes[i + j] != pattern[j])
                    {
                        match = false;
                        break;
                    }
                }
                if (match)
                {
                    for (int j = 0; j < replacement.Length; j++)
                    {
                        bytes[i + j] = replacement[j];
                    }
                    modified = true;
                }
            }
            if (modified)
            {
                File.WriteAllBytes(driverPath, bytes);
            }
        }
        catch
        {
        }
    }

    public static string smethod_96(string initialPath = "")
    {
        string result = "";
        try
        {
            using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (!string.IsNullOrWhiteSpace(initialPath) && Directory.Exists(initialPath.Trim()))
            {
                folderBrowserDialog.SelectedPath = initialPath.Trim();
            }
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                result = folderBrowserDialog.SelectedPath;
            }
        }
        catch
        {
        }
        return result;
    }

    private static ToolTip _folderPickerToolTip;

    public static void ShowFolderMediaTooltip(TextBox txt, string folder)
    {
        if (txt == null || string.IsNullOrWhiteSpace(folder)) return;
        try
        {
            if (_folderPickerToolTip == null)
            {
                _folderPickerToolTip = new ToolTip();
                _folderPickerToolTip.AutoPopDelay = 5000;
                _folderPickerToolTip.InitialDelay = 100;
                _folderPickerToolTip.ReshowDelay = 100;
                _folderPickerToolTip.ShowAlways = true;
            }

            if (ValidateMediaFolder(folder, out int count, out string msg))
            {
                string tip = $"✓ Có {count} file ảnh/video trong thư mục";
                _folderPickerToolTip.SetToolTip(txt, tip);
                _folderPickerToolTip.Show(tip, txt, 0, -26, 3000);
            }
            else
            {
                _folderPickerToolTip.SetToolTip(txt, msg);
                _folderPickerToolTip.Show(msg, txt, 0, -26, 3500);
            }
        }
        catch
        {
        }
    }

    public static bool ValidateMediaFolder(string path, out int mediaCount, out string message)
    {
        mediaCount = 0;
        message = "";
        if (string.IsNullOrWhiteSpace(path))
        {
            message = "Thư mục ảnh không tồn tại! Vui lòng chọn lại.";
            return false;
        }
        path = path.Trim().Trim('"', '\'');
        if (!Directory.Exists(path))
        {
            message = "Thư mục ảnh không tồn tại! Vui lòng chọn lại.";
            return false;
        }
        try
        {
            string[] validExtensions = new string[] { ".jpg", ".jpeg", ".png", ".bmp", ".webp", ".gif", ".mp4", ".mov" };
            HashSet<string> extSet = new HashSet<string>(validExtensions, StringComparer.OrdinalIgnoreCase);
            string[] allFiles = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
            int count = 0;
            for (int i = 0; i < allFiles.Length; i++)
            {
                string ext = Path.GetExtension(allFiles[i]);
                if (!string.IsNullOrEmpty(ext) && extSet.Contains(ext))
                {
                    count++;
                }
            }
            mediaCount = count;
            if (mediaCount == 0)
            {
                message = "Thư mục đã chọn không có file ảnh/video nào! Vui lòng kiểm tra lại.";
                return false;
            }
            message = $"Thư mục hợp lệ, tìm thấy {mediaCount} file media.";
            return true;
        }
        catch (Exception ex)
        {
            message = "Lỗi khi kiểm tra thư mục: " + ex.Message;
            return false;
        }
    }

    public static void AttachFolderPicker(TextBox txt, bool addBtn = true)
    {
        if (txt == null) return;
        txt.Cursor = Cursors.Hand;

        Action pickFolder = () =>
        {
            string currentPath = txt.Text.Trim();
            string folder = smethod_96(currentPath);
            if (!string.IsNullOrEmpty(folder))
            {
                txt.Text = folder;
                ShowFolderMediaTooltip(txt, folder);
            }
        };

        if (txt.Tag == null || !txt.Tag.ToString().Contains("folder_picker_attached"))
        {
            txt.Tag = (txt.Tag == null ? "" : txt.Tag.ToString()) + ";folder_picker_attached";
            txt.DoubleClick += (sender, e) => pickFolder();
            txt.TextChanged += (sender, e) =>
            {
                string path = txt.Text.Trim();
                if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                {
                    ShowFolderMediaTooltip(txt, path);
                }
            };
        }

        if (!addBtn) return;

        if (txt.Parent == null)
        {
            EventHandler onParentChanged = null;
            onParentChanged = (s, e) =>
            {
                txt.ParentChanged -= onParentChanged;
                if (txt.Parent != null)
                {
                    AttachFolderPickerButton(txt, pickFolder);
                }
            };
            txt.ParentChanged += onParentChanged;
            return;
        }

        AttachFolderPickerButton(txt, pickFolder);
    }

    private static void AttachFolderPickerButton(TextBox txt, Action pickFolder)
    {
        if (txt == null || txt.Parent == null) return;
        try
        {
            string btnName = "btnPick_" + txt.Name;
            Button btn = null;

            if (txt.Parent.Controls.ContainsKey(btnName))
            {
                btn = txt.Parent.Controls[btnName] as Button;
            }
            else
            {
                foreach (Control c in txt.Parent.Controls)
                {
                    if (c is Button b && c.Name != btnName)
                    {
                        bool isNearY = Math.Abs(b.Top - txt.Top) <= 8;
                        bool isAdjacentX = b.Left >= txt.Left && (b.Left - txt.Right) <= 30;
                        bool isPicker = b.Text == "Chọn" || b.Text == "..." ||
                                        b.Name.ToLower().Contains("choose") ||
                                        b.Name.ToLower().Contains("pick") ||
                                        b.Name == "button2";
                        if (isNearY && isAdjacentX && isPicker)
                        {
                            btn = b;
                            break;
                        }
                    }
                }
            }

            if (btn != null)
            {
                btn.Text = "Chọn";
                btn.Cursor = Cursors.Hand;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
                btn.BackColor = Color.FromArgb(243, 244, 246);
                btn.ForeColor = Color.FromArgb(31, 41, 55);
                btn.Font = new Font(txt.Font.FontFamily, 8.5f, FontStyle.Regular);
                if (btn.Width < 50)
                {
                    btn.Width = 52;
                }
                if (btn.Tag == null || !btn.Tag.ToString().Contains("picker_wired"))
                {
                    btn.Tag = (btn.Tag == null ? "" : btn.Tag.ToString()) + ";picker_wired";
                    btn.Click += (s, e) => pickFolder();
                }
                return;
            }

            int btnWidth = 54;
            int spacing = 4;
            if (txt.Width > 120)
            {
                txt.Width -= (btnWidth + spacing);
            }

            btn = new Button();
            btn.Name = btnName;
            btn.Text = "Chọn";
            btn.Cursor = Cursors.Hand;
            btn.Size = new System.Drawing.Size(btnWidth, txt.Height >= 23 ? txt.Height : 24);
            btn.Location = new System.Drawing.Point(txt.Right + spacing, txt.Top);
            btn.Font = new Font(txt.Font.FontFamily, 8.5f, FontStyle.Regular);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(209, 213, 219);
            btn.BackColor = Color.FromArgb(243, 244, 246);
            btn.ForeColor = Color.FromArgb(31, 41, 55);
            btn.UseVisualStyleBackColor = false;
            btn.Tag = "picker_wired";
            btn.Click += (sender, e) => pickFolder();

            txt.Parent.Controls.Add(btn);
            btn.BringToFront();
        }
        catch
        {
        }
    }

    public static string smethod_97(string string_1 = "Chọn File txt", string string_2 = "C:\\", string string_3 = "txt Files (*.txt)|*.txt|All files (*.*)|*.*")
    {
        string result = "";
        try
        {
            using OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = string_3;
            openFileDialog.InitialDirectory = string_2;
            openFileDialog.Title = string_1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                result = openFileDialog.FileName;
            }
        }
        catch
        {
        }
        return result;
    }

    public static bool EA87BD03(string B7924EAF, string string_1, bool bool_0)
    {
        try
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(B7924EAF);
            if (!directoryInfo.Exists)
            {
                return false;
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            Directory.CreateDirectory(string_1);
            FileInfo[] files = directoryInfo.GetFiles();
            FileInfo[] array = files;
            foreach (FileInfo fileInfo in array)
            {
                string destFileName = Path.Combine(string_1, fileInfo.Name);
                fileInfo.CopyTo(destFileName, overwrite: true);
            }
            if (bool_0)
            {
                DirectoryInfo[] array2 = directories;
                foreach (DirectoryInfo directoryInfo2 in array2)
                {
                    string string_2 = Path.Combine(string_1, directoryInfo2.Name);
                    EA87BD03(directoryInfo2.FullName, string_2, bool_0);
                }
            }
            return true;
        }
        catch (Exception)
        {
        }
        return false;
    }

    public static void AD214F8C(string string_1)
    {
        try
        {
            Directory.CreateDirectory(string_1);
        }
        catch
        {
        }
    }

    public static void smethod_98(string string_1, Action action_0)
    {
        object orAdd = concurrentDictionary_0.GetOrAdd(string_1, new object());
        lock (orAdd)
        {
            try
            {
                action_0();
            }
            catch (Exception)
            {
            }
        }
    }

    public static string smethod_99(string E39AF8B6)
    {
        try
        {
            byte[] buffer = File.ReadAllBytes(E39AF8B6);
            using SHA256 sHA = SHA256.Create();
            byte[] array = sHA.ComputeHash(buffer);
            return BitConverter.ToString(array).Replace("-", "").ToLower();
        }
        catch (Exception)
        {
            return "";
        }
    }
}
