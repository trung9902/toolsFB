using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;

internal class CommonSQL
{
	[Serializable]
	[CompilerGenerated]
	private sealed class EABDF619
	{
		internal static readonly EABDF619 _003C_003E9 = new EABDF619();

		internal static Func<string, string> _003C_003E9__20_0;

		internal static Func<string, string> _003C_003E9__20_1;

		internal static Func<DataRow, Class65> _003C_003E9__33_0;

		internal static Func<DataRow, Class65> _003C_003E9__35_0;

		internal static Func<DataRow, Class65> _003C_003E9__40_0;

		internal string method_0(string string_0)
		{
			return string_0.ToLower();
		}

		internal string D8A0CA8C(string string_0)
		{
			return string_0.ToLower();
		}

		internal Class65 F724E496(DataRow dataRow_0)
		{
			return new Class65
			{
				Int32_0 = Convert.ToInt32(dataRow_0["id"]),
				DDAA0B14 = Convert.ToString(dataRow_0["tenChuDe"]),
				String_4 = Convert.ToString(dataRow_0["ngaytao"]),
				String_1 = Convert.ToString(dataRow_0["anh"]),
				String_2 = Convert.ToString(dataRow_0["video"]),
				String_0 = Convert.ToString(dataRow_0["tieude"]),
				String_3 = Convert.ToString(dataRow_0["noidung"])
			};
		}

		internal Class65 D88593B0(DataRow dataRow_0)
		{
			return new Class65
			{
				Int32_0 = Convert.ToInt32(dataRow_0["id"]),
				DDAA0B14 = Convert.ToString(dataRow_0["tenChuDe"]),
				String_4 = Convert.ToString(dataRow_0["ngaytao"]),
				String_1 = Convert.ToString(dataRow_0["anh"]),
				String_2 = Convert.ToString(dataRow_0["video"]),
				String_0 = Convert.ToString(dataRow_0["tieude"]),
				String_3 = Convert.ToString(dataRow_0["noidung"])
			};
		}

		internal Class65 method_1(DataRow FD088EA5)
		{
			return new Class65
			{
				Int32_0 = Convert.ToInt32(FD088EA5["id"]),
				DDAA0B14 = Convert.ToString(FD088EA5["tenChuDe"]),
				String_4 = Convert.ToString(FD088EA5["ngaytao"]),
				String_1 = Convert.ToString(FD088EA5["anh"]),
				String_2 = Convert.ToString(FD088EA5["video"]),
				String_0 = Convert.ToString(FD088EA5["tieude"]),
				String_3 = Convert.ToString(FD088EA5["noidung"])
			};
		}
	}

	public static bool smethod_0(string D7B08BAB)
	{
		return Class60.smethod_0("SELECT COUNT(*) FROM files WHERE name='" + D7B08BAB + "' AND active=1;") > 0;
	}

	public static DataTable smethod_1(bool bool_0 = false, bool bool_1 = false)
	{
		DataTable result = new DataTable();
		try
		{
			string text = "";
			text = (bool_1 ? (bool_0 ? ("select id, name, STT from files WHERE id IN (SELECT DISTINCT idfile FROM accounts WHERE active=0) UNION SELECT -2 AS id, '" + Language.GetValue("[Tất cả thư mục]") + "' AS name, -2 AS STT UNION SELECT 999999 AS id, '" + Language.GetValue("[Chọn nhiều thư mục]") + "' AS name, 999999 AS STT ORDER BY STT") : "select id, name from files WHERE id IN (SELECT DISTINCT idfile FROM accounts WHERE active=0) ORDER BY STT") : (bool_0 ? ("select id, name, STT from files where active=1 UNION SELECT -2 AS id, '" + Language.GetValue("[Tất cả thư mục]") + "' AS name, -2 AS STT UNION SELECT 999999 AS id, '" + Language.GetValue("[Chọn nhiều thư mục]") + "' AS name, 999999 AS STT ORDER BY STT") : "select id, name from files where active=1 ORDER BY STT"));
			result = Class60.EEBF5BBB(text);
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static DataTable D0A8D8BC()
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = (C5034B95.smethod_4() ? "DROP TEMPORARY TABLE IF EXISTS tmp;CREATE TEMPORARY TABLE tmp (Stt INT AUTO_INCREMENT PRIMARY KEY, id INT, name TEXT);INSERT INTO tmp (id, name)SELECT id, name FROM files WHERE active = 1 ORDER BY Stt;SELECT id, CONCAT(Stt, '. ', name) AS Ten FROM tmp;" : "DROP TABLE IF EXISTS tmp;CREATE TEMPORARY TABLE tmp(Stt INTEGER PRIMARY KEY AUTOINCREMENT, id INTEGER, name TEXT);INSERT INTO tmp (id, name) select id, name from files where active=1 ORDER BY STT;SELECT id, (Stt||'. '||name) AS Ten FROM tmp;");
			result = Class60.EEBF5BBB(string_);
		}
		catch
		{
		}
		return result;
	}

