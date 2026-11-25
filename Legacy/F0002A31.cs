using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class F0002A31 : GControl0
{
	internal IContainer B89C4E85 = null;

	internal Panel panel3;

	internal Label lbl;

	internal TextBox txt;

	internal Button A4BD2FBA;

	public F0002A31()
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

	public override void vmethod_3(object E80269BE)
	{
		txt.Text = Convert.ToString(E80269BE);
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
		return "filepath";
	}

	private void F0002A31_Load(object sender, EventArgs e)
	{
	}

	private void A4BD2FBA_Click(object sender, EventArgs e)
	{
		string value = Commom.smethod_97("Select file", "Custom Files (*.txt,*.xlsx)|*.txt;*.xlsx|");
		if (!string.IsNullOrEmpty(value))
		{
			txt.Text = value;
		}
	}

	protected override void Dispose(bool EBA15F1E)
	{
		if (EBA15F1E && B89C4E85 != null)
		{
			B89C4E85.Dispose();
		}
		base.Dispose(EBA15F1E);
	}

	private void InitializeComponent()
	{
		panel3 = new System.Windows.Forms.Panel();
		lbl = new System.Windows.Forms.Label();
		txt = new System.Windows.Forms.TextBox();
		A4BD2FBA = new System.Windows.Forms.Button();
		panel3.SuspendLayout();
		SuspendLayout();
		panel3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		panel3.Controls.Add(A4BD2FBA);
		panel3.Controls.Add(lbl);
		panel3.Controls.Add(txt);
		panel3.Location = new System.Drawing.Point(0, 0);
		panel3.Margin = new System.Windows.Forms.Padding(4);
		panel3.Name = "panel3";
		panel3.Size = new System.Drawing.Size(350, 53);
		panel3.TabIndex = 31;
		lbl.AutoSize = true;
		lbl.Location = new System.Drawing.Point(1, 4);
		lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
		lbl.Name = "lbl";
		lbl.Size = new System.Drawing.Size(41, 16);
		lbl.TabIndex = 0;
		lbl.Text = "Nha\u0303n:";
		txt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		txt.Location = new System.Drawing.Point(4, 24);
		txt.Margin = new System.Windows.Forms.Padding(4);
		txt.Name = "txt";
		txt.Size = new System.Drawing.Size(305, 23);
		txt.TabIndex = 2;
		A4BD2FBA.Cursor = System.Windows.Forms.Cursors.Hand;
		A4BD2FBA.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		A4BD2FBA.Location = new System.Drawing.Point(316, 23);
		A4BD2FBA.Name = "button1";
		A4BD2FBA.Size = new System.Drawing.Size(29, 25);
		A4BD2FBA.TabIndex = 3;
		A4BD2FBA.Text = "...";
		A4BD2FBA.UseVisualStyleBackColor = true;
		A4BD2FBA.Click += new System.EventHandler(A4BD2FBA_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.Controls.Add(panel3);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.Margin = new System.Windows.Forms.Padding(4);
		base.Name = "ucInputFilePath";
		base.Size = new System.Drawing.Size(350, 53);
		base.Load += new System.EventHandler(F0002A31_Load);
		panel3.ResumeLayout(false);
		panel3.PerformLayout();
		ResumeLayout(false);
	}
}
