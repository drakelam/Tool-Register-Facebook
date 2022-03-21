using System;
using System.ComponentModel;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using ToolRegFB.Properties;

namespace ToolRegFB
{
	// Token: 0x02000037 RID: 55
	public partial class frmUpdate : Form
	{
		// Token: 0x060002A0 RID: 672 RVA: 0x00033181 File Offset: 0x00031381
		public frmUpdate()
		{
			this.InitializeComponent();
			this.lblLoading.Text = "<<<   <<<   <<<   <<<   <<<   ";
			this.checkversion();
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x000331B1 File Offset: 0x000313B1
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x000331BB File Offset: 0x000313BB
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.lblLoading.Text = this.lblLoading.Text.Substring(1) + this.lblLoading.Text.Substring(0, 1);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x000331F2 File Offset: 0x000313F2
		private void frmUpdate_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x000331F8 File Offset: 0x000313F8
		private void checkversion()
		{
			bool flag = InternetConnection.IsConnectedToInternet();
			bool flag2 = flag;
			if (flag2)
			{
				WebClient webClient = new WebClient();
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				webClient.DownloadFileCompleted += this.udcom;
				Uri address = new Uri(frmUpdate.hostname + "update.ini");
				webClient.DownloadFileAsync(address, "./update/update.ini");
			}
			else
			{
				MessageBox.Show("No internet connect.Please check your network!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00033278 File Offset: 0x00031478
		private void udcom(object sender, AsyncCompletedEventArgs e)
		{
			try
			{
				IniFile iniFile = new IniFile("./update/update.ini");
				string text = iniFile.Read("Version", "Infor");
				double num = Convert.ToDouble(text.Replace(".", "").Insert(1, "."));
				IniFile iniFile2 = new IniFile("update.ini");
				string text2 = iniFile2.Read("Version", "Infor");
				double num2 = Convert.ToDouble(text2.Replace(".", "").Insert(1, "."));
				bool flag = num > num2;
				bool flag2 = flag;
				if (flag2)
				{
					frmUpdateContent frmUpdateContent = new frmUpdateContent();
					base.Hide();
					frmUpdateContent.Show();
				}
				else
				{
					MessageBox.Show("Bạn đang được sử dụng phiên bản mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					base.Close();
				}
			}
			catch
			{
				MessageBox.Show("Lỗi update!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				base.Close();
			}
		}

		// Token: 0x040002D5 RID: 725
		public static string softname = "ToolRegFB";

		// Token: 0x040002D6 RID: 726
		public static string hostname = "https://rabbitsocialtools.com/public/update/" + frmUpdate.softname + "/";
	}
}
