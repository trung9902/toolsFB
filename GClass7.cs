using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class GClass7 : Button
{
	internal int FF349C3E = 30;

	public GClass7()
	{
		BackColor = Color.OrangeRed;
		base.FlatStyle = FlatStyle.Flat;
		base.FlatAppearance.BorderColor = Color.Black;
		base.FlatAppearance.BorderSize = 1;
		base.Width = 140;
		base.Height = 45;
	}

	private GraphicsPath method_0(RectangleF FBB2918B, int CE9A642C)
	{
		float num = (float)CE9A642C / 2f;
		GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddArc(FBB2918B.X, FBB2918B.Y, CE9A642C, CE9A642C, 180f, 90f);
		graphicsPath.AddLine(FBB2918B.X + num, FBB2918B.Y, FBB2918B.Width - num, FBB2918B.Y);
		graphicsPath.AddArc(FBB2918B.X + FBB2918B.Width - (float)CE9A642C, FBB2918B.Y, CE9A642C, CE9A642C, 270f, 90f);
		graphicsPath.AddLine(FBB2918B.Width, FBB2918B.Y + num, FBB2918B.Width, FBB2918B.Height - num);
		graphicsPath.AddArc(FBB2918B.X + FBB2918B.Width - (float)CE9A642C, FBB2918B.Y + FBB2918B.Height - (float)CE9A642C, CE9A642C, CE9A642C, 0f, 90f);
		graphicsPath.AddLine(FBB2918B.Width - num, FBB2918B.Height, FBB2918B.X + num, FBB2918B.Height);
		graphicsPath.AddArc(FBB2918B.X, FBB2918B.Y + FBB2918B.Height - (float)CE9A642C, CE9A642C, CE9A642C, 90f, 90f);
		graphicsPath.AddLine(FBB2918B.X, FBB2918B.Height - num, FBB2918B.X, FBB2918B.Y + num);
		graphicsPath.CloseFigure();
		return graphicsPath;
	}

	protected override void OnPaint(PaintEventArgs pevent)
	{
		base.OnPaint(pevent);
		RectangleF fBB2918B = new RectangleF(0f, 0f, base.Width, base.Height);
		using GraphicsPath path = method_0(fBB2918B, FF349C3E);
		base.Region = new Region(path);
		using Pen pen = new Pen(Color.CadetBlue, 1.75f);
		pen.Alignment = PenAlignment.Inset;
		pevent.Graphics.DrawPath(pen, path);
	}
}
