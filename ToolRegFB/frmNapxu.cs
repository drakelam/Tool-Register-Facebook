using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using ToolRegFB.Properties;

namespace ToolRegFB
{
	// Token: 0x02000035 RID: 53
	public partial class frmNapxu : Form
	{
		// Token: 0x06000291 RID: 657 RVA: 0x000300A8 File Offset: 0x0002E2A8
		public frmNapxu(string name)
		{
			this.InitializeComponent();
			this.lblNoiDung.Text = "NAPXU " + name;
			this.lblMomo.Text = "NAPXU " + name;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x000300F9 File Offset: 0x0002E2F9
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}
	}
}
