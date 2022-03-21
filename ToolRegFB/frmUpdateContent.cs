using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using ToolRegFB.Properties;
using WindowsFormsControlLibrary1;

namespace ToolRegFB
{
	// Token: 0x02000038 RID: 56
	public partial class frmUpdateContent : Form
	{
		// Token: 0x060002A9 RID: 681
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x060002AA RID: 682
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x060002AB RID: 683 RVA: 0x000338BF File Offset: 0x00031ABF
		public frmUpdateContent()
		{
			this.InitializeComponent();
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000338FB File Offset: 0x00031AFB
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00033908 File Offset: 0x00031B08
		public static string Base64Decode(string base64EncodedData)
		{
			byte[] bytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(bytes);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0003392C File Offset: 0x00031B2C
		private void bunifuCards1_MouseMove(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00033930 File Offset: 0x00031B30
		private void frmUpdateContent_Load(object sender, EventArgs e)
		{
			this.ini_server = new IniFile("./update/update.ini");
			this.new_version = this.ini_server.Read("Version", "Infor");
			this.lblNew.Text = this.new_version;
			this.ini_local = new IniFile("update.ini");
			this.old_version = this.ini_local.Read("Version", "Infor");
			this.lblCurrent.Text = this.old_version;
			try
			{
				string text = this.ini_server.Read("Content", "Infor");
				text = frmUpdateContent.Base64Decode(text);
				this.txtContentUpdate.Text = text.Replace("\n", "\r\n");
			}
			catch
			{
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00033A0C File Offset: 0x00031C0C
		private void btnUpdateVersion_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = MessageBox.Show("Bạn có muốn cập nhật phiên bản mới không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
			bool flag = dialogResult == DialogResult.Yes;
			bool flag2 = flag;
			if (flag2)
			{
				frm_progress frm_progress = new frm_progress();
				base.Hide();
				frm_progress.ShowDialog();
				File.Delete("./update/update.ini");
				this.ini_local.Write("Version", this.new_version, "Infor");
				MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x040002DF RID: 735
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x040002E0 RID: 736
		public const int HT_CAPTION = 2;

		// Token: 0x040002E1 RID: 737
		private IniFile ini_server = null;

		// Token: 0x040002E2 RID: 738
		private IniFile ini_local = null;

		// Token: 0x040002E3 RID: 739
		private string new_version = "";

		// Token: 0x040002E4 RID: 740
		private string old_version = "";
	}
}
