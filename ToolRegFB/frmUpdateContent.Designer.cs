namespace ToolRegFB
{
	// Token: 0x02000038 RID: 56
	public partial class frmUpdateContent : global::System.Windows.Forms.Form
	{
		// Token: 0x060002B1 RID: 689 RVA: 0x00033A88 File Offset: 0x00031C88
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00033AC0 File Offset: 0x00031CC0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ToolRegFB.frmUpdateContent));
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.bunifuCustomLabel2 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.lblCurrent = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.lblNew = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.bunifuCustomLabel1 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.txtContentUpdate = new global::WindowsFormsControlLibrary1.BunifuCustomTextbox();
			this.btnUpdateVersion = new global::Bunifu.Framework.UI.BunifuFlatButton();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.panel4.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(46, 51, 73);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.btnClose);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(544, 46);
			this.panel4.TabIndex = 10;
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(285, 32);
			this.label1.TabIndex = 6;
			this.label1.Text = "Thông tin phiên bản mới";
			this.panel1.Controls.Add(this.txtContentUpdate);
			this.panel1.Controls.Add(this.btnUpdateVersion);
			this.panel1.Controls.Add(this.bunifuCustomLabel2);
			this.panel1.Controls.Add(this.lblCurrent);
			this.panel1.Controls.Add(this.lblNew);
			this.panel1.Controls.Add(this.bunifuCustomLabel1);
			this.panel1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new global::System.Drawing.Point(0, 46);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(544, 371);
			this.panel1.TabIndex = 11;
			this.bunifuCustomLabel2.AutoSize = true;
			this.bunifuCustomLabel2.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel2.Location = new global::System.Drawing.Point(13, 51);
			this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			this.bunifuCustomLabel2.Size = new global::System.Drawing.Size(137, 20);
			this.bunifuCustomLabel2.TabIndex = 1;
			this.bunifuCustomLabel2.Text = "Phiên bản hiện tại:";
			this.lblCurrent.AutoSize = true;
			this.lblCurrent.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblCurrent.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lblCurrent.Location = new global::System.Drawing.Point(166, 51);
			this.lblCurrent.Name = "lblCurrent";
			this.lblCurrent.Size = new global::System.Drawing.Size(44, 20);
			this.lblCurrent.TabIndex = 1;
			this.lblCurrent.Text = "1.0.0";
			this.lblNew.AutoSize = true;
			this.lblNew.Font = new global::System.Drawing.Font("Segoe UI", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblNew.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lblNew.Location = new global::System.Drawing.Point(166, 18);
			this.lblNew.Name = "lblNew";
			this.lblNew.Size = new global::System.Drawing.Size(44, 20);
			this.lblNew.TabIndex = 1;
			this.lblNew.Text = "1.0.1";
			this.bunifuCustomLabel1.AutoSize = true;
			this.bunifuCustomLabel1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel1.Location = new global::System.Drawing.Point(13, 18);
			this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			this.bunifuCustomLabel1.Size = new global::System.Drawing.Size(147, 20);
			this.bunifuCustomLabel1.TabIndex = 1;
			this.bunifuCustomLabel1.Text = "Phiên bản mới nhất:";
			this.txtContentUpdate.BorderColor = global::System.Drawing.Color.SeaGreen;
			this.txtContentUpdate.Font = new global::System.Drawing.Font("Segoe UI Semibold", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.txtContentUpdate.Location = new global::System.Drawing.Point(17, 86);
			this.txtContentUpdate.Multiline = true;
			this.txtContentUpdate.Name = "txtContentUpdate";
			this.txtContentUpdate.ScrollBars = global::System.Windows.Forms.ScrollBars.Vertical;
			this.txtContentUpdate.Size = new global::System.Drawing.Size(507, 210);
			this.txtContentUpdate.TabIndex = 1;
			this.btnUpdateVersion.Activecolor = global::System.Drawing.Color.FromArgb(46, 139, 87);
			this.btnUpdateVersion.BackColor = global::System.Drawing.Color.FromArgb(46, 139, 87);
			this.btnUpdateVersion.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.btnUpdateVersion.BorderRadius = 0;
			this.btnUpdateVersion.ButtonText = "Cập nhật";
			this.btnUpdateVersion.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.btnUpdateVersion.DisabledColor = global::System.Drawing.Color.Gray;
			this.btnUpdateVersion.Dock = global::System.Windows.Forms.DockStyle.Bottom;
			this.btnUpdateVersion.Iconcolor = global::System.Drawing.Color.Transparent;
			this.btnUpdateVersion.Iconimage = (global::System.Drawing.Image)componentResourceManager.GetObject("btnUpdateVersion.Iconimage");
			this.btnUpdateVersion.Iconimage_right = null;
			this.btnUpdateVersion.Iconimage_right_Selected = null;
			this.btnUpdateVersion.Iconimage_Selected = null;
			this.btnUpdateVersion.IconMarginLeft = 130;
			this.btnUpdateVersion.IconMarginRight = 0;
			this.btnUpdateVersion.IconRightVisible = true;
			this.btnUpdateVersion.IconRightZoom = 0.0;
			this.btnUpdateVersion.IconVisible = true;
			this.btnUpdateVersion.IconZoom = 90.0;
			this.btnUpdateVersion.IsTab = false;
			this.btnUpdateVersion.Location = new global::System.Drawing.Point(0, 312);
			this.btnUpdateVersion.Margin = new global::System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnUpdateVersion.Name = "btnUpdateVersion";
			this.btnUpdateVersion.Normalcolor = global::System.Drawing.Color.FromArgb(46, 139, 87);
			this.btnUpdateVersion.OnHovercolor = global::System.Drawing.Color.FromArgb(36, 129, 77);
			this.btnUpdateVersion.OnHoverTextColor = global::System.Drawing.Color.White;
			this.btnUpdateVersion.selected = false;
			this.btnUpdateVersion.Size = new global::System.Drawing.Size(544, 59);
			this.btnUpdateVersion.TabIndex = 2;
			this.btnUpdateVersion.Text = "Cập nhật";
			this.btnUpdateVersion.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.btnUpdateVersion.Textcolor = global::System.Drawing.Color.White;
			this.btnUpdateVersion.TextFont = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnUpdateVersion.Click += new global::System.EventHandler(this.btnUpdateVersion_Click);
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Image = global::ToolRegFB.Properties.Resources.icons8_x_20;
			this.btnClose.Location = new global::System.Drawing.Point(497, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(44, 39);
			this.btnClose.TabIndex = 5;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(544, 417);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmUpdateContent";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmUpdateContent";
			base.Load += new global::System.EventHandler(this.frmUpdateContent_Load);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040002E5 RID: 741
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002E6 RID: 742
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040002E7 RID: 743
		private global::System.Windows.Forms.Label label1;

		// Token: 0x040002E8 RID: 744
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040002E9 RID: 745
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040002EA RID: 746
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;

		// Token: 0x040002EB RID: 747
		private global::Bunifu.Framework.UI.BunifuCustomLabel lblCurrent;

		// Token: 0x040002EC RID: 748
		private global::Bunifu.Framework.UI.BunifuCustomLabel lblNew;

		// Token: 0x040002ED RID: 749
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;

		// Token: 0x040002EE RID: 750
		private global::Bunifu.Framework.UI.BunifuFlatButton btnUpdateVersion;

		// Token: 0x040002EF RID: 751
		private global::WindowsFormsControlLibrary1.BunifuCustomTextbox txtContentUpdate;
	}
}
