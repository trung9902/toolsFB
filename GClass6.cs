using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class GClass6 : CheckBox
{
	internal Color color_0 = Color.MediumSlateBlue;

	internal Color color_1 = Color.WhiteSmoke;

	internal Color B928199A = Color.Gray;

	internal Color color_2 = Color.Gainsboro;

	internal bool F5BD6897 = true;

	internal IContainer icontainer_0 = null;

	public Color B315C598
	{
		get
		{
			return color_0;
		}
		set
		{
			color_0 = value;
			Invalidate();
		}
	}

	public Color C6B62F24
	{
		get
		{
			return color_1;
		}
		set
		{
			color_1 = value;
			Invalidate();
		}
	}

	public Color Color_0
	{
		get
		{
			return B928199A;
		}
		set
		{
			B928199A = value;
			Invalidate();
		}
	}

	public Color Color_1
	{
		get
		{
			return color_2;
		}
		set
		{
			color_2 = value;
			Invalidate();
		}
	}

	[Browsable(false)]
	public override string Text
	{
		get
		{
			return base.Text;
		}
		set
		{
		}
	}

	[DefaultValue(true)]
	public bool Boolean_0
	{
		get
		{
			return F5BD6897;
		}
		set
		{
			F5BD6897 = value;
			Invalidate();
		}
	}

	public GClass6()
	{
		MinimumSize = new Size(45, 22);
	}

	private GraphicsPath method_0()
	{
		int num = base.Height - 1;
		Rectangle rect = new Rectangle(0, 0, num, num);
		Rectangle rect2 = new Rectangle(base.Width - num - 2, 0, num, num);
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.StartFigure();
		graphicsPath.AddArc(rect, 90f, 180f);
		graphicsPath.AddArc(rect2, 270f, 180f);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	protected override void OnPaint(PaintEventArgs pevent)
	{
		int num = base.Height - 5;
		pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
		pevent.Graphics.Clear(base.Parent.BackColor);
		if (base.Checked)
		{
			if (F5BD6897)
			{
				pevent.Graphics.FillPath(new SolidBrush(color_0), method_0());
			}
			else
			{
				pevent.Graphics.DrawPath(new Pen(color_0, 2f), method_0());
			}
			pevent.Graphics.FillEllipse(new SolidBrush(color_1), new Rectangle(base.Width - base.Height + 1, 2, num, num));
		}
		else
		{
			if (F5BD6897)
			{
				pevent.Graphics.FillPath(new SolidBrush(B928199A), method_0());
			}
			else
			{
				pevent.Graphics.DrawPath(new Pen(B928199A, 2f), method_0());
			}
			pevent.Graphics.FillEllipse(new SolidBrush(color_2), new Rectangle(2, 2, num, num));
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
		icontainer_0 = new System.ComponentModel.Container();
	}
}
