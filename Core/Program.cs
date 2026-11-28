using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using LushCare.Benchmark;

internal static class Program
{
	[DllImport("kernel32.dll")]
	private static extern bool AttachConsole(int dwProcessId);

	[DllImport("kernel32.dll")]
	private static extern bool AllocConsole();

	[STAThread]
	private static void Main(string[] args)
	{
		Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

		if (args != null && args.Length > 0 && args.Any(a => a.Equals("--benchmark", StringComparison.OrdinalIgnoreCase)))
		{
			if (!AttachConsole(-1))
			{
				AllocConsole();
			}
			try { Console.OutputEncoding = Encoding.UTF8; } catch { }
			BenchmarkRunner.Run(args);
			return;
		}
		AppDomain.CurrentDomain.UnhandledException += (s, e) => {
			File.AppendAllText("startup_log.txt", "UnhandledException: " + e.ExceptionObject + "\r\n");
		};
		Application.ThreadException += (s, e) => {
			File.AppendAllText("startup_log.txt", "ThreadException: " + e.Exception + "\r\n");
		};
		File.AppendAllText("startup_log.txt", "Main started at " + DateTime.Now + "\r\n");

		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(defaultValue: false);
		try
		{
			ModernUITheme.Init();
		}
		catch { }
		try
		{
			File.AppendAllText("startup_log.txt", "Calling SetupFolder.CreateBasicFolder...\r\n");
			SetupFolder.CreateBasicFolder();
			File.AppendAllText("startup_log.txt", "Calling Application.Run(fIntro)...\r\n");
			Application.Run(new fIntro());
			File.AppendAllText("startup_log.txt", "Application.Run exited cleanly.\r\n");
		}
		catch (Exception exception_)
		{
			File.AppendAllText("startup_log.txt", "Catch block: " + exception_.ToString() + "\r\n");
			File.WriteAllText("error.txt", exception_.ToString());
			MsBoxHelper.Show(exception_.ToString(), 2);
			Environment.Exit(0);
		}
	}
}
