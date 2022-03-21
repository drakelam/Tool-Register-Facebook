using System;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace ToolRegFB
{
	// Token: 0x0200004D RID: 77
	internal static class Program
	{
		// Token: 0x0600032A RID: 810 RVA: 0x00038AD4 File Offset: 0x00036CD4
		[STAThread]
		private static void Main()
		{
			bool flag = false;
			using (new Mutex(true, "MyToolRunning", ref flag))
			{
				try
				{
					bool flag2 = flag;
					if (flag2)
					{
						Application.EnableVisualStyles();
						Application.SetCompatibleTextRenderingDefault(false);
						bool flag3 = !new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
						if (flag3)
						{
							MessageBox.Show("Vui lòng chạy Tool bằng quyền Admin!\r\nPlease Run Aplication As Administrator!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							Environment.Exit(0);
						}
						Application.Run(new frmLoginUser());
					}
					else
					{
						MessageBox.Show("Rabbit Social Tool hiện đang chạy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				catch
				{
				}
			}
		}
	}
}