	public static bool smethod_2(string C43F3A25)
	{
		bool result = true;
		try
		{
			int num = Class60.smethod_0("SELECT IFNULL(MAX(STT),0) FROM files");
			string string_ = "INSERT INTO files (name, createddate, active, STT) values('" + C43F3A25 + "','" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "',1," + (num + 1) + ")";
			Class60.EEBF5BBB(string_);
			return result;
		}
		catch
		{
			return false;
		}
	}

	public static bool smethod_3(string C41B1098, string string_0)
	{
		try
		{
			string f23A8E = "UPDATE files SET name='" + string_0 + "' where id=" + C41B1098;
			return Class60.E211632E(f23A8E) > 0;
		}
		catch
		{
		}
		return false;
	}

	public static bool smethod_4(string string_0)
	{
		bool result = false;
		try
		{
			if (Class60.smethod_0("SELECT COUNT(idfile) FROM accounts WHERE idfile=" + string_0) == 0)
			{
				result = Class60.E211632E("delete from files where id=" + string_0) > 0;
				return result;
			}
			if (Class60.E211632E("UPDATE files SET active=0 where id=" + string_0) > 0)
			{
				result = A2037203(string_0);
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static bool smethod_5(string E9A13F95, List<string> A4143DAB, string string_0 = "accounts")
	{
		List<string> list = new List<string>();
		string text = "";
		string text2 = "";
		string text3 = "";
		for (int i = 0; i < A4143DAB.Count; i++)
		{
			text = A4143DAB[i].Split('|')[0];
			text2 = A4143DAB[i].Split('|')[1];
			if (!string.IsNullOrEmpty(text))
			{
				list.Add(text);
				text3 = text3 + "WHEN '" + text + "' THEN '" + text2 + "' ";
			}
		}
		string f23A8E = "UPDATE " + string_0 + " SET " + E9A13F95 + " = CASE id " + text3 + "END WHERE id IN('" + string.Join("','", list) + "'); ";
		return Class60.E211632E(f23A8E) > 0;
	}

	public static bool smethod_6(JArray jarray_0, string string_0 = "uid")
	{
		List<string> list = new List<string>();
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		foreach (JObject item in jarray_0)
		{
			string text = item[string_0]!.ToString();
			if (text == "")
			{
				continue;
			}
			list.Add(text);
			foreach (JProperty item2 in item.Properties())
			{
				if (!(item2.Name == string_0))
				{
					if (!dictionary.ContainsKey(item2.Name))
					{
						dictionary.Add(item2.Name, new List<string>());
					}
					dictionary[item2.Name].Add("WHEN '" + text + "' THEN '" + item2.Value?.ToString() + "' ");
				}
			}
		}
		string text2 = "UPDATE accounts SET ";
		foreach (KeyValuePair<string, List<string>> item3 in dictionary)
		{
			string key = item3.Key;
			text2 = text2 + key + " = CASE " + string_0 + " " + string.Join(" ", item3.Value) + " END, ";
		}
		text2 = text2.TrimEnd(' ', ',') + " WHERE " + string_0 + " IN('" + string.Join("','", list) + "'); ";
		return Class60.E211632E(text2) > 0;
	}

	public static bool smethod_7()
	{
		bool result = false;
		try
		{
			result = Class60.E211632E("delete from files where id NOT IN (SELECT DISTINCT idfile FROM accounts) AND active=0") > 0;
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static DataTable B3B3608F()
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = "SELECT id, status FROM accounts WHERE active=1";
			result = Class60.EEBF5BBB(string_);
		}
		catch
		{
		}
		return result;
	}

	public static DataTable F314C9A4(List<string> list_0, bool E62F2A92 = true)
	{
		DataTable result = new DataTable();
		try
		{
			string text = "";
			text = ((list_0 != null && list_0.Count != 0) ? ("where idfile IN (" + string.Join(",", list_0) + ") AND active=" + (E62F2A92 ? 1 : 0)) : ("where active=" + (E62F2A92 ? 1 : 0)));
			string string_ = "SELECT '-1' as id, '" + Language.GetValue("[Tất cả tình trạng]") + "' AS name UNION select DISTINCT '0' as id,info from accounts " + text + " ORDER BY id,name ASC";
			result = Class60.EEBF5BBB(string_);
		}
		catch
		{
		}
		return result;
	}

	public static List<string> smethod_8(List<string> list_0)
	{
		List<string> list = new List<string>();
		try
		{
			int num = 100;
			int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)list_0.Count * 1.0 / 100.0)));
			string text = "";
			for (int i = 0; i < num2; i++)
			{
				text = "INSERT INTO accounts(uid, pass,token,cookie1,email,name,friends,groups,birthday,gender,info,fa2,idfile,passmail,useragent,proxy,dateCreateAcc,dateImport,mailrecovery,passmailrecovery,active,ghiChu,location,backup) VALUES " + string.Join(",", list_0.GetRange(num * i, (num * i + num <= list_0.Count) ? num : (list_0.Count % num)));
				list.Add(text);
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	public static string E503ACA8(string EF29D124, string string_0, string string_1, string EBAFB70F, string string_2, string string_3, string string_4, string AD39D1AF, string string_5, string string_6, string string_7, string string_8, string string_9, string string_10, string string_11, string CDAA9C8D, string string_12, string string_13, string string_14, string string_15, string E6230737, string string_16)
	{
		string text = "";
		try
		{
			text = "('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}',1,'{20}','{21}','{22}')";
			text = string.Format(text, EF29D124.Replace("'", "''"), string_0.Replace("'", "''"), string_1, EBAFB70F, string_2.Replace("'", "''"), string_3.Replace("'", "''"), string_4, AD39D1AF, string_5, string_6, string_7, string_8, string_9, string_10.Replace("'", "''"), string_11, CDAA9C8D, string_12, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), string_13, string_14, string_15, E6230737, string_16);
		}
		catch
		{
		}
		return text;
	}

	public static bool UpdateField(string id, string fieldName, string value)
	{
		return B8A0E617(id, fieldName, value);
	}

	public static bool B8A0E617(string C5A80B30, string DCA4D009, string string_0)
	{
		bool result = false;
		try
		{
			if (C5034B95.smethod_4())
			{
				List<string> list = new List<string> { "pass", "interactEnd", "info", "status282" };
				if (!list.Contains(DCA4D009))
				{
					return true;
				}
			}
			string text = "";
			if (DCA4D009 == "pass")
			{
				text += ",pass_old=pass";
			}
			if (DCA4D009 == "email")
			{
				text += ",email_old=email";
			}
			if (DCA4D009 == "passmail")
			{
				text += ",passmail_old=passmail";
			}
			if (DCA4D009 == "uid" && string_0.ToString().Trim() == "")
			{
				return false;
			}
			if (DCA4D009 == "cookie1" && string_0.ToString().Trim() == "")
			{
				return false;
			}
			string f23A8E = "update accounts set " + DCA4D009 + " = '" + string_0.Replace("'", "''") + "'" + text + " where id=" + C5A80B30;
			return Class60.E211632E(f23A8E) > 0;
		}
		catch
		{
		}
		return result;
	}

	public static bool smethod_9(string E72FDB9E, string string_0, string DC22668D, bool bool_0 = true)
	{
		bool result = false;
		try
		{
			if (string_0.Split('|').Length == DC22668D.Split('|').Length)
			{
				int num = string_0.Split('|').Length;
				string text = "";
				for (int i = 0; i < num; i++)
				{
					if (bool_0 || !(DC22668D.Split('|')[i].Trim() == ""))
					{
						text = text + string_0.Split('|')[i] + "='" + DC22668D.Split('|')[i].Replace("'", "''") + "',";
					}
				}
				text = text.TrimEnd(',');
				string f23A8E = "update accounts set " + text + " where id=" + E72FDB9E;
				result = Class60.E211632E(f23A8E) > 0;
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static bool E1BF11BA(List<string> B6038C2A, string string_0, string F9280C06)
	{
		bool result = false;
		try
		{
			if (string_0.Split('|').Length == F9280C06.Split('|').Length)
			{
				int num = string_0.Split('|').Length;
				string text = "";
				for (int i = 0; i < num; i++)
				{
					string text2 = string_0.Split('|')[i];
					text = text + text2 + "='" + F9280C06.Split('|')[i].Replace("'", "''") + "',";
					if (text2 == "email")
					{
						text += "email_old=email,";
					}
				}
				text = text.TrimEnd(',');
				int num2 = 100;
				int num3 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)B6038C2A.Count * 1.0 / 100.0)));
				List<string> list = new List<string>();
				string text3 = "";
				for (int j = 0; j < num3; j++)
				{
					text3 = "update accounts set " + text + " where id IN (" + string.Join(",", B6038C2A.GetRange(num2 * j, (num2 * j + num2 <= B6038C2A.Count) ? num2 : (B6038C2A.Count % num2))) + ")";
					list.Add(text3);
				}
				if (Class60.C138B888(list) > 0)
				{
					result = true;
					return result;
				}
				result = false;
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static bool B4B6DF28(string string_0, string string_1, string BF1532A8)
	{
		bool result = false;
		try
		{
			string f23A8E = "update files set " + string_1 + " = '" + BF1532A8.Replace("'", "''") + "' where id=" + string_0;
			if (Class60.E211632E(f23A8E) > 0)
			{
				result = true;
				return result;
			}
			result = false;
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static bool smethod_10(List<string> B4975598, string string_0, string string_1)
	{
		bool result = false;
		try
		{
			int num = 100;
			int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)B4975598.Count * 1.0 / 100.0)));
			List<string> list = new List<string>();
			string text = "";
			string text2 = "";
			if (string_0 == "pass")
			{
				text2 = ",pass_old=pass";
			}
			if (string_0 == "email")
			{
				text2 = ",email_old=email";
			}
			if (string_0 == "passmail")
			{
				text2 = ",passmail_old=passmail";
			}
			for (int i = 0; i < num2; i++)
			{
				text = "update accounts set " + string_0 + " = '" + string_1.Replace("'", "''") + "'" + text2 + " where id IN (" + string.Join(",", B4975598.GetRange(num * i, (num * i + num <= B4975598.Count) ? num : (B4975598.Count % num))) + ")";
				list.Add(text);
			}
			return Class60.C138B888(list) > 0;
		}
		catch (Exception ex)
		{
			Commom.smethod_58(null, ex.ToString());
		}
		return result;
	}

	public static bool F31E3E8E(List<string> list_0, string string_0, string E81EBC88)
	{
		bool result = true;
		try
		{
			string f23A8E = "update files set " + string_0 + " = '" + E81EBC88 + "' where id IN (" + string.Join(",", list_0) + ")";
			if (Class60.E211632E(f23A8E) > 0)
			{
				result = true;
				return result;
			}
			result = false;
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static DataTable A23CD00B(List<string> CA3BE4A9 = null, string string_0 = "", bool bool_0 = true)
	{
		DataTable result = new DataTable();
		try
		{
			string text = "WHERE ";
			string text2 = ((CA3BE4A9 == null || CA3BE4A9.Count <= 0) ? "" : ("t1.idFile IN (" + string.Join(",", CA3BE4A9) + ")"));
			if (text2 != "")
			{
				text = text + text2 + " AND ";
			}
			string text3 = ((string_0 != "") ? ("t1.info = '" + string_0 + "'") : "");
			if (text3 != "")
			{
				text = text + text3 + " AND ";
			}
			string text4 = $"t1.active = '{(bool_0 ? 1 : 0)}'";
			text += text4;
			string string_ = "SELECT t1.*, t2.name AS nameFile FROM accounts t1 JOIN files t2 ON t1.idfile=t2.id " + text + " ORDER BY t1.idfile";
			result = Class60.EEBF5BBB(string_);
		}
		catch
		{
		}
		return result;
	}

	public static DataTable FAACE83A(List<string> list_0, bool bool_0 = true, bool bool_1 = false)
	{
		DataTable result = new DataTable();
		try
		{
			if (list_0[0].Contains("Mozilla") || bool_1)
			{
				int num = 100;
				int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)list_0.Count * 1.0 / 100.0)));
				List<string> list = new List<string>();
				string text = "";
				for (int i = 0; i < num2; i++)
				{
					text = "SELECT t1.*, t2.name AS nameFile FROM accounts t1 JOIN files t2 ON t1.idfile=t2.id WHERE t1.useragent IN ('" + string.Join("','", list_0.GetRange(num * i, (num * i + num <= list_0.Count) ? num : (list_0.Count % num))) + "') and t1.active=" + (bool_0 ? "1" : "0") + " ORDER BY t1.useragent";
					list.Add(text);
				}
				result = Class60.A720858D(list);
			}
			else if (list_0[0].StartsWith("@"))
			{
				list_0 = list_0.Select((string string_0) => string_0.ToLower()).ToList();
				List<string> list2 = new List<string>();
				string text2 = "";
				for (int j = 0; j < list_0.Count; j++)
				{
					text2 = "SELECT t1.*, t2.name AS nameFile FROM accounts t1 JOIN files t2 ON t1.idfile=t2.id WHERE t1.email Like ('%" + list_0[j] + "%') and t1.active=" + (bool_0 ? "1" : "0");
					list2.Add(text2);
				}
				result = Class60.A720858D(list2);
			}
			else if (list_0[0].Contains("@"))
			{
				list_0 = list_0.Select((string string_0) => string_0.ToLower()).ToList();
				int num3 = 100;
				int num4 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)list_0.Count * 1.0 / 100.0)));
				List<string> list3 = new List<string>();
				string text3 = "";
				for (int k = 0; k < num4; k++)
				{
					text3 = "SELECT t1.*, t2.name AS nameFile FROM accounts t1 JOIN files t2 ON t1.idfile=t2.id WHERE t1.email IN ('" + string.Join("','", list_0.GetRange(num3 * k, (num3 * k + num3 <= list_0.Count) ? num3 : (list_0.Count % num3))) + "') and t1.active=" + (bool_0 ? "1" : "0") + " ORDER BY t1.email";
					list3.Add(text3);
				}
				result = Class60.A720858D(list3);
			}
			else
			{
				int num5 = 5000;
				int num6 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)list_0.Count * 1.0 / 5000.0)));
				List<string> list4 = new List<string>();
				string text4 = "";
				for (int l = 0; l < num6; l++)
				{
					text4 = "SELECT t1.*, t2.name AS nameFile FROM accounts t1 JOIN files t2 ON t1.idfile=t2.id WHERE t1.uid IN ('" + string.Join("','", list_0.GetRange(num5 * l, (num5 * l + num5 <= list_0.Count) ? num5 : (list_0.Count % num5))) + "') and t1.active=" + (bool_0 ? "1" : "0") + " ORDER BY t1.uid";
					list4.Add(text4);
				}
				result = Class60.A720858D(list4);
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "GetAccFromFile");
		}
		return result;
	}

	public static DataTable smethod_11(List<string> list_0)
	{
		DataTable result = new DataTable();
		try
		{
			int num = 100;
			int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)list_0.Count * 1.0 / 100.0)));
			List<string> list = new List<string>();
			string text = "";
			for (int i = 0; i < num2; i++)
			{
				text = "SELECT t1.*, t2.name AS nameFile FROM accounts t1 JOIN files t2 ON t1.idfile=t2.id WHERE t1.email IN ('" + string.Join("','", list_0.GetRange(num * i, (num * i + num <= list_0.Count) ? num : (list_0.Count % num))) + "') and t1.active=1 ORDER BY t1.email";
				list.Add(text);
			}
			result = Class60.A720858D(list);
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "GetAccFromFile");
		}
		return result;
	}

	public static DataTable smethod_12(bool bool_0 = true)
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = $"select uid from accounts where active={(bool_0 ? 1 : 0)};";
			result = Class60.EEBF5BBB(string_);
		}
		catch
		{
		}
		return result;
	}

	public static bool A2037203(string string_0)
	{
		bool result = true;
		try
		{
			if (Class60.E211632E("UPDATE accounts SET active=0, dateDelete='" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + "' where idfile=" + string_0) > 0)
			{
				result = true;
				return result;
			}
			result = false;
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static bool F18F7428(string string_0)
	{
		try
		{
			return Class60.E211632E("UPDATE accounts SET active=0, dateDelete='" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + "' where id=" + string_0) > 0;
		}
		catch
		{
		}
		return false;
	}

	public static DataTable smethod_13(List<string> D8A03530)
	{
		DataTable result = new DataTable();
		try
		{
			int num = 100;
			int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)D8A03530.Count * 1.0 / 100.0)));
			List<string> list = new List<string>();
			string text = "";
			for (int i = 0; i < num2; i++)
			{
				text = "SELECT uid, pass, token, cookie1,email, passmail, fa2 FROM accounts WHERE id IN ('" + string.Join("','", D8A03530.GetRange(num * i, (num * i + num <= D8A03530.Count) ? num : (D8A03530.Count % num))) + "')";
				list.Add(text);
			}
			result = Class60.A720858D(list);
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "GetAccFromFile");
		}
		return result;
	}

	public static bool smethod_14(List<string> list_0, bool bool_0 = false)
	{
		if (bool_0)
		{
			List<string> list = new List<string>();
			DataTable dataTable = smethod_13(list_0);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				string text = "";
				for (int j = 0; j < dataTable.Columns.Count; j++)
				{
					text = text + dataTable.Rows[i][j].ToString() + "|";
				}
				text = text.Substring(0, text.Length - 1);
				list.Add(text);
			}
			File.AppendAllText("bin.txt", "======" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + "======\r\n");
			File.AppendAllLines("bin.txt", list);
		}
		bool result = true;
		try
		{
			int num = 100;
			int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)list_0.Count * 1.0 / 100.0)));
			List<string> list2 = new List<string>();
			string text2 = "";
			for (int k = 0; k < num2; k++)
			{
				text2 = ((!bool_0) ? ("UPDATE accounts SET active=0, dateDelete='" + DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy") + "' where id IN (" + string.Join(",", list_0.GetRange(num * k, (num * k + num <= list_0.Count) ? num : (list_0.Count % num))) + ")") : ("delete from accounts where id IN (" + string.Join(",", list_0.GetRange(num * k, (num * k + num <= list_0.Count) ? num : (list_0.Count % num))) + ")"));
				list2.Add(text2);
			}
			for (int l = 0; l < list2.Count; l++)
			{
				result = Class60.E211632E(list2[l]) > 0;
			}
			return result;
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "DeleteAccountToDatabase");
			return result;
		}
	}

	public static JObject smethod_15(string D1224230)
	{
		string[] array = D1224230.Split('|');
		string text = array[0].Trim();
		string text2 = array[4].Trim();
		if (text == "" && text2 == "")
		{
			return null;
		}
		string text3 = array[1];
		string text4 = array[2];
		string text5 = array[3];
		string text6 = array[5];
		string text7 = array[6];
		string text8 = array[7];
		string text9 = array[8];
		string text10 = array[9];
		string text11 = array[10];
		string text12 = array[11];
		string text13 = array[12];
		string text14 = array[13];
		string text15 = array[14];
		string text16 = array[15];
		string text17 = array[16];
		string text18 = array[17];
		string text19 = array[18];
		JObject jObject = new JObject();
		if (text != "")
		{
			jObject["uid"] = (JToken)text;
		}
		if (text3 != "")
		{
			jObject["pass"] = (JToken)text3;
		}
		if (text4 != "")
		{
			jObject["token"] = (JToken)text4;
		}
		if (text5 != "")
		{
			jObject["cookie1"] = (JToken)text5;
		}
		if (text2 != "")
		{
			jObject["email"] = (JToken)text2;
		}
		if (text6 != "")
		{
			jObject["passmail"] = (JToken)text6;
		}
		if (text7 != "")
		{
			jObject["fa2"] = (JToken)text7;
		}
		if (text8 != "")
		{
			jObject["useragent"] = (JToken)text8;
		}
		if (text9 != "")
		{
			jObject["proxy"] = (JToken)text9;
		}
		if (text10 != "")
		{
			jObject["birthday"] = (JToken)text10;
		}
		if (text11 != "")
		{
			jObject["friends"] = (JToken)text11;
		}
		if (text12 != "")
		{
			jObject["gender"] = (JToken)text12;
		}
		if (text13 != "")
		{
			jObject["dateCreateAcc"] = (JToken)text13;
		}
		if (text14 != "")
		{
			jObject["mailrecovery"] = (JToken)text14;
		}
		if (text15 != "")
		{
			jObject["passmailrecovery"] = (JToken)text15;
		}
		if (text16 != "")
		{
			jObject["ghiChu"] = (JToken)text16;
		}
		if (text17 != "")
		{
			jObject["interactEnd"] = (JToken)text17;
		}
		if (text18 + "|" + text19 != "|")
		{
			jObject["backup"] = (JToken)(text18 + "|" + text19);
		}
		return jObject;
	}

	public static string smethod_16(string AEBA9BA0)
	{
		try
		{
			return Class60.smethod_0("SELECT idFile FROM accounts WHERE id='" + AEBA9BA0 + "'").ToString();
		}
		catch
		{
		}
		return "";
	}

	public static bool E106EC0B(string string_0, string C82B1A3D)
	{
		return Class60.smethod_0("SELECT COUNT(*) AS count FROM pragma_table_info('" + string_0 + "') WHERE name='" + C82B1A3D + "'") > 0;
	}

	public static bool EC9F109F(string string_0)
	{
		return Class60.smethod_0("SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='" + string_0 + "';") > 0;
	}

	public static bool smethod_17(string string_0, string string_1, int int_0 = 1)
	{
		bool result = false;
		try
		{
			if (E106EC0B(string_0, string_1))
			{
				return true;
			}
			if (Class60.E211632E("ALTER TABLE " + string_0 + " ADD COLUMN '" + string_1 + "' " + ((int_0 == 0) ? "INT" : "TEXT") + ";") > 0)
			{
				result = true;
			}
		}
		catch
		{
		}
		return result;
	}

	public static bool smethod_18(string AA1F4A00, string B11EC0BF, string A385BA89)
	{
		bool result = true;
		try
		{
			string string_ = "INSERT INTO interacts(uid, timeInteract,hanhDong,cauHinh) VALUES ('" + AA1F4A00 + "','" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "','" + B11EC0BF + "','" + A385BA89 + "')";
			Class60.EEBF5BBB(string_);
			return result;
		}
		catch
		{
			return false;
		}
	}

	public static List<Class65> FD9ECF83(string B62A0E19)
	{
		List<Class65> result = new List<Class65>();
		try
		{
			string string_ = "select id, tenChuDe,ngaytao,tieude,anh,video,noidung from BaiViet WHERE id = " + B62A0E19;
			DataTable source = GClass12.GClass12_0.method_0(string_);
			result = (from dataRow_0 in source.AsEnumerable()
				select new Class65
				{
					Int32_0 = Convert.ToInt32(dataRow_0["id"]),
					DDAA0B14 = Convert.ToString(dataRow_0["tenChuDe"]),
					String_4 = Convert.ToString(dataRow_0["ngaytao"]),
					String_1 = Convert.ToString(dataRow_0["anh"]),
					String_2 = Convert.ToString(dataRow_0["video"]),
					String_0 = Convert.ToString(dataRow_0["tieude"]),
					String_3 = Convert.ToString(dataRow_0["noidung"])
				}).ToList();
		}
		catch
		{
		}
		return result;
	}

	public static List<string> B5A9A490()
	{
		List<string> list = new List<string>();
		try
		{
			string string_ = "select ten from ChuDe;";
			DataTable dataTable = GClass12.GClass12_0.method_0(string_);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				list.Add(dataTable.Rows[i][0].ToString());
			}
		}
		catch
		{
		}
		return list;
	}

	public static List<Class65> A4ACAC39(string string_0 = "")
	{
		List<Class65> result = new List<Class65>();
		try
		{
			string text = "";
			text = ((!(string_0 != "")) ? "select id,tenchude,ngaytao,tieude,anh,video,noidung from BaiViet" : ("select id,tenchude,ngaytao,tieude,anh,video,noidung from BaiViet WHERE tenchude='" + string_0 + "'"));
			DataTable source = GClass12.GClass12_0.method_0(text);
			result = (from dataRow_0 in source.AsEnumerable()
				select new Class65
				{
					Int32_0 = Convert.ToInt32(dataRow_0["id"]),
					DDAA0B14 = Convert.ToString(dataRow_0["tenChuDe"]),
					String_4 = Convert.ToString(dataRow_0["ngaytao"]),
					String_1 = Convert.ToString(dataRow_0["anh"]),
					String_2 = Convert.ToString(dataRow_0["video"]),
					String_0 = Convert.ToString(dataRow_0["tieude"]),
					String_3 = Convert.ToString(dataRow_0["noidung"])
				}).ToList();
		}
		catch
		{
		}
		return result;
	}

	public static bool A1131E3C(int int_0)
	{
		bool result = false;
		if (GClass12.GClass12_0.method_1("delete from BaiViet where id=" + int_0) > 0)
		{
			result = true;
		}
		return result;
	}

	public static bool F91901A8(string string_0)
	{
		bool flag = false;
		try
		{
			string b61A = "delete from ChuDe where ten='" + string_0 + "'";
			if (GClass12.GClass12_0.method_1(b61A) > 0)
			{
				smethod_19(string_0);
				return true;
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	public static bool smethod_19(string D41B708F)
	{
		bool result = false;
		if (GClass12.GClass12_0.method_1("delete from BaiViet where tenchude='" + D41B708F + "'") > 0)
		{
			result = true;
		}
		return result;
	}

	public static bool E19E9C81(string string_0)
	{
		bool result = true;
		try
		{
			string b61A = "insert into ChuDe values('" + string_0 + "')";
			GClass12.GClass12_0.method_1(b61A);
			return result;
		}
		catch
		{
			return false;
		}
	}

	public static List<Class65> smethod_20()
	{
		List<Class65> result = new List<Class65>();
		try
		{
			string string_ = "select id, tenChuDe,ngaytao,tieude,anh,video,noidung from BaiViet ORDER BY id DESC LIMIT 1";
			DataTable source = GClass12.GClass12_0.method_0(string_);
			result = (from FD088EA5 in source.AsEnumerable()
				select new Class65
				{
					Int32_0 = Convert.ToInt32(FD088EA5["id"]),
					DDAA0B14 = Convert.ToString(FD088EA5["tenChuDe"]),
					String_4 = Convert.ToString(FD088EA5["ngaytao"]),
					String_1 = Convert.ToString(FD088EA5["anh"]),
					String_2 = Convert.ToString(FD088EA5["video"]),
					String_0 = Convert.ToString(FD088EA5["tieude"]),
					String_3 = Convert.ToString(FD088EA5["noidung"])
				}).ToList();
		}
		catch
		{
		}
		return result;
	}

	public static bool smethod_21(int int_0, Class65 B127D736)
	{
		bool result = true;
		try
		{
			string text = "";
			if (B127D736.String_0 != null)
			{
				text = text + "tieude = '" + B127D736.String_0.Replace("'", "''") + "',";
			}
			if (B127D736.String_1 != null)
			{
				text = text + "anh = '" + B127D736.String_1 + "',";
			}
			if (B127D736.String_3 != null)
			{
				text = text + "noidung = '" + B127D736.String_3.Replace("'", "''") + "',";
			}
			if (B127D736.String_4 != null)
			{
				text = text + "ngaytao = '" + B127D736.String_4 + "',";
			}
			if (B127D736.DDAA0B14 != null)
			{
				text = text + "tenchude = '" + B127D736.DDAA0B14 + "',";
			}
			if (B127D736.String_2 != null)
			{
				text = text + "video = '" + B127D736.String_2 + "',";
			}
			text = text.TrimEnd(',');
			if (text != "")
			{
				string b61A = "UPDATE BaiViet SET " + text + " WHERE id=" + int_0;
				GClass12.GClass12_0.method_1(b61A);
				return true;
			}
			return result;
		}
		catch
		{
			return false;
		}
	}

	public static bool DD031E85(string string_0, string EF1086B7)
	{
		bool result = true;
		try
		{
			string b61A = "UPDATE ChuDe SET ten = '" + EF1086B7 + "' WHERE ten='" + string_0 + "'";
			if (GClass12.GClass12_0.method_1(b61A) > 0)
			{
				List<Class65> list = A4ACAC39(string_0);
				for (int i = 0; i < list.Count; i++)
				{
					smethod_21(list[i].Int32_0, new Class65
					{
						DDAA0B14 = EF1086B7
					});
				}
				return result;
			}
			return result;
		}
		catch
		{
			return false;
		}
	}

	public static bool smethod_22(string string_0, Class65 F61072B1)
	{
		bool result = true;
		try
		{
			string b61A = "insert into BaiViet(tenChuDe, tieude, noidung, ngaytao, anh,video) values('" + string_0 + "','" + F61072B1.String_0.Replace("'", "''") + "','" + F61072B1.String_3.Replace("'", "''") + "','" + F61072B1.String_4 + "','" + F61072B1.String_1 + "','" + F61072B1.String_2 + "')";
			GClass12.GClass12_0.method_1(b61A);
			return result;
		}
		catch
		{
			return false;
		}
	}

	internal static DataTable smethod_23(string string_0)
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = "SELECT pass, cookie1, email, fa2, proxy FROM accounts WHERE uid='" + string_0 + "'AND active=1";
			result = Class60.EEBF5BBB(string_);
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "GetPassByUid");
		}
		return result;
	}

	public static DataTable smethod_24(List<string> A289298F, bool bool_0 = true)
	{
		DataTable result = new DataTable();
		try
		{
			if (A289298F[0].StartsWith("@"))
			{
				List<string> list = new List<string>();
				string text = "";
				for (int i = 0; i < A289298F.Count; i++)
				{
					text = "SELECT t1.*, t2.name AS nameFile FROM accounts t1 JOIN files t2 ON t1.idfile=t2.id WHERE t1.email Like ('%" + A289298F[i] + "%') and t1.active=" + (bool_0 ? 1 : 0);
					list.Add(text);
				}
				result = Class60.A720858D(list);
			}
			else if (A289298F[0].Contains("@"))
			{
				int num = 100;
				int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)A289298F.Count * 1.0 / 100.0)));
				List<string> list2 = new List<string>();
				string text2 = "";
				for (int j = 0; j < num2; j++)
				{
					text2 = "SELECT t1.*, t2.name AS nameFile FROM accounts t1 JOIN files t2 ON t1.idfile=t2.id WHERE t1.email IN ('" + string.Join("','", A289298F.GetRange(num * j, (num * j + num <= A289298F.Count) ? num : (A289298F.Count % num))) + "') and t1.active=" + (bool_0 ? 1 : 0) + " ORDER BY t1.email";
					list2.Add(text2);
				}
				result = Class60.A720858D(list2);
			}
			else
			{
				int num3 = 100;
				int num4 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)A289298F.Count * 1.0 / 100.0)));
				List<string> list3 = new List<string>();
				string text3 = "";
				for (int k = 0; k < num4; k++)
				{
					text3 = "SELECT t1.*, t2.name AS nameFile FROM accounts t1 JOIN files t2 ON t1.idfile=t2.id WHERE t1.uid IN ('" + string.Join("','", A289298F.GetRange(num3 * k, (num3 * k + num3 <= A289298F.Count) ? num3 : (A289298F.Count % num3))) + "') and t1.active=" + (bool_0 ? 1 : 0) + " ORDER BY t1.uid";
					list3.Add(text3);
				}
				result = Class60.A720858D(list3);
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_57(null, exception_, "GetAccFromFile");
		}
		return result;
	}

	public static string smethod_25(string string_0)
	{
		try
		{
			DataTable dataTable = Class60.EEBF5BBB("SELECT email, passmail FROM accounts WHERE id = " + string_0);
			return dataTable.Rows[0]["email"]?.ToString() + "|" + dataTable.Rows[0]["passmail"];
		}
		catch (Exception)
		{
		}
		return "|";
	}

	public static bool smethod_26(List<string> CF3C35AE)
	{
		bool result = false;
		try
		{
			int num = 100;
			int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)CF3C35AE.Count * 1.0 / 100.0)));
			List<string> list = new List<string>();
			string text = "";
			for (int i = 0; i < num2; i++)
			{
				text = "update accounts set pass=pass_old, pass_old=pass where id IN (" + string.Join(",", CF3C35AE.GetRange(num * i, (num * i + num <= CF3C35AE.Count) ? num : (CF3C35AE.Count % num))) + ")";
				list.Add(text);
			}
			result = Class60.C138B888(list) > 0;
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static bool FC3FE720(List<string> list_0)
	{
		bool result = false;
		try
		{
			int num = 100;
			int num2 = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal((double)list_0.Count * 1.0 / 100.0)));
			List<string> list = new List<string>();
			string text = "";
			for (int i = 0; i < num2; i++)
			{
				text = "update accounts set email=email_old, email_old=email, passmail=passmail_old, passmail_old=passmail where id IN (" + string.Join(",", list_0.GetRange(num * i, (num * i + num <= list_0.Count) ? num : (list_0.Count % num))) + ")";
				list.Add(text);
			}
			result = Class60.C138B888(list) > 0;
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static bool smethod_27(string string_0, string string_1)
	{
		bool result = false;
		try
		{
			string text = Class60.EEBF5BBB("SELECT STT FROM files WHERE id = " + string_0).Rows[0]["STT"].ToString();
			string text2 = Class60.EEBF5BBB("SELECT STT FROM files WHERE id = " + string_1).Rows[0]["STT"].ToString();
			string f23A8E = "UPDATE files SET STT = " + text2 + " WHERE id = " + string_0;
			string f23A8E2 = "UPDATE files SET STT = " + text + " WHERE id = " + string_1;
			if (Class60.E211632E(f23A8E) > 0 && Class60.E211632E(f23A8E2) > 0)
			{
				result = true;
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}
}
