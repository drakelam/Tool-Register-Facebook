using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace ToolRegFB
{
	// Token: 0x02000026 RID: 38
	public partial class frmLoading : Form
	{
		// Token: 0x060001AB RID: 427 RVA: 0x0000F748 File Offset: 0x0000D948
		public frmLoading(int _width, int _height, int _x, int _y)
		{
			this.InitializeComponent();
			base.Width = _width;
			base.Height = _height;
			base.Location = new Point(_x, _y);
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000F795 File Offset: 0x0000D995
		private void frmLoading_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060001AD RID: 429 RVA: 0x0000F798 File Offset: 0x0000D998
		public void showLoading()
		{
			try
			{
				int x = base.Width / 2 - (base.Width + base.Height) / 10;
				int y = base.Height / 2 - (base.Width + base.Height) / 10;
				BunifuLoader bunifuLoader = new BunifuLoader();
				bunifuLoader.Location = new Point(x, y);
				bunifuLoader.Size = new Size(base.Width / 3, base.Height / 2);
				bunifuLoader.Color = Color.DodgerBlue;
				bunifuLoader.RingStyle = 2;
				bunifuLoader.AllowStylePresets = false;
				bunifuLoader.ShowText = true;
				bool flag = this.text1 != "";
				if (flag)
				{
					bunifuLoader.Text = this.text1;
				}
				bunifuLoader.ForeColor = Color.White;
				bunifuLoader.Font = new Font("Nirmala UI", 10f, FontStyle.Regular);
				base.Controls.Add(bunifuLoader);
				base.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x0000F8B8 File Offset: 0x0000DAB8
		public void hideLoading()
		{
			try
			{
				base.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x040000FC RID: 252
		public string text1 = "";
	}
}
