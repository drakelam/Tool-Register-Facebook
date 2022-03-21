using System;

namespace ToolRegFB.Models
{
	// Token: 0x02000054 RID: 84
	public class Licenses
	{
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060003A6 RID: 934 RVA: 0x0003BFB2 File Offset: 0x0003A1B2
		// (set) Token: 0x060003A7 RID: 935 RVA: 0x0003BFBA File Offset: 0x0003A1BA
		public DateTime timeExpired { get; set; }

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060003A8 RID: 936 RVA: 0x0003BFC3 File Offset: 0x0003A1C3
		// (set) Token: 0x060003A9 RID: 937 RVA: 0x0003BFCB File Offset: 0x0003A1CB
		public string typeProduct { get; set; }
	}
}
