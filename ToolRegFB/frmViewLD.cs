using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using ToolRegFB.Properties;

namespace ToolRegFB
{
	// Token: 0x02000039 RID: 57
	public partial class frmViewLD : Form
	{
		// Token: 0x060002B3 RID: 691 RVA: 0x0003446C File Offset: 0x0003266C
		public frmViewLD()
		{
			this.InitializeComponent();
			frmViewLD.remote = this;
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x000344C0 File Offset: 0x000326C0
		public void AddPanelDevice(int deviceIndex)
		{
			try
			{
				bool flag = !this.isRunSwap;
				if (flag)
				{
					deviceIndex = -1;
				}
				Panel panel = new Panel();
				panel.Name = "dv" + deviceIndex.ToString();
				panel.Tag = deviceIndex;
				panel.Size = new Size(this.LDSize[0], this.LDSize[1] + 60);
				panel.BackColor = Color.White;
				panel.BorderStyle = BorderStyle.FixedSingle;
				bool flag2 = deviceIndex == -1;
				string text;
				if (flag2)
				{
					text = "LDPlayer-None";
				}
				else
				{
					text = "LDPlayer-" + deviceIndex.ToString();
				}
				Label label = new Label
				{
					Text = text,
					Location = new Point(0, this.LDSize[1]),
					Size = new Size(this.LDSize[0] - 55, 20),
					BackColor = Color.White,
					BorderStyle = BorderStyle.None,
					ForeColor = Color.Black,
					Name = (deviceIndex.ToString() ?? ""),
					AutoSize = false
				};
				panel.Controls.Add(label);
				label.DoubleClick += this.CheckDevice;
				Label value = new Label
				{
					Text = ">",
					Location = new Point(0, this.LDSize[1] + 20),
					Size = new Size(this.LDSize[0], 20),
					BackColor = Color.White,
					BorderStyle = BorderStyle.None,
					ForeColor = Color.Black,
					Name = (deviceIndex.ToString() ?? ""),
					AutoSize = false
				};
				panel.Controls.Add(value);
				Label value2 = new Label
				{
					Text = "",
					Location = new Point(0, this.LDSize[1] + 40),
					Size = new Size(this.LDSize[0], 20),
					BackColor = Color.White,
					BorderStyle = BorderStyle.None,
					ForeColor = Color.Black,
					Name = (deviceIndex.ToString() ?? ""),
					AutoSize = false
				};
				panel.Controls.Add(value2);
				PictureBox pictureBox = new PictureBox
				{
					Image = Resources.icons8_multiply_20,
					Location = new Point(this.LDSize[0] - 25, this.LDSize[1]),
					Name = (deviceIndex.ToString() ?? ""),
					Size = new Size(20, 20),
					Cursor = Cursors.Hand,
					Visible = false
				};
				pictureBox.Click += this.TurnOffDevice;
				panel.Controls.Add(pictureBox);
				this.bunifuToolTip1.SetToolTip(pictureBox, "Close");
				PictureBox pictureBox2 = new PictureBox
				{
					Image = Resources.icons8_undo_20,
					Location = new Point(this.LDSize[0] - 50, this.LDSize[1]),
					Name = (deviceIndex.ToString() ?? ""),
					Size = new Size(20, 20),
					Cursor = Cursors.Hand,
					Visible = false
				};
				pictureBox2.Click += this.Back;
				panel.Controls.Add(pictureBox2);
				this.bunifuToolTip1.SetToolTip(pictureBox2, "Back");
				PictureBox pictureBox3 = new PictureBox
				{
					Image = Resources.Custom_Logo_rabbit_940x1400,
					SizeMode = PictureBoxSizeMode.Zoom,
					Location = new Point(0, -30),
					Name = "pictureBoxLogo",
					Size = new Size(this.LDSize[0], this.LDSize[1] + 60),
					TabIndex = 0,
					TabStop = false
				};
				pictureBox3.BringToFront();
				panel.Controls.Add(pictureBox3);
				object obj = this.lock_listPanel;
				object obj2 = obj;
				lock (obj2)
				{
					this.panelListDevice.Invoke(new MethodInvoker(delegate()
					{
						this.panelListDevice.Controls.Add(panel);
					}));
				}
				int num = 0;
				while (num < 5 && this.panelListDevice.Controls["dv" + deviceIndex.ToString()] == null)
				{
					Thread.Sleep(1000);
					num++;
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x000349F0 File Offset: 0x00032BF0
		private void Back(object sender, EventArgs e)
		{
			try
			{
				string name = (sender as PictureBox).Name;
				ADBHelper.RunCMD(name, "shell input keyevent 4", 10);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00034A34 File Offset: 0x00032C34
		private void TurnOffDevice(object sender, EventArgs e)
		{
			try
			{
				int indexDevice = Convert.ToInt32((sender as PictureBox).Name);
				this.RemovePanelDevice(indexDevice);
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x00034A74 File Offset: 0x00032C74
		public void HidePicTurnOffDevice(int indexDevice)
		{
			try
			{
				base.Invoke(new MethodInvoker(delegate()
				{
					this.panelListDevice.Controls["dv" + indexDevice.ToString()].Controls[3].Visible = false;
					this.panelListDevice.Controls["dv" + indexDevice.ToString()].Controls[4].Visible = false;
				}));
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "HidePicTurnOffDevice");
			}
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x00034AD0 File Offset: 0x00032CD0
		public void RemovePanelDevice(int indexDevice)
		{
			try
			{
				IniFile iniFile = new IniFile("setting.ini");
				string pathLD = iniFile.Read("linkLD", null).ToString();
				ADBHelper.QuitDevice(pathLD, indexDevice);
				this.LoadStatus(indexDevice, "");
				this.LoadHanhDong(indexDevice, "");
				this.HidePicTurnOffDevice(indexDevice);
				Control control = this.panelListDevice.Controls["dv" + indexDevice.ToString()];
				this.UpdateInfoPanelDevice(control, -1, 0, string.Empty);
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "RemovePanelDevice");
			}
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00034B7C File Offset: 0x00032D7C
		public void ExportLog(int indexDevice, string activity = "", string html = "", string folderPath = "")
		{
			try
			{
				string str = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss");
				string text = indexDevice.ToString() + "_" + str;
				bool flag = folderPath == "";
				if (flag)
				{
					folderPath = "CheckDevice";
				}
				Common.CreateFolder(folderPath);
				Common.CreateFolder(folderPath + "\\" + indexDevice.ToString());
				string deviceByIndex = ADBHelper.GetDeviceByIndex(indexDevice);
				bool flag2 = deviceByIndex != "";
				if (flag2)
				{
					ADBHelper.ScreenShot(deviceByIndex, string.Concat(new string[]
					{
						folderPath,
						"\\",
						indexDevice.ToString(),
						"\\",
						text,
						".png"
					}));
					File.AppendAllText(string.Concat(new string[]
					{
						folderPath,
						"\\",
						indexDevice.ToString(),
						"\\",
						text,
						".txt"
					}), this.panelListDevice.Controls["dv" + indexDevice.ToString()].Controls[1].Text + "\r\n");
					bool flag3 = activity == "";
					if (flag3)
					{
						activity = ADBHelper.DumpActivity(deviceByIndex).Split(new char[]
						{
							'{',
							'}'
						})[1].Split(new char[]
						{
							' '
						})[2];
					}
					File.AppendAllText(string.Concat(new string[]
					{
						folderPath,
						"\\",
						indexDevice.ToString(),
						"\\",
						text,
						".txt"
					}), activity + "\r\n");
					bool flag4 = html == "";
					if (flag4)
					{
						html = ADBHelper.GetXML(deviceByIndex);
					}
					File.AppendAllText(string.Concat(new string[]
					{
						folderPath,
						"\\",
						indexDevice.ToString(),
						"\\",
						text,
						".txt"
					}), html);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00034DC8 File Offset: 0x00032FC8
		private void CheckDevice(object sender, EventArgs e)
		{
			try
			{
				int indexDevice = Convert.ToInt32((sender as Label).Name);
				this.ExportLog(indexDevice, "", "", "");
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "CheckDevice");
			}
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00034E24 File Offset: 0x00033024
		public void LoadStatus(int indexDevice, string content)
		{
			try
			{
				Application.DoEvents();
				bool flag = content.Trim() != "";
				if (flag)
				{
					content = content.Replace("\"", "");
					content += (content.EndsWith("...") ? "" : "...");
				}
				this.panelListDevice.Invoke(new MethodInvoker(delegate()
				{
					this.panelListDevice.Controls["dv" + indexDevice.ToString()].Controls[2].Text = content;
				}));
				Application.DoEvents();
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "LoadStatus");
			}
		}

		// Token: 0x060002BC RID: 700 RVA: 0x00034EFC File Offset: 0x000330FC
		public void LoadHanhDong(int indexDevice, string content)
		{
			try
			{
				Application.DoEvents();
				bool flag = content.Trim() != "";
				if (flag)
				{
					content = content.Replace("\"", "");
					content += (content.EndsWith("...") ? "" : "...");
				}
				this.panelListDevice.Invoke(new MethodInvoker(delegate()
				{
					this.panelListDevice.Controls["dv" + indexDevice.ToString()].Controls[1].Text = "> " + content;
				}));
				this.LoadStatus(indexDevice, "");
				Application.DoEvents();
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "LoadHanhDong");
			}
		}

		// Token: 0x060002BD RID: 701 RVA: 0x00034FE8 File Offset: 0x000331E8
		public void AddLDIntoPanel(IntPtr MainWindowHandle, int indexDevice, int sttTaiKhoan, string deviceName)
		{
			try
			{
				Control control = (from Control h in this.panelListDevice.Controls
				where h.Tag.Equals(indexDevice)
				select h).FirstOrDefault<Control>();
				bool flag = control == null;
				if (flag)
				{
					control = (from Control h in this.panelListDevice.Controls
					where h.Tag.Equals(-1)
					select h).FirstOrDefault<Control>();
					this.UpdateInfoPanelDevice(control, indexDevice, sttTaiKhoan, deviceName);
					Application.DoEvents();
				}
				base.Invoke(new MethodInvoker(delegate()
				{
					User32Helper.SetParent(MainWindowHandle, control.Handle);
					User32Helper.MoveWindow(MainWindowHandle, this.LDSize[2], this.LDSize[3], this.LDSize[4], this.LDSize[5], true);
				}));
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "AddLDIntoPanel");
			}
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000350F8 File Offset: 0x000332F8
		public void UpdateInfoPanelDevice(Control control, int deviceIndex, int sttTaiKhoan = 0, string deviceName = "")
		{
			try
			{
				control.Invoke(new MethodInvoker(delegate()
				{
					control.Name = "dv" + deviceIndex.ToString();
					control.Tag = deviceIndex;
					bool flag = deviceIndex == -1;
					if (flag)
					{
						control.Controls[0].Text = "LDPlayer-None";
					}
					else
					{
						control.Controls[0].Text = deviceName;
					}
					bool flag2 = sttTaiKhoan > 0;
					if (flag2)
					{
						Control control2 = control.Controls[0];
						control2.Text = control2.Text + ": Tài khoản " + sttTaiKhoan.ToString();
					}
					control.Controls[0].Name = deviceIndex.ToString();
					control.Controls[1].Name = deviceIndex.ToString();
					control.Controls[2].Name = deviceIndex.ToString();
					control.Controls[3].Name = deviceIndex.ToString();
				}));
			}
			catch
			{
			}
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0003515C File Offset: 0x0003335C
		private void frmViewLD_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				frmMain.remote.stopAll();
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "fViewChrome_FormClosing");
			}
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0003519C File Offset: 0x0003339C
		private void btnMinimize_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x000351A7 File Offset: 0x000333A7
		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x000351B1 File Offset: 0x000333B1
		private void btnMaximum_Click(object sender, EventArgs e)
		{
			this.maxMinWindows();
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x000351BB File Offset: 0x000333BB
		private void panel1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x000351C0 File Offset: 0x000333C0
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

		// Token: 0x060002C5 RID: 709 RVA: 0x00035228 File Offset: 0x00033428
		private void panel1_DoubleClick(object sender, EventArgs e)
		{
			this.maxMinWindows();
		}

		// Token: 0x040002F0 RID: 752
		public bool isRunSwap = false;

		// Token: 0x040002F1 RID: 753
		private object lock_listPanel = new object();

		// Token: 0x040002F2 RID: 754
		public int[] LDSize = new int[]
		{
			240,
			360,
			-1,
			-36,
			240,
			395
		};

		// Token: 0x040002F3 RID: 755
		public static frmViewLD remote;
	}
}
