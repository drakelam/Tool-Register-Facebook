namespace ToolRegFB
{
	// Token: 0x02000037 RID: 55
	public partial class frmUpdate : global::System.Windows.Forms.Form
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x0003337C File Offset: 0x0003157C
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000333B4 File Offset: 0x000315B4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.bunifuDragControl1 = new global::Bunifu.Framework.UI.BunifuDragControl(this.components);
			this.bunifuCustomLabel1 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.lblLoading = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.label1 = new global::System.Windows.Forms.Label();
			this.btnClose = new global::System.Windows.Forms.Button();
			this.panel4.SuspendLayout();
			base.SuspendLayout();
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(46, 51, 73);
			this.panel4.Controls.Add(this.label1);
			this.panel4.Controls.Add(this.btnClose);
			this.panel4.Dock = global::System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new global::System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(542, 46);
			this.panel4.TabIndex = 9;
			this.bunifuDragControl1.Fixed = true;
			this.bunifuDragControl1.Horizontal = true;
			this.bunifuDragControl1.TargetControl = this.panel4;
			this.bunifuDragControl1.Vertical = true;
			this.bunifuCustomLabel1.AutoSize = true;
			this.bunifuCustomLabel1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel1.Location = new global::System.Drawing.Point(138, 64);
			this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			this.bunifuCustomLabel1.Size = new global::System.Drawing.Size(254, 28);
			this.bunifuCustomLabel1.TabIndex = 10;
			this.bunifuCustomLabel1.Text = "Đang kiểm tra phiên bản...";
			this.bunifuCustomLabel1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLoading.AutoSize = true;
			this.lblLoading.Font = new global::System.Drawing.Font("Segoe UI Semibold", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLoading.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lblLoading.Location = new global::System.Drawing.Point(117, 103);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new global::System.Drawing.Size(201, 28);
			this.lblLoading.TabIndex = 11;
			this.lblLoading.Text = "bunifuCustomLabel2";
			this.timer1.Enabled = true;
			this.timer1.Interval = 200;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 13.8f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(3, 7);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(164, 32);
			this.label1.TabIndex = 6;
			this.label1.Text = "Cập nhật tool";
			this.btnClose.Anchor = (global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right);
			this.btnClose.FlatAppearance.BorderSize = 0;
			this.btnClose.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.2f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.btnClose.Image = global::ToolRegFB.Properties.Resources.icons8_x_20;
			this.btnClose.Location = new global::System.Drawing.Point(495, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new global::System.Drawing.Size(44, 39);
			this.btnClose.TabIndex = 5;
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new global::System.EventHandler(this.btnClose_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(542, 159);
			base.Controls.Add(this.lblLoading);
			base.Controls.Add(this.bunifuCustomLabel1);
			base.Controls.Add(this.panel4);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frmUpdate";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmUpdate";
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x040002D7 RID: 727
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x040002D8 RID: 728
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040002D9 RID: 729
		private global::System.Windows.Forms.Button btnClose;

		// Token: 0x040002DA RID: 730
		private global::Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;

		// Token: 0x040002DB RID: 731
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;

		// Token: 0x040002DC RID: 732
		private global::Bunifu.Framework.UI.BunifuCustomLabel lblLoading;

		// Token: 0x040002DD RID: 733
		private global::System.Windows.Forms.Timer timer1;

		// Token: 0x040002DE RID: 734
		private global::System.Windows.Forms.Label label1;
	}
}
