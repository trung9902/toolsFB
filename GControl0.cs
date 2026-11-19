using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class GControl0 : UserControl
{
	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string AFAEA08F = "";

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal string AA15739F = "Nha\u0303n";

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal object DD0B7631;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal string string_0 = "";

	internal IContainer icontainer_0 = null;

	private string String_0
	{
		[CompilerGenerated]
		get
		{
			return AFAEA08F;
		}
		[CompilerGenerated]
		set
		{
			AFAEA08F = value;
		}
	}

	private string B29CD701
	{
		[CompilerGenerated]
		get
		{
			return AA15739F;
		}
		[CompilerGenerated]
		set
		{
			AA15739F = value;
		}
	}

	private object Object_0
	{
		[CompilerGenerated]
		get
		{
			return DD0B7631;
		}
		[CompilerGenerated]
		set
		{
			DD0B7631 = value;
		}
	}

	private string String_1
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public GControl0()
	{
		InitializeComponent();
	}

	public virtual void vmethod_0(string F502943D)
	{
		B29CD701 = F502943D;
	}

	public virtual void vmethod_1(string string_1)
	{
		String_0 = string_1;
	}

	public virtual void vmethod_2(object D224C8B7)
	{
		Object_0 = D224C8B7;
	}

	public virtual void vmethod_3(object F3198C08)
	{
	}

	public void method_0(string string_1)
	{
		String_1 = string_1;
	}

	public string D09BB0AA()
	{
		return B29CD701;
	}

	public string method_1()
	{
		return String_0;
	}

	public object method_2()
	{
		if (Object_0 == null)
		{
			return "";
		}
		if (Object_0 is string)
		{
			return (string)Object_0;
		}
		if (Object_0 is bool)
		{
			return (bool)Object_0;
		}
		if (Object_0 is int)
		{
			return (int)Object_0;
		}
		return Object_0;
	}

	public virtual string vmethod_4()
	{
		return String_1;
	}

	public virtual string BCBC302C()
	{
		return "";
	}

	public virtual object vmethod_5()
	{
		return null;
	}

	public virtual string vmethod_6()
	{
		return "";
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
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	}
}
