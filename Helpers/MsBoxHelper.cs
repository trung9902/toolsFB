using System.Windows.Forms;

public class MsBoxHelper
{
	public static void Show(object object_0, int int_0 = 1)
	{
		MessageBoxIcon icon = MessageBoxIcon.None;
		switch (int_0)
		{
		case 1:
			icon = MessageBoxIcon.Asterisk;
			break;
		case 2:
			icon = MessageBoxIcon.Hand;
			break;
		case 3:
			icon = MessageBoxIcon.Exclamation;
			break;
		case 4:
			icon = MessageBoxIcon.Exclamation;
			break;
		}
		MessageBox.Show(Language.GetValue(object_0.ToString()), "LushCare - NVD Software", MessageBoxButtons.OK, icon);
	}

	public static DialogResult D41C45AC(string string_0)
	{
		return MessageBox.Show(Language.GetValue(string_0), "LushCare - NVD Software", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
	}
}
