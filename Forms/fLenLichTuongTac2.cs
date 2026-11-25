using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;

public class fLenLichTuongTac2 : Form
{
	[Serializable]
	[CompilerGenerated]
	private sealed class AEABDA33
	{
		internal static readonly AEABDA33 _003C_003E9 = new AEABDA33();

		internal static DataGridViewCellCancelEventHandler _003C_003E9__4_0;

		internal static Func<DataRow, string> _003C_003E9__9_1;

		internal static Func<DataRow, string> _003C_003E9__12_1;

		internal static Func<DataRow, string> _003C_003E9__15_1;

		internal void A927051C(object sender, DataGridViewCellCancelEventArgs e)
		{
			e.Cancel = true;
		}

		internal string A597213F(DataRow dataRow_0)
		{
			return dataRow_0["TenKichBan"].ToString();
		}

		internal string E22009AB(DataRow dataRow_0)
		{
			return dataRow_0["Id_KichBan"].ToString();
		}

		internal string method_0(DataRow C18C6C21)
		{
			return C18C6C21["Id_KichBan"].ToString();
		}
	}

	[CompilerGenerated]
	private sealed class Class47
	{
		internal string string_0;

		internal DateTime dateTime_0;

		internal bool method_0(DataRow E50B0C30)
		{
			return E50B0C30["TenKichBan"].ToString() == string_0;
		}

		internal bool method_1((DateTime dateTime, string idKichBan) valueTuple_0)
		{
			return valueTuple_0.dateTime == dateTime_0;
		}
	}

	[CompilerGenerated]
	private sealed class D1A74E10
	{
		internal fLenLichTuongTac2 fLenLichTuongTac2_0;

		internal DataGridViewCellEventArgs dataGridViewCellEventArgs_0;
	}

	[CompilerGenerated]
	private sealed class EB9E8B34
	{
		internal Dictionary<string, string> F19C7A9B;

		internal string string_0;

		internal string C1B57622;

		internal D1A74E10 CC10D58D;

		internal void method_0(object sender, EventArgs e)
		{
			string text = CC10D58D.fLenLichTuongTac2_0.BA11ED84.SelectedItem?.ToString();
			string text2 = (F19C7A9B.ContainsKey(text) ? F19C7A9B[text] : null);
			string s = CC10D58D.fLenLichTuongTac2_0.dataGridView1.Rows[CC10D58D.dataGridViewCellEventArgs_0.RowIndex].Cells[0].Value.ToString();
			TimeSpan value = TimeSpan.Parse(s);
			for (int i = 1; i < CC10D58D.fLenLichTuongTac2_0.dataGridView1.Columns.Count; i++)
			{
				AD381C2C CS_0024_003C_003E8__locals1 = new AD381C2C();
				string headerText = CC10D58D.fLenLichTuongTac2_0.dataGridView1.Columns[i].HeaderText;
				string[] array = headerText.Split(' ');
				if (array.Length >= 2)
				{
					CS_0024_003C_003E8__locals1.BCA60BA1 = DateTime.ParseExact(array[1], "dd/MM/yyyy", null).Add(value);
					CC10D58D.fLenLichTuongTac2_0.EC961D8D.RemoveAll(((DateTime dateTime, string idKichBan) E40C2D29) => E40C2D29.dateTime.Date == CS_0024_003C_003E8__locals1.BCA60BA1.Date && E40C2D29.dateTime.TimeOfDay == CS_0024_003C_003E8__locals1.BCA60BA1.TimeOfDay);
					DataGridViewCell dataGridViewCell = CC10D58D.fLenLichTuongTac2_0.dataGridView1.Rows[CC10D58D.dataGridViewCellEventArgs_0.RowIndex].Cells[i];
					dataGridViewCell.Value = string.Empty;
				}
			}
			if (text != "Hủy đặt lịch" && text2 != null)
			{
				Dictionary<string, string> dictionary = new Dictionary<string, string>
				{
					{ "Thứ 2", "T2" },
					{ "Thứ 3", "T3" },
					{ "Thứ 4", "T4" },
					{ "Thứ 5", "T5" },
					{ "Thứ 6", "T6" },
					{ "Thứ 7", "T7" },
					{ "Chủ Nhật", "CN" }
				};
				for (int j = 1; j < CC10D58D.fLenLichTuongTac2_0.dataGridView1.Columns.Count; j++)
				{
					string headerText2 = CC10D58D.fLenLichTuongTac2_0.dataGridView1.Columns[j].HeaderText;
					string[] array2 = headerText2.Split(' ');
					if (array2.Length < 2)
					{
						continue;
					}
					string text3 = array2[0];
					string text4 = array2[1];
					if (!int.TryParse(text4.Split('/')[0], out var result))
					{
						continue;
					}
					bool flag = string_0 == "Tất cả" || (dictionary.ContainsKey(string_0) && text3.Equals(dictionary[string_0], StringComparison.OrdinalIgnoreCase));
					bool flag2 = result % 2 == 0;
					bool flag3 = C1B57622 == "Tất cả" || (C1B57622 == "Ngày chẵn" && flag2) || (C1B57622 == "Ngày lẻ" && !flag2);
					if (flag && flag3)
					{
						Class48 CS_0024_003C_003E8__locals0 = new Class48();
						DataGridViewCell dataGridViewCell2 = CC10D58D.fLenLichTuongTac2_0.dataGridView1.Rows[CC10D58D.dataGridViewCellEventArgs_0.RowIndex].Cells[j];
						dataGridViewCell2.Value = text;
						dataGridViewCell2.Style.ForeColor = Color.DarkGreen;
						dataGridViewCell2.Style.SelectionForeColor = Color.DarkGreen;
						CS_0024_003C_003E8__locals0.B72BD096 = DateTime.ParseExact(text4, "dd/MM/yyyy", null).Add(value);
						if (!CC10D58D.fLenLichTuongTac2_0.EC961D8D.Any(((DateTime dateTime, string idKichBan) A3BD8695) => A3BD8695.dateTime == CS_0024_003C_003E8__locals0.B72BD096))
						{
							CC10D58D.fLenLichTuongTac2_0.EC961D8D.Add((CS_0024_003C_003E8__locals0.B72BD096, text2));
						}
					}
				}
			}
			CC10D58D.fLenLichTuongTac2_0.Controls.Remove(CC10D58D.fLenLichTuongTac2_0.BA11ED84);
			CC10D58D.fLenLichTuongTac2_0.BA11ED84.Dispose();
			CC10D58D.fLenLichTuongTac2_0.BA11ED84 = null;
		}
	}

