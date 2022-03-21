using System;
using System.Windows.Forms;

namespace ToolRegFB
{
	// Token: 0x02000018 RID: 24
	internal class DatagridviewHelper
	{
		// Token: 0x06000117 RID: 279 RVA: 0x000098A4 File Offset: 0x00007AA4
		public static void SetStatusDataGridViewWithWait(DataGridView dgv, int row, string colName, int timeWait = 0, string status = "Đợi {time} giây...")
		{
			try
			{
				int time_start = Environment.TickCount;
				while ((Environment.TickCount - time_start) / 1000 - timeWait < 0)
				{
					dgv.Invoke(new MethodInvoker(delegate()
					{
						dgv.Rows[row].Cells[colName].Value = status.Replace("{time}", (timeWait - (Environment.TickCount - time_start) / 1000).ToString());
					}));
					Common.DelayTime(0.5);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x00009964 File Offset: 0x00007B64
		public static void SetStatusDataGridViewWithWait(DataGridView dgv, int row, string colName, int timeWait = 0, int timeStart = 0, string status = "Đợi {time} giây...")
		{
			try
			{
				int time_start = Environment.TickCount;
				while ((Environment.TickCount - time_start) / 1000 - timeWait < 0)
				{
					dgv.Invoke(new MethodInvoker(delegate()
					{
						dgv.Rows[row].Cells[colName].Value = status.Replace("{time}", (timeStart - (Environment.TickCount - time_start) / 1000).ToString());
					}));
					Common.DelayTime(0.5);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00009A1C File Offset: 0x00007C1C
		public static string GetStatusDataGridView(DataGridView dgv, int row, int col)
		{
			string output = "";
			try
			{
				bool flag = dgv.Rows[row].Cells[col].Value != null;
				if (flag)
				{
					try
					{
						output = dgv.Rows[row].Cells[col].Value.ToString();
					}
					catch
					{
						dgv.Invoke(new MethodInvoker(delegate()
						{
							output = dgv.Rows[row].Cells[col].Value.ToString();
						}));
					}
				}
			}
			catch
			{
			}
			return output;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00009B0C File Offset: 0x00007D0C
		public static string GetStatusDataGridView(DataGridView dgv, int row, string colName)
		{
			string output = "";
			try
			{
				bool flag = dgv.Rows[row].Cells[colName].Value != null;
				if (flag)
				{
					try
					{
						output = dgv.Rows[row].Cells[colName].Value.ToString();
					}
					catch
					{
						dgv.Invoke(new MethodInvoker(delegate()
						{
							output = dgv.Rows[row].Cells[colName].Value.ToString();
						}));
					}
				}
			}
			catch
			{
			}
			return output;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00009BFC File Offset: 0x00007DFC
		public static void SetStatusDataGridView(DataGridView dgv, int row, string colName, object status)
		{
			try
			{
				bool flag = colName == "cStatus";
				if (flag)
				{
					string statusDataGridView = DatagridviewHelper.GetStatusDataGridView(dgv, row, "cId");
				}
				try
				{
					dgv.Invoke(new MethodInvoker(delegate()
					{
						dgv.Rows[row].Cells[colName].Value = status;
					}));
				}
				catch
				{
					dgv.Rows[row].Cells[colName].Value = status;
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00009CD4 File Offset: 0x00007ED4
		public static void SetStatusDataGridView(DataGridView dgv, int row, int col, object status)
		{
			try
			{
				try
				{
					dgv.Invoke(new MethodInvoker(delegate()
					{
						dgv.Rows[row].Cells[col].Value = status;
					}));
				}
				catch
				{
					dgv.Rows[row].Cells[col].Value = status;
				}
			}
			catch
			{
			}
		}
	}
}
