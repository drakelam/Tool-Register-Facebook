using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using DeviceId;
using HttpRequest;
using KAutoHelper;
using Newtonsoft.Json.Linq;
using ToolRegFB.Properties;

namespace ToolRegFB
{
	// Token: 0x0200002D RID: 45
	public partial class frmMain : Form
	{
		// Token: 0x060001F8 RID: 504 RVA: 0x0001A348 File Offset: 0x00018548
		public frmMain(string timeExpired)
		{
			this.InitializeComponent();
			frmMain.remote = this;
			base.MaximizedBounds = Screen.FromHandle(base.Handle).WorkingArea;
			base.WindowState = FormWindowState.Maximized;
			this.LoadCbbLocation();
			this.LoadSettings();
			this.btnReg.Enabled = true;
			this.btnStop.Enabled = false;
			this.btnSaveConf.Enabled = true;
			this.checkDelayLD_MoLDPLayer = 0;
			this.lock_checkDelayLD_MoLDPLayer = new object();
			this.checkDelayLD = 0;
			this.lock_checkDelayLD = new object();
			this.lock_checkDelayCreateDevice = new object();
			this.lock_checkDelayCreateDevice_MoLDPLayer = new object();
			this.isOpeningDevice_MoLDPLayer = false;
			this.listTinsoft = null;
			this.listApiTinsoft = null;
			this.lock_StartProxy = new object();
			this.listThread = new List<Thread>();
			this.lstDevice = new List<Device>();
			this.listextension = (from s in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "extension")
			where Path.GetExtension(s) == ".crx"
			select s).ToList<string>();
			this.stIPCur.Text = this.GetIp();
			try
			{
				Common.getWidthScreen = Screen.PrimaryScreen.Bounds.Width;
				Common.getHeightScreen = Screen.PrimaryScreen.Bounds.Height;
				this.getWidthChrome = 2 * Common.getWidthScreen / 6;
				this.getHeightChrome = Common.getHeightScreen / 2;
			}
			catch
			{
			}
			string text = Common.Md5Encode(DeviceIdBuilderExtensions.AddSystemDriveSerialNumber(DeviceIdBuilderExtensions.AddMotherboardSerialNumber(DeviceIdBuilderExtensions.AddProcessorId(DeviceIdBuilderExtensions.AddMachineName(new DeviceIdBuilder())))).ToString(), "X2");
			this.lblMachineName.Text = text.Substring(0, 10) + "****";
			this.lblTimeExpired.Text = Convert.ToDateTime(timeExpired).ToString("dd/MM/yyyy");
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0001A768 File Offset: 0x00018968
		public string GetCellAccount(int indexRow, string column)
		{
			return DatagridviewHelper.GetStatusDataGridView(this.dgvAcc, indexRow, column);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0001A787 File Offset: 0x00018987
		protected override void OnLoad(EventArgs args)
		{
			Application.Idle += this.OnLoaded;
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0001A79C File Offset: 0x0001899C
		private void OnLoaded(object sender, EventArgs e)
		{
			Application.Idle -= this.OnLoaded;
			new Thread(delegate()
			{
				for (;;)
				{
					try
					{
						string text = ADBHelper.RunCMD("adb devices", 10);
						bool flag = !text.Contains("List of devices attached");
						if (flag)
						{
							Common.KillProcess("adb");
							this.isResetAdb = true;
						}
					}
					catch
					{
					}
					Common.DelayTime(30.0);
				}
			}).Start();
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0001A7C8 File Offset: 0x000189C8
		private string GetLastnameUs()
		{
			return this.lastname_us[this.rd.Next(0, this.lastname_us.Length - 1)];
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0001A7F8 File Offset: 0x000189F8
		private string GetFirstnameFemaleUs()
		{
			return this.firstname_female_us[this.rd.Next(0, this.firstname_female_us.Length - 1)];
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0001A828 File Offset: 0x00018A28
		private string GetFirstnamemaleUs()
		{
			return this.firstname_male_us[this.rd.Next(0, this.firstname_male_us.Length - 1)];
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0001A858 File Offset: 0x00018A58
		private string GetLastnameVN()
		{
			return this.lastname_vn[this.rd.Next(0, this.lastname_vn.Length - 1)];
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0001A888 File Offset: 0x00018A88
		private string GetFirstnamemaleVN()
		{
			return this.firstname_male_vn[this.rd.Next(0, this.firstname_male_vn.Length - 1)];
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0001A8B8 File Offset: 0x00018AB8
		private string GetFirstnameFemaleVN()
		{
			return this.firstname_female_vn[this.rd.Next(0, this.firstname_female_vn.Length - 1)];
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0001A8E8 File Offset: 0x00018AE8
		private string HoVietNam()
		{
			string text = "Nguyen|Tran|Le|Pham|Hoang|Huynh|Phan|Vu|Vo|Dang|Dinh|Trinh|Doan|Bui|Do|Ho|Ngo|Duong|Ly|Dao|Ung|Lieu|Mai";
			string[] array = text.Split(new char[]
			{
				'|'
			});
			return array[this.rd.Next(0, array.Length - 1)];
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0001A928 File Offset: 0x00018B28
		public void stopAll()
		{
			try
			{
				this.plTrangThai.Text = "Đã dừng";
				this.plTrangThai.ForeColor = Color.Red;
				this.isStop = true;
				bool flag = this.listThread.Count > 0;
				if (flag)
				{
					this.listThread.Clear();
				}
				bool flag2 = this.lstDevice.Count > 0;
				if (flag2)
				{
					this.lstDevice.Clear();
				}
				this.cControl("stop");
			}
			catch
			{
			}
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0001A9C0 File Offset: 0x00018BC0
		private string TenVietName()
		{
			string text = "Kim Quyen|Phuoc Thien|Quynh Tran|Vinh|Binh|Huynh Ngoc Dung| Van|Thanh Bich|Thu Hien|Bao Ngoc|Thao|Huynh Truc Vy|Ba Duy|Thuy Linh|Huyen Tram|Ngoc Hoa|Hoang Quyen|Ngoc Diep|Thanh Ha|Hoang Phuong|Truc Ly|Tram|Trang Oanh|My|Nhu|Lai|Kim|Phuc|Phuong|Tram Anh|Dieu Anh|Quynh Anh|Ngoc Diep|Kim Khanh|Ngoc Lien|Cat TuongDiệu Ái|Khả Ái|Ngọc Ái|Hoài An|Huệ An|Minh An|Phương An|Thanh An|Hải Ân|Huệ Ân|Bảo Anh|Diệp Anh|Diệu Anh|Hải Anh|Hồng Anh|Huyền Anh|Kiều Anh|Kim Anh|Lan Anh|Mai Anh|Minh Anh|Mỹ Anh|Ngọc Anh|Nguyệt Anh|Như Anh|Phương Anh|Quế Anh|Quỳnh Anh|Thục Anh|Thúy Anh|Thùy Anh|Trâm Anh|Trang Anh|Tú Anh|Tuyết Anh|Vân Anh|Yến Anh|Kim Ánh|Ngọc Ánh|Nguyệt Ánh|Nhật Ánh|Băng Băng|Lệ Băng|Tuyết Băng|Như Bảo|Gia Bảo|Xuân Bảo|Ngọc Bích|An Bình|Thái Bình|Sơn Ca|Ngọc Cầm|Nguyệt Cầm|Thi Cầm|Bảo Châu|Bích Châu|Diễm Châu|Hải Châu|Hoàn Châu|Hồng Châu|Linh Châu|Loan Châu|Ly Châu|Mai Châu|Minh Châu|Trân Châu|Diệp Chi|Diễm Chi|Hạnh Chi|Khánh Chi|Kim Chi|Lan Chi|Lệ Chi|Linh Chi|Mai Chi|Phương Chi|Quế Chi|Quỳnh Chi|Bích Chiêu|Hoàng Cúc|Kim Cương|Trang Ðài|Tâm Đan|Thanh Đan|Linh Ðan|Quỳnh Dao|Anh Ðào|Bích Ðào|Hồng Ðào|Ngọc Ðào|Thục Ðào|Trúc Ðào|An Di|Thiên Di|Hồng Diễm|Kiều Diễm|Phương Diễm|Thúy Diễm|Bích Diệp|Hồng Diệp|Ngọc Diệp|Bích Ðiệp|Hồng Ðiệp|Mộng Ðiệp|Ngọc Ðiệp|Huyền Diệu|Tâm Ðoan|Thục Ðoan|Hạnh Dung|Kiều Dung|Kim Dung|Mỹ Dung|Nghi Dung|Ngọc Dung|Phương Dung|Quỳnh Dung|Thùy Dung|Ánh Dương|Chiêu Dương|Thùy Dương|Hải Ðường|Bích Duyên|Kỳ Duyên|Linh Duyên|Minh Duyên|Mỹ Duyên|Thu Duyên|Bảo An|Bình An|Ðăng An|Duy An|Khánh An|Nam An|Phước An|Thành An|Thế An|Thiên An|Trường An|Việt An|Xuân An|Công Ân|Ðức Ân|Gia Ân|Hoàng Ân|Minh Ân|Phú Ân|Thành Ân|Thiên Ân|Thiện Ân|Duy Bảo|Gia Bảo|Hữu Bảo|Nguyên Bảo|Quốc Bảo|Thiệu Bảo|Tiểu Bảo|Ðức Bình|Gia Bình|Khải Ca|Gia Cần|Duy Cẩn|Gia Cẩn|Hữu Canh|Gia Cảnh|Hữu Cảnh|Minh Cảnh|Ngọc Cảnh|Đức Cao|Xuân Cao|Bảo Chấn|Bảo Châu|";
			string[] array = text.Split(new char[]
			{
				'|'
			});
			return array[this.rd.Next(0, array.Length - 1)];
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0001A9FD File Offset: 0x00018BFD
		private void label4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0001AA00 File Offset: 0x00018C00
		private void button4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0001AA03 File Offset: 0x00018C03
		private void groupBox4_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0001AA06 File Offset: 0x00018C06
		private void numericUpDown6_ValueChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0001AA0C File Offset: 0x00018C0C
		public void cControl(string dt)
		{
			base.Invoke(new MethodInvoker(delegate()
			{
				try
				{
					bool flag = dt == "start";
					if (flag)
					{
						this.btnReg.Enabled = false;
						this.btnSaveConf.Enabled = false;
						this.btnStop.Enabled = true;
					}
					else
					{
						bool flag2 = dt == "stop";
						if (flag2)
						{
							this.btnReg.Enabled = true;
							this.btnSaveConf.Enabled = true;
							this.btnStop.Enabled = false;
						}
					}
				}
				catch (Exception)
				{
				}
			}));
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0001AA44 File Offset: 0x00018C44
		private void btnReg_Click(object sender, EventArgs e)
		{
			Thread threadRefreshDeviceId = null;
			try
			{
				threadRefreshDeviceId = new Thread(delegate()
				{
					for (;;)
					{
						try
						{
							bool flag17 = this.isResetAdb && this.lstDevice.Count > 0;
							if (flag17)
							{
								bool flag18 = false;
								while (!flag18)
								{
									flag18 = true;
									for (int m = 0; m < this.lstDevice.Count; m++)
									{
										string deviceByIndex = ADBHelper.GetDeviceByIndex(this.lstDevice[m].IndexDevice);
										bool flag19 = string.IsNullOrEmpty(deviceByIndex);
										if (flag19)
										{
											flag18 = false;
										}
										else
										{
											this.lstDevice[m].DeviceId = deviceByIndex;
										}
									}
								}
								this.isResetAdb = false;
							}
						}
						catch
						{
						}
						this.Delay(5.0);
					}
				});
				threadRefreshDeviceId.IsBackground = true;
				threadRefreshDeviceId.Start();
			}
			catch
			{
			}
			try
			{
				IniFile iniFile = new IniFile("setting.ini");
				this.iMaxThread = Convert.ToInt32(iniFile.Read("nudThread", null));
				bool flag = this.iMaxThread <= 0;
				bool flag2 = flag;
				if (flag2)
				{
					MessageBox.Show("Số luồng phải > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					this.iSoluotchay = Convert.ToInt32(iniFile.Read("nudSoLuotChay", null));
					this.iThoiGianChoNhapOtp = Convert.ToInt32(iniFile.Read("nudThoiGianChoNhapOTP", null));
					this.iModeRun = Convert.ToInt32(iniFile.Read("modeRun", null));
					this.iTypeOpenLD = Convert.ToInt32(iniFile.Read("optionMemu", null));
					this.iDelayFr = Convert.ToInt32(iniFile.Read("numDelayFr", null));
					this.iDelayTo = Convert.ToInt32(iniFile.Read("numDelayTo", null));
					this.iDelayClsFr = Convert.ToInt32(iniFile.Read("numDeClsFr", null));
					this.iDelayClsTo = Convert.ToInt32(iniFile.Read("numDeClsTo", null));
					this.iTypeChangeIp = Convert.ToInt32(iniFile.Read("typeChangeIp", null));
					this.pathLD = iniFile.Read("linkLD", null).ToString();
					this.sProfileNameDcom = iniFile.Read("txtProfileNameDcom", null).ToString();
					this.sTypeConfirmFB = iniFile.Read("typeVerify", null);
					this.PhoneCountry = Convert.ToInt32(iniFile.Read("cbbPhoneCountry", null));
					this.iTypeNameReg = Convert.ToInt32(iniFile.Read("typeNameReg", null));
					this.sPassFb = iniFile.Read("passFB", null).ToString();
					this.isPassRandom = Convert.ToBoolean(iniFile.Read("isRdPass", null));
					this.iGioiTinh = Convert.ToInt32(iniFile.Read("typeGender", null));
					this.ageFrom = Convert.ToInt32(iniFile.Read("ageFrom", null));
					this.ageTo = Convert.ToInt32(iniFile.Read("ageTo", null));
					this.isCreate2FA = Convert.ToBoolean(iniFile.Read("is2Fa", null));
					this.isUploadAvt = Convert.ToBoolean(iniFile.Read("isAvartar", null));
					this.isDoiAnhBia = Convert.ToBoolean(iniFile.Read("isCoverImg", null));
					this.isDoiNgonNgu = Convert.ToBoolean(iniFile.Read("isLanguage", null));
					this.isOnOff2FA = Convert.ToBoolean(iniFile.Read("is2Fa", null));
					this.sAPIProxyTinsoft = iniFile.Read("txtAPIProxy", null).ToString();
					this.iSoLuotDoiIpMotLan = Convert.ToInt32(iniFile.Read("iSoLuotDoiIpMotLan", null));
					this.isTaoMailBox = Convert.ToBoolean(iniFile.Read("ckTaoMailBox", null));
					this.sPassmail = iniFile.Read("txtPassmail", null);
					this.sAPISim = iniFile.Read("txtAPISim", null);
					this.sAnycaptcha = iniFile.Read("txtAPIAnyCat", null);
					this.inudLuongPerIPMinProxy = Convert.ToInt32(iniFile.Read("nudLuongPerIPMinProxy", null));
					this.linkAvartar = iniFile.Read("linkAvartar", null);
					this.linkCover = iniFile.Read("linkCover", null);
					bool flag3 = this.iSoluotchay == 0;
					if (flag3)
					{
						MessageBox.Show("Số lượt chạy > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						bool flag4 = !Directory.Exists(this.pathLD);
						if (flag4)
						{
							MessageBox.Show("Đường dẫn LDPlayer không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							bool @checked = this.chkAvartar.Checked;
							if (@checked)
							{
								bool flag5 = this.linkAvartar == string.Empty;
								if (flag5)
								{
									MessageBox.Show("Đường dẫn Folder avatar không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									return;
								}
							}
							bool flag6 = this.iTypeChangeIp == 2;
							if (flag6)
							{
								this.listApiTinsoft = TinsoftProxy.GetListKey(this.sAPIProxyTinsoft);
								bool flag7 = this.listApiTinsoft.Count == 0;
								if (flag7)
								{
									MessageBox.Show("Proxy Tinsoft không đủ, vui lòng mua thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									return;
								}
								this.listTinsoft = new List<TinsoftProxy>();
								this.inudLuongPerIPTinsoft = Convert.ToInt32(iniFile.Read("nudLuongPerIPTinsoft", null));
								this.cbLocationTinsoft = Convert.ToInt32(iniFile.Read("cbbLocationTinsoft", null));
								bool flag8 = this.inudLuongPerIPTinsoft == 0;
								if (flag8)
								{
									MessageBox.Show("Số luồng chạy proxy Tinsoft > 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									return;
								}
								for (int i = 0; i < this.listApiTinsoft.Count; i++)
								{
									TinsoftProxy item = new TinsoftProxy(this.listApiTinsoft[i], this.inudLuongPerIPTinsoft, this.cbLocationTinsoft);
									this.listTinsoft.Add(item);
								}
								bool flag9 = this.listApiTinsoft.Count * this.inudLuongPerIPTinsoft < this.iMaxThread;
								if (flag9)
								{
									this.iMaxThread = this.listApiTinsoft.Count * this.inudLuongPerIPTinsoft;
								}
							}
							else
							{
								bool flag10 = this.iTypeChangeIp == 1;
								if (flag10)
								{
									try
									{
										ProcessStartInfo startInfo = new ProcessStartInfo("rasdial.exe")
										{
											UseShellExecute = false,
											RedirectStandardOutput = true,
											CreateNoWindow = true
										};
										Process process = Process.Start(startInfo);
										string text = process.StandardOutput.ReadToEnd();
										bool flag11 = text.Split(new char[]
										{
											'\n'
										}).Length <= 3;
										if (flag11)
										{
											MessageBox.Show("Vui lòng kết nối Dcom trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
											return;
										}
									}
									catch (Exception ex)
									{
										MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										return;
									}
								}
								else
								{
									bool flag12 = this.iTypeChangeIp == 3;
									if (flag12)
									{
										bool flag13 = this.listProxyMinProxy.Count == 0;
										if (flag13)
										{
											MessageBox.Show("MinProxy không đủ, vui lòng mua thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
											return;
										}
										this.listMinProxy = new List<MinProxy>();
										for (int j = 0; j < this.listProxyMinProxy.Count; j++)
										{
											MinProxy item2 = new MinProxy(this.listProxyMinProxy[j], 0, this.inudLuongPerIPMinProxy);
											this.listMinProxy.Add(item2);
										}
										bool flag14 = this.listProxyMinProxy.Count * this.inudLuongPerIPMinProxy < this.iMaxThread;
										if (flag14)
										{
											this.iMaxThread = this.listProxyMinProxy.Count * this.inudLuongPerIPMinProxy;
										}
									}
								}
							}
							bool checked2 = this.rdHotMailRegisted.Checked;
							if (checked2)
							{
								this.lstHotmailDaReg = File.ReadAllLines("hotmail.txt").ToList<string>();
								this.lstHotmailDaReg = Common.RemoveEmptyItems(this.lstHotmailDaReg);
								bool flag15 = this.lstHotmailDaReg.Count <= 0 || this.lstHotmailDaReg.Count < this.iMaxThread;
								bool flag16 = flag15;
								if (flag16)
								{
									MessageBox.Show("Vui lòng nhập thêm hotmail đã đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
									return;
								}
							}
							int iCurThread = 0;
							this.isStop = false;
							bool isChangeIPSuccess = false;
							List<int> lstPossition = new List<int>();
							for (int k = 0; k < this.iMaxThread; k++)
							{
								lstPossition.Add(0);
							}
							this.OpenFormViewLD(false);
							for (int l = 0; l < this.iMaxThread; l++)
							{
								frmViewLD.remote.AddPanelDevice(l + 1);
							}
							MethodInvoker <>9__2;
							new Thread(delegate()
							{
								this.cControl("start");
								int num = 0;
								int num2 = this.iSoluotchay;
								bool flag17 = num2 == 0;
								if (flag17)
								{
									num2 = 1;
								}
								int m = 0;
								while (m < num2)
								{
									string str = (num2 > 1) ? string.Format("Lượt {0}/{1}. ", m + 1, num2) : "";
									bool flag18 = num2 > 1;
									if (flag18)
									{
										this.ShowTrangThai("Đang reg..." + str);
									}
									else
									{
										this.ShowTrangThai("Đang reg...");
									}
									Common.DelayTime(0.5);
									bool flag19 = this.isStop;
									bool flag20 = flag19;
									if (flag20)
									{
										break;
									}
									int num3 = 0;
									while (num3 < this.iMaxThread && !this.isStop)
									{
										bool flag21 = this.isStop;
										bool flag22 = flag21;
										if (flag22)
										{
											break;
										}
										bool flag23 = iCurThread < this.iMaxThread;
										bool flag24 = flag23;
										if (flag24)
										{
											Interlocked.Increment(ref iCurThread);
											int row = 0;
											this.dgvAcc.Invoke(new MethodInvoker(delegate()
											{
												row = this.dgvAcc.Rows.Add();
											}));
											num3++;
											Thread thread = new Thread(delegate()
											{
												try
												{
													bool flag33 = this.isStop;
													if (!flag33)
													{
														int indexOfPossitionApp = Common.GetIndexOfPossitionApp(ref lstPossition);
														this.ExcuteOneThread(row, indexOfPossitionApp + 1, false, this.pathLD);
														Common.FillIndexPossition(ref lstPossition, indexOfPossitionApp + 1);
														Interlocked.Decrement(ref iCurThread);
													}
												}
												catch
												{
													Interlocked.Decrement(ref iCurThread);
												}
											});
											thread.Name = row.ToString();
											this.listThread.Add(thread);
											Common.DelayTime(1.0);
											thread.Start();
										}
										else
										{
											for (int n = 0; n < this.listThread.Count<Thread>(); n++)
											{
												this.listThread[n].Join();
											}
											for (int num4 = 0; num4 < this.listThread.Count<Thread>(); num4++)
											{
												try
												{
													this.listThread[num4].Abort();
												}
												catch
												{
												}
											}
											this.listThread.Clear();
											iCurThread = 0;
										}
										bool flag25 = this.isStop;
										bool flag26 = flag25;
										if (flag26)
										{
											break;
										}
									}
									for (int num5 = 0; num5 < this.listThread.Count<Thread>(); num5++)
									{
										this.listThread[num5].Join();
									}
									for (int num6 = 0; num6 < this.listThread.Count<Thread>(); num6++)
									{
										this.listThread[num6].Abort();
									}
									this.listThread.Clear();
									num++;
									bool flag27 = !this.isStop && num >= this.iSoLuotDoiIpMotLan;
									bool flag28 = flag27 && (this.iTypeChangeIp == 1 || this.iTypeChangeIp == 4);
									if (flag28)
									{
										this.ShowTrangThai("Đang đổi IP...");
										bool isChangeIPSuccess = Common.ChangeIP(this.iTypeChangeIp, 0, this.sProfileNameDcom, "");
										num = 0;
										isChangeIPSuccess = isChangeIPSuccess;
										if (isChangeIPSuccess)
										{
											Control <>4__this = this;
											MethodInvoker method;
											if ((method = <>9__2) == null)
											{
												method = (<>9__2 = delegate()
												{
													this.stIPCur.Text = this.GetIp();
												});
											}
											<>4__this.Invoke(method);
										}
									}
									bool flag29 = m + 1 < num2;
									if (flag29)
									{
										int num7 = this.rd.Next(0, 10);
										int tickCount = Environment.TickCount;
										while ((Environment.TickCount - tickCount) / 1000 - num7 < 0)
										{
											this.ShowTrangThai(string.Format("Chạy lượt tiếp theo sau {time} giây...".Replace("{time}", (num7 - (Environment.TickCount - tickCount) / 1000).ToString()), Array.Empty<object>()));
											Common.DelayTime(0.5);
											bool isAutoClearLD = Settings.Default.isAutoClearLD;
											if (isAutoClearLD)
											{
												Common.ClearCacheLDPlayer(this.pathLD);
											}
											bool flag30 = this.isStop;
											if (flag30)
											{
												break;
											}
										}
									}
									bool flag31 = !this.isStop;
									if (flag31)
									{
										m++;
									}
									else
									{
										bool flag32 = this.isStop;
										if (flag32)
										{
											this.cControl("stop");
											break;
										}
									}
								}
								this.ShowTrangThai("Kết thúc đăng ký");
								this.CloseFormViewLD();
								this.cControl("stop");
								bool isAutoClearLD2 = Settings.Default.isAutoClearLD;
								if (isAutoClearLD2)
								{
									Common.ClearCacheLDPlayer(this.pathLD);
								}
								try
								{
									threadRefreshDeviceId.Abort();
								}
								catch
								{
								}
							}).Start();
						}
					}
				}
			}
			catch (Exception ex2)
			{
				this.ShowTrangThai("Lỗi: " + ex2.Message);
				this.cControl("stop");
				this.CloseFormViewLD();
				throw;
			}
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0001B2C8 File Offset: 0x000194C8
		private void ShowTrangThai(string content)
		{
			try
			{
				base.Invoke(new MethodInvoker(delegate()
				{
					this.plTrangThai.Text = content;
				}));
			}
			catch
			{
			}
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0001B318 File Offset: 0x00019518
		private void OpenFormViewLD(bool isRunSwap)
		{
			bool flag = !Common.CheckFormIsOpenning("frmViewLD");
			if (flag)
			{
				new frmViewLD
				{
					isRunSwap = false
				}.Show();
			}
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0001B34C File Offset: 0x0001954C
		public void SetCellAccount(int indexRow, string column, object value, bool isAllowEmptyValue = true)
		{
			bool flag = isAllowEmptyValue || !(value.ToString().Trim() == "");
			if (flag)
			{
				DatagridviewHelper.SetStatusDataGridView(this.dgvAcc, indexRow, column, value);
			}
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0001B390 File Offset: 0x00019590
		private void ExcuteOneThread(int indexRow, int indexPos, bool isRunSwap, string pathLD)
		{
			Device device = null;
			string text = null;
			TinsoftProxy tinsoftProxy = null;
			MinProxy minProxy = null;
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			bool flag = true;
			bool flag2 = false;
			this.LoadStatusGrid((indexRow + 1).ToString(), "cId", indexRow, 0, this.dgvAcc);
			bool flag3 = this.isStop;
			if (!flag3)
			{
				if (!isRunSwap)
				{
					bool flag4 = this.iTypeChangeIp == 2;
					if (flag4)
					{
						for (;;)
						{
							IL_9A:
							this.SetStatusAccount(indexRow, "Đang lấy proxy Tinsoft...", null);
							object obj = this.lock_StartProxy;
							object obj2 = obj;
							lock (obj2)
							{
								while (!this.isStop)
								{
									tinsoftProxy = null;
									while (!this.isStop)
									{
										bool flag6 = this.isStop;
										if (flag6)
										{
											goto IL_46E;
										}
										foreach (TinsoftProxy tinsoftProxy2 in this.listTinsoft)
										{
											bool flag7 = tinsoftProxy == null || tinsoftProxy2.daSuDung < tinsoftProxy.daSuDung;
											if (flag7)
											{
												tinsoftProxy = tinsoftProxy2;
											}
										}
										bool flag8 = tinsoftProxy.daSuDung != tinsoftProxy.limit_theads_use;
										if (flag8)
										{
											break;
										}
									}
									bool flag9 = !this.isStop;
									if (flag9)
									{
										bool flag10 = tinsoftProxy.daSuDung <= 0 && !tinsoftProxy.ChangeProxy();
										if (flag10)
										{
											continue;
										}
										text2 = tinsoftProxy.proxy;
										bool flag11 = text2 == "";
										if (flag11)
										{
											text2 = tinsoftProxy.GetProxy();
										}
										TinsoftProxy tinsoftProxy3 = tinsoftProxy;
										TinsoftProxy tinsoftProxy4 = tinsoftProxy3;
										int num = tinsoftProxy3.dangSuDung;
										tinsoftProxy4.dangSuDung = num + 1;
										tinsoftProxy3 = tinsoftProxy;
										TinsoftProxy tinsoftProxy5 = tinsoftProxy3;
										num = tinsoftProxy3.daSuDung;
										tinsoftProxy5.daSuDung = num + 1;
									}
									bool flag12 = this.isStop;
									if (flag12)
									{
										this.SetStatusAccount(indexRow, text3 + "Đã dừng...", null);
										return;
									}
									text3 = "(IP: " + text2.Split(new char[]
									{
										':'
									})[0] + ") ";
									this.SetStatusAccount(indexRow, text3 + "Check IP...", null);
									string text8 = Common.CheckProxy(text2, 0);
									bool flag13 = text8 == "";
									if (flag13)
									{
										flag = false;
									}
									bool flag14 = !flag;
									if (flag14)
									{
										TinsoftProxy tinsoftProxy3 = tinsoftProxy;
										TinsoftProxy tinsoftProxy6 = tinsoftProxy3;
										int num = tinsoftProxy3.dangSuDung;
										tinsoftProxy6.dangSuDung = num - 1;
										tinsoftProxy3 = tinsoftProxy;
										TinsoftProxy tinsoftProxy7 = tinsoftProxy3;
										num = tinsoftProxy3.daSuDung;
										tinsoftProxy7.daSuDung = num - 1;
										goto IL_9A;
									}
									text3 = "(IP: " + text8 + ") ";
									this.LoadStatusGrid(text8, "proxy", indexRow, 0, this.dgvAcc);
									this.SetStatusAccount(indexRow, text3 + "Check IP...", null);
									goto IL_758;
								}
							}
							break;
						}
					}
					else
					{
						bool flag15 = this.iTypeChangeIp == 3;
						if (flag15)
						{
							this.SetStatusAccount(indexRow, "Đang lấy Api MinProxy...", null);
							minProxy = null;
							flag2 = false;
							bool flag16 = this.listMinProxy.Count != 0;
							if (flag16)
							{
								object obj3 = this.lock_StartProxy;
								lock (obj3)
								{
									while (!this.isStop)
									{
										bool flag18 = this.isStop;
										if (flag18)
										{
											goto IL_46E;
										}
										foreach (MinProxy minProxy2 in this.listMinProxy)
										{
											bool flag19 = minProxy2.dangSuDung != 0;
											if (!flag19)
											{
												minProxy = minProxy2;
												break;
											}
											bool flag20 = minProxy == null || minProxy2.daSuDung < minProxy.daSuDung;
											if (flag20)
											{
												minProxy = minProxy2;
											}
										}
										bool flag21 = minProxy.daSuDung < minProxy.limit_theads_use;
										if (flag21)
										{
											break;
										}
									}
									bool flag22 = minProxy != null;
									if (flag22)
									{
										MinProxy minProxy3 = minProxy;
										MinProxy minProxy4 = minProxy3;
										MinProxy minProxy5 = minProxy4;
										int num = minProxy4.dangSuDung;
										minProxy5.dangSuDung = num + 1;
										minProxy3 = minProxy;
										minProxy4 = minProxy3;
										MinProxy minProxy6 = minProxy4;
										num = minProxy4.daSuDung;
										minProxy6.daSuDung = num + 1;
										goto IL_510;
									}
								}
							}
						}
					}
					IL_46E:
					bool flag23 = this.isStop;
					if (flag23)
					{
						this.SetStatusAccount(indexRow, text3 + "Đã dừng...", null);
						return;
					}
					bool flag24 = this.iTypeChangeIp == 3;
					if (flag24)
					{
						bool flag25 = !flag2;
						if (flag25)
						{
							object obj4 = this.lock_StartProxy;
							lock (obj4)
							{
								MinProxy minProxy7 = minProxy;
								MinProxy minProxy4 = minProxy7;
								MinProxy minProxy8 = minProxy4;
								int num = minProxy4.dangSuDung;
								minProxy8.dangSuDung = num - 1;
								minProxy7 = minProxy;
								minProxy4 = minProxy7;
								MinProxy minProxy9 = minProxy4;
								num = minProxy4.daSuDung;
								minProxy9.daSuDung = num - 1;
							}
						}
					}
					IL_510:
					bool flag27 = this.isStop;
					if (flag27)
					{
						this.SetStatusAccount(indexRow, text3 + "Đã dừng...", null);
						return;
					}
					bool flag28 = this.iTypeChangeIp == 3;
					if (flag28)
					{
						this.SetStatusAccount(indexRow, "Đang lấy Proxy từ API...", null);
						bool flag29 = minProxy.daSuDung > 1;
						if (flag29)
						{
							text2 = minProxy.GetProxy();
						}
						else
						{
							for (;;)
							{
								switch (minProxy.ChangeProxy())
								{
								case -2:
									goto IL_623;
								case -1:
									goto IL_666;
								case 0:
								{
									this.SetStatusAccount(indexRow, "Đang lấy Proxy từ API: Chờ " + minProxy.next_change.ToString() + " s", null);
									bool flag30 = minProxy.next_change > 10;
									if (flag30)
									{
										Common.DelayTime(10.0);
									}
									else
									{
										bool flag31 = minProxy.next_change > 0;
										if (flag31)
										{
											Common.DelayTime((double)minProxy.next_change);
										}
									}
									break;
								}
								case 1:
									text2 = minProxy.proxy;
									break;
								}
								bool flag32 = !(text2 != "");
								if (!flag32)
								{
									goto IL_6C4;
								}
							}
							IL_623:
							this.SetStatusAccount(indexRow, "Api không đúng", null);
							object obj5 = this.lock_StartProxy;
							lock (obj5)
							{
								this.listMinProxy.Remove(minProxy);
							}
							goto IL_6A9;
							IL_666:
							this.SetStatusAccount(indexRow, "Api hết hạn", null);
							object obj6 = this.lock_StartProxy;
							lock (obj6)
							{
								this.listMinProxy.Remove(minProxy);
							}
							IL_6A9:
							IL_6C4:;
						}
						bool flag35 = !(text2 == "");
						if (flag35)
						{
							text3 = "(IP: " + text2.Split(new char[]
							{
								':'
							})[0] + ") ";
							this.LoadStatusGrid(text2, "proxy", indexRow, 0, this.dgvAcc);
							this.SetStatusAccount(indexRow, text3 + "Check IP...", null);
							string a = Common.CheckProxy(text2, 0);
							bool flag36 = a == "";
							if (flag36)
							{
								flag2 = false;
							}
						}
					}
					IL_758:
					bool flag37 = this.isStop;
					if (flag37)
					{
						this.SetStatusAccount(indexRow, text3 + "Đã dừng...", null);
						return;
					}
					string text9 = this.GetCellAccount(indexRow, "cDevice");
					bool flag38 = text9 == "" || !Directory.Exists(pathLD + "\\vms\\leidian" + text9);
					if (flag38)
					{
						bool flag39 = this.isStop;
						if (flag39)
						{
							this.SetStatusAccount(indexRow, text3 + "Đã dừng...", null);
							return;
						}
						this.SetStatusAccount(indexRow, text3 + "Tạo thiết bị, chờ đến lượt...", null);
						object obj7 = this.lock_checkDelayCreateDevice;
						object obj8 = obj7;
						lock (obj8)
						{
							this.SetStatusAccount(indexRow, text3 + "Tạo thiết bị...", null);
							List<string> listIndexLDPlayer = ADBHelper.GetListIndexLDPlayer(pathLD);
							ADBHelper.AddDevice(pathLD);
							int num;
							for (int i = 0; i < 30; i = num + 1)
							{
								bool flag41 = this.isStop;
								if (flag41)
								{
									this.SetStatusAccount(indexRow, text3 + "Đã dừng...", null);
									return;
								}
								text9 = ADBHelper.GetListIndexLDPlayer(pathLD).Except(listIndexLDPlayer).First<string>();
								bool flag42 = text9 != "";
								if (flag42)
								{
									break;
								}
								num = i;
							}
							bool flag43 = text9 == "";
							if (flag43)
							{
								this.SetStatusAccount(indexRow, text3 + "Tạo thiết bị thất bại!", null);
								this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
							}
						}
						device = new Device(pathLD, text9, this.linkAvartar);
						this.SetCellAccount(indexRow, "cDevice", text9, true);
						device.ChangeHardwareLDPlayer2();
					}
					else
					{
						device = new Device(pathLD, text9 ?? "", this.linkAvartar);
						device.PathLDPlayer = pathLD;
						device.ChangeHardwareLDPlayer2();
					}
				}
				device.ChangeFileConfig();
				this.SetStatusAccount(indexRow, text3 + "Chờ đến lượt...", null);
				object obj9 = this.lock_checkDelayLD_MoLDPLayer;
				object obj10 = obj9;
				lock (obj10)
				{
					bool flag45 = this.iTypeOpenLD == 0;
					if (flag45)
					{
						while (this.isOpeningDevice_MoLDPLayer)
						{
							Common.DelayTime(0.5);
							bool flag46 = this.isStop;
							if (flag46)
							{
								this.SetStatusAccount(indexRow, text3 + "Đã dừng...", null);
								goto IL_AD9;
							}
						}
						this.isOpeningDevice_MoLDPLayer = true;
					}
					else
					{
						bool flag47 = this.checkDelayLD_MoLDPLayer > 0;
						if (flag47)
						{
							int num2 = this.rd.Next(this.iDelayFr, this.iDelayTo);
							bool flag48 = num2 > 0;
							if (flag48)
							{
								int tickCount = Environment.TickCount;
								while ((Environment.TickCount - tickCount) / 1000 - num2 < 0)
								{
									this.SetStatusAccount(indexRow, text3 + "Mở thiết bị sau {time}s...".Replace("{time}", (num2 - (Environment.TickCount - tickCount) / 1000).ToString()), null);
									Common.DelayTime(0.5);
									bool flag49 = this.isStop;
									if (flag49)
									{
										this.SetStatusAccount(indexRow, text3 + "Đã dừng...", null);
										break;
									}
								}
							}
						}
						else
						{
							int num = this.checkDelayLD_MoLDPLayer;
							this.checkDelayLD_MoLDPLayer = num + 1;
						}
					}
				}
				IL_AD9:
				bool flag50 = this.isStop;
				if (flag50)
				{
					this.SetStatusAccount(indexRow, text3 + "Đã dừng...", null);
				}
				else
				{
					this.SetStatusAccount(indexRow, text3 + "Mở thiết bị...", null);
					device.Open(120);
					bool flag51 = device.process == null;
					if (flag51)
					{
						this.SetStatusAccount(indexRow, text3 + "Lỗi mở thiết bị", null);
						this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
					}
					else
					{
						bool flag52 = this.isStop;
						if (flag52)
						{
							this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
						}
						else
						{
							string deviceModelName = device.getDeviceModelName();
							frmViewLD.remote.AddLDIntoPanel(device.process.MainWindowHandle, device.IndexDevice, indexRow + 1, deviceModelName);
							bool flag53 = this.isStop;
							if (!flag53)
							{
								bool flag54 = !device.CheckOpenedDevice(60);
								if (flag54)
								{
									this.SetStatusAccount(indexRow, text3 + "Lỗi mở thiết bị", null);
									this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
								}
								else
								{
									this.SetStatusAccount(indexRow, text3 + "Mở thiết bị thành công", device);
									this.lstDevice.Add(device);
									this.Delay(5.0);
									bool flag55 = this.isStop;
									if (!flag55)
									{
										text = ADBHelper.GetDeviceByIndex(device.IndexDevice);
										device.DeviceId = text;
										device.lstPackages = device.GetListPackages();
										bool flag56 = false;
										bool flag57 = !device.lstPackages.Contains("com.facebook.katana") && !device.lstPackages.Contains("com.android.adbkeyboard");
										if (flag57)
										{
											bool flag58 = this.isStop;
											if (flag58)
											{
												return;
											}
											this.SetStatusAccount(indexRow, text3 + "Kiểm tra App cần cài đặt", device);
											this.Delay(1.0);
											bool flag59 = device.lstPackages.Contains("com.facebook.katana");
											if (!flag59)
											{
												bool flag60 = !device.lstPackages.Contains("com.facebook.katana");
												if (flag60)
												{
													this.SetStatusAccount(indexRow, text3 + "Cài đặt App Facebook...", device);
													for (;;)
													{
														bool flag61 = this.isStop;
														if (flag61)
														{
															break;
														}
														flag56 = device.InstallApp(FileHelper.GetPathToCurrentFolder() + "\\app\\facebook.apk");
														bool flag62 = flag56;
														if (flag62)
														{
															goto Block_41;
														}
													}
													return;
													Block_41:;
												}
												bool flag63 = device.lstPackages.Contains("com.android.adbkeyboard");
												if (!flag63)
												{
													bool flag64 = !device.lstPackages.Contains("com.android.adbkeyboard");
													if (flag64)
													{
														this.SetStatusAccount(indexRow, text3 + "Cài đặt App Keyboard...", device);
														for (;;)
														{
															bool flag65 = this.isStop;
															if (flag65)
															{
																break;
															}
															flag56 = device.InstallApp(FileHelper.GetPathToCurrentFolder() + "\\app\\ADBKeyboard.apk");
															bool flag66 = flag56;
															if (flag66)
															{
																goto Block_45;
															}
														}
														return;
														Block_45:;
													}
												}
											}
										}
										bool flag67 = !flag56;
										if (flag67)
										{
											this.SetStatusAccount(indexRow, text3 + "Cài đặt các ứng dụng không thành công", device);
											this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
										}
										else
										{
											bool isOnGPSLD = Settings.Default.isOnGPSLD;
											if (isOnGPSLD)
											{
												device.ExecuteCMD("shell settings put secure location_providers_allowed +gps", 10);
											}
											else
											{
												device.ExecuteCMD("shell settings put secure location_providers_allowed -gps", 10);
											}
											device.RemoveProxy();
											bool flag68 = this.isStop;
											if (flag68)
											{
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
											}
											else
											{
												bool flag69 = text2 != "";
												if (flag69)
												{
													device.LoadStatusLD("Đang kết nối proxy...");
													this.SetStatusAccount(indexRow, text3 + " Đang kết nối proxy...", null);
													bool flag70 = text2.Split(new char[]
													{
														':'
													}).Length == 2;
													if (flag70)
													{
														device.ConnectProxy(text2);
														device.DelayTime(5.0);
													}
												}
												string html;
												bool flag73;
												for (;;)
												{
													IL_EE9:
													this.SetStatusAccount(indexRow, text3 + "Mở App Facebook", device);
													bool flag71 = device.OpenAppFacebook1(180);
													bool flag72 = flag71;
													if (!flag72)
													{
														goto IL_6100;
													}
													html = string.Empty;
													flag73 = false;
													bool flag74 = false;
													bool @checked = this.rdThuePhone.Checked;
													if (@checked)
													{
														bool flag75 = this.sTypeConfirmFB.Substring(2, 1) == "3" || this.sTypeConfirmFB.Substring(2, 1) == "2";
														if (flag75)
														{
															flag74 = true;
														}
													}
													bool flag76 = this.isStop;
													if (flag76)
													{
														break;
													}
													this.SetStatusAccount(indexRow, text3 + "Đăng ký Facebook", device);
													bool flag77 = false;
													int num3 = 0;
													if (num3 < 5)
													{
														bool flag78 = device.TapByImage("DataClick\\image\\createaccount", null, 30);
														if (flag78)
														{
															flag73 = true;
														}
														else
														{
															flag73 = true;
															flag77 = true;
														}
													}
													bool flag79 = flag77;
													if (flag79)
													{
														ADBHelper.TapByPercent(text, 47.8, 86.9, 1);
													}
													bool flag80 = !flag73;
													if (flag80)
													{
														goto Block_58;
													}
													bool flag81 = this.isStop;
													if (flag81)
													{
														goto Block_59;
													}
													int j = 0;
													int num;
													while (j < 20)
													{
														html = device.GetHtml();
														bool flag82 = device.GetListText(html, 0).Count != 1;
														if (flag82)
														{
															bool flag83 = device.CheckExistText("join facebook", html, 0.0) || device.CheckExistText("tham gia facebook", html, 0.0);
															if (!flag83)
															{
																flag73 = false;
																break;
															}
															bool flag84 = this.isStop;
															if (flag84)
															{
																goto Block_63;
															}
															flag73 = true;
															bool flag85 = device.CheckExistText("\"next\"", html, 0.0);
															if (flag85)
															{
																device.TapByText("\"next\"", "", 10);
															}
															else
															{
																device.TapByText("\"tiếp\"", "", 10);
															}
															break;
														}
														else
														{
															num = j;
															j = num + 1;
														}
													}
													bool flag86 = !flag73;
													if (flag86)
													{
														goto Block_65;
													}
													bool flag87 = this.isStop;
													if (flag87)
													{
														goto Block_66;
													}
													this.SetStatusAccount(indexRow, text3 + "Tạo thông tin đăng ký", device);
													string text10 = "";
													string text11 = "";
													string text12 = "";
													string apiKey = "";
													string idRequest = "";
													string a2 = this.rd.Next(0, 2).ToString();
													bool flag88 = this.iGioiTinh == 0;
													if (flag88)
													{
														a2 = "0";
													}
													else
													{
														bool flag89 = this.iGioiTinh == 1;
														if (flag89)
														{
															a2 = "1";
														}
													}
													bool flag90 = this.iTypeNameReg == 0;
													if (flag90)
													{
														text10 = this.GetLastnameVN();
														bool flag91 = a2 == "0";
														if (flag91)
														{
															text11 = this.GetFirstnameFemaleVN();
														}
														else
														{
															text11 = this.GetFirstnamemaleVN();
														}
													}
													else
													{
														bool flag92 = this.iTypeNameReg == 1;
														if (flag92)
														{
															text10 = this.GetLastnameUs();
															bool flag93 = a2 == "0";
															if (flag93)
															{
																text11 = this.GetFirstnameFemaleUs();
															}
															else
															{
																text11 = this.GetFirstnamemaleUs();
															}
														}
													}
													bool flag94 = this.isPassRandom;
													if (flag94)
													{
														text12 = Common.CreateRandomPassword(text11 + text10);
													}
													else
													{
														text12 = this.sPassFb;
													}
													bool flag95 = this.isStop;
													if (flag95)
													{
														goto Block_74;
													}
													this.LoadStatusGrid(text10, "ho", indexRow, 0, this.dgvAcc);
													this.LoadStatusGrid(text11, "ten", indexRow, 0, this.dgvAcc);
													this.LoadStatusGrid((a2 == "1") ? "Nam" : "Nữ", "gender", indexRow, 0, this.dgvAcc);
													this.LoadStatusGrid(text12, "pass", indexRow, 0, this.dgvAcc);
													apiKey = this.sAPISim;
													int k = 0;
													while (k < 5)
													{
														bool flag96 = this.isStop;
														if (flag96)
														{
															goto Block_76;
														}
														html = device.GetHtml();
														bool flag97 = device.GetListText(html, 0).Count != 1;
														if (flag97)
														{
															bool flag98 = device.CheckExistText("enter the name you use in real life.", html, 0.0) || device.CheckExistText("nhập tên bạn sử dụng trong đời thực", html, 0.0);
															if (flag98)
															{
																flag73 = true;
																this.SetStatusAccount(indexRow, text3 + "Nhập tên", device);
																device.DelayTime(1.0);
																device.InputTextWithUnicode(text11, 0.0);
																device.DelayTime(1.0);
																this.SetStatusAccount(indexRow, text3 + "Nhập họ...", device);
																device.DelayTime(1.0);
																bool flag99 = device.CheckExistText("\"last name\"", html, 0.0);
																if (flag99)
																{
																	device.TapByText("\"last name\"", "", 10);
																}
																else
																{
																	bool flag100 = device.CheckExistImage("DataClick\\image\\ten", null, 30);
																	if (flag100)
																	{
																		device.TapByImage("DataClick\\image\\ten", null, 30);
																	}
																	else
																	{
																		ADBHelper.TapByPercent(text, 59.5, 42.9, 1);
																	}
																}
																device.DelayTime(1.0);
																device.InputTextWithUnicode(text10, 0.0);
																device.DelayTime(1.0);
																bool flag101 = device.CheckExistText("\"next\"", html, 0.0);
																if (flag101)
																{
																	device.TapByText("\"next\"", "", 10);
																}
																else
																{
																	device.TapByText("\"tiếp\"", "", 10);
																}
																break;
															}
															flag73 = false;
															break;
														}
														else
														{
															num = k;
															k = num + 1;
														}
													}
													bool flag102 = !flag73;
													if (flag102)
													{
														goto Block_83;
													}
													bool flag103 = this.isStop;
													if (flag103)
													{
														goto Block_84;
													}
													int l = 0;
													while (l < 5)
													{
														html = device.GetHtml();
														bool flag104 = device.GetListText(html, 0).Count != 1;
														if (flag104)
														{
															bool flag105 = device.CheckExistText("what's your birthday", html, 0.0) || device.CheckExistText("sinh nhật của bạn khi nào?", html, 0.0);
															if (!flag105)
															{
																flag73 = false;
																break;
															}
															bool flag106 = this.isStop;
															if (flag106)
															{
																goto Block_88;
															}
															this.SetStatusAccount(indexRow, text3 + "Chọn ngày tháng năm sinh...", device);
															bool flag107 = this.isStop;
															if (flag107)
															{
																goto Block_89;
															}
															flag73 = true;
															bool flag108 = device.CheckExistText("\"select birthday\"", html, 0.0);
															if (flag108)
															{
																device.TapByText("\"select birthday\"", html, 10);
															}
															else
															{
																device.TapByText("\"chọn ngày sinh\"", html, 10);
															}
															device.DelayTime(1.0);
															bool flag109 = this.isStop;
															if (flag109)
															{
																goto Block_91;
															}
															break;
														}
														else
														{
															num = l;
															l = num + 1;
														}
													}
													bool flag110 = flag73;
													if (flag110)
													{
														int num4 = this.rd.Next(60, 100);
														ADBHelper.SwipeByPercent(text, 35.0, 50.0, 35.0, (double)num4, 100);
														device.DelayTime(1.0);
														bool flag111 = this.isStop;
														if (flag111)
														{
															goto Block_93;
														}
														ADBHelper.SwipeByPercent(text, 50.0, 51.6, 50.0, (double)num4, 100);
														device.DelayTime(1.0);
														bool flag112 = this.isStop;
														if (flag112)
														{
															goto Block_94;
														}
														int num5 = this.rd.Next(400, 600);
														ADBHelper.SwipeByPercent(text, 64.0, 51.0, 64.0, (double)num5, 100);
														device.DelayTime(1.0);
														bool flag113 = this.isStop;
														if (flag113)
														{
															goto Block_95;
														}
														ADBHelper.TapByPercent(text, 83.3, 69.7, 1);
														device.DelayTime(1.0);
														bool flag114 = device.CheckExistText("\"next\"", html, 0.0);
														if (flag114)
														{
															device.TapByText("\"next\"", "", 10);
														}
														else
														{
															device.TapByText("\"tiếp\"", "", 10);
														}
														flag73 = true;
													}
													bool flag115 = !flag73;
													if (flag115)
													{
														goto Block_97;
													}
													bool flag116 = this.isStop;
													if (flag116)
													{
														goto Block_98;
													}
													int m = 0;
													while (m < 5)
													{
														html = device.GetHtml();
														bool flag117 = device.GetListText(html, 0).Count != 1;
														if (flag117)
														{
															bool flag118 = device.CheckExistText("what's your gender?", html, 0.0) || device.CheckExistText("giới tính của bạn là gì?", html, 0.0);
															if (!flag118)
															{
																flag73 = false;
																break;
															}
															bool flag119 = this.isStop;
															if (flag119)
															{
																goto Block_102;
															}
															this.SetStatusAccount(indexRow, text3 + "Chọn giới tính...", device);
															bool flag120 = a2 == "0";
															if (flag120)
															{
																bool flag121 = device.CheckExistImage("DataClick\\image\\female", null, 30);
																if (flag121)
																{
																	device.TapByImage("DataClick\\image\\female", null, 30);
																}
																else
																{
																	ADBHelper.TapByPercent(text, 19.0, 38.5, 1);
																}
															}
															else
															{
																bool flag122 = a2 == "1";
																if (flag122)
																{
																	bool flag123 = device.CheckExistImage("DataClick\\image\\male", null, 30);
																	if (flag123)
																	{
																		device.TapByImage("DataClick\\image\\male", null, 30);
																	}
																	else
																	{
																		ADBHelper.TapByPercent(text, 24.0, 46.2, 1);
																	}
																}
															}
															flag73 = true;
															device.DelayTime(1.0);
															bool flag124 = device.CheckExistText("\"next\"", html, 0.0);
															if (flag124)
															{
																device.TapByText("\"next\"", "", 10);
															}
															else
															{
																device.TapByText("\"tiếp\"", "", 10);
															}
															break;
														}
														else
														{
															num = m;
															m = num + 1;
														}
													}
													bool flag125 = !flag73;
													if (flag125)
													{
														goto Block_108;
													}
													bool flag126 = this.isStop;
													if (flag126)
													{
														goto Block_109;
													}
													for (int n = 0; n < 5; n = num + 1)
													{
														html = device.GetHtml();
														bool flag127 = device.GetListText(html, 0).Count != 1;
														if (flag127)
														{
															bool flag128 = device.CheckExistText("enter your mobile number", html, 0.0) || device.CheckExistText("nhập số di động của bạn", html, 0.0);
															if (flag128)
															{
																bool flag129 = this.isStop;
																if (flag129)
																{
																	goto Block_113;
																}
																bool flag130 = this.sTypeConfirmFB.Substring(0, 1) == "0";
																if (flag130)
																{
																	bool flag131 = this.isStop;
																	if (flag131)
																	{
																		goto Block_115;
																	}
																	bool flag132 = this.sTypeConfirmFB.Substring(1, 1) == "0";
																	if (flag132)
																	{
																		bool flag133 = this.isStop;
																		if (flag133)
																		{
																			goto Block_117;
																		}
																		this.SetStatusAccount(indexRow, text3 + "Đang tạo số điện thoại ảo....", device);
																		ADBHelper.TapByPercent(text, 92.2, 43.6, 1);
																		string randomPhoneCountry = this.GetRandomPhoneCountry(this.PhoneCountry);
																		bool flag134 = randomPhoneCountry == string.Empty;
																		if (flag134)
																		{
																			goto Block_118;
																		}
																		this.Delay(2.0);
																		flag73 = true;
																		this.SetStatusAccount(indexRow, text3 + "Số điện thoại ảo:" + randomPhoneCountry, device);
																		this.LoadStatusGrid(randomPhoneCountry, "phone", indexRow, 0, this.dgvAcc);
																		device.InputTextWithUnicode(randomPhoneCountry, 0.0);
																	}
																	else
																	{
																		bool flag135 = this.isStop;
																		if (flag135)
																		{
																			goto Block_119;
																		}
																		ADBHelper.TapByPercent(text, 52.2, 96.7, 1);
																		this.Delay(2.0);
																		this.SetStatusAccount(indexRow, text3 + "Đang tạo Email ảo....", device);
																		string emailUsingFirst_LastName = this.GetEmailUsingFirst_LastName(text11, text10, Convert.ToInt32(this.sTypeConfirmFB.Substring(2, 1)));
																		bool flag136 = emailUsingFirst_LastName == string.Empty;
																		if (flag136)
																		{
																			this.SetStatusAccount(indexRow, text3 + "Không tạo được email ảo...", device);
																			this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																			flag73 = false;
																		}
																		else
																		{
																			this.Delay(2.0);
																			flag73 = true;
																			this.SetStatusAccount(indexRow, text3 + "Email ảo:" + emailUsingFirst_LastName, device);
																			this.LoadStatusGrid(emailUsingFirst_LastName, "email", indexRow, 0, this.dgvAcc);
																			device.InputTextWithUnicode(emailUsingFirst_LastName, 0.0);
																		}
																	}
																}
																else
																{
																	bool flag137 = this.isStop;
																	if (flag137)
																	{
																		goto Block_121;
																	}
																	bool checked2 = this.rdThuePhone.Checked;
																	if (!checked2)
																	{
																		goto IL_21EC;
																	}
																	bool flag138 = this.isStop;
																	if (flag138)
																	{
																		goto Block_123;
																	}
																	try
																	{
																		bool flag139 = this.isStop;
																		if (flag139)
																		{
																			this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																			return;
																		}
																		for (;;)
																		{
																			this.SetStatusAccount(indexRow, text3 + "Đang lấy số điện thoại....", device);
																			ADBHelper.TapByPercent(text, 92.2, 43.6, 1);
																			this.Delay(1.0);
																			bool flag140 = this.sTypeConfirmFB.Substring(2, 1) == "0";
																			if (flag140)
																			{
																				text4 = Common.GetPhoneSimThue(apiKey, ref idRequest, 60, 1001);
																			}
																			else
																			{
																				bool flag141 = this.sTypeConfirmFB.Substring(2, 1) == "1";
																				if (flag141)
																				{
																					text4 = Common.GetPhoneViotp(apiKey, ref idRequest, 60, 7);
																				}
																				else
																				{
																					bool flag142 = this.sTypeConfirmFB.Substring(2, 1) == "2";
																					if (flag142)
																					{
																						text4 = Common.GetPhoneTextNow(apiKey, ref idRequest, 60, 1);
																					}
																					else
																					{
																						bool flag143 = this.sTypeConfirmFB.Substring(2, 1) == "3";
																						if (flag143)
																						{
																							text4 = Common.GetPhoneOtpmmo(apiKey, 60);
																							text7 = text4;
																						}
																					}
																				}
																			}
																			bool flag144 = this.isStop;
																			if (flag144)
																			{
																				break;
																			}
																			bool flag145 = text4 == "";
																			if (!flag145)
																			{
																				goto IL_20A5;
																			}
																			this.SetStatusAccount(indexRow, text3 + "Không lấy được số điện thoại. Lấy số khác!!!", device);
																			device.DelayTime(2.0);
																		}
																		this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																		return;
																		IL_20A5:
																		bool flag146 = this.isStop;
																		if (flag146)
																		{
																			this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																			return;
																		}
																		bool flag147 = this.sTypeConfirmFB.Substring(2, 1) == "0" || this.sTypeConfirmFB.Substring(2, 1) == "1";
																		if (flag147)
																		{
																			text4 = "+84" + text4;
																		}
																		bool flag148 = this.sTypeConfirmFB.Substring(2, 1) == "2" || this.sTypeConfirmFB.Substring(2, 1) == "3";
																		if (flag148)
																		{
																			text4 = "+1" + text4;
																		}
																		this.SetStatusAccount(indexRow, text3 + "Số điện thoại:" + text4, device);
																		this.LoadStatusGrid(text4, "phone", indexRow, 0, this.dgvAcc);
																		this.Delay(1.0);
																		bool flag149 = this.isStop;
																		if (flag149)
																		{
																			return;
																		}
																		device.InputTextWithUnicode(text4, 0.0);
																		goto IL_24ED;
																	}
																	catch
																	{
																		this.SetStatusAccount(indexRow, text3 + "Không lấy được số điện thoại. Kiểm tra trên web nha", device);
																		this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																		return;
																	}
																	goto IL_21EC;
																	IL_24ED:
																	bool flag150 = this.isStop;
																	if (flag150)
																	{
																		goto Block_136;
																	}
																	bool flag151 = device.CheckExistText("\"next\"", html, 0.0);
																	if (flag151)
																	{
																		device.TapByText("\"next\"", "", 10);
																	}
																	else
																	{
																		device.TapByText("\"tiếp\"", "", 10);
																	}
																	int num6 = 0;
																	while (num6 < 5)
																	{
																		html = device.GetHtml();
																		bool flag152 = device.GetListText(html, 0).Count != 1;
																		if (flag152)
																		{
																			bool flag153 = device.CheckExistText("choose a password", html, 0.0) || device.CheckExistText("chọn mật khẩu", html, 0.0);
																			if (!flag153)
																			{
																				flag73 = false;
																				break;
																			}
																			bool flag154 = this.isStop;
																			if (flag154)
																			{
																				goto Block_141;
																			}
																			flag73 = true;
																			this.SetStatusAccount(indexRow, text3 + "Nhập mật khẩu...", device);
																			device.InputTextWithUnicode(text12, 0.0);
																			bool flag155 = device.CheckExistText("\"next\"", html, 0.0);
																			if (flag155)
																			{
																				device.TapByText("\"next\"", "", 10);
																			}
																			else
																			{
																				device.TapByText("\"tiếp\"", "", 10);
																			}
																			break;
																		}
																		else
																		{
																			num = num6;
																			num6 = num + 1;
																		}
																	}
																	bool flag156 = !flag73;
																	if (flag156)
																	{
																		goto Block_143;
																	}
																	bool flag157 = this.isStop;
																	if (flag157)
																	{
																		goto Block_144;
																	}
																	int num7 = 0;
																	while (num7 < 5)
																	{
																		html = device.GetHtml();
																		bool flag158 = device.GetListText(html, 0).Count != 1;
																		if (flag158)
																		{
																			bool flag159 = device.CheckExistText("finish signing up", html, 0.0) || device.CheckExistText("hoàn tất đăng ký", html, 0.0);
																			if (!flag159)
																			{
																				flag73 = false;
																				break;
																			}
																			bool flag160 = this.isStop;
																			if (flag160)
																			{
																				goto Block_148;
																			}
																			flag73 = true;
																			this.SetStatusAccount(indexRow, text3 + "Đăng ký...", device);
																			device.DelayTime(2.0);
																			bool flag161 = device.CheckExistText("\"sign up\"", html, 0.0);
																			if (flag161)
																			{
																				device.TapByText("\"sign up\"", "", 10);
																			}
																			else
																			{
																				device.TapByText("\"đăng ký\"", "", 10);
																			}
																			break;
																		}
																		else
																		{
																			num = num7;
																			num7 = num + 1;
																		}
																	}
																	bool flag162 = !flag73;
																	if (flag162)
																	{
																		goto Block_150;
																	}
																	bool flag163 = this.isStop;
																	if (flag163)
																	{
																		goto Block_151;
																	}
																	device.DelayTime(30.0);
																	for (;;)
																	{
																		IL_28AD:
																		this.SetStatusAccount(indexRow, text3 + "Check status đăng ký...", device);
																		for (int num8 = 0; num8 < 10; num8 = num + 1)
																		{
																			bool flag164 = this.isStop;
																			if (flag164)
																			{
																				goto Block_152;
																			}
																			html = device.GetHtml();
																			bool flag165 = device.GetListText(html, 0).Count != 1;
																			if (flag165)
																			{
																				bool flag166 = this.isStop;
																				if (flag166)
																				{
																					goto Block_154;
																				}
																				bool flag167 = device.CheckExistText("bạn đã có tài khoản facebook chưa?", html, 0.0) || device.CheckExistText("do you already have a facebook account?", html, 0.0);
																				if (flag167)
																				{
																					bool flag168 = device.CheckExistText("no, create new account", html, 0.0);
																					if (flag168)
																					{
																						device.TapByText("no, create new account", "", 10);
																					}
																					else
																					{
																						device.TapByText("không, tạo tài khoản mới", "", 10);
																					}
																					goto IL_28AD;
																				}
																				bool flag169 = device.CheckExistText("use a different name", html, 0.0) || device.CheckExistText("chọn tên của bạn", html, 0.0);
																				if (flag169)
																				{
																					goto Block_159;
																				}
																				bool flag170 = device.CheckExistText("next time, log in with one tap", html, 0.0) || device.CheckExistText("lần sau, đăng nhập bằng một lần nhấn", html, 0.0);
																				if (flag170)
																				{
																					goto Block_161;
																				}
																				bool flag171 = device.CheckExistText("enter your mobile number", html, 0.0) || device.CheckExistText("nhập số di động của bạn", html, 0.0);
																				if (flag171)
																				{
																					goto Block_164;
																				}
																				bool flag174;
																				for (;;)
																				{
																					IL_2B97:
																					bool flag172 = device.CheckExistText("do you already have a facebook account?", html, 0.0) || device.CheckExistText("bạn đã có tài khoản facebook chưa?", html, 0.0);
																					if (!flag172)
																					{
																						break;
																					}
																					bool flag173 = this.isStop;
																					if (flag173)
																					{
																						goto Block_167;
																					}
																					flag174 = false;
																					ADBHelper.TapByPercent(text, 47.4, 54.7, 1);
																					this.Delay(1.0);
																					int num9 = 0;
																					while (num9 < 5)
																					{
																						bool flag175 = false;
																						html = device.GetHtml();
																						bool flag176 = device.CheckExistText("enter your mobile number", html, 0.0) || device.CheckExistText("nhập số di động của bạn", html, 0.0);
																						if (flag176)
																						{
																							this.SetStatusAccount(indexRow, text3 + "Đang lấy số điện thoại khác...", device);
																							bool flag177 = this.sTypeConfirmFB.Substring(2, 1) == "0";
																							if (flag177)
																							{
																								text4 = Common.GetPhoneSimThue(apiKey, ref idRequest, 60, 1001);
																							}
																							else
																							{
																								bool flag178 = this.sTypeConfirmFB.Substring(2, 1) == "1";
																								if (flag178)
																								{
																									text4 = Common.GetPhoneViotp(apiKey, ref idRequest, 60, 7);
																								}
																								else
																								{
																									bool flag179 = this.sTypeConfirmFB.Substring(2, 1) == "2";
																									if (flag179)
																									{
																										text4 = Common.GetPhoneTextNow(apiKey, ref idRequest, 60, 1);
																									}
																									else
																									{
																										bool flag180 = this.sTypeConfirmFB.Substring(2, 1) == "3";
																										if (flag180)
																										{
																											text4 = Common.GetPhoneOtpmmo(apiKey, 60);
																											text7 = text4;
																										}
																									}
																								}
																							}
																							bool flag181 = text4 == "";
																							if (flag181)
																							{
																								bool flag182 = this.isStop;
																								if (flag182)
																								{
																									goto Block_175;
																								}
																								this.SetStatusAccount(indexRow, text3 + "Không lấy được số điện thoại. Kiểm tra trên web nha!", device);
																								this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																								device.GotoNewFeedQuick();
																							}
																							else
																							{
																								flag175 = true;
																								bool flag183 = this.sTypeConfirmFB.Substring(2, 1) == "0" || this.sTypeConfirmFB.Substring(2, 1) == "1";
																								if (flag183)
																								{
																									text4 = "+84" + text4;
																								}
																								bool flag184 = this.sTypeConfirmFB.Substring(2, 1) == "2" || this.sTypeConfirmFB.Substring(2, 1) == "3";
																								if (flag184)
																								{
																									text4 = "+1" + text4;
																								}
																								this.SetStatusAccount(indexRow, text3 + "Số điện thoại:" + text4, device);
																								this.LoadStatusGrid(text4, "phone", indexRow, 0, this.dgvAcc);
																								this.Delay(1.0);
																								bool flag185 = this.isStop;
																								if (flag185)
																								{
																									goto Block_180;
																								}
																								ADBHelper.TapByPercent(text, 92.6, 49.3, 1);
																								device.DelayTime(1.0);
																								device.InputText(text4);
																								device.DelayTime(1.0);
																								bool flag186 = device.CheckExistText("\"next\"", html, 0.0);
																								if (flag186)
																								{
																									device.TapByText("\"next\"", "", 10);
																								}
																								else
																								{
																									device.TapByText("\"tiếp\"", "", 10);
																								}
																							}
																							bool flag187 = flag175;
																							if (flag187)
																							{
																								goto IL_2B97;
																							}
																							break;
																						}
																						else
																						{
																							flag174 = true;
																							num = num9;
																							num9 = num + 1;
																						}
																					}
																					goto IL_302E;
																				}
																				bool flag188 = this.isStop;
																				if (flag188)
																				{
																					goto Block_184;
																				}
																				bool flag189 = device.CheckExistText("the action attempted has been deemed abusive or is otherwise disallowed", html, 0.0) || device.CheckExistText("an unknown error occurred", html, 0.0) || device.CheckExistText("we couldn't create your account", html, 0.0) || device.CheckExistText("chúng tôi không thể tạo tài khoản của bạn", html, 0.0) || device.CheckExistText("một lỗi không xác định đã xảy ra", html, 0.0) || device.CheckExistText("hành động đã cố gắng bị coi là lạm dụng hoặc không được phép", html, 0.0);
																				if (flag189)
																				{
																					goto Block_190;
																				}
																				bool flag190 = this.isStop;
																				if (flag190)
																				{
																					goto Block_192;
																				}
																				bool flag191 = this.CheckStatusAccIsCheckPoint(device);
																				if (flag191)
																				{
																					goto Block_193;
																				}
																				bool flag192 = device.CheckExistText("there was an issue with your connection. check the following and try again.", html, 0.0);
																				if (flag192)
																				{
																					goto Block_194;
																				}
																				goto IL_3276;
																				IL_302E:
																				bool flag193 = flag174;
																				if (flag193)
																				{
																					goto IL_28AD;
																				}
																				break;
																				goto IL_302E;
																			}
																			IL_3276:
																			num = num8;
																		}
																		goto IL_32A4;
																	}
																	Block_159:
																	this.SetStatusAccount(indexRow, text3 + "Tạo lại tài khoản khác...", device);
																	device.CloseAppFacebook();
																	device.DelayTime(2.0);
																	goto IL_EE9;
																	Block_164:
																	this.SetStatusAccount(indexRow, text3 + "Tạo lại tài khoản khác...", device);
																	device.CloseAppFacebook();
																	device.DelayTime(3.0);
																	goto IL_EE9;
																	IL_21EC:
																	bool checked3 = this.rdConfMail.Checked;
																	if (checked3)
																	{
																		bool flag194 = this.isStop;
																		if (flag194)
																		{
																			goto Block_126;
																		}
																		ADBHelper.TapByPercent(text, 49.2, 96.6, 1);
																		string text13 = this.sTypeConfirmFB.Substring(2, 1);
																		bool flag195 = text13 != null;
																		if (flag195)
																		{
																			bool flag196 = !(text13 == "0");
																			if (flag196)
																			{
																				bool flag197 = text13 == "1";
																				if (flag197)
																				{
																					string text14 = this.lstHotmailDaReg[indexRow];
																					bool flag198 = text14 != "";
																					if (flag198)
																					{
																						this.SetStatusAccount(indexRow, text3 + "Nhập hotmail có sẵn....", device);
																						text5 = text14.Split(new char[]
																						{
																							'|'
																						})[0];
																						text6 = text14.Split(new char[]
																						{
																							'|'
																						})[1];
																						bool flag199 = this.isStop;
																						if (flag199)
																						{
																							goto Block_131;
																						}
																						this.LoadStatusGrid(text5, "email", indexRow, 0, this.dgvAcc);
																						this.LoadStatusGrid(text6, "passMail", indexRow, 0, this.dgvAcc);
																						device.InputTextWithUnicode(text5, 0.0);
																						this.Delay(2.0);
																						goto IL_24ED;
																					}
																				}
																			}
																			else
																			{
																				bool flag200 = this.isStop;
																				if (flag200)
																				{
																					goto Block_132;
																				}
																				this.Delay(2.0);
																				this.SetStatusAccount(indexRow, text3 + "Đăng ký hotmail....", device);
																				for (;;)
																				{
																					bool flag201 = this.regHotmail(indexRow);
																					bool flag202 = flag201;
																					if (flag202)
																					{
																						break;
																					}
																					this.LoadStatusGrid("Đang tạo lại mail khác", "status", indexRow, 0, this.dgvAcc);
																				}
																				bool flag203 = this.isStop;
																				if (flag203)
																				{
																					goto Block_134;
																				}
																				text5 = this.GetMailAccount(indexRow);
																				text6 = this.GetPassMailAccount(indexRow);
																				File.AppendAllText("output/facebook/hotmail.txt", string.Concat(new string[]
																				{
																					text5,
																					"|",
																					text6,
																					Environment.NewLine
																				}));
																				device.InputTextWithUnicode(text5, 0.0);
																				this.Delay(2.0);
																				goto IL_24ED;
																			}
																		}
																	}
																}
																break;
															}
															else
															{
																flag73 = false;
															}
														}
														num = n;
													}
													bool flag204 = !flag73;
													if (flag204)
													{
														goto Block_135;
													}
													goto IL_24ED;
												}
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_58:
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_59:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_63:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_65:
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_66:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_74:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_76:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_83:
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_84:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_88:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_89:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_91:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_93:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_94:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_95:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_97:
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_98:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_102:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_108:
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_109:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_113:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												Block_115:
												return;
												Block_117:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_118:
												this.SetStatusAccount(indexRow, text3 + "Không tạo được số điện thoại ảo...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_119:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_121:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_123:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_126:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_131:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_132:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_134:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_135:
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_136:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_141:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_143:
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_144:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_148:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												return;
												Block_150:
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_151:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_152:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_154:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_161:
												this.SetStatusAccount(indexRow, text3 + "Đăng ký thành công...", device);
												bool flag205 = device.CheckExistText("\"not now\"", html, 0.0);
												if (flag205)
												{
													device.TapByText("\"not now\"", "", 10);
												}
												else
												{
													device.TapByText("\"lúc khác\"", "", 10);
												}
												goto IL_32A4;
												Block_167:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_175:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_180:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												goto IL_32A4;
												Block_184:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_190:
												bool flag206 = this.isStop;
												if (flag206)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra. Thử lại sau", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												goto IL_606B;
												Block_192:
												this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												return;
												Block_193:
												this.SetStatusAccount(indexRow, text3 + "Checkpoint...", device);
												this.SetInfoAccount(indexRow, "Checkpoint");
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												goto IL_606B;
												Block_194:
												this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
												this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
												goto IL_606B;
												IL_32A4:
												bool flag207 = !flag73;
												if (flag207)
												{
													this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool flag208 = this.isStop;
												if (flag208)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												device.DelayTime(5.0);
												this.SetStatusAccount(indexRow, text3 + "Lưu mật khẩu và số điện thoại...", device);
												ADBHelper.TapByPercent(text, 47.8, 74.3, 1);
												device.DelayTime(3.0);
												bool flag209 = this.sTypeConfirmFB.Substring(0, 1) == "0";
												if (flag209)
												{
													device.GotoProfileQuick("");
												}
												else
												{
													string text15;
													for (;;)
													{
														IL_33AA:
														int num10 = 0;
														while (num10 < 5)
														{
															html = device.GetHtml();
															bool flag210 = device.GetListText(html, 0).Count != 1;
															if (flag210)
															{
																bool flag211 = device.CheckExistText("enter the code from your sms", html, 0.0) || device.CheckExistText("nhập mã từ sms của bạn", html, 0.0);
																if (!flag211)
																{
																	flag73 = false;
																	break;
																}
																bool flag212 = this.isStop;
																if (flag212)
																{
																	goto Block_201;
																}
																flag73 = true;
																break;
															}
															else
															{
																int num = num10;
																num10 = num + 1;
															}
														}
														bool flag213 = !flag73;
														if (flag213)
														{
															goto Block_202;
														}
														bool checked4 = this.rdThuePhone.Checked;
														if (checked4)
														{
															int num11 = 0;
															int num;
															for (int num12 = 0; num12 < 5; num12 = num + 1)
															{
																bool flag214 = this.isStop;
																if (flag214)
																{
																	goto Block_204;
																}
																this.SetStatusAccount(indexRow, text3 + "Đang lấy mã OTP...", device);
																text15 = string.Empty;
																bool flag215 = this.sTypeConfirmFB.Substring(2, 1) == "0";
																string apiKey;
																string idRequest;
																if (flag215)
																{
																	text15 = Common.GetCodeSimThue(apiKey, idRequest, 60, 1001);
																}
																else
																{
																	bool flag216 = this.sTypeConfirmFB.Substring(2, 1) == "1";
																	if (flag216)
																	{
																		text15 = Common.GetCodeViotp(apiKey, idRequest, 60, 7);
																	}
																	else
																	{
																		bool flag217 = this.sTypeConfirmFB.Substring(2, 1) == "2";
																		if (flag217)
																		{
																			text15 = Common.GetCodeTextNow(apiKey, idRequest, 60, 1);
																		}
																		else
																		{
																			bool flag218 = this.sTypeConfirmFB.Substring(2, 1) == "3";
																			if (flag218)
																			{
																				text15 = Common.GetCodeOTPMMO(apiKey, text7, 120);
																			}
																		}
																	}
																}
																bool flag219 = this.isStop;
																if (flag219)
																{
																	goto Block_209;
																}
																bool flag220 = text15 == "";
																if (!flag220)
																{
																	goto IL_3C3B;
																}
																bool flag221 = this.isStop;
																if (flag221)
																{
																	goto Block_211;
																}
																num = num11;
																num11 = num + 1;
																html = device.GetHtml();
																bool flag222 = device.GetListText(html, 0).Count != 1;
																if (flag222)
																{
																	this.SetStatusAccount(indexRow, text3 + "Không lấy được mã OTP...", device);
																	bool flag223 = device.CheckExistText("account confirmation", html, 0.0) || device.CheckExistText("xác nhận tài khoản", html, 0.0);
																	if (flag223)
																	{
																		bool flag224 = this.isStop;
																		if (flag224)
																		{
																			goto Block_215;
																		}
																		bool flag225 = device.CheckExistText("change phone number", html, 0.0) || device.CheckExistText("thay đổi số điện thoại", html, 0.0);
																		if (flag225)
																		{
																			bool flag226 = this.isStop;
																			if (flag226)
																			{
																				goto Block_218;
																			}
																			bool flag227 = device.CheckExistText("change phone number", html, 0.0);
																			if (flag227)
																			{
																				device.TapByText("change phone number", html, 2);
																			}
																			else
																			{
																				device.TapByText("thay đổi số điện thoại", html, 2);
																			}
																			device.DelayTime(1.0);
																			bool flag74;
																			bool flag228 = flag74;
																			if (flag228)
																			{
																				ADBHelper.TapByPercent(text, 34.2, 24.7, 1);
																				device.DelayTime(5.0);
																				device.InputText("Canada");
																				device.DelayTime(5.0);
																				ADBHelper.TapByPercent(text, 21.2, 20.9, 1);
																				device.DelayTime(3.0);
																			}
																			for (;;)
																			{
																				this.SetStatusAccount(indexRow, text3 + "Đang lấy số điện thoại khác...", device);
																				bool flag229 = this.sTypeConfirmFB.Substring(2, 1) == "0";
																				if (flag229)
																				{
																					text4 = Common.GetPhoneSimThue(apiKey, ref idRequest, 60, 1001);
																				}
																				else
																				{
																					bool flag230 = this.sTypeConfirmFB.Substring(2, 1) == "1";
																					if (flag230)
																					{
																						text4 = Common.GetPhoneViotp(apiKey, ref idRequest, 60, 7);
																					}
																					else
																					{
																						bool flag231 = this.sTypeConfirmFB.Substring(2, 1) == "2";
																						if (flag231)
																						{
																							text4 = Common.GetPhoneTextNow(apiKey, ref idRequest, 60, 1);
																						}
																						else
																						{
																							bool flag232 = this.sTypeConfirmFB.Substring(2, 1) == "3";
																							if (flag232)
																							{
																								text4 = Common.GetPhoneOtpmmo(apiKey, 60);
																								text7 = text4;
																							}
																						}
																					}
																				}
																				bool flag233 = text4 == "";
																				if (!flag233)
																				{
																					break;
																				}
																				bool flag234 = this.isStop;
																				if (flag234)
																				{
																					goto Block_226;
																				}
																				this.SetStatusAccount(indexRow, text3 + "Không lấy được số điện thoại. Lấy số khác", device);
																			}
																			bool flag235 = this.sTypeConfirmFB.Substring(2, 1) == "0" || this.sTypeConfirmFB.Substring(2, 1) == "1";
																			if (flag235)
																			{
																				text4 = "+84" + text4;
																			}
																			bool flag236 = this.sTypeConfirmFB.Substring(2, 1) == "2" || this.sTypeConfirmFB.Substring(2, 1) == "3";
																			if (flag236)
																			{
																				text4 = "+1" + text4;
																			}
																			this.SetStatusAccount(indexRow, text3 + "Số điện thoại:" + text4, device);
																			this.LoadStatusGrid(text4, "phone", indexRow, 0, this.dgvAcc);
																			this.Delay(1.0);
																			bool flag237 = this.isStop;
																			if (flag237)
																			{
																				goto Block_231;
																			}
																			ADBHelper.TapByPercent(text, 24.2, 31.4, 1);
																			device.DelayTime(1.0);
																			device.InputText(text4);
																			device.DelayTime(1.0);
																			ADBHelper.TapByPercent(text, 48.8, 40.2, 1);
																			device.DelayTime(5.0);
																			goto IL_33AA;
																		}
																	}
																}
																bool flag238 = num11 == 5;
																if (flag238)
																{
																	goto Block_232;
																}
																num = num12;
															}
															goto IL_3CBE;
														}
														goto IL_3CC4;
													}
													Block_201:
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_202:
													this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_204:
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													return;
													Block_209:
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_211:
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_215:
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_218:
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_226:
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_231:
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_232:
													device.GotoProfileQuick("");
													goto IL_4260;
													IL_3C3B:
													flag73 = true;
													this.SetStatusAccount(indexRow, text3 + "Mã OTP:" + text15, device);
													ADBHelper.TapByPercent(text, 7.2, 31.7, 1);
													this.Delay((double)this.iThoiGianChoNhapOtp);
													device.InputText(text15);
													IL_3CBE:
													goto IL_3DF2;
													IL_3CC4:
													bool checked5 = this.rdConfMail.Checked;
													if (checked5)
													{
														bool flag239 = this.isStop;
														if (flag239)
														{
															this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
															this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
															return;
														}
														string otpHotMailNew = Common.GetOtpHotMailNew(text5, text6, 90, "00000");
														bool flag240 = otpHotMailNew == "";
														if (flag240)
														{
															this.LoadStatusGrid("Mail không nhận được OTP!", "status", indexRow, 2, this.dgvAcc);
															this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
															return;
														}
														bool flag241 = otpHotMailNew.Contains("kcon");
														if (flag241)
														{
															this.LoadStatusGrid("Không kết nối được server hotmail!", "status", indexRow, 2, this.dgvAcc);
															this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
															return;
														}
														this.Delay((double)this.iThoiGianChoNhapOtp);
														device.InputText(otpHotMailNew);
														flag73 = true;
													}
													IL_3DF2:
													bool flag242 = !flag73;
													if (flag242)
													{
														this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
														this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
														return;
													}
													bool flag243 = this.isStop;
													if (flag243)
													{
														this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
														this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
														return;
													}
													bool flag244 = device.CheckExistText("\"confirm\"", html, 0.0);
													if (flag244)
													{
														device.TapByText("\"confirm\"", "", 10);
													}
													else
													{
														device.TapByText("\"xác nhận\"", "", 10);
													}
													device.DelayTime(10.0);
													int num13 = 0;
													while (num13 < 5)
													{
														html = device.GetHtml();
														bool flag245 = device.GetListText(html, 0).Count != 1;
														if (flag245)
														{
															bool flag246 = device.CheckExistText("skip", html, 0.0) || device.CheckExistText("bỏ qua", html, 0.0);
															if (!flag246)
															{
																flag73 = true;
																this.SetStatusAccount(indexRow, text3 + "Lỗi xác thực số điện thoại từ Facebook...Goto facebook - noveri", device);
																goto IL_4260;
															}
															bool flag247 = this.isStop;
															if (flag247)
															{
																this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																return;
															}
															flag73 = true;
															bool flag248 = device.CheckExistText("skip", html, 0.0);
															if (flag248)
															{
																device.TapByText("\"skip\"", "", 10);
															}
															else
															{
																device.TapByText("\"bỏ qua\"", "", 10);
															}
															break;
														}
														else
														{
															int num = num13;
															num13 = num + 1;
														}
													}
													bool flag249 = !flag73;
													if (flag249)
													{
														this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
														this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
														return;
													}
													bool flag250 = this.isStop;
													if (flag250)
													{
														this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
														this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
														return;
													}
													this.SetStatusAccount(indexRow, text3 + "Thêm 5 bạn bè...", device);
													device.DelayTime(2.0);
													int num14 = 0;
													while (num14 < 5)
													{
														html = device.GetHtml();
														bool flag251 = device.GetListText(html, 0).Count != 1;
														if (flag251)
														{
															bool flag252 = device.CheckExistText("add 5 friends", html, 0.0) || device.CheckExistText("thêm 5 người bạn", html, 0.0);
															if (!flag252)
															{
																flag73 = true;
																break;
															}
															bool flag253 = this.isStop;
															if (flag253)
															{
																this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																return;
															}
															flag73 = true;
															bool flag254 = device.CheckExistText("add 5 friends", html, 0.0);
															if (flag254)
															{
																device.TapByText("\"add 5 friends\"", "", 10);
															}
															else
															{
																device.TapByText("\"thêm 5 người bạn\"", "", 10);
															}
															break;
														}
														else
														{
															int num = num14;
															num14 = num + 1;
														}
													}
													bool flag255 = !flag73;
													if (flag255)
													{
														this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
														this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
														return;
													}
													device.TapByText("\"ok\"", "", 10);
												}
												IL_4260:
												device.DelayTime(5.0);
												bool flag256 = this.isStop;
												if (flag256)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												string tokenCookie = device.GetTokenCookie();
												string value = Regex.Match(tokenCookie.Split(new char[]
												{
													'|'
												})[1] + ";", "c_user=(.*?);").Groups[1].Value;
												bool flag257 = value.Trim() != "";
												if (flag257)
												{
													this.LoadStatusGrid(value, "uid", indexRow, 0, this.dgvAcc);
												}
												string text16 = tokenCookie.Split(new char[]
												{
													'|'
												})[0];
												string text17 = tokenCookie.Split(new char[]
												{
													'|'
												})[1];
												this.LoadStatusGrid(text16, "token", indexRow, 0, this.dgvAcc);
												this.LoadStatusGrid(text17, "cookie", indexRow, 0, this.dgvAcc);
												bool flag258 = !flag73;
												if (flag258)
												{
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool flag259 = this.isStop;
												if (flag259)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												this.SetStatusAccount(indexRow, text3 + "Chuyển đổi ngôn ngữ về English...", device);
												device.GotoNewFeedQuick();
												device.DelayTime(1.0);
												bool flag260 = this.isStop;
												if (flag260)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool flag261 = device.TapByImage("DataClick\\image\\menu", null, 30);
												if (!flag261)
												{
													ADBHelper.TapByPercent(text, 92.0, 8.2, 1);
												}
												int num15 = 0;
												bool flag262 = false;
												while (num15 < 10)
												{
													bool flag263 = this.isStop;
													if (flag263)
													{
														this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
														this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
														return;
													}
													string html2 = device.GetHtml();
													bool flag264 = device.CheckExistText("see your profile", html2, 0.0);
													if (flag264)
													{
														this.SetStatusAccount(indexRow, text3 + "Ngôn ngữ là English. Không đổi...", device);
														device.DelayTime(2.0);
														break;
													}
													bool flag265 = !device.CheckExistText("cài đặt &amp; quyền riêng tư. phần: đã thu gọn. nhấn đúp để mở rộng phần này.", html2, 0.0);
													if (flag265)
													{
														bool flag266 = !device.CheckExistText("cài đặt &amp; quyền riêng tư. phần: đã thu gọn. nhấn đúp để mở rộng phần này.", html2, 0.0);
														if (flag266)
														{
															bool flag267 = !device.ScrollAndCheckScreenNotChange(1000, 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]");
															if (flag267)
															{
																device.DelayTime(1.0);
																int num = num15;
																num15 = num + 1;
																continue;
															}
														}
														else
														{
															flag262 = true;
														}
													}
													else
													{
														device.TapByText("cài đặt &amp; quyền riêng tư. phần: đã thu gọn. nhấn đúp để mở rộng phần này.", html2, 0);
														flag262 = true;
													}
													bool flag268 = flag262;
													if (flag268)
													{
														int num16 = 0;
														html2 = device.GetHtml();
														while (num16 < 10)
														{
															bool flag269 = this.isStop;
															if (flag269)
															{
																this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																return;
															}
															bool flag270 = !device.TapByImage("DataClick\\image\\caidat", null, 0);
															if (flag270)
															{
																bool flag271 = num16 % 2 != 1 || !device.ScrollAndCheckScreenNotChange(1000, 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]");
																if (flag271)
																{
																	device.DelayTime(1.0);
																	int num = num16;
																	num16 = num + 1;
																	continue;
																}
															}
															else
															{
																flag262 = true;
															}
															bool flag272 = flag262;
															if (flag272)
															{
																int num17 = 0;
																while (num17 < 10)
																{
																	bool flag273 = this.isStop;
																	if (flag273)
																	{
																		this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																		this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																		return;
																	}
																	html2 = device.GetHtml();
																	bool flag274 = !device.TapByText("ngôn ngữ và khu vực", html2, 0);
																	if (flag274)
																	{
																		bool flag275 = !device.ScrollAndCheckScreenNotChange(1000, 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]");
																		if (flag275)
																		{
																			device.DelayTime(1.0);
																			int num = num17;
																			num17 = num + 1;
																			continue;
																		}
																	}
																	else
																	{
																		flag262 = true;
																	}
																	bool flag276 = flag262;
																	if (flag276)
																	{
																		ADBHelper.TapByPercent(text, 45.7, 15.5, 1);
																		int num;
																		for (int num18 = 0; num18 < 10; num18 = num + 1)
																		{
																			html2 = device.GetHtml();
																			bool flag277 = !device.TapByText("english", html2, 0);
																			if (!flag277)
																			{
																				flag262 = true;
																				flag73 = true;
																				break;
																			}
																			num = num18;
																		}
																	}
																	bool flag278 = flag262;
																	if (flag278)
																	{
																		break;
																	}
																}
																bool flag279 = flag262;
																if (flag279)
																{
																	break;
																}
															}
															bool flag280 = flag262;
															if (flag280)
															{
																break;
															}
														}
														bool flag281 = flag262;
														if (flag281)
														{
															break;
														}
													}
													bool flag282 = flag262;
													if (flag282)
													{
														break;
													}
												}
												bool flag283 = !flag73;
												if (flag283)
												{
													this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool flag284 = this.isStop;
												if (flag284)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												device.DelayTime(5.0);
												bool flag285 = this.isUploadAvt;
												if (flag285)
												{
													bool flag286 = this.isStop;
													if (flag286)
													{
														this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
														this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
														return;
													}
													this.SetStatusAccount(indexRow, text3 + "Up avatar...", device);
													int num19 = 1;
													string html3 = "";
													int num20;
													for (;;)
													{
														bool flag287 = this.isStop;
														if (flag287)
														{
															break;
														}
														device.GotoProfileQuick("");
														num20 = this.CheckGoToProfileUidSuccess(device, indexRow, "");
														bool flag288 = this.isStop;
														if (flag288)
														{
															goto Block_285;
														}
														bool flag289 = num20 == 0;
														if (flag289)
														{
															goto Block_286;
														}
														bool flag290 = num20 != 2;
														if (flag290)
														{
															goto Block_287;
														}
													}
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_285:
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_286:
													goto IL_4FBC;
													Block_287:
													bool flag291 = num20 != 3;
													if (flag291)
													{
														bool flag292 = device.TapByText("profile picture", "", 10);
														while (flag292)
														{
															bool flag293 = this.isStop;
															if (flag293)
															{
																this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																return;
															}
															int num = num19;
															num19 = num + 1;
															int num21 = num19;
															int num22 = num21;
															if (num22 != 1)
															{
																if (num22 == 2)
																{
																	flag292 = false;
																	device.ExecuteCMD("shell rm /sdcard/*.png", 10);
																	device.ExecuteCMD("shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file:///sdcard/Pictures", 10);
																	device.DelayTime(1.0);
																	bool flag294 = !device.TapByText("select profile picture", "", 5);
																	if (flag294)
																	{
																		continue;
																	}
																	for (int num23 = 0; num23 < 5; num23 = num + 1)
																	{
																		bool flag295 = this.isStop;
																		if (flag295)
																		{
																			this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																			this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																			return;
																		}
																		html3 = device.GetHtml();
																		num20 = device.CheckExistTexts(html3, 0.0, new string[]
																		{
																			"\"allow\"",
																			"\"enable gallery access",
																			"\"want to upload your photos",
																			"\"photo\""
																		});
																		bool flag296 = num20 == 1;
																		if (flag296)
																		{
																			device.TapByText("\"allow\"", html3, 0);
																		}
																		else
																		{
																			bool flag297 = num20 == 2;
																			if (flag297)
																			{
																				device.TapByText("\"enable gallery access", html3, 0);
																			}
																			else
																			{
																				bool flag298 = num20 == 3;
																				if (flag298)
																				{
																					device.TapByText("\"want to upload your photos", html3, 0);
																					device.DelayTime(2.0);
																					device.GotoBack(1, 0.0);
																				}
																				else
																				{
																					bool flag299 = num20 == 4;
																					if (flag299)
																					{
																						break;
																					}
																				}
																			}
																		}
																		device.DelayTime(1.0);
																		num = num23;
																	}
																	List<string> listBoundsByText = device.GetListBoundsByText("\"photo\"", html3, 0);
																	bool flag300 = listBoundsByText.Count >= 19;
																	if (flag300)
																	{
																		int num24 = this.rd.Next(0, 10);
																		int num25 = 0;
																		while (num25 < num24 && !device.ScrollAndCheckScreenNotChange(1000, 1, "[125,444][179,465]", "[146,313][223,348]", "[124,359][196,423]"))
																		{
																			bool flag301 = this.isStop;
																			if (flag301)
																			{
																				this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																				this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																				return;
																			}
																			device.DelayTime(1.0);
																			num = num25;
																			num25 = num + 1;
																		}
																		html3 = device.GetHtml();
																	}
																	string text18 = (from t in device.GetListBoundsByText("\"photo\"", html3, 0)
																	orderby Guid.NewGuid()
																	select t).FirstOrDefault<string>();
																	bool flag302 = !string.IsNullOrEmpty(text18);
																	if (flag302)
																	{
																		device.TapByBounds(text18, "");
																		device.DelayTime(1.0);
																		flag292 = device.TapByText("\"save\"", "", 10);
																		flag73 = true;
																		continue;
																	}
																	continue;
																}
															}
															break;
														}
													}
													IL_4FBC:;
												}
												else
												{
													ADBHelper.TapByPercent(text, 92.8, 8.2, 1);
												}
												bool flag303 = !flag73;
												if (flag303)
												{
													this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool flag304 = this.isStop;
												if (flag304)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool flag305 = this.isDoiAnhBia;
												if (flag305)
												{
													device.SetShareFolder(this.linkCover);
													this.SetStatusAccount(indexRow, text3 + "Up cover photo...", device);
													bool flag306 = false;
													string html4 = "";
													int num26 = 1;
													int num27;
													for (;;)
													{
														bool flag307 = this.isStop;
														if (flag307)
														{
															break;
														}
														device.GotoProfileQuick("");
														num27 = this.CheckGoToProfileUidSuccess(device, indexRow, text3);
														bool flag308 = num27 == 0;
														if (flag308)
														{
															goto Block_308;
														}
														bool flag309 = num27 != 2;
														if (flag309)
														{
															goto Block_309;
														}
													}
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
													Block_308:
													goto IL_563A;
													Block_309:
													bool flag310 = num27 != 3;
													if (flag310)
													{
														string boundsByText = device.GetBoundsByText("profile picture", "", 10);
														bool flag311 = boundsByText != "";
														if (flag311)
														{
															string[] array = boundsByText.Split(new char[]
															{
																'[',
																',',
																']'
															});
															device.Tap(Convert.ToInt32(array[1]) - 10, Convert.ToInt32(array[2]) - 10, 1);
															flag306 = true;
														}
														while (flag306)
														{
															bool flag312 = this.isStop;
															if (flag312)
															{
																this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																return;
															}
															int num = num26;
															num26 = num + 1;
															switch (num26)
															{
															case 2:
															{
																flag306 = false;
																device.ExecuteCMD("shell rm /sdcard.png", 10);
																device.ExecuteCMD("shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file:///sdcard/Pictures", 10);
																device.DelayTime(1.0);
																bool flag313 = !device.TapByText("upload photo", "", 5);
																if (flag313)
																{
																	continue;
																}
																for (int num28 = 0; num28 < 5; num28 = num + 1)
																{
																	bool flag314 = this.isStop;
																	if (flag314)
																	{
																		this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
																		this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
																		return;
																	}
																	html4 = device.GetHtml();
																	num27 = device.CheckExistTexts(html4, 0.0, new string[]
																	{
																		"\"allow\"",
																		"\"enable gallery access",
																		"\"want to upload your photos",
																		"\"photo\""
																	});
																	bool flag315 = num27 == 1;
																	if (flag315)
																	{
																		device.TapByText("\"allow\"", html4, 0);
																	}
																	else
																	{
																		bool flag316 = num27 == 2;
																		if (flag316)
																		{
																			device.TapByText("\"enable gallery access", html4, 0);
																		}
																		else
																		{
																			bool flag317 = num27 == 3;
																			if (flag317)
																			{
																				device.TapByText("\"want to upload your photos", html4, 0);
																				device.DelayTime(2.0);
																				device.GotoBack(1, 0.0);
																			}
																			else
																			{
																				bool flag318 = num27 == 4;
																				if (flag318)
																				{
																					break;
																				}
																			}
																		}
																	}
																	device.DelayTime(1.0);
																	num = num28;
																}
																List<string> listBoundsByText2 = device.GetListBoundsByText("\"photo\"", html4, 0);
																bool flag319 = listBoundsByText2.Count >= 24;
																if (flag319)
																{
																	int num29 = this.rd.Next(0, 5);
																	int num30 = 0;
																	while (num30 < num29 && !device.ScrollAndCheckScreenNotChange(1000, 1, "[125,444][179,465]", "[146,313][223,348]", "[124,359][196,423]"))
																	{
																		device.DelayTime(1.0);
																		num = num30;
																		num30 = num + 1;
																	}
																	html4 = device.GetHtml();
																}
																string text19 = (from t in device.GetListBoundsByText("\"photo\"", html4, 0)
																orderby Guid.NewGuid()
																select t).FirstOrDefault<string>();
																bool flag320 = !string.IsNullOrEmpty(text19);
																if (flag320)
																{
																	device.TapByBounds(text19, "");
																	device.DelayTime(1.0);
																	flag306 = device.TapByText("\"save\"", "", 10);
																	flag73 = true;
																	continue;
																}
																continue;
															}
															case 3:
																device.DelayTime(3.0);
																flag306 = device.WaitForTextDisappear(60.0, new string[]
																{
																	"uploading your cover photo."
																});
																continue;
															}
															break;
														}
													}
													IL_563A:;
												}
												bool flag321 = !flag73;
												if (flag321)
												{
													this.SetStatusAccount(indexRow, text3 + "Có lỗi xảy ra", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool flag322 = this.isStop;
												if (flag322)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool flag323 = this.isOnOff2FA;
												if (flag323)
												{
													this.SetStatusAccount(indexRow, text3 + "Bật 2FA...", device);
													bool flag324 = this.isStop;
													if (flag324)
													{
														this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
														this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
														return;
													}
													int num31 = this.HDOnOff2FA(indexRow, device, 1);
													bool flag325 = num31 == 1;
													if (flag325)
													{
														this.SetStatusAccount(indexRow, text3 + "Bật 2FA thành công", device);
													}
													else
													{
														this.SetStatusAccount(indexRow, text3 + "Bật 2FA thất bại", device);
													}
												}
												device.DelayTime(1.0);
												this.SetStatusAccount(indexRow, text3 + "Tắt app Facebook và mở lại", device);
												device.DelayTime(1.0);
												device.CloseAppFacebook();
												device.DelayTime(3.0);
												device.OpenAppFacebook();
												device.DelayTime(1.0);
												bool checked6 = this.chkReadNotifi.Checked;
												if (checked6)
												{
													this.SetStatusAccount(indexRow, text3 + "Đọc thông báo", device);
													device.DelayTime(1.0);
													this.HDDocThongBao(indexRow, text3, device);
												}
												bool flag326 = this.isStop;
												if (flag326)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool checked7 = this.chkWStory.Checked;
												if (checked7)
												{
													this.SetStatusAccount(indexRow, text3 + "Lướt story", device);
													device.DelayTime(1.0);
													this.HDXemStory(indexRow, text3, device);
												}
												bool flag327 = this.isStop;
												if (flag327)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool checked8 = this.chkAddFUID.Checked;
												if (checked8)
												{
													this.SetStatusAccount(indexRow, text3 + "Thêm bạn bè gợi ý", device);
													int soLuongFrom = Convert.ToInt32(this.nFriendFrom.Value);
													int soLuongTo = Convert.ToInt32(this.nFriendFrom.Value);
													device.DelayTime(1.0);
													this.HDKetBanGoiY(indexRow, text3, device, soLuongFrom, soLuongTo);
												}
												bool flag328 = this.isStop;
												if (flag328)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool checked9 = this.chkInNewfeed.Checked;
												if (checked9)
												{
													this.SetStatusAccount(indexRow, text3 + "Tương tác newsfeed", device);
													device.DelayTime(1.0);
													this.HDTuongTacNewsfeed(indexRow, text3, device);
												}
												bool flag329 = this.isStop;
												if (flag329)
												{
													this.SetStatusAccount(indexRow, text3 + "Đã dừng...", device);
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, false);
													return;
												}
												bool checked10 = this.chkWatch.Checked;
												if (checked10)
												{
													this.SetStatusAccount(indexRow, text3 + "Xem watch", device);
													device.DelayTime(1.0);
													this.HDXemWatch(indexRow, text3, device, 1, 5, 10, 20, true, 1, 5, true, 1, 3, false, null, 0, 0, 100, 100, 100);
												}
												bool flag330 = this.CheckIsUidFacebook(value) && Common.CheckLiveWall(value).StartsWith("0|");
												if (flag330)
												{
													this.SetInfoAccount(indexRow, "Live");
												}
												else
												{
													this.SetInfoAccount(indexRow, "Die");
												}
												bool checked11 = this.rdNoVeri.Checked;
												if (checked11)
												{
													string text20 = this.Get2FAAccount(indexRow);
													bool flag331 = text20 != "";
													if (flag331)
													{
														object obj11 = this.ofile1;
														object obj12 = obj11;
														lock (obj12)
														{
															string text12;
															File.AppendAllText("output/facebook/Noverify.txt", string.Concat(new string[]
															{
																value,
																"|",
																text12,
																"|",
																text20,
																"|",
																text16,
																"|",
																text17,
																Environment.NewLine
															}));
														}
													}
													else
													{
														object obj11 = this.ofile1;
														object obj13 = obj11;
														lock (obj13)
														{
															string text12;
															File.AppendAllText("output/facebook/Noverify.txt", string.Concat(new string[]
															{
																value,
																"|",
																text12,
																"|",
																text16,
																"|",
																text17,
																Environment.NewLine
															}));
														}
													}
												}
												else
												{
													bool checked12 = this.rdThuePhone.Checked;
													if (checked12)
													{
														string text21 = this.Get2FAAccount(indexRow);
														bool flag334 = text21 != "";
														if (flag334)
														{
															object obj14 = this.ofile2;
															object obj15 = obj14;
															lock (obj15)
															{
																string text12;
																File.AppendAllText("output/facebook/VerifySdt.txt", string.Concat(new string[]
																{
																	value,
																	"|",
																	text12,
																	"|",
																	text21,
																	"|",
																	text4,
																	"|",
																	text16,
																	"|",
																	text17,
																	Environment.NewLine
																}));
															}
														}
														else
														{
															object obj14 = this.ofile2;
															object obj16 = obj14;
															lock (obj16)
															{
																string text12;
																File.AppendAllText("output/facebook/VerifySdt.txt", string.Concat(new string[]
																{
																	value,
																	"|",
																	text12,
																	"|",
																	text4,
																	"|",
																	text16,
																	"|",
																	text17,
																	Environment.NewLine
																}));
															}
														}
													}
													else
													{
														bool checked13 = this.rdConfMail.Checked;
														if (checked13)
														{
															string text22 = this.Get2FAAccount(indexRow);
															bool flag337 = text22 != "";
															if (flag337)
															{
																object obj17 = this.ofile3;
																object obj18 = obj17;
																lock (obj18)
																{
																	string text12;
																	File.AppendAllText("output/facebook/VerifyHotMail.txt", string.Concat(new string[]
																	{
																		value,
																		"|",
																		text12,
																		"|",
																		text22,
																		"|",
																		text5,
																		"|",
																		text6,
																		"|",
																		text16,
																		"|",
																		text17,
																		Environment.NewLine
																	}));
																}
															}
															else
															{
																object obj17 = this.ofile3;
																object obj19 = obj17;
																lock (obj19)
																{
																	string text12;
																	File.AppendAllText("output/facebook/VerifyHotMail.txt", string.Concat(new string[]
																	{
																		value,
																		"|",
																		text12,
																		"|",
																		text5,
																		"|",
																		text6,
																		"|",
																		text16,
																		"|",
																		text17,
																		Environment.NewLine
																	}));
																}
															}
														}
													}
												}
												object obj20 = this.oStop;
												object obj21 = obj20;
												lock (obj21)
												{
													this.stopDeviceOneThread(device.IndexDevice, indexRow, indexPos, device, true);
												}
												IL_606B:
												object obj22 = this.lock_FinishProxy;
												lock (obj22)
												{
													switch (this.iTypeChangeIp)
													{
													case 2:
														if (tinsoftProxy != null)
														{
															tinsoftProxy.DecrementDangSuDung();
														}
														break;
													case 3:
														if (minProxy != null)
														{
															minProxy.DecrementDangSuDung();
														}
														break;
													}
												}
												IL_6100:;
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00021654 File Offset: 0x0001F854
		private int HDXemWatch(int indexRow, string statusProxy, Device device, int nudSoLuongFrom, int nudSoLuongTo, int nudTimeWatchFrom, int nudTimeWatchTo, bool ckbInteract, int nudCountLikeFrom, int nudCountLikeTo, bool ckbShareWall, int nudCountShareFrom, int nudCountShareTo, bool ckbComment, List<string> txtComment, int nudCountCommentFrom, int nudCountCommentTo, int nudPercentLike, int nudPercentShare, int nudPercentComment)
		{
			int num = 0;
			int num2 = this.rd.Next(nudCountLikeFrom, nudCountLikeTo + 1);
			int num3 = this.rd.Next(nudCountCommentFrom, nudCountCommentTo + 1);
			int num4 = this.rd.Next(nudCountShareFrom, nudCountShareTo + 1);
			int num5 = this.rd.Next(nudSoLuongFrom, nudSoLuongTo + 1);
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			try
			{
				int i = 0;
				while (i < 10)
				{
					int num9;
					for (;;)
					{
						device.GotoWatchQuick();
						bool flag = device.CheckExistText("more options", "", 5.0);
						if (flag)
						{
							goto Block_3;
						}
						bool flag2 = device.CheckExistImage("DataClick\\image\\tryagain", null, 0);
						if (flag2)
						{
							goto Block_4;
						}
						bool flag3 = device.ClosePopup("");
						if (flag3)
						{
							break;
						}
						num9 = this.CheckStatusDevice(device, indexRow, statusProxy);
						bool flag4 = num9 != 1;
						if (flag4)
						{
							goto Block_6;
						}
					}
					IL_D4:
					i++;
					continue;
					Block_4:
					device.TapByImageWait("DataClick\\image\\tryagain", 0, 10);
					goto IL_D4;
					Block_3:
					for (;;)
					{
						if (num < num5)
						{
							device.ClosePopup("");
							for (;;)
							{
								bool flag5 = device.ScrollAndCheckScreenNotChange(500, 1, "[97,401][179,413]", "[180,88][254,100]", "[99,416][169,456]");
								if (flag5)
								{
									goto Block_8;
								}
								num++;
								device.DelayRandom((double)nudTimeWatchFrom, (double)nudTimeWatchTo);
								bool flag6 = ckbInteract && num6 < num2 && Common.CheckWithPercent(nudPercentLike);
								if (flag6)
								{
									string html = device.GetHtml();
									string text = device.GetListBoundsByText("\"like\"", html, 0).LastOrDefault<string>();
									bool flag7 = !string.IsNullOrEmpty(text);
									if (flag7)
									{
										device.TapLongByBounds(text, "");
										device.ClickReactions(6);
										num6++;
									}
								}
								bool flag8 = ckbComment && num7 < num3 && Common.CheckWithPercent(nudPercentComment);
								if (flag8)
								{
									string html2 = device.GetHtml();
									string text2 = device.GetListBoundsByText("\"comment\"", html2, 0).LastOrDefault<string>();
									bool flag9 = !string.IsNullOrEmpty(text2);
									if (flag9)
									{
										string text3 = txtComment[device.GetRandomInt(0, txtComment.Count - 1)];
										text3 = Common.SpinText(text3, this.rd);
										text3 = GetIconFacebook.ProcessString(text3, this.rd);
										device.TapByBounds(text2, "");
										device.DelayRandom(2.0, 3.0);
										device.ClosePopup("");
										device.GetHtml();
										int num10 = device.CheckExistTexts(html2, 3.0, new string[]
										{
											"\"comment…\"",
											"write a comment…\""
										});
										bool flag10 = num10 == 1;
										if (flag10)
										{
											device.TapByText("\"comment…\"", html2, 0);
										}
										bool flag11 = !device.TapByTextWithPopupAppear(10, "write a comment…\"", Device.GetListTextClosePopup().ToArray());
										if (flag11)
										{
											break;
										}
										device.InputTextWithUnicode(text3, 0.0);
										device.TapByText("\"send\"", "", 3);
										device.DelayRandom(2.0, 2.5);
										device.GotoBack(2, 0.0);
										device.DelayRandom(1.0, 1.5);
										num7++;
									}
								}
								bool flag12 = ckbShareWall && num8 < num4 && Common.CheckWithPercent(nudPercentShare);
								if (flag12)
								{
									string html3 = device.GetHtml();
									bool flag13 = device.CheckExistText("share", html3, 0.0);
									if (flag13)
									{
										List<string> listBoundsByText = device.GetListBoundsByText("share", html3, 0);
										string bounds = listBoundsByText[listBoundsByText.Count - 1];
										device.TapByBounds(bounds, "");
										device.TapByText("\"share now\"", "", 3);
										device.DelayRandom(1.5, 2.0);
										num8++;
									}
								}
								this.SetStatusAccount(indexRow, statusProxy + "Đang xem watch" + string.Format(" {0} ({1}/{2})...", num, num5), null);
							}
						}
					}
					Block_8:
					return num;
					goto IL_D4;
					Block_6:
					bool flag14 = num9 == 0;
					if (flag14)
					{
						goto IL_D4;
					}
					return num;
				}
			}
			catch
			{
			}
			return num;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00021ADC File Offset: 0x0001FCDC
		private int HDTuongTacNewsfeed(int indexRow, string statusProxy, Device device)
		{
			int result = 0;
			try
			{
				int num;
				do
				{
					device.GotoNewFeedQuick();
					device.DelayRandom(1.0, 2.0);
					num = this.CheckStatusDevice(device, indexRow, statusProxy);
				}
				while (num == 1);
				bool flag = num == 0;
				if (flag)
				{
					this.InteractTimelime(indexRow, statusProxy, device, 10, 30, true, 1, 5, false, 0, 0, null, true, 1, 3);
				}
			}
			catch (Exception ex)
			{
				result = -1;
			}
			return result;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x00021B68 File Offset: 0x0001FD68
		private int InteractTimelime(int indexRow, string statusProxy, Device device, int timeFrom, int timeTo, bool isLike, int countLikeFrom, int countLikeTo, bool isComment, int countCommentFrom, int countCommentTo, List<string> lstComment, bool isShareWall, int countShareFrom, int countShareTo)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			List<string> list = new List<string>();
			if (isLike)
			{
				num4 = device.GetRandomInt(countLikeFrom, countLikeTo);
			}
			bool flag = lstComment != null;
			if (flag)
			{
				lstComment = Common.RemoveEmptyItems(lstComment);
				list = Common.CloneList(lstComment);
			}
			if (isComment)
			{
				num5 = device.GetRandomInt(countCommentFrom, countCommentTo);
			}
			if (isShareWall)
			{
				num6 = device.GetRandomInt(countShareFrom, countShareTo);
			}
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			int randomInt = device.GetRandomInt(timeFrom, timeTo);
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount < randomInt * 1000)
			{
				int num7 = this.CheckStatusDevice(device, indexRow, statusProxy);
				bool flag2 = num7 == 1;
				if (flag2)
				{
					device.GotoNewFeedQuick();
				}
				else
				{
					bool flag3 = num7 != 0;
					if (flag3)
					{
						break;
					}
				}
				string html = device.GetHtml();
				list2 = device.GetListBoundsByText("like button. double tap and hold to react", html, 0);
				bool flag4 = list2.Count > 0 && isLike && num < num4 && device.GetRandomInt(1, 100) % 2 == 0;
				if (flag4)
				{
					string text = list2[list2.Count - 1];
					bool flag5 = text != "" && device.TapLongByBounds(text, "[0,100][320,480]");
					if (flag5)
					{
						device.DelayRandom(1.0, 1.5);
						device.ClickReactions(6);
						num++;
						device.DelayRandom(1.0, 2.0);
						html = device.GetHtml();
					}
				}
				list3 = device.GetListBoundsByText("comment button", html, 0);
				bool flag6 = list3.Count > 0 && isComment && num2 < num5 && device.GetRandomInt(1, 100) % 2 == 0 && lstComment != null;
				if (flag6)
				{
					string text2 = list3[list3.Count - 1];
					bool flag7 = text2 != "";
					if (flag7)
					{
						bool flag8 = list.Count == 0;
						if (flag8)
						{
							list = Common.CloneList(lstComment);
						}
						string text3 = list[device.GetRandomInt(0, list.Count - 1)];
						list.Remove(text3);
						text3 = Common.SpinText(text3, this.rd);
						bool flag9 = device.TapByBounds(text2, "[0,100][320,480]");
						if (flag9)
						{
							device.DelayRandom(1.0, 2.0);
							device.InputTextWithUnicode(text3, 0.0);
							device.DelayRandom(1.0, 2.0);
							bool flag10 = device.TapByText("send", "", 0);
							if (flag10)
							{
								device.DelayRandom(3.0, 5.0);
							}
							device.GotoBack(2, 0.3);
							num2++;
							device.DelayRandom(1.0, 2.0);
							html = device.GetHtml();
						}
					}
				}
				list4 = device.GetListBoundsByText("share button", html, 0);
				bool flag11 = list4.Count > 0 && isShareWall && num3 < num6 && device.GetRandomInt(1, 100) % 2 == 0;
				if (flag11)
				{
					string text4 = list4[list4.Count - 1];
					bool flag12 = text4 != "" && device.TapByBounds(text4, "[0,100][320,480]");
					if (flag12)
					{
						device.DelayRandom(1.5, 2.0);
						device.TapByText("share now", "", 0);
						device.DelayRandom(2.0, 3.0);
						num3++;
					}
				}
				bool flag13 = device.ScrollAndCheckScreenNotChange(500, 1, "[97,401][179,413]", "[180,88][254,100]", "[72,165][216,294]");
				if (flag13)
				{
					break;
				}
				device.DelayRandom(1.5, 3.0);
			}
			return 0;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00021FAC File Offset: 0x000201AC
		private int HDKetBanGoiY(int indexRow, string statusProxy, Device device, int soLuongFrom, int soLuongTo)
		{
			int num = 0;
			try
			{
				int num2 = this.rd.Next(soLuongFrom, soLuongTo + 1);
				bool flag = num2 != 0;
				if (flag)
				{
					for (;;)
					{
						for (;;)
						{
							IL_28:
							device.GotoFriendSuggest();
							device.DelayRandom(1.0, 2.0);
							int num3 = this.CheckStatusDevice(device, indexRow, statusProxy);
							bool flag2 = num3 != 1;
							if (flag2)
							{
								bool flag3 = num3 != 0;
								if (flag3)
								{
									goto Block_5;
								}
								List<string> listBoundsByText = device.GetListBoundsByText("as a friend\"", "", 0);
								bool flag4 = listBoundsByText.Count != 0;
								if (flag4)
								{
									for (int i = 0; i < num2 + 10; i++)
									{
										int num4 = this.CheckStatusDevice(device, indexRow, statusProxy);
										bool flag5 = num4 == 1;
										if (flag5)
										{
											goto IL_28;
										}
										bool flag6 = num4 != 0;
										if (flag6)
										{
											break;
										}
										string text = listBoundsByText[device.GetRandomInt(0, listBoundsByText.Count - 1)];
										bool flag7 = text != "" && device.TapByBounds(text, "");
										if (flag7)
										{
											num++;
											this.SetStatusAccount(indexRow, statusProxy + "Đang" + string.Format(" kết bạn gợi ý ({1}/{2})...", num, num2), null);
											device.DelayRandom(2.0, 5.0);
										}
										bool flag8 = num >= num2;
										if (flag8)
										{
											break;
										}
										listBoundsByText = device.GetListBoundsByText("as a friend", "", 0);
										bool flag9 = listBoundsByText.Count == 0;
										if (flag9)
										{
											bool flag10 = device.ScrollAndCheckScreenNotChange(device.GetRandomInt(200, 300), 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]");
											if (flag10)
											{
												break;
											}
											listBoundsByText = device.GetListBoundsByText("as a friend", "", 0);
											bool flag11 = listBoundsByText.Count == 0;
											if (flag11)
											{
												break;
											}
										}
									}
									goto IL_1FC;
								}
								goto IL_1FE;
							}
						}
					}
					Block_5:
					IL_1FC:
					IL_1FE:;
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x000221F0 File Offset: 0x000203F0
		private int HDXemStory(int indexRow, string statusProxy, Device device)
		{
			int randomInt = device.GetRandomInt(3, 5);
			try
			{
				int num;
				do
				{
					device.GotoNewFeedQuick();
					device.DelayRandom(1.0, 2.0);
					num = this.CheckStatusDevice(device, indexRow, statusProxy);
				}
				while (num == 1);
				bool flag = num == 0;
				if (flag)
				{
					string boundsByText = device.GetBoundsByText("'s story", "", 0);
					bool flag2 = boundsByText != "";
					if (flag2)
					{
						device.TapByBounds(boundsByText, "");
						int tickCount = Environment.TickCount;
						while (Environment.TickCount - tickCount < randomInt * 1000)
						{
							device.DelayRandom(4.0, 8.0);
							bool flag3 = this.typeReaction.Count > 0 && device.GetRandomInt(1, 9) % 3 == 0;
							if (flag3)
							{
								string bounds = "[165,445][195,470]";
								string bounds2 = "[35,445][65,470]";
								device.SwipeByBounds(bounds, bounds2, 100);
								device.DelayRandom(1.0, 1.5);
								int num2 = Convert.ToInt32(this.typeReaction[device.GetRandomInt(0, this.typeReaction.Count - 1)].ToString());
								device.ClickReactions(num2);
								device.DelayRandom(1.0, 1.5);
								device.TapByBounds("[260,198][300,268]", "");
								device.DelayRandom(1.0, 1.5);
							}
							device.TapByBounds("[260,198][300,268]", "");
						}
					}
				}
			}
			catch
			{
			}
			return randomInt;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000223D4 File Offset: 0x000205D4
		private int HDDocThongBao(int indexRow, string statusProxy, Device device)
		{
			int i = 0;
			int num = device.GetRandomInt(1, 5);
			try
			{
				string text = "manage the notification";
				List<string> list = new List<string>();
				for (;;)
				{
					while (i < num)
					{
						int j = 0;
						while (j < 10)
						{
							string html = device.GetHtml();
							list = device.GetListBoundsByText(text, "", 0);
							bool flag = list.Count > 0;
							if (flag)
							{
								bool flag2 = list.Count <= 4;
								if (flag2)
								{
									num = list.Count;
								}
								Point locationFromBounds;
								do
								{
									bool flag3 = list.Count == 0;
									if (flag3)
									{
										bool flag4 = device.ScrollAndCheckScreenNotChange(150, 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]");
										if (flag4)
										{
											goto Block_6;
										}
										list = device.GetListBoundsByText(text, "", 0);
										bool flag5 = list.Count == 0;
										if (flag5)
										{
											goto Block_7;
										}
									}
									string text2 = list[device.GetRandomInt(0, list.Count - 1)];
									list.Remove(text2);
									locationFromBounds = device.GetLocationFromBounds(text2);
								}
								while (!device.CheckBoundsContainLocation("[0,60][320,480]", locationFromBounds));
								device.Tap(locationFromBounds.X - device.GetRandomInt(100, 150), locationFromBounds.Y, 1);
								device.DelayRandom(1.0, 2.0);
								int tickCount = Environment.TickCount;
								int randomInt = device.GetRandomInt(3, 5);
								while (Environment.TickCount - tickCount < randomInt * 1000 && !device.ScrollAndCheckScreenNotChange(1000, 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]"))
								{
									device.DelayRandom(1.0, 2.0);
								}
								i++;
								this.SetStatusAccount(indexRow, statusProxy + "Đang" + string.Format(" Đọc thông báo ({1}/{2})...", i, num), device);
								device.GotoBack(1, 0.0);
								device.DelayRandom(1.0, 2.0);
								break;
							}
							bool flag6 = device.CheckExistText("no notifications", html, 0.0);
							if (flag6)
							{
								goto Block_11;
							}
							int num2;
							for (;;)
							{
								device.GotoNotificationQuick();
								device.DelayTime(3.0);
								bool flag7 = device.ClosePopup("");
								if (flag7)
								{
									break;
								}
								num2 = this.CheckStatusDevice(device, indexRow, statusProxy);
								bool flag8 = num2 != 1;
								if (flag8)
								{
									goto Block_13;
								}
							}
							IL_29F:
							j++;
							continue;
							goto IL_29F;
							Block_13:
							bool flag9 = num2 == 0;
							if (flag9)
							{
								goto IL_29F;
							}
							goto IL_2B7;
						}
					}
					goto Block_15;
				}
				Block_6:
				Block_7:
				return i;
				Block_11:
				this.SetStatusAccount(indexRow, statusProxy + "Không có thông báo để đọc", device);
				return i;
				IL_2B7:
				return i;
				Block_15:;
			}
			catch
			{
			}
			return i;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x000226E8 File Offset: 0x000208E8
		private void DelayThaoTacNho(int timeAdd = 0)
		{
			Common.DelayTime((double)this.rd.Next(timeAdd + 1, timeAdd + 4));
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00022704 File Offset: 0x00020904
		private int HDOnOff2FA(int indexRow, Device device, int cauHinh)
		{
			string cellAccount = this.GetCellAccount(indexRow, "uid");
			string cellAccount2 = this.GetCellAccount(indexRow, "pass");
			bool flag = true;
			bool flag2 = cauHinh == 1;
			int result;
			if (flag2)
			{
				int num = 0;
				int num2 = 0;
				try
				{
					string text;
					for (;;)
					{
						device.GotoNewFeedQuick();
						num2++;
						for (;;)
						{
							IL_4A:
							bool flag3 = !device.TapByImage("DataClick\\image\\menu", null, 30);
							if (flag3)
							{
								goto Block_4;
							}
							bool flag4 = false;
							num2++;
							int i = 0;
							while (i < 10)
							{
								string html = device.GetHtml();
								bool flag5 = !device.CheckExistText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", html, 0.0);
								if (flag5)
								{
									bool flag6 = !device.CheckExistText("settings &amp; privacy, header. section is expanded. double-tap to collapse the section.", html, 0.0);
									if (flag6)
									{
										bool flag7 = !device.ScrollAndCheckScreenNotChange(500, 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]");
										if (flag7)
										{
											device.DelayTime(1.0);
											i++;
											continue;
										}
									}
									else
									{
										flag4 = true;
									}
								}
								else
								{
									device.TapByText("settings &amp; privacy, header. section is collapsed. double-tap to expand the section.", html, 0);
									flag4 = true;
								}
								bool flag8 = flag4;
								if (flag8)
								{
									flag4 = false;
									num2++;
									int j = 0;
									while (j < 10)
									{
										bool flag9 = !device.TapByImage("DataClick\\image\\caidat", null, 0);
										if (flag9)
										{
											bool flag10 = j % 2 != 1 || !device.ScrollAndCheckScreenNotChange(1000, 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]");
											if (flag10)
											{
												device.DelayTime(1.0);
												j++;
												continue;
											}
										}
										else
										{
											flag4 = true;
										}
										bool flag11 = flag4;
										if (flag11)
										{
											flag4 = false;
											int k = 0;
											while (k < 10)
											{
												html = device.GetHtml();
												bool flag12 = !device.TapByText("password and security", html, 0) && !device.TapByText("security and login", html, 0);
												if (flag12)
												{
													bool flag13 = !device.ScrollAndCheckScreenNotChange(1000, 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]");
													if (flag13)
													{
														device.DelayTime(1.0);
														k++;
														continue;
													}
												}
												else
												{
													flag4 = true;
												}
												bool flag14 = !flag4;
												if (flag14)
												{
													break;
												}
												for (;;)
												{
													for (;;)
													{
														IL_255:
														flag4 = false;
														int l = 0;
														while (l < 10)
														{
															html = device.GetHtml();
															bool flag15 = !device.TapByText("use two-factor authentication", html, 0);
															if (flag15)
															{
																bool flag16 = !device.ScrollAndCheckScreenNotChange(1000, 1, "[100,391][219,423]", "[181,195][286,226]", "[72,165][216,294]");
																if (flag16)
																{
																	device.DelayTime(1.0);
																	l++;
																	continue;
																}
															}
															else
															{
																flag4 = true;
															}
															bool flag17 = flag4;
															if (flag17)
															{
																flag4 = false;
																for (int m = 0; m < 10; m++)
																{
																	html = device.GetHtml();
																	bool flag18 = device.TapByImage("DataClick\\image\\continue", null, 10);
																	if (flag18)
																	{
																		goto Block_20;
																	}
																	bool flag19 = device.CheckExistText("two-factor authentication is on", html, 0.0);
																	if (flag19)
																	{
																		bool flag20 = false;
																		bool flag21 = !flag;
																		if (flag21)
																		{
																			break;
																		}
																		bool flag22 = device.TapByImageWait("DataClick\\image\\turnoff", 0, 10) && device.TapByImageWait("DataClick\\image\\turnoffxanh", 0, 10);
																		if (flag22)
																		{
																			for (int n = 0; n < 10; n++)
																			{
																				html = device.GetHtml();
																				bool flag23 = device.CheckExistText("incorrect password", html, 0.0);
																				if (flag23)
																				{
																					this.SetInfoAccount(indexRow, "Changed pass");
																					break;
																				}
																				bool flag24 = device.CheckExistText("\"password\"", html, 0.0);
																				if (flag24)
																				{
																					bool flag25 = cellAccount2.Trim() == "";
																					if (flag25)
																					{
																						break;
																					}
																					device.TapByText("\"password\"", html, 0);
																					device.InputTextWithUnicode(cellAccount2, 0.0);
																					device.TapByImage("DataClick\\image\\continue", null, 10);
																				}
																				else
																				{
																					bool flag26 = device.CheckExistText("two-factor authentication", html, 0.0);
																					if (flag26)
																					{
																						flag20 = true;
																						break;
																					}
																				}
																				device.DelayTime(1.0);
																			}
																		}
																		bool flag27 = flag20;
																		if (flag27)
																		{
																			goto IL_255;
																		}
																	}
																	device.DelayTime(1.0);
																}
																goto IL_48A;
															}
															goto IL_48F;
														}
													}
												}
												IL_74D:
												bool flag28 = !flag4;
												if (flag28)
												{
													break;
												}
												bool flag29 = !device.CheckExistImage("DataClick\\image\\setup2fa", null, 10);
												if (flag29)
												{
													break;
												}
												text = "";
												for (int num3 = 0; num3 < 5; num3++)
												{
													Bitmap bitmap = device.ScreenShoot();
													text = Common.ByPassQRCode(bitmap);
													text = Regex.Match(text, "secret=(.*?)&").Groups[1].Value;
													bool flag30 = !string.IsNullOrEmpty(text);
													if (flag30)
													{
														break;
													}
													device.DelayTime(1.0);
												}
												bool flag31 = !string.IsNullOrEmpty(text);
												if (flag31)
												{
													int num4 = 0;
													IL_560:
													while (device.TapByImage("DataClick\\image\\continue", null, 10))
													{
														flag4 = false;
														bool flag32 = device.TapByImage("DataClick\\image\\enterthe6digitcode", null, 10);
														if (flag32)
														{
															string totp = Common.GetTotp(text);
															ADBHelper.TapByPercent(device.DeviceId, 12.7, 34.1, 1);
															device.DelayTime(2.0);
															device.InputTextWithUnicode(totp, 0.0);
															device.TapByText("\"continue\"", "", 0);
															int num5 = 0;
															while (num5 < 10)
															{
																bool flag33 = !device.CheckExistImage("DataClick\\image\\thiscodeisntright", null, 0);
																if (flag33)
																{
																	html = device.GetHtml();
																	bool flag34 = device.CheckExistText("incorrect password", html, 0.0);
																	if (flag34)
																	{
																		this.SetInfoAccount(indexRow, "Changed pass");
																		break;
																	}
																	bool flag35 = device.CheckExistText("\"password\"", html, 0.0);
																	if (flag35)
																	{
																		bool flag36 = cellAccount2.Trim() == "";
																		if (flag36)
																		{
																			break;
																		}
																		device.TapByText("\"password\"", html, 0);
																		device.InputTextWithUnicode(cellAccount2, 0.0);
																		device.TapByImage("DataClick\\image\\continue", null, 10);
																	}
																	else
																	{
																		bool flag37 = device.CheckExistText("two-factor authentication is on", html, 0.0);
																		if (flag37)
																		{
																			flag4 = true;
																			break;
																		}
																	}
																	device.DelayTime(1.0);
																	num5++;
																}
																else
																{
																	num4++;
																	bool flag38 = num4 < 3;
																	if (flag38)
																	{
																		device.TapByText("\"back\"", "", 0);
																		goto IL_560;
																	}
																	break;
																}
															}
														}
														bool flag39 = !flag4;
														if (flag39)
														{
															goto IL_4A;
														}
														goto IL_72C;
													}
													break;
												}
												break;
												IL_48A:
												goto IL_74D;
												goto IL_48A;
												Block_20:
												flag4 = true;
												goto IL_74D;
											}
											break;
										}
										break;
									}
									goto IL_775;
								}
								goto IL_775;
							}
							break;
						}
					}
					Block_4:
					IL_48F:
					goto IL_7B9;
					IL_72C:
					bool flag40 = text != "";
					if (flag40)
					{
						num = 1;
						this.SetCellAccount(indexRow, "conf_2fa", text, true);
					}
					IL_775:
					IL_7B9:;
				}
				catch
				{
				}
				int num6 = num;
				result = num6;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000217 RID: 535 RVA: 0x00022F04 File Offset: 0x00021104
		public string GetInfoAccount(int indexRow)
		{
			return DatagridviewHelper.GetStatusDataGridView(this.dgvAcc, indexRow, "cInfo");
		}

		// Token: 0x06000218 RID: 536 RVA: 0x00022F28 File Offset: 0x00021128
		public string Get2FAAccount(int indexRow)
		{
			return DatagridviewHelper.GetStatusDataGridView(this.dgvAcc, indexRow, "conf_2fa");
		}

		// Token: 0x06000219 RID: 537 RVA: 0x00022F4C File Offset: 0x0002114C
		public string GetMailAccount(int indexRow)
		{
			return DatagridviewHelper.GetStatusDataGridView(this.dgvAcc, indexRow, "email");
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00022F70 File Offset: 0x00021170
		public string GetPassMailAccount(int indexRow)
		{
			return DatagridviewHelper.GetStatusDataGridView(this.dgvAcc, indexRow, "passMail");
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00022F94 File Offset: 0x00021194
		private void SetRowColor(int indexRow = -1)
		{
			bool flag = indexRow == -1;
			if (flag)
			{
				for (int i = 0; i < this.dgvAcc.RowCount; i++)
				{
					string infoAccount = this.GetInfoAccount(i);
					bool flag2 = infoAccount == "Live";
					if (flag2)
					{
						this.dgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
					}
					else
					{
						bool flag3 = infoAccount.Contains("Die") || infoAccount.Contains("Checkpoint") || infoAccount.Contains("Changed pass");
						if (flag3)
						{
							this.dgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
						}
					}
				}
			}
			else
			{
				string infoAccount2 = this.GetInfoAccount(indexRow);
				bool flag4 = infoAccount2 == "Live";
				if (flag4)
				{
					this.dgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
				}
				else
				{
					bool flag5 = infoAccount2.Contains("Die") || infoAccount2.Contains("Checkpoint") || infoAccount2.Contains("Changed pass");
					if (flag5)
					{
						this.dgvAcc.Rows[indexRow].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
					}
				}
			}
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00023137 File Offset: 0x00021337
		public void SetInfoAccount(int indexRow, string value)
		{
			DatagridviewHelper.SetStatusDataGridView(this.dgvAcc, indexRow, "cInfo", value);
			this.SetRowColor(indexRow);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x00023158 File Offset: 0x00021358
		private bool CheckStatusAccIsCheckPoint(Device device)
		{
			bool result = false;
			for (int i = 0; i < 60; i++)
			{
				string html = device.GetHtml();
				bool flag = device.GetListText(html, 0).Count != 1;
				if (flag)
				{
					bool flag2 = device.CheckExistText("we need more information", html, 5.0);
					if (flag2)
					{
						result = true;
						break;
					}
					bool flag3 = device.CheckExistText("Something went wrong. Please try again.", html, 5.0);
					if (flag3)
					{
						result = true;
						break;
					}
					bool flag4 = device.CheckExistText("chúng tôi cần thêm thông tin", html, 5.0);
					if (flag4)
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0600021E RID: 542 RVA: 0x0002320C File Offset: 0x0002140C
		private int CheckGoToProfileUidSuccess(Device device, int indexRow, string statusProxy)
		{
			int result = 0;
			int num = 0;
			int num2 = 5;
			for (int i = 0; i < 60; i++)
			{
				string html = device.GetHtml();
				bool flag = device.GetListText(html, 0).Count != 1;
				if (flag)
				{
					bool flag2 = !device.CheckExistText("profile picture", html, 0.0);
					if (flag2)
					{
						bool flag3 = device.CheckExistText("reload page", html, 0.0);
						if (flag3)
						{
							num++;
							bool flag4 = num < num2;
							if (flag4)
							{
								device.TapByText("reload page", html, 0);
								goto IL_ED;
							}
						}
						else
						{
							int num3 = this.CheckStatusDevice(device, indexRow, statusProxy);
							bool flag5 = num3 != 1;
							if (flag5)
							{
								bool flag6 = num3 == 0;
								if (flag6)
								{
									goto IL_ED;
								}
								result = 3;
							}
							else
							{
								result = 2;
							}
						}
					}
					else
					{
						result = 1;
					}
					return result;
				}
				device.TapByText(device.GetListText(html, 0)[0], html, 0);
				IL_ED:
				device.DelayTime(1.0);
			}
			return result;
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00023334 File Offset: 0x00021534
		private int CheckStatusDevice(Device device, int indexRow, string statusProxy)
		{
			device.LoadStatusLD("Check status...");
			string html = "";
			int num = device.CheckStatusDevice(ref html, true);
			device.LoadStatusLD(string.Format("Check status: {0}...", num));
			bool flag = (num.ToString() ?? "").StartsWith("-1");
			if (flag)
			{
				bool flag2 = device.CheckExistText("\"ok\"", html, 0.0);
				if (flag2)
				{
					device.TapByText("\"ok\"", html, 0);
				}
				else
				{
					device.ClosePopup(html);
				}
				num = -1;
			}
			int num2 = num;
			int num3 = num2;
			bool flag3 = num3 != -1;
			int result;
			if (flag3)
			{
				result = num;
			}
			else
			{
				bool flag4 = this.isReloginIfLogout;
				if (flag4)
				{
					device.CloseAppFacebook();
					string a = "";
					for (int i = 0; i < 10; i++)
					{
						a = device.OpenFacebookAndCheckStatusLogin(0).Split(new char[]
						{
							'|'
						})[1];
						bool flag5 = a == "0";
						if (flag5)
						{
							break;
						}
					}
					bool flag6 = a != "1" && this.LoginFacebook(device, indexRow, statusProxy) == 1;
					if (flag6)
					{
						return 1;
					}
				}
				result = -1;
			}
			return result;
		}

		// Token: 0x06000220 RID: 544 RVA: 0x0002348C File Offset: 0x0002168C
		private int LoginFacebook(Device device, int indexRow, string statusProxy)
		{
			return -1;
		}

		// Token: 0x06000221 RID: 545 RVA: 0x000234A4 File Offset: 0x000216A4
		private void IncrementLbl(ToolStripStatusLabel lbl1)
		{
			try
			{
				int num = Convert.ToInt32(lbl1.Text);
				lbl1.Text = (num + 1).ToString();
			}
			catch
			{
			}
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000234EC File Offset: 0x000216EC
		private bool CheckIsUidFacebook(string uid)
		{
			return Common.IsNumber(uid) && !uid.StartsWith("0");
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00023518 File Offset: 0x00021718
		private void stopDeviceOneThread(int indexDevice, int indexRow, int indexPos, Device device, bool isSuccess)
		{
			int num = this.rd.Next(this.iDelayClsFr, this.iDelayClsTo + 1);
			bool flag = num > 0;
			if (flag)
			{
				int tickCount = Environment.TickCount;
				while ((Environment.TickCount - tickCount) / 1000 - num < 0)
				{
					bool flag2 = this.isStop;
					if (flag2)
					{
						this.SetStatusAccount(indexRow, "Đã dừng!", null);
						break;
					}
					this.SetStatusAccount(indexRow, "Đóng LD sau {time}s...".Replace("{time}", (num - (Environment.TickCount - tickCount) / 1000).ToString()), null);
					Common.DelayTime(0.5);
				}
			}
			bool flag3 = !isSuccess;
			if (flag3)
			{
				this.IncrementLbl(this.stTotalFail);
				this.SetStatusAccount(indexRow, "Tạo tài khoản thất bại", device);
			}
			else
			{
				this.IncrementLbl(this.stTotalSuccess);
				this.SetStatusAccount(indexRow, "Tạo tài khoản thành công", device);
			}
			this.lstDevice.Remove(device);
			device.Close();
			frmViewLD.remote.RemovePanelDevice(device.IndexDevice);
			bool isAutoClearLD = Settings.Default.isAutoClearLD;
			if (isAutoClearLD)
			{
				bool flag4 = Directory.Exists(this.pathLD + "\\vms\\leidian" + indexDevice.ToString());
				if (flag4)
				{
					bool flag6;
					do
					{
						string pathFolder = this.pathLD + "\\vms\\leidian" + indexDevice.ToString();
						bool flag5 = Common.DeleteFolder(pathFolder);
						flag6 = flag5;
					}
					while (!flag6);
				}
				bool flag7 = File.Exists(this.pathLD + "\\vms\\config\\leidian" + indexDevice.ToString() + ".config");
				if (flag7)
				{
					bool flag9;
					do
					{
						string pathFile = this.pathLD + "\\vms\\config\\leidian" + indexDevice.ToString() + ".config";
						bool flag8 = Common.DeleteFile(pathFile);
						flag9 = flag8;
					}
					while (!flag9);
				}
			}
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00023708 File Offset: 0x00021908
		private void CloseFormViewLD()
		{
			Common.CloseForm("frmViewLD");
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00023716 File Offset: 0x00021916
		private void Delay(double delay)
		{
			Application.DoEvents();
			Thread.Sleep(Convert.ToInt32(delay * 1000.0));
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00023738 File Offset: 0x00021938
		private void LoadStatusGrid(string status, string colname, int rowIndex, int typeColor, DataGridView gv)
		{
			try
			{
				gv.Invoke(new Action(delegate()
				{
					gv.Rows[rowIndex].Cells[colname].Value = status;
				}));
			}
			catch
			{
			}
		}

		// Token: 0x06000227 RID: 551 RVA: 0x0002379C File Offset: 0x0002199C
		private string GetPrePhone()
		{
			string str = "";
			Random random = new Random();
			string text = "91|94";
			string str2 = text.Split(new char[]
			{
				'|'
			})[random.Next(0, text.Split(new char[]
			{
				'|'
			}).Length)];
			return str + str2;
		}

		// Token: 0x06000228 RID: 552 RVA: 0x000237F8 File Offset: 0x000219F8
		private string GetIp()
		{
			string result = "";
			try
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36"
				});
				string text = requestHTTP.Request("GET", "http://lumtest.com/myip.json", null, null, true, null, 60000).ToString();
				JObject jobject = JObject.Parse(text);
				result = jobject["ip"].ToString();
			}
			catch
			{
				result = "Lỗi lấy IP";
			}
			return result;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x000238A0 File Offset: 0x00021AA0
		private void label2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600022A RID: 554 RVA: 0x000238A4 File Offset: 0x00021AA4
		private void LoadCbbLocation()
		{
			Dictionary<string, string> dataSource = this.TinsoftGetListLocation();
			this.cbLocationProxy.DataSource = new BindingSource(dataSource, null);
			this.cbLocationProxy.ValueMember = "Key";
			this.cbLocationProxy.DisplayMember = "Value";
		}

		// Token: 0x0600022B RID: 555 RVA: 0x000238F0 File Offset: 0x00021AF0
		public Dictionary<string, string> TinsoftGetListLocation()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			List<string> listCountryTinsoft = TinsoftProxy.GetListCountryTinsoft();
			for (int i = 0; i < listCountryTinsoft.Count; i++)
			{
				string[] array = listCountryTinsoft[i].Split(new char[]
				{
					'|'
				});
				dictionary.Add(array[0], array[1]);
			}
			return dictionary;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00023950 File Offset: 0x00021B50
		private void LoadSettings()
		{
			try
			{
				IniFile iniFile = new IniFile("setting.ini");
				this.numThrLdPlay.Value = Convert.ToInt32(iniFile.Read("nudThread", null));
				this.numOTP.Value = Convert.ToInt32(iniFile.Read("nudThoiGianChoNhapOTP", null));
				this.rdNormal.Checked = true;
				this.rdDelayLD.Checked = true;
				this.numDelayFr.Value = Convert.ToInt32(iniFile.Read("numDelayFr", null));
				this.numDelayTo.Value = Convert.ToInt32(iniFile.Read("numDelayTo", null));
				this.numDeClsFr.Value = Convert.ToInt32(iniFile.Read("numDeClsFr", null));
				this.numDeClsTo.Value = Convert.ToInt32(iniFile.Read("numDeClsTo", null));
				this.numChangeIP.Value = Convert.ToInt32(iniFile.Read("iSoLuotDoiIpMotLan", null));
				this.nudSoLuotChay.Value = Convert.ToInt32(iniFile.Read("nudSoLuotChay", null));
				this.txtLinkLD.Text = iniFile.Read("linkLD", null);
				this.txtNameDcom.Text = iniFile.Read("txtProfileNameDcom", null);
				this.txtProxy.Text = iniFile.Read("txtAPIProxy", null);
				this.nudLuongPerIPTinsoft.Value = Convert.ToInt32(iniFile.Read("nudLuongPerIPTinsoft", null));
				this.nudLuongPerIPMinProxy.Value = Convert.ToInt32(iniFile.Read("nudLuongPerIPMinProxy", null));
				this.plHotmailReg.Enabled = false;
				string text = iniFile.Read("typeVerify", null);
				try
				{
					bool flag = text.Substring(0, 1) == "0";
					if (flag)
					{
						this.rdNoVeri.Checked = true;
						this.plVeriPhone.Enabled = false;
						this.plVeriMail.Enabled = false;
						bool flag2 = text.Substring(1, 1) == "0";
						if (flag2)
						{
							this.rdNovriPhone.Checked = true;
						}
						else
						{
							this.rdNoveriMail.Checked = true;
							this.cbMailAo.SelectedIndex = Convert.ToInt32(text.Substring(2, 1));
						}
					}
					else
					{
						this.rdThuePhone.Checked = true;
						this.plNovery.Enabled = false;
						this.plVeriMail.Enabled = false;
						bool flag3 = text.Substring(1, 1) == "0";
						if (flag3)
						{
							this.cbDvSim.SelectedIndex = Convert.ToInt32(text.Substring(2, 1));
						}
						else
						{
							this.rdConfMail.Checked = true;
							string text2 = text.Substring(2, 1);
							bool flag4 = text2 != null;
							if (flag4)
							{
								bool flag5 = !(text2 == "0");
								if (flag5)
								{
									bool flag6 = text2 == "1";
									if (flag6)
									{
										this.rdHotMailRegisted.Checked = true;
									}
								}
								else
								{
									this.rdHotMailReg.Checked = true;
									this.plHotmailReg.Enabled = true;
								}
							}
						}
					}
				}
				catch
				{
					this.rdNoVeri.Checked = true;
					this.rdNovriPhone.Checked = true;
				}
				this.ckTaoMailBox.Checked = Convert.ToBoolean(iniFile.Read("ckTaoMailBox", null));
				this.ckRdPassmail.Checked = Convert.ToBoolean(iniFile.Read("ckRdPassmail", null));
				this.txtPassmail.Text = iniFile.Read("txtPassmail", null);
				this.txtAPISim.Text = iniFile.Read("txtAPISim", null);
				this.txtAPIAnyCat.Text = iniFile.Read("txtAPIAnyCat", null);
				this.cbNameReg.SelectedIndex = Convert.ToInt32(iniFile.Read("typeNameReg", null));
				this.txtPassFb.Text = iniFile.Read("passFB", null);
				this.chkRandomPass.Checked = Convert.ToBoolean(iniFile.Read("isRdPass", null));
				switch (Convert.ToInt32(iniFile.Read("typeGender", null)))
				{
				case 0:
					this.rbFemale.Checked = true;
					break;
				case 1:
					this.rbMale.Checked = true;
					break;
				case 2:
					this.rbRandomMF.Checked = true;
					break;
				}
				switch (Convert.ToInt32(iniFile.Read("typeChangeIp", null)))
				{
				case 0:
					this.rdNoChangeIP.Checked = true;
					this.plChangeIPDcom.Enabled = false;
					this.plTinsoftProxy.Enabled = false;
					this.pnlAPIMinProxy.Enabled = false;
					this.plCheckDoiIP.Enabled = false;
					break;
				case 1:
					this.rdChangeIPDcom.Checked = true;
					this.plTinsoftProxy.Enabled = false;
					this.pnlAPIMinProxy.Enabled = false;
					break;
				case 2:
					this.rdTinsoftProxy.Checked = true;
					this.plChangeIPDcom.Enabled = false;
					this.pnlAPIMinProxy.Enabled = false;
					this.plCheckDoiIP.Enabled = false;
					break;
				case 3:
					this.rdMinProxy.Checked = true;
					this.plChangeIPDcom.Enabled = false;
					this.plTinsoftProxy.Enabled = false;
					this.plCheckDoiIP.Enabled = false;
					break;
				case 4:
					this.rdHMA.Checked = true;
					this.plTinsoftProxy.Enabled = false;
					this.pnlAPIMinProxy.Enabled = false;
					this.plChangeIPDcom.Enabled = false;
					break;
				}
				this.cbLocationProxy.SelectedValue = iniFile.Read("cbbLocationTinsoft", null);
				this.chk2FA.Checked = Convert.ToBoolean(iniFile.Read("is2Fa", null));
				this.chkAvartar.Checked = Convert.ToBoolean(iniFile.Read("isAvartar", null));
				this.chkCoverImg.Checked = Convert.ToBoolean(iniFile.Read("isCoverImg", null));
				this.cbbPhoneCountry.SelectedIndex = Convert.ToInt32(iniFile.Read("cbbPhoneCountry", null));
				this.chkAddFUID.Checked = Convert.ToBoolean(iniFile.Read("chkAddFUID", null));
				this.chkInNewfeed.Checked = Convert.ToBoolean(iniFile.Read("chkInNewfeed", null));
				this.chkWStory.Checked = Convert.ToBoolean(iniFile.Read("chkWStory", null));
				this.chkWatch.Checked = Convert.ToBoolean(iniFile.Read("chkWatch", null));
				this.chkReadNotifi.Checked = Convert.ToBoolean(iniFile.Read("chkReadNotifi", null));
				this.nFriendFrom.Value = Convert.ToInt32(iniFile.Read("nFriendFrom", null));
				this.nFriendTo.Value = Convert.ToInt32(iniFile.Read("nFriendTo", null));
				this.chkLike.Checked = Convert.ToBoolean(iniFile.Read("chkLike", null));
				this.chkBuon.Checked = Convert.ToBoolean(iniFile.Read("chkBuon", null));
				this.chkTym.Checked = Convert.ToBoolean(iniFile.Read("chkTym", null));
				this.chkGian.Checked = Convert.ToBoolean(iniFile.Read("chkGian", null));
				this.chkHaha.Checked = Convert.ToBoolean(iniFile.Read("chkHaha", null));
				this.chkHideBrowser.Checked = Convert.ToBoolean(iniFile.Read("chkHideBrowser", null));
				this.txtLinkAvartar.Text = ((iniFile.Read("linkAvartar", null) == "") ? "" : iniFile.Read("linkAvartar", null));
				this.plAddfriend.Enabled = this.chkAddFUID.Checked;
				this.gbCamxuc.Enabled = this.chkWStory.Checked;
				this.pnlAPIMinProxy.Enabled = this.rdMinProxy.Checked;
				bool @checked = this.chkLike.Checked;
				if (@checked)
				{
					this.typeReaction.Add(1.ToString());
				}
				bool checked2 = this.chkTym.Checked;
				if (checked2)
				{
					this.typeReaction.Add(2.ToString());
				}
				bool checked3 = this.chkHaha.Checked;
				if (checked3)
				{
					this.typeReaction.Add(3.ToString());
				}
				bool checked4 = this.chkBuon.Checked;
				if (checked4)
				{
					this.typeReaction.Add(4.ToString());
				}
				bool checked5 = this.chkGian.Checked;
				if (checked5)
				{
					this.typeReaction.Add(5.ToString());
				}
				string text3 = iniFile.Read("apiMinProxy", null);
				bool flag7 = text3 != string.Empty;
				if (flag7)
				{
					string[] array = text3.Split(new char[]
					{
						'|'
					});
					string text4 = string.Empty;
					for (int i = 0; i < array.Length; i++)
					{
						this.listProxyMinProxy.Add(array[i]);
						text4 += array[i];
						bool flag8 = i < array.Length - 1;
						if (flag8)
						{
							text4 += Environment.NewLine;
						}
					}
					this.txtApiKeyMinProxy.Text = text4;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00024374 File Offset: 0x00022574
		private void btnSaveConf_Click(object sender, EventArgs e)
		{
			try
			{
				IniFile iniFile = new IniFile("setting.ini");
				iniFile.Write("nudThread", this.numThrLdPlay.Value.ToString(), null);
				iniFile.Write("nudThoiGianChoNhapOTP", this.numOTP.Value.ToString(), null);
				int num = 0;
				bool @checked = this.rdNormal.Checked;
				if (@checked)
				{
					num = 0;
				}
				iniFile.Write("modeRun", num.ToString(), null);
				int num2 = 0;
				bool checked2 = this.rdDelayLD.Checked;
				if (checked2)
				{
					num2 = 1;
				}
				iniFile.Write("optionMemu", num2.ToString(), null);
				iniFile.Write("numDelayFr", this.numDelayFr.Value.ToString(), null);
				iniFile.Write("numDelayTo", this.numDelayTo.Value.ToString(), null);
				iniFile.Write("numDeClsFr", this.numDeClsFr.Value.ToString(), null);
				iniFile.Write("numDeClsTo", this.numDeClsTo.Value.ToString(), null);
				iniFile.Write("linkLD", this.txtLinkLD.Text.Trim(), null);
				int num3 = 0;
				bool checked3 = this.rdNoChangeIP.Checked;
				if (checked3)
				{
					num3 = 0;
				}
				else
				{
					bool checked4 = this.rdChangeIPDcom.Checked;
					if (checked4)
					{
						num3 = 1;
					}
					else
					{
						bool checked5 = this.rdTinsoftProxy.Checked;
						if (checked5)
						{
							num3 = 2;
						}
						else
						{
							bool checked6 = this.rdMinProxy.Checked;
							if (checked6)
							{
								num3 = 3;
							}
							else
							{
								bool checked7 = this.rdHMA.Checked;
								if (checked7)
								{
									num3 = 4;
								}
							}
						}
					}
				}
				iniFile.Write("typeChangeIp", num3.ToString(), null);
				iniFile.Write("txtProfileNameDcom", this.txtNameDcom.Text, null);
				iniFile.Write("txtAPIProxy", this.txtProxy.Text, null);
				iniFile.Write("cbbLocationTinsoft", this.cbLocationProxy.SelectedValue.ToString(), null);
				iniFile.Write("nudLuongPerIPTinsoft", this.nudLuongPerIPTinsoft.Value.ToString(), null);
				iniFile.Write("nudSoLuotChay", this.nudSoLuotChay.Value.ToString(), null);
				iniFile.Write("nudLuongPerIPMinProxy", this.nudLuongPerIPMinProxy.Value.ToString(), null);
				bool flag = this.txtApiKeyMinProxy.Text != "";
				if (flag)
				{
					string[] array = this.txtApiKeyMinProxy.Text.Split(new char[]
					{
						'\n'
					});
					bool flag2 = array.Length != 0;
					if (flag2)
					{
						string text = string.Empty;
						for (int i = 0; i < array.Length; i++)
						{
							this.listProxyMinProxy.Add(array[i]);
							text += array[i];
							bool flag3 = i < array.Length - 1;
							if (flag3)
							{
								text += "|";
							}
						}
						iniFile.Write("apiMinProxy", text, null);
					}
				}
				else
				{
					iniFile.Write("apiMinProxy", string.Empty, null);
				}
				string value = "";
				bool checked8 = this.rdNoVeri.Checked;
				if (checked8)
				{
					bool checked9 = this.rdNovriPhone.Checked;
					if (checked9)
					{
						value = "00";
					}
					else
					{
						bool checked10 = this.rdNoveriMail.Checked;
						if (checked10)
						{
							value = "01" + this.cbMailAo.SelectedIndex.ToString();
						}
					}
				}
				else
				{
					bool checked11 = this.rdThuePhone.Checked;
					if (checked11)
					{
						value = "10" + this.cbDvSim.SelectedIndex.ToString();
					}
					else
					{
						bool checked12 = this.rdHotMailReg.Checked;
						if (checked12)
						{
							value = "110";
						}
						else
						{
							bool checked13 = this.rdHotMailRegisted.Checked;
							if (checked13)
							{
								value = "111";
							}
						}
					}
				}
				iniFile.Write("typeVerify", value, null);
				iniFile.Write("txtAPISim", this.txtAPISim.Text, null);
				iniFile.Write("txtAPIAnyCat", this.txtAPIAnyCat.Text, null);
				iniFile.Write("txtPassmail", this.txtPassmail.Text, null);
				iniFile.Write("ckTaoMailBox", this.ckTaoMailBox.Checked.ToString(), null);
				iniFile.Write("ckRdPassmail", this.ckRdPassmail.Checked.ToString(), null);
				iniFile.Write("typeNameReg", this.cbNameReg.SelectedIndex.ToString(), null);
				iniFile.Write("passFB", this.txtPassFb.Text, null);
				iniFile.Write("isRdPass", this.chkRandomPass.Checked.ToString(), null);
				bool checked14 = this.rbFemale.Checked;
				int num4;
				if (checked14)
				{
					num4 = 0;
				}
				else
				{
					bool checked15 = this.rbMale.Checked;
					if (checked15)
					{
						num4 = 1;
					}
					else
					{
						num4 = 2;
					}
				}
				iniFile.Write("typeGender", num4.ToString(), null);
				iniFile.Write("is2Fa", this.chk2FA.Checked.ToString(), null);
				iniFile.Write("isAvartar", this.chkAvartar.Checked.ToString(), null);
				iniFile.Write("isCoverImg", this.chkCoverImg.Checked.ToString(), null);
				iniFile.Write("cbbPhoneCountry", this.cbbPhoneCountry.SelectedIndex.ToString(), null);
				iniFile.Write("iSoLuotDoiIpMotLan", this.numChangeIP.Value.ToString(), null);
				iniFile.Write("chkReadNotifi", this.chkReadNotifi.Checked.ToString(), null);
				iniFile.Write("chkWatch", this.chkWatch.Checked.ToString(), null);
				iniFile.Write("chkWStory", this.chkWStory.Checked.ToString(), null);
				iniFile.Write("chkInNewfeed", this.chkInNewfeed.Checked.ToString(), null);
				iniFile.Write("chkAddFUID", this.chkAddFUID.Checked.ToString(), null);
				iniFile.Write("nFriendFrom", this.nFriendFrom.Value.ToString(), null);
				iniFile.Write("nFriendTo", this.nFriendTo.Value.ToString(), null);
				iniFile.Write("chkLike", this.chkLike.Checked.ToString(), null);
				iniFile.Write("chkGian", this.chkGian.Checked.ToString(), null);
				iniFile.Write("chkHaha", this.chkHaha.Checked.ToString(), null);
				iniFile.Write("chkBuon", this.chkBuon.Checked.ToString(), null);
				iniFile.Write("chkTym", this.chkTym.Checked.ToString(), null);
				iniFile.Write("chkHideBrowser", this.chkHideBrowser.Checked.ToString(), null);
				iniFile.Write("linkAvartar", this.txtLinkAvartar.Text.Trim(), null);
				MessageBox.Show("Lưu cấu hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch
			{
			}
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00024B74 File Offset: 0x00022D74
		private void btnStop_Click(object sender, EventArgs e)
		{
			this.plTrangThai.Text = "Đã dừng";
			this.plTrangThai.ForeColor = Color.Red;
			this.isStop = true;
			this.listThread.Clear();
			this.lstDevice.Clear();
			this.cControl("stop");
			this.CloseFormViewLD();
			bool isAutoClearLD = Settings.Default.isAutoClearLD;
			if (isAutoClearLD)
			{
				Common.ClearCacheLDPlayer(this.pathLD);
			}
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00024BF0 File Offset: 0x00022DF0
		private void SetStatusAccount(int indexRow, string value, Device device = null)
		{
			this.LoadStatusGrid(value, "status", indexRow, 0, this.dgvAcc);
			bool flag = device != null;
			if (flag)
			{
				bool flag2 = value.StartsWith("(");
				if (flag2)
				{
					value = value.Substring(value.IndexOf(")") + 1);
				}
				device.LoadHanhDongLD(value);
			}
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00024C4C File Offset: 0x00022E4C
		private void btnCheckSim_Click(object sender, EventArgs e)
		{
			try
			{
				bool @checked = this.rdThuePhone.Checked;
				if (@checked)
				{
					string text = this.txtAPISim.Text.ToString();
					string text2 = string.Empty;
					bool flag = this.cbDvSim.SelectedIndex == 0;
					if (flag)
					{
						text2 = Common.CheckBalanceSimThue(text, 60, 1001);
						bool flag2 = text2 == "";
						if (flag2)
						{
							MessageBox.Show("API key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							MessageBox.Show("Số tiền: " + text2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
					else
					{
						bool flag3 = this.cbDvSim.SelectedIndex == 1;
						if (flag3)
						{
							text2 = Common.CheckBalanceViotp(text, 60, 7);
							bool flag4 = text2 == "";
							if (flag4)
							{
								MessageBox.Show("Token này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
							else
							{
								MessageBox.Show("Số tiền: " + text2, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							}
						}
						else
						{
							bool flag5 = this.cbDvSim.SelectedIndex == 2;
							if (flag5)
							{
								bool flag6 = Common.CheckKeyCodetextNow(text, 60);
								bool flag7 = flag6;
								if (flag7)
								{
									MessageBox.Show("Api key hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
								else
								{
									MessageBox.Show("Api key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
							}
							else
							{
								bool flag8 = this.cbDvSim.SelectedIndex == 3;
								if (flag8)
								{
									MessageBox.Show("OTPMMO không hỗ trợ API check Balance!!!" + Environment.NewLine + "Bạn kiểm tra số tiền trên web https://otpmmo.com trước khi chạy nha! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00024E20 File Offset: 0x00023020
		private void frmMain_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00024E23 File Offset: 0x00023023
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.stopAll();
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00024E30 File Offset: 0x00023030
		private void btnGetDcom_Click(object sender, EventArgs e)
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo("rasdial.exe")
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				};
				Process process = Process.Start(startInfo);
				string text = process.StandardOutput.ReadToEnd();
				bool flag = text.Split(new char[]
				{
					'\n'
				}).Length <= 3;
				if (flag)
				{
					MessageBox.Show("Vui lòng kết nối Dcom trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					this.txtNameDcom.Text = text.Split(new char[]
					{
						'\n'
					}).ToList<string>()[1];
					MessageBox.Show("Lấy tên cấu hình Dcom thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00024F14 File Offset: 0x00023114
		private void rdProxy_CheckedChanged(object sender, EventArgs e)
		{
			this.plTinsoftProxy.Enabled = this.rdTinsoftProxy.Checked;
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00024F2E File Offset: 0x0002312E
		private void rdConfMail_CheckedChanged(object sender, EventArgs e)
		{
			this.plVeriMail.Enabled = this.rdConfMail.Checked;
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00024F48 File Offset: 0x00023148
		private void rdThuePhone_CheckedChanged(object sender, EventArgs e)
		{
			this.plVeriPhone.Enabled = this.rdThuePhone.Checked;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00024F64 File Offset: 0x00023164
		private void btnCheckProxy_Click(object sender, EventArgs e)
		{
			string api_user = this.txtProxy.Text.Trim();
			List<string> listKey = TinsoftProxy.GetListKey(api_user);
			bool flag = listKey.Count > 0;
			if (flag)
			{
				MessageBox.Show(string.Format("Đang có {0} proxy khả dụng!", listKey.Count), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show("Không có proxy khả dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00024FD3 File Offset: 0x000231D3
		private void rdNoVeri_CheckedChanged(object sender, EventArgs e)
		{
			this.plNovery.Enabled = this.rdNoVeri.Checked;
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00024FED File Offset: 0x000231ED
		private void tấtCảToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChoseRowInDatagrid("All");
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00024FFC File Offset: 0x000231FC
		private void ChoseRowInDatagrid(string modeChose)
		{
			bool flag = !(modeChose == "All");
			if (flag)
			{
				bool flag2 = !(modeChose == "UnAll");
				if (flag2)
				{
					bool flag3 = !(modeChose == "SelectHighline");
					if (flag3)
					{
						bool flag4 = modeChose == "ToggleCheck";
						if (flag4)
						{
							for (int i = 0; i < this.dgvAcc.SelectedRows.Count; i++)
							{
								int index = this.dgvAcc.SelectedRows[i].Index;
								this.SetCellAccount(index, "cChose", !Convert.ToBoolean(this.GetCellAccount(index, "cChose")), true);
							}
							this.CountCheckedAccount(-1);
						}
					}
					else
					{
						DataGridViewSelectedRowCollection selectedRows = this.dgvAcc.SelectedRows;
						for (int j = 0; j < selectedRows.Count; j++)
						{
							this.SetCellAccount(selectedRows[j].Index, "cChose", true, true);
						}
						this.CountCheckedAccount(-1);
					}
				}
				else
				{
					for (int k = 0; k < this.dgvAcc.RowCount; k++)
					{
						this.SetCellAccount(k, "cChose", false, true);
					}
					this.CountCheckedAccount(0);
				}
			}
			else
			{
				for (int l = 0; l < this.dgvAcc.RowCount; l++)
				{
					this.SetCellAccount(l, "cChose", true, true);
				}
				this.CountCheckedAccount(this.dgvAcc.RowCount);
			}
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000251BC File Offset: 0x000233BC
		private void CountCheckedAccount(int count = -1)
		{
			bool flag = count == -1;
			if (flag)
			{
				count = 0;
				for (int i = 0; i < this.dgvAcc.Rows.Count; i++)
				{
					bool flag2 = Convert.ToBoolean(this.dgvAcc.Rows[i].Cells["cChose"].Value);
					if (flag2)
					{
						count++;
					}
				}
			}
			this.lblCountSelect.Text = count.ToString();
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00025240 File Offset: 0x00023440
		private void bỏChọnTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChoseRowInDatagrid("UnAll");
		}

		// Token: 0x0600023D RID: 573 RVA: 0x0002524F File Offset: 0x0002344F
		private void bôiĐenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.ChoseRowInDatagrid("SelectHighline");
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00025260 File Offset: 0x00023460
		private uint ComputeStringHash(string s)
		{
			uint num = 0U;
			bool flag = s != null;
			if (flag)
			{
				num = 2166136261U;
				for (int i = 0; i < s.Length; i++)
				{
					num = ((uint)s[i] ^ num) * 16777619U;
				}
			}
			return num;
		}

		// Token: 0x0600023F RID: 575 RVA: 0x000252B0 File Offset: 0x000234B0
		private void CopyRowDatagrid(string modeCopy)
		{
			try
			{
				string text = "";
				List<string> list = new List<string>();
				int i = 0;
				while (i < this.dgvAcc.Rows.Count)
				{
					bool flag = !Convert.ToBoolean(this.GetCellAccount(i, "cChose"));
					if (flag)
					{
						i++;
					}
					else
					{
						list.Add(this.GetCellAccount(i, "cId"));
						bool flag2 = list.Count == 0;
						if (flag2)
						{
							MessageBox.Show("Vui lòng chọn danh sách tài khoản muốn copy thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							break;
						}
						uint num = this.ComputeStringHash(modeCopy);
						bool flag3 = num <= 2071622424U;
						if (flag3)
						{
							bool flag4 = num <= 1329202400U;
							if (flag4)
							{
								bool flag5 = num <= 457434463U;
								if (flag5)
								{
									bool flag6 = num != 159575910U;
									if (flag6)
									{
										bool flag7 = num == 457434463U;
										if (flag7)
										{
											bool flag8 = modeCopy == "uid|pass|token|cookie";
											if (flag8)
											{
												for (int j = 0; j < this.dgvAcc.RowCount; j++)
												{
													bool flag9 = Convert.ToBoolean(this.dgvAcc.Rows[j].Cells["cChose"].Value);
													if (flag9)
													{
														text = string.Concat(new string[]
														{
															text,
															this.GetCellAccount(j, "uid"),
															"|",
															this.GetCellAccount(j, "pass"),
															"|",
															this.GetCellAccount(j, "token"),
															"|",
															this.GetCellAccount(j, "cookie"),
															"\r\n"
														});
													}
												}
											}
										}
									}
									else
									{
										bool flag10 = modeCopy == "uid|pass";
										if (flag10)
										{
											for (int k = 0; k < this.dgvAcc.RowCount; k++)
											{
												bool flag11 = Convert.ToBoolean(this.dgvAcc.Rows[k].Cells["cChose"].Value);
												if (flag11)
												{
													text = string.Concat(new string[]
													{
														text,
														this.GetCellAccount(k, "uid"),
														"|",
														this.GetCellAccount(k, "pass"),
														"\r\n"
													});
												}
											}
										}
									}
								}
								else
								{
									bool flag12 = num != 738560386U;
									if (flag12)
									{
										bool flag13 = num == 1329202400U;
										if (flag13)
										{
											bool flag14 = modeCopy == "mail|passmail";
											if (flag14)
											{
												for (int l = 0; l < this.dgvAcc.RowCount; l++)
												{
													bool flag15 = Convert.ToBoolean(this.dgvAcc.Rows[l].Cells["cChose"].Value);
													if (flag15)
													{
														text = string.Concat(new string[]
														{
															text,
															this.GetCellAccount(l, "email"),
															"|",
															this.GetCellAccount(l, "passMail"),
															"\r\n"
														});
													}
												}
											}
										}
									}
									else
									{
										bool flag16 = modeCopy == "ma2fa";
										if (flag16)
										{
										}
									}
								}
							}
							else
							{
								bool flag17 = num <= 1718322808U;
								if (flag17)
								{
									bool flag18 = num != 1556604621U;
									if (flag18)
									{
										bool flag19 = num == 1718322808U;
										if (flag19)
										{
											bool flag20 = modeCopy == "2fa";
											if (flag20)
											{
												for (int m = 0; m < this.dgvAcc.RowCount; m++)
												{
													bool flag21 = Convert.ToBoolean(this.dgvAcc.Rows[m].Cells["cChose"].Value);
													if (flag21)
													{
														text = text + this.GetCellAccount(m, "cFa2") + "\r\n";
													}
												}
											}
										}
									}
									else
									{
										bool flag22 = modeCopy == "uid";
										if (flag22)
										{
											for (int n = 0; n < this.dgvAcc.RowCount; n++)
											{
												bool flag23 = Convert.ToBoolean(this.dgvAcc.Rows[n].Cells["cChose"].Value);
												if (flag23)
												{
													text = text + this.GetCellAccount(n, "cUid") + "\r\n";
												}
											}
										}
									}
								}
								else
								{
									bool flag24 = num != 2007449791U;
									if (flag24)
									{
										bool flag25 = num == 2071622424U;
										if (flag25)
										{
											bool flag26 = modeCopy == "pass";
											if (flag26)
											{
												for (int num2 = 0; num2 < this.dgvAcc.RowCount; num2++)
												{
													bool flag27 = Convert.ToBoolean(this.dgvAcc.Rows[num2].Cells["cChose"].Value);
													if (flag27)
													{
														text = text + this.GetCellAccount(num2, "cPassword") + "\r\n";
													}
												}
											}
										}
									}
									else
									{
										bool flag28 = modeCopy == "cookie";
										if (flag28)
										{
											for (int num3 = 0; num3 < this.dgvAcc.RowCount; num3++)
											{
												bool flag29 = Convert.ToBoolean(this.dgvAcc.Rows[num3].Cells["cChose"].Value);
												if (flag29)
												{
													string cellAccount = this.GetCellAccount(num3, "cCookies");
													text = text + cellAccount + "\r\n";
												}
											}
										}
									}
								}
							}
						}
						else
						{
							bool flag30 = num <= 2491017778U;
							if (flag30)
							{
								bool flag31 = num <= 2337339239U;
								if (flag31)
								{
									bool flag32 = num != 2107770459U;
									if (flag32)
									{
										bool flag33 = num == 2337339239U;
										if (flag33)
										{
											bool flag34 = modeCopy == "useragent";
											if (flag34)
											{
												for (int num4 = 0; num4 < this.dgvAcc.RowCount; num4++)
												{
													bool flag35 = Convert.ToBoolean(this.dgvAcc.Rows[num4].Cells["cChose"].Value);
													if (flag35)
													{
														text = text + this.GetCellAccount(num4, "cUseragent") + "\r\n";
													}
												}
											}
										}
									}
									else
									{
										bool flag36 = modeCopy == "proxy";
										if (flag36)
										{
											for (int num5 = 0; num5 < this.dgvAcc.RowCount; num5++)
											{
												bool flag37 = Convert.ToBoolean(this.dgvAcc.Rows[num5].Cells["cChose"].Value);
												if (flag37)
												{
													text = string.Concat(new string[]
													{
														text,
														this.GetCellAccount(num5, "uid"),
														"|",
														this.GetCellAccount(num5, "pass"),
														"|",
														this.GetCellAccount(num5, "conf_2fa"),
														"|",
														this.GetCellAccount(num5, "cookie"),
														"|",
														this.GetCellAccount(num5, "token"),
														"|",
														this.GetCellAccount(num5, "ho"),
														"|",
														this.GetCellAccount(num5, "ten"),
														"|",
														this.GetCellAccount(num5, "gender"),
														"|",
														this.GetCellAccount(num5, "phone"),
														"|",
														this.GetCellAccount(num5, "email"),
														"|",
														this.GetCellAccount(num5, "passMail"),
														"|",
														this.GetCellAccount(num5, "proxy"),
														"\r\n"
													});
												}
											}
										}
									}
								}
								else
								{
									bool flag38 = num != 2369371622U;
									if (flag38)
									{
										bool flag39 = num == 2491017778U;
										if (flag39)
										{
											bool flag40 = modeCopy == "token";
											if (flag40)
											{
												for (int num6 = 0; num6 < this.dgvAcc.RowCount; num6++)
												{
													bool flag41 = Convert.ToBoolean(this.dgvAcc.Rows[num6].Cells["cChose"].Value);
													if (flag41)
													{
														text = text + this.GetCellAccount(num6, "cToken") + "\r\n";
													}
												}
											}
										}
									}
									else
									{
										bool flag42 = modeCopy == "name";
										if (flag42)
										{
											for (int num7 = 0; num7 < this.dgvAcc.RowCount; num7++)
											{
												bool flag43 = Convert.ToBoolean(this.dgvAcc.Rows[num7].Cells["cChose"].Value);
												if (flag43)
												{
													text = text + this.GetCellAccount(num7, "cName") + "\r\n";
												}
											}
										}
									}
								}
							}
							else
							{
								bool flag44 = num <= 3144981877U;
								if (flag44)
								{
									bool flag45 = num != 2703251604U;
									if (flag45)
									{
										bool flag46 = num == 3144981877U;
										if (flag46)
										{
											bool flag47 = modeCopy == "uid|pass|2fa";
											if (flag47)
											{
												for (int num8 = 0; num8 < this.dgvAcc.RowCount; num8++)
												{
													bool flag48 = Convert.ToBoolean(this.dgvAcc.Rows[num8].Cells["cChose"].Value);
													if (flag48)
													{
														text = string.Concat(new string[]
														{
															text,
															this.GetCellAccount(num8, "uid"),
															"|",
															this.GetCellAccount(num8, "pass"),
															"|",
															this.GetCellAccount(num8, "conf_2fa"),
															"\r\n"
														});
													}
												}
											}
										}
									}
									else
									{
										bool flag49 = modeCopy == "uid|pass|token|cookie|mail|passmail";
										if (flag49)
										{
											for (int num9 = 0; num9 < this.dgvAcc.RowCount; num9++)
											{
												bool flag50 = Convert.ToBoolean(this.dgvAcc.Rows[num9].Cells["cChose"].Value);
												if (flag50)
												{
													text = string.Concat(new string[]
													{
														text,
														this.GetCellAccount(num9, "cUid"),
														"|",
														this.GetCellAccount(num9, "cPassword"),
														"|",
														this.GetCellAccount(num9, "cToken"),
														"|",
														this.GetCellAccount(num9, "cCookies"),
														"|",
														this.GetCellAccount(num9, "cEmail"),
														"|",
														this.GetCellAccount(num9, "cPassMail"),
														"\r\n"
													});
												}
											}
										}
									}
								}
								else
								{
									bool flag51 = num != 3728375369U;
									if (flag51)
									{
										bool flag52 = num != 3968918830U;
										if (flag52)
										{
											bool flag53 = num == 4025178668U;
											if (flag53)
											{
												bool flag54 = modeCopy == "birthday";
												if (flag54)
												{
													for (int num10 = 0; num10 < this.dgvAcc.RowCount; num10++)
													{
														bool flag55 = Convert.ToBoolean(this.dgvAcc.Rows[num10].Cells["cChose"].Value);
														if (flag55)
														{
															text = text + this.GetCellAccount(num10, "cBirthday") + "\r\n";
														}
													}
												}
											}
										}
										else
										{
											bool flag56 = modeCopy == "mail";
											if (flag56)
											{
												for (int num11 = 0; num11 < this.dgvAcc.RowCount; num11++)
												{
													bool flag57 = Convert.ToBoolean(this.dgvAcc.Rows[num11].Cells["cChose"].Value);
													if (flag57)
													{
														text = text + this.GetCellAccount(num11, "cEmail") + "\r\n";
													}
												}
											}
										}
									}
									else
									{
										bool flag58 = modeCopy == "uid|pass|token|cookie|mail|passmail|fa2";
										if (flag58)
										{
											for (int num12 = 0; num12 < this.dgvAcc.RowCount; num12++)
											{
												bool flag59 = Convert.ToBoolean(this.dgvAcc.Rows[num12].Cells["cChose"].Value);
												if (flag59)
												{
													text = string.Concat(new string[]
													{
														text,
														this.GetCellAccount(num12, "cUid"),
														"|",
														this.GetCellAccount(num12, "cPassword"),
														"|",
														this.GetCellAccount(num12, "cToken"),
														"|",
														this.GetCellAccount(num12, "cCookies"),
														"|",
														this.GetCellAccount(num12, "cEmail"),
														"|",
														this.GetCellAccount(num12, "cPassMail"),
														"|",
														this.GetCellAccount(num12, "cFa2"),
														"\r\n"
													});
												}
											}
										}
										else
										{
											bool flag60 = modeCopy == "all";
											if (flag60)
											{
											}
										}
									}
								}
							}
						}
						Clipboard.SetText(text.TrimEnd(new char[]
						{
							'\r',
							'\n'
						}));
						break;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000240 RID: 576 RVA: 0x000261B4 File Offset: 0x000243B4
		private void uidPassToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.CopyRowDatagrid("uid|pass");
		}

		// Token: 0x06000241 RID: 577 RVA: 0x000261C3 File Offset: 0x000243C3
		private void uidPassTokenCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.CopyRowDatagrid("uid|pass|token|cookie");
		}

		// Token: 0x06000242 RID: 578 RVA: 0x000261D2 File Offset: 0x000243D2
		private void rdHotMail_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000243 RID: 579 RVA: 0x000261D5 File Offset: 0x000243D5
		private void rdHotMailReg_CheckedChanged(object sender, EventArgs e)
		{
			this.plHotmailReg.Enabled = this.rdHotMailReg.Checked;
		}

		// Token: 0x06000244 RID: 580 RVA: 0x000261F0 File Offset: 0x000243F0
		private string GetRandomPhoneCountry(int phoneCountry)
		{
			string text = "";
			bool flag = phoneCountry == 0;
			bool flag2 = flag;
			if (flag2)
			{
				text = "+84";
				text += this.GetPrePhone();
				for (int i = 0; i < 7; i++)
				{
					text += this.rd.Next(0, 10).ToString();
				}
			}
			else
			{
				bool flag3 = this.PhoneCountry == 1;
				bool flag4 = flag3;
				if (flag4)
				{
					text = "+1-";
					text += this.PhoneBangUS();
					text += "-555-";
					for (int j = 0; j < 4; j++)
					{
						text += this.rd.Next(0, 10).ToString();
					}
				}
			}
			return text;
		}

		// Token: 0x06000245 RID: 581 RVA: 0x000262CC File Offset: 0x000244CC
		private string PhoneBangUS()
		{
			string text = "205|251|659|256|334|907|520|928|480|602|623|501|479|870|341|442|628|657|669|747|752|764|951|209|559|408|831|510|213|310|424|323|562|707|369|627|530|714|949|626|909|916|760|619|858|935|818|415|925|661|805|650|211|720|970|303|719|203|475|860|959|302|411|202|911|239|386|689|754|941|954|561|407|727|352|904|850|786|863|305|321|813|470|478|770|678|404|706|912|229|710|671|808|208|312|773|630|847|708|815|224|331|464|872|217|618|309|260|317|219|765|812|563|641|515|319|712|876|620|785|913|316|270|859|606|502|225|337|985|504|318|207|227|240|443|667|410|301|339|351|774|781|857|978|508|617|413|231|269|989|734|517|313|810|248|278|586|679|947|906|616|320|612|763|952|218|507|651|228|601|557|573|636|660|975|314|816|417|664|406|402|308|775|702|506|603|551|848|862|732|908|201|973|609|856|505|575|585|845|917|516|212|646|315|518|347|718|607|914|631|716|252|336|828|910|980|984|919|704|701|283|380|567|216|614|937|330|234|440|419|740|513|580|918|405|541|971|445|610|835|878|484|717|570|412|215|267|814|724|787|939|401|306|803|843|864|605|731|865|931|423|615|901|325|361|430|432|469|682|737|979|214|972|254|940|713|281|832|956|817|806|903|210|830|409|936|512|915|340|385|435|801|802|276|434|540|571|757|703|804|509|206|425|253|360|564|304|262|920|414|715|608|307|867|866|456|011|880|881|882|500|611|311|200|300|400|700|711|811|800|877|888";
			string[] array = text.Split(new char[]
			{
				'|'
			});
			return array[this.rd.Next(0, array.Length - 1)];
		}

		// Token: 0x06000246 RID: 582 RVA: 0x0002630C File Offset: 0x0002450C
		private string ConvertToUnicode(string text)
		{
			text = text.ToLower().Replace(" ", "");
			text = Common.convertToUnSign3(text);
			return text;
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00026340 File Offset: 0x00024540
		private string GetEmailUsingFirst_LastName(string firstName, string lastName, int typeMail)
		{
			string text = firstName + lastName;
			text = this.ConvertToUnicode(text);
			text += this.rd.Next(0, 1000).ToString();
			text = text.ToLower();
			bool flag = typeMail == 0;
			bool flag2 = flag;
			if (flag2)
			{
				text += "@gmail.com";
			}
			else
			{
				bool flag3 = typeMail == 1;
				bool flag4 = flag3;
				if (flag4)
				{
					text += "@yahoo.com";
				}
				else
				{
					bool flag5 = typeMail == 2;
					bool flag6 = flag5;
					if (flag6)
					{
						text += "@hotmail.com";
					}
				}
			}
			return text;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x000263E4 File Offset: 0x000245E4
		private void chkRandomPass_CheckedChanged(object sender, EventArgs e)
		{
			this.txtPassFb.Enabled = !this.chkRandomPass.Checked;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00026404 File Offset: 0x00024604
		private void dgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool flag = e.ColumnIndex == 0;
			if (flag)
			{
				try
				{
					this.dgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(this.dgvAcc.CurrentRow.Cells["cChose"].Value);
					this.CountCheckedAccount(-1);
				}
				catch
				{
				}
			}
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00026490 File Offset: 0x00024690
		private void dgvAcc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00026493 File Offset: 0x00024693
		private void dgvAcc_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00026498 File Offset: 0x00024698
		private void dgvAcc_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				this.dgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(this.dgvAcc.CurrentRow.Cells["cChose"].Value);
				this.CountCheckedAccount(-1);
			}
			catch
			{
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00026514 File Offset: 0x00024714
		private void uidPass2FAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.CopyRowDatagrid("uid|pass|2fa");
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00026524 File Offset: 0x00024724
		private void btnCheckAPIAny_Click(object sender, EventArgs e)
		{
			string apiKey = this.txtAPIAnyCat.Text.ToString();
			string text = Common.CheckBalanceAnycaptcha(apiKey, 60);
			bool flag = text == "";
			if (flag)
			{
				MessageBox.Show("API key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show("Số tiền còn dư: " + text + " $", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00026594 File Offset: 0x00024794
		private void btnNhapanh_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				folderBrowserDialog.ShowNewFolderButton = true;
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				bool flag = dialogResult == DialogResult.OK;
				if (flag)
				{
					this.txtLinkAvartar.Text = folderBrowserDialog.SelectedPath;
					Environment.SpecialFolder rootFolder = folderBrowserDialog.RootFolder;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00026614 File Offset: 0x00024814
		public string GetPathPictureLDPlayer()
		{
			string result = "";
			try
			{
				string path = this.txtLinkLD.Text + "\\vms\\config\\leidian0.config";
				string text = this.txtLinkLD.Text + "\\vms\\config\\leidian1.config";
				bool flag = File.Exists(text);
				if (flag)
				{
					path = text;
				}
				JObject jobject = JObject.Parse(File.ReadAllText(path));
				result = jobject["statusSettings.sharedPictures"].ToString();
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x000266A4 File Offset: 0x000248A4
		private void liveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectGridByInfo(sender, e);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x000266B0 File Offset: 0x000248B0
		private void SelectGridByInfo(object sender, EventArgs e)
		{
			this.ChooseAccountByValue("cInfo", (sender as ToolStripMenuItem).Text);
		}

		// Token: 0x06000253 RID: 595 RVA: 0x000266CC File Offset: 0x000248CC
		private void ChooseAccountByValue(string column, string value)
		{
			for (int i = 0; i < this.dgvAcc.RowCount; i++)
			{
				this.dgvAcc.Rows[i].Cells["cChose"].Value = this.GetCellAccount(i, column).Contains(value);
			}
			this.CountCheckedAccount(-1);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00026737 File Offset: 0x00024937
		private void dieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectGridByInfo(sender, e);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00026743 File Offset: 0x00024943
		private void checkpointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.SelectGridByInfo(sender, e);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00026750 File Offset: 0x00024950
		private string CreateRandomString(Random rd, int lengText)
		{
			string text = "";
			string text2 = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			for (int i = 0; i < lengText; i++)
			{
				text += text2[rd.Next(0, text2.Length)].ToString();
			}
			return text;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x000267A8 File Offset: 0x000249A8
		private bool regHotmail(int rowIndex)
		{
			bool result = false;
			Chrome chrome = new Chrome();
			chrome.Position = Common.GetPointFromIndexPosition(rowIndex, 6);
			chrome.Size = new Point(this.getWidthChrome, this.getHeightChrome);
			string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36";
			try
			{
				chrome.HideBrowser = this.chkHideBrowser.Checked;
				chrome.UserAgent = userAgent;
				chrome.Open();
			}
			catch (Exception ex)
			{
			}
			this.LoadStatusGrid("Đang đăng ký tài khoản hotmail...", "status", rowIndex, 1, this.dgvAcc);
			chrome.GotoURL("https://signup.live.com/signup");
			chrome.DelayTime(5.0);
			string lastnameVN = this.GetLastnameVN();
			string firstnamemaleVN = this.GetFirstnamemaleVN();
			string emailUsingFirst_LastName = this.GetEmailUsingFirst_LastName(firstnamemaleVN, lastnameVN, 2);
			string content = this.isPassRandom ? this.CreateRandomString(this.rd, 15) : this.sPassmail;
			this.LoadStatusGrid(emailUsingFirst_LastName, "email", rowIndex, 0, this.dgvAcc);
			this.LoadStatusGrid(content, "passMail", rowIndex, 0, this.dgvAcc);
			bool flag = chrome.CheckExistElement("[name=\"MemberName\"]", 60.0);
			if (flag)
			{
				chrome.SendKeys(4, "[name=\"MemberName\"]", emailUsingFirst_LastName, 0.0, true);
			}
			chrome.DelayTime(3.0);
			bool flag2 = emailUsingFirst_LastName.EndsWith("@hotmail.com");
			if (flag2)
			{
				chrome.Select(1, "LiveDomainBoxList", "hotmail.com");
			}
			bool flag3 = !chrome.SendEnter(2, "MemberName");
			if (flag3)
			{
				chrome.ExecuteScript("document.querySelector('#iSignupAction').click()");
			}
			bool flag4 = !chrome.CheckExistElement("#PasswordInput", 10.0);
			if (flag4)
			{
				bool flag5 = chrome.CheckExistElement("#MemberName", 0.0);
				if (flag5)
				{
					this.LoadStatusGrid("Mail không thể đăng ký!", "status", rowIndex, 1, this.dgvAcc);
				}
				else
				{
					this.LoadStatusGrid("Không load được trang!", "status", rowIndex, 1, this.dgvAcc);
				}
			}
			else
			{
				chrome.SendKeys(1, "PasswordInput", content, 0.0, true);
				chrome.DelayTime(1.0);
				bool flag6 = !chrome.SendEnter(1, "PasswordInput");
				if (flag6)
				{
					chrome.ExecuteScript("document.querySelector('#iSignupAction').click()");
				}
				chrome.DelayTime(1.0);
				bool flag7 = chrome.CheckExistElement("#LastName", 60.0);
				if (flag7)
				{
					chrome.SendKeys(1, "LastName", this.HoVietNam(), 0.1, true);
					this.Delay(0.5);
					chrome.SendKeys(1, "FirstName", this.TenVietName(), 0.1, true);
					this.Delay(0.5);
				}
				bool flag8 = !chrome.SendEnter(1, "LastName");
				if (flag8)
				{
					chrome.ExecuteScript("document.querySelector('#iSignupAction').click()");
				}
				chrome.DelayTime(1.0);
				bool flag9 = chrome.CheckExistElement("[name=\"BirthDay\"]", 60.0);
				if (flag9)
				{
					chrome.Select(2, "BirthDay", this.rd.Next(1, 28).ToString());
				}
				bool flag10 = chrome.CheckExistElement("[name=\"BirthMonth\"]", 60.0);
				if (flag10)
				{
					chrome.Select(2, "BirthMonth", this.rd.Next(1, 12).ToString());
				}
				bool flag11 = chrome.CheckExistElement("[name=\"BirthYear\"]", 60.0) && !chrome.Select(2, "BirthYear", this.rd.Next(1970, 2000).ToString());
				if (flag11)
				{
					chrome.SendKeys(2, "BirthYear", this.rd.Next(1970, 2000).ToString(), true);
				}
				chrome.DelayTime(1.0);
				chrome.ExecuteScript("document.querySelector('#iSignupAction').click()");
				this.Delay(3.0);
				int num;
				for (;;)
				{
					num = chrome.CheckExistElements(90.0, new string[]
					{
						"#hipTemplateContainer>div:nth-child(3)>input",
						"#wlspispHipChallengeContainer>div:nth-child(2)>input",
						"#HipEnforcementForm"
					});
					bool flag12 = num == 1;
					if (flag12)
					{
						break;
					}
					bool flag13 = num != 2;
					if (flag13)
					{
						goto Block_16;
					}
					bool flag14 = !this.VerifyPhone(chrome, rowIndex, this.sAPISim);
					if (flag14)
					{
						goto Block_17;
					}
					for (;;)
					{
						num = chrome.CheckExistElements(90.0, new string[]
						{
							"#KmsiCheckboxField",
							"#hipTemplateContainer>div:nth-child(3)>input",
							"#uhfSkipToMain",
							"#o365header",
							"#HipEnforcementForm",
							"#idPageTitle"
						});
						bool flag15 = num == 1;
						if (flag15)
						{
							try
							{
								try
								{
									chrome.Click(1, "KmsiCheckboxField");
								}
								catch
								{
									chrome.ExecuteScript("document.querySelector('#KmsiCheckboxField').click()");
								}
								chrome.DelayTime(1.0);
								try
								{
									chrome.Click(1, "idSIButton9");
								}
								catch
								{
									chrome.ExecuteScript("document.querySelector('#idSIButton9').click()");
								}
							}
							catch
							{
								goto IL_850;
							}
						}
						else
						{
							bool flag16 = num == 3 || num == 4;
							if (flag16)
							{
								goto Block_20;
							}
							bool flag17 = num != 5;
							if (flag17)
							{
								goto Block_21;
							}
							for (;;)
							{
								this.LoadStatusGrid("Đang giải funcaptcha...", "status", rowIndex, 1, this.dgvAcc);
								string captchaResponse = Common.GetCaptchaResponse(this.txtAPIAnyCat.Text.Trim(), "https://signup.live.com", "B7D8911C-5CC8-A9A3-35B0-554ACEE604DA");
								chrome.chrome.SwitchTo().Frame(0);
								chrome.ExecuteScript("parent.postMessage(JSON.stringify({eventId: \"challenge-complete\",payload: {sessionToken: \"" + captchaResponse + "\"}}), \"*\")");
								chrome.DelayTime(1.0);
								switch (chrome.CheckExistElements(30.0, new string[]
								{
									"#KmsiCheckboxField",
									"#o365header",
									"#wlspispHipChallengeContainer>div:nth-child(2)>input",
									"#HipEnforcementForm"
								}))
								{
								case 1:
									goto IL_65F;
								case 2:
									goto IL_661;
								case 3:
									goto IL_666;
								case 4:
									continue;
								}
								goto Block_22;
							}
							IL_65F:
							chrome.Click(1, "KmsiCheckboxField");
							chrome.DelayTime(1.0);
							chrome.Click(1, "idSIButton9");
							chrome.DelayTime(1.0);
							continue;
							IL_666:
							bool flag18 = !this.VerifyPhone(chrome, rowIndex, this.sAPISim);
							if (flag18)
							{
								goto Block_23;
							}
						}
					}
					Block_22:;
				}
				goto IL_850;
				Block_16:
				bool flag19 = num == 3;
				if (flag19)
				{
					int num2;
					do
					{
						this.LoadStatusGrid("Đang giải funcaptcha...", "status", rowIndex, 1, this.dgvAcc);
						string captchaResponse2 = Common.GetCaptchaResponse(this.txtAPIAnyCat.Text.Trim(), "https://signup.live.com", "B7D8911C-5CC8-A9A3-35B0-554ACEE604DA");
						chrome.chrome.SwitchTo().Frame(0);
						chrome.ExecuteScript("parent.postMessage(JSON.stringify({eventId: \"challenge-complete\",payload: {sessionToken: \"" + captchaResponse2 + "\"}}), \"*\")");
						chrome.DelayTime(1.0);
						num2 = chrome.CheckExistElements(30.0, new string[]
						{
							"#KmsiCheckboxField",
							"#o365header",
							"#wlspispHipChallengeContainer>div:nth-child(2)>input",
							"#HipEnforcementForm"
						});
					}
					while (num2 == 4);
					bool flag20 = num2 == 1;
					if (flag20)
					{
						chrome.Click(1, "KmsiCheckboxField");
						chrome.DelayTime(1.0);
						chrome.Click(1, "idSIButton9");
						chrome.DelayTime(1.0);
					}
					else
					{
						bool flag21 = num2 == 3 && !this.VerifyPhone(chrome, rowIndex, this.sAPISim);
						if (flag21)
						{
							goto IL_928;
						}
					}
					goto IL_850;
				}
				goto IL_850;
				Block_17:
				goto IL_6D9;
				Block_20:
				goto IL_850;
				Block_21:
				bool flag22 = num == 6;
				if (flag22)
				{
					this.LoadStatusGrid("Không load được trang!", "status", rowIndex, 1, this.dgvAcc);
					goto IL_928;
				}
				IL_661:
				goto IL_850;
				Block_23:
				IL_6D9:
				goto IL_928;
				IL_850:
				bool flag23 = this.isTaoMailBox;
				if (flag23)
				{
					chrome.DelayTime(1.0);
					this.LoadStatusGrid("Đang tạo mailbox...", "status", rowIndex, 1, this.dgvAcc);
					chrome.DelayTime(1.0);
					chrome.GotoURL("https://outlook.live.com/mail/0");
					chrome.DelayTime(5.0);
					int num3 = chrome.CheckExistElements(90.0, new string[]
					{
						"#owaBranding_container",
						".ms-Modal-scrollableContent"
					});
					bool flag24 = num3 == 1 || num3 == 2;
					if (flag24)
					{
						this.LoadStatusGrid("Tạo mailbox thành công!", "status", rowIndex, 1, this.dgvAcc);
					}
				}
				this.LoadStatusGrid("Đăng ký Mail thành công!", "status", rowIndex, 1, this.dgvAcc);
				result = true;
			}
			IL_928:
			chrome.Close();
			return result;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00027124 File Offset: 0x00025324
		private bool VerifyPhone(Chrome chrome, int indexRow, string api_sim)
		{
			bool result = false;
			string text = "";
			int num = 5;
			try
			{
				this.LoadStatusGrid("Đang xác minh sđt...", "status", indexRow, 1, this.dgvAcc);
				chrome.ExecuteScript("document.querySelector(\"#wlspispHipChallengeContainer > div:nth-child(1) > select\").value=\"VN\"");
				this.LoadStatusGrid("Đang lấy sđt...", "status", indexRow, 0, this.dgvAcc);
				bool flag = api_sim == "";
				if (!flag)
				{
					string text3;
					for (;;)
					{
						string text2 = string.Empty;
						bool flag2 = this.sTypeConfirmFB.Substring(2, 1) == "0";
						if (flag2)
						{
							text2 = Common.GetPhoneSimCode(this.sAPISim, "hotmail", 60);
						}
						else
						{
							bool flag3 = this.sTypeConfirmFB.Substring(2, 1) == "1";
							if (flag3)
							{
								text2 = Common.GetPhoneViotp(this.sAPISim, 60);
							}
							else
							{
								bool flag4 = this.sTypeConfirmFB.Substring(2, 1) == "2";
								if (flag4)
								{
									text2 = Common.GetPhoneTextNow(this.sAPISim, 60);
								}
							}
						}
						text3 = text2.Split(new char[]
						{
							'|'
						})[0];
						string text4 = text2.Split(new char[]
						{
							'|'
						})[1];
						bool flag5 = text4 == "";
						if (flag5)
						{
							this.LoadStatusGrid("Không lấy được sđt! Đang lấy lại...", "status", indexRow, 0, this.dgvAcc);
						}
						else
						{
							bool flag6 = this.sTypeConfirmFB.Substring(2, 1) == "0" || this.sTypeConfirmFB.Substring(2, 1) == "1";
							if (flag6)
							{
								text4 = "+84" + text4;
							}
							else
							{
								bool flag7 = this.sTypeConfirmFB.Substring(2, 1) == "2";
								if (flag7)
								{
									text4 = "+1" + text4;
								}
							}
							bool flag8 = chrome.CheckExistElement("#wlspispHipChallengeContainer>div:nth-child(2)>input", 10.0);
							if (flag8)
							{
								chrome.ClearText(4, "#wlspispHipChallengeContainer>div:nth-child(2)>input");
								chrome.SendKeys(4, "#wlspispHipChallengeContainer>div:nth-child(2)>input", text4, true);
							}
							chrome.DelayTime(3.0);
							chrome.ExecuteScript("document.querySelector('#wlspispHipControlButtonsContainer>a').click()");
							chrome.DelayTime(3.0);
							bool flag9 = !Convert.ToBoolean(chrome.ExecuteScript("return document.querySelector('#iSignupAction').disabled+''").ToString());
							if (flag9)
							{
								break;
							}
							bool flag10 = num < 0;
							if (flag10)
							{
								goto Block_13;
							}
							this.LoadStatusGrid("Sđt không dùng được! Đang lấy số khác...", "status", indexRow, 0, this.dgvAcc);
							num--;
						}
					}
					this.LoadStatusGrid("Đợi lấy mã code...", "status", indexRow, 0, this.dgvAcc);
					bool flag11 = this.sTypeConfirmFB.Substring(2, 1) == "0";
					if (flag11)
					{
						text = Common.GetOTPSimCode(this.sAPISim, text3, 120);
					}
					else
					{
						bool flag12 = this.sTypeConfirmFB.Substring(2, 1) == "1";
						if (flag12)
						{
							text = Common.GetCodeViotp(this.sAPISim, text3, 120, 7);
						}
						else
						{
							bool flag13 = this.sTypeConfirmFB.Substring(2, 1) == "2";
							if (flag13)
							{
								text = Common.GetCodeTextNow(this.sAPISim, text3, 120, 1);
							}
						}
					}
					bool flag14 = text == "";
					if (flag14)
					{
						this.LoadStatusGrid("Không lấy được mã code!", "status", indexRow, 0, this.dgvAcc);
					}
					else
					{
						bool flag15 = chrome.CheckExistElement("#wlspispHipSolutionContainer>div>input", 10.0);
						if (flag15)
						{
							chrome.SendKeys(4, "#wlspispHipSolutionContainer>div>input", text, true);
						}
						chrome.DelayTime(3.0);
						chrome.ExecuteScript("document.querySelector('#iSignupAction').click()");
						chrome.DelayTime(3.0);
						result = true;
					}
					goto IL_3DE;
					Block_13:
					return result;
				}
				this.LoadStatusGrid("Không có api, không thể lấy sđt!", "status", indexRow, 0, this.dgvAcc);
				IL_3DE:;
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0002753C File Offset: 0x0002573C
		private void ckRdPassmail_CheckedChanged(object sender, EventArgs e)
		{
			this.txtPassmail.Enabled = !this.ckRdPassmail.Checked;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x00027559 File Offset: 0x00025759
		private void btnClearLD_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0002755C File Offset: 0x0002575C
		private void mailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.CopyRowDatagrid("mail|passmail");
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0002756B File Offset: 0x0002576B
		private void timer1_Tick(object sender, EventArgs e)
		{
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0002756E File Offset: 0x0002576E
		private void button2_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00027571 File Offset: 0x00025771
		private void chkAddFUID_CheckedChanged(object sender, EventArgs e)
		{
			this.plAddfriend.Enabled = this.chkAddFUID.Checked;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0002758B File Offset: 0x0002578B
		private void chkWStory_CheckedChanged(object sender, EventArgs e)
		{
			this.gbCamxuc.Enabled = this.chkWStory.Checked;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000275A5 File Offset: 0x000257A5
		private void ckRdPassmail_CheckStateChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000261 RID: 609 RVA: 0x000275A8 File Offset: 0x000257A8
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000262 RID: 610 RVA: 0x000275B2 File Offset: 0x000257B2
		private void btnMinimized_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x000275BD File Offset: 0x000257BD
		private void groupBox6_Enter(object sender, EventArgs e)
		{
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000275C0 File Offset: 0x000257C0
		private void rdNoChangeIP_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000265 RID: 613 RVA: 0x000275C3 File Offset: 0x000257C3
		private void timer2_Tick(object sender, EventArgs e)
		{
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000275C6 File Offset: 0x000257C6
		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000275CC File Offset: 0x000257CC
		private void btnCheckAPIMinProxy_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = this.txtApiKeyMinProxy.Lines.ToList<string>();
				list2 = Common.RemoveEmptyItems(list2);
				foreach (string text in list2)
				{
					bool flag = MinProxy.CheckApiProxy(text);
					if (flag)
					{
						list.Add(text);
					}
				}
				this.txtApiKeyMinProxy.Lines = list.ToArray();
				bool flag2 = list.Count > 0;
				if (flag2)
				{
					MessageBox.Show(string.Format("Đang có {0} proxy khả dụng!", list.Count), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Không có proxy khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Không có proxy khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		// Token: 0x06000268 RID: 616 RVA: 0x000276D4 File Offset: 0x000258D4
		private void rdMinProxy_CheckedChanged(object sender, EventArgs e)
		{
			this.pnlAPIMinProxy.Enabled = this.rdMinProxy.Checked;
			this.CheckDoiIPEnable();
		}

		// Token: 0x06000269 RID: 617 RVA: 0x000276F5 File Offset: 0x000258F5
		private void rdHMA_CheckedChanged(object sender, EventArgs e)
		{
			this.CheckDoiIPEnable();
		}

		// Token: 0x0600026A RID: 618 RVA: 0x000276FF File Offset: 0x000258FF
		private void CheckDoiIPEnable()
		{
			this.plCheckDoiIP.Enabled = (this.rdChangeIPDcom.Checked || this.rdHMA.Checked);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x00027729 File Offset: 0x00025929
		private void rdChangeIPDcom_CheckedChanged_1(object sender, EventArgs e)
		{
			this.plChangeIPDcom.Enabled = this.rdChangeIPDcom.Checked;
			this.CheckDoiIPEnable();
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0002774A File Offset: 0x0002594A
		private void rdProxy_CheckedChanged_1(object sender, EventArgs e)
		{
			this.plTinsoftProxy.Enabled = this.rdTinsoftProxy.Checked;
			this.CheckDoiIPEnable();
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0002776C File Offset: 0x0002596C
		private void button2_Click_2(object sender, EventArgs e)
		{
			this.OpenFormViewLD(false);
			for (int i = 0; i < 2; i++)
			{
				frmViewLD.remote.AddPanelDevice(i + 1);
			}
		}

		// Token: 0x0600026E RID: 622 RVA: 0x000277A4 File Offset: 0x000259A4
		private void btnTestChangeIP_Click(object sender, EventArgs e)
		{
			IniFile iniFile = new IniFile("setting.ini");
			int num = Convert.ToInt32(iniFile.Read("typeChangeIp", null));
			bool flag = num == 1 || num == 4;
			if (flag)
			{
				bool flag2 = Common.ChangeIP(num, 0, iniFile.Read("txtProfileNameDcom", null).ToString(), "");
				bool flag3 = flag2;
				if (flag3)
				{
					this.stIPCur.Text = this.GetIp();
					MessageBox.Show("Đổi IP thành công. IP mới: " + this.stIPCur.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Đổi IP thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		// Token: 0x0600026F RID: 623 RVA: 0x00027851 File Offset: 0x00025A51
		private void rdHotMailRegisted_CheckedChanged(object sender, EventArgs e)
		{
			this.btnNhapHotmail.Enabled = this.rdHotMailRegisted.Checked;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0002786B File Offset: 0x00025A6B
		private void btnNhapHotmail_Click(object sender, EventArgs e)
		{
			Process.Start("hotmail.txt");
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00027879 File Offset: 0x00025A79
		private void allToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.CopyRowDatagrid("proxy");
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00027888 File Offset: 0x00025A88
		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://tinsoftproxy.com/");
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00027896 File Offset: 0x00025A96
		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://minproxy.vn/");
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000278A4 File Offset: 0x00025AA4
		private void btnClearLD_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000275 RID: 629 RVA: 0x000278A8 File Offset: 0x00025AA8
		private void btnAutoConfig_Click(object sender, EventArgs e)
		{
			frmAutoFunction frmAutoFunction = new frmAutoFunction();
			frmAutoFunction.Show();
		}

		// Token: 0x06000276 RID: 630 RVA: 0x000278C3 File Offset: 0x00025AC3
		private void button2_Click_3(object sender, EventArgs e)
		{
		}

		// Token: 0x06000277 RID: 631 RVA: 0x000278C6 File Offset: 0x00025AC6
		private void btnMaximum_Click(object sender, EventArgs e)
		{
			this.maxMinWindows();
		}

		// Token: 0x06000278 RID: 632 RVA: 0x000278D0 File Offset: 0x00025AD0
		private void maxMinWindows()
		{
			base.MaximizedBounds = Screen.FromHandle(base.Handle).WorkingArea;
			bool flag = base.WindowState == FormWindowState.Minimized;
			if (flag)
			{
				base.WindowState = FormWindowState.Maximized;
			}
			else
			{
				bool flag2 = base.WindowState == FormWindowState.Normal;
				if (flag2)
				{
					base.WindowState = FormWindowState.Maximized;
				}
				else
				{
					bool flag3 = base.WindowState == FormWindowState.Maximized;
					if (flag3)
					{
						base.WindowState = FormWindowState.Normal;
					}
				}
			}
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00027938 File Offset: 0x00025B38
		private void btnLinkCover_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x04000175 RID: 373
		public static frmMain remote;

		// Token: 0x04000176 RID: 374
		private Random rd = new Random();

		// Token: 0x04000177 RID: 375
		private List<int> listPositionApp = new List<int>();

		// Token: 0x04000178 RID: 376
		private List<string> lstHotmailDaReg = new List<string>();

		// Token: 0x04000179 RID: 377
		private bool isStop;

		// Token: 0x0400017A RID: 378
		private string[] firstname_female_us = File.ReadAllLines("data/US/firstname_female.txt");

		// Token: 0x0400017B RID: 379
		private string[] firstname_male_us = File.ReadAllLines("data/US/firstname_male.txt");

		// Token: 0x0400017C RID: 380
		private string[] lastname_us = File.ReadAllLines("data/US/lastname.txt");

		// Token: 0x0400017D RID: 381
		private string[] firstname_female_vn = File.ReadAllLines("data/VN/firstname_female.txt");

		// Token: 0x0400017E RID: 382
		private string[] firstname_male_vn = File.ReadAllLines("data/VN/firstname_male.txt");

		// Token: 0x0400017F RID: 383
		private string[] lastname_vn = File.ReadAllLines("data/VN/lastname.txt");

		// Token: 0x04000180 RID: 384
		private int iModeRun = 0;

		// Token: 0x04000181 RID: 385
		private int iSoluotchay = 0;

		// Token: 0x04000182 RID: 386
		private int iTypeOpenLD = 0;

		// Token: 0x04000183 RID: 387
		private int iDelayFr = 0;

		// Token: 0x04000184 RID: 388
		private int iDelayTo = 0;

		// Token: 0x04000185 RID: 389
		private int iDelayClsFr = 0;

		// Token: 0x04000186 RID: 390
		private int iDelayClsTo = 0;

		// Token: 0x04000187 RID: 391
		private int iThoiGianChoNhapOtp = 0;

		// Token: 0x04000188 RID: 392
		private string pathLD = "";

		// Token: 0x04000189 RID: 393
		private int iSoLuotDoiIpMotLan = 0;

		// Token: 0x0400018A RID: 394
		private int iTypeChangeIp = 0;

		// Token: 0x0400018B RID: 395
		private string sProfileNameDcom = "";

		// Token: 0x0400018C RID: 396
		private string sAPISim = "";

		// Token: 0x0400018D RID: 397
		private string sTypeConfirmFB = "";

		// Token: 0x0400018E RID: 398
		private int iTypeConfirm = 0;

		// Token: 0x0400018F RID: 399
		public string deviceId;

		// Token: 0x04000190 RID: 400
		private int iMaxThread = 0;

		// Token: 0x04000191 RID: 401
		private List<Thread> listThread;

		// Token: 0x04000192 RID: 402
		public bool isResetAdb;

		// Token: 0x04000193 RID: 403
		private List<Device> lstDevice;

		// Token: 0x04000194 RID: 404
		private object lock_restoreDevice;

		// Token: 0x04000195 RID: 405
		private int iTypeNameReg = 0;

		// Token: 0x04000196 RID: 406
		private string sPassFb = "";

		// Token: 0x04000197 RID: 407
		private int iGioiTinh = 0;

		// Token: 0x04000198 RID: 408
		private bool isCreate2FA = false;

		// Token: 0x04000199 RID: 409
		private bool isUploadAvt = false;

		// Token: 0x0400019A RID: 410
		private bool isDoiAnhBia = false;

		// Token: 0x0400019B RID: 411
		private bool isPassRandom = false;

		// Token: 0x0400019C RID: 412
		private bool isOnOff2FA = false;

		// Token: 0x0400019D RID: 413
		private bool isDoiNgonNgu = false;

		// Token: 0x0400019E RID: 414
		private int ageFrom = 0;

		// Token: 0x0400019F RID: 415
		private int ageTo = 0;

		// Token: 0x040001A0 RID: 416
		private bool isReloginIfLogout = false;

		// Token: 0x040001A1 RID: 417
		private int checkDelayLD;

		// Token: 0x040001A2 RID: 418
		private object lock_checkDelayLD;

		// Token: 0x040001A3 RID: 419
		private int checkDelayLD_MoLDPLayer;

		// Token: 0x040001A4 RID: 420
		private object lock_checkDelayLD_MoLDPLayer;

		// Token: 0x040001A5 RID: 421
		private object lock_checkDelayCreateDevice;

		// Token: 0x040001A6 RID: 422
		private object lock_checkDelayCreateDevice_MoLDPLayer;

		// Token: 0x040001A7 RID: 423
		private bool isOpeningDevice_MoLDPLayer;

		// Token: 0x040001A8 RID: 424
		private List<TinsoftProxy> listTinsoft;

		// Token: 0x040001A9 RID: 425
		private List<string> listApiTinsoft;

		// Token: 0x040001AA RID: 426
		private string sAPIProxyTinsoft = "";

		// Token: 0x040001AB RID: 427
		private int inudLuongPerIPTinsoft = 0;

		// Token: 0x040001AC RID: 428
		private int cbLocationTinsoft = 0;

		// Token: 0x040001AD RID: 429
		private object lock_StartProxy;

		// Token: 0x040001AE RID: 430
		private string sAnycaptcha = "";

		// Token: 0x040001AF RID: 431
		private int PhoneCountry = 0;

		// Token: 0x040001B0 RID: 432
		private List<string> listextension = null;

		// Token: 0x040001B1 RID: 433
		private int getWidthChrome;

		// Token: 0x040001B2 RID: 434
		private int getHeightChrome;

		// Token: 0x040001B3 RID: 435
		private object k;

		// Token: 0x040001B4 RID: 436
		private bool isTaoMailBox = false;

		// Token: 0x040001B5 RID: 437
		private string sPassmail = "";

		// Token: 0x040001B6 RID: 438
		private static List<float> AvailableCPU = new List<float>();

		// Token: 0x040001B7 RID: 439
		private static List<float> AvailableRAM = new List<float>();

		// Token: 0x040001B8 RID: 440
		protected static PerformanceCounter cpuCounter;

		// Token: 0x040001B9 RID: 441
		protected static PerformanceCounter ramCounter;

		// Token: 0x040001BA RID: 442
		private object lock_fileig;

		// Token: 0x040001BB RID: 443
		private object ofile1 = new object();

		// Token: 0x040001BC RID: 444
		private object ofile2 = new object();

		// Token: 0x040001BD RID: 445
		private object ofile3 = new object();

		// Token: 0x040001BE RID: 446
		private object ofile4 = new object();

		// Token: 0x040001BF RID: 447
		private object oStop = new object();

		// Token: 0x040001C0 RID: 448
		private List<string> typeReaction = new List<string>();

		// Token: 0x040001C1 RID: 449
		private frmLoading _loading;

		// Token: 0x040001C2 RID: 450
		private List<string> listProxyMinProxy = new List<string>();

		// Token: 0x040001C3 RID: 451
		private List<MinProxy> listMinProxy = null;

		// Token: 0x040001C4 RID: 452
		private int inudLuongPerIPMinProxy = 0;

		// Token: 0x040001C5 RID: 453
		private object lock_StartProxy1 = new object();

		// Token: 0x040001C6 RID: 454
		private object lock_FinishProxy = new object();

		// Token: 0x040001C7 RID: 455
		private string linkAvartar;

		// Token: 0x040001C8 RID: 456
		private string linkCover;
	}
}