	[CompilerGenerated]
	private sealed class AD381C2C
	{
		internal DateTime BCA60BA1;

		internal bool E3911525((DateTime dateTime, string idKichBan) E40C2D29)
		{
			return E40C2D29.dateTime.Date == BCA60BA1.Date && E40C2D29.dateTime.TimeOfDay == BCA60BA1.TimeOfDay;
		}
	}

	[CompilerGenerated]
	private sealed class Class48
	{
		internal DateTime B72BD096;

		internal bool method_0((DateTime dateTime, string idKichBan) A3BD8695)
		{
			return A3BD8695.dateTime == B72BD096;
		}
	}

	[CompilerGenerated]
	private sealed class C2009C1D
	{
		internal Dictionary<string, string> dictionary_0;

		internal DataGridViewCell dataGridViewCell_0;

		internal DateTime dateTime_0;

		internal D1A74E10 EF23FF1E;

		internal Func<(DateTime dateTime, string idKichBan), bool> DF322120;

		internal Predicate<(DateTime dateTime, string idKichBan)> predicate_0;

		internal Predicate<(DateTime dateTime, string idKichBan)> predicate_1;

		internal void FA027134(object sender, EventArgs e)
		{
			string text = EF23FF1E.fLenLichTuongTac2_0.BA11ED84.SelectedItem?.ToString();
			string text2 = (dictionary_0.ContainsKey(text) ? dictionary_0[text] : null);
			if (text != "Hủy đặt lịch" && text2 != null)
			{
				dataGridViewCell_0.Value = text;
				dataGridViewCell_0.Style.ForeColor = Color.DarkGreen;
				dataGridViewCell_0.Style.SelectionForeColor = Color.DarkGreen;
				if (!EF23FF1E.fLenLichTuongTac2_0.EC961D8D.Any(((DateTime dateTime, string idKichBan) valueTuple_0) => valueTuple_0.dateTime == dateTime_0))
				{
					EF23FF1E.fLenLichTuongTac2_0.EC961D8D.Add((dateTime_0, text2));
				}
				else
				{
					EF23FF1E.fLenLichTuongTac2_0.EC961D8D.RemoveAll(((DateTime dateTime, string idKichBan) valueTuple_0) => valueTuple_0.dateTime == dateTime_0);
					EF23FF1E.fLenLichTuongTac2_0.EC961D8D.Add((dateTime_0, text2));
				}
			}
			else
			{
				dataGridViewCell_0.Value = string.Empty;
				EF23FF1E.fLenLichTuongTac2_0.EC961D8D.RemoveAll(((DateTime dateTime, string idKichBan) valueTuple_0) => valueTuple_0.dateTime == dateTime_0);
			}
			EF23FF1E.fLenLichTuongTac2_0.Controls.Remove(EF23FF1E.fLenLichTuongTac2_0.BA11ED84);
			EF23FF1E.fLenLichTuongTac2_0.BA11ED84.Dispose();
			EF23FF1E.fLenLichTuongTac2_0.BA11ED84 = null;
		}

		internal bool method_0((DateTime dateTime, string idKichBan) valueTuple_0)
		{
			return valueTuple_0.dateTime == dateTime_0;
		}

		internal bool method_1((DateTime dateTime, string idKichBan) valueTuple_0)
		{
			return valueTuple_0.dateTime == dateTime_0;
		}

		internal bool method_2((DateTime dateTime, string idKichBan) valueTuple_0)
		{
			return valueTuple_0.dateTime == dateTime_0;
		}
	}

