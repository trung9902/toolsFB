using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace lushcare.Properties
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.13.0.0")]
	[CompilerGenerated]
	internal sealed class Settings : ApplicationSettingsBase
	{
		internal static Settings settings_0 = (Settings)SettingsBase.Synchronized(new Settings());

		public static Settings Default => settings_0;

		[DebuggerNonUserCode]
		[UserScopedSetting]
		[DefaultSettingValue("")]
		public string UserName
		{
			get
			{
				return (string)this["UserName"];
			}
			set
			{
				this["UserName"] = value;
			}
		}

		[DefaultSettingValue("")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string PassWord
		{
			get
			{
				return (string)this["PassWord"];
			}
			set
			{
				this["PassWord"] = value;
			}
		}

		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		[UserScopedSetting]
		public string PathChrome
		{
			get
			{
				return (string)this["PathChrome"];
			}
			set
			{
				this["PathChrome"] = value;
			}
		}
	}
}
