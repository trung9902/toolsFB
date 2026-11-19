using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

public class EAB09F19
{
	internal static Dictionary<DataGridView, bool> dictionary_0 = new Dictionary<DataGridView, bool>();

	public static void smethod_0(DataGridView C6B2BF82, bool bool_0)
	{
		try
		{
			if (!dictionary_0.ContainsKey(C6B2BF82))
			{
				dictionary_0.Add(C6B2BF82, value: true);
			}
			if (dictionary_0[C6B2BF82] == bool_0)
			{
				return;
			}
			C6B2BF82.Invoke((MethodInvoker)delegate
			{
				foreach (DataGridViewColumn column in C6B2BF82.Columns)
				{
					column.SortMode = (bool_0 ? DataGridViewColumnSortMode.Automatic : DataGridViewColumnSortMode.NotSortable);
				}
			});
			dictionary_0[C6B2BF82] = bool_0;
		}
		catch (Exception)
		{
		}
	}

	public static void EBB59018(DataGridView dataGridView_0, int D4BC813C)
	{
		if (D4BC813C == -1)
		{
			for (int i = 0; i < dataGridView_0.RowCount; i++)
			{
				smethod_1(dataGridView_0, i, -1);
			}
		}
		else
		{
			smethod_1(dataGridView_0, D4BC813C, -1);
		}
	}

	public static void smethod_1(DataGridView E632B29E, int int_0, int int_1)
	{
		if (int_1 == -1)
		{
			string text = E2A1ED2F(E632B29E, int_0, "cInfo");
			if (text == "Live")
			{
				int_1 = 2;
			}
			else if (text.Contains("Die") || text.Contains("Checkpoint") || text.Contains("Changed pass"))
			{
				int_1 = 1;
			}
		}
		switch (C5034B95.smethod_0("configGeneral").method_2("typePhanBietMau"))
		{
		case 0:
			switch (int_1)
			{
			case 0:
				E632B29E.Rows[int_0].DefaultCellStyle.BackColor = Color.White;
				break;
			case 1:
				E632B29E.Rows[int_0].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
				break;
			case 2:
				E632B29E.Rows[int_0].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
				break;
			}
			break;
		case 1:
			switch (int_1)
			{
			case 0:
				E632B29E.Rows[int_0].DefaultCellStyle.ForeColor = Color.Black;
				break;
			case 1:
				E632B29E.Rows[int_0].DefaultCellStyle.ForeColor = Color.Red;
				break;
			case 2:
				E632B29E.Rows[int_0].DefaultCellStyle.ForeColor = Color.Green;
				break;
			}
			break;
		}
	}

	public static void A00F6EA9(DataGridView B803A595, int int_0, string CEA76083, int int_1 = 0, string B2A0612E = "Đơ\u0323i {time} giây...")
	{
		try
		{
			int tickCount = Environment.TickCount;
			while (true)
			{
				int num = int_1 - (Environment.TickCount - tickCount) / 1000;
				if (num > 0)
				{
					smethod_3(B803A595, int_0, CEA76083, B2A0612E.Replace("{time}", num.ToString()));
					Commom.smethod_52(0.5);
					continue;
				}
				break;
			}
		}
		catch
		{
		}
	}

	public static string EC12300A(DataGridView dataGridView_0, int int_0, int int_1)
	{
		string E92A8E92 = "";
		try
		{
			if (dataGridView_0.Rows[int_0].Cells[int_1].Value == null)
			{
				return "";
			}
			try
			{
				E92A8E92 = dataGridView_0.Rows[int_0].Cells[int_1].Value.ToString();
			}
			catch
			{
				dataGridView_0.Invoke((MethodInvoker)delegate
				{
					E92A8E92 = dataGridView_0.Rows[int_0].Cells[int_1].Value.ToString();
				});
			}
		}
		catch
		{
		}
		return E92A8E92;
	}

