using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class DCA0BA83 : GControl0
{
	internal IContainer icontainer_1 = null;

	internal Panel DB21A909;

	internal Label lbl;

	internal CheckBox B5221222;

	public DCA0BA83()
	{
		InitializeComponent();
	}

	public override void vmethod_0(string F502943D)
	{
		base.vmethod_0(F502943D);
		F502943D = F502943D.TrimEnd(':');
		lbl.Text = (F502943D.EndsWith("?") ? F502943D : (F502943D + ":"));
	}

	public override void vmethod_2(object A0918F86)
	{
		base.vmethod_2(A0918F86);
		try
		{
			B5221222.Checked = Convert.ToBoolean(A0918F86);
		}
		catch (Exception)
		{
		}
	}

	public override void vmethod_3(object C72386A5)
	{
		try
		{
			B5221222.Checked = Convert.ToBoolean(C72386A5);
		}
		catch (Exception)
		{
		}
	}

	public override object vmethod_5()
	{
		return B5221222.Checked;
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
		return "checkbox";
	}

	private void DCA0BA83_Load(object sender, EventArgs e)
	{
	}

	protected override void Dispose(bool F805D230)
	{
		if (F805D230 && icontainer_1 != null)
		{
			icontainer_1.Dispose();
		}
		base.Dispose(F805D230);
	}

	private void InitializeComponent()
	{
		DB21A909 = new System.Windows.Forms.Panel();
		B5221222 = new System.Windows.Forms.CheckBox();
		lbl = new System.Windows.Forms.Label();
		DB21A909.SuspendLayout();
		SuspendLayout();
		DB21A909.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		DB21A909.Controls.Add(B5221222);
		DB21A909.Controls.Add(lbl);
		DB21A909.Location = new System.Drawing.Point(0, 0);
		DB21A909.Margin = new System.Windows.Forms.Padding(4);
		DB21A909.Name = "panel3";
		DB21A909.Size = new System.Drawing.Size(350, 47);
		DB21A909.TabIndex = 31;
		B5221222.AutoSize = true;
		B5221222.Cursor = System.Windows.Forms.Cursors.Hand;
		B5221222.Location = new System.Drawing.Point(4, 24);
		B5221222.Name = "ckb";
		B5221222.Size = new System.Drawing.Size(15, 14);
		B5221222.TabIndex = 1;
		B5221222.UseVisualStyleBackColor = true;
		lbl.AutoSize = true;
		lbl.Location = new System.Drawing.Point(1, 4);
		lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		lbl.Name = "lbl";
		lbl.Size = new System.Drawing.Size(41, 16);
		lbl.TabIndex = 0;
		lbl.Text = "Nha\u0303n:";
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(DB21A909);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "ucInputCheckbox";
		base.Size = new System.Drawing.Size(350, 47);
		base.Load += new System.EventHandler(DCA0BA83_Load);
		DB21A909.ResumeLayout(false);
		DB21A909.PerformLayout();
		ResumeLayout(false);
	}
}
