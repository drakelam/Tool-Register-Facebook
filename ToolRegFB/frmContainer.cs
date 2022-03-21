using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using DeviceId;
using ToolRegFB.Models;
using ToolRegFB.Properties;

namespace ToolRegFB
{
	// Token: 0x02000027 RID: 39
	public partial class frmContainer : Form
	{
		// Token: 0x060001B1 RID: 433 RVA: 0x0000FA30 File Offset: 0x0000DC30
		public frmContainer(Users user)
		{
			this.InitializeComponent();
			frmContainer.remote = this;
			this.pnlNav.Height = this.btnServices.Height;
			this.pnlNav.Top = this.btnServices.Top;
			this.pnlNav.Left = this.btnServices.Left;
			this.btnServices.BackColor = Color.FromArgb(46, 51, 73);
			this.lblFb.Visible = (this.lblInstagram.Visible = (this.lblShopee.Visible = (this.lblZalo.Visible = false)));
			this.lblLimitFB.Visible = (this.lblLimitInsta.Visible = (this.lblLimitShopee.Visible = (this.lblLimitZalo.Visible = false)));
			this.btnFacebook.Visible = (this.btnInstagram.Visible = (this.btnZalo.Visible = (this.btnShopee.Visible = false)));
			this.sessionUser = user;
			this.lblUserName.Text = user.email;
			this.lblSoxu.Text = user.totalMoney.ToString();
			this._listProduct = new List<PackageProduct>();
			this.machine_id = Common.Md5Encode(DeviceIdBuilderExtensions.AddSystemDriveSerialNumber(DeviceIdBuilderExtensions.AddMotherboardSerialNumber(DeviceIdBuilderExtensions.AddProcessorId(DeviceIdBuilderExtensions.AddMachineName(new DeviceIdBuilder())))).ToString(), "X2");
			this.LoadVersionSoft();
			bool flag = user.listLicense != null;
			if (flag)
			{
				bool flag2 = user.listLicense.Count > 0;
				if (flag2)
				{
					foreach (Licenses licenses in user.listLicense)
					{
						bool flag3 = licenses.typeProduct == "facebook";
						if (flag3)
						{
							this.btnRegFB.Text = "Gia hạn";
							this.lblLimitFB.Visible = true;
							this.lblFb.Visible = true;
							this.lblLimitFB.Text = licenses.timeExpired.ToString("dd/MM/yyyy");
							this.time_expired = licenses.timeExpired;
							int days = (Convert.ToDateTime(licenses.timeExpired.ToString("dd/MM/yyyy hh:mm:ss")) - Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"))).Days;
							bool flag4 = days <= 3 && days > 0;
							if (flag4)
							{
								this.timer1.Start();
							}
							bool flag5 = DateTime.Parse(licenses.timeExpired.ToString("dd/MM/yyyy hh:mm:ss")) > DateTime.Now;
							if (flag5)
							{
								this.timer2.Start();
								this.btnFacebook.Visible = true;
							}
							else
							{
								this.lblLimitFB.Text = "Hết hạn";
							}
						}
					}
				}
			}
			else
			{
				this.btnRegFB.Text = "Đăng ký";
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000FDC0 File Offset: 0x0000DFC0
		private void frmContainer_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000FDC4 File Offset: 0x0000DFC4
		private void btnServices_Click(object sender, EventArgs e)
		{
			this.pnlNav.Height = this.btnServices.Height;
			this.pnlNav.Top = this.btnServices.Top;
			this.pnlNav.Left = this.btnServices.Left;
			this.btnServices.BackColor = Color.FromArgb(46, 51, 73);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x0000FE30 File Offset: 0x0000E030
		private void btnFacebook_Click(object sender, EventArgs e)
		{
			this.pnlNav.Height = this.btnFacebook.Height;
			this.pnlNav.Top = this.btnFacebook.Top;
			this.btnFacebook.BackColor = Color.FromArgb(46, 51, 73);
			this.checkLicenseKey("facebook");
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x0000FE90 File Offset: 0x0000E090
		private void checkLicenseKey(string type)
		{
			this._loading = new frmLoading(base.Width, base.Height, base.Location.X, base.Location.Y);
			new Thread(delegate()
			{
				this.btnFacebook.Invoke(new MethodInvoker(delegate()
				{
					bool flag2 = type == "facebook";
					if (flag2)
					{
						this._loading.text1 = "Đang khởi tạo Auto Register Facebook...";
					}
					this._loading.showLoading();
				}));
				try
				{
					string user_id = this.sessionUser.id.ToString();
					string row = APIRequest.checkLicenseKey(this.sessionUser.token, user_id, this.machine_id, type);
					bool flag = row == string.Empty;
					if (flag)
					{
						MessageBox.Show("Khởi tạo tool không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						this._loading.hideLoading();
					}
					else
					{
						this.btnFacebook.Invoke(new MethodInvoker(delegate()
						{
							bool flag2 = !Common.CheckFormIsOpenning("frmMain");
							if (flag2)
							{
								this._loading.hideLoading();
								this.fmain = new frmMain(row);
								this.fmain.Show();
							}
						}));
					}
				}
				catch (Exception ex)
				{
					this.btnFacebook.Invoke(new MethodInvoker(delegate()
					{
						this._loading.hideLoading();
					}));
					MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}).Start();
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x0000FEFC File Offset: 0x0000E0FC
		private void btnInstagram_Click(object sender, EventArgs e)
		{
			this.pnlNav.Height = this.btnInstagram.Height;
			this.pnlNav.Top = this.btnInstagram.Top;
			this.btnInstagram.BackColor = Color.FromArgb(46, 51, 73);
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x0000FF50 File Offset: 0x0000E150
		private void btnShopee_Click(object sender, EventArgs e)
		{
			this.pnlNav.Height = this.btnShopee.Height;
			this.pnlNav.Top = this.btnShopee.Top;
			this.btnShopee.BackColor = Color.FromArgb(46, 51, 73);
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000FFA3 File Offset: 0x0000E1A3
		private void btnServices_Leave(object sender, EventArgs e)
		{
			this.btnServices.BackColor = Color.FromArgb(24, 30, 54);
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x0000FFBD File Offset: 0x0000E1BD
		private void btnFacebook_Leave(object sender, EventArgs e)
		{
			this.btnFacebook.BackColor = Color.FromArgb(24, 30, 54);
		}

		// Token: 0x060001BA RID: 442 RVA: 0x0000FFD7 File Offset: 0x0000E1D7
		private void btnInstagram_Leave(object sender, EventArgs e)
		{
			this.btnInstagram.BackColor = Color.FromArgb(24, 30, 54);
		}

		// Token: 0x060001BB RID: 443 RVA: 0x0000FFF1 File Offset: 0x0000E1F1
		private void btnShopee_Leave(object sender, EventArgs e)
		{
			this.btnShopee.BackColor = Color.FromArgb(24, 30, 54);
		}

		// Token: 0x060001BC RID: 444 RVA: 0x0001000B File Offset: 0x0000E20B
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.AlertKillTool();
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00010018 File Offset: 0x0000E218
		private void AlertKillTool()
		{
			DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát tool không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				Common.KillProcess("ToolRegFB");
				Common.KillProcess("RabbitUpdater");
				Common.KillProcess("adb");
			}
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00010064 File Offset: 0x0000E264
		private void btnMinimized_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00010070 File Offset: 0x0000E270
		private void btnZalo_Click(object sender, EventArgs e)
		{
			this.pnlNav.Height = this.btnZalo.Height;
			this.pnlNav.Top = this.btnZalo.Top;
			this.btnZalo.BackColor = Color.FromArgb(46, 51, 73);
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x000100C3 File Offset: 0x0000E2C3
		private void btnZalo_Leave(object sender, EventArgs e)
		{
			this.btnZalo.BackColor = Color.FromArgb(24, 30, 54);
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x000100E0 File Offset: 0x0000E2E0
		private void timer1_Tick(object sender, EventArgs e)
		{
			bool flag = this.demExpired == 3 || this.lblLimitFB.Text == "Hết hạn";
			if (flag)
			{
				this.timer1.Stop();
			}
			else
			{
				bool flag2 = this.sessionUser.listLicense != null;
				if (flag2)
				{
					bool flag3 = this.sessionUser.listLicense.Count > 0;
					if (flag3)
					{
						foreach (Licenses licenses in this.sessionUser.listLicense)
						{
							bool flag4 = licenses.typeProduct == "facebook";
							if (flag4)
							{
								int days = (Convert.ToDateTime(licenses.timeExpired.ToString("dd/MM/yyyy")) - Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"))).Days;
								bool flag5 = days <= 3 && days > 0;
								if (flag5)
								{
									bool flag6 = Common.CheckFormIsOpenning("frmMain");
									if (flag6)
									{
										this.bunifuSnackbar1.Show(this.fmain, "License sắp hết hạn. Vui lòng gia hạn thêm để sử dụng. Thank you!!!", 0, 3000);
									}
									else
									{
										this.bunifuSnackbar1.Show(this, "License sắp hết hạn. Vui lòng gia hạn thêm để sử dụng. Thank you!!!", 0, 3000);
									}
									this.demExpired++;
								}
								else
								{
									bool flag7 = DateTime.Parse(licenses.timeExpired.ToString("dd/MM/yyyy hh:mm:ss")) < DateTime.Now;
									if (flag7)
									{
										bool flag8 = Common.CheckFormIsOpenning("frmMain");
										if (flag8)
										{
											this.fmain.Close();
										}
										bool flag9 = Common.CheckFormIsOpenning("frmViewLD");
										if (flag9)
										{
											frmViewLD.remote.Close();
										}
										this.btnFacebook.Visible = false;
										this.lblLimitFB.Text = "Hết hạn";
										this.timer1.Stop();
										break;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00010318 File Offset: 0x0000E518
		private void btnNapxu_Click(object sender, EventArgs e)
		{
			bool flag = !Common.CheckFormIsOpenning("frmNapxu");
			if (flag)
			{
				string[] array = this.lblUserName.Text.Split(new string[]
				{
					"@"
				}, StringSplitOptions.None);
				frmNapxu frmNapxu = new frmNapxu(array[0]);
				frmNapxu.ShowDialog();
			}
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x0001036C File Offset: 0x0000E56C
		private void btnLogout_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.No;
			bool flag = Common.CheckFormIsOpenning("frmMain");
			if (flag)
			{
				this.fmain.Close();
			}
			base.Close();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x000103A3 File Offset: 0x0000E5A3
		private void btnRegFB_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x000103A8 File Offset: 0x0000E5A8
		private void ExcuteProduct(string type, string typeProduct, double xuMua, int typePackage)
		{
			this._loading = new frmLoading(base.Width, base.Height, base.Location.X, base.Location.Y);
			new Thread(delegate()
			{
				this.btnRegFB.Invoke(new MethodInvoker(delegate()
				{
					bool flag5 = type == "register";
					if (flag5)
					{
						this._loading.text1 = "Đang đăng ký Tool...";
					}
					else
					{
						bool flag6 = type == "extend";
						if (flag6)
						{
							this._loading.text1 = "Đang gia hạn Tool...";
						}
						else
						{
							this._loading.text1 = "Đang đăng ký dùng thử...";
						}
					}
					this._loading.showLoading();
				}));
				try
				{
					string user_id = this.sessionUser.id.ToString();
					bool flag = APIRequest.BuyProduct(this.sessionUser.token, user_id, this.machine_id, typeProduct, type, xuMua, typePackage);
					this.btnRegFB.Invoke(new MethodInvoker(delegate()
					{
						this._loading.hideLoading();
					}));
					bool flag2 = !flag;
					if (flag2)
					{
						bool flag3 = type == "register";
						if (flag3)
						{
							MessageBox.Show("Đăng ký tool này không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							bool flag4 = type == "extend";
							if (flag4)
							{
								MessageBox.Show("Gia hạn tool này không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							else
							{
								MessageBox.Show("Đăng ký dùng thử tool không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
						}
					}
					else
					{
						this.btnRegFB.Invoke(new MethodInvoker(delegate()
						{
							bool flag5 = type == "register" || type == "extend";
							if (flag5)
							{
								this.btnRegFB.Text = "Gia hạn";
								this.lblSoxu.Text = ((double)Convert.ToInt32(this.lblSoxu.Text) - xuMua).ToString();
								int num = 0;
								bool flag6 = typePackage == 1;
								if (flag6)
								{
									num = 30;
								}
								else
								{
									bool flag7 = typePackage == 6;
									if (flag7)
									{
										num = 180;
									}
									else
									{
										bool flag8 = typePackage == 12;
										if (flag8)
										{
											num = 360;
										}
										else
										{
											bool flag9 = typePackage == 0;
											if (flag9)
											{
												num = 7;
											}
										}
									}
								}
								bool flag10 = typeProduct == "facebook";
								if (flag10)
								{
									bool flag11 = this.lblLimitFB.Text != "Hết hạn";
									if (flag11)
									{
										this.lblLimitFB.Text = Convert.ToDateTime(this.lblLimitFB.Text).AddDays((double)num).ToString("dd/MM/yyyy");
									}
									else
									{
										DateTime now = DateTime.Now;
										TimeSpan value = new TimeSpan(num, 0, 0, 0);
										DateTime dateTime = now.Add(value);
										this.lblLimitFB.Text = DateTime.Now.AddDays((double)num).ToString("dd/MM/yyyy");
									}
								}
							}
							else
							{
								DateTime now2 = DateTime.Now;
								TimeSpan value2 = new TimeSpan(7, 0, 0, 0);
								DateTime dateTime2 = now2.Add(value2);
								this.lblLimitFB.Text = DateTime.Now.AddDays(7.0).ToString("dd/MM/yyyy");
								this.btnRegFB.Text = "Đăng ký";
							}
							this.lblLimitFB.Visible = true;
							this.lblFb.Visible = true;
							this.timer1.Stop();
							this.btnFacebook.Visible = true;
							bool flag12 = type == "register";
							if (flag12)
							{
								MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							else
							{
								bool flag13 = type == "extend";
								if (flag13)
								{
									MessageBox.Show("Gia hạn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
								else
								{
									bool flag14 = type == "trial";
									if (flag14)
									{
										MessageBox.Show("Đăng ký dùng thử tool thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									}
									else
									{
										MessageBox.Show("Có lỗi xảy ra khi đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
								}
							}
						}));
					}
				}
				catch (Exception ex)
				{
					this.btnRegFB.Invoke(new MethodInvoker(delegate()
					{
						this.timer1.Stop();
						this._loading.hideLoading();
					}));
					MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}).Start();
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x0001042C File Offset: 0x0000E62C
		private void showFormDangKy(string type_proc)
		{
			bool flag = this.btnRegFB.Text == "Dùng thử";
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Thời gian dùng thử tool đã hết. Các bạn có thể đăng ký 1 tuần để test tool.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					this.btnRegFB.Text = "Đăng ký";
				}
			}
			else
			{
				bool flag3 = !Common.CheckFormIsOpenning("frmNapxu");
				if (flag3)
				{
					frmProductOptions frmProductOptions = new frmProductOptions(new PackageProduct
					{
						listProc = new List<DetailPackage>
						{
							new DetailPackage
							{
								month = 1,
								tongxu = 800f
							},
							new DetailPackage
							{
								month = 6,
								tongxu = 4800f
							},
							new DetailPackage
							{
								month = 12,
								tongxu = 9600f
							},
							new DetailPackage
							{
								month = 0,
								tongxu = 200f
							}
						}
					});
					frmProductOptions.ShowDialog();
					bool flag4 = frmProductOptions.btnRegProduct.DialogResult == DialogResult.OK;
					if (flag4)
					{
						bool @checked = frmProductOptions.chk1ngay.Checked;
						int num;
						double num2;
						if (@checked)
						{
							num = 0;
							num2 = Convert.ToDouble(frmProductOptions.lbl1ngay.Text);
						}
						else
						{
							bool checked2 = frmProductOptions.chk1thang.Checked;
							if (checked2)
							{
								num = 1;
								num2 = Convert.ToDouble(frmProductOptions.lbl1thang.Text);
							}
							else
							{
								bool checked3 = frmProductOptions.chk6thang.Checked;
								if (checked3)
								{
									num = 6;
									num2 = Convert.ToDouble(frmProductOptions.lbl6thang.Text);
								}
								else
								{
									bool checked4 = frmProductOptions.chk12thang.Checked;
									if (!checked4)
									{
										MessageBox.Show("Vui lòng chọn gói cần đăng ký", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
										return;
									}
									num = 12;
									num2 = Convert.ToDouble(frmProductOptions.lbl12thang.Text);
								}
							}
						}
						bool flag5 = this.sessionUser.totalMoney < num2;
						if (flag5)
						{
							MessageBox.Show("Xu không đủ. Vui lòng nạp thêm xu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							bool flag6 = this.btnRegFB.Text == "Đăng ký";
							if (flag6)
							{
								bool flag7 = num == 0;
								DialogResult dialogResult;
								if (flag7)
								{
									dialogResult = MessageBox.Show("Bạn đồng ý đăng ký 1 tuần dùng tool?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
								}
								else
								{
									dialogResult = MessageBox.Show("Bạn đồng ý đăng ký " + num.ToString() + " tháng dùng tool?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
								}
								bool flag8 = dialogResult == DialogResult.Yes;
								if (flag8)
								{
									this.ExcuteProduct("register", type_proc, num2, num);
								}
							}
							else
							{
								bool flag9 = num == 0;
								DialogResult dialogResult;
								if (flag9)
								{
									dialogResult = MessageBox.Show("Bạn đồng ý gia hạn thêm 1 tuần dùng tool?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
								}
								else
								{
									dialogResult = MessageBox.Show("Bạn đồng ý gia hạn thêm " + num.ToString() + " tháng dùng tool?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
								}
								bool flag10 = dialogResult == DialogResult.Yes;
								if (flag10)
								{
									this.ExcuteProduct("extend", type_proc, num2, num);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x0001074C File Offset: 0x0000E94C
		private void btnRegFB_Click_1(object sender, EventArgs e)
		{
			bool flag = Common.CheckTimeIsValid();
			if (flag)
			{
				this.showFormDangKy("facebook");
			}
			else
			{
				MessageBox.Show("Bạn vui lòng chuyển đổi thời gian máy tính của bạn sang định dạng ngày/tháng/năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00010784 File Offset: 0x0000E984
		private void btnRegInsta_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Đang phát triển. Mọi người chờ nhé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x0001079A File Offset: 0x0000E99A
		private void btnRegShopee_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Đang phát triển. Mọi người chờ nhé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000107B0 File Offset: 0x0000E9B0
		private void btnRegZalo_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Đang phát triển. Mọi người chờ nhé", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000107C8 File Offset: 0x0000E9C8
		private void btnUpdateVersion_Click(object sender, EventArgs e)
		{
			frmUpdate frmUpdate = new frmUpdate();
			frmUpdate.Show();
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000107E4 File Offset: 0x0000E9E4
		public void LoadVersionSoft()
		{
			IniFile iniFile = new IniFile("update.ini");
			this.lblVersion.Text = iniFile.Read("Version", "Infor");
		}

		// Token: 0x060001CD RID: 461 RVA: 0x0001081C File Offset: 0x0000EA1C
		private void timer2_Tick(object sender, EventArgs e)
		{
			bool flag = DateTime.Parse(this.time_expired.ToString("dd/MM/yyyy hh:mm:ss")) < DateTime.Now;
			if (flag)
			{
				bool flag2 = frmMain.remote != null;
				if (flag2)
				{
					frmMain.remote.Close();
				}
				bool flag3 = frmViewLD.remote != null;
				if (flag3)
				{
					frmViewLD.remote.Close();
				}
				this.btnFacebook.Visible = false;
				this.lblLimitFB.Text = "Hết hạn";
				this.timer2.Stop();
			}
		}

		// Token: 0x060001CE RID: 462 RVA: 0x000108A7 File Offset: 0x0000EAA7
		private void btnExitTool_Click(object sender, EventArgs e)
		{
			this.AlertKillTool();
		}

		// Token: 0x060001CF RID: 463 RVA: 0x000108B4 File Offset: 0x0000EAB4
		private void btnUpdateXu_Click(object sender, EventArgs e)
		{
			bool flag = this.sessionUser != null;
			if (flag)
			{
				this.lblSoxu.Text = APIRequest.updateTongXu(this.sessionUser.id.ToString(), this.sessionUser.email, this.sessionUser.token).ToString();
			}
			else
			{
				MessageBox.Show("Cập nhật xu không thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x040000FE RID: 254
		public static frmContainer remote;

		// Token: 0x040000FF RID: 255
		private frmLoading _loading;

		// Token: 0x04000100 RID: 256
		private Users sessionUser = new Users();

		// Token: 0x04000101 RID: 257
		private int demExpired = 0;

		// Token: 0x04000102 RID: 258
		private frmMain fmain;

		// Token: 0x04000103 RID: 259
		private frmViewLD fviewLD;

		// Token: 0x04000104 RID: 260
		private List<PackageProduct> _listProduct;

		// Token: 0x04000105 RID: 261
		private string machine_id = string.Empty;

		// Token: 0x04000106 RID: 262
		private DateTime time_expired;
	}
}
