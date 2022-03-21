using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using DeviceId;
using ToolRegFB.Models;
using ToolRegFB.Properties;
using Utilities.BunifuPages.BunifuAnimatorNS;

namespace ToolRegFB
{
	// Token: 0x0200002B RID: 43
	public partial class frmLoginUser : Form
	{
		// Token: 0x060001DE RID: 478 RVA: 0x0001496C File Offset: 0x00012B6C
		public frmLoginUser()
		{
			this.InitializeComponent();
			IniFile iniFile = new IniFile("update.ini");
			this.lblVersion.Text = iniFile.Read("Version", "Infor");
			this.machine_id = Common.Md5Encode(DeviceIdBuilderExtensions.AddSystemDriveSerialNumber(DeviceIdBuilderExtensions.AddMotherboardSerialNumber(DeviceIdBuilderExtensions.AddProcessorId(DeviceIdBuilderExtensions.AddMachineName(new DeviceIdBuilder())))).ToString(), "X2");
		}

		// Token: 0x060001DF RID: 479 RVA: 0x000149EF File Offset: 0x00012BEF
		private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		// Token: 0x060001E0 RID: 480 RVA: 0x000149F8 File Offset: 0x00012BF8
		private void btnMinimize_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x060001E1 RID: 481 RVA: 0x00014A04 File Offset: 0x00012C04
		private void btnSigup_Click(object sender, EventArgs e)
		{
			bool flag = this.txtUserName.Text.Trim() == "";
			if (flag)
			{
				MessageBox.Show("Chưa nhập họ và tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.txtUserName.Focus();
			}
			else
			{
				bool flag2 = this.txtEmail.Text.Trim() == "";
				if (flag2)
				{
					MessageBox.Show("Chưa nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtEmail.Focus();
				}
				else
				{
					bool flag3 = !new EmailAddressAttribute().IsValid(this.txtEmail.Text.Trim());
					if (flag3)
					{
						MessageBox.Show("Email định dạng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtEmail.Focus();
					}
					else
					{
						bool flag4 = this.txtPassword.Text.Trim() == "";
						if (flag4)
						{
							MessageBox.Show("Chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							this.txtPassword.Focus();
						}
						else
						{
							bool flag5 = this.txtRePass.Text.Trim() == "";
							if (flag5)
							{
								MessageBox.Show("Chưa nhập lại mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								this.txtRePass.Focus();
							}
							else
							{
								bool flag6 = this.txtRePass.Text.Trim() != this.txtPassword.Text.Trim();
								if (flag6)
								{
									MessageBox.Show("Mật khẩu nhập lại không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									this.txtRePass.Focus();
								}
								else
								{
									this._loading = new frmLoading(base.Width, base.Height, base.Location.X, base.Location.Y);
									new Thread(delegate()
									{
										try
										{
											this.btnSignup1.Invoke(new MethodInvoker(delegate()
											{
												this.btnSignup1.Enabled = false;
												this._loading.text1 = "Đang đăng ký...";
												this._loading.showLoading();
											}));
											Users user = new Users
											{
												name = this.txtUserName.Text.Trim(),
												email = this.txtEmail.Text.Trim(),
												password = this.txtPassword.Text.Trim(),
												macAddress = this.machine_id
											};
											int num = APIRequest.RegisterAccount(user);
											this.btnSignup1.Invoke(new MethodInvoker(delegate()
											{
												this.btnSignup1.Enabled = true;
												this._loading.hideLoading();
											}));
											bool flag7 = num == 402;
											if (flag7)
											{
												MessageBox.Show("Email này đã được đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
											}
											else
											{
												bool flag8 = num == 401;
												if (flag8)
												{
													MessageBox.Show("Nhiều tài khoản đã đăng ký trên máy này. Vui lòng đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
													this.btnSignup1.Invoke(new MethodInvoker(delegate()
													{
														this.txtUserName.Text = (this.txtPassword.Text = (this.txtEmail.Text = (this.txtRePass.Text = string.Empty)));
														this.bunifuPages1.SetPage(0);
													}));
												}
												else
												{
													bool flag9 = num == 404;
													if (flag9)
													{
														MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
													}
													else
													{
														this.btnSignup1.Invoke(new MethodInvoker(delegate()
														{
															MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
															this.txtEmailSigin.Text = this.txtEmail.Text.Trim();
															this.txtUserName.Text = (this.txtPassword.Text = (this.txtEmail.Text = (this.txtRePass.Text = string.Empty)));
															this.bunifuPages1.SetPage(0);
														}));
													}
												}
											}
										}
										catch (Exception ex)
										{
											this.btnSignup1.Invoke(new MethodInvoker(delegate()
											{
												this.btnSignup1.Enabled = true;
												this._loading.hideLoading();
												MessageBox.Show("Đăng ký không thành công. Vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
											}));
										}
									}).Start();
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060001E2 RID: 482 RVA: 0x00014C00 File Offset: 0x00012E00
		private void btnSigin_Click(object sender, EventArgs e)
		{
			bool flag = this.txtEmailSigin.Text.Trim() == "";
			if (flag)
			{
				MessageBox.Show("Chưa nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				this.txtEmailSigin.Focus();
			}
			else
			{
				bool flag2 = !new EmailAddressAttribute().IsValid(this.txtEmailSigin.Text.Trim());
				if (flag2)
				{
					MessageBox.Show("Email định dạng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					this.txtEmailSigin.Focus();
				}
				else
				{
					bool flag3 = this.txtPassSigin.Text.Trim() == "";
					if (flag3)
					{
						MessageBox.Show("Chưa nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this.txtPassSigin.Focus();
					}
					else
					{
						this._loading = new frmLoading(base.Width, base.Height, base.Location.X, base.Location.Y);
						new Thread(delegate()
						{
							try
							{
								this.btnSigin.Invoke(new MethodInvoker(delegate()
								{
									this.btnSigin.Enabled = false;
									this._loading.text1 = "Đang đăng nhập...";
									this._loading.showLoading();
								}));
								Users user = APIRequest.LoginApp(this.txtEmailSigin.Text.Trim(), this.txtPassSigin.Text.Trim());
								this.btnSigin.Invoke(new MethodInvoker(delegate()
								{
									this.btnSigin.Enabled = true;
									this._loading.hideLoading();
								}));
								bool flag4 = user == null;
								if (flag4)
								{
									MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Hoặc bạn chưa nạp để sử dụng tool!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
								else
								{
									this.btnSigin.Invoke(new MethodInvoker(delegate()
									{
										this.Visible = false;
										frmContainer frmContainer = new frmContainer(user);
										frmContainer.ShowDialog();
										this.txtEmailSigin.Text = (this.txtPassSigin.Text = string.Empty);
										bool flag5 = frmContainer.DialogResult != DialogResult.No;
										if (flag5)
										{
											this.Close();
										}
										bool isRememe = Settings.Default.isRememe;
										if (isRememe)
										{
											this.chkRememe.Checked = true;
											this.txtEmailSigin.Text = Settings.Default.userLogin;
											this.txtPassSigin.Text = Settings.Default.PassLogin;
										}
										else
										{
											this.chkRememe.Checked = false;
											this.txtEmailSigin.Text = string.Empty;
											this.txtPassSigin.Text = string.Empty;
										}
										this.Visible = true;
									}));
								}
							}
							catch (Exception ex)
							{
								this.btnSigin.Invoke(new MethodInvoker(delegate()
								{
									this.btnSigin.Enabled = true;
									this._loading.hideLoading();
									MessageBox.Show("Đăng nhập không thành công. Vui lòng thử lại sau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}));
							}
						}).Start();
					}
				}
			}
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00014D21 File Offset: 0x00012F21
		private void btnSignup1_Click(object sender, EventArgs e)
		{
			this.bunifuPages1.SetPage(1);
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00014D31 File Offset: 0x00012F31
		private void btnSigin1_Click_1(object sender, EventArgs e)
		{
			this.bunifuPages1.SetPage(0);
		}

		// Token: 0x060001E5 RID: 485 RVA: 0x00014D44 File Offset: 0x00012F44
		private void chkRememe_OnChange(object sender, EventArgs e)
		{
			bool @checked = this.chkRememe.Checked;
			if (@checked)
			{
				bool flag = this.txtEmailSigin.Text != string.Empty && this.txtPassSigin.Text != string.Empty;
				if (flag)
				{
					Settings.Default.userLogin = this.txtEmailSigin.Text.Trim();
					Settings.Default.PassLogin = this.txtPassSigin.Text.Trim();
					Settings.Default.isRememe = this.chkRememe.Checked;
					Settings.Default.Save();
				}
			}
			else
			{
				Settings.Default.userLogin = string.Empty;
				Settings.Default.PassLogin = string.Empty;
				Settings.Default.isRememe = false;
				Settings.Default.Save();
			}
		}

		// Token: 0x060001E6 RID: 486 RVA: 0x00014E30 File Offset: 0x00013030
		private void frmLoginUser_Load(object sender, EventArgs e)
		{
			bool isRememe = Settings.Default.isRememe;
			if (isRememe)
			{
				this.chkRememe.Checked = true;
				this.txtEmailSigin.Text = Settings.Default.userLogin;
				this.txtPassSigin.Text = Settings.Default.PassLogin;
			}
			else
			{
				this.chkRememe.Checked = false;
			}
		}

		// Token: 0x060001E7 RID: 487 RVA: 0x00014E98 File Offset: 0x00013098
		private void txtEmailSigin_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == (char)Convert.ToInt16(Keys.Return);
			if (flag)
			{
				this.btnSigin_Click(sender, e);
			}
		}

		// Token: 0x060001E8 RID: 488 RVA: 0x00014ECC File Offset: 0x000130CC
		private void txtPassSigin_KeyPress(object sender, KeyPressEventArgs e)
		{
			bool flag = e.KeyChar == (char)Convert.ToInt16(Keys.Return);
			if (flag)
			{
				this.btnSigin_Click(sender, e);
			}
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00014F00 File Offset: 0x00013100
		private void btnNapXu_Click(object sender, EventArgs e)
		{
			bool flag = !Common.CheckFormIsOpenning("frmNapxu");
			if (flag)
			{
				string name = "+ Tài khoản đăng ký";
				frmNapxu frmNapxu = new frmNapxu(name);
				frmNapxu.ShowDialog();
			}
		}

		// Token: 0x04000152 RID: 338
		private frmLoading _loading;

		// Token: 0x04000153 RID: 339
		private string machine_id = string.Empty;
	}
}
