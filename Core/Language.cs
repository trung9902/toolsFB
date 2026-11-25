using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class Language
{
	[Serializable]
	[CompilerGenerated]
	private sealed class E2AD9908
	{
		internal static readonly E2AD9908 _003C_003E9 = new E2AD9908();

		internal static Func<Control, IEnumerable<Control>> _003C_003E9__4_0;

		internal IEnumerable<Control> method_0(Control control_0)
		{
			return F1B10D96(control_0);
		}
	}

	public static string GetValue(string string_0)
	{
		string text = "";
		if (Base.smethod_2() == "VN")
		{
			return string_0;
		}
		if (string_0 == "")
		{
			return string_0;
		}
		if (C5034B95.smethod_0("configDebug").method_3("ckbLanguage"))
		{
			GClass4 gClass = new GClass4("configLanguage");
			text = gClass.BDB80B23(string_0);
			if (text == "")
			{
				text = string_0;
				if (string_0.Trim() != "" && !Commom.smethod_45(string_0.Trim()) && string_0.Trim() != Commom.EB835717(string_0.Trim()))
				{
					try
					{
						File.AppendAllText("settings\\\\configLanguage.txt", string_0 + "\r\n");
					}
					catch
					{
					}
				}
			}
		}
		else
		{
			text = smethod_2(string_0);
			if (text == "")
			{
				text = string_0;
			}
		}
		return text;
	}

	public static void C43D0AAC(Control E21B721D, string string_0 = "VN")
	{
		if (E21B721D.Text.ToLower().Contains("(ẩn)"))
		{
			if (Base.bool_0)
			{
				E21B721D.Text = E21B721D.Text.Replace("(ẩn)", "");
			}
			else
			{
				E21B721D.Visible = false;
			}
		}
		E21B721D.Text = GetValue(E21B721D.Text);
	}

	public static void C3132E1D(ToolStripItem D31564B8, string B43DD786 = "VN")
	{
		if (D31564B8.Text.ToLower().Contains("(ẩn)"))
		{
			if (Base.bool_0)
			{
				D31564B8.Text = D31564B8.Text.Replace("(ẩn)", "");
			}
			else
			{
				D31564B8.Visible = false;
			}
		}
		D31564B8.Text = GetValue(D31564B8.Text);
	}

	public static void E608C23A(DataGridViewColumn C992DA8E, string string_0 = "VN")
	{
		C992DA8E.HeaderText = GetValue(C992DA8E.HeaderText);
	}

	public static IEnumerable<Control> F1B10D96(Control C710AB2D)
	{
		IEnumerable<Control> enumerable = C710AB2D.Controls.Cast<Control>();
		return enumerable.SelectMany((Control control_0) => F1B10D96(control_0)).Concat(enumerable);
	}

	public static void CD21F0A9(Control control_0)
	{
		try
		{
			if (control_0 is Form form)
			{
				form.Icon = Class155.D596C6A5;
			}
		}
		catch { }
		IEnumerable<Control> enumerable = F1B10D96(control_0);
		foreach (Control item in enumerable)
		{
			if (item is PictureBox pb && pb.Location.X <= 10 && pb.Location.Y <= 8 && (pb.Name.StartsWith("pictureBox") || pb.Parent?.Name == "pnlHeader" || pb.Parent?.Name == "A730AF01"))
			{
				try
				{
					pb.Image = Class155.DD225F0D;
				}
				catch { }
			}
			if (item is DataGridView)
			{
				foreach (DataGridViewColumn column in (item as DataGridView).Columns)
				{
					E608C23A(column);
				}
			}
			else if (item is MenuStrip)
			{
				foreach (ToolStripMenuItem item2 in (item as MenuStrip).Items)
				{
					C3132E1D(item2);
					if (item2.HasDropDownItems)
					{
						B6BBEF04(item2);
					}
				}
			}
			else if (item is StatusStrip)
			{
				foreach (ToolStripItem item3 in (item as StatusStrip).Items)
				{
					C3132E1D(item3);
				}
			}
			else if (item is RichTextBox)
			{
				(item as RichTextBox).smethod_5();
				C43D0AAC(item);
			}
			else if (item is TextBox txt)
			{
				try
				{
					string nameLower = (txt.Name ?? "").ToLower();
					if (nameLower.Contains("path") || nameLower.Contains("folder") || nameLower.Contains("thumuc") || 
					    nameLower.Contains("video") || nameLower.Contains("anh") || nameLower.Contains("image"))
					{
						if (txt.Tag == null || !txt.Tag.ToString().Contains("picker_attached"))
						{
							txt.Tag = (txt.Tag == null ? "" : txt.Tag.ToString()) + ";picker_attached";
							txt.Cursor = Cursors.Hand;
							txt.DoubleClick += (s, ev) =>
							{
								string folder = Commom.smethod_96();
								if (!string.IsNullOrEmpty(folder))
								{
									txt.Text = folder;
								}
							};
						}
					}
					else if (nameLower.Contains("file") || nameLower.Contains("txt"))
					{
						if (txt.Tag == null || !txt.Tag.ToString().Contains("picker_attached"))
						{
							txt.Tag = (txt.Tag == null ? "" : txt.Tag.ToString()) + ";picker_attached";
							txt.Cursor = Cursors.Hand;
							txt.DoubleClick += (s, ev) =>
							{
								string file = Commom.smethod_97("Chọn tệp", "", "All files (*.*)|*.*");
								if (!string.IsNullOrEmpty(file))
								{
									txt.Text = file;
								}
							};
						}
					}
				}
				catch { }
				C43D0AAC(item);
			}
			else
			{
				C43D0AAC(item);
			}
		}
	}

	public static void smethod_0(ContextMenuStrip contextMenuStrip_0)
	{
		foreach (ToolStripMenuItem item in contextMenuStrip_0.Items)
		{
			C3132E1D(item);
			if (item.HasDropDownItems)
			{
				B6BBEF04(item);
			}
		}
	}

	public static void B6BBEF04(ToolStripMenuItem toolStripMenuItem_0)
	{
		foreach (ToolStripMenuItem dropDownItem in toolStripMenuItem_0.DropDownItems)
		{
			C3132E1D(dropDownItem);
			if (dropDownItem.HasDropDownItems)
			{
				B6BBEF04(dropDownItem);
			}
		}
	}

	public static string smethod_2(string B22F1B08)
	{
		return B22F1B08;
	}
}
