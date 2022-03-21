using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ToolRegFB
{
	// Token: 0x02000046 RID: 70
	internal class JSON_Settings
	{
		// Token: 0x060002F4 RID: 756 RVA: 0x0003768C File Offset: 0x0003588C
		public JSON_Settings(string jsonStringOrPathFile, bool isJsonString = false)
		{
			if (isJsonString)
			{
				bool flag = jsonStringOrPathFile.Trim() == "";
				if (flag)
				{
					jsonStringOrPathFile = "{}";
				}
				this.json = JObject.Parse(jsonStringOrPathFile);
			}
			else
			{
				try
				{
					bool flag2 = jsonStringOrPathFile.Contains("\\") || jsonStringOrPathFile.Contains("/");
					if (flag2)
					{
						this.PathFileSetting = jsonStringOrPathFile;
					}
					else
					{
						this.PathFileSetting = "settings\\" + jsonStringOrPathFile + ".json";
					}
					bool flag3 = !File.Exists(this.PathFileSetting);
					if (flag3)
					{
						using (File.AppendText(this.PathFileSetting))
						{
						}
					}
					this.json = JObject.Parse(File.ReadAllText(this.PathFileSetting));
				}
				catch
				{
					this.json = new JObject();
				}
			}
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00037794 File Offset: 0x00035994
		public JSON_Settings()
		{
			this.json = new JObject();
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x000377AC File Offset: 0x000359AC
		public string GetValue(string key, string valueDefault = "")
		{
			string result = valueDefault;
			try
			{
				result = ((this.json[key] == null) ? valueDefault : this.json[key].ToString());
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00037800 File Offset: 0x00035A00
		public List<string> GetValueList(string key, int typeSplitString = 0)
		{
			List<string> list = new List<string>();
			try
			{
				bool flag = typeSplitString == 0;
				if (flag)
				{
					list = this.GetValue(key, "").Split(new char[]
					{
						'\n'
					}).ToList<string>();
				}
				else
				{
					list = this.GetValue(key, "").Split(new string[]
					{
						"\n|\n"
					}, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
				}
				list = Common.RemoveEmptyItems(list);
			}
			catch
			{
			}
			return list;
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00037890 File Offset: 0x00035A90
		public int GetValueInt(string key, int valueDefault = 0)
		{
			int result = valueDefault;
			try
			{
				result = ((this.json[key] == null) ? valueDefault : Convert.ToInt32(this.json[key].ToString()));
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x000378E8 File Offset: 0x00035AE8
		public bool GetValueBool(string key, bool valueDefault = false)
		{
			bool result = valueDefault;
			try
			{
				result = ((this.json[key] == null) ? valueDefault : Convert.ToBoolean(this.json[key].ToString()));
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00037940 File Offset: 0x00035B40
		public void Add(string key, string value)
		{
			try
			{
				bool flag = !this.json.ContainsKey(key);
				if (flag)
				{
					this.json.Add(key, value);
				}
				else
				{
					this.json[key] = value;
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060002FB RID: 763 RVA: 0x000379A8 File Offset: 0x00035BA8
		public void Update(string key, object value)
		{
			try
			{
				this.json[key] = value.ToString();
			}
			catch
			{
			}
		}

		// Token: 0x060002FC RID: 764 RVA: 0x000379E8 File Offset: 0x00035BE8
		public void Update(string key, List<string> lst)
		{
			try
			{
				bool flag = false;
				foreach (string text in lst)
				{
					bool flag2 = text.Contains("\n");
					if (flag2)
					{
						flag = true;
						break;
					}
				}
				bool flag3 = flag;
				if (flag3)
				{
					this.json[key] = string.Join("\n|\n", lst).ToString();
				}
				else
				{
					this.json[key] = string.Join("\n", lst).ToString();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00037AB0 File Offset: 0x00035CB0
		public void Remove(string key)
		{
			try
			{
				this.json.Remove(key);
			}
			catch
			{
			}
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00037AE4 File Offset: 0x00035CE4
		public void Save(string pathFileSetting = "")
		{
			try
			{
				bool flag = pathFileSetting == "";
				if (flag)
				{
					pathFileSetting = this.PathFileSetting;
				}
				File.WriteAllText(pathFileSetting, this.json.ToString());
			}
			catch
			{
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00037B38 File Offset: 0x00035D38
		public string GetFullString()
		{
			string result = "";
			try
			{
				result = this.json.ToString().Replace("\r\n", "");
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x04000325 RID: 805
		private string PathFileSetting;

		// Token: 0x04000326 RID: 806
		private JObject json;
	}
}
