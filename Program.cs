using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
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
