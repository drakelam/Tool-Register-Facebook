using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace ToolRegFB
{
	// Token: 0x02000044 RID: 68
	public class IniFile
	{
		// Token: 0x060002E7 RID: 743
		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

		// Token: 0x060002E8 RID: 744
		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		private static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

		// Token: 0x060002E9 RID: 745
		[DllImport("KERNEL32.DLL", CharSet = CharSet.Unicode, EntryPoint = "GetPrivateProfileStringW")]
		private static extern uint GetPrivateProfileStringByByteArray(string lpAppName, string lpKeyName, string lpDefault, byte[] lpReturnedString, uint nSize, string lpFileName);

		// Token: 0x060002EA RID: 746 RVA: 0x00037510 File Offset: 0x00035710
		public IniFile(string IniPath = null)
		{
			this.Path = new FileInfo(IniPath ?? (this.EXE + ".ini")).FullName.ToString();
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00037564 File Offset: 0x00035764
		public string ReadUnicode(string Key, string Section = null)
		{
			byte[] array = new byte[1024];
			uint privateProfileStringByByteArray = IniFile.GetPrivateProfileStringByByteArray(Section ?? this.EXE, Key, "", array, (uint)array.Length, this.Path);
			return Encoding.Unicode.GetString(array, 0, (int)(privateProfileStringByByteArray * 2U));
		}

		// Token: 0x060002EC RID: 748 RVA: 0x000375B4 File Offset: 0x000357B4
		public string Read(string Key, string Section = null)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			IniFile.GetPrivateProfileString(Section ?? this.EXE, Key, "", stringBuilder, 255, this.Path);
			return stringBuilder.ToString();
		}

		// Token: 0x060002ED RID: 749 RVA: 0x000375FA File Offset: 0x000357FA
		public void Write(string Key, string Value, string Section = null)
		{
			IniFile.WritePrivateProfileString(Section ?? this.EXE, Key, Value, this.Path);
		}

		// Token: 0x060002EE RID: 750 RVA: 0x00037616 File Offset: 0x00035816
		public void DeleteKey(string Key, string Section = null)
		{
			this.Write(Key, null, Section ?? this.EXE);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0003762D File Offset: 0x0003582D
		public void DeleteSection(string Section = null)
		{
			this.Write(null, null, Section ?? this.EXE);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00037644 File Offset: 0x00035844
		public bool KeyExists(string Key, string Section = null)
		{
			return this.Read(Key, Section).Length > 0;
		}

		// Token: 0x04000323 RID: 803
		private string Path;

		// Token: 0x04000324 RID: 804
		private string EXE = Assembly.GetExecutingAssembly().GetName().Name;
	}
}