	[CompilerGenerated]
	private sealed class Class49
	{
		internal string C191ADB0;

		internal bool A0B5621B(DataRow D798E4B8)
		{
			return D798E4B8["TenKichBan"].ToString() == C191ADB0;
		}
	}

	[CompilerGenerated]
	private sealed class Class50
	{
		internal (DateTime dateTime, string idKichBan) A3184F16;

		internal bool method_0(DataRow D4870D94)
		{
			return D4870D94["Id_KichBan"].ToString() == A3184F16.idKichBan;
		}
	}

	internal int A83EDC35;

	internal int C514B82E;

	internal List<(DateTime dateTime, string idKichBan)> EC961D8D = new List<(DateTime, string)>();

	internal ComboBox BA11ED84;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal Action<List<(DateTime date, TimeSpan time, string idKichBan)>> F10C9D9D;

	internal IContainer icontainer_0 = null;

	internal BunifuCards CDB216B4;

	internal Panel A02B2B94;

	internal BunifuCustomLabel F53A4EAB;

	internal Button btnCancel;

	internal BunifuDragControl bunifuDragControl_0;

	internal PictureBox pictureBox1;

	internal Button btnSchedule;

	internal Button btnNextMonth;

	internal Button btnPrevMonth;

	internal DataGridView dataGridView1;

	internal ComboBox cbbThu;

	internal Label B99FBD0B;

	internal Label D2A63305;

	internal ComboBox cbbNgay;

	internal Button btnXoaLich;

	internal Button btnClose;

	internal Button button1;

