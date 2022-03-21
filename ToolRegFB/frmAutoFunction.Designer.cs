namespace ToolRegFB
{
	// Token: 0x02000025 RID: 37
	public partial class frmAutoFunction : global::System.Windows.Forms.Form
	{
		// Token: 0x060001A9 RID: 425 RVA: 0x0000E228 File Offset: 0x0000C428
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001AA RID: 426 RVA: 0x0000E260 File Offset: 0x0000C460
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ToolRegFB.frmAutoFunction));
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.label28 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnSaveConf = new global::Bunifu.Framework.UI.BunifuFlatButton();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.chkAutoClearLD = new global::System.Windows.Forms.CheckBox();
			this.nudSizeTo = new global::System.Windows.Forms.NumericUpDown();
			this.nudDPILD = new global::System.Windows.Forms.NumericUpDown();
			this.nudSizeFr = new global::System.Windows.Forms.NumericUpDown();
			this.cbRamLD = new global::System.Windows.Forms.ComboBox();
			this.label4 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.cbCPULD = new global::System.Windows.Forms.ComboBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.cbTurnOnLDPlayer = new global::System.Windows.Forms.CheckBox();
			this.bunifuFormDock1 = new global::Bunifu.UI.WinForms.BunifuFormDock();
			this.ckAdbDebug = new global::System.Windows.Forms.CheckBox();
			this.panel4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudSizeTo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudDPILD).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudSizeFr).BeginInit();
			base.SuspendLayout();
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(46, 51, 73);
			this.panel4.Controls.Add(this.btnClose);
			this.panel4.Controls.Add(this.label28);
			this.panel4.Controls.Add(this.pictureBox1);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(501, 46);
			this.panel4.TabIndex = 8;
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Image = global::ToolRegFB.Properties.Resources.icons8_x_20;
			this.btnClose.Location = new global::System.Drawing.Point(454, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(44, 39);
			this.btnClose.TabIndex = 5;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.label28.AutoSize = true;
			this.label28.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label28.ForeColor = global::System.Drawing.Color.White;
			this.label28.Location = new global::System.Drawing.Point(42, 8);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(270, 32);
			this.label28.TabIndex = 6;
			this.label28.Text = "Cấu hình nâng cao";
			this.pictureBox1.Image = global::ToolRegFB.Properties.Resources.icons8_facebook_970;
			this.pictureBox1.Location = new global::System.Drawing.Point(2, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(40, 40);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			this.panel1.Controls.Add(this.btnSaveConf);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.panel1.Location = new global::System.Drawing.Point(0, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(501, 404);
			this.panel1.TabIndex = 9;
			this.btnSaveConf.Activecolor = global::System.Drawing.Color.FromArgb(46, 139, 87);
			this.btnSaveConf.BackColor = global::System.Drawing.Color.FromArgb(46, 139, 87);
			this.btnSaveConf.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.btnSaveConf.BorderRadius = 0;
			this.btnSaveConf.ButtonText = "Lưu cấu hình";
			this.btnSaveConf.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnSaveConf.DisabledColor = global::System.Drawing.Color.Gray;
			this.btnSaveConf.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btnSaveConf.Iconcolor = global::System.Drawing.Color.Transparent;
			this.btnSaveConf.Iconimage = (global::System.Drawing.Image)componentResourceManager.GetObject("btnSaveConf.Iconimage");
			this.btnSaveConf.Iconimage_right = null;
			this.btnSaveConf.Iconimage_right_Selected = null;
			this.btnSaveConf.Iconimage_Selected = null;
			this.btnSaveConf.IconMarginLeft = 0;
			this.btnSaveConf.IconMarginRight = 0;
			this.btnSaveConf.IconRightVisible = true;
			this.btnSaveConf.IconRightZoom = 0.0;
			this.btnSaveConf.IconVisible = false;
			this.btnSaveConf.IconZoom = 90.0;
			this.btnSaveConf.IsTab = false;
			this.btnSaveConf.Location = new global::System.Drawing.Point(0, 345);
			this.btnSaveConf.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSaveConf.Name = "btnSaveConf";
			this.btnSaveConf.Normalcolor = global::System.Drawing.Color.FromArgb(46, 139, 87);
			this.btnSaveConf.OnHovercolor = global::System.Drawing.Color.FromArgb(36, 129, 77);
			this.btnSaveConf.OnHoverTextColor = global::System.Drawing.Color.White;
			this.btnSaveConf.selected = false;
			this.btnSaveConf.Size = new global::System.Drawing.Size(501, 59);
			this.btnSaveConf.TabIndex = 2;
			this.btnSaveConf.Text = "Lưu cấu hình";
			this.btnSaveConf.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.btnSaveConf.Textcolor = global::System.Drawing.Color.White;
			this.btnSaveConf.TextFont = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnSaveConf.Click += new global::System.EventHandler(this.btnSaveConf_Click);
			this.groupBox1.Controls.Add(this.panel2);
			this.groupBox1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox1.Location = new global::System.Drawing.Point(12, 17);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(477, 308);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cấu hình LDPlayer";
			this.panel2.Controls.Add(this.pictureBox2);
			this.panel2.Controls.Add(this.ckAdbDebug);
			this.panel2.Controls.Add(this.chkAutoClearLD);
			this.panel2.Controls.Add(this.nudSizeTo);
			this.panel2.Controls.Add(this.nudDPILD);
			this.panel2.Controls.Add(this.nudSizeFr);
			this.panel2.Controls.Add(this.cbRamLD);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.cbCPULD);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.cbTurnOnLDPlayer);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new global::System.Drawing.Point(3, 26);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(471, 279);
			this.panel2.TabIndex = 0;
			this.pictureBox2.Image = global::ToolRegFB.Properties.Resources.icons8_x_30;
			this.pictureBox2.Location = new global::System.Drawing.Point(156, 94);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(35, 30);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			this.chkAutoClearLD.AutoSize = true;
			this.chkAutoClearLD.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.chkAutoClearLD.Location = new global::System.Drawing.Point(32, 202);
			this.chkAutoClearLD.Name = "chkAutoClearLD";
			this.chkAutoClearLD.Size = new global::System.Drawing.Size(233, 24);
			this.chkAutoClearLD.TabIndex = 0;
			this.chkAutoClearLD.Text = "Tự động clear cache LDPlayer";
			this.chkAutoClearLD.UseVisualStyleBackColor = true;
			this.chkAutoClearLD.CheckedChanged += new global::System.EventHandler(this.chkAutoClearLD_CheckedChanged);
			this.nudSizeTo.Location = new global::System.Drawing.Point(197, 94);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.nudSizeTo;
			int[] array = new int[4];
			array[0] = 1920;
			numericUpDown.Maximum = new decimal(array);
			this.nudSizeTo.Name = "nudSizeTo";
			this.nudSizeTo.Size = new global::System.Drawing.Size(67, 30);
			this.nudSizeTo.TabIndex = 3;
			this.nudSizeTo.ValueChanged += new global::System.EventHandler(this.numericUpDown1_ValueChanged);
			this.nudDPILD.Location = new global::System.Drawing.Point(83, 131);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.nudDPILD;
			int[] array2 = new int[4];
			array2[0] = 1000;
			numericUpDown2.Maximum = new decimal(array2);
			this.nudDPILD.Name = "nudDPILD";
			this.nudDPILD.Size = new global::System.Drawing.Size(67, 30);
			this.nudDPILD.TabIndex = 3;
			this.nudDPILD.ValueChanged += new global::System.EventHandler(this.numericUpDown1_ValueChanged);
			this.nudSizeFr.Location = new global::System.Drawing.Point(83, 94);
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.nudSizeFr;
			int[] array3 = new int[4];
			array3[0] = 1920;
			numericUpDown3.Maximum = new decimal(array3);
			this.nudSizeFr.Name = "nudSizeFr";
			this.nudSizeFr.Size = new global::System.Drawing.Size(67, 30);
			this.nudSizeFr.TabIndex = 3;
			this.nudSizeFr.ValueChanged += new global::System.EventHandler(this.numericUpDown1_ValueChanged);
			this.cbRamLD.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRamLD.FormattingEnabled = true;
			this.cbRamLD.Items.AddRange(new object[]
			{
				"256M",
				"512M",
				"768M",
				"1024M (Khuyến nghị)",
				"1536M",
				"2048M",
				"3072M",
				"4096M",
				"8192M"
			});
			this.cbRamLD.Location = new global::System.Drawing.Point(83, 52);
			this.cbRamLD.Name = "cbRamLD";
			this.cbRamLD.Size = new global::System.Drawing.Size(233, 31);
			this.cbRamLD.TabIndex = 2;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(28, 135);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(37, 20);
			this.label4.TabIndex = 1;
			this.label4.Text = "DPI:";
			this.label4.Click += new global::System.EventHandler(this.label3_Click);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(28, 101);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(42, 20);
			this.label3.TabIndex = 1;
			this.label3.Text = "SIZE:";
			this.label3.Click += new global::System.EventHandler(this.label3_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(28, 57);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(46, 20);
			this.label2.TabIndex = 1;
			this.label2.Text = "RAM:";
			this.cbCPULD.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCPULD.FormattingEnabled = true;
			this.cbCPULD.Items.AddRange(new object[]
			{
				"1 cores (Khuyến nghị)",
				"2 cores",
				"3 cores",
				"4 cores",
				"6 cores"
			});
			this.cbCPULD.Location = new global::System.Drawing.Point(83, 10);
			this.cbCPULD.Name = "cbCPULD";
			this.cbCPULD.Size = new global::System.Drawing.Size(233, 31);
			this.cbCPULD.TabIndex = 2;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(28, 15);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(42, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "CPU:";
			this.cbTurnOnLDPlayer.AutoSize = true;
			this.cbTurnOnLDPlayer.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbTurnOnLDPlayer.Location = new global::System.Drawing.Point(32, 172);
			this.cbTurnOnLDPlayer.Name = "cbTurnOnLDPlayer";
			this.cbTurnOnLDPlayer.Size = new global::System.Drawing.Size(149, 24);
			this.cbTurnOnLDPlayer.TabIndex = 0;
			this.cbTurnOnLDPlayer.Text = "Bật GPS LDPlayer";
			this.cbTurnOnLDPlayer.UseVisualStyleBackColor = true;
			this.cbTurnOnLDPlayer.CheckedChanged += new global::System.EventHandler(this.cbTurnOnLDPlayer_CheckedChanged);
			this.bunifuFormDock1.AllowFormDragging = true;
			this.bunifuFormDock1.AllowFormDropShadow = true;
			this.bunifuFormDock1.AllowFormResizing = false;
			this.bunifuFormDock1.AllowHidingBottomRegion = true;
			this.bunifuFormDock1.AllowOpacityChangesWhileDragging = false;
			this.bunifuFormDock1.BorderOptions.BottomBorder.BorderColor = global::System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.BottomBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.BottomBorder.ShowBorder = true;
			this.bunifuFormDock1.BorderOptions.LeftBorder.BorderColor = global::System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.LeftBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.LeftBorder.ShowBorder = true;
			this.bunifuFormDock1.BorderOptions.RightBorder.BorderColor = global::System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.RightBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.RightBorder.ShowBorder = true;
			this.bunifuFormDock1.BorderOptions.TopBorder.BorderColor = global::System.Drawing.Color.Silver;
			this.bunifuFormDock1.BorderOptions.TopBorder.BorderThickness = 1;
			this.bunifuFormDock1.BorderOptions.TopBorder.ShowBorder = true;
			this.bunifuFormDock1.ContainerControl = this;
			this.bunifuFormDock1.DockingIndicatorsColor = global::System.Drawing.Color.FromArgb(202, 215, 233);
			this.bunifuFormDock1.DockingIndicatorsOpacity = 0.5;
			this.bunifuFormDock1.DockingOptions.DockAll = true;
			this.bunifuFormDock1.DockingOptions.DockBottomLeft = true;
			this.bunifuFormDock1.DockingOptions.DockBottomRight = true;
			this.bunifuFormDock1.DockingOptions.DockFullScreen = true;
			this.bunifuFormDock1.DockingOptions.DockLeft = true;
			this.bunifuFormDock1.DockingOptions.DockRight = true;
			this.bunifuFormDock1.DockingOptions.DockTopLeft = true;
			this.bunifuFormDock1.DockingOptions.DockTopRight = true;
			this.bunifuFormDock1.FormDraggingOpacity = 0.9;
			this.bunifuFormDock1.ParentForm = this;
			this.bunifuFormDock1.ShowCursorChanges = true;
			this.bunifuFormDock1.ShowDockingIndicators = true;
			this.bunifuFormDock1.TitleBarOptions.AllowFormDragging = true;
			this.bunifuFormDock1.TitleBarOptions.BunifuFormDock = this.bunifuFormDock1;
			this.bunifuFormDock1.TitleBarOptions.DoubleClickToExpandWindow = true;
			this.bunifuFormDock1.TitleBarOptions.TitleBarControl = null;
			this.bunifuFormDock1.TitleBarOptions.UseBackColorOnDockingIndicators = false;
			this.ckAdbDebug.AutoSize = true;
			this.ckAdbDebug.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ckAdbDebug.Location = new global::System.Drawing.Point(33, 232);
			this.ckAdbDebug.Name = "ckAdbDebug";
			this.ckAdbDebug.Size = new global::System.Drawing.Size(414, 24);
			this.ckAdbDebug.TabIndex = 0;
			this.ckAdbDebug.Text = "ADB Debug (Dành cho các phiên bản LDPlayer cao hơn)";
			this.ckAdbDebug.UseVisualStyleBackColor = true;
			this.ckAdbDebug.CheckedChanged += new global::System.EventHandler(this.chkAutoClearLD_CheckedChanged);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(501, 450);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmAutoFunction";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cấu hình nâng cao";
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudSizeTo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudDPILD).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudSizeFr).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040000E5 RID: 229
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.Label label28;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.CheckBox chkAutoClearLD;

		// Token: 0x040000EC RID: 236
		private global::Bunifu.UI.WinForms.BunifuFormDock bunifuFormDock1;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.CheckBox cbTurnOnLDPlayer;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.NumericUpDown nudSizeFr;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.ComboBox cbRamLD;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.Label label3;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.Label label2;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.ComboBox cbCPULD;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.NumericUpDown nudSizeTo;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.NumericUpDown nudDPILD;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.Label label4;

		// Token: 0x040000FA RID: 250
		private global::Bunifu.Framework.UI.BunifuFlatButton btnSaveConf;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.CheckBox ckAdbDebug;
	}
}
