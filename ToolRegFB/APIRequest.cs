using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HttpRequest;
using Newtonsoft.Json.Linq;
using ToolRegFB.Models;

namespace ToolRegFB
{
	// Token: 0x02000003 RID: 3
	internal class APIRequest
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020B4 File Offset: 0x000002B4
		public static int RegisterAccount(Users user)
		{
			IniFile iniFile = new IniFile("update.ini");
			string text = iniFile.Read("Version", "Infor");
			string s = string.Concat(new string[]
			{
				"name=",
				user.name,
				"&email=",
				user.email,
				"&password=",
				user.password,
				"&macAddress=",
				user.macAddress,
				"&rb_version=",
				text
			});
			string text2 = APIRequest.requestHTTP.Request("POST", APIRequest.api_url + "register", null, Encoding.UTF8.GetBytes(s), true, null, 60000);
			JObject jobject = JObject.Parse(text2);
			return Convert.ToInt32(jobject["code"].ToString());
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002194 File Offset: 0x00000394
		public static Users LoginApp(string email, string pass)
		{
			Users result;
			try
			{
				IniFile iniFile = new IniFile("update.ini");
				string text = iniFile.Read("Version", "Infor");
				Users users = null;
				string s = string.Concat(new string[]
				{
					"email=",
					email,
					"&password=",
					pass,
					"&rb_version=",
					text
				});
				string text2 = APIRequest.requestHTTP.Request("POST", APIRequest.api_url + "login", null, Encoding.UTF8.GetBytes(s), true, null, 60000);
				JObject jobject = JObject.Parse(text2);
				int num = Convert.ToInt32(jobject["code"].ToString());
				bool flag = num == 200;
				if (flag)
				{
					users = new Users();
					users.name = jobject["data"][0]["name"].ToString();
					users.email = jobject["data"][0]["email"].ToString();
					users.id = Convert.ToInt32(jobject["data"][0]["user_id"].ToString());
					users.token = jobject["data"][0]["token"].ToString();
					users.totalMoney = Convert.ToDouble(jobject["data"][0]["totalMoney"].ToString());
					bool flag2 = jobject["license"].ToArray<JToken>().Count<JToken>() > 0;
					if (flag2)
					{
						users.listLicense = new List<Licenses>();
						for (int i = 0; i < jobject["license"].ToArray<JToken>().Count<JToken>(); i++)
						{
							users.listLicense.Add(new Licenses
							{
								timeExpired = Convert.ToDateTime(jobject["license"][i]["time_expired"].ToString()),
								typeProduct = jobject["license"][i]["name"].ToString()
							});
						}
					}
				}
				result = users;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002444 File Offset: 0x00000644
		public static bool BuyProduct(string token, string user_id, string mac_address, string type_product = "facebook", string type_reg = "register", double xuMua = 0.0, int typePackage = 1)
		{
			IniFile iniFile = new IniFile("update.ini");
			string text = iniFile.Read("Version", "Infor");
			APIRequest.requestHTTP.SetDefaultHeaders(new string[]
			{
				"token:" + token
			});
			string s = string.Concat(new string[]
			{
				"mac_address=",
				mac_address,
				"&user_id=",
				user_id,
				"&type_proc=",
				type_product,
				"&xuMua=",
				xuMua.ToString(),
				"&type_reg=",
				type_reg,
				"&typePackage=",
				typePackage.ToString(),
				"&rb_version=",
				text
			});
			string text2 = string.Empty;
			text2 = APIRequest.requestHTTP.Request("POST", APIRequest.api_url + "registerProduct", null, Encoding.UTF8.GetBytes(s), true, null, 60000);
			bool flag = text2 != "";
			if (flag)
			{
				JObject jobject = JObject.Parse(text2);
				int num = Convert.ToInt32(jobject["code"].ToString());
				bool flag2 = num == 200;
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002588 File Offset: 0x00000788
		public static string checkLicenseKey(string token, string user_id, string mac_address, string type_product = "facebook")
		{
			IniFile iniFile = new IniFile("update.ini");
			string text = iniFile.Read("Version", "Infor");
			APIRequest.requestHTTP.SetDefaultHeaders(new string[]
			{
				"token:" + token
			});
			string s = string.Concat(new string[]
			{
				"mac_address=",
				mac_address,
				"&user_id=",
				user_id,
				"&type_proc=",
				type_product,
				"&rb_version=",
				text
			});
			string text2 = string.Empty;
			text2 = APIRequest.requestHTTP.Request("POST", APIRequest.api_url + "checkLicenseKey", null, Encoding.UTF8.GetBytes(s), true, null, 60000);
			bool flag = text2 != "";
			if (flag)
			{
				JObject jobject = JObject.Parse(text2);
				int num = Convert.ToInt32(jobject["code"].ToString());
				bool flag2 = num == 200;
				if (flag2)
				{
					return jobject["data"][0]["time_expired"].ToString();
				}
			}
			return string.Empty;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000026C0 File Offset: 0x000008C0
		public static double updateTongXu(string user_id, string email, string token)
		{
			IniFile iniFile = new IniFile("update.ini");
			string text = iniFile.Read("Version", "Infor");
			APIRequest.requestHTTP.SetDefaultHeaders(new string[]
			{
				"token:" + token
			});
			string s = string.Concat(new string[]
			{
				"email=",
				email,
				"&user_id=",
				user_id,
				"&rb_version=",
				text
			});
			string text2 = string.Empty;
			text2 = APIRequest.requestHTTP.Request("POST", APIRequest.api_url + "capnhatxu", null, Encoding.UTF8.GetBytes(s), true, null, 60000);
			bool flag = text2 != "";
			if (flag)
			{
				JObject jobject = JObject.Parse(text2);
				int num = Convert.ToInt32(jobject["code"].ToString());
				bool flag2 = num == 200;
				if (flag2)
				{
					return Convert.ToDouble(jobject["tongXu"].ToString());
				}
			}
			return 0.0;
		}

		// Token: 0x04000004 RID: 4
		private static string api_url = "https://rabbitsocialtools.com/api/";

		// Token: 0x04000005 RID: 5
		private static RequestHTTP requestHTTP = new RequestHTTP();
	}
}
