using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public static class Extensions
{
	[Serializable]
	[CompilerGenerated]
	private sealed class B52545A4
	{
		internal static readonly B52545A4 _003C_003E9 = new B52545A4();

		internal static Func<KeyValuePair<string, List<string>>, string> _003C_003E9__10_0;

		internal static Func<KeyValuePair<string, List<string>>, List<string>> _003C_003E9__10_1;

		internal static Func<string, bool> _003C_003E9__12_0;

		internal string method_0(KeyValuePair<string, List<string>> AB870FA3)
		{
			return AB870FA3.Key;
		}

		internal List<string> BA21F32E(KeyValuePair<string, List<string>> keyValuePair_0)
		{
			return new List<string>(keyValuePair_0.Value);
		}

		internal bool F52B8D28(string BE8DC9AA)
		{
			return !string.IsNullOrWhiteSpace(BE8DC9AA);
		}
	}

	[CompilerGenerated]
	private sealed class Class84
	{
		internal Control control_0;

		internal bool bool_0;

		internal void DF1D0F83()
		{
			control_0.Enabled = bool_0;
		}
	}

	[CompilerGenerated]
	private sealed class Class85
	{
		internal Control F63459A6;

		internal string string_0;

		internal void C50DCDBD()
		{
			F63459A6.Text = string_0;
		}
	}

	[CompilerGenerated]
	private sealed class Class86
	{
		internal RichTextBox DB92439A;

		internal void method_0(object sender, EventArgs e)
		{
			DB92439A.SelectAll();
		}

		internal void method_1(object sender, EventArgs e)
		{
			DB92439A.Copy();
		}

		internal void method_2(object sender, EventArgs e)
		{
			DB92439A.Cut();
		}

		internal void method_3(object sender, EventArgs e)
		{
			DB92439A.Paste();
		}
	}

	public static Bitmap smethod_0(this string string_0)
	{
		try
		{
			byte[] array = Convert.FromBase64String(string_0);
			MemoryStream memoryStream = new MemoryStream(array, 0, array.Length);
			memoryStream.Write(array, 0, array.Length);
			Image original = Image.FromStream(memoryStream, useEmbeddedColorManagement: true);
			return new Bitmap(original);
		}
		catch
		{
		}
		return null;
	}

	public static void smethod_1(this Control control_0, bool bool_0 = true)
	{
		try
		{
			control_0.Invoke((MethodInvoker)delegate
			{
				control_0.Enabled = bool_0;
			});
		}
		catch
		{
		}
	}

	public static void smethod_2(this Control control_0, string AC1468A1)
	{
		try
		{
			control_0.Invoke((MethodInvoker)delegate
			{
				control_0.Text = AC1468A1;
			});
		}
		catch
		{
		}
	}

	public static string smethod_3(this string string_0)
	{
		return WebUtility.UrlEncode(string_0);
	}

	public static string A9341621(this string E7956B26)
	{
		return WebUtility.HtmlDecode(E7956B26);
	}

	public static void E6175915(this Form F08A6438)
	{
		if (F08A6438.WindowState == FormWindowState.Maximized)
		{
			F08A6438.WindowState = FormWindowState.Normal;
			return;
		}
		Rectangle workingArea = Screen.FromHandle(F08A6438.Handle).WorkingArea;
		workingArea.Location = new Point(0, 0);
		F08A6438.MaximumSize = workingArea.Size;
		F08A6438.WindowState = FormWindowState.Maximized;
	}

	public static void AF8ADE0B(this Control control_0, string E5A0B62B = "Search...")
	{
		E5A0B62B = Language.GetValue(E5A0B62B);
		control_0.Tag = E5A0B62B;
		if (control_0.Text == "" || control_0.Text == E5A0B62B)
		{
			control_0.Text = E5A0B62B;
			control_0.ForeColor = Color.Gray;
		}
		control_0.Leave += smethod_4;
		control_0.Enter += B43547B2;
	}

	private static void B43547B2(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Text == control.Tag.ToString())
		{
			control.Text = "";
			control.ForeColor = Color.Black;
		}
	}

	private static void smethod_4(object sender, EventArgs e)
	{
		Control control = sender as Control;
		if (control.Text == "")
		{
			control.Text = control.Tag.ToString();
			control.ForeColor = Color.Gray;
		}
	}

	public static void smethod_5(this RichTextBox D7254A0D)
	{
		ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem("Select All");
		ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem("Copy");
		ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem("Cut");
		ToolStripMenuItem toolStripMenuItem4 = new ToolStripMenuItem("Paste");
		toolStripMenuItem.Click += delegate
		{
			D7254A0D.SelectAll();
		};
		toolStripMenuItem2.Click += delegate
		{
			D7254A0D.Copy();
		};
		toolStripMenuItem3.Click += delegate
		{
			D7254A0D.Cut();
		};
		toolStripMenuItem4.Click += delegate
		{
			D7254A0D.Paste();
		};
		contextMenuStrip.Items.Add(toolStripMenuItem);
		contextMenuStrip.Items.Add(toolStripMenuItem2);
		contextMenuStrip.Items.Add(toolStripMenuItem3);
		contextMenuStrip.Items.Add(toolStripMenuItem4);
		D7254A0D.ContextMenuStrip = contextMenuStrip;
	}

	public static Dictionary<string, List<string>> smethod_6(this Dictionary<string, List<string>> B42A7190)
	{
		return B42A7190.ToDictionary((KeyValuePair<string, List<string>> AB870FA3) => AB870FA3.Key, (KeyValuePair<string, List<string>> keyValuePair_0) => new List<string>(keyValuePair_0.Value));
	}

	public static List<string> smethod_7(this RichTextBox richTextBox_0)
	{
		return richTextBox_0.Text.Split(new string[1] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
	}

	public static List<string> AF1855B2(this List<string> E4300E29)
	{
		return E4300E29.Where((string BE8DC9AA) => !string.IsNullOrWhiteSpace(BE8DC9AA)).ToList();
	}
}
