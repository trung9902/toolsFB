using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public static class GClass11
{
	internal static Dictionary<Control, bool> C98BE2A7 = new Dictionary<Control, bool>();

	internal static Size FC1CE43B;

	public static void smethod_0(this Control control_0, bool F6165FA8)
	{
		if (F6165FA8)
		{
			if (!C98BE2A7.ContainsKey(control_0))
			{
				C98BE2A7.Add(control_0, value: false);
				control_0.MouseDown += EE1F5D1B;
				control_0.MouseMove += smethod_1;
			}
		}
		else if (C98BE2A7.ContainsKey(control_0))
		{
			control_0.MouseDown -= EE1F5D1B;
			control_0.MouseMove -= smethod_1;
			C98BE2A7.Remove(control_0);
		}
	}

	private static void EE1F5D1B(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left)
		{
			FC1CE43B = new Size(e.Location);
			C98BE2A7[(Control)sender] = true;
			(sender as Control).BringToFront();
		}
	}

	private static void smethod_1(object sender, MouseEventArgs e)
	{
		if (e.Button == MouseButtons.Left && C98BE2A7[(Control)sender])
		{
			Point point = e.Location - FC1CE43B;
			((Control)sender).Left += point.X;
			((Control)sender).Top += point.Y;
		}
	}
}
