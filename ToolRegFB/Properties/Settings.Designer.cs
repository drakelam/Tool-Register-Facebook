using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ToolRegFB.Properties
{
	// Token: 0x02000053 RID: 83
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600038B RID: 907 RVA: 0x0003BCF0 File Offset: 0x00039EF0
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x0600038C RID: 908 RVA: 0x0003BD08 File Offset: 0x00039F08
		// (set) Token: 0x0600038D RID: 909 RVA: 0x0003BD2A File Offset: 0x00039F2A
		[DefaultSettingValue("Memory")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public string Memory
		{
			get
			{
				return (string)this["Memory"];
			}
			set
			{
				this["Memory"] = value;
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x0600038E RID: 910 RVA: 0x0003BD3C File Offset: 0x00039F3C
		// (set) Token: 0x0600038F RID: 911 RVA: 0x0003BD5E File Offset: 0x00039F5E
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		[UserScopedSetting]
		public string userLogin
		{
			get
			{
				return (string)this["userLogin"];
			}
			set
			{
				this["userLogin"] = value;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000390 RID: 912 RVA: 0x0003BD70 File Offset: 0x00039F70
		// (set) Token: 0x06000391 RID: 913 RVA: 0x0003BD92 File Offset: 0x00039F92
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		[UserScopedSetting]
		public string PassLogin
		{
			get
			{
				return (string)this["PassLogin"];
			}
			set
			{
				this["PassLogin"] = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000392 RID: 914 RVA: 0x0003BDA4 File Offset: 0x00039FA4
		// (set) Token: 0x06000393 RID: 915 RVA: 0x0003BDC6 File Offset: 0x00039FC6
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool isRememe
		{
			get
			{
				return (bool)this["isRememe"];
			}
			set
			{
				this["isRememe"] = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000394 RID: 916 RVA: 0x0003BDDC File Offset: 0x00039FDC
		// (set) Token: 0x06000395 RID: 917 RVA: 0x0003BDFE File Offset: 0x00039FFE
		[DefaultSettingValue("True")]
		[DebuggerNonUserCode]
		[UserScopedSetting]
		public bool isAutoClearLD
		{
			get
			{
				return (bool)this["isAutoClearLD"];
			}
			set
			{
				this["isAutoClearLD"] = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000396 RID: 918 RVA: 0x0003BE14 File Offset: 0x0003A014
		// (set) Token: 0x06000397 RID: 919 RVA: 0x0003BE36 File Offset: 0x0003A036
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool isOnGPSLD
		{
			get
			{
				return (bool)this["isOnGPSLD"];
			}
			set
			{
				this["isOnGPSLD"] = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000398 RID: 920 RVA: 0x0003BE4C File Offset: 0x0003A04C
		// (set) Token: 0x06000399 RID: 921 RVA: 0x0003BE6E File Offset: 0x0003A06E
		[UserScopedSetting]
		[DefaultSettingValue("1 cores (Khuyến nghị)")]
		[DebuggerNonUserCode]
		public string CpuLD
		{
			get
			{
				return (string)this["CpuLD"];
			}
			set
			{
				this["CpuLD"] = value;
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x0600039A RID: 922 RVA: 0x0003BE80 File Offset: 0x0003A080
		// (set) Token: 0x0600039B RID: 923 RVA: 0x0003BEA2 File Offset: 0x0003A0A2
		[UserScopedSetting]
		[DefaultSettingValue("1024M (Khuyến nghị)")]
		[DebuggerNonUserCode]
		public string RamLD
		{
			get
			{
				return (string)this["RamLD"];
			}
			set
			{
				this["RamLD"] = value;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x0600039C RID: 924 RVA: 0x0003BEB4 File Offset: 0x0003A0B4
		// (set) Token: 0x0600039D RID: 925 RVA: 0x0003BED6 File Offset: 0x0003A0D6
		[DefaultSettingValue("320")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public int SizeLDFrom
		{
			get
			{
				return (int)this["SizeLDFrom"];
			}
			set
			{
				this["SizeLDFrom"] = value;
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x0600039E RID: 926 RVA: 0x0003BEEC File Offset: 0x0003A0EC
		// (set) Token: 0x0600039F RID: 927 RVA: 0x0003BF0E File Offset: 0x0003A10E
		[DebuggerNonUserCode]
		[DefaultSettingValue("480")]
		[UserScopedSetting]
		public int SizeLDTo
		{
			get
			{
				return (int)this["SizeLDTo"];
			}
			set
			{
				this["SizeLDTo"] = value;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060003A0 RID: 928 RVA: 0x0003BF24 File Offset: 0x0003A124
		// (set) Token: 0x060003A1 RID: 929 RVA: 0x0003BF46 File Offset: 0x0003A146
		[UserScopedSetting]
		[DefaultSettingValue("120")]
		[DebuggerNonUserCode]
		public int DPILD
		{
			get
			{
				return (int)this["DPILD"];
			}
			set
			{
				this["DPILD"] = value;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060003A2 RID: 930 RVA: 0x0003BF5C File Offset: 0x0003A15C
		// (set) Token: 0x060003A3 RID: 931 RVA: 0x0003BF7E File Offset: 0x0003A17E
		[DefaultSettingValue("False")]
		[UserScopedSetting]
		[DebuggerNonUserCode]
		public bool isAdbDebug
		{
			get
			{
				return (bool)this["isAdbDebug"];
			}
			set
			{
				this["isAdbDebug"] = value;
			}
		}

		// Token: 0x04000363 RID: 867
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
