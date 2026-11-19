using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

public class GClass1
{
	private struct Struct0
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		internal bool C302CDBB;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal string string_0;

		public bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return C302CDBB;
			}
			[CompilerGenerated]
			set
			{
				C302CDBB = value;
			}
		}

		public string String_0
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
	}

	private static class F515FCA4
	{
		internal const string FA9B31BD = "Folders|\n";

		internal const BindingFlags bindingFlags_0 = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		internal static readonly Assembly assembly_0 = typeof(FileDialog).Assembly;

		internal static readonly Type type_0 = assembly_0.GetType("System.Windows.Forms.FileDialogNative+IFileDialog");

		internal static readonly MethodInfo methodInfo_0 = typeof(OpenFileDialog).GetMethod("CreateVistaDialog", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		internal static readonly MethodInfo E1023002 = typeof(OpenFileDialog).GetMethod("OnBeforeVistaDialog", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		internal static readonly MethodInfo B23CBD87 = typeof(FileDialog).GetMethod("GetOptions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		internal static readonly MethodInfo C7182E21 = type_0.GetMethod("SetOptions", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

		internal static readonly uint uint_0 = (uint)assembly_0.GetType("System.Windows.Forms.FileDialogNative+FOS").GetField("FOS_PICKFOLDERS").GetValue(null);

		internal static readonly ConstructorInfo constructorInfo_0 = assembly_0.GetType("System.Windows.Forms.FileDialog+VistaDialogEvents").GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[1] { typeof(FileDialog) }, null);

		internal static readonly MethodInfo methodInfo_1 = type_0.GetMethod("Advise");

		internal static readonly MethodInfo C21160A7 = type_0.GetMethod("Unadvise");

		internal static readonly MethodInfo methodInfo_2 = type_0.GetMethod("Show");

		public static Struct0 EF1BC68A(IntPtr intptr_0, string string_0, string C583B723)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				AddExtension = false,
				CheckFileExists = false,
				DereferenceLinks = true,
				Filter = "Folders|\n",
				InitialDirectory = string_0,
				Multiselect = false,
				Title = C583B723
			};
			object obj = methodInfo_0.Invoke(openFileDialog, new object[0]);
			E1023002.Invoke(openFileDialog, new object[1] { obj });
			C7182E21.Invoke(obj, new object[1] { (uint)B23CBD87.Invoke(openFileDialog, new object[0]) | uint_0 });
			object[] array = new object[2]
			{
				constructorInfo_0.Invoke(new object[1] { openFileDialog }),
				0u
			};
			methodInfo_1.Invoke(obj, array);
			try
			{
				int num = (int)methodInfo_2.Invoke(obj, new object[1] { intptr_0 });
				Struct0 result = default(Struct0);
				result.Boolean_0 = num == 0;
				result.String_0 = openFileDialog.FileName;
				return result;
			}
			finally
			{
				C21160A7.Invoke(obj, new object[1] { array[1] });
			}
		}
	}

	private class A305718A : IWin32Window
	{
		internal readonly IntPtr intptr_0;

		public IntPtr Handle => intptr_0;

		public A305718A(IntPtr intptr_1)
		{
			intptr_0 = intptr_1;
		}
	}

	internal string FEB8D839;

	internal string B8AB3311;

	internal string string_0 = "";

	public string EE1FD628
	{
		get
		{
			return string.IsNullOrEmpty(FEB8D839) ? Environment.CurrentDirectory : FEB8D839;
		}
		set
		{
			FEB8D839 = value;
		}
	}

	public string String_0
	{
		get
		{
			return B8AB3311 ?? "Select a folder";
		}
		set
		{
			B8AB3311 = value;
		}
	}

	public string BB0F8217 => string_0;

	public bool method_0()
	{
		return method_1(IntPtr.Zero);
	}

	public bool method_1(IntPtr EEACBB1A)
	{
		Struct0 @struct = ((Environment.OSVersion.Version.Major >= 6) ? F515FCA4.EF1BC68A(EEACBB1A, EE1FD628, String_0) : smethod_0(EEACBB1A, EE1FD628, String_0));
		string_0 = @struct.String_0;
		return @struct.Boolean_0;
	}

	private static Struct0 smethod_0(IntPtr intptr_0, string string_1, string string_2)
	{
		FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
		{
			Description = string_2,
			SelectedPath = string_1,
			ShowNewFolderButton = false
		};
		Struct0 result = default(Struct0);
		if (folderBrowserDialog.ShowDialog(new A305718A(intptr_0)) == DialogResult.OK)
		{
			result.Boolean_0 = true;
			result.String_0 = folderBrowserDialog.SelectedPath;
		}
		return result;
	}
}
