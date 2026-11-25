using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class ucInputJson : GControl0
{
	internal IContainer icontainer_1 = null;

	internal Panel EEB769A7;

	internal Label lbl;

	internal RichTextBox txt;

	public ucInputJson()
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
		txt.Text = Convert.ToString(A7130ABA);
	}

	public override void vmethod_3(object C72386A5)
	{
		txt.Text = Convert.ToString(C72386A5);
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
		return "json";
	}

	protected override void Dispose(bool FBB300AC)
	{
		if (FBB300AC && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(FBB300AC);
	}

	private void InitializeComponent()
	{
		EEB769A7 = new System.Windows.Forms.Panel();
		txt = new System.Windows.Forms.RichTextBox();
		lbl = new System.Windows.Forms.Label();
		EEB769A7.SuspendLayout();
		SuspendLayout();
		EEB769A7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		EEB769A7.Controls.Add(txt);
		EEB769A7.Controls.Add(lbl);
		EEB769A7.Location = new System.Drawing.Point(0, 0);
		EEB769A7.Margin = new System.Windows.Forms.Padding(4);
		EEB769A7.Name = "panel3";
		EEB769A7.Size = new System.Drawing.Size(350, 163);
		EEB769A7.TabIndex = 31;
		txt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		txt.Location = new System.Drawing.Point(4, 23);
		txt.Name = "txt";
		txt.Size = new System.Drawing.Size(343, 137);
		txt.TabIndex = 32;
		txt.Text = "";
		lbl.AutoSize = true;
		lbl.Location = new System.Drawing.Point(1, 4);
		lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		lbl.Name = "lbl";
		lbl.Size = new System.Drawing.Size(41, 16);
		lbl.TabIndex = 0;
		lbl.Text = "Nha\u0303n:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(EEB769A7);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "ucInputJson";
		base.Size = new System.Drawing.Size(350, 163);
		EEB769A7.ResumeLayout(false);
		EEB769A7.PerformLayout();
		ResumeLayout(false);
	}
}