	public static string E2A1ED2F(DataGridView dataGridView_0, int int_0, string E71B0C97)
	{
		string E7AE251C = "";
		try
		{
			if (dataGridView_0.Rows[int_0].Cells[E71B0C97].Value == null)
			{
				return "";
			}
			try
			{
				E7AE251C = dataGridView_0.Rows[int_0].Cells[E71B0C97].Value.ToString();
			}
			catch
			{
				dataGridView_0.Invoke((MethodInvoker)delegate
				{
					E7AE251C = dataGridView_0.Rows[int_0].Cells[E71B0C97].Value.ToString();
				});
			}
		}
		catch
		{
		}
		return E7AE251C;
	}

	public static void smethod_2(DataGridView dataGridView_0, int int_0, int int_1, object F1989505)
	{
		try
		{
			try
			{
				dataGridView_0.Invoke((MethodInvoker)delegate
				{
					dataGridView_0.Rows[int_0].Cells[int_1].Value = F1989505;
				});
			}
			catch
			{
				dataGridView_0.Rows[int_0].Cells[int_1].Value = F1989505;
			}
		}
		catch
		{
		}
	}

	public static void smethod_3(DataGridView dataGridView_0, int E12D0719, string string_0, object object_0)
	{
		try
		{
			if (Class87.bool_0 && string_0 == "cStatus")
			{
				string string_ = E2A1ED2F(dataGridView_0, E12D0719, "cId");
				Class87.smethod_1(string_, object_0.ToString());
			}
			if (dataGridView_0.IsHandleCreated)
			{
				dataGridView_0.BeginInvoke((MethodInvoker)delegate
				{
					try
					{
						if (E12D0719 >= 0 && E12D0719 < dataGridView_0.Rows.Count)
						{
							dataGridView_0.Rows[E12D0719].Cells[string_0].Value = object_0;
						}
					}
					catch {}
				});
			}
			else
			{
				try
				{
					if (E12D0719 >= 0 && E12D0719 < dataGridView_0.Rows.Count)
					{
						dataGridView_0.Rows[E12D0719].Cells[string_0].Value = object_0;
					}
				}
				catch {}
			}
		}
		catch
		{
		}
	}

	public static void smethod_4(DataGridView dataGridView_0, DataTable dataTable_0, bool bool_0 = false)
	{
		string[] requiredCols = new string[]
		{
			"id", "uid", "token", "cookie1", "email", "phone", "name", "follow", "friends", "groups",
			"pages", "pagePro5", "birthday", "gender", "pass", "mailrecovery", "passmail", "backup",
			"fa2", "useragent", "proxy", "dateCreateAcc", "avatar", "profile", "nameFile", "interactEnd",
			"info", "ghiChu", "location", "hometown", "currentCity", "dating", "ads", "bm", "wallPosts",
			"fbBlock", "job", "dateDelete", "email2", "passmailrecovery", "status282", "kichban", "cookieHotmail"
		};
		foreach (string col in requiredCols)
		{
			if (!dataTable_0.Columns.Contains(col))
			{
				dataTable_0.Columns.Add(col, typeof(string));
			}
		}
		if (bool_0)
		{
			for (int i = 0; i < dataTable_0.Rows.Count; i++)
			{
				DataRow dataRow = dataTable_0.Rows[i];
				dataGridView_0.Rows.Add(false, dataGridView_0.RowCount + 1, dataRow["id"], dataRow["uid"], dataRow["token"], dataRow["cookie1"], dataRow["email"], dataRow["phone"], dataRow["name"], dataRow["follow"], dataRow["friends"], dataRow["groups"], dataRow["pages"], dataRow["pagePro5"], dataRow["birthday"], dataRow["gender"], dataRow["pass"], dataRow["mailrecovery"], dataRow["passmail"], dataRow["backup"], dataRow["fa2"], dataRow["useragent"], dataRow["proxy"], dataRow["dateCreateAcc"], dataRow["avatar"], dataRow["profile"], dataRow["nameFile"], dataRow["interactEnd"], dataRow["info"], dataRow["ghiChu"], dataRow["location"], dataRow["hometown"], dataRow["currentCity"], dataRow["dating"], dataRow["ads"], dataRow["bm"], dataRow["wallPosts"], dataRow["fbBlock"], dataRow["job"], dataRow["dateDelete"], Class87.smethod_0(dataRow["id"].ToString()));
			}
			return;
		}
		for (int j = 0; j < dataTable_0.Rows.Count; j++)
		{
			DataRow dataRow2 = dataTable_0.Rows[j];
			dataGridView_0.Rows.Add(false, dataGridView_0.RowCount + 1, dataRow2["id"], dataRow2["uid"], dataRow2["pass"], dataRow2["fa2"], dataRow2["token"], dataRow2["cookie1"], dataRow2["email"], dataRow2["email2"], dataRow2["passmail"], dataRow2["mailrecovery"], dataRow2["passmailrecovery"], dataRow2["phone"], dataRow2["name"], dataRow2["follow"], dataRow2["friends"], dataRow2["groups"], dataRow2["pages"], dataRow2["pagePro5"], dataRow2["birthday"], dataRow2["gender"], dataRow2["backup"], dataRow2["useragent"], dataRow2["proxy"], dataRow2["dateCreateAcc"], dataRow2["avatar"], dataRow2["profile"], dataRow2["nameFile"], dataRow2["interactEnd"], dataRow2["info"], dataRow2["ghiChu"], dataRow2["status282"], dataRow2["location"], dataRow2["hometown"], dataRow2["currentCity"], dataRow2["dating"], dataRow2["ads"], dataRow2["bm"], dataRow2["wallPosts"], dataRow2["fbBlock"], dataRow2["job"], dataRow2["kichban"], dataRow2["cookieHotmail"], Class87.smethod_0(dataRow2["id"].ToString()));
		}
	}

