namespace ToolRegFB
{
	// Token: 0x0200002D RID: 45
	public partial class frmMain : global::System.Windows.Forms.Form
	{
		// Token: 0x0600027A RID: 634 RVA: 0x0002793C File Offset: 0x00025B3C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x00027974 File Offset: 0x00025B74
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ToolRegFB.frmMain));
			global::System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new global::System.Windows.Forms.DataGridViewCellStyle();
			this.contextMenuStrip1 = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.chọnToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.tấtCảToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.bôiĐenToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.trạngTháiToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.liveToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.dieToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.checkpointToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.bỏChọnTấtCảToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.uidPassToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.uidPass2FAToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.uidPassTokenCookieToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.mailPassMailToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.allToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.statusStrip1 = new global::System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel9 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.plTrangThai = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel10 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel1 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.stTotalSuccess = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel3 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel4 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.stTotalFail = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel2 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel6 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.stIPCur = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel7 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel14 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.lblCountSelect = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel8 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel16 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.lblTimeExpired = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel15 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel5 = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.lblMachineName = new global::System.Windows.Forms.ToolStripStatusLabel();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.label28 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.btnMaximum = new global::System.Windows.Forms.Button();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.btnMinimized = new global::System.Windows.Forms.Button();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.timer2 = new global::System.Windows.Forms.Timer(this.components);
			this.bunifuDragControl1 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.pnlContainer = new global::Bunifu.UI.WinForms.BunifuPanel();
			this.btnAutoConfig = new global::System.Windows.Forms.Button();
			this.btnSaveConf = new global::System.Windows.Forms.Button();
			this.btnStop = new global::System.Windows.Forms.Button();
			this.btnReg = new global::System.Windows.Forms.Button();
			this.groupBox2 = new global::System.Windows.Forms.GroupBox();
			this.dgvAcc = new global::System.Windows.Forms.DataGridView();
			this.cChose = new global::System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.cId = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.status = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.uid = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pass = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ho = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ten = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.gender = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.conf_2fa = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.token = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cookie = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.email = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.passMail = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phone = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.proxy = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cInfo = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cDevice = new global::System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new global::System.Windows.Forms.GroupBox();
			this.groupBox7 = new global::System.Windows.Forms.GroupBox();
			this.txtLinkAvartar = new global::System.Windows.Forms.TextBox();
			this.btnNhapanh = new global::System.Windows.Forms.Button();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.rbRandomMF = new global::System.Windows.Forms.RadioButton();
			this.rbFemale = new global::System.Windows.Forms.RadioButton();
			this.rbMale = new global::System.Windows.Forms.RadioButton();
			this.chkCoverImg = new global::System.Windows.Forms.CheckBox();
			this.chkAvartar = new global::System.Windows.Forms.CheckBox();
			this.chk2FA = new global::System.Windows.Forms.CheckBox();
			this.chkRandomPass = new global::System.Windows.Forms.CheckBox();
			this.label14 = new global::System.Windows.Forms.Label();
			this.label13 = new global::System.Windows.Forms.Label();
			this.txtPassFb = new global::System.Windows.Forms.TextBox();
			this.label12 = new global::System.Windows.Forms.Label();
			this.cbNameReg = new global::System.Windows.Forms.ComboBox();
			this.groupBox6 = new global::System.Windows.Forms.GroupBox();
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.plNovery = new global::System.Windows.Forms.Panel();
			this.rdNoveriMail = new global::System.Windows.Forms.RadioButton();
			this.rdNovriPhone = new global::System.Windows.Forms.RadioButton();
			this.label18 = new global::System.Windows.Forms.Label();
			this.label17 = new global::System.Windows.Forms.Label();
			this.cbMailAo = new global::System.Windows.Forms.ComboBox();
			this.cbbPhoneCountry = new global::System.Windows.Forms.ComboBox();
			this.plVeriPhone = new global::System.Windows.Forms.Panel();
			this.btnCheckSim = new global::System.Windows.Forms.Button();
			this.label9 = new global::System.Windows.Forms.Label();
			this.label10 = new global::System.Windows.Forms.Label();
			this.cbDvSim = new global::System.Windows.Forms.ComboBox();
			this.txtAPISim = new global::System.Windows.Forms.TextBox();
			this.rdThuePhone = new global::System.Windows.Forms.RadioButton();
			this.rdNoVeri = new global::System.Windows.Forms.RadioButton();
			this.plVeriMail = new global::System.Windows.Forms.Panel();
			this.plHotmailReg = new global::System.Windows.Forms.Panel();
			this.btnCheckAPIAny = new global::System.Windows.Forms.Button();
			this.txtPassmail = new global::System.Windows.Forms.TextBox();
			this.txtAPIAnyCat = new global::System.Windows.Forms.TextBox();
			this.label22 = new global::System.Windows.Forms.Label();
			this.ckRdPassmail = new global::System.Windows.Forms.CheckBox();
			this.chkHideBrowser = new global::System.Windows.Forms.CheckBox();
			this.ckTaoMailBox = new global::System.Windows.Forms.CheckBox();
			this.label19 = new global::System.Windows.Forms.Label();
			this.btnNhapHotmail = new global::System.Windows.Forms.Button();
			this.rdHotMailReg = new global::System.Windows.Forms.RadioButton();
			this.rdHotMailRegisted = new global::System.Windows.Forms.RadioButton();
			this.rdConfMail = new global::System.Windows.Forms.RadioButton();
			this.groupBox8 = new global::System.Windows.Forms.GroupBox();
			this.panel6 = new global::System.Windows.Forms.Panel();
			this.gbCamxuc = new global::System.Windows.Forms.GroupBox();
			this.chkGian = new global::System.Windows.Forms.CheckBox();
			this.chkBuon = new global::System.Windows.Forms.CheckBox();
			this.chkHaha = new global::System.Windows.Forms.CheckBox();
			this.chkTym = new global::System.Windows.Forms.CheckBox();
			this.chkLike = new global::System.Windows.Forms.CheckBox();
			this.plAddfriend = new global::System.Windows.Forms.Panel();
			this.nFriendTo = new global::System.Windows.Forms.NumericUpDown();
			this.label25 = new global::System.Windows.Forms.Label();
			this.nFriendFrom = new global::System.Windows.Forms.NumericUpDown();
			this.label26 = new global::System.Windows.Forms.Label();
			this.label27 = new global::System.Windows.Forms.Label();
			this.chkInNewfeed = new global::System.Windows.Forms.CheckBox();
			this.chkWatch = new global::System.Windows.Forms.CheckBox();
			this.chkWStory = new global::System.Windows.Forms.CheckBox();
			this.chkAddFUID = new global::System.Windows.Forms.CheckBox();
			this.chkReadNotifi = new global::System.Windows.Forms.CheckBox();
			this.groupBox5 = new global::System.Windows.Forms.GroupBox();
			this.panel5 = new global::System.Windows.Forms.Panel();
			this.linkLabel2 = new global::System.Windows.Forms.LinkLabel();
			this.linkLabel1 = new global::System.Windows.Forms.LinkLabel();
			this.plCheckDoiIP = new global::System.Windows.Forms.Panel();
			this.btnTestChangeIP = new global::System.Windows.Forms.Button();
			this.numChangeIP = new global::System.Windows.Forms.NumericUpDown();
			this.label20 = new global::System.Windows.Forms.Label();
			this.label21 = new global::System.Windows.Forms.Label();
			this.pnlAPIMinProxy = new global::System.Windows.Forms.Panel();
			this.btnCheckAPIMinProxy = new global::System.Windows.Forms.Button();
			this.txtApiKeyMinProxy = new global::System.Windows.Forms.RichTextBox();
			this.label49 = new global::System.Windows.Forms.Label();
			this.label50 = new global::System.Windows.Forms.Label();
			this.nudLuongPerIPMinProxy = new global::System.Windows.Forms.NumericUpDown();
			this.plChangeIPDcom = new global::System.Windows.Forms.Panel();
			this.btnGetDcom = new global::System.Windows.Forms.Button();
			this.txtNameDcom = new global::System.Windows.Forms.TextBox();
			this.plTinsoftProxy = new global::System.Windows.Forms.Panel();
			this.nudLuongPerIPTinsoft = new global::System.Windows.Forms.NumericUpDown();
			this.btnCheckProxy = new global::System.Windows.Forms.Button();
			this.label16 = new global::System.Windows.Forms.Label();
			this.label29 = new global::System.Windows.Forms.Label();
			this.label15 = new global::System.Windows.Forms.Label();
			this.txtProxy = new global::System.Windows.Forms.TextBox();
			this.cbLocationProxy = new global::System.Windows.Forms.ComboBox();
			this.rdMinProxy = new global::System.Windows.Forms.RadioButton();
			this.rdTinsoftProxy = new global::System.Windows.Forms.RadioButton();
			this.rdHMA = new global::System.Windows.Forms.RadioButton();
			this.rdChangeIPDcom = new global::System.Windows.Forms.RadioButton();
			this.rdNoChangeIP = new global::System.Windows.Forms.RadioButton();
			this.groupBox4 = new global::System.Windows.Forms.GroupBox();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.numDelayTo = new global::System.Windows.Forms.NumericUpDown();
			this.rdDelayLD = new global::System.Windows.Forms.RadioButton();
			this.label4 = new global::System.Windows.Forms.Label();
			this.numDelayFr = new global::System.Windows.Forms.NumericUpDown();
			this.label5 = new global::System.Windows.Forms.Label();
			this.txtLinkLD = new global::System.Windows.Forms.TextBox();
			this.numDeClsTo = new global::System.Windows.Forms.NumericUpDown();
			this.numDeClsFr = new global::System.Windows.Forms.NumericUpDown();
			this.label7 = new global::System.Windows.Forms.Label();
			this.rdNormal = new global::System.Windows.Forms.RadioButton();
			this.label8 = new global::System.Windows.Forms.Label();
			this.label6 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.groupBox3 = new global::System.Windows.Forms.GroupBox();
			this.numOTP = new global::System.Windows.Forms.NumericUpDown();
			this.nudSoLuotChay = new global::System.Windows.Forms.NumericUpDown();
			this.numThrLdPlay = new global::System.Windows.Forms.NumericUpDown();
			this.label24 = new global::System.Windows.Forms.Label();
			this.label11 = new global::System.Windows.Forms.Label();
			this.button1 = new global::System.Windows.Forms.Button();
			this.label23 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.bunifuFormDock1 = new global::Bunifu.UI.WinForms.BunifuFormDock();
			this.contextMenuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.panel4.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.pnlContainer.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.dgvAcc).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox7.SuspendLayout();
			this.panel3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.panel2.SuspendLayout();
			this.plNovery.SuspendLayout();
			this.plVeriPhone.SuspendLayout();
			this.plVeriMail.SuspendLayout();
			this.plHotmailReg.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.panel6.SuspendLayout();
			this.gbCamxuc.SuspendLayout();
			this.plAddfriend.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nFriendTo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nFriendFrom).BeginInit();
			this.groupBox5.SuspendLayout();
			this.panel5.SuspendLayout();
			this.plCheckDoiIP.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numChangeIP).BeginInit();
			this.pnlAPIMinProxy.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nudLuongPerIPMinProxy).BeginInit();
			this.plChangeIPDcom.SuspendLayout();
			this.plTinsoftProxy.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nudLuongPerIPTinsoft).BeginInit();
			this.groupBox4.SuspendLayout();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numDelayTo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numDelayFr).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numDeClsTo).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numDeClsFr).BeginInit();
			this.groupBox3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numOTP).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudSoLuotChay).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numThrLdPlay).BeginInit();
			base.SuspendLayout();
			this.contextMenuStrip1.ImageScalingSize = new global::System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.chọnToolStripMenuItem,
				this.bỏChọnTấtCảToolStripMenuItem,
				this.copyToolStripMenuItem
			});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new global::System.Drawing.Size(174, 76);
			this.chọnToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.tấtCảToolStripMenuItem,
				this.bôiĐenToolStripMenuItem,
				this.trạngTháiToolStripMenuItem
			});
			this.chọnToolStripMenuItem.Name = "chọnToolStripMenuItem";
			this.chọnToolStripMenuItem.Size = new global::System.Drawing.Size(173, 24);
			this.chọnToolStripMenuItem.Text = "Chọn";
			this.tấtCảToolStripMenuItem.Name = "tấtCảToolStripMenuItem";
			this.tấtCảToolStripMenuItem.Size = new global::System.Drawing.Size(158, 26);
			this.tấtCảToolStripMenuItem.Text = "Tất cả";
			this.tấtCảToolStripMenuItem.Click += new global::System.EventHandler(this.tấtCảToolStripMenuItem_Click);
			this.bôiĐenToolStripMenuItem.Name = "bôiĐenToolStripMenuItem";
			this.bôiĐenToolStripMenuItem.Size = new global::System.Drawing.Size(158, 26);
			this.bôiĐenToolStripMenuItem.Text = "Bôi đen";
			this.bôiĐenToolStripMenuItem.Click += new global::System.EventHandler(this.bôiĐenToolStripMenuItem_Click);
			this.trạngTháiToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.liveToolStripMenuItem,
				this.dieToolStripMenuItem,
				this.checkpointToolStripMenuItem
			});
			this.trạngTháiToolStripMenuItem.Name = "trạngTháiToolStripMenuItem";
			this.trạngTháiToolStripMenuItem.Size = new global::System.Drawing.Size(158, 26);
			this.trạngTháiToolStripMenuItem.Text = "Trạng thái";
			this.liveToolStripMenuItem.Name = "liveToolStripMenuItem";
			this.liveToolStripMenuItem.Size = new global::System.Drawing.Size(166, 26);
			this.liveToolStripMenuItem.Text = "Live";
			this.liveToolStripMenuItem.Click += new global::System.EventHandler(this.liveToolStripMenuItem_Click);
			this.dieToolStripMenuItem.Name = "dieToolStripMenuItem";
			this.dieToolStripMenuItem.Size = new global::System.Drawing.Size(166, 26);
			this.dieToolStripMenuItem.Text = "Die";
			this.dieToolStripMenuItem.Click += new global::System.EventHandler(this.dieToolStripMenuItem_Click);
			this.checkpointToolStripMenuItem.Name = "checkpointToolStripMenuItem";
			this.checkpointToolStripMenuItem.Size = new global::System.Drawing.Size(166, 26);
			this.checkpointToolStripMenuItem.Text = "Checkpoint";
			this.checkpointToolStripMenuItem.Click += new global::System.EventHandler(this.checkpointToolStripMenuItem_Click);
			this.bỏChọnTấtCảToolStripMenuItem.Name = "bỏChọnTấtCảToolStripMenuItem";
			this.bỏChọnTấtCảToolStripMenuItem.Size = new global::System.Drawing.Size(173, 24);
			this.bỏChọnTấtCảToolStripMenuItem.Text = "Bỏ chọn tất cả";
			this.bỏChọnTấtCảToolStripMenuItem.Click += new global::System.EventHandler(this.bỏChọnTấtCảToolStripMenuItem_Click);
			this.copyToolStripMenuItem.DropDownItems.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.uidPassToolStripMenuItem,
				this.uidPass2FAToolStripMenuItem,
				this.uidPassTokenCookieToolStripMenuItem,
				this.mailPassMailToolStripMenuItem,
				this.allToolStripMenuItem
			});
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new global::System.Drawing.Size(173, 24);
			this.copyToolStripMenuItem.Text = "Copy";
			this.uidPassToolStripMenuItem.Name = "uidPassToolStripMenuItem";
			this.uidPassToolStripMenuItem.Size = new global::System.Drawing.Size(239, 26);
			this.uidPassToolStripMenuItem.Text = "Uid|Pass";
			this.uidPassToolStripMenuItem.Click += new global::System.EventHandler(this.uidPassToolStripMenuItem_Click);
			this.uidPass2FAToolStripMenuItem.Name = "uidPass2FAToolStripMenuItem";
			this.uidPass2FAToolStripMenuItem.Size = new global::System.Drawing.Size(239, 26);
			this.uidPass2FAToolStripMenuItem.Text = "Uid|Pass|2FA";
			this.uidPass2FAToolStripMenuItem.Click += new global::System.EventHandler(this.uidPass2FAToolStripMenuItem_Click);
			this.uidPassTokenCookieToolStripMenuItem.Name = "uidPassTokenCookieToolStripMenuItem";
			this.uidPassTokenCookieToolStripMenuItem.Size = new global::System.Drawing.Size(239, 26);
			this.uidPassTokenCookieToolStripMenuItem.Text = "Uid|Pass|Token|Cookie";
			this.uidPassTokenCookieToolStripMenuItem.Click += new global::System.EventHandler(this.uidPassTokenCookieToolStripMenuItem_Click);
			this.mailPassMailToolStripMenuItem.Name = "mailPassMailToolStripMenuItem";
			this.mailPassMailToolStripMenuItem.Size = new global::System.Drawing.Size(239, 26);
			this.mailPassMailToolStripMenuItem.Text = "Mail|PassMail";
			this.mailPassMailToolStripMenuItem.Click += new global::System.EventHandler(this.mailPassMailToolStripMenuItem_Click);
			this.allToolStripMenuItem.Name = "allToolStripMenuItem";
			this.allToolStripMenuItem.Size = new global::System.Drawing.Size(239, 26);
			this.allToolStripMenuItem.Text = "All";
			this.allToolStripMenuItem.Click += new global::System.EventHandler(this.allToolStripMenuItem_Click);
			this.statusStrip1.BackColor = global::System.Drawing.SystemColors.Control;
			this.statusStrip1.ImageScalingSize = new global::System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripStatusLabel9,
				this.plTrangThai,
				this.toolStripStatusLabel10,
				this.toolStripStatusLabel1,
				this.stTotalSuccess,
				this.toolStripStatusLabel3,
				this.toolStripStatusLabel4,
				this.stTotalFail,
				this.toolStripStatusLabel2,
				this.toolStripStatusLabel6,
				this.stIPCur,
				this.toolStripStatusLabel7,
				this.toolStripStatusLabel14,
				this.lblCountSelect,
				this.toolStripStatusLabel8,
				this.toolStripStatusLabel16,
				this.lblTimeExpired,
				this.toolStripStatusLabel15,
				this.toolStripStatusLabel5,
				this.lblMachineName
			});
			this.statusStrip1.Location = new global::System.Drawing.Point(0, 1026);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new global::System.Drawing.Size(1924, 29);
			this.statusStrip1.TabIndex = 3;
			this.statusStrip1.Text = "statusStrip1";
			this.toolStripStatusLabel9.Font = new global::System.Drawing.Font("Segoe UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel9.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
			this.toolStripStatusLabel9.Size = new global::System.Drawing.Size(97, 23);
			this.toolStripStatusLabel9.Text = "Trạng thái:";
			this.plTrangThai.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.plTrangThai.ForeColor = global::System.Drawing.Color.FromArgb(189, 6, 30);
			this.plTrangThai.Name = "plTrangThai";
			this.plTrangThai.Size = new global::System.Drawing.Size(81, 23);
			this.plTrangThai.Text = "Chưa chạy";
			this.toolStripStatusLabel10.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel10.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
			this.toolStripStatusLabel10.Size = new global::System.Drawing.Size(14, 23);
			this.toolStripStatusLabel10.Text = "|";
			this.toolStripStatusLabel1.Font = new global::System.Drawing.Font("Segoe UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel1.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new global::System.Drawing.Size(108, 23);
			this.toolStripStatusLabel1.Text = "Thành công:";
			this.stTotalSuccess.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.stTotalSuccess.ForeColor = global::System.Drawing.Color.FromArgb(6, 189, 11);
			this.stTotalSuccess.Name = "stTotalSuccess";
			this.stTotalSuccess.Size = new global::System.Drawing.Size(18, 23);
			this.stTotalSuccess.Text = "0";
			this.toolStripStatusLabel3.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel3.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			this.toolStripStatusLabel3.Size = new global::System.Drawing.Size(14, 23);
			this.toolStripStatusLabel3.Text = "|";
			this.toolStripStatusLabel4.Font = new global::System.Drawing.Font("Segoe UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel4.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			this.toolStripStatusLabel4.Size = new global::System.Drawing.Size(81, 23);
			this.toolStripStatusLabel4.Text = "Thất bại:";
			this.stTotalFail.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.stTotalFail.ForeColor = global::System.Drawing.Color.Red;
			this.stTotalFail.Name = "stTotalFail";
			this.stTotalFail.Size = new global::System.Drawing.Size(18, 23);
			this.stTotalFail.Text = "0";
			this.toolStripStatusLabel2.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel2.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			this.toolStripStatusLabel2.Size = new global::System.Drawing.Size(14, 23);
			this.toolStripStatusLabel2.Text = "|";
			this.toolStripStatusLabel6.Font = new global::System.Drawing.Font("Segoe UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel6.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
			this.toolStripStatusLabel6.Size = new global::System.Drawing.Size(95, 23);
			this.toolStripStatusLabel6.Text = "IP hiện tại:";
			this.stIPCur.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.stIPCur.ForeColor = global::System.Drawing.Color.FromArgb(6, 40, 189);
			this.stIPCur.Name = "stIPCur";
			this.stIPCur.Size = new global::System.Drawing.Size(74, 23);
			this.stIPCur.Text = "currentIP";
			this.toolStripStatusLabel7.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel7.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
			this.toolStripStatusLabel7.Size = new global::System.Drawing.Size(14, 23);
			this.toolStripStatusLabel7.Text = "|";
			this.toolStripStatusLabel14.Font = new global::System.Drawing.Font("Segoe UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel14.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel14.Name = "toolStripStatusLabel14";
			this.toolStripStatusLabel14.Size = new global::System.Drawing.Size(80, 23);
			this.toolStripStatusLabel14.Text = "Đã chọn:";
			this.lblCountSelect.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblCountSelect.ForeColor = global::System.Drawing.Color.FromArgb(189, 6, 165);
			this.lblCountSelect.Name = "lblCountSelect";
			this.lblCountSelect.Size = new global::System.Drawing.Size(18, 23);
			this.lblCountSelect.Text = "0";
			this.toolStripStatusLabel8.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel8.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
			this.toolStripStatusLabel8.Size = new global::System.Drawing.Size(14, 23);
			this.toolStripStatusLabel8.Text = "|";
			this.toolStripStatusLabel16.Font = new global::System.Drawing.Font("Segoe UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel16.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel16.Name = "toolStripStatusLabel16";
			this.toolStripStatusLabel16.Size = new global::System.Drawing.Size(117, 23);
			this.toolStripStatusLabel16.Text = "Hạn sử dụng:";
			this.lblTimeExpired.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblTimeExpired.ForeColor = global::System.Drawing.Color.FromArgb(173, 18, 16);
			this.lblTimeExpired.Name = "lblTimeExpired";
			this.lblTimeExpired.Size = new global::System.Drawing.Size(18, 23);
			this.lblTimeExpired.Text = "0";
			this.toolStripStatusLabel15.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel15.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel15.Name = "toolStripStatusLabel15";
			this.toolStripStatusLabel15.Size = new global::System.Drawing.Size(14, 23);
			this.toolStripStatusLabel15.Text = "|";
			this.toolStripStatusLabel5.Font = new global::System.Drawing.Font("Segoe UI", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.toolStripStatusLabel5.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
			this.toolStripStatusLabel5.Size = new global::System.Drawing.Size(79, 23);
			this.toolStripStatusLabel5.Text = "Mã máy:";
			this.lblMachineName.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMachineName.ForeColor = global::System.Drawing.Color.FromArgb(86, 89, 10);
			this.lblMachineName.Name = "lblMachineName";
			this.lblMachineName.Size = new global::System.Drawing.Size(18, 23);
			this.lblMachineName.Text = "0";
			this.timer1.Interval = 1000;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.label28.AutoSize = true;
			this.label28.Font = new global::System.Drawing.Font("Nirmala UI", 16.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label28.ForeColor = global::System.Drawing.Color.White;
			this.label28.Location = new global::System.Drawing.Point(42, 2);
			this.label28.Name = "label28";
			this.label28.Size = new global::System.Drawing.Size(498, 38);
			this.label28.TabIndex = 6;
			this.label28.Text = "Auto Register Facebook On LDPlayer";
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(46, 51, 73);
			this.panel4.Controls.Add(this.btnMaximum);
			this.panel4.Controls.Add(this.btnClose);
			this.panel4.Controls.Add(this.btnMinimized);
			this.panel4.Controls.Add(this.label28);
			this.panel4.Controls.Add(this.pictureBox1);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(1924, 46);
			this.panel4.TabIndex = 7;
			this.btnMaximum.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnMaximum.FlatAppearance.BorderSize = 0;
			this.btnMaximum.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnMaximum.ForeColor = global::System.Drawing.Color.White;
			this.btnMaximum.Image = global::ToolRegFB.Properties.Resources.icons8_maximize_button_20;
			this.btnMaximum.Location = new global::System.Drawing.Point(1842, 2);
			this.btnMaximum.Name = "btnMaximum";
			this.btnMaximum.Size = new global::System.Drawing.Size(44, 34);
			this.btnMaximum.TabIndex = 7;
			this.btnMaximum.UseVisualStyleBackColor = true;
			this.btnMaximum.Click += new global::System.EventHandler(this.btnMaximum_Click);
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Image = global::ToolRegFB.Properties.Resources.icons8_x_20;
			this.btnClose.Location = new global::System.Drawing.Point(1877, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(44, 39);
			this.btnClose.TabIndex = 5;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			this.btnMinimized.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnMinimized.FlatAppearance.BorderSize = 0;
			this.btnMinimized.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnMinimized.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnMinimized.Image = global::ToolRegFB.Properties.Resources.icons8_minimize_window_20;
			this.btnMinimized.Location = new global::System.Drawing.Point(1804, 0);
			this.btnMinimized.Name = "btnMinimized";
			this.btnMinimized.Size = new global::System.Drawing.Size(44, 39);
			this.btnMinimized.TabIndex = 5;
			this.btnMinimized.UseVisualStyleBackColor = true;
			this.btnMinimized.Click += new global::System.EventHandler(this.btnMinimized_Click);
			this.pictureBox1.Image = global::ToolRegFB.Properties.Resources.icons8_facebook_970;
			this.pictureBox1.Location = new global::System.Drawing.Point(2, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(40, 40);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			this.timer2.Interval = 5000;
			this.timer2.Tick += new global::System.EventHandler(this.timer2_Tick);
			this.bunifuDragControl1.Fixed = true;
			this.bunifuDragControl1.Horizontal = true;
			this.bunifuDragControl1.TargetControl = this.panel4;
			this.bunifuDragControl1.Vertical = true;
			this.pnlContainer.BackgroundColor = global::System.Drawing.Color.Transparent;
			this.pnlContainer.BackgroundImage = (global::System.Drawing.Image)componentResourceManager.GetObject("pnlContainer.BackgroundImage");
			this.pnlContainer.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.pnlContainer.BorderColor = global::System.Drawing.Color.Transparent;
			this.pnlContainer.BorderRadius = 3;
			this.pnlContainer.BorderThickness = 1;
			this.pnlContainer.Controls.Add(this.btnAutoConfig);
			this.pnlContainer.Controls.Add(this.btnSaveConf);
			this.pnlContainer.Controls.Add(this.btnStop);
			this.pnlContainer.Controls.Add(this.btnReg);
			this.pnlContainer.Controls.Add(this.groupBox2);
			this.pnlContainer.Controls.Add(this.groupBox1);
			this.pnlContainer.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.pnlContainer.Location = new global::System.Drawing.Point(0, 46);
			this.pnlContainer.Name = "pnlContainer";
			this.pnlContainer.ShowBorders = true;
			this.pnlContainer.Size = new global::System.Drawing.Size(1924, 980);
			this.pnlContainer.TabIndex = 8;
			this.btnAutoConfig.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnAutoConfig.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnAutoConfig.ForeColor = global::System.Drawing.Color.FromArgb(66, 135, 245);
			this.btnAutoConfig.Image = global::ToolRegFB.Properties.Resources.icons8_automation_25;
			this.btnAutoConfig.Location = new global::System.Drawing.Point(452, 16);
			this.btnAutoConfig.Name = "btnAutoConfig";
			this.btnAutoConfig.Size = new global::System.Drawing.Size(247, 61);
			this.btnAutoConfig.TabIndex = 5;
			this.btnAutoConfig.Text = "Cấu hình nâng cao";
			this.btnAutoConfig.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnAutoConfig.UseVisualStyleBackColor = true;
			this.btnAutoConfig.Click += new global::System.EventHandler(this.btnAutoConfig_Click);
			this.btnSaveConf.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnSaveConf.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnSaveConf.ForeColor = global::System.Drawing.Color.FromArgb(245, 99, 66);
			this.btnSaveConf.Image = global::ToolRegFB.Properties.Resources.icons8_setting_25;
			this.btnSaveConf.Location = new global::System.Drawing.Point(305, 16);
			this.btnSaveConf.Name = "btnSaveConf";
			this.btnSaveConf.Size = new global::System.Drawing.Size(140, 61);
			this.btnSaveConf.TabIndex = 6;
			this.btnSaveConf.Text = "Lưu cấu hình";
			this.btnSaveConf.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnSaveConf.UseVisualStyleBackColor = true;
			this.btnSaveConf.Click += new global::System.EventHandler(this.btnSaveConf_Click);
			this.btnStop.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnStop.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnStop.ForeColor = global::System.Drawing.Color.Red;
			this.btnStop.Image = global::ToolRegFB.Properties.Resources.icons8_stop_25__1_;
			this.btnStop.Location = new global::System.Drawing.Point(158, 15);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new global::System.Drawing.Size(140, 61);
			this.btnStop.TabIndex = 7;
			this.btnStop.Text = "Dừng lại";
			this.btnStop.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new global::System.EventHandler(this.btnStop_Click);
			this.btnReg.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnReg.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnReg.ForeColor = global::System.Drawing.Color.FromArgb(37, 189, 6);
			this.btnReg.Image = global::ToolRegFB.Properties.Resources.icons8_start_25__1_;
			this.btnReg.Location = new global::System.Drawing.Point(12, 15);
			this.btnReg.Name = "btnReg";
			this.btnReg.Size = new global::System.Drawing.Size(140, 61);
			this.btnReg.TabIndex = 8;
			this.btnReg.Text = "Bắt đầu";
			this.btnReg.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnReg.UseVisualStyleBackColor = true;
			this.btnReg.Click += new global::System.EventHandler(this.btnReg_Click);
			this.groupBox2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox2.BackColor = global::System.Drawing.SystemColors.Control;
			this.groupBox2.Controls.Add(this.dgvAcc);
			this.groupBox2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox2.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.groupBox2.Location = new global::System.Drawing.Point(12, 87);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new global::System.Drawing.Size(735, 884);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Danh sách tài khoản";
			this.dgvAcc.AllowUserToAddRows = false;
			this.dgvAcc.AllowUserToDeleteRows = false;
			this.dgvAcc.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle.Alignment = global::System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = global::System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = global::System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = global::System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = global::System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = global::System.Windows.Forms.DataGridViewTriState.True;
			this.dgvAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.dgvAcc.ColumnHeadersHeightSizeMode = global::System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAcc.Columns.AddRange(new global::System.Windows.Forms.DataGridViewColumn[]
			{
				this.cChose,
				this.cId,
				this.status,
				this.uid,
				this.pass,
				this.ho,
				this.ten,
				this.gender,
				this.conf_2fa,
				this.token,
				this.cookie,
				this.email,
				this.passMail,
				this.phone,
				this.proxy,
				this.cInfo,
				this.cDevice
			});
			this.dgvAcc.ContextMenuStrip = this.contextMenuStrip1;
			this.dgvAcc.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.dgvAcc.EditMode = global::System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvAcc.Location = new global::System.Drawing.Point(3, 23);
			this.dgvAcc.Name = "dgvAcc";
			this.dgvAcc.RowHeadersVisible = false;
			this.dgvAcc.RowHeadersWidth = 51;
			this.dgvAcc.RowTemplate.Height = 24;
			this.dgvAcc.SelectionMode = global::System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAcc.Size = new global::System.Drawing.Size(729, 858);
			this.dgvAcc.TabIndex = 1;
			this.cChose.HeaderText = "Chọn";
			this.cChose.MinimumWidth = 6;
			this.cChose.Name = "cChose";
			this.cChose.Resizable = global::System.Windows.Forms.DataGridViewTriState.True;
			this.cChose.SortMode = global::System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.cChose.Width = 85;
			this.cId.HeaderText = "STT";
			this.cId.MinimumWidth = 6;
			this.cId.Name = "cId";
			this.cId.Width = 85;
			this.status.HeaderText = "Trạng thái";
			this.status.MinimumWidth = 6;
			this.status.Name = "status";
			this.status.Width = 200;
			this.uid.HeaderText = "UID";
			this.uid.MinimumWidth = 6;
			this.uid.Name = "uid";
			this.uid.Width = 125;
			this.pass.HeaderText = "Mật khẩu";
			this.pass.MinimumWidth = 6;
			this.pass.Name = "pass";
			this.pass.Width = 125;
			this.ho.HeaderText = "Họ";
			this.ho.MinimumWidth = 6;
			this.ho.Name = "ho";
			this.ho.Width = 125;
			this.ten.HeaderText = "Tên";
			this.ten.MinimumWidth = 6;
			this.ten.Name = "ten";
			this.ten.Width = 125;
			this.gender.HeaderText = "Giới tính";
			this.gender.MinimumWidth = 6;
			this.gender.Name = "gender";
			this.gender.Width = 125;
			this.conf_2fa.HeaderText = "2Fa";
			this.conf_2fa.MinimumWidth = 6;
			this.conf_2fa.Name = "conf_2fa";
			this.conf_2fa.Width = 125;
			this.token.HeaderText = "Token";
			this.token.MinimumWidth = 6;
			this.token.Name = "token";
			this.token.Width = 125;
			this.cookie.HeaderText = "Cookie";
			this.cookie.MinimumWidth = 6;
			this.cookie.Name = "cookie";
			this.cookie.Width = 125;
			this.email.HeaderText = "Email";
			this.email.MinimumWidth = 6;
			this.email.Name = "email";
			this.email.Width = 125;
			this.passMail.HeaderText = "Pass Mail";
			this.passMail.MinimumWidth = 6;
			this.passMail.Name = "passMail";
			this.passMail.Width = 125;
			this.phone.HeaderText = "Phone";
			this.phone.MinimumWidth = 6;
			this.phone.Name = "phone";
			this.phone.Width = 125;
			this.proxy.HeaderText = "Proxy";
			this.proxy.MinimumWidth = 6;
			this.proxy.Name = "proxy";
			this.proxy.Width = 125;
			this.cInfo.HeaderText = "Tình trạng";
			this.cInfo.MinimumWidth = 6;
			this.cInfo.Name = "cInfo";
			this.cInfo.Width = 125;
			this.cDevice.HeaderText = "LD index";
			this.cDevice.MinimumWidth = 6;
			this.cDevice.Name = "cDevice";
			this.cDevice.Width = 125;
			this.groupBox1.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right);
			this.groupBox1.BackColor = global::System.Drawing.SystemColors.Control;
			this.groupBox1.Controls.Add(this.groupBox7);
			this.groupBox1.Controls.Add(this.groupBox6);
			this.groupBox1.Controls.Add(this.groupBox8);
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.groupBox3);
			this.groupBox1.Font = new global::System.Drawing.Font("Nirmala UI", 10.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox1.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.groupBox1.Location = new global::System.Drawing.Point(753, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new global::System.Drawing.Size(1159, 962);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Cấu hình";
			this.groupBox7.Controls.Add(this.txtLinkAvartar);
			this.groupBox7.Controls.Add(this.btnNhapanh);
			this.groupBox7.Controls.Add(this.panel3);
			this.groupBox7.Controls.Add(this.chkCoverImg);
			this.groupBox7.Controls.Add(this.chkAvartar);
			this.groupBox7.Controls.Add(this.chk2FA);
			this.groupBox7.Controls.Add(this.chkRandomPass);
			this.groupBox7.Controls.Add(this.label14);
			this.groupBox7.Controls.Add(this.label13);
			this.groupBox7.Controls.Add(this.txtPassFb);
			this.groupBox7.Controls.Add(this.label12);
			this.groupBox7.Controls.Add(this.cbNameReg);
			this.groupBox7.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox7.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.groupBox7.Location = new global::System.Drawing.Point(598, 21);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Size = new global::System.Drawing.Size(547, 262);
			this.groupBox7.TabIndex = 1;
			this.groupBox7.TabStop = false;
			this.groupBox7.Text = "Cấu hình tài khoản";
			this.txtLinkAvartar.Location = new global::System.Drawing.Point(170, 195);
			this.txtLinkAvartar.Name = "txtLinkAvartar";
			this.txtLinkAvartar.Size = new global::System.Drawing.Size(201, 24);
			this.txtLinkAvartar.TabIndex = 6;
			this.btnNhapanh.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnNhapanh.Location = new global::System.Drawing.Point(388, 188);
			this.btnNhapanh.Name = "btnNhapanh";
			this.btnNhapanh.Size = new global::System.Drawing.Size(131, 40);
			this.btnNhapanh.TabIndex = 5;
			this.btnNhapanh.Text = "Folder ảnh";
			this.btnNhapanh.UseVisualStyleBackColor = true;
			this.btnNhapanh.Click += new global::System.EventHandler(this.btnNhapanh_Click);
			this.panel3.Controls.Add(this.rbRandomMF);
			this.panel3.Controls.Add(this.rbFemale);
			this.panel3.Controls.Add(this.rbMale);
			this.panel3.Location = new global::System.Drawing.Point(100, 109);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(283, 40);
			this.panel3.TabIndex = 4;
			this.rbRandomMF.AutoSize = true;
			this.rbRandomMF.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbRandomMF.Location = new global::System.Drawing.Point(159, 10);
			this.rbRandomMF.Name = "rbRandomMF";
			this.rbRandomMF.Size = new global::System.Drawing.Size(103, 22);
			this.rbRandomMF.TabIndex = 1;
			this.rbRandomMF.TabStop = true;
			this.rbRandomMF.Text = "Ngẫu nhiên";
			this.rbRandomMF.UseVisualStyleBackColor = true;
			this.rbFemale.AutoSize = true;
			this.rbFemale.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbFemale.Location = new global::System.Drawing.Point(88, 10);
			this.rbFemale.Name = "rbFemale";
			this.rbFemale.Size = new global::System.Drawing.Size(48, 22);
			this.rbFemale.TabIndex = 1;
			this.rbFemale.TabStop = true;
			this.rbFemale.Text = "Nữ";
			this.rbFemale.UseVisualStyleBackColor = true;
			this.rbMale.AutoSize = true;
			this.rbMale.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rbMale.Location = new global::System.Drawing.Point(10, 10);
			this.rbMale.Name = "rbMale";
			this.rbMale.Size = new global::System.Drawing.Size(61, 22);
			this.rbMale.TabIndex = 1;
			this.rbMale.TabStop = true;
			this.rbMale.Text = "Nam";
			this.rbMale.UseVisualStyleBackColor = true;
			this.rbMale.CheckedChanged += new global::System.EventHandler(this.rdMinProxy_CheckedChanged);
			this.chkCoverImg.AutoSize = true;
			this.chkCoverImg.Location = new global::System.Drawing.Point(31, 227);
			this.chkCoverImg.Name = "chkCoverImg";
			this.chkCoverImg.Size = new global::System.Drawing.Size(125, 22);
			this.chkCoverImg.TabIndex = 3;
			this.chkCoverImg.Text = "Thay ảnh bìa";
			this.chkCoverImg.UseVisualStyleBackColor = true;
			this.chkAvartar.AutoSize = true;
			this.chkAvartar.Location = new global::System.Drawing.Point(31, 197);
			this.chkAvartar.Name = "chkAvartar";
			this.chkAvartar.Size = new global::System.Drawing.Size(123, 22);
			this.chkAvartar.TabIndex = 3;
			this.chkAvartar.Text = "Thay avartar";
			this.chkAvartar.UseVisualStyleBackColor = true;
			this.chk2FA.AutoSize = true;
			this.chk2FA.Location = new global::System.Drawing.Point(31, 166);
			this.chk2FA.Name = "chk2FA";
			this.chk2FA.Size = new global::System.Drawing.Size(209, 22);
			this.chk2FA.TabIndex = 3;
			this.chk2FA.Text = "Bật bảo mật 2 lớp (2FA)";
			this.chk2FA.UseVisualStyleBackColor = true;
			this.chkRandomPass.AutoSize = true;
			this.chkRandomPass.Location = new global::System.Drawing.Point(199, 81);
			this.chkRandomPass.Name = "chkRandomPass";
			this.chkRandomPass.Size = new global::System.Drawing.Size(114, 22);
			this.chkRandomPass.TabIndex = 3;
			this.chkRandomPass.Text = "Ngẫu nhiên";
			this.chkRandomPass.UseVisualStyleBackColor = true;
			this.chkRandomPass.CheckedChanged += new global::System.EventHandler(this.chkRandomPass_CheckedChanged);
			this.label14.AutoSize = true;
			this.label14.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label14.Location = new global::System.Drawing.Point(28, 122);
			this.label14.Name = "label14";
			this.label14.Size = new global::System.Drawing.Size(66, 18);
			this.label14.TabIndex = 1;
			this.label14.Text = "Giới tính:";
			this.label13.AutoSize = true;
			this.label13.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label13.Location = new global::System.Drawing.Point(28, 57);
			this.label13.Name = "label13";
			this.label13.Size = new global::System.Drawing.Size(144, 18);
			this.label13.TabIndex = 1;
			this.label13.Text = "Mật khẩu Facebook:";
			this.txtPassFb.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtPassFb.Location = new global::System.Drawing.Point(198, 53);
			this.txtPassFb.Name = "txtPassFb";
			this.txtPassFb.Size = new global::System.Drawing.Size(143, 24);
			this.txtPassFb.TabIndex = 2;
			this.label12.AutoSize = true;
			this.label12.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label12.Location = new global::System.Drawing.Point(28, 27);
			this.label12.Name = "label12";
			this.label12.Size = new global::System.Drawing.Size(92, 18);
			this.label12.TabIndex = 1;
			this.label12.Text = "Tên đăng ký:";
			this.cbNameReg.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbNameReg.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbNameReg.FormattingEnabled = true;
			this.cbNameReg.Items.AddRange(new object[]
			{
				"Tên Việt",
				"Tên nước ngoài"
			});
			this.cbNameReg.Location = new global::System.Drawing.Point(145, 21);
			this.cbNameReg.Name = "cbNameReg";
			this.cbNameReg.Size = new global::System.Drawing.Size(195, 26);
			this.cbNameReg.TabIndex = 2;
			this.groupBox6.Controls.Add(this.panel2);
			this.groupBox6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox6.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.groupBox6.Location = new global::System.Drawing.Point(598, 289);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new global::System.Drawing.Size(547, 517);
			this.groupBox6.TabIndex = 0;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Cấu hình xác minh";
			this.panel2.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left);
			this.panel2.Controls.Add(this.plNovery);
			this.panel2.Controls.Add(this.plVeriPhone);
			this.panel2.Controls.Add(this.rdThuePhone);
			this.panel2.Controls.Add(this.rdNoVeri);
			this.panel2.Controls.Add(this.plVeriMail);
			this.panel2.Controls.Add(this.rdConfMail);
			this.panel2.Location = new global::System.Drawing.Point(3, 20);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(532, 491);
			this.panel2.TabIndex = 7;
			this.plNovery.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.plNovery.Controls.Add(this.rdNoveriMail);
			this.plNovery.Controls.Add(this.rdNovriPhone);
			this.plNovery.Controls.Add(this.label18);
			this.plNovery.Controls.Add(this.label17);
			this.plNovery.Controls.Add(this.cbMailAo);
			this.plNovery.Controls.Add(this.cbbPhoneCountry);
			this.plNovery.Location = new global::System.Drawing.Point(57, 44);
			this.plNovery.Name = "plNovery";
			this.plNovery.Size = new global::System.Drawing.Size(472, 74);
			this.plNovery.TabIndex = 5;
			this.rdNoveriMail.AutoSize = true;
			this.rdNoveriMail.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdNoveriMail.Location = new global::System.Drawing.Point(15, 42);
			this.rdNoveriMail.Name = "rdNoveriMail";
			this.rdNoveriMail.Size = new global::System.Drawing.Size(77, 22);
			this.rdNoveriMail.TabIndex = 1;
			this.rdNoveriMail.Text = "Mail ảo";
			this.rdNoveriMail.UseVisualStyleBackColor = true;
			this.rdNovriPhone.AutoSize = true;
			this.rdNovriPhone.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdNovriPhone.Location = new global::System.Drawing.Point(15, 3);
			this.rdNovriPhone.Name = "rdNovriPhone";
			this.rdNovriPhone.Size = new global::System.Drawing.Size(136, 22);
			this.rdNovriPhone.TabIndex = 1;
			this.rdNovriPhone.Text = "Số điện thoại ảo";
			this.rdNovriPhone.UseVisualStyleBackColor = true;
			this.label18.AutoSize = true;
			this.label18.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label18.Location = new global::System.Drawing.Point(102, 43);
			this.label18.Name = "label18";
			this.label18.Size = new global::System.Drawing.Size(81, 18);
			this.label18.TabIndex = 0;
			this.label18.Text = "Loại mail:";
			this.label17.AutoSize = true;
			this.label17.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label17.Location = new global::System.Drawing.Point(176, 7);
			this.label17.Name = "label17";
			this.label17.Size = new global::System.Drawing.Size(81, 18);
			this.label17.TabIndex = 0;
			this.label17.Text = "Quốc gia:";
			this.cbMailAo.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMailAo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbMailAo.FormattingEnabled = true;
			this.cbMailAo.Items.AddRange(new object[]
			{
				"Gmail",
				"Yahoo",
				"Hotmail"
			});
			this.cbMailAo.Location = new global::System.Drawing.Point(200, 38);
			this.cbMailAo.Name = "cbMailAo";
			this.cbMailAo.Size = new global::System.Drawing.Size(183, 26);
			this.cbMailAo.TabIndex = 2;
			this.cbbPhoneCountry.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbbPhoneCountry.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbbPhoneCountry.FormattingEnabled = true;
			this.cbbPhoneCountry.Items.AddRange(new object[]
			{
				"VN",
				"USA"
			});
			this.cbbPhoneCountry.Location = new global::System.Drawing.Point(274, 2);
			this.cbbPhoneCountry.Name = "cbbPhoneCountry";
			this.cbbPhoneCountry.Size = new global::System.Drawing.Size(110, 26);
			this.cbbPhoneCountry.TabIndex = 2;
			this.plVeriPhone.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.plVeriPhone.Controls.Add(this.btnCheckSim);
			this.plVeriPhone.Controls.Add(this.label9);
			this.plVeriPhone.Controls.Add(this.label10);
			this.plVeriPhone.Controls.Add(this.cbDvSim);
			this.plVeriPhone.Controls.Add(this.txtAPISim);
			this.plVeriPhone.Location = new global::System.Drawing.Point(57, 149);
			this.plVeriPhone.Name = "plVeriPhone";
			this.plVeriPhone.Size = new global::System.Drawing.Size(472, 78);
			this.plVeriPhone.TabIndex = 4;
			this.btnCheckSim.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCheckSim.Location = new global::System.Drawing.Point(362, 27);
			this.btnCheckSim.Name = "btnCheckSim";
			this.btnCheckSim.Size = new global::System.Drawing.Size(100, 45);
			this.btnCheckSim.TabIndex = 3;
			this.btnCheckSim.Text = "Kiểm tra";
			this.btnCheckSim.UseVisualStyleBackColor = true;
			this.btnCheckSim.Click += new global::System.EventHandler(this.btnCheckSim_Click);
			this.label9.AutoSize = true;
			this.label9.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label9.Location = new global::System.Drawing.Point(12, 9);
			this.label9.Name = "label9";
			this.label9.Size = new global::System.Drawing.Size(126, 18);
			this.label9.TabIndex = 0;
			this.label9.Text = "Chọn dịch vụ sim:";
			this.label10.AutoSize = true;
			this.label10.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label10.Location = new global::System.Drawing.Point(12, 43);
			this.label10.Name = "label10";
			this.label10.Size = new global::System.Drawing.Size(34, 18);
			this.label10.TabIndex = 0;
			this.label10.Text = "API:";
			this.cbDvSim.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDvSim.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbDvSim.FormattingEnabled = true;
			this.cbDvSim.Items.AddRange(new object[]
			{
				"chothuesimcode",
				"viotp",
				"codetextnow",
				"otpmmo"
			});
			this.cbDvSim.Location = new global::System.Drawing.Point(160, 5);
			this.cbDvSim.Name = "cbDvSim";
			this.cbDvSim.Size = new global::System.Drawing.Size(186, 26);
			this.cbDvSim.TabIndex = 2;
			this.txtAPISim.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtAPISim.Location = new global::System.Drawing.Point(68, 39);
			this.txtAPISim.Name = "txtAPISim";
			this.txtAPISim.Size = new global::System.Drawing.Size(278, 24);
			this.txtAPISim.TabIndex = 2;
			this.rdThuePhone.AutoSize = true;
			this.rdThuePhone.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdThuePhone.Location = new global::System.Drawing.Point(34, 124);
			this.rdThuePhone.Name = "rdThuePhone";
			this.rdThuePhone.Size = new global::System.Drawing.Size(150, 22);
			this.rdThuePhone.TabIndex = 1;
			this.rdThuePhone.Text = "Thuê số điện thoại";
			this.rdThuePhone.UseVisualStyleBackColor = true;
			this.rdThuePhone.CheckedChanged += new global::System.EventHandler(this.rdThuePhone_CheckedChanged);
			this.rdNoVeri.AutoSize = true;
			this.rdNoVeri.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdNoVeri.Location = new global::System.Drawing.Point(34, 15);
			this.rdNoVeri.Name = "rdNoVeri";
			this.rdNoVeri.Size = new global::System.Drawing.Size(135, 22);
			this.rdNoVeri.TabIndex = 1;
			this.rdNoVeri.Text = "Không xác minh";
			this.rdNoVeri.UseVisualStyleBackColor = true;
			this.rdNoVeri.CheckedChanged += new global::System.EventHandler(this.rdNoVeri_CheckedChanged);
			this.plVeriMail.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.plVeriMail.Controls.Add(this.plHotmailReg);
			this.plVeriMail.Controls.Add(this.btnNhapHotmail);
			this.plVeriMail.Controls.Add(this.rdHotMailReg);
			this.plVeriMail.Controls.Add(this.rdHotMailRegisted);
			this.plVeriMail.Location = new global::System.Drawing.Point(57, 255);
			this.plVeriMail.Name = "plVeriMail";
			this.plVeriMail.Size = new global::System.Drawing.Size(472, 227);
			this.plVeriMail.TabIndex = 2;
			this.plHotmailReg.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.plHotmailReg.Controls.Add(this.btnCheckAPIAny);
			this.plHotmailReg.Controls.Add(this.txtPassmail);
			this.plHotmailReg.Controls.Add(this.txtAPIAnyCat);
			this.plHotmailReg.Controls.Add(this.label22);
			this.plHotmailReg.Controls.Add(this.ckRdPassmail);
			this.plHotmailReg.Controls.Add(this.chkHideBrowser);
			this.plHotmailReg.Controls.Add(this.ckTaoMailBox);
			this.plHotmailReg.Controls.Add(this.label19);
			this.plHotmailReg.Location = new global::System.Drawing.Point(31, 29);
			this.plHotmailReg.Name = "plHotmailReg";
			this.plHotmailReg.Size = new global::System.Drawing.Size(434, 140);
			this.plHotmailReg.TabIndex = 4;
			this.btnCheckAPIAny.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCheckAPIAny.Location = new global::System.Drawing.Point(320, 2);
			this.btnCheckAPIAny.Name = "btnCheckAPIAny";
			this.btnCheckAPIAny.Size = new global::System.Drawing.Size(111, 45);
			this.btnCheckAPIAny.TabIndex = 3;
			this.btnCheckAPIAny.Text = "Kiểm tra";
			this.btnCheckAPIAny.UseVisualStyleBackColor = true;
			this.btnCheckAPIAny.Click += new global::System.EventHandler(this.btnCheckAPIAny_Click);
			this.txtPassmail.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtPassmail.Location = new global::System.Drawing.Point(145, 82);
			this.txtPassmail.Name = "txtPassmail";
			this.txtPassmail.Size = new global::System.Drawing.Size(151, 24);
			this.txtPassmail.TabIndex = 2;
			this.txtAPIAnyCat.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtAPIAnyCat.Location = new global::System.Drawing.Point(145, 12);
			this.txtAPIAnyCat.Name = "txtAPIAnyCat";
			this.txtAPIAnyCat.Size = new global::System.Drawing.Size(151, 24);
			this.txtAPIAnyCat.TabIndex = 2;
			this.label22.AutoSize = true;
			this.label22.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label22.Location = new global::System.Drawing.Point(4, 85);
			this.label22.Name = "label22";
			this.label22.Size = new global::System.Drawing.Size(104, 18);
			this.label22.TabIndex = 0;
			this.label22.Text = "Mật khẩu mail:";
			this.ckRdPassmail.AutoSize = true;
			this.ckRdPassmail.Location = new global::System.Drawing.Point(302, 84);
			this.ckRdPassmail.Name = "ckRdPassmail";
			this.ckRdPassmail.Size = new global::System.Drawing.Size(93, 22);
			this.ckRdPassmail.TabIndex = 3;
			this.ckRdPassmail.Text = "Random";
			this.ckRdPassmail.UseVisualStyleBackColor = true;
			this.ckRdPassmail.CheckedChanged += new global::System.EventHandler(this.ckRdPassmail_CheckedChanged);
			this.chkHideBrowser.AutoSize = true;
			this.chkHideBrowser.Location = new global::System.Drawing.Point(7, 112);
			this.chkHideBrowser.Name = "chkHideBrowser";
			this.chkHideBrowser.Size = new global::System.Drawing.Size(132, 22);
			this.chkHideBrowser.TabIndex = 3;
			this.chkHideBrowser.Text = "Ẩn trình duyệt";
			this.chkHideBrowser.UseVisualStyleBackColor = true;
			this.ckTaoMailBox.AutoSize = true;
			this.ckTaoMailBox.Location = new global::System.Drawing.Point(7, 48);
			this.ckTaoMailBox.Name = "ckTaoMailBox";
			this.ckTaoMailBox.Size = new global::System.Drawing.Size(338, 22);
			this.ckTaoMailBox.TabIndex = 3;
			this.ckTaoMailBox.Text = "Tự động tạo Mailbox (Hotmail + Outlook)";
			this.ckTaoMailBox.UseVisualStyleBackColor = true;
			this.label19.AutoSize = true;
			this.label19.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label19.Location = new global::System.Drawing.Point(4, 15);
			this.label19.Name = "label19";
			this.label19.Size = new global::System.Drawing.Size(114, 18);
			this.label19.TabIndex = 0;
			this.label19.Text = "API Anycaptcha:";
			this.btnNhapHotmail.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnNhapHotmail.Location = new global::System.Drawing.Point(187, 178);
			this.btnNhapHotmail.Name = "btnNhapHotmail";
			this.btnNhapHotmail.Size = new global::System.Drawing.Size(178, 37);
			this.btnNhapHotmail.TabIndex = 3;
			this.btnNhapHotmail.Text = "Nhập Hotmail";
			this.btnNhapHotmail.UseVisualStyleBackColor = true;
			this.btnNhapHotmail.Click += new global::System.EventHandler(this.btnNhapHotmail_Click);
			this.rdHotMailReg.AutoSize = true;
			this.rdHotMailReg.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdHotMailReg.Location = new global::System.Drawing.Point(10, 7);
			this.rdHotMailReg.Name = "rdHotMailReg";
			this.rdHotMailReg.Size = new global::System.Drawing.Size(198, 22);
			this.rdHotMailReg.TabIndex = 1;
			this.rdHotMailReg.TabStop = true;
			this.rdHotMailReg.Text = "Hotmail (tự động đăng ký)";
			this.rdHotMailReg.UseVisualStyleBackColor = true;
			this.rdHotMailReg.CheckedChanged += new global::System.EventHandler(this.rdHotMailReg_CheckedChanged);
			this.rdHotMailRegisted.AutoSize = true;
			this.rdHotMailRegisted.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdHotMailRegisted.Location = new global::System.Drawing.Point(10, 185);
			this.rdHotMailRegisted.Name = "rdHotMailRegisted";
			this.rdHotMailRegisted.Size = new global::System.Drawing.Size(155, 22);
			this.rdHotMailRegisted.TabIndex = 1;
			this.rdHotMailRegisted.TabStop = true;
			this.rdHotMailRegisted.Text = "Hotmail đã đăng ký";
			this.rdHotMailRegisted.UseVisualStyleBackColor = true;
			this.rdConfMail.AutoSize = true;
			this.rdConfMail.Checked = true;
			this.rdConfMail.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdConfMail.Location = new global::System.Drawing.Point(34, 230);
			this.rdConfMail.Name = "rdConfMail";
			this.rdConfMail.Size = new global::System.Drawing.Size(150, 22);
			this.rdConfMail.TabIndex = 1;
			this.rdConfMail.TabStop = true;
			this.rdConfMail.Text = "Xác minh qua mail";
			this.rdConfMail.UseVisualStyleBackColor = true;
			this.rdConfMail.CheckedChanged += new global::System.EventHandler(this.rdConfMail_CheckedChanged);
			this.groupBox8.Controls.Add(this.panel6);
			this.groupBox8.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox8.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.groupBox8.Location = new global::System.Drawing.Point(598, 806);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Size = new global::System.Drawing.Size(547, 150);
			this.groupBox8.TabIndex = 0;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Tương tác sau khi reg thành công";
			this.panel6.AutoScroll = true;
			this.panel6.Controls.Add(this.gbCamxuc);
			this.panel6.Controls.Add(this.plAddfriend);
			this.panel6.Controls.Add(this.chkInNewfeed);
			this.panel6.Controls.Add(this.chkWatch);
			this.panel6.Controls.Add(this.chkWStory);
			this.panel6.Controls.Add(this.chkAddFUID);
			this.panel6.Controls.Add(this.chkReadNotifi);
			this.panel6.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new global::System.Drawing.Point(3, 20);
			this.panel6.Name = "panel6";
			this.panel6.Size = new global::System.Drawing.Size(541, 127);
			this.panel6.TabIndex = 6;
			this.gbCamxuc.Controls.Add(this.chkGian);
			this.gbCamxuc.Controls.Add(this.chkBuon);
			this.gbCamxuc.Controls.Add(this.chkHaha);
			this.gbCamxuc.Controls.Add(this.chkTym);
			this.gbCamxuc.Controls.Add(this.chkLike);
			this.gbCamxuc.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.gbCamxuc.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.gbCamxuc.Location = new global::System.Drawing.Point(142, 71);
			this.gbCamxuc.Name = "gbCamxuc";
			this.gbCamxuc.Size = new global::System.Drawing.Size(351, 52);
			this.gbCamxuc.TabIndex = 12;
			this.gbCamxuc.TabStop = false;
			this.gbCamxuc.Text = "Cảm xúc";
			this.chkGian.AutoSize = true;
			this.chkGian.Location = new global::System.Drawing.Point(276, 22);
			this.chkGian.Name = "chkGian";
			this.chkGian.Size = new global::System.Drawing.Size(61, 22);
			this.chkGian.TabIndex = 3;
			this.chkGian.Text = "Giận";
			this.chkGian.UseVisualStyleBackColor = true;
			this.chkBuon.AutoSize = true;
			this.chkBuon.Location = new global::System.Drawing.Point(203, 22);
			this.chkBuon.Name = "chkBuon";
			this.chkBuon.Size = new global::System.Drawing.Size(65, 22);
			this.chkBuon.TabIndex = 3;
			this.chkBuon.Text = "Buồn";
			this.chkBuon.UseVisualStyleBackColor = true;
			this.chkHaha.AutoSize = true;
			this.chkHaha.Location = new global::System.Drawing.Point(135, 22);
			this.chkHaha.Name = "chkHaha";
			this.chkHaha.Size = new global::System.Drawing.Size(65, 22);
			this.chkHaha.TabIndex = 3;
			this.chkHaha.Text = "Haha";
			this.chkHaha.UseVisualStyleBackColor = true;
			this.chkTym.AutoSize = true;
			this.chkTym.Location = new global::System.Drawing.Point(72, 23);
			this.chkTym.Name = "chkTym";
			this.chkTym.Size = new global::System.Drawing.Size(59, 22);
			this.chkTym.TabIndex = 3;
			this.chkTym.Text = "Tym";
			this.chkTym.UseVisualStyleBackColor = true;
			this.chkLike.AutoSize = true;
			this.chkLike.Location = new global::System.Drawing.Point(12, 23);
			this.chkLike.Name = "chkLike";
			this.chkLike.Size = new global::System.Drawing.Size(57, 22);
			this.chkLike.TabIndex = 3;
			this.chkLike.Text = "Like";
			this.chkLike.UseVisualStyleBackColor = true;
			this.plAddfriend.Controls.Add(this.nFriendTo);
			this.plAddfriend.Controls.Add(this.label25);
			this.plAddfriend.Controls.Add(this.nFriendFrom);
			this.plAddfriend.Controls.Add(this.label26);
			this.plAddfriend.Controls.Add(this.label27);
			this.plAddfriend.Location = new global::System.Drawing.Point(217, 25);
			this.plAddfriend.Name = "plAddfriend";
			this.plAddfriend.Size = new global::System.Drawing.Size(300, 49);
			this.plAddfriend.TabIndex = 11;
			this.nFriendTo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nFriendTo.Location = new global::System.Drawing.Point(194, 9);
			this.nFriendTo.Name = "nFriendTo";
			this.nFriendTo.Size = new global::System.Drawing.Size(55, 24);
			this.nFriendTo.TabIndex = 1;
			this.label25.AutoSize = true;
			this.label25.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label25.Location = new global::System.Drawing.Point(8, 11);
			this.label25.Name = "label25";
			this.label25.Size = new global::System.Drawing.Size(71, 18);
			this.label25.TabIndex = 0;
			this.label25.Text = "Số lượng:";
			this.nFriendFrom.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nFriendFrom.Location = new global::System.Drawing.Point(88, 9);
			this.nFriendFrom.Name = "nFriendFrom";
			this.nFriendFrom.Size = new global::System.Drawing.Size(55, 24);
			this.nFriendFrom.TabIndex = 1;
			this.label26.AutoSize = true;
			this.label26.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label26.Location = new global::System.Drawing.Point(153, 11);
			this.label26.Name = "label26";
			this.label26.Size = new global::System.Drawing.Size(32, 18);
			this.label26.TabIndex = 0;
			this.label26.Text = "đến";
			this.label27.AutoSize = true;
			this.label27.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label27.Location = new global::System.Drawing.Point(258, 11);
			this.label27.Name = "label27";
			this.label27.Size = new global::System.Drawing.Size(32, 18);
			this.label27.TabIndex = 0;
			this.label27.Text = "bạn";
			this.chkInNewfeed.AutoSize = true;
			this.chkInNewfeed.Location = new global::System.Drawing.Point(16, 30);
			this.chkInNewfeed.Name = "chkInNewfeed";
			this.chkInNewfeed.Size = new global::System.Drawing.Size(175, 22);
			this.chkInNewfeed.TabIndex = 6;
			this.chkInNewfeed.Text = "Tương tác Newfeed";
			this.chkInNewfeed.UseVisualStyleBackColor = true;
			this.chkWatch.AutoSize = true;
			this.chkWatch.Location = new global::System.Drawing.Point(16, 59);
			this.chkWatch.Name = "chkWatch";
			this.chkWatch.Size = new global::System.Drawing.Size(117, 22);
			this.chkWatch.TabIndex = 7;
			this.chkWatch.Text = "Xem Watch";
			this.chkWatch.UseVisualStyleBackColor = true;
			this.chkWStory.AutoSize = true;
			this.chkWStory.Location = new global::System.Drawing.Point(16, 91);
			this.chkWStory.Name = "chkWStory";
			this.chkWStory.Size = new global::System.Drawing.Size(109, 22);
			this.chkWStory.TabIndex = 8;
			this.chkWStory.Text = "Xem Story";
			this.chkWStory.UseVisualStyleBackColor = true;
			this.chkWStory.CheckedChanged += new global::System.EventHandler(this.chkWStory_CheckedChanged);
			this.chkAddFUID.AutoSize = true;
			this.chkAddFUID.Location = new global::System.Drawing.Point(227, 3);
			this.chkAddFUID.Name = "chkAddFUID";
			this.chkAddFUID.Size = new global::System.Drawing.Size(128, 22);
			this.chkAddFUID.TabIndex = 9;
			this.chkAddFUID.Text = "Kết bạn gợi ý";
			this.chkAddFUID.UseVisualStyleBackColor = true;
			this.chkAddFUID.CheckedChanged += new global::System.EventHandler(this.chkAddFUID_CheckedChanged);
			this.chkReadNotifi.AutoSize = true;
			this.chkReadNotifi.Location = new global::System.Drawing.Point(16, 3);
			this.chkReadNotifi.Name = "chkReadNotifi";
			this.chkReadNotifi.Size = new global::System.Drawing.Size(141, 22);
			this.chkReadNotifi.TabIndex = 10;
			this.chkReadNotifi.Text = "Đọc thông báo";
			this.chkReadNotifi.UseVisualStyleBackColor = true;
			this.groupBox5.Controls.Add(this.panel5);
			this.groupBox5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox5.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.groupBox5.Location = new global::System.Drawing.Point(6, 359);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new global::System.Drawing.Size(585, 597);
			this.groupBox5.TabIndex = 0;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Cấu hình đổi IP";
			this.panel5.AutoScroll = true;
			this.panel5.Controls.Add(this.linkLabel2);
			this.panel5.Controls.Add(this.linkLabel1);
			this.panel5.Controls.Add(this.plCheckDoiIP);
			this.panel5.Controls.Add(this.pnlAPIMinProxy);
			this.panel5.Controls.Add(this.plChangeIPDcom);
			this.panel5.Controls.Add(this.plTinsoftProxy);
			this.panel5.Controls.Add(this.rdMinProxy);
			this.panel5.Controls.Add(this.rdTinsoftProxy);
			this.panel5.Controls.Add(this.rdHMA);
			this.panel5.Controls.Add(this.rdChangeIPDcom);
			this.panel5.Controls.Add(this.rdNoChangeIP);
			this.panel5.Location = new global::System.Drawing.Point(3, 20);
			this.panel5.Name = "panel5";
			this.panel5.Size = new global::System.Drawing.Size(579, 574);
			this.panel5.TabIndex = 7;
			this.linkLabel2.AutoSize = true;
			this.linkLabel2.Location = new global::System.Drawing.Point(167, 288);
			this.linkLabel2.Name = "linkLabel2";
			this.linkLabel2.Size = new global::System.Drawing.Size(155, 18);
			this.linkLabel2.TabIndex = 156;
			this.linkLabel2.TabStop = true;
			this.linkLabel2.Text = "https://minproxy.vn/";
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new global::System.Drawing.Point(167, 169);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new global::System.Drawing.Size(191, 18);
			this.linkLabel1.TabIndex = 156;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "https://tinsoftproxy.com/";
			this.plCheckDoiIP.Controls.Add(this.btnTestChangeIP);
			this.plCheckDoiIP.Controls.Add(this.numChangeIP);
			this.plCheckDoiIP.Controls.Add(this.label20);
			this.plCheckDoiIP.Controls.Add(this.label21);
			this.plCheckDoiIP.Location = new global::System.Drawing.Point(34, 8);
			this.plCheckDoiIP.Name = "plCheckDoiIP";
			this.plCheckDoiIP.Size = new global::System.Drawing.Size(324, 36);
			this.plCheckDoiIP.TabIndex = 155;
			this.btnTestChangeIP.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnTestChangeIP.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 163);
			this.btnTestChangeIP.ForeColor = global::System.Drawing.Color.Black;
			this.btnTestChangeIP.Location = new global::System.Drawing.Point(221, 0);
			this.btnTestChangeIP.Margin = new global::System.Windows.Forms.Padding(4);
			this.btnTestChangeIP.Name = "btnTestChangeIP";
			this.btnTestChangeIP.Size = new global::System.Drawing.Size(103, 35);
			this.btnTestChangeIP.TabIndex = 156;
			this.btnTestChangeIP.Text = "Test";
			this.btnTestChangeIP.UseVisualStyleBackColor = true;
			this.btnTestChangeIP.Click += new global::System.EventHandler(this.btnTestChangeIP_Click);
			this.numChangeIP.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numChangeIP.Location = new global::System.Drawing.Point(93, 7);
			this.numChangeIP.Name = "numChangeIP";
			this.numChangeIP.Size = new global::System.Drawing.Size(55, 24);
			this.numChangeIP.TabIndex = 8;
			this.label20.AutoSize = true;
			this.label20.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label20.Location = new global::System.Drawing.Point(2, 10);
			this.label20.Name = "label20";
			this.label20.Size = new global::System.Drawing.Size(80, 18);
			this.label20.TabIndex = 7;
			this.label20.Text = "Đổi IP sau:";
			this.label21.AutoSize = true;
			this.label21.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label21.Location = new global::System.Drawing.Point(152, 9);
			this.label21.Name = "label21";
			this.label21.Size = new global::System.Drawing.Size(52, 18);
			this.label21.TabIndex = 6;
			this.label21.Text = "lần reg";
			this.pnlAPIMinProxy.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlAPIMinProxy.Controls.Add(this.btnCheckAPIMinProxy);
			this.pnlAPIMinProxy.Controls.Add(this.txtApiKeyMinProxy);
			this.pnlAPIMinProxy.Controls.Add(this.label49);
			this.pnlAPIMinProxy.Controls.Add(this.label50);
			this.pnlAPIMinProxy.Controls.Add(this.nudLuongPerIPMinProxy);
			this.pnlAPIMinProxy.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 163);
			this.pnlAPIMinProxy.Location = new global::System.Drawing.Point(48, 312);
			this.pnlAPIMinProxy.Margin = new global::System.Windows.Forms.Padding(4);
			this.pnlAPIMinProxy.Name = "pnlAPIMinProxy";
			this.pnlAPIMinProxy.Size = new global::System.Drawing.Size(351, 226);
			this.pnlAPIMinProxy.TabIndex = 154;
			this.btnCheckAPIMinProxy.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnCheckAPIMinProxy.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 163);
			this.btnCheckAPIMinProxy.ForeColor = global::System.Drawing.Color.Black;
			this.btnCheckAPIMinProxy.Location = new global::System.Drawing.Point(212, 181);
			this.btnCheckAPIMinProxy.Margin = new global::System.Windows.Forms.Padding(4);
			this.btnCheckAPIMinProxy.Name = "btnCheckAPIMinProxy";
			this.btnCheckAPIMinProxy.Size = new global::System.Drawing.Size(69, 33);
			this.btnCheckAPIMinProxy.TabIndex = 145;
			this.btnCheckAPIMinProxy.Text = "Check";
			this.btnCheckAPIMinProxy.UseVisualStyleBackColor = true;
			this.btnCheckAPIMinProxy.Click += new global::System.EventHandler(this.btnCheckAPIMinProxy_Click);
			this.txtApiKeyMinProxy.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtApiKeyMinProxy.Location = new global::System.Drawing.Point(8, 28);
			this.txtApiKeyMinProxy.Margin = new global::System.Windows.Forms.Padding(4);
			this.txtApiKeyMinProxy.Name = "txtApiKeyMinProxy";
			this.txtApiKeyMinProxy.Size = new global::System.Drawing.Size(336, 144);
			this.txtApiKeyMinProxy.TabIndex = 144;
			this.txtApiKeyMinProxy.Text = "";
			this.txtApiKeyMinProxy.WordWrap = false;
			this.label49.AutoSize = true;
			this.label49.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 163);
			this.label49.Location = new global::System.Drawing.Point(4, 2);
			this.label49.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label49.Name = "label49";
			this.label49.Size = new global::System.Drawing.Size(148, 21);
			this.label49.TabIndex = 79;
			this.label49.Text = "Nhập API KEY (0):";
			this.label50.AutoSize = true;
			this.label50.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 163);
			this.label50.Location = new global::System.Drawing.Point(4, 185);
			this.label50.Margin = new global::System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label50.Name = "label50";
			this.label50.Size = new global::System.Drawing.Size(101, 21);
			this.label50.TabIndex = 139;
			this.label50.Text = "Số luồng/IP:";
			this.nudLuongPerIPMinProxy.Font = new global::System.Drawing.Font("Tahoma", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 163);
			this.nudLuongPerIPMinProxy.Location = new global::System.Drawing.Point(117, 183);
			this.nudLuongPerIPMinProxy.Margin = new global::System.Windows.Forms.Padding(4);
			this.nudLuongPerIPMinProxy.Name = "nudLuongPerIPMinProxy";
			this.nudLuongPerIPMinProxy.Size = new global::System.Drawing.Size(89, 27);
			this.nudLuongPerIPMinProxy.TabIndex = 140;
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.nudLuongPerIPMinProxy;
			int[] array = new int[4];
			array[0] = 1;
			numericUpDown.Value = new decimal(array);
			this.plChangeIPDcom.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.plChangeIPDcom.Controls.Add(this.btnGetDcom);
			this.plChangeIPDcom.Controls.Add(this.txtNameDcom);
			this.plChangeIPDcom.Location = new global::System.Drawing.Point(53, 108);
			this.plChangeIPDcom.Name = "plChangeIPDcom";
			this.plChangeIPDcom.Size = new global::System.Drawing.Size(346, 54);
			this.plChangeIPDcom.TabIndex = 13;
			this.btnGetDcom.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnGetDcom.Location = new global::System.Drawing.Point(172, 3);
			this.btnGetDcom.Name = "btnGetDcom";
			this.btnGetDcom.Size = new global::System.Drawing.Size(164, 45);
			this.btnGetDcom.TabIndex = 3;
			this.btnGetDcom.Text = "Lấy tên Dcom";
			this.btnGetDcom.UseVisualStyleBackColor = true;
			this.btnGetDcom.Click += new global::System.EventHandler(this.btnGetDcom_Click);
			this.txtNameDcom.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtNameDcom.Location = new global::System.Drawing.Point(8, 14);
			this.txtNameDcom.Name = "txtNameDcom";
			this.txtNameDcom.Size = new global::System.Drawing.Size(149, 24);
			this.txtNameDcom.TabIndex = 2;
			this.plTinsoftProxy.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.plTinsoftProxy.Controls.Add(this.nudLuongPerIPTinsoft);
			this.plTinsoftProxy.Controls.Add(this.btnCheckProxy);
			this.plTinsoftProxy.Controls.Add(this.label16);
			this.plTinsoftProxy.Controls.Add(this.label29);
			this.plTinsoftProxy.Controls.Add(this.label15);
			this.plTinsoftProxy.Controls.Add(this.txtProxy);
			this.plTinsoftProxy.Controls.Add(this.cbLocationProxy);
			this.plTinsoftProxy.Location = new global::System.Drawing.Point(53, 195);
			this.plTinsoftProxy.Name = "plTinsoftProxy";
			this.plTinsoftProxy.Size = new global::System.Drawing.Size(488, 85);
			this.plTinsoftProxy.TabIndex = 12;
			this.nudLuongPerIPTinsoft.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.nudLuongPerIPTinsoft.Location = new global::System.Drawing.Point(285, 46);
			this.nudLuongPerIPTinsoft.Name = "nudLuongPerIPTinsoft";
			this.nudLuongPerIPTinsoft.Size = new global::System.Drawing.Size(55, 24);
			this.nudLuongPerIPTinsoft.TabIndex = 1;
			this.btnCheckProxy.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnCheckProxy.Location = new global::System.Drawing.Point(272, 5);
			this.btnCheckProxy.Name = "btnCheckProxy";
			this.btnCheckProxy.Size = new global::System.Drawing.Size(101, 34);
			this.btnCheckProxy.TabIndex = 3;
			this.btnCheckProxy.Text = "Check";
			this.btnCheckProxy.UseVisualStyleBackColor = true;
			this.btnCheckProxy.Click += new global::System.EventHandler(this.btnCheckProxy_Click);
			this.label16.AutoSize = true;
			this.label16.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label16.Location = new global::System.Drawing.Point(176, 49);
			this.label16.Name = "label16";
			this.label16.Size = new global::System.Drawing.Size(88, 18);
			this.label16.TabIndex = 0;
			this.label16.Text = "Số luồng/IP:";
			this.label29.AutoSize = true;
			this.label29.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label29.Location = new global::System.Drawing.Point(5, 13);
			this.label29.Name = "label29";
			this.label29.Size = new global::System.Drawing.Size(94, 18);
			this.label29.TabIndex = 6;
			this.label29.Text = "API key user:";
			this.label15.AutoSize = true;
			this.label15.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label15.Location = new global::System.Drawing.Point(5, 49);
			this.label15.Name = "label15";
			this.label15.Size = new global::System.Drawing.Size(40, 18);
			this.label15.TabIndex = 0;
			this.label15.Text = "Vị trí:";
			this.txtProxy.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtProxy.Location = new global::System.Drawing.Point(108, 10);
			this.txtProxy.Name = "txtProxy";
			this.txtProxy.Size = new global::System.Drawing.Size(149, 24);
			this.txtProxy.TabIndex = 2;
			this.cbLocationProxy.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbLocationProxy.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.cbLocationProxy.FormattingEnabled = true;
			this.cbLocationProxy.Location = new global::System.Drawing.Point(50, 46);
			this.cbLocationProxy.Name = "cbLocationProxy";
			this.cbLocationProxy.Size = new global::System.Drawing.Size(110, 26);
			this.cbLocationProxy.TabIndex = 2;
			this.rdMinProxy.AutoSize = true;
			this.rdMinProxy.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdMinProxy.Location = new global::System.Drawing.Point(36, 286);
			this.rdMinProxy.Name = "rdMinProxy";
			this.rdMinProxy.Size = new global::System.Drawing.Size(114, 22);
			this.rdMinProxy.TabIndex = 9;
			this.rdMinProxy.TabStop = true;
			this.rdMinProxy.Text = "MinProxy.vn:";
			this.rdMinProxy.UseVisualStyleBackColor = true;
			this.rdMinProxy.CheckedChanged += new global::System.EventHandler(this.rdMinProxy_CheckedChanged);
			this.rdTinsoftProxy.AutoSize = true;
			this.rdTinsoftProxy.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdTinsoftProxy.Location = new global::System.Drawing.Point(36, 167);
			this.rdTinsoftProxy.Name = "rdTinsoftProxy";
			this.rdTinsoftProxy.Size = new global::System.Drawing.Size(120, 22);
			this.rdTinsoftProxy.TabIndex = 9;
			this.rdTinsoftProxy.TabStop = true;
			this.rdTinsoftProxy.Text = "Proxy Tinsoft:";
			this.rdTinsoftProxy.UseVisualStyleBackColor = true;
			this.rdTinsoftProxy.CheckedChanged += new global::System.EventHandler(this.rdProxy_CheckedChanged);
			this.rdHMA.AutoSize = true;
			this.rdHMA.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdHMA.Location = new global::System.Drawing.Point(423, 84);
			this.rdHMA.Name = "rdHMA";
			this.rdHMA.Size = new global::System.Drawing.Size(106, 22);
			this.rdHMA.TabIndex = 10;
			this.rdHMA.TabStop = true;
			this.rdHMA.Text = "Đổi IP HMA";
			this.rdHMA.UseVisualStyleBackColor = true;
			this.rdHMA.CheckedChanged += new global::System.EventHandler(this.rdHMA_CheckedChanged);
			this.rdChangeIPDcom.AutoSize = true;
			this.rdChangeIPDcom.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdChangeIPDcom.Location = new global::System.Drawing.Point(36, 84);
			this.rdChangeIPDcom.Name = "rdChangeIPDcom";
			this.rdChangeIPDcom.Size = new global::System.Drawing.Size(118, 22);
			this.rdChangeIPDcom.TabIndex = 10;
			this.rdChangeIPDcom.TabStop = true;
			this.rdChangeIPDcom.Text = "Đổi IP Dcom:";
			this.rdChangeIPDcom.UseVisualStyleBackColor = true;
			this.rdChangeIPDcom.CheckedChanged += new global::System.EventHandler(this.rdChangeIPDcom_CheckedChanged_1);
			this.rdNoChangeIP.AutoSize = true;
			this.rdNoChangeIP.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdNoChangeIP.Location = new global::System.Drawing.Point(36, 50);
			this.rdNoChangeIP.Name = "rdNoChangeIP";
			this.rdNoChangeIP.Size = new global::System.Drawing.Size(113, 22);
			this.rdNoChangeIP.TabIndex = 11;
			this.rdNoChangeIP.TabStop = true;
			this.rdNoChangeIP.Text = "Không đổi IP";
			this.rdNoChangeIP.UseVisualStyleBackColor = true;
			this.rdNoChangeIP.Click += new global::System.EventHandler(this.rdNoChangeIP_CheckedChanged);
			this.groupBox4.Controls.Add(this.panel1);
			this.groupBox4.Controls.Add(this.txtLinkLD);
			this.groupBox4.Controls.Add(this.numDeClsTo);
			this.groupBox4.Controls.Add(this.numDeClsFr);
			this.groupBox4.Controls.Add(this.label7);
			this.groupBox4.Controls.Add(this.rdNormal);
			this.groupBox4.Controls.Add(this.label8);
			this.groupBox4.Controls.Add(this.label6);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox4.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.groupBox4.Location = new global::System.Drawing.Point(7, 165);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new global::System.Drawing.Size(585, 188);
			this.groupBox4.TabIndex = 0;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Cấu hình LDPlayer";
			this.panel1.Controls.Add(this.numDelayTo);
			this.panel1.Controls.Add(this.rdDelayLD);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.numDelayFr);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Location = new global::System.Drawing.Point(36, 56);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(543, 33);
			this.panel1.TabIndex = 3;
			this.numDelayTo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numDelayTo.Location = new global::System.Drawing.Point(411, 6);
			this.numDelayTo.Name = "numDelayTo";
			this.numDelayTo.Size = new global::System.Drawing.Size(55, 24);
			this.numDelayTo.TabIndex = 1;
			this.rdDelayLD.AutoSize = true;
			this.rdDelayLD.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdDelayLD.Location = new global::System.Drawing.Point(188, 6);
			this.rdDelayLD.Name = "rdDelayLD";
			this.rdDelayLD.Size = new global::System.Drawing.Size(96, 22);
			this.rdDelayLD.TabIndex = 1;
			this.rdDelayLD.TabStop = true;
			this.rdDelayLD.Text = "Delay mở:";
			this.rdDelayLD.UseVisualStyleBackColor = true;
			this.label4.AutoSize = true;
			this.label4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label4.Location = new global::System.Drawing.Point(2, 9);
			this.label4.Name = "label4";
			this.label4.Size = new global::System.Drawing.Size(98, 18);
			this.label4.TabIndex = 0;
			this.label4.Text = "Mở LDPlayer:";
			this.numDelayFr.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numDelayFr.Location = new global::System.Drawing.Point(307, 6);
			this.numDelayFr.Name = "numDelayFr";
			this.numDelayFr.Size = new global::System.Drawing.Size(55, 24);
			this.numDelayFr.TabIndex = 1;
			this.label5.AutoSize = true;
			this.label5.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label5.Location = new global::System.Drawing.Point(370, 9);
			this.label5.Name = "label5";
			this.label5.Size = new global::System.Drawing.Size(32, 18);
			this.label5.TabIndex = 0;
			this.label5.Text = "đến";
			this.txtLinkLD.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtLinkLD.Location = new global::System.Drawing.Point(223, 139);
			this.txtLinkLD.Name = "txtLinkLD";
			this.txtLinkLD.Size = new global::System.Drawing.Size(320, 24);
			this.txtLinkLD.TabIndex = 2;
			this.numDeClsTo.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numDeClsTo.Location = new global::System.Drawing.Point(341, 102);
			this.numDeClsTo.Name = "numDeClsTo";
			this.numDeClsTo.Size = new global::System.Drawing.Size(55, 24);
			this.numDeClsTo.TabIndex = 1;
			this.numDeClsFr.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.numDeClsFr.Location = new global::System.Drawing.Point(224, 103);
			this.numDeClsFr.Name = "numDeClsFr";
			this.numDeClsFr.Size = new global::System.Drawing.Size(55, 24);
			this.numDeClsFr.TabIndex = 1;
			this.label7.AutoSize = true;
			this.label7.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label7.Location = new global::System.Drawing.Point(294, 105);
			this.label7.Name = "label7";
			this.label7.Size = new global::System.Drawing.Size(32, 18);
			this.label7.TabIndex = 0;
			this.label7.Text = "đến";
			this.rdNormal.AutoSize = true;
			this.rdNormal.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.rdNormal.Location = new global::System.Drawing.Point(224, 29);
			this.rdNormal.Name = "rdNormal";
			this.rdNormal.Size = new global::System.Drawing.Size(241, 22);
			this.rdNormal.TabIndex = 1;
			this.rdNormal.TabStop = true;
			this.rdNormal.Text = "Thường (1 tài khoản/1 LDPlayer)";
			this.rdNormal.UseVisualStyleBackColor = true;
			this.label8.AutoSize = true;
			this.label8.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label8.Location = new global::System.Drawing.Point(37, 143);
			this.label8.Name = "label8";
			this.label8.Size = new global::System.Drawing.Size(148, 18);
			this.label8.TabIndex = 0;
			this.label8.Text = "Đường dẫn LDPlayer:";
			this.label6.AutoSize = true;
			this.label6.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label6.Location = new global::System.Drawing.Point(37, 105);
			this.label6.Name = "label6";
			this.label6.Size = new global::System.Drawing.Size(150, 18);
			this.label6.TabIndex = 0;
			this.label6.Text = "Delay đóng LDPlayer:";
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.Location = new global::System.Drawing.Point(37, 30);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(159, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Chế độ chạy LDPlayer:";
			this.groupBox3.Controls.Add(this.numOTP);
			this.groupBox3.Controls.Add(this.nudSoLuotChay);
			this.groupBox3.Controls.Add(this.numThrLdPlay);
			this.groupBox3.Controls.Add(this.label24);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.button1);
			this.groupBox3.Controls.Add(this.label23);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.groupBox3.ForeColor = global::System.Drawing.Color.FromArgb(24, 30, 54);
			this.groupBox3.Location = new global::System.Drawing.Point(7, 22);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new global::System.Drawing.Size(585, 139);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Cấu hình chung";
			this.numOTP.Location = new global::System.Drawing.Point(228, 88);
			this.numOTP.Name = "numOTP";
			this.numOTP.Size = new global::System.Drawing.Size(77, 24);
			this.numOTP.TabIndex = 1;
			this.nudSoLuotChay.Location = new global::System.Drawing.Point(228, 28);
			this.nudSoLuotChay.Name = "nudSoLuotChay";
			this.nudSoLuotChay.Size = new global::System.Drawing.Size(77, 24);
			this.nudSoLuotChay.TabIndex = 1;
			this.numThrLdPlay.Location = new global::System.Drawing.Point(228, 58);
			this.numThrLdPlay.Name = "numThrLdPlay";
			this.numThrLdPlay.Size = new global::System.Drawing.Size(77, 24);
			this.numThrLdPlay.TabIndex = 1;
			this.label24.AutoSize = true;
			this.label24.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label24.Location = new global::System.Drawing.Point(311, 34);
			this.label24.Name = "label24";
			this.label24.Size = new global::System.Drawing.Size(27, 18);
			this.label24.TabIndex = 0;
			this.label24.Text = "lần";
			this.label11.AutoSize = true;
			this.label11.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label11.Location = new global::System.Drawing.Point(311, 90);
			this.label11.Name = "label11";
			this.label11.Size = new global::System.Drawing.Size(34, 18);
			this.label11.TabIndex = 0;
			this.label11.Text = "giây";
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.FromArgb(37, 189, 6);
			this.button1.Image = global::ToolRegFB.Properties.Resources.icons8_start_25__1_;
			this.button1.Location = new global::System.Drawing.Point(-943, -131);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(140, 61);
			this.button1.TabIndex = 2;
			this.button1.Text = "Bắt đầu";
			this.button1.TextImageRelation = global::System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.button1.UseVisualStyleBackColor = true;
			this.label23.AutoSize = true;
			this.label23.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label23.Location = new global::System.Drawing.Point(33, 34);
			this.label23.Name = "label23";
			this.label23.Size = new global::System.Drawing.Size(79, 18);
			this.label23.TabIndex = 0;
			this.label23.Text = "Số lần reg:";
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.Location = new global::System.Drawing.Point(34, 94);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(143, 18);
			this.label2.TabIndex = 0;
			this.label2.Text = "Thời gian nhập OTP:";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.Location = new global::System.Drawing.Point(34, 64);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(170, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Số luồng chạy LDPlayer:";
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
			this.bunifuFormDock1.TitleBarOptions.TitleBarControl = this.pnlContainer;
			this.bunifuFormDock1.TitleBarOptions.UseBackColorOnDockingIndicators = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.SystemColors.Control;
			base.ClientSize = new global::System.Drawing.Size(1924, 1055);
			base.Controls.Add(this.pnlContainer);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.statusStrip1);
			this.ForeColor = global::System.Drawing.Color.White;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmMain";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Auto Register Facebook On LDPlayer";
			base.WindowState = global::System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			base.Load += new global::System.EventHandler(this.frmMain_Load);
			base.Paint += new global::System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
			this.contextMenuStrip1.ResumeLayout(false);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.pnlContainer.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.dgvAcc).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.plNovery.ResumeLayout(false);
			this.plNovery.PerformLayout();
			this.plVeriPhone.ResumeLayout(false);
			this.plVeriPhone.PerformLayout();
			this.plVeriMail.ResumeLayout(false);
			this.plVeriMail.PerformLayout();
			this.plHotmailReg.ResumeLayout(false);
			this.plHotmailReg.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel6.PerformLayout();
			this.gbCamxuc.ResumeLayout(false);
			this.gbCamxuc.PerformLayout();
			this.plAddfriend.ResumeLayout(false);
			this.plAddfriend.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nFriendTo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nFriendFrom).EndInit();
			this.groupBox5.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel5.PerformLayout();
			this.plCheckDoiIP.ResumeLayout(false);
			this.plCheckDoiIP.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numChangeIP).EndInit();
			this.pnlAPIMinProxy.ResumeLayout(false);
			this.pnlAPIMinProxy.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nudLuongPerIPMinProxy).EndInit();
			this.plChangeIPDcom.ResumeLayout(false);
			this.plChangeIPDcom.PerformLayout();
			this.plTinsoftProxy.ResumeLayout(false);
			this.plTinsoftProxy.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.nudLuongPerIPTinsoft).EndInit();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numDelayTo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numDelayFr).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numDeClsTo).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numDeClsFr).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numOTP).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.nudSoLuotChay).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numThrLdPlay).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040001C9 RID: 457
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040001CA RID: 458
		private global::System.Windows.Forms.StatusStrip statusStrip1;

		// Token: 0x040001CB RID: 459
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;

		// Token: 0x040001CC RID: 460
		private global::System.Windows.Forms.ToolStripStatusLabel stTotalSuccess;

		// Token: 0x040001CD RID: 461
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;

		// Token: 0x040001CE RID: 462
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;

		// Token: 0x040001CF RID: 463
		private global::System.Windows.Forms.ToolStripStatusLabel stTotalFail;

		// Token: 0x040001D0 RID: 464
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;

		// Token: 0x040001D1 RID: 465
		private global::System.Windows.Forms.ToolStripStatusLabel stIPCur;

		// Token: 0x040001D2 RID: 466
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;

		// Token: 0x040001D3 RID: 467
		private global::System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		// Token: 0x040001D4 RID: 468
		private global::System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;

		// Token: 0x040001D5 RID: 469
		private global::System.Windows.Forms.ToolStripMenuItem uidPassToolStripMenuItem;

		// Token: 0x040001D6 RID: 470
		private global::System.Windows.Forms.ToolStripMenuItem uidPassTokenCookieToolStripMenuItem;

		// Token: 0x040001D7 RID: 471
		private global::System.Windows.Forms.ToolStripMenuItem chọnToolStripMenuItem;

		// Token: 0x040001D8 RID: 472
		private global::System.Windows.Forms.ToolStripMenuItem tấtCảToolStripMenuItem;

		// Token: 0x040001D9 RID: 473
		private global::System.Windows.Forms.ToolStripMenuItem bôiĐenToolStripMenuItem;

		// Token: 0x040001DA RID: 474
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;

		// Token: 0x040001DB RID: 475
		private global::System.Windows.Forms.ToolStripStatusLabel lblCountSelect;

		// Token: 0x040001DC RID: 476
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;

		// Token: 0x040001DD RID: 477
		private global::System.Windows.Forms.ToolStripMenuItem bỏChọnTấtCảToolStripMenuItem;

		// Token: 0x040001DE RID: 478
		private global::System.Windows.Forms.ToolStripMenuItem trạngTháiToolStripMenuItem;

		// Token: 0x040001DF RID: 479
		private global::System.Windows.Forms.ToolStripMenuItem uidPass2FAToolStripMenuItem;

		// Token: 0x040001E0 RID: 480
		private global::System.Windows.Forms.ToolStripMenuItem liveToolStripMenuItem;

		// Token: 0x040001E1 RID: 481
		private global::System.Windows.Forms.ToolStripMenuItem dieToolStripMenuItem;

		// Token: 0x040001E2 RID: 482
		private global::System.Windows.Forms.ToolStripMenuItem checkpointToolStripMenuItem;

		// Token: 0x040001E3 RID: 483
		private global::System.Windows.Forms.ToolStripMenuItem mailPassMailToolStripMenuItem;

		// Token: 0x040001E4 RID: 484
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;

		// Token: 0x040001E5 RID: 485
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;

		// Token: 0x040001E6 RID: 486
		private global::System.Windows.Forms.ToolStripStatusLabel plTrangThai;

		// Token: 0x040001E7 RID: 487
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;

		// Token: 0x040001E8 RID: 488
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x040001E9 RID: 489
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x040001EA RID: 490
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040001EB RID: 491
		private global::System.Windows.Forms.Button btnMinimized;

		// Token: 0x040001EC RID: 492
		private global::System.Windows.Forms.Label label28;

		// Token: 0x040001ED RID: 493
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040001EE RID: 494
		private global::System.Windows.Forms.Timer timer2;

		// Token: 0x040001EF RID: 495
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel14;

		// Token: 0x040001F0 RID: 496
		private global::System.Windows.Forms.ToolStripStatusLabel lblTimeExpired;

		// Token: 0x040001F1 RID: 497
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel15;

		// Token: 0x040001F2 RID: 498
		private global::System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel16;

		// Token: 0x040001F3 RID: 499
		private global::System.Windows.Forms.ToolStripStatusLabel lblMachineName;

		// Token: 0x040001F4 RID: 500
		private global::System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;

		// Token: 0x040001F5 RID: 501
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;

		// Token: 0x040001F6 RID: 502
		private global::Bunifu.UI.WinForms.BunifuPanel pnlContainer;

		// Token: 0x040001F7 RID: 503
		private global::System.Windows.Forms.Button btnAutoConfig;

		// Token: 0x040001F8 RID: 504
		private global::System.Windows.Forms.Button btnSaveConf;

		// Token: 0x040001F9 RID: 505
		private global::System.Windows.Forms.Button btnStop;

		// Token: 0x040001FA RID: 506
		private global::System.Windows.Forms.Button btnReg;

		// Token: 0x040001FB RID: 507
		private global::System.Windows.Forms.GroupBox groupBox2;

		// Token: 0x040001FC RID: 508
		private global::System.Windows.Forms.DataGridView dgvAcc;

		// Token: 0x040001FD RID: 509
		private global::System.Windows.Forms.DataGridViewCheckBoxColumn cChose;

		// Token: 0x040001FE RID: 510
		private global::System.Windows.Forms.DataGridViewTextBoxColumn cId;

		// Token: 0x040001FF RID: 511
		private global::System.Windows.Forms.DataGridViewTextBoxColumn status;

		// Token: 0x04000200 RID: 512
		private global::System.Windows.Forms.DataGridViewTextBoxColumn uid;

		// Token: 0x04000201 RID: 513
		private global::System.Windows.Forms.DataGridViewTextBoxColumn pass;

		// Token: 0x04000202 RID: 514
		private global::System.Windows.Forms.DataGridViewTextBoxColumn ho;

		// Token: 0x04000203 RID: 515
		private global::System.Windows.Forms.DataGridViewTextBoxColumn ten;

		// Token: 0x04000204 RID: 516
		private global::System.Windows.Forms.DataGridViewTextBoxColumn gender;

		// Token: 0x04000205 RID: 517
		private global::System.Windows.Forms.DataGridViewTextBoxColumn conf_2fa;

		// Token: 0x04000206 RID: 518
		private global::System.Windows.Forms.DataGridViewTextBoxColumn token;

		// Token: 0x04000207 RID: 519
		private global::System.Windows.Forms.DataGridViewTextBoxColumn cookie;

		// Token: 0x04000208 RID: 520
		private global::System.Windows.Forms.DataGridViewTextBoxColumn email;

		// Token: 0x04000209 RID: 521
		private global::System.Windows.Forms.DataGridViewTextBoxColumn passMail;

		// Token: 0x0400020A RID: 522
		private global::System.Windows.Forms.DataGridViewTextBoxColumn phone;

		// Token: 0x0400020B RID: 523
		private global::System.Windows.Forms.DataGridViewTextBoxColumn proxy;

		// Token: 0x0400020C RID: 524
		private global::System.Windows.Forms.DataGridViewTextBoxColumn cInfo;

		// Token: 0x0400020D RID: 525
		private global::System.Windows.Forms.DataGridViewTextBoxColumn cDevice;

		// Token: 0x0400020E RID: 526
		private global::System.Windows.Forms.GroupBox groupBox1;

		// Token: 0x0400020F RID: 527
		private global::System.Windows.Forms.GroupBox groupBox7;

		// Token: 0x04000210 RID: 528
		private global::System.Windows.Forms.TextBox txtLinkAvartar;

		// Token: 0x04000211 RID: 529
		private global::System.Windows.Forms.Button btnNhapanh;

		// Token: 0x04000212 RID: 530
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x04000213 RID: 531
		private global::System.Windows.Forms.RadioButton rbRandomMF;

		// Token: 0x04000214 RID: 532
		private global::System.Windows.Forms.RadioButton rbFemale;

		// Token: 0x04000215 RID: 533
		private global::System.Windows.Forms.RadioButton rbMale;

		// Token: 0x04000216 RID: 534
		private global::System.Windows.Forms.CheckBox chkCoverImg;

		// Token: 0x04000217 RID: 535
		private global::System.Windows.Forms.CheckBox chkAvartar;

		// Token: 0x04000218 RID: 536
		private global::System.Windows.Forms.CheckBox chk2FA;

		// Token: 0x04000219 RID: 537
		private global::System.Windows.Forms.CheckBox chkRandomPass;

		// Token: 0x0400021A RID: 538
		private global::System.Windows.Forms.Label label14;

		// Token: 0x0400021B RID: 539
		private global::System.Windows.Forms.Label label13;

		// Token: 0x0400021C RID: 540
		private global::System.Windows.Forms.TextBox txtPassFb;

		// Token: 0x0400021D RID: 541
		private global::System.Windows.Forms.Label label12;

		// Token: 0x0400021E RID: 542
		private global::System.Windows.Forms.ComboBox cbNameReg;

		// Token: 0x0400021F RID: 543
		private global::System.Windows.Forms.GroupBox groupBox6;

		// Token: 0x04000220 RID: 544
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000221 RID: 545
		private global::System.Windows.Forms.Panel plNovery;

		// Token: 0x04000222 RID: 546
		private global::System.Windows.Forms.RadioButton rdNoveriMail;

		// Token: 0x04000223 RID: 547
		private global::System.Windows.Forms.RadioButton rdNovriPhone;

		// Token: 0x04000224 RID: 548
		private global::System.Windows.Forms.Label label18;

		// Token: 0x04000225 RID: 549
		private global::System.Windows.Forms.Label label17;

		// Token: 0x04000226 RID: 550
		private global::System.Windows.Forms.ComboBox cbMailAo;

		// Token: 0x04000227 RID: 551
		private global::System.Windows.Forms.ComboBox cbbPhoneCountry;

		// Token: 0x04000228 RID: 552
		private global::System.Windows.Forms.Panel plVeriPhone;

		// Token: 0x04000229 RID: 553
		private global::System.Windows.Forms.Button btnCheckSim;

		// Token: 0x0400022A RID: 554
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400022B RID: 555
		private global::System.Windows.Forms.Label label10;

		// Token: 0x0400022C RID: 556
		private global::System.Windows.Forms.ComboBox cbDvSim;

		// Token: 0x0400022D RID: 557
		private global::System.Windows.Forms.TextBox txtAPISim;

		// Token: 0x0400022E RID: 558
		private global::System.Windows.Forms.RadioButton rdThuePhone;

		// Token: 0x0400022F RID: 559
		private global::System.Windows.Forms.RadioButton rdNoVeri;

		// Token: 0x04000230 RID: 560
		private global::System.Windows.Forms.Panel plVeriMail;

		// Token: 0x04000231 RID: 561
		private global::System.Windows.Forms.Panel plHotmailReg;

		// Token: 0x04000232 RID: 562
		private global::System.Windows.Forms.Button btnCheckAPIAny;

		// Token: 0x04000233 RID: 563
		private global::System.Windows.Forms.TextBox txtPassmail;

		// Token: 0x04000234 RID: 564
		private global::System.Windows.Forms.TextBox txtAPIAnyCat;

		// Token: 0x04000235 RID: 565
		private global::System.Windows.Forms.Label label22;

		// Token: 0x04000236 RID: 566
		private global::System.Windows.Forms.CheckBox ckRdPassmail;

		// Token: 0x04000237 RID: 567
		private global::System.Windows.Forms.CheckBox chkHideBrowser;

		// Token: 0x04000238 RID: 568
		private global::System.Windows.Forms.CheckBox ckTaoMailBox;

		// Token: 0x04000239 RID: 569
		private global::System.Windows.Forms.Label label19;

		// Token: 0x0400023A RID: 570
		private global::System.Windows.Forms.Button btnNhapHotmail;

		// Token: 0x0400023B RID: 571
		private global::System.Windows.Forms.RadioButton rdHotMailReg;

		// Token: 0x0400023C RID: 572
		private global::System.Windows.Forms.RadioButton rdHotMailRegisted;

		// Token: 0x0400023D RID: 573
		private global::System.Windows.Forms.RadioButton rdConfMail;

		// Token: 0x0400023E RID: 574
		private global::System.Windows.Forms.GroupBox groupBox8;

		// Token: 0x0400023F RID: 575
		private global::System.Windows.Forms.Panel panel6;

		// Token: 0x04000240 RID: 576
		private global::System.Windows.Forms.GroupBox gbCamxuc;

		// Token: 0x04000241 RID: 577
		private global::System.Windows.Forms.CheckBox chkGian;

		// Token: 0x04000242 RID: 578
		private global::System.Windows.Forms.CheckBox chkBuon;

		// Token: 0x04000243 RID: 579
		private global::System.Windows.Forms.CheckBox chkHaha;

		// Token: 0x04000244 RID: 580
		private global::System.Windows.Forms.CheckBox chkTym;

		// Token: 0x04000245 RID: 581
		private global::System.Windows.Forms.CheckBox chkLike;

		// Token: 0x04000246 RID: 582
		private global::System.Windows.Forms.Panel plAddfriend;

		// Token: 0x04000247 RID: 583
		private global::System.Windows.Forms.NumericUpDown nFriendTo;

		// Token: 0x04000248 RID: 584
		private global::System.Windows.Forms.Label label25;

		// Token: 0x04000249 RID: 585
		private global::System.Windows.Forms.NumericUpDown nFriendFrom;

		// Token: 0x0400024A RID: 586
		private global::System.Windows.Forms.Label label26;

		// Token: 0x0400024B RID: 587
		private global::System.Windows.Forms.Label label27;

		// Token: 0x0400024C RID: 588
		private global::System.Windows.Forms.CheckBox chkInNewfeed;

		// Token: 0x0400024D RID: 589
		private global::System.Windows.Forms.CheckBox chkWatch;

		// Token: 0x0400024E RID: 590
		private global::System.Windows.Forms.CheckBox chkWStory;

		// Token: 0x0400024F RID: 591
		private global::System.Windows.Forms.CheckBox chkAddFUID;

		// Token: 0x04000250 RID: 592
		private global::System.Windows.Forms.CheckBox chkReadNotifi;

		// Token: 0x04000251 RID: 593
		private global::System.Windows.Forms.GroupBox groupBox5;

		// Token: 0x04000252 RID: 594
		private global::System.Windows.Forms.Panel panel5;

		// Token: 0x04000253 RID: 595
		private global::System.Windows.Forms.LinkLabel linkLabel2;

		// Token: 0x04000254 RID: 596
		private global::System.Windows.Forms.LinkLabel linkLabel1;

		// Token: 0x04000255 RID: 597
		private global::System.Windows.Forms.Panel plCheckDoiIP;

		// Token: 0x04000256 RID: 598
		private global::System.Windows.Forms.Button btnTestChangeIP;

		// Token: 0x04000257 RID: 599
		private global::System.Windows.Forms.NumericUpDown numChangeIP;

		// Token: 0x04000258 RID: 600
		private global::System.Windows.Forms.Label label20;

		// Token: 0x04000259 RID: 601
		private global::System.Windows.Forms.Label label21;

		// Token: 0x0400025A RID: 602
		private global::System.Windows.Forms.Panel pnlAPIMinProxy;

		// Token: 0x0400025B RID: 603
		private global::System.Windows.Forms.Button btnCheckAPIMinProxy;

		// Token: 0x0400025C RID: 604
		private global::System.Windows.Forms.RichTextBox txtApiKeyMinProxy;

		// Token: 0x0400025D RID: 605
		private global::System.Windows.Forms.Label label49;

		// Token: 0x0400025E RID: 606
		private global::System.Windows.Forms.Label label50;

		// Token: 0x0400025F RID: 607
		private global::System.Windows.Forms.NumericUpDown nudLuongPerIPMinProxy;

		// Token: 0x04000260 RID: 608
		private global::System.Windows.Forms.Panel plChangeIPDcom;

		// Token: 0x04000261 RID: 609
		private global::System.Windows.Forms.Button btnGetDcom;

		// Token: 0x04000262 RID: 610
		private global::System.Windows.Forms.TextBox txtNameDcom;

		// Token: 0x04000263 RID: 611
		private global::System.Windows.Forms.Panel plTinsoftProxy;

		// Token: 0x04000264 RID: 612
		private global::System.Windows.Forms.NumericUpDown nudLuongPerIPTinsoft;

		// Token: 0x04000265 RID: 613
		private global::System.Windows.Forms.Button btnCheckProxy;

		// Token: 0x04000266 RID: 614
		private global::System.Windows.Forms.Label label16;

		// Token: 0x04000267 RID: 615
		private global::System.Windows.Forms.Label label29;

		// Token: 0x04000268 RID: 616
		private global::System.Windows.Forms.Label label15;

		// Token: 0x04000269 RID: 617
		private global::System.Windows.Forms.TextBox txtProxy;

		// Token: 0x0400026A RID: 618
		private global::System.Windows.Forms.ComboBox cbLocationProxy;

		// Token: 0x0400026B RID: 619
		private global::System.Windows.Forms.RadioButton rdMinProxy;

		// Token: 0x0400026C RID: 620
		private global::System.Windows.Forms.RadioButton rdTinsoftProxy;

		// Token: 0x0400026D RID: 621
		private global::System.Windows.Forms.RadioButton rdHMA;

		// Token: 0x0400026E RID: 622
		private global::System.Windows.Forms.RadioButton rdChangeIPDcom;

		// Token: 0x0400026F RID: 623
		private global::System.Windows.Forms.RadioButton rdNoChangeIP;

		// Token: 0x04000270 RID: 624
		private global::System.Windows.Forms.GroupBox groupBox4;

		// Token: 0x04000271 RID: 625
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000272 RID: 626
		private global::System.Windows.Forms.NumericUpDown numDelayTo;

		// Token: 0x04000273 RID: 627
		private global::System.Windows.Forms.RadioButton rdDelayLD;

		// Token: 0x04000274 RID: 628
		private global::System.Windows.Forms.Label label4;

		// Token: 0x04000275 RID: 629
		private global::System.Windows.Forms.NumericUpDown numDelayFr;

		// Token: 0x04000276 RID: 630
		private global::System.Windows.Forms.Label label5;

		// Token: 0x04000277 RID: 631
		private global::System.Windows.Forms.TextBox txtLinkLD;

		// Token: 0x04000278 RID: 632
		private global::System.Windows.Forms.NumericUpDown numDeClsTo;

		// Token: 0x04000279 RID: 633
		private global::System.Windows.Forms.NumericUpDown numDeClsFr;

		// Token: 0x0400027A RID: 634
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400027B RID: 635
		private global::System.Windows.Forms.RadioButton rdNormal;

		// Token: 0x0400027C RID: 636
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400027D RID: 637
		private global::System.Windows.Forms.Label label6;

		// Token: 0x0400027E RID: 638
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400027F RID: 639
		private global::System.Windows.Forms.GroupBox groupBox3;

		// Token: 0x04000280 RID: 640
		private global::System.Windows.Forms.NumericUpDown numOTP;

		// Token: 0x04000281 RID: 641
		private global::System.Windows.Forms.NumericUpDown nudSoLuotChay;

		// Token: 0x04000282 RID: 642
		private global::System.Windows.Forms.NumericUpDown numThrLdPlay;

		// Token: 0x04000283 RID: 643
		private global::System.Windows.Forms.Label label24;

		// Token: 0x04000284 RID: 644
		private global::System.Windows.Forms.Label label11;

		// Token: 0x04000285 RID: 645
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000286 RID: 646
		private global::System.Windows.Forms.Label label23;

		// Token: 0x04000287 RID: 647
		private global::System.Windows.Forms.Label label2;

		// Token: 0x04000288 RID: 648
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000289 RID: 649
		private global::System.Windows.Forms.Button btnMaximum;

		// Token: 0x0400028A RID: 650
		private global::Bunifu.UI.WinForms.BunifuFormDock bunifuFormDock1;
	}
}
