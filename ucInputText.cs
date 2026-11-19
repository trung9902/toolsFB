using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ucInputText : GControl0
{
	internal IContainer icontainer_1 = null;

	internal Panel panel3;

	internal Label E015823E;

	internal TextBox txt;

	public ucInputText()
	{
		InitializeComponent();
	}

	public override void vmethod_0(string F502943D)
	{
		base.vmethod_0(F502943D);
		E015823E.Text = F502943D.TrimEnd(':') + ":";
	}

	public override void vmethod_2(object A7130ABA)
	{
		base.vmethod_2(A7130ABA);
		txt.Text = Convert.ToString(A7130ABA);
	}

	public override void vmethod_3(object B5AE691F)
	{
		txt.Text = Convert.ToString(B5AE691F);
	}

	public override object vmethod_5()
	{
		return txt.Text;
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
		return "string";
	}

	private void ucInputText_Load(object sender, EventArgs e)
	{
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
		panel3 = new System.Windows.Forms.Panel();
		E015823E = new System.Windows.Forms.Label();
		txt = new System.Windows.Forms.TextBox();
		panel3.SuspendLayout();
		SuspendLayout();
		panel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		panel3.Controls.Add(E015823E);
		panel3.Controls.Add(txt);
		panel3.Location = new System.Drawing.Point(0, 0);
		panel3.Margin = new System.Windows.Forms.Padding(4);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(350, 53);
		panel3.TabIndex = 31;
		E015823E.AutoSize = true;
		E015823E.Location = new System.Drawing.Point(1, 4);
		E015823E.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		E015823E.Name = "lbl";
		E015823E.Size = new System.Drawing.Size(41, 16);
		E015823E.TabIndex = 0;
		E015823E.Text = "Nha\u0303n:";
		txt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txt.Location = new System.Drawing.Point(4, 24);
		txt.Margin = new System.Windows.Forms.Padding(4);
		txt.Name = "txt";
		txt.Size = new System.Drawing.Size(342, 23);
		txt.TabIndex = 2;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(panel3);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "ucInputText";
		base.Size = new System.Drawing.Size(350, 53);
		base.Load += new System.EventHandler(ucInputText_Load);
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		ResumeLayout(false);
	}
}
