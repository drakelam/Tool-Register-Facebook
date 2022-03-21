namespace ToolRegFB
{
	// Token: 0x02000027 RID: 39
	public partial class frmContainer : global::System.Windows.Forms.Form
	{
		// Token: 0x060001D0 RID: 464 RVA: 0x00010928 File Offset: 0x0000EB28
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00010960 File Offset: 0x0000EB60
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ToolRegFB.frmContainer));
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.btnExitTool = new global::System.Windows.Forms.Button();
			this.btnUpdateVersion = new global::System.Windows.Forms.Button();
			this.pnlNav = new global::System.Windows.Forms.Panel();
			this.btnZalo = new global::System.Windows.Forms.Button();
			this.btnShopee = new global::System.Windows.Forms.Button();
			this.btnInstagram = new global::System.Windows.Forms.Button();
			this.btnLogout = new global::System.Windows.Forms.Button();
			this.btnFacebook = new global::System.Windows.Forms.Button();
			this.btnServices = new global::System.Windows.Forms.Button();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.panel7 = new global::System.Windows.Forms.Panel();
			this.btnUpdateXu = new global::System.Windows.Forms.Button();
			this.btnNapxu = new global::System.Windows.Forms.Button();
			this.lblSoxu = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.lblUserName = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label8 = new global::System.Windows.Forms.Label();
			this.panel8 = new global::System.Windows.Forms.Panel();
			this.btnMinimized = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.pnlListProduct = new global::System.Windows.Forms.Panel();
			this.panel9 = new global::System.Windows.Forms.Panel();
			this.label11 = new global::System.Windows.Forms.Label();
			this.lblVersion = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.label7 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.btnRegInsta = new global::System.Windows.Forms.Button();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.label9 = new global::System.Windows.Forms.Label();
			this.lblLimitInsta = new global::System.Windows.Forms.Label();
			this.lblInstagram = new global::System.Windows.Forms.Label();
			this.label12 = new global::System.Windows.Forms.Label();
			this.label4 = new global::System.Windows.Forms.Label();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.btnRegZalo = new global::System.Windows.Forms.Button();
			this.pictureBox5 = new global::System.Windows.Forms.PictureBox();
			this.label17 = new global::System.Windows.Forms.Label();
			this.lblLimitZalo = new global::System.Windows.Forms.Label();
			this.lblZalo = new global::System.Windows.Forms.Label();
			this.label20 = new global::System.Windows.Forms.Label();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.btnRegShopee = new global::System.Windows.Forms.Button();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.label13 = new global::System.Windows.Forms.Label();
			this.lblLimitShopee = new global::System.Windows.Forms.Label();
			this.lblShopee = new global::System.Windows.Forms.Label();
			this.label16 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.btnRegFB = new global::System.Windows.Forms.Button();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.label6 = new global::System.Windows.Forms.Label();
			this.lblLimitFB = new global::System.Windows.Forms.Label();
			this.lblFb = new global::System.Windows.Forms.Label();
			this.label5 = new global::System.Windows.Forms.Label();
			this.bunifuDragControl2 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuDragControl1 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuDragControl3 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuSnackbar1 = new global::Bunifu.UI.WinForms.BunifuSnackbar(this.components);
			this.timer2 = new global::System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel8.SuspendLayout();
			this.pnlListProduct.SuspendLayout();
			this.panel9.SuspendLayout();
			this.panel4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			this.panel6.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
			this.panel5.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			this.panel3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.panel1.Controls.Add(this.btnExitTool);
			this.panel1.Controls.Add(this.btnUpdateVersion);
			this.panel1.Controls.Add(this.pnlNav);
			this.panel1.Controls.Add(this.btnZalo);
			this.panel1.Controls.Add(this.btnShopee);
			this.panel1.Controls.Add(this.btnInstagram);
			this.panel1.Controls.Add(this.btnLogout);
			this.panel1.Controls.Add(this.btnFacebook);
			this.panel1.Controls.Add(this.btnServices);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new global::System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(287, 700);
			this.panel1.TabIndex = 0;
			this.btnExitTool.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btnExitTool.FlatAppearance.BorderSize = 0;
			this.btnExitTool.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnExitTool.Font = new global::System.Drawing.Font("Nirmala UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnExitTool.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.btnExitTool.Image = global::ToolRegFB.Properties.Resources.icons8_exit_25;
			this.btnExitTool.Location = new global::System.Drawing.Point(0, 575);
			this.btnExitTool.Name = "btnExitTool";
			this.btnExitTool.Size = new global::System.Drawing.Size(287, 42);
			this.btnExitTool.TabIndex = 2;
			this.btnExitTool.Text = "Thoát tool";
			this.btnExitTool.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnExitTool.UseVisualStyleBackColor = true;
			this.btnExitTool.Click += new global::System.EventHandler(this.btnExitTool_Click);
			this.btnUpdateVersion.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btnUpdateVersion.FlatAppearance.BorderSize = 0;
			this.btnUpdateVersion.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnUpdateVersion.Font = new global::System.Drawing.Font("Nirmala UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnUpdateVersion.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.btnUpdateVersion.Image = global::ToolRegFB.Properties.Resources.icons8_update_left_rotation_25;
			this.btnUpdateVersion.Location = new global::System.Drawing.Point(0, 617);
			this.btnUpdateVersion.Name = "btnUpdateVersion";
			this.btnUpdateVersion.Size = new global::System.Drawing.Size(287, 42);
			this.btnUpdateVersion.TabIndex = 9;
			this.btnUpdateVersion.Text = "Cập nhật tool";
			this.btnUpdateVersion.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnUpdateVersion.UseVisualStyleBackColor = true;
			this.btnUpdateVersion.Visible = false;
			this.btnUpdateVersion.Click += new global::System.EventHandler(this.btnUpdateVersion_Click);
			this.pnlNav.BackColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.pnlNav.Location = new global::System.Drawing.Point(0, 322);
			this.pnlNav.Name = "pnlNav";
			this.pnlNav.Size = new global::System.Drawing.Size(4, 200);
			this.pnlNav.TabIndex = 8;
			this.btnZalo.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.btnZalo.FlatAppearance.BorderSize = 0;
			this.btnZalo.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnZalo.Font = new global::System.Drawing.Font("Nirmala UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnZalo.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.btnZalo.Image = global::ToolRegFB.Properties.Resources.icons8_zalo_25;
			this.btnZalo.Location = new global::System.Drawing.Point(0, 502);
			this.btnZalo.Name = "btnZalo";
			this.btnZalo.Size = new global::System.Drawing.Size(287, 52);
			this.btnZalo.TabIndex = 7;
			this.btnZalo.Text = "Auto Reg Zalo";
			this.btnZalo.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnZalo.UseVisualStyleBackColor = true;
			this.btnZalo.Click += new global::System.EventHandler(this.btnZalo_Click);
			this.btnZalo.Leave += new global::System.EventHandler(this.btnZalo_Leave);
			this.btnShopee.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.btnShopee.FlatAppearance.BorderSize = 0;
			this.btnShopee.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnShopee.Font = new global::System.Drawing.Font("Nirmala UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnShopee.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.btnShopee.Image = global::ToolRegFB.Properties.Resources.icons8_shopee_25;
			this.btnShopee.Location = new global::System.Drawing.Point(0, 450);
			this.btnShopee.Name = "btnShopee";
			this.btnShopee.Size = new global::System.Drawing.Size(287, 52);
			this.btnShopee.TabIndex = 5;
			this.btnShopee.Text = "Auto Reg Shopee";
			this.btnShopee.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnShopee.UseVisualStyleBackColor = true;
			this.btnShopee.Click += new global::System.EventHandler(this.btnShopee_Click);
			this.btnShopee.Leave += new global::System.EventHandler(this.btnShopee_Leave);
			this.btnInstagram.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.btnInstagram.FlatAppearance.BorderSize = 0;
			this.btnInstagram.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnInstagram.Font = new global::System.Drawing.Font("Nirmala UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnInstagram.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.btnInstagram.Image = global::ToolRegFB.Properties.Resources.icons8_instagram_25__2_;
			this.btnInstagram.Location = new global::System.Drawing.Point(0, 398);
			this.btnInstagram.Name = "btnInstagram";
			this.btnInstagram.Size = new global::System.Drawing.Size(287, 52);
			this.btnInstagram.TabIndex = 4;
			this.btnInstagram.Text = "Auto Reg Instagram";
			this.btnInstagram.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnInstagram.UseVisualStyleBackColor = true;
			this.btnInstagram.Click += new global::System.EventHandler(this.btnInstagram_Click);
			this.btnInstagram.Leave += new global::System.EventHandler(this.btnInstagram_Leave);
			this.btnLogout.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btnLogout.FlatAppearance.BorderSize = 0;
			this.btnLogout.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnLogout.Font = new global::System.Drawing.Font("Nirmala UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnLogout.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.btnLogout.Image = global::ToolRegFB.Properties.Resources.icons8_shutdown_25;
			this.btnLogout.Location = new global::System.Drawing.Point(0, 659);
			this.btnLogout.Name = "btnLogout";
			this.btnLogout.Size = new global::System.Drawing.Size(287, 41);
			this.btnLogout.TabIndex = 10;
			this.btnLogout.Text = "Đăng xuất";
			this.btnLogout.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnLogout.UseVisualStyleBackColor = true;
			this.btnLogout.Visible = false;
			this.btnLogout.Click += new global::System.EventHandler(this.btnLogout_Click);
			this.btnFacebook.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.btnFacebook.FlatAppearance.BorderSize = 0;
			this.btnFacebook.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnFacebook.Font = new global::System.Drawing.Font("Nirmala UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnFacebook.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.btnFacebook.Image = global::ToolRegFB.Properties.Resources.icons8_facebook_25__1_;
			this.btnFacebook.Location = new global::System.Drawing.Point(0, 346);
			this.btnFacebook.Name = "btnFacebook";
			this.btnFacebook.Size = new global::System.Drawing.Size(287, 52);
			this.btnFacebook.TabIndex = 2;
			this.btnFacebook.Text = "Auto Reg Facebook";
			this.btnFacebook.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnFacebook.UseVisualStyleBackColor = true;
			this.btnFacebook.Click += new global::System.EventHandler(this.btnFacebook_Click);
			this.btnFacebook.Leave += new global::System.EventHandler(this.btnFacebook_Leave);
			this.btnServices.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.btnServices.FlatAppearance.BorderSize = 0;
			this.btnServices.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnServices.Font = new global::System.Drawing.Font("Nirmala UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnServices.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.btnServices.Image = global::ToolRegFB.Properties.Resources.icons8_sign_in_form_password_25;
			this.btnServices.Location = new global::System.Drawing.Point(0, 294);
			this.btnServices.Name = "btnServices";
			this.btnServices.Size = new global::System.Drawing.Size(287, 52);
			this.btnServices.TabIndex = 2;
			this.btnServices.Text = "Đăng ký tool";
			this.btnServices.TextImageRelation = global::System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.btnServices.UseVisualStyleBackColor = true;
			this.btnServices.Click += new global::System.EventHandler(this.btnServices_Click);
			this.btnServices.Leave += new global::System.EventHandler(this.btnServices_Leave);
			this.panel2.Controls.Add(this.panel7);
			this.panel2.Controls.Add(this.btnUpdateXu);
			this.panel2.Controls.Add(this.btnNapxu);
			this.panel2.Controls.Add(this.lblSoxu);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.lblUserName);
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Controls.Add(this.label8);
			this.panel2.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new global::System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(287, 294);
			this.panel2.TabIndex = 1;
			this.panel7.BackColor = global::System.Drawing.Color.FromArgb(158, 161, 176);
			this.panel7.ForeColor = global::System.Drawing.Color.FromArgb(158, 161, 176);
			this.panel7.Location = new global::System.Drawing.Point(2, 285);
			this.panel7.Name = "panel7";
			this.panel7.Size = new global::System.Drawing.Size(280, 4);
			this.panel7.TabIndex = 8;
			this.btnUpdateXu.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnUpdateXu.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnUpdateXu.ForeColor = global::System.Drawing.Color.FromArgb(50, 168, 50);
			this.btnUpdateXu.Location = new global::System.Drawing.Point(127, 220);
			this.btnUpdateXu.Name = "btnUpdateXu";
			this.btnUpdateXu.Size = new global::System.Drawing.Size(143, 49);
			this.btnUpdateXu.TabIndex = 2;
			this.btnUpdateXu.Text = "Cập nhật xu";
			this.btnUpdateXu.UseVisualStyleBackColor = true;
			this.btnUpdateXu.Click += new global::System.EventHandler(this.btnUpdateXu_Click);
			this.btnNapxu.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnNapxu.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnNapxu.ForeColor = global::System.Drawing.Color.FromArgb(245, 81, 66);
			this.btnNapxu.Location = new global::System.Drawing.Point(16, 220);
			this.btnNapxu.Name = "btnNapxu";
			this.btnNapxu.Size = new global::System.Drawing.Size(105, 49);
			this.btnNapxu.TabIndex = 2;
			this.btnNapxu.Text = "Nạp xu";
			this.btnNapxu.UseVisualStyleBackColor = true;
			this.btnNapxu.Click += new global::System.EventHandler(this.btnNapxu_Click);
			this.lblSoxu.AutoSize = true;
			this.lblSoxu.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblSoxu.ForeColor = global::System.Drawing.Color.FromArgb(245, 81, 66);
			this.lblSoxu.Location = new global::System.Drawing.Point(141, 172);
			this.lblSoxu.Name = "lblSoxu";
			this.lblSoxu.Size = new global::System.Drawing.Size(49, 20);
			this.lblSoxu.TabIndex = 3;
			this.lblSoxu.Text = "1000";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(158, 161, 178);
			this.label2.Location = new global::System.Drawing.Point(82, 172);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(56, 18);
			this.label2.TabIndex = 2;
			this.label2.Text = "Số xu:";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(245, 81, 66);
			this.label1.Location = new global::System.Drawing.Point(3, 141);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(79, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Xin chào,";
			this.lblUserName.AutoSize = true;
			this.lblUserName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblUserName.ForeColor = global::System.Drawing.Color.FromArgb(50, 168, 50);
			this.lblUserName.Location = new global::System.Drawing.Point(87, 144);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new global::System.Drawing.Size(88, 17);
			this.lblUserName.TabIndex = 1;
			this.lblUserName.Text = "User Name";
			this.pictureBox1.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.pictureBox1.Image = global::ToolRegFB.Properties.Resources.Publication_Facebook_940x788__px___Dimensions_personnalisées2;
			this.pictureBox1.Location = new global::System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(287, 138);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 7.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.ForeColor = global::System.Drawing.Color.FromArgb(50, 226, 178);
			this.label8.Location = new global::System.Drawing.Point(66, 194);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(142, 17);
			this.label8.TabIndex = 0;
			this.label8.Text = "(1000 VND = 1 xu)";
			this.panel8.Controls.Add(this.btnMinimized);
			this.panel8.Controls.Add(this.btnClose);
			this.panel8.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new global::System.Drawing.Point(287, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new global::System.Drawing.Size(976, 44);
			this.panel8.TabIndex = 4;
			this.btnMinimized.FlatAppearance.BorderSize = 0;
			this.btnMinimized.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnMinimized.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnMinimized.ForeColor = global::System.Drawing.Color.White;
			this.btnMinimized.Image = global::ToolRegFB.Properties.Resources.icons8_minimize_window_201;
			this.btnMinimized.Location = new global::System.Drawing.Point(892, 5);
			this.btnMinimized.Name = "btnMinimized";
			this.btnMinimized.Size = new global::System.Drawing.Size(33, 31);
			this.btnMinimized.TabIndex = 1;
			this.btnMinimized.UseVisualStyleBackColor = true;
			this.btnMinimized.Click += new global::System.EventHandler(this.btnMinimized_Click);
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.ForeColor = global::System.Drawing.Color.White;
			this.btnClose.Image = global::ToolRegFB.Properties.Resources.icons8_x_20;
			this.btnClose.Location = new global::System.Drawing.Point(931, 5);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(33, 31);
			this.btnClose.TabIndex = 1;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.timer1.Interval = 600000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.pnlListProduct.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.pnlListProduct.Controls.Add(this.panel9);
			this.pnlListProduct.Controls.Add(this.panel4);
			this.pnlListProduct.Controls.Add(this.label4);
			this.pnlListProduct.Controls.Add(this.panel6);
			this.pnlListProduct.Controls.Add(this.panel5);
			this.pnlListProduct.Controls.Add(this.panel3);
			this.pnlListProduct.Location = new global::System.Drawing.Point(287, 47);
			this.pnlListProduct.Name = "pnlListProduct";
			this.pnlListProduct.Size = new global::System.Drawing.Size(976, 650);
			this.pnlListProduct.TabIndex = 5;
			this.panel9.Controls.Add(this.label11);
			this.panel9.Controls.Add(this.lblVersion);
			this.panel9.Controls.Add(this.label10);
			this.panel9.Controls.Add(this.label7);
			this.panel9.Controls.Add(this.label3);
			this.panel9.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.panel9.Location = new global::System.Drawing.Point(0, 611);
			this.panel9.Name = "panel9";
			this.panel9.Size = new global::System.Drawing.Size(976, 39);
			this.panel9.TabIndex = 9;
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.ForeColor = global::System.Drawing.Color.White;
			this.label11.Location = new global::System.Drawing.Point(96, 15);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(99, 18);
			this.label11.TabIndex = 0;
			this.label11.Text = "Phong.Ittran";
			this.lblVersion.AutoSize = true;
			this.lblVersion.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblVersion.ForeColor = global::System.Drawing.Color.White;
			this.lblVersion.Location = new global::System.Drawing.Point(914, 15);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new global::System.Drawing.Size(45, 18);
			this.lblVersion.TabIndex = 0;
			this.lblVersion.Text = "1.0.0";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.label10.Location = new global::System.Drawing.Point(3, 15);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(89, 18);
			this.label10.TabIndex = 0;
			this.label10.Text = "Developer:";
			this.label10.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.label7.Location = new global::System.Drawing.Point(399, 15);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(180, 18);
			this.label7.TabIndex = 0;
			this.label7.Text = "© Copyright 2021-2023";
			this.label7.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.label3.Location = new global::System.Drawing.Point(838, 15);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(70, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Version:";
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(37, 42, 64);
			this.panel4.Controls.Add(this.btnRegInsta);
			this.panel4.Controls.Add(this.pictureBox3);
			this.panel4.Controls.Add(this.label9);
			this.panel4.Controls.Add(this.lblLimitInsta);
			this.panel4.Controls.Add(this.lblInstagram);
			this.panel4.Controls.Add(this.label12);
			this.panel4.Location = new global::System.Drawing.Point(521, 77);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(417, 196);
			this.panel4.TabIndex = 5;
			this.btnRegInsta.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnRegInsta.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnRegInsta.ForeColor = global::System.Drawing.Color.FromArgb(245, 81, 66);
			this.btnRegInsta.Location = new global::System.Drawing.Point(22, 128);
			this.btnRegInsta.Name = "btnRegInsta";
			this.btnRegInsta.Size = new global::System.Drawing.Size(130, 58);
			this.btnRegInsta.TabIndex = 2;
			this.btnRegInsta.Text = "Đăng ký";
			this.btnRegInsta.UseVisualStyleBackColor = true;
			this.btnRegInsta.Click += new global::System.EventHandler(this.btnRegInsta_Click);
			this.pictureBox3.Image = global::ToolRegFB.Properties.Resources.icons8_instagram_970;
			this.pictureBox3.Location = new global::System.Drawing.Point(267, 21);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(133, 113);
			this.pictureBox3.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 1;
			this.pictureBox3.TabStop = false;
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.label9.Location = new global::System.Drawing.Point(15, 70);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(228, 36);
			this.label9.TabIndex = 0;
			this.label9.Text = "600 xu/1 tháng";
			this.lblLimitInsta.AutoSize = true;
			this.lblLimitInsta.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLimitInsta.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lblLimitInsta.Location = new global::System.Drawing.Point(285, 151);
			this.lblLimitInsta.Name = "lblLimitInsta";
			this.lblLimitInsta.Size = new global::System.Drawing.Size(66, 18);
			this.lblLimitInsta.TabIndex = 0;
			this.lblLimitInsta.Text = "30 ngày";
			this.lblInstagram.AutoSize = true;
			this.lblInstagram.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblInstagram.ForeColor = global::System.Drawing.Color.FromArgb(50, 226, 178);
			this.lblInstagram.Location = new global::System.Drawing.Point(167, 151);
			this.lblInstagram.Name = "lblInstagram";
			this.lblInstagram.Size = new global::System.Drawing.Size(107, 18);
			this.lblInstagram.TabIndex = 0;
			this.lblInstagram.Text = "Hạn sử dụng:";
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Nirmala UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label12.ForeColor = global::System.Drawing.Color.White;
			this.label12.Location = new global::System.Drawing.Point(24, 21);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(222, 28);
			this.label12.TabIndex = 0;
			this.label12.Text = "Auto Register Instagram";
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 21f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.ForeColor = global::System.Drawing.Color.FromArgb(158, 161, 176);
			this.label4.Location = new global::System.Drawing.Point(37, 16);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(221, 39);
			this.label4.TabIndex = 4;
			this.label4.Text = "Đăng ký tool";
			this.panel6.BackColor = global::System.Drawing.Color.FromArgb(37, 42, 64);
			this.panel6.Controls.Add(this.btnRegZalo);
			this.panel6.Controls.Add(this.pictureBox5);
			this.panel6.Controls.Add(this.label17);
			this.panel6.Controls.Add(this.lblLimitZalo);
			this.panel6.Controls.Add(this.lblZalo);
			this.panel6.Controls.Add(this.label20);
			this.panel6.Location = new global::System.Drawing.Point(521, 325);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(417, 196);
			this.panel6.TabIndex = 6;
			this.btnRegZalo.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnRegZalo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnRegZalo.ForeColor = global::System.Drawing.Color.FromArgb(245, 81, 66);
			this.btnRegZalo.Location = new global::System.Drawing.Point(22, 128);
			this.btnRegZalo.Name = "btnRegZalo";
			this.btnRegZalo.Size = new global::System.Drawing.Size(130, 58);
			this.btnRegZalo.TabIndex = 2;
			this.btnRegZalo.Text = "Đăng ký";
			this.btnRegZalo.UseVisualStyleBackColor = true;
			this.btnRegZalo.Click += new global::System.EventHandler(this.btnRegZalo_Click);
			this.pictureBox5.Image = global::ToolRegFB.Properties.Resources.icons8_zalo_970;
			this.pictureBox5.Location = new global::System.Drawing.Point(267, 21);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new global::System.Drawing.Size(133, 113);
			this.pictureBox5.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox5.TabIndex = 1;
			this.pictureBox5.TabStop = false;
			this.label17.AutoSize = true;
			this.label17.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label17.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.label17.Location = new global::System.Drawing.Point(15, 70);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(228, 36);
			this.label17.TabIndex = 0;
			this.label17.Text = "400 xu/1 tháng";
			this.lblLimitZalo.AutoSize = true;
			this.lblLimitZalo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLimitZalo.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lblLimitZalo.Location = new global::System.Drawing.Point(285, 151);
			this.lblLimitZalo.Name = "lblLimitZalo";
			this.lblLimitZalo.Size = new global::System.Drawing.Size(66, 18);
			this.lblLimitZalo.TabIndex = 0;
			this.lblLimitZalo.Text = "30 ngày";
			this.lblZalo.AutoSize = true;
			this.lblZalo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblZalo.ForeColor = global::System.Drawing.Color.FromArgb(50, 226, 178);
			this.lblZalo.Location = new global::System.Drawing.Point(167, 151);
			this.lblZalo.Name = "lblZalo";
			this.lblZalo.Size = new global::System.Drawing.Size(107, 18);
			this.lblZalo.TabIndex = 0;
			this.lblZalo.Text = "Hạn sử dụng:";
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Nirmala UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label20.ForeColor = global::System.Drawing.Color.White;
			this.label20.Location = new global::System.Drawing.Point(15, 21);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(173, 28);
			this.label20.TabIndex = 0;
			this.label20.Text = "Auto Register Zalo";
			this.panel5.BackColor = global::System.Drawing.Color.FromArgb(37, 42, 64);
			this.panel5.Controls.Add(this.btnRegShopee);
			this.panel5.Controls.Add(this.pictureBox4);
			this.panel5.Controls.Add(this.label13);
			this.panel5.Controls.Add(this.lblLimitShopee);
			this.panel5.Controls.Add(this.lblShopee);
			this.panel5.Controls.Add(this.label16);
			this.panel5.Location = new global::System.Drawing.Point(42, 325);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(417, 196);
			this.panel5.TabIndex = 7;
			this.btnRegShopee.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnRegShopee.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnRegShopee.ForeColor = global::System.Drawing.Color.FromArgb(245, 81, 66);
			this.btnRegShopee.Location = new global::System.Drawing.Point(22, 128);
			this.btnRegShopee.Name = "btnRegShopee";
			this.btnRegShopee.Size = new global::System.Drawing.Size(130, 58);
			this.btnRegShopee.TabIndex = 2;
			this.btnRegShopee.Text = "Đăng ký";
			this.btnRegShopee.UseVisualStyleBackColor = true;
			this.btnRegShopee.Click += new global::System.EventHandler(this.btnRegShopee_Click);
			this.pictureBox4.Image = global::ToolRegFB.Properties.Resources.icons8_shopee_970;
			this.pictureBox4.Location = new global::System.Drawing.Point(267, 21);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(133, 113);
			this.pictureBox4.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox4.TabIndex = 1;
			this.pictureBox4.TabStop = false;
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.label13.Location = new global::System.Drawing.Point(15, 70);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(228, 36);
			this.label13.TabIndex = 0;
			this.label13.Text = "500 xu/1 tháng";
			this.lblLimitShopee.AutoSize = true;
			this.lblLimitShopee.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLimitShopee.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lblLimitShopee.Location = new global::System.Drawing.Point(285, 151);
			this.lblLimitShopee.Name = "lblLimitShopee";
			this.lblLimitShopee.Size = new global::System.Drawing.Size(66, 18);
			this.lblLimitShopee.TabIndex = 0;
			this.lblLimitShopee.Text = "30 ngày";
			this.lblShopee.AutoSize = true;
			this.lblShopee.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblShopee.ForeColor = global::System.Drawing.Color.FromArgb(50, 226, 178);
			this.lblShopee.Location = new global::System.Drawing.Point(167, 151);
			this.lblShopee.Name = "lblShopee";
			this.lblShopee.Size = new global::System.Drawing.Size(107, 18);
			this.lblShopee.TabIndex = 0;
			this.lblShopee.Text = "Hạn sử dụng:";
			this.label16.AutoSize = true;
			this.label16.Font = new global::System.Drawing.Font("Nirmala UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label16.ForeColor = global::System.Drawing.Color.White;
			this.label16.Location = new global::System.Drawing.Point(15, 21);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(201, 28);
			this.label16.TabIndex = 0;
			this.label16.Text = "Auto Register Shopee";
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(37, 42, 64);
			this.panel3.Controls.Add(this.btnRegFB);
			this.panel3.Controls.Add(this.pictureBox2);
			this.panel3.Controls.Add(this.label6);
			this.panel3.Controls.Add(this.lblLimitFB);
			this.panel3.Controls.Add(this.lblFb);
			this.panel3.Controls.Add(this.label5);
			this.panel3.Location = new global::System.Drawing.Point(42, 77);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(417, 196);
			this.panel3.TabIndex = 8;
			this.btnRegFB.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnRegFB.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnRegFB.ForeColor = global::System.Drawing.Color.FromArgb(245, 81, 66);
			this.btnRegFB.Location = new global::System.Drawing.Point(22, 128);
			this.btnRegFB.Name = "btnRegFB";
			this.btnRegFB.Size = new global::System.Drawing.Size(130, 58);
			this.btnRegFB.TabIndex = 2;
			this.btnRegFB.Text = "Đăng ký";
			this.btnRegFB.UseVisualStyleBackColor = true;
			this.btnRegFB.Click += new global::System.EventHandler(this.btnRegFB_Click_1);
			this.pictureBox2.Image = global::ToolRegFB.Properties.Resources.icons8_facebook_970;
			this.pictureBox2.Location = new global::System.Drawing.Point(267, 21);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(133, 113);
			this.pictureBox2.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.ForeColor = global::System.Drawing.Color.FromArgb(0, 126, 249);
			this.label6.Location = new global::System.Drawing.Point(15, 70);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(228, 36);
			this.label6.TabIndex = 0;
			this.label6.Text = "800 xu/1 tháng";
			this.lblLimitFB.AutoSize = true;
			this.lblLimitFB.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLimitFB.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lblLimitFB.Location = new global::System.Drawing.Point(285, 151);
			this.lblLimitFB.Name = "lblLimitFB";
			this.lblLimitFB.Size = new global::System.Drawing.Size(66, 18);
			this.lblLimitFB.TabIndex = 0;
			this.lblLimitFB.Text = "30 ngày";
			this.lblFb.AutoSize = true;
			this.lblFb.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblFb.ForeColor = global::System.Drawing.Color.FromArgb(50, 226, 178);
			this.lblFb.Location = new global::System.Drawing.Point(167, 151);
			this.lblFb.Name = "lblFb";
			this.lblFb.Size = new global::System.Drawing.Size(107, 18);
			this.lblFb.TabIndex = 0;
			this.lblFb.Text = "Hạn sử dụng:";
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Nirmala UI", 12f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.ForeColor = global::System.Drawing.Color.White;
			this.label5.Location = new global::System.Drawing.Point(15, 21);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(219, 28);
			this.label5.TabIndex = 0;
			this.label5.Text = "Auto Register Facebook";
			this.bunifuDragControl2.Fixed = true;
			this.bunifuDragControl2.Horizontal = true;
			this.bunifuDragControl2.TargetControl = this.pictureBox1;
			this.bunifuDragControl2.Vertical = true;
			this.bunifuDragControl1.Fixed = true;
			this.bunifuDragControl1.Horizontal = true;
			this.bunifuDragControl1.TargetControl = this.panel8;
			this.bunifuDragControl1.Vertical = true;
			this.bunifuDragControl3.Fixed = true;
			this.bunifuDragControl3.Horizontal = true;
			this.bunifuDragControl3.TargetControl = this.pnlListProduct;
			this.bunifuDragControl3.Vertical = true;
			this.bunifuSnackbar1.AllowDragging = false;
			this.bunifuSnackbar1.AllowMultipleViews = true;
			this.bunifuSnackbar1.ClickToClose = true;
			this.bunifuSnackbar1.DoubleClickToClose = true;
			this.bunifuSnackbar1.DurationAfterIdle = 3000;
			this.bunifuSnackbar1.ErrorOptions.ActionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.bunifuSnackbar1.ErrorOptions.ActionBorderColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.bunifuSnackbar1.ErrorOptions.ActionBorderRadius = 1;
			this.bunifuSnackbar1.ErrorOptions.ActionFont = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.bunifuSnackbar1.ErrorOptions.ActionForeColor = global::System.Drawing.Color.Black;
			this.bunifuSnackbar1.ErrorOptions.BackColor = global::System.Drawing.Color.White;
			this.bunifuSnackbar1.ErrorOptions.BorderColor = global::System.Drawing.Color.White;
			this.bunifuSnackbar1.ErrorOptions.CloseIconColor = global::System.Drawing.Color.FromArgb(255, 204, 199);
			this.bunifuSnackbar1.ErrorOptions.Font = new global::System.Drawing.Font("Segoe UI", 9.75f);
			this.bunifuSnackbar1.ErrorOptions.ForeColor = global::System.Drawing.Color.Black;
			this.bunifuSnackbar1.ErrorOptions.Icon = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Icon");
			this.bunifuSnackbar1.ErrorOptions.IconLeftMargin = 12;
			this.bunifuSnackbar1.FadeCloseIcon = false;
			this.bunifuSnackbar1.Host = 2;
			this.bunifuSnackbar1.InformationOptions.ActionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.bunifuSnackbar1.InformationOptions.ActionBorderColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.bunifuSnackbar1.InformationOptions.ActionBorderRadius = 1;
			this.bunifuSnackbar1.InformationOptions.ActionFont = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.bunifuSnackbar1.InformationOptions.ActionForeColor = global::System.Drawing.Color.Black;
			this.bunifuSnackbar1.InformationOptions.BackColor = global::System.Drawing.Color.White;
			this.bunifuSnackbar1.InformationOptions.BorderColor = global::System.Drawing.Color.White;
			this.bunifuSnackbar1.InformationOptions.CloseIconColor = global::System.Drawing.Color.FromArgb(145, 213, 255);
			this.bunifuSnackbar1.InformationOptions.Font = new global::System.Drawing.Font("Segoe UI", 9.75f);
			this.bunifuSnackbar1.InformationOptions.ForeColor = global::System.Drawing.Color.Black;
			this.bunifuSnackbar1.InformationOptions.Icon = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Icon1");
			this.bunifuSnackbar1.InformationOptions.IconLeftMargin = 12;
			this.bunifuSnackbar1.Margin = 10;
			this.bunifuSnackbar1.MaximumSize = new global::System.Drawing.Size(0, 0);
			this.bunifuSnackbar1.MaximumViews = 7;
			this.bunifuSnackbar1.MessageRightMargin = 15;
			this.bunifuSnackbar1.MinimumSize = new global::System.Drawing.Size(0, 0);
			this.bunifuSnackbar1.ShowBorders = false;
			this.bunifuSnackbar1.ShowCloseIcon = false;
			this.bunifuSnackbar1.ShowIcon = true;
			this.bunifuSnackbar1.ShowShadows = true;
			this.bunifuSnackbar1.SuccessOptions.ActionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.bunifuSnackbar1.SuccessOptions.ActionBorderColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.bunifuSnackbar1.SuccessOptions.ActionBorderRadius = 1;
			this.bunifuSnackbar1.SuccessOptions.ActionFont = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.bunifuSnackbar1.SuccessOptions.ActionForeColor = global::System.Drawing.Color.Black;
			this.bunifuSnackbar1.SuccessOptions.BackColor = global::System.Drawing.Color.White;
			this.bunifuSnackbar1.SuccessOptions.BorderColor = global::System.Drawing.Color.White;
			this.bunifuSnackbar1.SuccessOptions.CloseIconColor = global::System.Drawing.Color.FromArgb(246, 255, 237);
			this.bunifuSnackbar1.SuccessOptions.Font = new global::System.Drawing.Font("Segoe UI", 9.75f);
			this.bunifuSnackbar1.SuccessOptions.ForeColor = global::System.Drawing.Color.Black;
			this.bunifuSnackbar1.SuccessOptions.Icon = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Icon2");
			this.bunifuSnackbar1.SuccessOptions.IconLeftMargin = 12;
			this.bunifuSnackbar1.ViewsMargin = 7;
			this.bunifuSnackbar1.WarningOptions.ActionBackColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.bunifuSnackbar1.WarningOptions.ActionBorderColor = global::System.Drawing.Color.FromArgb(255, 255, 255);
			this.bunifuSnackbar1.WarningOptions.ActionBorderRadius = 1;
			this.bunifuSnackbar1.WarningOptions.ActionFont = new global::System.Drawing.Font("Segoe UI", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.bunifuSnackbar1.WarningOptions.ActionForeColor = global::System.Drawing.Color.Black;
			this.bunifuSnackbar1.WarningOptions.BackColor = global::System.Drawing.Color.White;
			this.bunifuSnackbar1.WarningOptions.BorderColor = global::System.Drawing.Color.White;
			this.bunifuSnackbar1.WarningOptions.CloseIconColor = global::System.Drawing.Color.FromArgb(255, 229, 143);
			this.bunifuSnackbar1.WarningOptions.Font = new global::System.Drawing.Font("Segoe UI", 9.75f);
			this.bunifuSnackbar1.WarningOptions.ForeColor = global::System.Drawing.Color.Black;
			this.bunifuSnackbar1.WarningOptions.Icon = (global::System.Drawing.Image)componentResourceManager.GetObject("resource.Icon3");
			this.bunifuSnackbar1.WarningOptions.IconLeftMargin = 12;
			this.bunifuSnackbar1.ZoomCloseIcon = true;
			this.timer2.Interval = 10000;
			this.timer2.Tick += new global::System.EventHandler(this.timer2_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(46, 51, 73);
			base.ClientSize = new global::System.Drawing.Size(1263, 700);
			base.Controls.Add(this.pnlListProduct);
			base.Controls.Add(this.panel8);
			base.Controls.Add(this.panel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmContainer";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Social Rabbit Tool";
			base.Load += new global::System.EventHandler(this.frmContainer_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel8.ResumeLayout(false);
			this.pnlListProduct.ResumeLayout(false);
			this.pnlListProduct.PerformLayout();
			this.panel9.ResumeLayout(false);
			this.panel9.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000107 RID: 263
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.Button btnServices;

		// Token: 0x0400010A RID: 266
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.Label lblSoxu;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.Label lblUserName;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x0400010F RID: 271
		private global::System.Windows.Forms.Button btnLogout;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.Button btnFacebook;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.Button btnShopee;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.Button btnInstagram;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.Button btnMinimized;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.Button btnZalo;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.Panel pnlNav;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.Label label8;

		// Token: 0x04000118 RID: 280
		private global::System.Windows.Forms.Button btnNapxu;

		// Token: 0x04000119 RID: 281
		private global::System.Windows.Forms.Panel panel7;

		// Token: 0x0400011A RID: 282
		private global::System.Windows.Forms.Panel panel8;

		// Token: 0x0400011B RID: 283
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x0400011C RID: 284
		private global::System.Windows.Forms.Panel pnlListProduct;

		// Token: 0x0400011D RID: 285
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400011E RID: 286
		private global::System.Windows.Forms.Button btnRegInsta;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.PictureBox pictureBox3;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.Label label9;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Label lblLimitInsta;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.Label lblInstagram;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.Label label12;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.Button btnRegFB;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.PictureBox pictureBox2;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.Label label6;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.Label lblLimitFB;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.Label lblFb;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.Label label5;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.Button btnRegZalo;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.PictureBox pictureBox5;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.Label lblLimitZalo;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.Label lblZalo;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.Label label20;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000134 RID: 308
		private global::System.Windows.Forms.Button btnRegShopee;

		// Token: 0x04000135 RID: 309
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x04000136 RID: 310
		private global::System.Windows.Forms.Label label13;

		// Token: 0x04000137 RID: 311
		private global::System.Windows.Forms.Label lblLimitShopee;

		// Token: 0x04000138 RID: 312
		private global::System.Windows.Forms.Label lblShopee;

		// Token: 0x04000139 RID: 313
		private global::System.Windows.Forms.Label label16;

		// Token: 0x0400013A RID: 314
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400013B RID: 315
		private global::System.Windows.Forms.Button btnUpdateVersion;

		// Token: 0x0400013C RID: 316
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl2;

		// Token: 0x0400013D RID: 317
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;

		// Token: 0x0400013E RID: 318
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl3;

		// Token: 0x0400013F RID: 319
		private global::Bunifu.UI.WinForms.BunifuSnackbar bunifuSnackbar1;

		// Token: 0x04000140 RID: 320
		private global::System.Windows.Forms.Label lblVersion;

		// Token: 0x04000141 RID: 321
		private global::System.Windows.Forms.Label label3;

		// Token: 0x04000142 RID: 322
		private global::System.Windows.Forms.Panel panel9;

		// Token: 0x04000143 RID: 323
		private global::System.Windows.Forms.Label label7;

		// Token: 0x04000144 RID: 324
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.Label label10;

		// Token: 0x04000146 RID: 326
		private global::System.Windows.Forms.Timer timer2;

		// Token: 0x04000147 RID: 327
		private global::System.Windows.Forms.Button btnExitTool;

		// Token: 0x04000148 RID: 328
		private global::System.Windows.Forms.Button btnUpdateXu;
	}
}
