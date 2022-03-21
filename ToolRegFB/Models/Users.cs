using System;
using System.Collections.Generic;

namespace ToolRegFB.Models
{
	// Token: 0x02000057 RID: 87
	public class Users
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x0003C022 File Offset: 0x0003A222
		// (set) Token: 0x060003B4 RID: 948 RVA: 0x0003C02A File Offset: 0x0003A22A
		public int id { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x0003C033 File Offset: 0x0003A233
		// (set) Token: 0x060003B6 RID: 950 RVA: 0x0003C03B File Offset: 0x0003A23B
		public string name { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x060003B7 RID: 951 RVA: 0x0003C044 File Offset: 0x0003A244
		// (set) Token: 0x060003B8 RID: 952 RVA: 0x0003C04C File Offset: 0x0003A24C
		public string email { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x060003B9 RID: 953 RVA: 0x0003C055 File Offset: 0x0003A255
		// (set) Token: 0x060003BA RID: 954 RVA: 0x0003C05D File Offset: 0x0003A25D
		public string password { get; set; }

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x060003BB RID: 955 RVA: 0x0003C066 File Offset: 0x0003A266
		// (set) Token: 0x060003BC RID: 956 RVA: 0x0003C06E File Offset: 0x0003A26E
		public string token { get; set; }

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x060003BD RID: 957 RVA: 0x0003C077 File Offset: 0x0003A277
		// (set) Token: 0x060003BE RID: 958 RVA: 0x0003C07F File Offset: 0x0003A27F
		public double totalMoney { get; set; }

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x060003BF RID: 959 RVA: 0x0003C088 File Offset: 0x0003A288
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x0003C090 File Offset: 0x0003A290
		public List<Licenses> listLicense { get; set; }

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x060003C1 RID: 961 RVA: 0x0003C099 File Offset: 0x0003A299
		// (set) Token: 0x060003C2 RID: 962 RVA: 0x0003C0A1 File Offset: 0x0003A2A1
		public string macAddress { get; set; }
	}
}
