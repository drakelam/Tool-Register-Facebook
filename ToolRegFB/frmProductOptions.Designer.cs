namespace ToolRegFB
{
	// Token: 0x02000036 RID: 54
	public partial class frmProductOptions : global::System.Windows.Forms.Form
	{
		// Token: 0x0600029E RID: 670 RVA: 0x000317A4 File Offset: 0x0002F9A4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x000317DC File Offset: 0x0002F9DC
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ToolRegFB.frmProductOptions));
			global::Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges = new global::Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.bunifuPanel1 = new global::Bunifu.UI.WinForms.BunifuPanel();
			this.bunifuCustomLabel9 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.bunifuCustomLabel6 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.bunifuCustomLabel10 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.bunifuCustomLabel4 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.lbl12thang = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.lbl6thang = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.lbl1ngay = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.lbl1thang = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.bunifuCustomLabel7 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.chk12thang = new global::Bunifu.Framework.UI.BunifuCheckbox();
			this.bunifuCustomLabel3 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.chk6thang = new global::Bunifu.Framework.UI.BunifuCheckbox();
			this.bunifuCustomLabel5 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.chk1ngay = new global::Bunifu.Framework.UI.BunifuCheckbox();
			this.bunifuCustomLabel2 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.chk1thang = new global::Bunifu.Framework.UI.BunifuCheckbox();
			this.btnRegProduct = new global::Bunifu.UI.WinForms.BunifuButton.BunifuButton();
			this.bunifuCustomLabel1 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.bunifuDragControl1 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuDragControl2 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.panel4.SuspendLayout();
			this.bunifuPanel1.SuspendLayout();
			base.SuspendLayout();
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(46, 51, 73);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.btnClose);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(580, 46);
			this.panel4.TabIndex = 8;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(4, 6);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(202, 32);
			this.label1.TabIndex = 19;
			this.label1.Text = "Các gói thuê tool";
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Image = global::ToolRegFB.Properties.Resources.icons8_x_20;
			this.btnClose.Location = new global::System.Drawing.Point(533, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(44, 39);
			this.btnClose.TabIndex = 5;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.bunifuPanel1.BackgroundColor = global::System.Drawing.Color.White;
			this.bunifuPanel1.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("bunifuPanel1.BackgroundImage");
			this.bunifuPanel1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuPanel1.BorderColor = global::System.Drawing.Color.Transparent;
			this.bunifuPanel1.BorderRadius = 3;
			this.bunifuPanel1.BorderThickness = 1;
			this.bunifuPanel1.Controls.Add(this.bunifuCustomLabel9);
			this.bunifuPanel1.Controls.Add(this.bunifuCustomLabel6);
			this.bunifuPanel1.Controls.Add(this.bunifuCustomLabel10);
			this.bunifuPanel1.Controls.Add(this.bunifuCustomLabel4);
			this.bunifuPanel1.Controls.Add(this.lbl12thang);
			this.bunifuPanel1.Controls.Add(this.lbl6thang);
			this.bunifuPanel1.Controls.Add(this.lbl1ngay);
			this.bunifuPanel1.Controls.Add(this.lbl1thang);
			this.bunifuPanel1.Controls.Add(this.bunifuCustomLabel7);
			this.bunifuPanel1.Controls.Add(this.chk12thang);
			this.bunifuPanel1.Controls.Add(this.bunifuCustomLabel3);
			this.bunifuPanel1.Controls.Add(this.chk6thang);
			this.bunifuPanel1.Controls.Add(this.bunifuCustomLabel5);
			this.bunifuPanel1.Controls.Add(this.chk1ngay);
			this.bunifuPanel1.Controls.Add(this.bunifuCustomLabel2);
			this.bunifuPanel1.Controls.Add(this.chk1thang);
			this.bunifuPanel1.Controls.Add(this.btnRegProduct);
			this.bunifuPanel1.Controls.Add(this.bunifuCustomLabel1);
			this.bunifuPanel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.bunifuPanel1.Location = new global::System.Drawing.Point(0, 46);
			this.bunifuPanel1.Name = "bunifuPanel1";
			this.bunifuPanel1.ShowBorders = true;
			this.bunifuPanel1.Size = new global::System.Drawing.Size(580, 265);
			this.bunifuPanel1.TabIndex = 13;
			this.bunifuCustomLabel9.AutoSize = true;
			this.bunifuCustomLabel9.BackColor = global::System.Drawing.Color.Transparent;
			this.bunifuCustomLabel9.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel9.Location = new global::System.Drawing.Point(207, 174);
			this.bunifuCustomLabel9.Name = "bunifuCustomLabel9";
			this.bunifuCustomLabel9.Size = new global::System.Drawing.Size(107, 20);
			this.bunifuCustomLabel9.TabIndex = 18;
			this.bunifuCustomLabel9.Text = "xu (giảm 30%)";
			this.bunifuCustomLabel6.AutoSize = true;
			this.bunifuCustomLabel6.BackColor = global::System.Drawing.Color.Transparent;
			this.bunifuCustomLabel6.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel6.Location = new global::System.Drawing.Point(207, 139);
			this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
			this.bunifuCustomLabel6.Size = new global::System.Drawing.Size(105, 20);
			this.bunifuCustomLabel6.TabIndex = 18;
			this.bunifuCustomLabel6.Text = "xu (giảm 10%)";
			this.bunifuCustomLabel10.AutoSize = true;
			this.bunifuCustomLabel10.BackColor = global::System.Drawing.Color.Transparent;
			this.bunifuCustomLabel10.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel10.Location = new global::System.Drawing.Point(199, 68);
			this.bunifuCustomLabel10.Name = "bunifuCustomLabel10";
			this.bunifuCustomLabel10.Size = new global::System.Drawing.Size(26, 20);
			this.bunifuCustomLabel10.TabIndex = 18;
			this.bunifuCustomLabel10.Text = "xu";
			this.bunifuCustomLabel4.AutoSize = true;
			this.bunifuCustomLabel4.BackColor = global::System.Drawing.Color.Transparent;
			this.bunifuCustomLabel4.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel4.Location = new global::System.Drawing.Point(198, 104);
			this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
			this.bunifuCustomLabel4.Size = new global::System.Drawing.Size(26, 20);
			this.bunifuCustomLabel4.TabIndex = 18;
			this.bunifuCustomLabel4.Text = "xu";
			this.lbl12thang.AutoSize = true;
			this.lbl12thang.BackColor = global::System.Drawing.Color.Transparent;
			this.lbl12thang.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lbl12thang.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lbl12thang.Location = new global::System.Drawing.Point(165, 174);
			this.lbl12thang.Name = "lbl12thang";
			this.lbl12thang.Size = new global::System.Drawing.Size(41, 20);
			this.lbl12thang.TabIndex = 18;
			this.lbl12thang.Text = "9600";
			this.lbl6thang.AutoSize = true;
			this.lbl6thang.BackColor = global::System.Drawing.Color.Transparent;
			this.lbl6thang.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lbl6thang.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lbl6thang.Location = new global::System.Drawing.Point(165, 139);
			this.lbl6thang.Name = "lbl6thang";
			this.lbl6thang.Size = new global::System.Drawing.Size(42, 20);
			this.lbl6thang.TabIndex = 18;
			this.lbl6thang.Text = "4800";
			this.lbl1ngay.AutoSize = true;
			this.lbl1ngay.BackColor = global::System.Drawing.Color.Transparent;
			this.lbl1ngay.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lbl1ngay.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lbl1ngay.Location = new global::System.Drawing.Point(165, 68);
			this.lbl1ngay.Name = "lbl1ngay";
			this.lbl1ngay.Size = new global::System.Drawing.Size(33, 20);
			this.lbl1ngay.TabIndex = 18;
			this.lbl1ngay.Text = "200";
			this.lbl1thang.AutoSize = true;
			this.lbl1thang.BackColor = global::System.Drawing.Color.Transparent;
			this.lbl1thang.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lbl1thang.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lbl1thang.Location = new global::System.Drawing.Point(165, 104);
			this.lbl1thang.Name = "lbl1thang";
			this.lbl1thang.Size = new global::System.Drawing.Size(33, 20);
			this.lbl1thang.TabIndex = 18;
			this.lbl1thang.Text = "800";
			this.bunifuCustomLabel7.AutoSize = true;
			this.bunifuCustomLabel7.BackColor = global::System.Drawing.Color.Transparent;
			this.bunifuCustomLabel7.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel7.Location = new global::System.Drawing.Point(93, 174);
			this.bunifuCustomLabel7.Name = "bunifuCustomLabel7";
			this.bunifuCustomLabel7.Size = new global::System.Drawing.Size(71, 20);
			this.bunifuCustomLabel7.TabIndex = 18;
			this.bunifuCustomLabel7.Text = "12 tháng:";
			this.bunifuCustomLabel7.Click += new global::System.EventHandler(this.bunifuCustomLabel7_Click);
			this.chk12thang.BackColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.chk12thang.ChechedOffColor = global::System.Drawing.Color.FromArgb(132, 135, 140);
			this.chk12thang.Checked = true;
			this.chk12thang.CheckedOnColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.chk12thang.ForeColor = global::System.Drawing.Color.White;
			this.chk12thang.Location = new global::System.Drawing.Point(66, 173);
			this.chk12thang.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chk12thang.Name = "chk12thang";
			this.chk12thang.Size = new global::System.Drawing.Size(20, 20);
			this.chk12thang.TabIndex = 17;
			this.chk12thang.OnChange += new global::System.EventHandler(this.chk12thang_OnChange);
			this.bunifuCustomLabel3.AutoSize = true;
			this.bunifuCustomLabel3.BackColor = global::System.Drawing.Color.Transparent;
			this.bunifuCustomLabel3.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel3.Location = new global::System.Drawing.Point(93, 139);
			this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			this.bunifuCustomLabel3.Size = new global::System.Drawing.Size(65, 20);
			this.bunifuCustomLabel3.TabIndex = 18;
			this.bunifuCustomLabel3.Text = "6 tháng:";
			this.bunifuCustomLabel3.Click += new global::System.EventHandler(this.bunifuCustomLabel3_Click);
			this.chk6thang.BackColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.chk6thang.ChechedOffColor = global::System.Drawing.Color.FromArgb(132, 135, 140);
			this.chk6thang.Checked = true;
			this.chk6thang.CheckedOnColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.chk6thang.ForeColor = global::System.Drawing.Color.White;
			this.chk6thang.Location = new global::System.Drawing.Point(66, 138);
			this.chk6thang.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chk6thang.Name = "chk6thang";
			this.chk6thang.Size = new global::System.Drawing.Size(20, 20);
			this.chk6thang.TabIndex = 17;
			this.chk6thang.OnChange += new global::System.EventHandler(this.chk6thang_OnChange);
			this.bunifuCustomLabel5.AutoSize = true;
			this.bunifuCustomLabel5.BackColor = global::System.Drawing.Color.Transparent;
			this.bunifuCustomLabel5.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel5.Location = new global::System.Drawing.Point(93, 68);
			this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			this.bunifuCustomLabel5.Size = new global::System.Drawing.Size(54, 20);
			this.bunifuCustomLabel5.TabIndex = 18;
			this.bunifuCustomLabel5.Text = "1 tuần:";
			this.bunifuCustomLabel5.Click += new global::System.EventHandler(this.bunifuCustomLabel2_Click);
			this.chk1ngay.BackColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.chk1ngay.ChechedOffColor = global::System.Drawing.Color.FromArgb(132, 135, 140);
			this.chk1ngay.Checked = true;
			this.chk1ngay.CheckedOnColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.chk1ngay.ForeColor = global::System.Drawing.Color.White;
			this.chk1ngay.Location = new global::System.Drawing.Point(66, 67);
			this.chk1ngay.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chk1ngay.Name = "chk1ngay";
			this.chk1ngay.Size = new global::System.Drawing.Size(20, 20);
			this.chk1ngay.TabIndex = 17;
			this.chk1ngay.OnChange += new global::System.EventHandler(this.chk1ngay_OnChange);
			this.bunifuCustomLabel2.AutoSize = true;
			this.bunifuCustomLabel2.BackColor = global::System.Drawing.Color.Transparent;
			this.bunifuCustomLabel2.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel2.Location = new global::System.Drawing.Point(93, 104);
			this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			this.bunifuCustomLabel2.Size = new global::System.Drawing.Size(63, 20);
			this.bunifuCustomLabel2.TabIndex = 18;
			this.bunifuCustomLabel2.Text = "1 tháng:";
			this.bunifuCustomLabel2.Click += new global::System.EventHandler(this.bunifuCustomLabel2_Click);
			this.chk1thang.BackColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.chk1thang.ChechedOffColor = global::System.Drawing.Color.FromArgb(132, 135, 140);
			this.chk1thang.Checked = true;
			this.chk1thang.CheckedOnColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.chk1thang.ForeColor = global::System.Drawing.Color.White;
			this.chk1thang.Location = new global::System.Drawing.Point(66, 103);
			this.chk1thang.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.chk1thang.Name = "chk1thang";
			this.chk1thang.Size = new global::System.Drawing.Size(20, 20);
			this.chk1thang.TabIndex = 17;
			this.chk1thang.OnChange += new global::System.EventHandler(this.bunifuCheckbox1_OnChange);
			this.btnRegProduct.AllowAnimations = true;
			this.btnRegProduct.AllowMouseEffects = true;
			this.btnRegProduct.AllowToggling = false;
			this.btnRegProduct.AnimationSpeed = 200;
			this.btnRegProduct.AutoGenerateColors = false;
			this.btnRegProduct.AutoRoundBorders = false;
			this.btnRegProduct.AutoSizeLeftIcon = true;
			this.btnRegProduct.AutoSizeRightIcon = true;
			this.btnRegProduct.BackColor = global::System.Drawing.Color.Transparent;
			this.btnRegProduct.BackColor1 = global::System.Drawing.Color.FromArgb(51, 122, 183);
			this.btnRegProduct.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("btnRegProduct.BackgroundImage");
			this.btnRegProduct.BorderStyle = 0;
			this.btnRegProduct.ButtonText = "Đăng ký";
			this.btnRegProduct.ButtonTextMarginLeft = 0;
			this.btnRegProduct.ColorContrastOnClick = 45;
			this.btnRegProduct.ColorContrastOnHover = 45;
			this.btnRegProduct.Cursor = global::System.Windows.Forms.Cursors.Default;
			borderEdges.BottomLeft = true;
			borderEdges.BottomRight = true;
			borderEdges.TopLeft = true;
			borderEdges.TopRight = true;
			this.btnRegProduct.CustomizableEdges = borderEdges;
			this.btnRegProduct.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnRegProduct.DisabledBorderColor = global::System.Drawing.Color.FromArgb(191, 191, 191);
			this.btnRegProduct.DisabledFillColor = global::System.Drawing.Color.Empty;
			this.btnRegProduct.DisabledForecolor = global::System.Drawing.Color.Empty;
			this.btnRegProduct.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btnRegProduct.FocusState = 2;
			this.btnRegProduct.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnRegProduct.ForeColor = global::System.Drawing.Color.Black;
			this.btnRegProduct.IconLeft = null;
			this.btnRegProduct.IconLeftAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRegProduct.IconLeftCursor = global::System.Windows.Forms.Cursors.Default;
			this.btnRegProduct.IconLeftPadding = new global::System.Windows.Forms.Padding(11, 3, 3, 3);
			this.btnRegProduct.IconMarginLeft = 11;
			this.btnRegProduct.IconPadding = 10;
			this.btnRegProduct.IconRight = null;
			this.btnRegProduct.IconRightAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.btnRegProduct.IconRightCursor = global::System.Windows.Forms.Cursors.Default;
			this.btnRegProduct.IconRightPadding = new global::System.Windows.Forms.Padding(3, 3, 7, 3);
			this.btnRegProduct.IconSize = 25;
			this.btnRegProduct.IdleBorderColor = global::System.Drawing.Color.Empty;
			this.btnRegProduct.IdleBorderRadius = 0;
			this.btnRegProduct.IdleBorderThickness = 0;
			this.btnRegProduct.IdleFillColor = global::System.Drawing.Color.Empty;
			this.btnRegProduct.IdleIconLeftImage = null;
			this.btnRegProduct.IdleIconRightImage = null;
			this.btnRegProduct.IndicateFocus = false;
			this.btnRegProduct.Location = new global::System.Drawing.Point(0, 226);
			this.btnRegProduct.Name = "btnRegProduct";
			this.btnRegProduct.OnDisabledState.BorderColor = global::System.Drawing.Color.FromArgb(191, 191, 191);
			this.btnRegProduct.OnDisabledState.BorderRadius = 1;
			this.btnRegProduct.OnDisabledState.BorderStyle = 0;
			this.btnRegProduct.OnDisabledState.BorderThickness = 1;
			this.btnRegProduct.OnDisabledState.FillColor = global::System.Drawing.Color.FromArgb(204, 204, 204);
			this.btnRegProduct.OnDisabledState.ForeColor = global::System.Drawing.Color.FromArgb(168, 160, 168);
			this.btnRegProduct.OnDisabledState.IconLeftImage = null;
			this.btnRegProduct.OnDisabledState.IconRightImage = null;
			this.btnRegProduct.onHoverState.BorderColor = global::System.Drawing.Color.FromArgb(40, 205, 112);
			this.btnRegProduct.onHoverState.BorderRadius = 1;
			this.btnRegProduct.onHoverState.BorderStyle = 0;
			this.btnRegProduct.onHoverState.BorderThickness = 1;
			this.btnRegProduct.onHoverState.FillColor = global::System.Drawing.Color.FromArgb(40, 205, 112);
			this.btnRegProduct.onHoverState.ForeColor = global::System.Drawing.Color.White;
			this.btnRegProduct.onHoverState.IconLeftImage = null;
			this.btnRegProduct.onHoverState.IconRightImage = null;
			this.btnRegProduct.OnIdleState.BorderColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.btnRegProduct.OnIdleState.BorderRadius = 1;
			this.btnRegProduct.OnIdleState.BorderStyle = 0;
			this.btnRegProduct.OnIdleState.BorderThickness = 1;
			this.btnRegProduct.OnIdleState.FillColor = global::System.Drawing.Color.FromArgb(51, 205, 117);
			this.btnRegProduct.OnIdleState.ForeColor = global::System.Drawing.Color.Black;
			this.btnRegProduct.OnIdleState.IconLeftImage = null;
			this.btnRegProduct.OnIdleState.IconRightImage = null;
			this.btnRegProduct.OnPressedState.BorderColor = global::System.Drawing.Color.FromArgb(40, 205, 158);
			this.btnRegProduct.OnPressedState.BorderRadius = 1;
			this.btnRegProduct.OnPressedState.BorderStyle = 0;
			this.btnRegProduct.OnPressedState.BorderThickness = 1;
			this.btnRegProduct.OnPressedState.FillColor = global::System.Drawing.Color.FromArgb(40, 205, 158);
			this.btnRegProduct.OnPressedState.ForeColor = global::System.Drawing.Color.White;
			this.btnRegProduct.OnPressedState.IconLeftImage = null;
			this.btnRegProduct.OnPressedState.IconRightImage = null;
			this.btnRegProduct.Size = new global::System.Drawing.Size(580, 39);
			this.btnRegProduct.TabIndex = 16;
			this.btnRegProduct.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.btnRegProduct.TextAlignment = global::System.Windows.Forms.HorizontalAlignment.Center;
			this.btnRegProduct.TextMarginLeft = 0;
			this.btnRegProduct.TextPadding = new global::System.Windows.Forms.Padding(0);
			this.btnRegProduct.UseDefaultRadiusAndThickness = true;
			this.bunifuCustomLabel1.AutoSize = true;
			this.bunifuCustomLabel1.BackColor = global::System.Drawing.Color.Transparent;
			this.bunifuCustomLabel1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel1.ForeColor = global::System.Drawing.Color.FromArgb(245, 81, 66);
			this.bunifuCustomLabel1.Location = new global::System.Drawing.Point(37, 20);
			this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			this.bunifuCustomLabel1.Size = new global::System.Drawing.Size(498, 28);
			this.bunifuCustomLabel1.TabIndex = 13;
			this.bunifuCustomLabel1.Text = "Bạn có thể lựa chọn gói theo tháng để tiết kiệm nhé!";
			this.bunifuCustomLabel1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.bunifuDragControl1.Fixed = true;
			this.bunifuDragControl1.Horizontal = true;
			this.bunifuDragControl1.TargetControl = this.panel4;
			this.bunifuDragControl1.Vertical = true;
			this.bunifuDragControl2.Fixed = true;
			this.bunifuDragControl2.Horizontal = true;
			this.bunifuDragControl2.TargetControl = this.bunifuPanel1;
			this.bunifuDragControl2.Vertical = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(580, 311);
			base.Controls.Add(this.bunifuPanel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmProductOptions";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Danh sách gói mua";
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.bunifuPanel1.ResumeLayout(false);
			this.bunifuPanel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040002BC RID: 700
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002BD RID: 701
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040002BE RID: 702
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040002BF RID: 703
		private global::Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;

		// Token: 0x040002C0 RID: 704
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;

		// Token: 0x040002C1 RID: 705
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;

		// Token: 0x040002C2 RID: 706
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;

		// Token: 0x040002C3 RID: 707
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel9;

		// Token: 0x040002C4 RID: 708
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;

		// Token: 0x040002C5 RID: 709
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel7;

		// Token: 0x040002C6 RID: 710
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;

		// Token: 0x040002C7 RID: 711
		public global::Bunifu.UI.WinForms.BunifuButton.BunifuButton btnRegProduct;

		// Token: 0x040002C8 RID: 712
		public global::Bunifu.Framework.UI.BunifuCheckbox chk1thang;

		// Token: 0x040002C9 RID: 713
		public global::Bunifu.Framework.UI.BunifuCustomLabel lbl1thang;

		// Token: 0x040002CA RID: 714
		public global::Bunifu.Framework.UI.BunifuCustomLabel lbl12thang;

		// Token: 0x040002CB RID: 715
		public global::Bunifu.Framework.UI.BunifuCustomLabel lbl6thang;

		// Token: 0x040002CC RID: 716
		public global::Bunifu.Framework.UI.BunifuCheckbox chk12thang;

		// Token: 0x040002CD RID: 717
		public global::Bunifu.Framework.UI.BunifuCheckbox chk6thang;

		// Token: 0x040002CE RID: 718
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;

		// Token: 0x040002CF RID: 719
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;

		// Token: 0x040002D0 RID: 720
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002D1 RID: 721
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel10;

		// Token: 0x040002D2 RID: 722
		public global::Bunifu.Framework.UI.BunifuCustomLabel lbl1ngay;

		// Token: 0x040002D3 RID: 723
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;

		// Token: 0x040002D4 RID: 724
		public global::Bunifu.Framework.UI.BunifuCheckbox chk1ngay;
	}
}
