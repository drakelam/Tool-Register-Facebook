using System;
using System.Runtime.InteropServices;

namespace ToolRegFB
{
	// Token: 0x02000045 RID: 69
	internal class InternetConnection
	{
		// Token: 0x060002F1 RID: 753
		[DllImport("wininet.dll")]
		private static extern bool InternetGetConnectedState(out int description, int reservedValuine);

		// Token: 0x060002F2 RID: 754 RVA: 0x00037668 File Offset: 0x00035868
		public static bool IsConnectedToInternet()
		{
			int num;
			return InternetConnection.InternetGetConnectedState(out num, 0);
		}
	}
}
