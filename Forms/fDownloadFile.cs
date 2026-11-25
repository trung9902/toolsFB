using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

public class fDownloadFile : Form
{
	[CompilerGenerated]
	private sealed class D6312C2B
	{
		internal fDownloadFile A2B86C07;

		internal Uri CEA7890D;

		internal string string_0;

		internal void method_0()
		{
			WebClient webClient = new WebClient();
			webClient.DownloadProgressChanged += A2B86C07.method_2;
			webClient.DownloadFileCompleted += A2B86C07.method_3;
			webClient.DownloadFileAsync(CEA7890D, string_0);
		}
	}

	[CompilerGenerated]
	private sealed class Class22
	{
		internal DownloadProgressChangedEventArgs B6A24FB8;

		internal fDownloadFile fDownloadFile_0;

		internal void method_0()
		{
			double num = double.Parse(B6A24FB8.BytesReceived.ToString());
			double num2 = double.Parse(B6A24FB8.TotalBytesToReceive.ToString());
			double d = num / num2 * 100.0;
			fDownloadFile_0.lblproccess.Text = $"Downloading ({int.Parse(Math.Truncate(d).ToString())}%)...";
			fDownloadFile_0.progressBar1.Value = int.Parse(Math.Truncate(d).ToString());
		}
	}

	internal string string_0 = "";

	internal string EAB70110 = "";

	internal IContainer icontainer_0 = null;

	internal Label lblproccess;

	internal ProgressBar progressBar1;

	public fDownloadFile(string string_1)
	{
		InitializeComponent();
		string_0 = string_1;
		EAB70110 = Path.GetFileName(string_0);
	}

	private void fDownloadFile_Load(object sender, EventArgs e)
	{
		try
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			if (InternetConnection.smethod_0())
			{
				Uri f2ACED = new Uri(string_0);
				Commom.DeleteFolder("download");
				Commom.CreateFolder("download");
				method_1(f2ACED, "download\\" + EAB70110);
			}
			else
			{
				MsBoxHelper.Show("Không co\u0301 kê\u0301t nô\u0301i Internet, vui lo\u0300ng kiê\u0309m tra la\u0323i!");
				Close();
			}
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show("Error: " + ex.Message, 2);
			Close();
		}
	}

	public void method_0(string E8991E84, string string_1)
	{
		DirectoryInfo directoryInfo_ = new DirectoryInfo(E8991E84);
		DirectoryInfo directoryInfo_2 = new DirectoryInfo(string_1);
		FD37C6A9(directoryInfo_, directoryInfo_2);
	}

	public void FD37C6A9(DirectoryInfo directoryInfo_0, DirectoryInfo directoryInfo_1)
	{
		Directory.CreateDirectory(directoryInfo_1.FullName);
		int num = 1;
		FileInfo[] files = directoryInfo_0.GetFiles();
		foreach (FileInfo fileInfo in files)
		{
			Application.DoEvents();
			fileInfo.CopyTo(Path.Combine(directoryInfo_1.FullName, fileInfo.Name), overwrite: true);
			num++;
		}
		DirectoryInfo[] directories = directoryInfo_0.GetDirectories();
		foreach (DirectoryInfo directoryInfo in directories)
		{
			DirectoryInfo directoryInfo_2 = directoryInfo_1.CreateSubdirectory(directoryInfo.Name);
			FD37C6A9(directoryInfo, directoryInfo_2);
		}
	}

	private void method_1(Uri F2ACED81, string ACB18983)
	{
		Thread thread = new Thread((ThreadStart)delegate
		{
			WebClient webClient = new WebClient();
			webClient.DownloadProgressChanged += method_2;
			webClient.DownloadFileCompleted += method_3;
			webClient.DownloadFileAsync(F2ACED81, ACB18983);
		});
		thread.IsBackground = true;
		thread.Start();
	}

	private void method_2(object sender, DownloadProgressChangedEventArgs e)
	{
		BeginInvoke((MethodInvoker)delegate
		{
			double num = double.Parse(e.BytesReceived.ToString());
			double num2 = double.Parse(e.TotalBytesToReceive.ToString());
			double d = num / num2 * 100.0;
			lblproccess.Text = $"Downloading ({int.Parse(Math.Truncate(d).ToString())}%)...";
			progressBar1.Value = int.Parse(Math.Truncate(d).ToString());
		});
	}

	private void method_3(object sender, AsyncCompletedEventArgs e)
	{
		lblproccess.smethod_2("Unzip file...");
		try
		{
			ZipFile.ExtractToDirectory("./download/" + EAB70110, "./download/");
			Commom.E10A40B6("./download/" + EAB70110);
			string[] foundDrivers = Directory.GetFiles("./download", "chromedriver.exe", SearchOption.AllDirectories);
			if (foundDrivers.Length > 0)
			{
				File.Copy(foundDrivers[0], "./chromedriver.exe", true);
			}
			else if (File.Exists("download\\driver\\win32\\chromedriver.exe"))
			{
				method_0("download\\driver\\win32", "./");
			}
			else
			{
				method_0("download", "./");
			}
			Commom.DeleteFolder("download");
			BeginInvoke((MethodInvoker)delegate
			{
				Close();
			});
		}
		catch (Exception ex)
		{
			MsBoxHelper.Show("Error: " + ex.Message, 2);
			BeginInvoke((MethodInvoker)delegate
			{
				Close();
			});
		}
	}

	protected override void Dispose(bool D9BE6F08)
	{
		if (D9BE6F08 && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(D9BE6F08);
	}

	private void InitializeComponent()
	{
		lblproccess = new System.Windows.Forms.Label();
		progressBar1 = new System.Windows.Forms.ProgressBar();
		SuspendLayout();
		lblproccess.AutoSize = true;
		lblproccess.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		lblproccess.Location = new System.Drawing.Point(34, 22);
		lblproccess.Name = "lblproccess";
		lblproccess.Size = new System.Drawing.Size(125, 16);
		lblproccess.TabIndex = 1;
		lblproccess.Text = "Downloading (0%)...";
		progressBar1.Location = new System.Drawing.Point(37, 52);
		progressBar1.Name = "progressBar1";
		progressBar1.Size = new System.Drawing.Size(219, 23);
		progressBar1.TabIndex = 2;
		base.AutoScaleDimensions = new System.Drawing.SizeF(7f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
		BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
		base.ClientSize = new System.Drawing.Size(294, 104);
		base.Controls.Add(progressBar1);
		base.Controls.Add(lblproccess);
		Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
		base.Name = "fDownloadFile";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		Text = "frm_progress";
		base.Load += new System.EventHandler(fDownloadFile_Load);
		ResumeLayout(false);
		PerformLayout();
	}

	[CompilerGenerated]
	private void method_4()
	{
		Close();
	}

	[CompilerGenerated]
	private void BA98F40C()
	{
		Close();
	}
}
