namespace ToolRegFB
{
	// Token: 0x02000042 RID: 66
	public partial class frm_progress : global::System.Windows.Forms.Form
	{
		// Token: 0x060002DF RID: 735 RVA: 0x000369A0 File Offset: 0x00034BA0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x000369D8 File Offset: 0x00034BD8
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.bunifuCustomLabel1 = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.lblLoading = new global::Bunifu.Framework.UI.BunifuCustomLabel();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			base.SuspendLayout();
			this.bunifuCustomLabel1.AutoSize = true;
			this.bunifuCustomLabel1.Font = new global::System.Drawing.Font("Segoe UI Semibold", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuCustomLabel1.Location = new global::System.Drawing.Point(106, 26);
			this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			this.bunifuCustomLabel1.Size = new global::System.Drawing.Size(242, 28);
			this.bunifuCustomLabel1.TabIndex = 11;
			this.bunifuCustomLabel1.Text = "Đang tải phiên bản mới...";
			this.bunifuCustomLabel1.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblLoading.AutoSize = true;
			this.lblLoading.Font = new global::System.Drawing.Font("Segoe UI Semibold", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblLoading.ForeColor = global::System.Drawing.Color.FromArgb(245, 66, 66);
			this.lblLoading.Location = new global::System.Drawing.Point(85, 62);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new global::System.Drawing.Size(201, 28);
			this.lblLoading.TabIndex = 12;
			this.lblLoading.Text = "bunifuCustomLabel2";
			this.timer1.Enabled = true;
			this.timer1.Interval = 200;
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(469, 137);
			base.Controls.Add(this.lblLoading);
			base.Controls.Add(this.bunifuCustomLabel1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "frm_progress";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frm_progress";
			base.Load += new global::System.EventHandler(this.frm_progress_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000315 RID: 789
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000316 RID: 790
		private global::Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;

		// Token: 0x04000317 RID: 791
		private global::Bunifu.Framework.UI.BunifuCustomLabel lblLoading;

		// Token: 0x04000318 RID: 792
		private global::System.Windows.Forms.Timer timer1;
	}
}
