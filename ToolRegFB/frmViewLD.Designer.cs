namespace ToolRegFB
{
	// Token: 0x02000039 RID: 57
	public partial class frmViewLD : global::System.Windows.Forms.Form
	{
		// Token: 0x060002C6 RID: 710 RVA: 0x00035234 File Offset: 0x00033434
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0003526C File Offset: 0x0003346C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ToolRegFB.frmViewLD));
			this.panelListDevice = new global::System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.btnMaximum = new global::System.Windows.Forms.Button();
			this.btnMinimize = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.bunifuDragControl1 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuFormDock1 = new global::Bunifu.UI.WinForms.BunifuFormDock();
			this.bunifuToolTip1 = new global::Bunifu.UI.WinForms.BunifuToolTip(this.components);
			this.bunifuVScrollBar1 = new global::Bunifu.UI.WinForms.BunifuVScrollBar();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.panelListDevice.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.panelListDevice.Location = new global::System.Drawing.Point(0, 47);
			this.panelListDevice.Name = "panelListDevice";
			this.panelListDevice.Size = new global::System.Drawing.Size(1360, 854);
			this.panelListDevice.TabIndex = 0;
			this.bunifuToolTip1.SetToolTip(this.panelListDevice, "");
			this.bunifuToolTip1.SetToolTipIcon(this.panelListDevice, null);
			this.bunifuToolTip1.SetToolTipTitle(this.panelListDevice, "");
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(46, 51, 73);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Controls.Add(this.btnMaximum);
			this.panel1.Controls.Add(this.btnMinimize);
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1382, 46);
			this.panel1.TabIndex = 1;
			this.bunifuToolTip1.SetToolTip(this.panel1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.panel1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.panel1, "");
			this.panel1.Click += new global::System.EventHandler(this.panel1_Click);
			this.panel1.DoubleClick += new global::System.EventHandler(this.panel1_DoubleClick);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Nirmala UI", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(50, 2);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(205, 38);
			this.label1.TabIndex = 2;
			this.label1.Text = "LDPlayer View";
			this.bunifuToolTip1.SetToolTip(this.label1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.label1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.label1, "");
			this.pictureBox1.Image = global::ToolRegFB.Properties.Resources.icons8_facebook_970;
			this.pictureBox1.Location = new global::System.Drawing.Point(4, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(40, 40);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.bunifuToolTip1.SetToolTip(this.pictureBox1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.pictureBox1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.pictureBox1, "");
			this.btnMaximum.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnMaximum.FlatAppearance.BorderSize = 0;
			this.btnMaximum.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnMaximum.ForeColor = global::System.Drawing.Color.White;
			this.btnMaximum.Image = global::ToolRegFB.Properties.Resources.icons8_maximize_button_20;
			this.btnMaximum.Location = new global::System.Drawing.Point(1296, 4);
			this.btnMaximum.Name = "btnMaximum";
			this.btnMaximum.Size = new global::System.Drawing.Size(44, 34);
			this.btnMaximum.TabIndex = 0;
			this.bunifuToolTip1.SetToolTip(this.btnMaximum, "");
			this.bunifuToolTip1.SetToolTipIcon(this.btnMaximum, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnMaximum, "");
			this.btnMaximum.UseVisualStyleBackColor = true;
			this.btnMaximum.Click += new global::System.EventHandler(this.btnMaximum_Click);
			this.btnMinimize.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnMinimize.FlatAppearance.BorderSize = 0;
			this.btnMinimize.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnMinimize.ForeColor = global::System.Drawing.Color.White;
			this.btnMinimize.Image = global::ToolRegFB.Properties.Resources.icons8_minimize_window_20;
			this.btnMinimize.Location = new global::System.Drawing.Point(1255, 4);
			this.btnMinimize.Name = "btnMinimize";
			this.btnMinimize.Size = new global::System.Drawing.Size(44, 34);
			this.btnMinimize.TabIndex = 0;
			this.bunifuToolTip1.SetToolTip(this.btnMinimize, "");
			this.bunifuToolTip1.SetToolTipIcon(this.btnMinimize, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnMinimize, "");
			this.btnMinimize.UseVisualStyleBackColor = true;
			this.btnMinimize.Click += new global::System.EventHandler(this.btnMinimize_Click);
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.ForeColor = global::System.Drawing.Color.White;
			this.btnClose.Image = global::ToolRegFB.Properties.Resources.icons8_x_20;
			this.btnClose.Location = new global::System.Drawing.Point(1335, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(44, 39);
			this.btnClose.TabIndex = 0;
			this.bunifuToolTip1.SetToolTip(this.btnClose, "");
			this.bunifuToolTip1.SetToolTipIcon(this.btnClose, null);
			this.bunifuToolTip1.SetToolTipTitle(this.btnClose, "");
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.bunifuDragControl1.Fixed = true;
			this.bunifuDragControl1.Horizontal = true;
			this.bunifuDragControl1.TargetControl = this.panel1;
			this.bunifuDragControl1.Vertical = true;
			this.bunifuFormDock1.AllowFormDragging = true;
			this.bunifuFormDock1.AllowFormDropShadow = true;
			this.bunifuFormDock1.AllowFormResizing = true;
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
			this.bunifuFormDock1.TitleBarOptions.TitleBarControl = this.panelListDevice;
			this.bunifuFormDock1.TitleBarOptions.UseBackColorOnDockingIndicators = false;
			this.bunifuToolTip1.Active = true;
			this.bunifuToolTip1.AlignTextWithTitle = false;
			this.bunifuToolTip1.AllowAutoClose = false;
			this.bunifuToolTip1.AllowFading = true;
			this.bunifuToolTip1.AutoCloseDuration = 5000;
			this.bunifuToolTip1.BackColor = global::System.Drawing.SystemColors.Control;
			this.bunifuToolTip1.BorderColor = global::System.Drawing.Color.Gainsboro;
			this.bunifuToolTip1.ClickToShowDisplayControl = false;
			this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
			this.bunifuToolTip1.DisplayControl = null;
			this.bunifuToolTip1.EntryAnimationSpeed = 350;
			this.bunifuToolTip1.ExitAnimationSpeed = 200;
			this.bunifuToolTip1.GenerateAutoCloseDuration = false;
			this.bunifuToolTip1.IconMargin = 6;
			this.bunifuToolTip1.InitialDelay = 0;
			this.bunifuToolTip1.Name = "bunifuToolTip1";
			this.bunifuToolTip1.Opacity = 1.0;
			this.bunifuToolTip1.OverrideToolTipTitles = false;
			this.bunifuToolTip1.Padding = new global::System.Windows.Forms.Padding(10);
			this.bunifuToolTip1.ReshowDelay = 100;
			this.bunifuToolTip1.ShowAlways = true;
			this.bunifuToolTip1.ShowBorders = true;
			this.bunifuToolTip1.ShowIcons = true;
			this.bunifuToolTip1.ShowShadows = true;
			this.bunifuToolTip1.Tag = null;
			this.bunifuToolTip1.TextFont = new global::System.Drawing.Font("Segoe UI", 9f);
			this.bunifuToolTip1.TextForeColor = global::System.Drawing.Color.FromArgb(64, 64, 64);
			this.bunifuToolTip1.TextMargin = 2;
			this.bunifuToolTip1.TitleFont = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold);
			this.bunifuToolTip1.TitleForeColor = global::System.Drawing.Color.Black;
			this.bunifuToolTip1.ToolTipPosition = new global::System.Drawing.Point(0, 0);
			this.bunifuToolTip1.ToolTipTitle = null;
			this.bunifuVScrollBar1.AllowCursorChanges = true;
			this.bunifuVScrollBar1.AllowHomeEndKeysDetection = false;
			this.bunifuVScrollBar1.AllowIncrementalClickMoves = true;
			this.bunifuVScrollBar1.AllowMouseDownEffects = true;
			this.bunifuVScrollBar1.AllowMouseHoverEffects = true;
			this.bunifuVScrollBar1.AllowScrollingAnimations = true;
			this.bunifuVScrollBar1.AllowScrollKeysDetection = true;
			this.bunifuVScrollBar1.AllowScrollOptionsMenu = true;
			this.bunifuVScrollBar1.AllowShrinkingOnFocusLost = false;
			this.bunifuVScrollBar1.BackgroundColor = global::System.Drawing.Color.Silver;
			this.bunifuVScrollBar1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("bunifuVScrollBar1.BackgroundImage");
			this.bunifuVScrollBar1.BindingContainer = this.panelListDevice;
			this.bunifuVScrollBar1.BorderColor = global::System.Drawing.Color.Silver;
			this.bunifuVScrollBar1.BorderRadius = 14;
			this.bunifuVScrollBar1.BorderThickness = 1;
			this.bunifuVScrollBar1.Dock = global::System.Windows.Forms.DockStyle.Right;
			this.bunifuVScrollBar1.DurationBeforeShrink = 2000;
			this.bunifuVScrollBar1.LargeChange = 10;
			this.bunifuVScrollBar1.Location = new global::System.Drawing.Point(1365, 46);
			this.bunifuVScrollBar1.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.bunifuVScrollBar1.Maximum = 100;
			this.bunifuVScrollBar1.Minimum = 0;
			this.bunifuVScrollBar1.MinimumThumbLength = 18;
			this.bunifuVScrollBar1.Name = "bunifuVScrollBar1";
			this.bunifuVScrollBar1.OnDisable.ScrollBarBorderColor = global::System.Drawing.Color.Silver;
			this.bunifuVScrollBar1.OnDisable.ScrollBarColor = global::System.Drawing.Color.Transparent;
			this.bunifuVScrollBar1.OnDisable.ThumbColor = global::System.Drawing.Color.Silver;
			this.bunifuVScrollBar1.ScrollBarBorderColor = global::System.Drawing.Color.Silver;
			this.bunifuVScrollBar1.ScrollBarColor = global::System.Drawing.Color.Silver;
			this.bunifuVScrollBar1.ShrinkSizeLimit = 3;
			this.bunifuVScrollBar1.Size = new global::System.Drawing.Size(17, 854);
			this.bunifuVScrollBar1.SmallChange = 1;
			this.bunifuVScrollBar1.TabIndex = 2;
			this.bunifuVScrollBar1.ThumbColor = global::System.Drawing.Color.Gray;
			this.bunifuVScrollBar1.ThumbLength = 84;
			this.bunifuVScrollBar1.ThumbMargin = 1;
			this.bunifuVScrollBar1.ThumbStyle = 0;
			this.bunifuToolTip1.SetToolTip(this.bunifuVScrollBar1, "");
			this.bunifuToolTip1.SetToolTipIcon(this.bunifuVScrollBar1, null);
			this.bunifuToolTip1.SetToolTipTitle(this.bunifuVScrollBar1, "");
			this.bunifuVScrollBar1.Value = 0;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(1382, 900);
			base.Controls.Add(this.bunifuVScrollBar1);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panelListDevice);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmViewLD";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LDPLayer View";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmViewLD_FormClosing);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x040002F4 RID: 756
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002F5 RID: 757
		private global::System.Windows.Forms.FlowLayoutPanel panelListDevice;

		// Token: 0x040002F6 RID: 758
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040002F7 RID: 759
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;

		// Token: 0x040002F8 RID: 760
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040002F9 RID: 761
		private global::System.Windows.Forms.Button btnMinimize;

		// Token: 0x040002FA RID: 762
		private global::System.Windows.Forms.Button btnMaximum;

		// Token: 0x040002FB RID: 763
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040002FC RID: 764
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002FD RID: 765
		private global::Bunifu.UI.WinForms.BunifuFormDock bunifuFormDock1;

		// Token: 0x040002FE RID: 766
		private global::Bunifu.UI.WinForms.BunifuVScrollBar bunifuVScrollBar1;

		// Token: 0x040002FF RID: 767
		private global::Bunifu.UI.WinForms.BunifuToolTip bunifuToolTip1;
	}
}
