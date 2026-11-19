using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

public class fShowProgressBar : Form
{
	[CompilerGenerated]
	private sealed class EF2E201F
	{
		internal int int_0;

		internal int CF208E05;

		internal fShowProgressBar E6BF0DAF;

		internal void method_0()
		{
			E6BF0DAF.lblproccess.Text = string.Format(Language.GetValue("Đang copy, vui lo\u0300ng chơ\u0300 ({0}/{1})..."), int_0, CF208E05);
		}
	}

	[CompilerGenerated]
	private sealed class EF094C23
	{
		internal double F7A0D417;

		internal EF2E201F E637C03F;

		internal void method_0()
		{
			E637C03F.E6BF0DAF.lblproccess.Text = string.Format(Language.GetValue("Đang copy, vui lo\u0300ng chơ\u0300 ({0}/{1})..."), E637C03F.int_0, E637C03F.CF208E05);
			E637C03F.E6BF0DAF.F505BA2B.Value = int.Parse(Math.Truncate(F7A0D417).ToString());
		}
	}

	internal List<string> list_0 = new List<string>();

	internal IContainer icontainer_0 = null;

	internal Label lblproccess;

	internal ProgressBar F505BA2B;

	public fShowProgressBar(List<string> list_1)
	{
		InitializeComponent();
		Language.CD21F0A9(this);
		list_0 = list_1;
	}

	private void AF9175A6(object sender, EventArgs e)
	{
		try
		{
			new Thread((ThreadStart)delegate
			{
				string text = "";
				string text2 = "";
				int int_0 = 0;
				int CF208E5 = list_0.Count;
				BeginInvoke((MethodInvoker)delegate
				{
					lblproccess.Text = string.Format(Language.GetValue("Đang copy, vui lo\u0300ng chơ\u0300 ({0}/{1})..."), int_0, CF208E5);
				});
				for (int i = 0; i < list_0.Count; i++)
				{
					text = list_0[i].Split('|')[0];
					text2 = list_0[i].Split('|')[1];
					if (Commom.EA87BD03(text, text2, bool_0: true))
					{
						int num = int_0;
						int_0 = num + 1;
					}
					double F7A0D417 = (double)int_0 * 1.0 / (double)CF208E5 * 100.0;
					BeginInvoke((MethodInvoker)delegate
					{
						lblproccess.Text = string.Format(Language.GetValue("Đang copy, vui lo\u0300ng chơ\u0300 ({0}/{1})..."), int_0, CF208E5);
						F505BA2B.Value = int.Parse(Math.Truncate(F7A0D417).ToString());
					});
				}
				BeginInvoke((MethodInvoker)delegate
				{
					Close();
				});
			}).Start();
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show("Error: " + ex.Message, 2);
			Close();
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		lblproccess = new System.Windows.Forms.Label();
		F505BA2B = new System.Windows.Forms.ProgressBar();
		SuspendLayout();
		lblproccess.AutoSize = true;
		lblproccess.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblproccess.Location = new System.Drawing.Point(34, 22);
		lblproccess.Name = "lblproccess";
		lblproccess.Size = new System.Drawing.Size(189, 16);
		lblproccess.TabIndex = 1;
		lblproccess.Text = "Đang copy, vui lo\u0300ng chơ\u0300 (0/0)...";
		F505BA2B.Location = new System.Drawing.Point(37, 52);
		F505BA2B.Name = "progressBar1";
		F505BA2B.Size = new System.Drawing.Size(219, 23);
		F505BA2B.TabIndex = 2;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		base.ClientSize = new System.Drawing.Size(294, 104);
		base.Controls.Add(F505BA2B);
		base.Controls.Add(lblproccess);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fShowProgressBar";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "frm_progress";
		base.Load += new System.EventHandler(AF9175A6);
		ResumeLayout(false);
		PerformLayout();
	}

	[CompilerGenerated]
	private void method_0()
	{
		string text = "";
		string text2 = "";
		int int_0 = 0;
		int CF208E5 = list_0.Count;
		BeginInvoke((MethodInvoker)delegate
		{
			lblproccess.Text = string.Format(Language.GetValue("Đang copy, vui lo\u0300ng chơ\u0300 ({0}/{1})..."), int_0, CF208E5);
		});
		for (int i = 0; i < list_0.Count; i++)
		{
			text = list_0[i].Split('|')[0];
			text2 = list_0[i].Split('|')[1];
			if (Commom.EA87BD03(text, text2, bool_0: true))
			{
				int num = int_0;
				int_0 = num + 1;
			}
			double F7A0D417 = (double)int_0 * 1.0 / (double)CF208E5 * 100.0;
			BeginInvoke((MethodInvoker)delegate
			{
				lblproccess.Text = string.Format(Language.GetValue("Đang copy, vui lo\u0300ng chơ\u0300 ({0}/{1})..."), int_0, CF208E5);
				F505BA2B.Value = int.Parse(Math.Truncate(F7A0D417).ToString());
			});
		}
		BeginInvoke((MethodInvoker)delegate
		{
			Close();
		});
	}

	[CompilerGenerated]
	private void method_1()
	{
		Close();
	}
}
