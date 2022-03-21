using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using ToolRegFB.Properties;

namespace ToolRegFB
{
	// Token: 0x02000025 RID: 37
	public partial class frmAutoFunction : Form
	{
		// Token: 0x060001A1 RID: 417 RVA: 0x0000DEAD File Offset: 0x0000C0AD
		public frmAutoFunction()
		{
			this.InitializeComponent();
			this.ShowConfig();
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x0000DECC File Offset: 0x0000C0CC
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x0000DED8 File Offset: 0x0000C0D8
		private void ShowConfig()
		{
			this.cbCPULD.Text = Settings.Default.CpuLD;
			this.cbRamLD.Text = Settings.Default.RamLD;
			this.nudSizeFr.Value = Settings.Default.SizeLDFrom;
			this.nudSizeTo.Value = Settings.Default.SizeLDTo;
			this.nudDPILD.Value = Settings.Default.DPILD;
			bool isAutoClearLD = Settings.Default.isAutoClearLD;
			if (isAutoClearLD)
			{
				this.chkAutoClearLD.Checked = true;
			}
			bool isOnGPSLD = Settings.Default.isOnGPSLD;
			if (isOnGPSLD)
			{
				this.cbTurnOnLDPlayer.Checked = true;
			}
			bool isAdbDebug = Settings.Default.isAdbDebug;
			if (isAdbDebug)
			{
				this.ckAdbDebug.Checked = true;
			}
		}

		// Token: 0x060001A4 RID: 420 RVA: 0x0000DFB4 File Offset: 0x0000C1B4
		private void chkAutoClearLD_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x0000DFB7 File Offset: 0x0000C1B7
		private void cbTurnOnLDPlayer_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x0000DFBA File Offset: 0x0000C1BA
		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000DFBD File Offset: 0x0000C1BD
		private void label3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000DFC0 File Offset: 0x0000C1C0
		private void btnSaveConf_Click(object sender, EventArgs e)
		{
			bool flag = this.cbCPULD.GetItemText(this.cbCPULD.SelectedItem) == string.Empty;
			if (flag)
			{
				MessageBox.Show("Chưa chọn loại CPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				bool flag2 = this.cbRamLD.GetItemText(this.cbRamLD.SelectedItem) == string.Empty;
				if (flag2)
				{
					MessageBox.Show("Chưa chọn loại Ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					bool flag3 = this.nudSizeFr.Value < 320m;
					if (flag3)
					{
						MessageBox.Show("Chiều ngang LDPlayer tối thiểu là 320", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						bool flag4 = this.nudSizeTo.Value < 480m;
						if (flag4)
						{
							MessageBox.Show("Chiều dọc LDPlayer tối thiểu là 480", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							bool flag5 = this.nudDPILD.Value < 120m;
							if (flag5)
							{
								MessageBox.Show("DPI LDPlayer tối thiểu là 120", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							else
							{
								Settings.Default.CpuLD = this.cbCPULD.GetItemText(this.cbCPULD.SelectedItem);
								Settings.Default.RamLD = this.cbRamLD.GetItemText(this.cbRamLD.SelectedItem);
								Settings.Default.SizeLDFrom = Convert.ToInt32(this.nudSizeFr.Value);
								Settings.Default.SizeLDTo = Convert.ToInt32(this.nudSizeTo.Value);
								Settings.Default.DPILD = Convert.ToInt32(this.nudDPILD.Value);
								bool @checked = this.chkAutoClearLD.Checked;
								if (@checked)
								{
									Settings.Default.isAutoClearLD = true;
								}
								else
								{
									Settings.Default.isAutoClearLD = false;
								}
								bool checked2 = this.cbTurnOnLDPlayer.Checked;
								if (checked2)
								{
									Settings.Default.isOnGPSLD = true;
								}
								else
								{
									Settings.Default.isOnGPSLD = false;
								}
								bool checked3 = this.ckAdbDebug.Checked;
								if (checked3)
								{
									Settings.Default.isAdbDebug = true;
								}
								else
								{
									Settings.Default.isAdbDebug = false;
								}
								Settings.Default.Save();
								MessageBox.Show("Lưu cấu hình thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								base.Hide();
							}
						}
					}
				}
			}
		}
	}
}