	internal static void smethod_5(DataGridViewSortCompareEventArgs dataGridViewSortCompareEventArgs_0)
	{
		try
		{
			List<string> list = new List<string> { "cStt", "cFriend", "cGroup", "cFollow", "cPage", "cPagePro5", "cBM" };
			string text = dataGridViewSortCompareEventArgs_0.CellValue1.ToString().Trim();
			string text2 = dataGridViewSortCompareEventArgs_0.CellValue2.ToString().Trim();
			if (text == "" || text2 == "")
			{
				dataGridViewSortCompareEventArgs_0.SortResult = text.CompareTo(text2);
				dataGridViewSortCompareEventArgs_0.Handled = true;
				return;
			}
			if (list.Contains(dataGridViewSortCompareEventArgs_0.Column.Name))
			{
				if (!Commom.smethod_45(text))
				{
					text = ((text != "") ? "-1" : "-2");
				}
				if (!Commom.smethod_45(text2))
				{
					text2 = ((text2 != "") ? "-1" : "-2");
				}
				dataGridViewSortCompareEventArgs_0.SortResult = int.Parse(text).CompareTo(int.Parse(text2));
			}
			else if (dataGridViewSortCompareEventArgs_0.Column.Name == "cWallPosts")
			{
				dataGridViewSortCompareEventArgs_0.SortResult = int.Parse(text.Replace("+", "")).CompareTo(int.Parse(text2.Replace("+", "")));
			}
			else if (dataGridViewSortCompareEventArgs_0.Column.Name == "cInteractEnd")
			{
				dataGridViewSortCompareEventArgs_0.SortResult = Commom.smethod_61(text).CompareTo(Commom.smethod_61(text2));
			}
			else if (dataGridViewSortCompareEventArgs_0.Column.Name == "cDateDelete")
			{
				dataGridViewSortCompareEventArgs_0.SortResult = Commom.smethod_61(text, "HH:mm:ss dd/MM/yyyy").CompareTo(Commom.smethod_61(text2, "HH:mm:ss dd/MM/yyyy"));
			}
			else if (dataGridViewSortCompareEventArgs_0.Column.Name == "cJob")
			{
				string[] array = dataGridViewSortCompareEventArgs_0.CellValue1.ToString().Split(' ');
				string[] array2 = dataGridViewSortCompareEventArgs_0.CellValue2.ToString().Split(' ');
				string text3 = array[0].Trim().Substring(1, 10);
				string text4 = array2[0].Trim().Substring(1, 10);
				int num = int.Parse(array[1].Trim());
				int value = int.Parse(array2[1].Trim());
				if (text3 == text4)
				{
					dataGridViewSortCompareEventArgs_0.SortResult = num.CompareTo(value);
				}
				else
				{
					DateTime dateTime = DateTime.ParseExact(text3, "dd/MM/yyyy", CultureInfo.InvariantCulture);
					DateTime value2 = DateTime.ParseExact(text4, "dd/MM/yyyy", CultureInfo.InvariantCulture);
					dataGridViewSortCompareEventArgs_0.SortResult = dateTime.CompareTo(value2);
				}
			}
			else if (dataGridViewSortCompareEventArgs_0.Column.Name == "cStatus282")
			{
				string[] array3 = dataGridViewSortCompareEventArgs_0.CellValue1.ToString().Split('-');
				string[] array4 = dataGridViewSortCompareEventArgs_0.CellValue2.ToString().Split('-');
				string text5 = array3[0].Trim();
				string text6 = array4[0].Trim();
				if (text5 == text6)
				{
					int num2 = 0;
					int num3 = 0;
					if (array3.Count() > 2)
					{
						num2 = int.Parse(array3[2].Trim().Split(' ')[0]);
					}
					if (array4.Count() > 2)
					{
						num3 = int.Parse(array4[2].Trim().Split(' ')[0]);
					}
					if (num2 != num3)
					{
						dataGridViewSortCompareEventArgs_0.SortResult = num2.CompareTo(num3);
					}
					else
					{
						string s = array3[1].Trim();
						string s2 = array4[1].Trim();
						DateTime dateTime2 = DateTime.ParseExact(s, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
						DateTime value3 = DateTime.ParseExact(s2, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
						dataGridViewSortCompareEventArgs_0.SortResult = dateTime2.CompareTo(value3);
					}
				}
				else
				{
					dataGridViewSortCompareEventArgs_0.SortResult = text5.CompareTo(text6);
				}
			}
			else if (dataGridViewSortCompareEventArgs_0.Column.Name == "cStatus")
			{
				string text7 = text;
				string strB = text2;
				if (text.StartsWith("("))
				{
					text7 = text.Substring(text.IndexOf(")") + 1).Trim();
				}
				if (text2.StartsWith("("))
				{
					strB = text2.Substring(text2.IndexOf(")") + 1).Trim();
				}
				dataGridViewSortCompareEventArgs_0.SortResult = text7.CompareTo(strB);
			}
			else if (dataGridViewSortCompareEventArgs_0.Column.Name == "cBirthday")
			{
				dataGridViewSortCompareEventArgs_0.SortResult = Commom.smethod_61(text, "M/d/yyyy").CompareTo(Commom.smethod_61(text2, "M/d/yyyy"));
			}
			else if (dataGridViewSortCompareEventArgs_0.Column.Name == "cDateCreateAcc")
			{
				text = Regex.Match(text, "2\\d{3}").Value;
				text2 = Regex.Match(text2, "2\\d{3}").Value;
				if (!Commom.smethod_45(text))
				{
					text = ((text != "") ? "-1" : "-2");
				}
				if (!Commom.smethod_45(text2))
				{
					text2 = ((text2 != "") ? "-1" : "-2");
				}
				dataGridViewSortCompareEventArgs_0.SortResult = int.Parse(text).CompareTo(int.Parse(text2));
			}
			else if (dataGridViewSortCompareEventArgs_0.Column.Name == "cEmail" || dataGridViewSortCompareEventArgs_0.Column.Name == "cMailRecovery")
			{
				string text8 = "";
				string strB2 = "";
				if (text.Contains("@"))
				{
					text8 = text.Split('@')[1];
				}
				if (text2.Contains("@"))
				{
					strB2 = text2.Split('@')[1];
				}
				dataGridViewSortCompareEventArgs_0.SortResult = text8.CompareTo(strB2);
			}
			else
			{
				dataGridViewSortCompareEventArgs_0.SortResult = text.CompareTo(text2);
			}
		}
		catch (Exception)
		{
			dataGridViewSortCompareEventArgs_0.SortResult = 0;
		}
		dataGridViewSortCompareEventArgs_0.Handled = true;
	}
}
