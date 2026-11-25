using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class CCA901B5 : GControl0
{
	internal IContainer icontainer_1 = null;

	internal Panel BA88F129;

	internal Label lbl;

	internal NumericUpDown nud;

	public CCA901B5()
	{
		InitializeComponent();
	}

	public override void vmethod_0(string F502943D)
	{
		base.vmethod_0(F502943D);
		lbl.Text = F502943D.TrimEnd(':') + ":";
	}

	public override void vmethod_2(object A7130ABA)
	{
		base.vmethod_2(A7130ABA);
		try
		{
			nud.Value = Convert.ToInt32(method_2());
		}
		catch (Exception)
		{
		}
	}

	public override void vmethod_3(object FA9A7B07)
	{
		try
		{
			nud.Value = Convert.ToInt32(FA9A7B07);
		}
		catch (Exception)
		{
		}
	}

	public override object vmethod_5()
	{
		return Convert.ToInt32(nud.Value);
	}

	public override string BCBC302C()
	{
		GClass4 gClass = new GClass4();
		gClass.method_4("type", vmethod_6());
		gClass.method_4("name", method_1());
		gClass.method_4("label", D09BB0AA());
		gClass.method_4("defaultValue", method_2());
		gClass.method_4("value", vmethod_5());
		gClass.method_4("description", vmethod_4());
		return gClass.ED11179C();
	}

	public override string vmethod_6()
	{
		return "number";
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		BA88F129 = new System.Windows.Forms.Panel();
		nud = new System.Windows.Forms.NumericUpDown();
		lbl = new System.Windows.Forms.Label();
		BA88F129.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)nud).BeginInit();
		SuspendLayout();
		BA88F129.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		BA88F129.Controls.Add(nud);
		BA88F129.Controls.Add(lbl);
		BA88F129.Location = new System.Drawing.Point(0, 0);
		BA88F129.Margin = new System.Windows.Forms.Padding(4);
		BA88F129.Name = "panel3";
		BA88F129.Size = new System.Drawing.Size(350, 53);
		BA88F129.TabIndex = 31;
		nud.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		nud.Location = new System.Drawing.Point(4, 24);
		nud.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
		nud.Name = "nud";
		nud.Size = new System.Drawing.Size(342, 23);
		nud.TabIndex = 2;
		lbl.AutoSize = true;
		lbl.Location = new System.Drawing.Point(1, 4);
		lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		lbl.Name = "lbl";
		lbl.Size = new System.Drawing.Size(41, 16);
		lbl.TabIndex = 0;
		lbl.Text = "Nha\u0303n:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(BA88F129);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "ucInputNumber";
		base.Size = new System.Drawing.Size(350, 53);
		BA88F129.ResumeLayout(false);
		BA88F129.PerformLayout();
		((System.ComponentModel.ISupportInitialize)nud).EndInit();
		ResumeLayout(false);
	}
}
