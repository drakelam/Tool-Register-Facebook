using System;
using System.Runtime.InteropServices;

namespace ToolRegFB
{
	// Token: 0x02000051 RID: 81
	internal class User32Helper
	{
		// Token: 0x0600034F RID: 847
		[DllImport("user32.dll", SetLastError = true)]
		public static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		// Token: 0x06000350 RID: 848
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
	}
}
