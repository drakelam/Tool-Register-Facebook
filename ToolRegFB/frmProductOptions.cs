using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using ToolRegFB.Models;
using ToolRegFB.Properties;

namespace ToolRegFB
{
	// Token: 0x02000036 RID: 54
	public partial class frmProductOptions : Form
	{
		// Token: 0x06000295 RID: 661 RVA: 0x00031550 File Offset: 0x0002F750
		public frmProductOptions(PackageProduct product)
		{
			this.InitializeComponent();
			double num = (double)product.listProc[1].tongxu * 0.9;
			double num2 = (double)product.listProc[2].tongxu * 0.7;
			this.lbl1thang.Text = product.listProc[0].tongxu.ToString();
			this.lbl6thang.Text = num.ToString();
			this.lbl12thang.Text = num2.ToString();
			this.lbl1ngay.Text = product.listProc[3].tongxu.ToString();
			this.chk6thang.Checked = (this.chk12thang.Checked = (this.chk1ngay.Checked = !this.chk1thang.Checked));
			this.btnRegProduct.DialogResult = DialogResult.OK;
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00031664 File Offset: 0x0002F864
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.btnRegProduct.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		// Token: 0x06000297 RID: 663 RVA: 0x0003167C File Offset: 0x0002F87C
		private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
		{
			this.chk1ngay.Checked = (this.chk6thang.Checked = (this.chk12thang.Checked = !this.chk1thang.Checked));
		}

		// Token: 0x06000298 RID: 664 RVA: 0x000316C4 File Offset: 0x0002F8C4
		private void chk6thang_OnChange(object sender, EventArgs e)
		{
			this.chk1ngay.Checked = (this.chk1thang.Checked = (this.chk12thang.Checked = !this.chk6thang.Checked));
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0003170C File Offset: 0x0002F90C
		private void chk12thang_OnChange(object sender, EventArgs e)
		{
			this.chk1ngay.Checked = (this.chk1thang.Checked = (this.chk6thang.Checked = !this.chk12thang.Checked));
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00031752 File Offset: 0x0002F952
		private void bunifuCustomLabel2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00031755 File Offset: 0x0002F955
		private void bunifuCustomLabel3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00031758 File Offset: 0x0002F958
		private void bunifuCustomLabel7_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600029D RID: 669 RVA: 0x0003175C File Offset: 0x0002F95C
		private void chk1ngay_OnChange(object sender, EventArgs e)
		{
			this.chk1thang.Checked = (this.chk6thang.Checked = (this.chk12thang.Checked = !this.chk1ngay.Checked));
		}
	}
}