	public event Action<List<(DateTime date, TimeSpan time, string idKichBan)>> Event_0
	{
		[CompilerGenerated]
		add
		{
			Action<List<(DateTime, TimeSpan, string)>> action = F10C9D9D;
			Action<List<(DateTime, TimeSpan, string)>> action2;
			do
			{
				action2 = action;
				Action<List<(DateTime, TimeSpan, string)>> value2 = (Action<List<(DateTime, TimeSpan, string)>>)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref F10C9D9D, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action<List<(DateTime, TimeSpan, string)>> action = F10C9D9D;
			Action<List<(DateTime, TimeSpan, string)>> action2;
			do
			{
				action2 = action;
				Action<List<(DateTime, TimeSpan, string)>> value2 = (Action<List<(DateTime, TimeSpan, string)>>)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref F10C9D9D, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public fLenLichTuongTac2()
	{
		InitializeComponent();
		A83EDC35 = DateTime.Now.Month;
		C514B82E = DateTime.Now.Year;
		cbbThu.Items.Clear();
		cbbNgay.Items.Clear();
		ComboBox.ObjectCollection items = cbbThu.Items;
		object[] items2 = new string[8] { "Tất cả", "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ Nhật" };
		items.AddRange(items2);
		cbbThu.SelectedIndex = 0;
		ComboBox.ObjectCollection items3 = cbbNgay.Items;
		items2 = new string[3] { "Tất cả", "Ngày chẵn", "Ngày lẻ" };
		items3.AddRange(items2);
		cbbNgay.SelectedIndex = 0;
		foreach (DataGridViewColumn column in dataGridView1.Columns)
		{
			column.ReadOnly = true;
		}
		dataGridView1.CellBeginEdit += delegate(object sender, DataGridViewCellCancelEventArgs e)
		{
			e.Cancel = true;
		};
		base.Controls.Add(dataGridView1);
		DDBAFC29(A83EDC35, C514B82E);
		Language.CD21F0A9(this);
	}

	private void DF804B1A()
	{
		Language.C43D0AAC(F53A4EAB);
		Language.C43D0AAC(btnSchedule);
		Language.C43D0AAC(btnCancel);
		Language.C43D0AAC(btnXoaLich);
	}

	private void method_0(object sender, EventArgs e)
	{
		Close();
	}

	private void F98F9231(object sender, EventArgs e)
	{
		Close();
	}

	private void C1026933(object sender, EventArgs e)
	{
		bool flag = false;
		foreach (DataGridViewRow item in (IEnumerable)dataGridView1.Rows)
		{
			for (int i = 1; i < dataGridView1.Columns.Count; i++)
			{
				DataGridViewCell dataGridViewCell = item.Cells[i];
				if (dataGridViewCell.Value?.ToString() != "")
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				break;
			}
		}
		if (!flag)
		{
			MessageBox.Show("Bạn chưa đặt lịch.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			return;
		}
		DialogResult dialogResult = MessageBox.Show("Bạn có muốn xóa toàn bộ lịch đã đặt không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (dialogResult != DialogResult.Yes)
		{
			return;
		}
		EC961D8D.Clear();
		foreach (DataGridViewRow item2 in (IEnumerable)dataGridView1.Rows)
		{
			for (int j = 1; j < dataGridView1.Columns.Count; j++)
			{
				DataGridViewCell dataGridViewCell2 = item2.Cells[j];
				dataGridViewCell2.Value = "";
			}
		}
	}

	private void DDBAFC29(int CB376AA8, int C30AA42D)
	{
		dataGridView1.Columns.Clear();
		dataGridView1.Rows.Clear();
		dataGridView1.Columns.Add("colTime", "Giờ");
		dataGridView1.Columns[0].Frozen = true;
		dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
		dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
		for (int i = 1; i <= DateTime.DaysInMonth(C30AA42D, CB376AA8); i++)
		{
			DateTime dateTime = new DateTime(C30AA42D, CB376AA8, i);
			string arg = dateTime.ToString("ddd", new CultureInfo("vi-VN"));
			string headerText = $"{arg} {dateTime:dd/MM/yyyy}";
			dataGridView1.Columns.Add($"col{i}", headerText);
			dataGridView1.Columns[$"col{i}"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
			dataGridView1.Columns[$"col{i}"].Width = 100;
		}
		Match match = Regex.Match(C5034B95.smethod_0("cauHinhThoiGianLapLich").BDB80B23("rdCauHinhThoiGianLapLich"), "\\d+");
		int num = 60 / int.Parse(match.Value);
		int num2 = int.Parse(match.Value);
		for (int j = 0; j < 24; j++)
		{
			for (int k = 0; k < num; k++)
			{
				int minute = k * num2;
				string value = new DateTime(1, 1, 1, j, minute, 0).ToString("HH:mm");
				int index = dataGridView1.Rows.Add();
				dataGridView1.Rows[index].Cells[0].Value = value;
			}
		}
		DataTable source = Class154.smethod_2();
		foreach (var A3184F16 in EC961D8D)
		{
			DateTime item = A3184F16.dateTime;
			if (item.Month != CB376AA8 || item.Year != C30AA42D)
			{
				continue;
			}
			int day = item.Day;
			int num3 = item.Hour * 2 + item.Minute / 30;
			if (num3 >= 0 && num3 < dataGridView1.Rows.Count && day > 0 && day <= dataGridView1.Columns.Count - 1)
			{
				DataGridViewCell dataGridViewCell = dataGridView1.Rows[num3].Cells[day];
				string text = (string)(dataGridViewCell.Value = (from D4870D94 in source.AsEnumerable()
					where D4870D94["Id_KichBan"].ToString() == A3184F16.idKichBan
					select D4870D94 into dataRow_0
					select dataRow_0["TenKichBan"].ToString()).FirstOrDefault() ?? "Unknown");
				dataGridViewCell.Style.ForeColor = Color.DarkGreen;
				dataGridViewCell.Style.SelectionForeColor = Color.DarkGreen;
			}
		}
		dataGridView1.AllowUserToResizeColumns = false;
		dataGridView1.AllowUserToResizeRows = false;
	}

	private void btnPrevMonth_Click(object sender, EventArgs e)
	{
		C091A223();
		A83EDC35--;
		if (A83EDC35 < 1)
		{
			A83EDC35 = 12;
			C514B82E--;
		}
		DDBAFC29(A83EDC35, C514B82E);
	}

	private void BE380F89(object sender, EventArgs e)
	{
		C091A223();
		A83EDC35++;
		if (A83EDC35 > 12)
		{
			A83EDC35 = 1;
			C514B82E++;
		}
		DDBAFC29(A83EDC35, C514B82E);
	}

	private void C091A223()
	{
		DataTable source = Class154.smethod_2();
		foreach (DataGridViewRow item in (IEnumerable)dataGridView1.Rows)
		{
			for (int i = 1; i < dataGridView1.Columns.Count; i++)
			{
				DataGridViewCell dataGridViewCell = item.Cells[i];
				if (!(dataGridViewCell.Value?.ToString() != ""))
				{
					continue;
				}
				string headerText = dataGridView1.Columns[i].HeaderText;
				string[] array = headerText.Split(' ');
				if (array.Length >= 2)
				{
					DateTime dateTime = DateTime.ParseExact(array[1], "dd/MM/yyyy", null);
					TimeSpan value = TimeSpan.Parse(item.Cells[0].Value.ToString());
					DateTime dateTime_0 = dateTime.Add(value);
					string string_0 = dataGridViewCell.Value.ToString();
					string text = (from E50B0C30 in source.AsEnumerable()
						where E50B0C30["TenKichBan"].ToString() == string_0
						select E50B0C30 into dataRow_0
						select dataRow_0["Id_KichBan"].ToString()).FirstOrDefault();
					EC961D8D.RemoveAll(((DateTime dateTime, string idKichBan) valueTuple_0) => valueTuple_0.dateTime == dateTime_0);
					if (text != null)
					{
						EC961D8D.Add((dateTime_0, text));
					}
				}
			}
		}
	}

	private int method_1(ComboBox comboBox_0)
	{
		int num = 0;
		using (Graphics graphics = comboBox_0.CreateGraphics())
		{
			foreach (object item in comboBox_0.Items)
			{
				int val = (int)graphics.MeasureString(item.ToString(), comboBox_0.Font).Width + 20;
				num = Math.Max(num, val);
			}
		}
		return num;
	}

	private void ABAF2F2F(object sender, DataGridViewCellEventArgs e)
	{
		if (e.RowIndex < 0 || e.ColumnIndex < 0)
		{
			return;
		}
		object[] items2;
		if (e.ColumnIndex == 0)
		{
			string string_0 = cbbThu.SelectedItem?.ToString();
			string C1B57622 = cbbNgay.SelectedItem?.ToString();
			if (string.IsNullOrEmpty(string_0) || string.IsNullOrEmpty(C1B57622))
			{
				MessageBox.Show("Vui lòng chọn Thứ và Ngày trước khi đặt lịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (string_0 == "Không chọn" || C1B57622 == "Không chọn")
			{
				MessageBox.Show("Vui lòng chọn giá trị hợp lệ cho Thứ và Ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			if (BA11ED84 != null)
			{
				base.Controls.Remove(BA11ED84);
				BA11ED84.Dispose();
				BA11ED84 = null;
			}
			Rectangle cellDisplayRectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, cutOverflow: false);
			BA11ED84 = new ComboBox
			{
				DropDownStyle = ComboBoxStyle.DropDownList,
				Location = new Point(cellDisplayRectangle.Left + dataGridView1.Left, cellDisplayRectangle.Top + dataGridView1.Top),
				Height = cellDisplayRectangle.Height
			};
			DataTable dataTable = Class154.smethod_2();
			Dictionary<string, string> F19C7A9B = new Dictionary<string, string>();
			List<string> list = new List<string>();
			foreach (DataRow row in dataTable.Rows)
			{
				string text = row["TenKichBan"].ToString();
				string value = row["Id_KichBan"].ToString();
				list.Add(text);
				F19C7A9B[text] = value;
			}
			list.Add("Hủy đặt lịch");
			ComboBox.ObjectCollection items = BA11ED84.Items;
			items2 = list.ToArray();
			items.AddRange(items2);
			BA11ED84.SelectedIndex = list.IndexOf("Hủy đặt lịch");
			BA11ED84.Width = method_1(BA11ED84);
			BA11ED84.SelectedIndexChanged += delegate
			{
				string text5 = BA11ED84.SelectedItem?.ToString();
				string text6 = (F19C7A9B.ContainsKey(text5) ? F19C7A9B[text5] : null);
				string s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
				TimeSpan value4 = TimeSpan.Parse(s);
				for (int i = 1; i < dataGridView1.Columns.Count; i++)
				{
					string headerText2 = dataGridView1.Columns[i].HeaderText;
					string[] array2 = headerText2.Split(' ');
					if (array2.Length >= 2)
					{
						DateTime BCA60BA1 = DateTime.ParseExact(array2[1], "dd/MM/yyyy", null).Add(value4);
						EC961D8D.RemoveAll(((DateTime dateTime, string idKichBan) E40C2D29) => E40C2D29.dateTime.Date == BCA60BA1.Date && E40C2D29.dateTime.TimeOfDay == BCA60BA1.TimeOfDay);
						DataGridViewCell dataGridViewCell = dataGridView1.Rows[e.RowIndex].Cells[i];
						dataGridViewCell.Value = string.Empty;
					}
				}
				if (text5 != "Hủy đặt lịch" && text6 != null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>
					{
						{ "Thứ 2", "T2" },
						{ "Thứ 3", "T3" },
						{ "Thứ 4", "T4" },
						{ "Thứ 5", "T5" },
						{ "Thứ 6", "T6" },
						{ "Thứ 7", "T7" },
						{ "Chủ Nhật", "CN" }
					};
					for (int j = 1; j < dataGridView1.Columns.Count; j++)
					{
						string headerText3 = dataGridView1.Columns[j].HeaderText;
						string[] array3 = headerText3.Split(' ');
						if (array3.Length >= 2)
						{
							string text7 = array3[0];
							string text8 = array3[1];
							if (int.TryParse(text8.Split('/')[0], out var result))
							{
								bool flag = string_0 == "Tất cả" || (dictionary.ContainsKey(string_0) && text7.Equals(dictionary[string_0], StringComparison.OrdinalIgnoreCase));
								bool flag2 = result % 2 == 0;
								bool flag3 = C1B57622 == "Tất cả" || (C1B57622 == "Ngày chẵn" && flag2) || (C1B57622 == "Ngày lẻ" && !flag2);
								if (flag && flag3)
								{
									DataGridViewCell dataGridViewCell2 = dataGridView1.Rows[e.RowIndex].Cells[j];
									dataGridViewCell2.Value = text5;
									dataGridViewCell2.Style.ForeColor = Color.DarkGreen;
									dataGridViewCell2.Style.SelectionForeColor = Color.DarkGreen;
									DateTime B72BD96 = DateTime.ParseExact(text8, "dd/MM/yyyy", null).Add(value4);
									if (!EC961D8D.Any(((DateTime dateTime, string idKichBan) A3BD8695) => A3BD8695.dateTime == B72BD96))
									{
										EC961D8D.Add((B72BD96, text6));
									}
								}
							}
						}
					}
				}
				base.Controls.Remove(BA11ED84);
				BA11ED84.Dispose();
				BA11ED84 = null;
			};
			base.Controls.Add(BA11ED84);
			BA11ED84.DroppedDown = true;
			return;
		}
		DataGridViewCell dataGridViewCell_0 = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
		string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
		string[] array = headerText.Split(' ');
		if (array.Length < 2)
		{
			return;
		}
		DateTime dateTime = DateTime.ParseExact(array[1], "dd/MM/yyyy", null);
		TimeSpan value2 = TimeSpan.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
		DateTime dateTime_0 = dateTime.Add(value2);
		if (BA11ED84 != null)
		{
			base.Controls.Remove(BA11ED84);
			BA11ED84.Dispose();
			BA11ED84 = null;
		}
		Rectangle cellDisplayRectangle2 = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, cutOverflow: false);
		BA11ED84 = new ComboBox
		{
			DropDownStyle = ComboBoxStyle.DropDownList,
			Location = new Point(cellDisplayRectangle2.Left + dataGridView1.Left, cellDisplayRectangle2.Top + dataGridView1.Top),
			Height = cellDisplayRectangle2.Height
		};
		DataTable dataTable2 = Class154.smethod_2();
		Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();
		List<string> list2 = new List<string>();
		foreach (DataRow row2 in dataTable2.Rows)
		{
			string text2 = row2["TenKichBan"].ToString();
			string value3 = row2["Id_KichBan"].ToString();
			list2.Add(text2);
			dictionary_0[text2] = value3;
		}
		list2.Add("Hủy đặt lịch");
		ComboBox.ObjectCollection items3 = BA11ED84.Items;
		items2 = list2.ToArray();
		items3.AddRange(items2);
		BA11ED84.SelectedIndex = (list2.Contains(dataGridViewCell_0.Value?.ToString()) ? list2.IndexOf(dataGridViewCell_0.Value.ToString()) : list2.IndexOf("Hủy đặt lịch"));
		BA11ED84.Width = method_1(BA11ED84);
		BA11ED84.SelectedIndexChanged += delegate
		{
			string text3 = BA11ED84.SelectedItem?.ToString();
			string text4 = (dictionary_0.ContainsKey(text3) ? dictionary_0[text3] : null);
			if (text3 != "Hủy đặt lịch" && text4 != null)
			{
				dataGridViewCell_0.Value = text3;
				dataGridViewCell_0.Style.ForeColor = Color.DarkGreen;
				dataGridViewCell_0.Style.SelectionForeColor = Color.DarkGreen;
				if (!EC961D8D.Any(((DateTime dateTime, string idKichBan) valueTuple_0) => valueTuple_0.dateTime == dateTime_0))
				{
					EC961D8D.Add((dateTime_0, text4));
				}
				else
				{
					EC961D8D.RemoveAll(((DateTime dateTime, string idKichBan) valueTuple_0) => valueTuple_0.dateTime == dateTime_0);
					EC961D8D.Add((dateTime_0, text4));
				}
			}
			else
			{
				dataGridViewCell_0.Value = string.Empty;
				EC961D8D.RemoveAll(((DateTime dateTime, string idKichBan) valueTuple_0) => valueTuple_0.dateTime == dateTime_0);
			}
			base.Controls.Remove(BA11ED84);
			BA11ED84.Dispose();
			BA11ED84 = null;
		};
		base.Controls.Add(BA11ED84);
		BA11ED84.DroppedDown = true;
	}

	private void btnSchedule_Click(object sender, EventArgs e)
	{
		List<(DateTime, TimeSpan, string)> list = new List<(DateTime, TimeSpan, string)>();
		List<string> list2 = new List<string>();
		DataTable source = Class154.smethod_2();
		foreach (DataGridViewRow item in (IEnumerable)dataGridView1.Rows)
		{
			for (int i = 1; i < dataGridView1.Columns.Count; i++)
			{
				DataGridViewCell dataGridViewCell = item.Cells[i];
				if (string.IsNullOrEmpty(dataGridViewCell.Value?.ToString()))
				{
					continue;
				}
				string headerText = dataGridView1.Columns[i].HeaderText;
				string[] array = headerText.Split(' ');
				if (array.Length >= 2)
				{
					string arg = array[0];
					DateTime dateTime = DateTime.ParseExact(array[1], "dd/MM/yyyy", null);
					TimeSpan timeSpan = TimeSpan.Parse(item.Cells[0].Value.ToString());
					string C191ADB0 = dataGridViewCell.Value.ToString();
					string text = (from D798E4B8 in source.AsEnumerable()
						where D798E4B8["TenKichBan"].ToString() == C191ADB0
						select D798E4B8 into C18C6C21
						select C18C6C21["Id_KichBan"].ToString()).FirstOrDefault();
					if (text != null)
					{
						list2.Add($"{arg} {dateTime:dd/MM/yyyy} lúc {timeSpan}");
						list.Add((dateTime, timeSpan, text));
					}
				}
			}
		}
		if (list2.Count > 0)
		{
			MessageBox.Show("Bạn đã đặt lịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		else
		{
			MessageBox.Show("Bạn chưa đặt lịch.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
		F10C9D9D?.Invoke(list);
		Close();
	}

	private void E983B32D(object sender, EventArgs e)
	{
		Close();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		C5034B95.smethod_0("cauHinhThoiGianLapLich").ED11179C();
		Commom.smethod_35(new fCauHinhHienThiThoiGianLapLinh());
		A83EDC35 = DateTime.Now.Month;
		C514B82E = DateTime.Now.Year;
		DDBAFC29(A83EDC35, C514B82E);
	}

	protected override void Dispose(bool BBB35A82)
	{
		if (BBB35A82 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(BBB35A82);
	}

	private void InitializeComponent()
	{
		icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLenLichTuongTac2));
		CDB216B4 = new Bunifu.Framework.UI.BunifuCards();
		A02B2B94 = new System.Windows.Forms.Panel();
		btnClose = new System.Windows.Forms.Button();
		pictureBox1 = new System.Windows.Forms.PictureBox();
		F53A4EAB = new Bunifu.Framework.UI.BunifuCustomLabel();
		btnCancel = new System.Windows.Forms.Button();
		btnSchedule = new System.Windows.Forms.Button();
		bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
		btnNextMonth = new System.Windows.Forms.Button();
		btnPrevMonth = new System.Windows.Forms.Button();
		dataGridView1 = new System.Windows.Forms.DataGridView();
		cbbThu = new System.Windows.Forms.ComboBox();
		B99FBD0B = new System.Windows.Forms.Label();
		D2A63305 = new System.Windows.Forms.Label();
		cbbNgay = new System.Windows.Forms.ComboBox();
		btnXoaLich = new System.Windows.Forms.Button();
		button1 = new System.Windows.Forms.Button();
		CDB216B4.SuspendLayout();
		A02B2B94.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
		((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
		SuspendLayout();
		CDB216B4.BackColor = System.Drawing.Color.White;
		CDB216B4.BorderRadius = 0;
		CDB216B4.BottomSahddow = true;
		CDB216B4.color = System.Drawing.Color.SaddleBrown;
		CDB216B4.Controls.Add(A02B2B94);
		CDB216B4.Dock = System.Windows.Forms.DockStyle.Top;
		CDB216B4.LeftSahddow = false;
		CDB216B4.Location = new System.Drawing.Point(0, 0);
		CDB216B4.Name = "bunifuCards1";
		CDB216B4.RightSahddow = true;
		CDB216B4.ShadowDepth = 20;
		CDB216B4.Size = new System.Drawing.Size(674, 38);
		CDB216B4.TabIndex = 0;
		A02B2B94.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		A02B2B94.BackColor = System.Drawing.Color.White;
		A02B2B94.Controls.Add(btnClose);
		A02B2B94.Controls.Add(pictureBox1);
		A02B2B94.Controls.Add(F53A4EAB);
		A02B2B94.Location = new System.Drawing.Point(0, 5);
		A02B2B94.Name = "pnlHeader";
		A02B2B94.Size = new System.Drawing.Size(674, 32);
		A02B2B94.TabIndex = 9;
		btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
		btnClose.Dock = System.Windows.Forms.DockStyle.Right;
		btnClose.FlatAppearance.BorderSize = 0;
		btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		btnClose.ForeColor = System.Drawing.Color.White;
		btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
		btnClose.Location = new System.Drawing.Point(642, 0);
		btnClose.Name = "btnClose";
		btnClose.Size = new System.Drawing.Size(32, 32);
		btnClose.TabIndex = 78;
		btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
		btnClose.UseVisualStyleBackColor = true;
		btnClose.Click += new System.EventHandler(E983B32D);
		pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
		pictureBox1.Image = Class155.DD225F0D;
		pictureBox1.Location = new System.Drawing.Point(4, 1);
		pictureBox1.Name = "pictureBox1";
		pictureBox1.Size = new System.Drawing.Size(34, 27);
		pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
		pictureBox1.TabIndex = 77;
		pictureBox1.TabStop = false;
		F53A4EAB.Anchor = System.Windows.Forms.AnchorStyles.Top;
		F53A4EAB.BackColor = System.Drawing.Color.Transparent;
		F53A4EAB.Cursor = System.Windows.Forms.Cursors.SizeAll;
		F53A4EAB.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		F53A4EAB.ForeColor = System.Drawing.Color.Black;
		F53A4EAB.Location = new System.Drawing.Point(139, 0);
		F53A4EAB.Name = "bunifuCustomLabel1";
		F53A4EAB.Size = new System.Drawing.Size(396, 32);
		F53A4EAB.TabIndex = 1;
		F53A4EAB.Text = "Đặt lịch tương tác";
		F53A4EAB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnCancel.BackColor = System.Drawing.Color.Maroon;
		btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
		btnCancel.FlatAppearance.BorderSize = 0;
		btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnCancel.ForeColor = System.Drawing.Color.White;
		btnCancel.Location = new System.Drawing.Point(343, 438);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new System.Drawing.Size(92, 29);
		btnCancel.TabIndex = 4;
		btnCancel.Text = "Hủy";
		btnCancel.UseVisualStyleBackColor = false;
		btnCancel.Click += new System.EventHandler(F98F9231);
		btnSchedule.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
		btnSchedule.BackColor = System.Drawing.Color.FromArgb(53, 120, 229);
		btnSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
		btnSchedule.FlatAppearance.BorderSize = 0;
		btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		btnSchedule.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		btnSchedule.ForeColor = System.Drawing.Color.White;
		btnSchedule.Location = new System.Drawing.Point(239, 438);
		btnSchedule.Name = "btnSchedule";
		btnSchedule.Size = new System.Drawing.Size(92, 29);
		btnSchedule.TabIndex = 3;
		btnSchedule.Text = "Đặt lịch";
		btnSchedule.UseVisualStyleBackColor = false;
		btnSchedule.Click += new System.EventHandler(btnSchedule_Click);
		bunifuDragControl_0.Fixed = true;
		bunifuDragControl_0.Horizontal = true;
		bunifuDragControl_0.TargetControl = F53A4EAB;
		bunifuDragControl_0.Vertical = true;
		btnNextMonth.Location = new System.Drawing.Point(629, 40);
		btnNextMonth.Name = "btnNextMonth";
		btnNextMonth.Size = new System.Drawing.Size(26, 26);
		btnNextMonth.TabIndex = 7;
		btnNextMonth.Text = ">";
		btnNextMonth.UseVisualStyleBackColor = true;
		btnNextMonth.Click += new System.EventHandler(BE380F89);
		btnPrevMonth.Location = new System.Drawing.Point(12, 40);
		btnPrevMonth.Name = "btnPrevMonth";
		btnPrevMonth.Size = new System.Drawing.Size(26, 26);
		btnPrevMonth.TabIndex = 6;
		btnPrevMonth.Text = "<";
		btnPrevMonth.UseVisualStyleBackColor = true;
		btnPrevMonth.Click += new System.EventHandler(btnPrevMonth_Click);
		dataGridView1.AllowUserToAddRows = false;
		dataGridView1.AllowUserToDeleteRows = false;
		dataGridView1.AllowUserToResizeRows = false;
		dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		dataGridView1.Location = new System.Drawing.Point(12, 73);
		dataGridView1.Name = "dataGridView1";
		dataGridView1.RowHeadersVisible = false;
		dataGridView1.Size = new System.Drawing.Size(651, 347);
		dataGridView1.TabIndex = 5;
		dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(ABAF2F2F);
		cbbThu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbThu.FormattingEnabled = true;
		cbbThu.Location = new System.Drawing.Point(95, 40);
		cbbThu.Name = "cbbThu";
		cbbThu.Size = new System.Drawing.Size(121, 24);
		cbbThu.TabIndex = 78;
		B99FBD0B.AutoSize = true;
		B99FBD0B.Location = new System.Drawing.Point(54, 45);
		B99FBD0B.Name = "label1";
		B99FBD0B.Size = new System.Drawing.Size(35, 16);
		B99FBD0B.TabIndex = 79;
		B99FBD0B.Text = "Thứ:";
		D2A63305.AutoSize = true;
		D2A63305.Location = new System.Drawing.Point(236, 45);
		D2A63305.Name = "label2";
		D2A63305.Size = new System.Drawing.Size(40, 16);
		D2A63305.TabIndex = 81;
		D2A63305.Text = "Ngày:";
		cbbNgay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		cbbNgay.FormattingEnabled = true;
		cbbNgay.Location = new System.Drawing.Point(282, 42);
		cbbNgay.Name = "cbbNgay";
		cbbNgay.Size = new System.Drawing.Size(121, 24);
		cbbNgay.TabIndex = 80;
		btnXoaLich.Location = new System.Drawing.Point(502, 40);
		btnXoaLich.Name = "btnXoaLich";
		btnXoaLich.Size = new System.Drawing.Size(121, 26);
		btnXoaLich.TabIndex = 82;
		btnXoaLich.Text = "Xoá Lịch đã đặt";
		btnXoaLich.UseVisualStyleBackColor = true;
		btnXoaLich.Click += new System.EventHandler(C1026933);
		button1.Image = (System.Drawing.Image)resources.GetObject("button1.Image");
		button1.Location = new System.Drawing.Point(435, 40);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(26, 26);
		button1.TabIndex = 83;
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		base.ClientSize = new System.Drawing.Size(674, 478);
		base.Controls.Add(button1);
		base.Controls.Add(btnXoaLich);
		base.Controls.Add(D2A63305);
		base.Controls.Add(cbbNgay);
		base.Controls.Add(B99FBD0B);
		base.Controls.Add(cbbThu);
		base.Controls.Add(btnNextMonth);
		base.Controls.Add(btnPrevMonth);
		base.Controls.Add(dataGridView1);
		base.Controls.Add(btnCancel);
		base.Controls.Add(btnSchedule);
		base.Controls.Add(CDB216B4);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "fLenLichTuongTac2";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		Text = "fScheduleInteraction";
		CDB216B4.ResumeLayout(false);
		A02B2B94.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
		((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
		ResumeLayout(false);
		PerformLayout();
	}
}
