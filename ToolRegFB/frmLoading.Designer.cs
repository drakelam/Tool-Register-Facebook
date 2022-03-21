namespace ToolRegFB
{
	// Token: 0x02000026 RID: 38
	public partial class frmLoading : global::System.Windows.Forms.Form
	{
		// Token: 0x060001AF RID: 431 RVA: 0x0000F8FC File Offset: 0x0000DAFC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x0000F934 File Offset: 0x0000DB34
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::ToolRegFB.frmLoading));
			base.SuspendLayout();
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(7f, 17f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(46, 51, 73);
			base.ClientSize = new global::System.Drawing.Size(843, 503);
			this.Font = new global::System.Drawing.Font("Nirmala UI", 7.8f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.ForeColor = global::System.Drawing.Color.White;
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmLoading";
			base.Opacity = 0.8;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Loading Indicator";
			base.Load += new global::System.EventHandler(this.frmLoading_Load);
			base.ResumeLayout(false);
		}

		// Token: 0x040000FD RID: 253
		private global::System.ComponentModel.IContainer components = null;
	}
}
