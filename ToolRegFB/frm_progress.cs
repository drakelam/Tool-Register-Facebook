using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace ToolRegFB
{
	// Token: 0x02000042 RID: 66
	public partial class frm_progress : Form
	{
		// Token: 0x060002D9 RID: 729 RVA: 0x000365ED File Offset: 0x000347ED
		public frm_progress()
		{
			this.InitializeComponent();
			this.lblLoading.Text = "<<<   <<<   <<<   <<<   <<<   ";
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00036616 File Offset: 0x00034816
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.lblLoading.Text = this.lblLoading.Text.Substring(1) + this.lblLoading.Text.Substring(0, 1);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00036650 File Offset: 0x00034850
		private void frm_progress_Load(object sender, EventArgs e)
		{
			try
			{
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				string hostname = frmUpdate.hostname;
				bool flag = InternetConnection.IsConnectedToInternet();
				bool flag2 = flag;
				if (flag2)
				{
					WebClient webClient = new WebClient();
					webClient.DownloadFileCompleted += this.udcom_file;
					Uri address = new Uri(hostname + frmUpdate.softname + ".zip");
					webClient.DownloadFileAsync(address, "./update/" + frmUpdate.softname + ".zip");
				}
				else
				{
					MessageBox.Show("No internet connect.Please check your network!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					Application.Exit();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
			}
		}

		// Token: 0x060002DC RID: 732 RVA: 0x0003672C File Offset: 0x0003492C
		public void Copy(string sourceDirectory, string targetDirectory)
		{
			DirectoryInfo source = new DirectoryInfo(sourceDirectory);
			DirectoryInfo target = new DirectoryInfo(targetDirectory);
			this.CopyAll(source, target);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x00036754 File Offset: 0x00034954
		public void CopyAll(DirectoryInfo source, DirectoryInfo target)
		{
			Directory.CreateDirectory(target.FullName);
			int num = 1;
			foreach (FileInfo fileInfo in source.GetFiles())
			{
				Application.DoEvents();
				fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name), true);
				num++;
			}
			foreach (DirectoryInfo directoryInfo in source.GetDirectories())
			{
				DirectoryInfo target2 = target.CreateSubdirectory(directoryInfo.Name);
				this.CopyAll(directoryInfo, target2);
			}
		}

		// Token: 0x060002DE RID: 734 RVA: 0x000367F0 File Offset: 0x000349F0
		private void udcom_file(object sender, AsyncCompletedEventArgs e)
		{
			try
			{
				bool flag = Directory.Exists("./update/" + frmUpdate.softname);
				bool flag2 = flag;
				if (flag2)
				{
					Directory.Delete("./update/" + frmUpdate.softname, true);
				}
				ZipFile.ExtractToDirectory("./update/" + frmUpdate.softname + ".zip", "./update/");
				try
				{
					string sourceDirectory = "./update/" + frmUpdate.softname + "/";
					string startupPath = Application.StartupPath;
					this.Copy(sourceDirectory, startupPath);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Update fail:" + ex.Message);
					return;
				}
				bool flag3 = File.Exists("./update/" + frmUpdate.softname + ".zip");
				bool flag4 = flag3;
				if (flag4)
				{
					File.Delete("./update/" + frmUpdate.softname + ".zip");
				}
				bool flag5 = Directory.Exists("./update/" + frmUpdate.softname);
				bool flag6 = flag5;
				if (flag6)
				{
					Directory.Delete("./update/" + frmUpdate.softname, true);
				}
				this.timer1.Stop();
			}
			catch (Exception ex2)
			{
				MessageBox.Show("Error: " + ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				base.Close();
			}
			finally
			{
				base.Close();
			}
		}
	}
}
