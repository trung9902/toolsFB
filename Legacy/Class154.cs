using System;
using System.Collections.Generic;
using System.Data;

internal class Class154
{
	public static bool smethod_0(string FD25ACA6, string string_0)
	{
		bool result = false;
		try
		{
			int num = ConnectorKichBan.ConnectorKichBan_0.method_3("SELECT COUNT(*) AS count FROM pragma_table_info('" + FD25ACA6 + "') WHERE name='" + string_0 + "'");
			if (num > 0)
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

	public static bool D6132534(string string_0, string string_1, int int_0)
	{
		bool result = false;
		try
		{
			if (smethod_0(string_0, string_1))
			{
				return true;
			}
			if (ConnectorKichBan.ConnectorKichBan_0.method_2("ALTER TABLE " + string_0 + " ADD COLUMN '" + string_1 + "' " + ((int_0 == 0) ? "INT" : "TEXT") + ";") > 0)
			{
				result = true;
			}
		}
		catch
		{
		}
		return result;
	}

	public static DataTable smethod_1(string string_0)
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = "SELECT * FROM Kich_Ban WHERE Id_KichBan = " + string_0;
			result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_);
		}
		catch
		{
		}
		return result;
	}

	public static string F8339D27(string string_0)
	{
		string result = "";
		try
		{
			string string_ = "SELECT TenKichBan FROM Kich_Ban WHERE Id_KichBan = " + string_0;
			result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_).Rows[0][0].ToString();
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static DataTable smethod_2()
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = "DROP TABLE IF EXISTS tmp;CREATE TEMPORARY TABLE tmp(Stt INTEGER PRIMARY KEY AUTOINCREMENT, Id_KichBan INTEGER, TenKichBan TEXT);INSERT INTO tmp (Id_KichBan, TenKichBan) SELECT Id_KichBan, TenKichBan FROM Kich_Ban ORDER BY STT;SELECT Id_KichBan, TenKichBan, (Stt||'. '||TenKichBan) AS Ten FROM tmp;";
			result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_);
		}
		catch
		{
		}
		return result;
	}

	public static DataTable BA00569F()
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = "SELECT * FROM Kich_Ban ORDER BY Id_KichBan DESC LIMIT 1";
			result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_);
		}
		catch
		{
		}
		return result;
	}

	public static string smethod_3(string string_0)
	{
		string result = "";
		try
		{
			string string_ = "SELECT CauHinh FROM Kich_Ban WHERE Id_KichBan = " + string_0;
			result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_).Rows[0]["CauHinh"].ToString();
		}
		catch
		{
		}
		return result;
	}

	public static bool D912C107(string F19FEA2A, string string_0)
	{
		try
		{
			string string_ = "UPDATE Kich_Ban SET CauHinh = '" + string_0.Replace("'", "''") + "' WHERE Id_KichBan = " + F19FEA2A;
			return ConnectorKichBan.ConnectorKichBan_0.method_2(string_) > 0;
		}
		catch
		{
		}
		return false;
	}

	public static bool smethod_4(string B804BA2A)
	{
		try
		{
			string string_ = "SELECT Id_KichBan FROM Kich_Ban WHERE TenKichBan = '" + B804BA2A.Replace("'", "''") + "'";
			if (ConnectorKichBan.ConnectorKichBan_0.method_1(string_).Rows.Count > 0)
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	public static bool smethod_5(string string_0, string string_1)
	{
		bool result = false;
		try
		{
			string string_2 = "INSERT INTO Kich_Ban (TenKichBan, STT) VALUES ('" + string_0 + "', " + string_1 + ")";
			if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_2) > 0)
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

	public static bool smethod_6(string string_0, string string_1)
	{
		bool result = false;
		try
		{
			string string_2 = "UPDATE Kich_Ban SET TenKichBan = '" + string_1.Replace("'", "''") + "' WHERE Id_KichBan = " + string_0;
			if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_2) > 0)
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

	public static bool smethod_7(string string_0)
	{
		bool result = false;
		try
		{
			string string_ = "DELETE FROM Kich_Ban WHERE Id_KichBan = " + string_0;
			if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_) > 0)
			{
				smethod_16(string_0);
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

	public static bool smethod_8(string string_0, string string_1)
	{
		bool result = false;
		try
		{
			string text = "";
			try
			{
				text = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT STT FROM Kich_Ban ORDER BY STT DESC LIMIT 1").Rows[0]["STT"].ToString();
			}
			catch
			{
			}
			text = ((text == "") ? "1" : (Convert.ToInt32(text) + 1).ToString());
			if (smethod_5(string_1, text))
			{
				string text2 = BA00569F().Rows[0]["Id_KichBan"].ToString();
				DataTable dataTable = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT * FROM Hanh_Dong WHERE Id_KichBan = " + string_0);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string string_2 = "INSERT INTO Hanh_Dong (STT,Id_KichBan, TenHanhDong, Id_TuongTac, CauHinh) VALUES (" + dataTable.Rows[i]["STT"].ToString() + "," + text2 + ", '" + dataTable.Rows[i]["TenHanhDong"].ToString() + "', " + dataTable.Rows[i]["Id_TuongTac"].ToString() + ", '" + dataTable.Rows[i]["CauHinh"].ToString().Replace("'", "''") + "')";
					ConnectorKichBan.ConnectorKichBan_0.method_2(string_2);
				}
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

	public static DataTable BD904B3B(string string_0)
	{
		DataTable result = new DataTable();
		if (string_0 == "")
		{
			return result;
		}
		try
		{
			string text = "";
			if (string_0 != "")
			{
				text = text + "TenTuongTac = '" + string_0.Replace("'", "''") + "'";
			}
			if (text != "")
			{
				if (text.EndsWith(" AND "))
				{
					text = text.Replace(" AND ", "");
				}
				string string_ = "SELECT * FROM Tuong_Tac WHERE " + text;
				result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_);
			}
		}
		catch
		{
		}
		return result;
	}

	internal static void FA0E41AD(string string_0, string AA239C34)
	{
		DataTable dataTable = BD904B3B(string_0);
		if (dataTable.Rows.Count == 0)
		{
			ConnectorKichBan.ConnectorKichBan_0.method_2("INSERT INTO main.Tuong_Tac (TenTuongTac, MoTa) VALUES ('" + string_0.Replace("'", "''") + "', '" + AA239C34.Replace("'", "''") + "');");
		}
		else
		{
			string text = dataTable.Rows[0]["MoTa"].ToString();
			if (text != AA239C34)
			{
				ConnectorKichBan.ConnectorKichBan_0.method_2(string.Format("UPDATE main.Tuong_Tac SET MoTa='{0}' WHERE Id_TuongTac={1};", AA239C34.Replace("'", "''"), dataTable.Rows[0]["Id_TuongTac"]));
			}
		}
	}

	public static DataTable smethod_9(string C585AA30)
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = "SELECT t1.Id_HanhDong, t1.TenHanhDong,t2.Id_TuongTac,t2.TenTuongTac, t2.MoTa FROM Hanh_Dong t1 JOIN Tuong_Tac t2 ON t1.Id_TuongTac = t2.Id_TuongTac WHERE t1.Id_KichBan = " + C585AA30 + " ORDER BY t1.STT";
			result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_);
		}
		catch
		{
		}
		return result;
	}

	public static DataTable E6AD9687(string string_0)
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = "SELECT t1.TenHanhDong,t1.CauHinh,t2.Id_TuongTac,t2.TenTuongTac, t2.MoTa FROM Hanh_Dong t1 JOIN Tuong_Tac t2 ON t1.Id_TuongTac = t2.Id_TuongTac WHERE t1.Id_HanhDong = " + string_0;
			result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_);
		}
		catch
		{
		}
		return result;
	}

	public static DataTable smethod_10()
	{
		DataTable result = new DataTable();
		try
		{
			string string_ = "SELECT t1.Id_HanhDong,t1.TenHanhDong,t1.CauHinh,t2.Id_TuongTac,t2.TenTuongTac, t2.MoTa FROM Hanh_Dong t1 JOIN Tuong_Tac t2 ON t1.Id_TuongTac = t2.Id_TuongTac ORDER BY Id_HanhDong DESC LIMIT 1";
			result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_);
		}
		catch
		{
		}
		return result;
	}

	public static bool D31F2EA6(string string_0)
	{
		try
		{
			string string_ = "SELECT Id_HanhDong FROM Hanh_Dong WHERE TenHanhDong = '" + string_0.Replace("'", "''") + "'";
			if (ConnectorKichBan.ConnectorKichBan_0.method_1(string_).Rows.Count > 0)
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	public static bool smethod_11(string string_0, string EA9BD32E, string string_1, string E013A829)
	{
		bool result = false;
		try
		{
			string text = "";
			try
			{
				text = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT STT FROM Hanh_Dong WHERE Id_KichBan = " + string_0 + " ORDER BY STT DESC LIMIT 1").Rows[0]["STT"].ToString();
			}
			catch
			{
			}
			text = ((text == "") ? "1" : (Convert.ToInt32(text) + 1).ToString());
			E013A829 = E013A829.Replace("'", "''");
			string string_2 = "INSERT INTO Hanh_Dong (STT,Id_KichBan, TenHanhDong, Id_TuongTac, CauHinh) VALUES (" + text + "," + string_0 + ", '" + EA9BD32E.Replace("'", "''") + "', " + string_1 + ", '" + E013A829.Replace("'", "''") + "')";
			if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_2) > 0)
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

	public static bool smethod_12(string string_0, string F831373E)
	{
		bool result = false;
		try
		{
			DataTable dataTable = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT * FROM Hanh_Dong WHERE Id_HanhDong = " + string_0);
			string text = "";
			try
			{
				text = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT STT FROM Hanh_Dong WHERE Id_KichBan = " + dataTable.Rows[0]["Id_KichBan"].ToString() + " ORDER BY STT DESC LIMIT 1").Rows[0]["STT"].ToString();
			}
			catch
			{
			}
			text = ((text == "") ? "1" : (Convert.ToInt32(text) + 1).ToString());
			string string_ = "INSERT INTO Hanh_Dong (STT,Id_KichBan, TenHanhDong, Id_TuongTac, CauHinh) VALUES (" + text + "," + dataTable.Rows[0]["Id_KichBan"].ToString() + ", '" + F831373E.Replace("'", "''") + "', " + dataTable.Rows[0]["Id_TuongTac"].ToString() + ", '" + dataTable.Rows[0]["CauHinh"].ToString() + "')";
			if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_) > 0)
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

	public static bool smethod_13(string D828B52F, string string_0 = "", string string_1 = "")
	{
		bool result = false;
		try
		{
			string text = "";
			if (string_0 != "")
			{
				text = text + "TenHanhDong = '" + string_0.Replace("'", "''") + "',";
			}
			if (string_1 != "")
			{
				text = text + "CauHinh = '" + string_1.Replace("'", "''") + "'";
			}
			if (text != "")
			{
				text = text.TrimEnd(',');
				string string_2 = "UPDATE Hanh_Dong SET " + text + " WHERE Id_HanhDong = " + D828B52F;
				if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_2) > 0)
				{
					result = true;
					return result;
				}
				return result;
			}
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static bool D028FD87(string string_0, string string_1)
	{
		bool result = false;
		try
		{
			string text = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT STT FROM Kich_Ban WHERE Id_KichBan = " + string_0).Rows[0]["STT"].ToString();
			string text2 = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT STT FROM Kich_Ban WHERE Id_KichBan = " + string_1).Rows[0]["STT"].ToString();
			string string_2 = "UPDATE Kich_Ban SET STT = " + text2 + " WHERE Id_KichBan = " + string_0;
			string string_3 = "UPDATE Kich_Ban SET STT = " + text + " WHERE Id_KichBan = " + string_1;
			if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_2) > 0 && ConnectorKichBan.ConnectorKichBan_0.method_2(string_3) > 0)
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

	public static bool smethod_14(string string_0, string B33787B9)
	{
		bool result = false;
		try
		{
			string text = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT STT FROM Hanh_Dong WHERE Id_HanhDong = " + string_0).Rows[0]["STT"].ToString();
			string text2 = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT STT FROM Hanh_Dong WHERE Id_HanhDong = " + B33787B9).Rows[0]["STT"].ToString();
			string string_ = "UPDATE Hanh_Dong SET STT = " + text2 + " WHERE Id_HanhDong = " + string_0;
			string string_2 = "UPDATE Hanh_Dong SET STT = " + text + " WHERE Id_HanhDong = " + B33787B9;
			if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_) > 0 && ConnectorKichBan.ConnectorKichBan_0.method_2(string_2) > 0)
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

	public static bool smethod_15(string string_0)
	{
		bool result = false;
		try
		{
			string string_ = "DELETE FROM Hanh_Dong WHERE Id_HanhDong = " + string_0;
			if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_) > 0)
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

	public static bool smethod_16(string F5B3718E)
	{
		bool result = false;
		try
		{
			string string_ = "DELETE FROM Hanh_Dong WHERE Id_KichBan = " + F5B3718E;
			if (ConnectorKichBan.ConnectorKichBan_0.method_2(string_) > 0)
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

	public static List<string> FD11BF96(string string_0, string F78AFF03)
	{
		List<string> list = new List<string>();
		try
		{
			string string_ = "SELECT t1.Id_HanhDong FROM Hanh_Dong t1 JOIN Tuong_Tac t2 ON t1.Id_TuongTac = t2.Id_TuongTac WHERE t1.Id_KichBan = " + string_0 + " AND t2.TenTuongTac = '" + F78AFF03.Replace("'", "''") + "'";
			DataTable dataTable = ConnectorKichBan.ConnectorKichBan_0.method_1(string_);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				list.Add(dataTable.Rows[i]["Id_HanhDong"].ToString());
			}
		}
		catch
		{
		}
		return list;
	}

	public static List<string> B980BAA0(string string_0, string string_1)
	{
		List<string> list = new List<string>();
		try
		{
			string string_2 = "SELECT t1.Id_HanhDong FROM Hanh_Dong t1 JOIN Tuong_Tac t2 ON t1.Id_TuongTac = t2.Id_TuongTac WHERE t1.Id_KichBan = " + string_0;
			DataTable dataTable = ConnectorKichBan.ConnectorKichBan_0.method_1(string_2);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				list.Add(dataTable.Rows[i]["Id_HanhDong"].ToString());
			}
		}
		catch
		{
		}
		return list;
	}

	public static string smethod_17(string string_0)
	{
		string result = "";
		try
		{
			string string_ = "SELECT CauHinh FROM Hanh_Dong WHERE Id_HanhDong = " + string_0;
			result = ConnectorKichBan.ConnectorKichBan_0.method_1(string_).Rows[0]["CauHinh"].ToString();
		}
		catch
		{
		}
		return result;
	}
}
