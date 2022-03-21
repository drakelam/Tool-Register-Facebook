using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EAGetMail;
using HttpRequest;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using Newtonsoft.Json.Linq;
using OtpNet;
using xNet;

namespace ToolRegFB
{
	// Token: 0x02000013 RID: 19
	public class Common
	{
		// Token: 0x060000D1 RID: 209 RVA: 0x00006AA4 File Offset: 0x00004CA4
		public static Point GetPointFromIndexPosition(int indexPos, int maxApp = 6)
		{
			Point result = default(Point);
			int num = 2 * Common.getWidthScreen / maxApp;
			int num2 = maxApp / 2;
			while (indexPos > 5)
			{
				indexPos -= 6;
			}
			bool flag = indexPos <= num2 - 1;
			bool flag2 = flag;
			if (flag2)
			{
				result.Y = 0;
			}
			else
			{
				bool flag3 = indexPos < maxApp;
				bool flag4 = flag3;
				if (flag4)
				{
					result.Y = Common.getHeightScreen / 2;
					indexPos -= num2;
				}
			}
			result.X = indexPos * num;
			return result;
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00006B34 File Offset: 0x00004D34
		public static void CreateFolder(string pathFolder)
		{
			try
			{
				bool flag = !Directory.Exists(pathFolder);
				if (flag)
				{
					Directory.CreateDirectory(pathFolder);
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00006B74 File Offset: 0x00004D74
		public static string CalculateMD5Hash(string input)
		{
			MD5 md = MD5.Create();
			byte[] bytes = Encoding.ASCII.GetBytes(input);
			byte[] array = md.ComputeHash(bytes);
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00006BE4 File Offset: 0x00004DE4
		public static string CreateRandomString(int lengText, Random rd = null)
		{
			string text = "";
			bool flag = rd == null;
			if (flag)
			{
				rd = new Random();
			}
			string text2 = "abcdefghijklmnopqrstuvwxyz";
			for (int i = 0; i < lengText; i++)
			{
				text += text2[rd.Next(0, text2.Length)].ToString();
			}
			return text;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00006C50 File Offset: 0x00004E50
		public static bool CheckWithPercent(int percent)
		{
			int num = Common.rd.Next(1, 101);
			return num <= percent;
		}

		// Token: 0x060000D6 RID: 214 RVA: 0x00006C78 File Offset: 0x00004E78
		public static List<string> CloneList(List<string> lstFrom)
		{
			List<string> list = new List<string>();
			try
			{
				for (int i = 0; i < lstFrom.Count; i++)
				{
					list.Add(lstFrom[i]);
				}
			}
			catch
			{
			}
			return list;
		}

		// Token: 0x060000D7 RID: 215 RVA: 0x00006CD0 File Offset: 0x00004ED0
		public static string SpinText(string text, Random rand)
		{
			int num = -1;
			char[] anyOf = new char[]
			{
				'{',
				'}'
			};
			text += "~";
			do
			{
				int num2 = num;
				num = -1;
				while ((num2 = text.IndexOf('{', num2 + 1)) != -1)
				{
					int num3 = num2;
					while ((num3 = text.IndexOfAny(anyOf, num3 + 1)) != -1 && text[num3] != '}')
					{
						bool flag = num == -1;
						if (flag)
						{
							num = num2;
						}
						num2 = num3;
					}
					bool flag2 = num3 != -1;
					if (flag2)
					{
						string[] array = text.Substring(num2 + 1, num3 - 1 - (num2 + 1 - 1)).Split(new char[]
						{
							'|'
						});
						text = text.Remove(num2, num3 - (num2 - 1)).Insert(num2, array[rand.Next(array.Length)]);
					}
				}
			}
			while (num-- != -1);
			return text.Remove(text.Length - 1);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x00006DE0 File Offset: 0x00004FE0
		public static string CheckBalanceSimThue(string apiKey, int timeout = 60, int services = 1001)
		{
			string result = "";
			bool flag = services == 1001;
			bool flag2 = flag;
			if (flag2)
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
				});
				string text = requestHTTP.Request("GET", "https://chothuesimcode.com/api?act=account&apik=" + apiKey, null, null, true, null, 60000);
				JObject jobject = JObject.Parse(text);
				string a = jobject["ResponseCode"].ToString();
				bool flag3 = a == "0";
				bool flag4 = flag3;
				if (flag4)
				{
					result = jobject["Result"]["Balance"].ToString();
				}
			}
			return result;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00006EBC File Offset: 0x000050BC
		public static string CheckBalanceViotp(string token, int timeout = 60, int services = 7)
		{
			string result = "";
			bool flag = services == 7;
			bool flag2 = flag;
			if (flag2)
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
				});
				string text = requestHTTP.Request("GET", "https://api.viotp.com/users/balance?token=" + token, null, null, true, null, 60000);
				JObject jobject = JObject.Parse(text);
				int num = Convert.ToInt32(jobject["status_code"].ToString());
				bool flag3 = num == 200;
				bool flag4 = flag3;
				if (flag4)
				{
					result = jobject["data"]["balance"].ToString();
				}
			}
			return result;
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00006F94 File Offset: 0x00005194
		public static bool CheckKeyCodetextNow(string api, int timeout = 60)
		{
			bool result = false;
			RequestHTTP requestHTTP = new RequestHTTP();
			requestHTTP.SetSSL(SecurityProtocolType.Tls12);
			requestHTTP.SetKeepAlive(true);
			requestHTTP.SetDefaultHeaders(new string[]
			{
				"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
				"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
			});
			string text = requestHTTP.Request("GET", "http://codetextnow.com/api.php?apikey=" + api + "&action=services", null, null, true, null, 60000);
			JArray jarray = JArray.Parse(text);
			bool flag = jarray.Count > 0;
			if (flag)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00007024 File Offset: 0x00005224
		public static string GetPhoneTextNow(string apiKey, ref string idRequest, int timeout = 60, int services = 1)
		{
			string text = "";
			bool flag = services == 1;
			bool flag2 = flag;
			if (flag2)
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
				});
				int tickCount = Environment.TickCount;
				try
				{
					do
					{
						bool flag3 = Environment.TickCount - tickCount >= timeout * 1000;
						bool flag4 = flag3;
						if (flag4)
						{
							break;
						}
						string text2 = requestHTTP.Request("GET", "http://codetextnow.com/api.php?apikey=" + apiKey + "&action=create-request&serviceId=1&count=1", null, null, true, null, 60000);
						JObject jobject = JObject.Parse(text2);
						Thread.Sleep(TimeSpan.FromSeconds(3.0));
						string a = jobject["status"].ToString();
						bool flag5 = a == "200";
						bool flag6 = flag5;
						if (flag6)
						{
							text = jobject["results"]["data"][0]["sdt"].ToString();
							idRequest = jobject["results"]["data"][0]["requestId"].ToString();
						}
					}
					while (text.Equals(""));
				}
				catch
				{
				}
			}
			return text;
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000071C4 File Offset: 0x000053C4
		public static string GetCodeTextNow(string apiKey, string idRequest, int timeout = 60, int services = 1)
		{
			string text = "";
			bool flag = services == 1;
			bool flag2 = flag;
			if (flag2)
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
				});
				int tickCount = Environment.TickCount;
				try
				{
					do
					{
						bool flag3 = Environment.TickCount - tickCount >= timeout * 1000;
						bool flag4 = flag3;
						if (flag4)
						{
							break;
						}
						string text2 = requestHTTP.Request("GET", "http://codetextnow.com/api.php?apikey=" + apiKey + "&action=data-request&requestId=" + idRequest, null, null, true, null, 60000);
						JObject jobject = JObject.Parse(text2);
						Thread.Sleep(TimeSpan.FromSeconds(3.0));
						string a = jobject["status"].ToString();
						bool flag5 = a == "200";
						bool flag6 = flag5;
						if (flag6)
						{
							text = jobject["data"][0]["otp"].ToString();
						}
					}
					while (text.Equals(""));
				}
				catch
				{
				}
			}
			return text;
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000731C File Offset: 0x0000551C
		public static string GetCodeOTPMMO(string apiKey, string phone, int timeout = 120)
		{
			string text = "";
			RequestHTTP requestHTTP = new RequestHTTP();
			requestHTTP.SetSSL(SecurityProtocolType.Tls12);
			requestHTTP.SetKeepAlive(true);
			requestHTTP.SetDefaultHeaders(new string[]
			{
				"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
				"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
			});
			int tickCount = Environment.TickCount;
			try
			{
				do
				{
					bool flag = Environment.TickCount - tickCount >= timeout * 1000;
					bool flag2 = flag;
					if (flag2)
					{
						break;
					}
					string text2 = requestHTTP.Request("GET", "https://otpmmo.online/textnow/api.php?apikey=" + apiKey + "&type=getotp&sdt=" + phone, null, null, true, null, 60000);
					bool flag3 = text2 == "";
					if (!flag3)
					{
						JArray jarray = JArray.Parse(text2);
						Thread.Sleep(TimeSpan.FromSeconds(3.0));
						string text3 = jarray[0]["otp"].ToString();
						string[] array = text3.Split(new char[]
						{
							' '
						});
						bool flag4 = array[1] != "";
						if (flag4)
						{
							text = array[1];
						}
					}
				}
				while (text.Equals(""));
			}
			catch
			{
			}
			return text;
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00007464 File Offset: 0x00005664
		public static bool CheckTimeIsValid()
		{
			bool result = false;
			string a = DateTime.Now.ToShortDateString();
			bool flag = a == DateTime.Now.ToString("dd/MM/yyyy");
			if (flag)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x060000DF RID: 223 RVA: 0x000074AC File Offset: 0x000056AC
		public static string CheckBalanceAnycaptcha(string apiKey, int timeout = 60)
		{
			string result = "";
			RequestHTTP requestHTTP = new RequestHTTP();
			requestHTTP.SetSSL(SecurityProtocolType.Tls12);
			requestHTTP.SetKeepAlive(true);
			requestHTTP.SetDefaultHeaders(new string[]
			{
				"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
				"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
			});
			string s = string.Concat(new string[]
			{
				"clientKey=",
				apiKey
			});
			string text = requestHTTP.Request("POST", "https://api.anycaptcha.com/getBalance", null, Encoding.UTF8.GetBytes(s), true, null, 60000);
			JObject jobject = JObject.Parse(text);
			string value = jobject["errorId"].ToString();
			bool flag = Convert.ToInt32(value) == 0;
			bool flag2 = flag;
			if (flag2)
			{
				result = jobject["balance"].ToString();
			}
			return result;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00007580 File Offset: 0x00005780
		public static string GetOtpHotMailNew(string username, string password, int timeout = 90, string oldOtp = "00000")
		{
			bool flag = false;
			string text = "";
			int tickCount = Environment.TickCount;
			try
			{
				for (;;)
				{
					bool flag2 = Environment.TickCount - tickCount > timeout * 1000;
					bool flag3 = flag2;
					if (flag3)
					{
						break;
					}
					MailServer mailServer = new MailServer("imap-mail.outlook.com", username, password, 1);
					MailClient mailClient = new MailClient("TryIt");
					mailServer.SSLConnection = true;
					mailServer.Port = 993;
					Thread.Sleep(5000);
					try
					{
						mailClient.Connect(mailServer);
						mailClient.GetMailInfosParam.Reset();
						MailInfo[] mailInfos = mailClient.GetMailInfos();
						for (int i = 0; i < mailInfos.Length; i++)
						{
							Mail mail = mailClient.GetMail(mailInfos[i]);
							mailClient.MarkAsRead(mailInfos[i], true);
							bool flag4 = mail.From.Address.Contains("registration@facebookmail.com");
							bool flag5 = flag4;
							if (flag5)
							{
								Match match = Regex.Match(mail.Subject, "\\d+\\s");
								bool success = match.Success;
								bool flag6 = success;
								if (flag6)
								{
									text = match.Value.Trim();
									bool flag7 = (!text.Equals("") && text != oldOtp) || oldOtp == "00000";
									bool flag8 = flag7;
									if (flag8)
									{
										flag = true;
										break;
									}
								}
							}
						}
						mailClient.Quit();
						mailClient.Close();
					}
					catch
					{
						mailClient.Quit();
						mailClient.Close();
					}
					bool flag9 = flag;
					if (flag9)
					{
						goto Block_5;
					}
				}
				return "";
				Block_5:;
			}
			catch
			{
			}
			return text;
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000776C File Offset: 0x0000596C
		public static string GetCaptchaResponse(string AntiKey, string Website, string SiteKey)
		{
			string result = "";
			try
			{
				HttpRequest httpRequest = new HttpRequest();
				httpRequest.KeepAlive = true;
				httpRequest.Cookies = new CookieDictionary(false);
				httpRequest.AddHeader(0, "application/json, text/javascript, */*; q=0.01");
				httpRequest.AddHeader(2, "en-US,en;q=0.5");
				httpRequest.UserAgent = Http.ChromeUserAgent();
				string text = Common.Base64Decode("ewogICAgImNsaWVudEtleSI6ICJ4eHh4eHh4eHgiLAogICAgInRhc2siOiB7CiAgICAgICAgInR5cGUiOiAiRnVuQ2FwdGNoYVRhc2tQcm94eWxlc3MiLAogICAgICAgICJ3ZWJzaXRlVVJMIjogInp6enp6enp6enoiLAogICAgICAgICJ3ZWJzaXRlUHVibGljS2V5IjogInl5eXl5eXl5eSIKICAgIH0KfQ==");
				text = text.Replace("xxxxxxxxx", AntiKey);
				text = text.Replace("yyyyyyyyy", SiteKey);
				text = text.Replace("zzzzzzzzzz", Website);
				string text2 = httpRequest.Post("https://api.anycaptcha.com/createTask", text, "application/json").ToString();
				bool flag = text2.Contains("\"errorId\":0");
				if (flag)
				{
					string value = Regex.Match(text2, "taskId\":(.*?)}").Groups[1].Value;
					string text3 = Common.Base64Decode("ewogICAgImNsaWVudEtleSI6Inl5eXl5eXl5eSIsCiAgICAidGFza0lkIjogeHh4Cn0=");
					text3 = text3.Replace("yyyyyyyyy", AntiKey);
					text3 = text3.Replace("xxx", value);
					for (int i = 0; i < 62; i++)
					{
						text2 = httpRequest.Post("https://api.anycaptcha.com/getTaskResult", text3, "application/json").ToString();
						bool flag2 = !text2.Contains("processing");
						if (flag2)
						{
							string value2 = Regex.Match(text2, "token\":\"(.*?)\"").Groups[1].Value;
							result = value2;
							goto IL_18D;
						}
						Thread.Sleep(1000);
						bool flag3 = i > 60;
						if (flag3)
						{
							Console.WriteLine("Time out!!!");
							return result;
						}
					}
				}
				return result;
			}
			catch
			{
			}
			IL_18D:
			return result;
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000792C File Offset: 0x00005B2C
		public static string CheckLiveWall(string uid)
		{
			RequestHTTP requestHTTP = new RequestHTTP();
			requestHTTP.SetSSL(SecurityProtocolType.Tls12);
			requestHTTP.SetKeepAlive(true);
			requestHTTP.SetDefaultHeaders(new string[]
			{
				"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
				"user-agent: " + SetupFolder.GetUseragentIPhone(Common.rd)
			});
			try
			{
				string text = requestHTTP.Request("POST", "https://graph.facebook.com/" + uid + "/picture?redirect=false", null, null, true, null, 60000);
				bool flag = !string.IsNullOrEmpty(text);
				if (flag)
				{
					bool flag2 = text.Contains("height") && text.Contains("width");
					if (flag2)
					{
						return "1|";
					}
					return "0|";
				}
			}
			catch (Exception)
			{
			}
			return "2|";
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x00007A0C File Offset: 0x00005C0C
		public static string RunCMD(string fileName, string cmd, int timeout = 10)
		{
			Process process = new Process();
			process.StartInfo.FileName = fileName;
			process.StartInfo.Arguments = cmd;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.StandardOutputEncoding = Encoding.UTF8;
			process.StartInfo.StandardErrorEncoding = Encoding.UTF8;
			StringBuilder output = new StringBuilder();
			process.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
			{
				bool flag2 = !string.IsNullOrEmpty(e.Data);
				if (flag2)
				{
					output.Append(e.Data + "\n");
				}
			};
			process.Start();
			process.BeginOutputReadLine();
			bool flag = timeout < 0;
			if (flag)
			{
				process.WaitForExit();
			}
			else
			{
				process.WaitForExit(timeout * 1000);
			}
			process.Close();
			return output.ToString();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00007AFC File Offset: 0x00005CFC
		public static string CheckProxy(string proxy, int typeProxy)
		{
			string result = "";
			try
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: " + SetupFolder.GetUseragentIPhone(Common.rd)
				});
				WebProxy webProxy = new WebProxy(proxy, false);
				result = requestHTTP.Request("GET", "https://api64.ipify.org/", null, null, true, webProxy, 60000);
			}
			catch (Exception)
			{
				result = Common.CheckProxy2(proxy, typeProxy);
			}
			return result;
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00007BA0 File Offset: 0x00005DA0
		public static string CheckProxy2(string proxy, int typeProxy)
		{
			string result = "";
			try
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: " + SetupFolder.GetUseragentIPhone(Common.rd)
				});
				WebProxy webProxy = new WebProxy(proxy, false);
				result = requestHTTP.Request("GET", "http://v4v6.ipv6-test.com/api/myip.php", null, null, true, webProxy, 60000);
			}
			catch (Exception ex)
			{
			}
			return result;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x00007C3C File Offset: 0x00005E3C
		public static void ClearCacheLDPlayer(string path)
		{
			int num = Directory.GetDirectories(path + "\\vms", "*", SearchOption.TopDirectoryOnly).Length;
			for (int i = 0; i < num; i++)
			{
				bool flag = i == 0;
				if (!flag)
				{
					bool flag2 = Directory.Exists(path + "\\vms\\leidian" + i.ToString());
					if (flag2)
					{
						string pathFolder = path + "\\vms\\leidian" + i.ToString();
						Common.DeleteFolder(pathFolder);
					}
				}
			}
			int num2 = Directory.GetFiles(path + "\\vms\\config", "*.config", SearchOption.TopDirectoryOnly).Length;
			for (int j = 0; j < num2; j++)
			{
				bool flag3 = j == 0;
				if (!flag3)
				{
					bool flag4 = File.Exists(path + "\\vms\\config\\leidian" + j.ToString() + ".config");
					if (flag4)
					{
						string pathFile = path + "\\vms\\config\\leidian" + j.ToString() + ".config";
						Common.DeleteFile(pathFile);
					}
				}
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00007D40 File Offset: 0x00005F40
		public static bool DeleteFolder(string pathFolder)
		{
			try
			{
				Directory.Delete(pathFolder, true);
				return true;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00007D78 File Offset: 0x00005F78
		public static bool ResetDcom(string profileDcom)
		{
			string text = Common.RunCMD("rasdial.exe", "\"" + profileDcom + "\"", 3);
			bool flag = text.Contains("Successfully connected to ");
			bool flag2;
			if (flag)
			{
				flag2 = true;
			}
			else
			{
				bool flag3 = text.Contains("You are already connected to ");
				if (flag3)
				{
					for (int i = 0; i < 3; i++)
					{
						text = Common.RunCMD("rasdial.exe", "\"" + profileDcom + "\" /disconnect", 3);
						bool flag4 = text.Trim() == "Command completed successfully.";
						if (flag4)
						{
							flag2 = true;
							Common.DelayTime(1.0);
							bool flag5 = flag2;
							if (flag5)
							{
								for (int j = 0; j < 3; j++)
								{
									text = Common.RunCMD("rasdial.exe", "\"" + profileDcom + "\"", 3);
									bool flag6 = text.Contains("Successfully connected to ");
									if (flag6)
									{
										flag2 = true;
										break;
									}
									Common.DelayTime(1.0);
								}
							}
							Common.DelayTime(1.0);
							return flag2;
						}
						Common.DelayTime(1.0);
					}
				}
				flag2 = false;
			}
			return flag2;
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00007EC8 File Offset: 0x000060C8
		public static string GetPhoneSimCode(string apikey, string typeMail, int timeOut = 60)
		{
			string str = "";
			int num = 0;
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			bool flag = typeMail == "hotmail";
			if (flag)
			{
				num = 1017;
			}
			else
			{
				num = 1009;
			}
			string text = "";
			for (int i = 0; i < 5; i++)
			{
				try
				{
					string text2 = requestXNet.RequestGet("https://chothuesimcode.com/api?act=number&apik=" + apikey + "&appId=" + num.ToString());
					JObject jobject = JObject.Parse(text2);
					text = jobject["Result"]["Id"].ToString();
					bool flag2 = text != "";
					if (flag2)
					{
						str = jobject["Result"]["Number"].ToString();
						break;
					}
					Thread.Sleep(3000);
				}
				catch
				{
					throw;
				}
			}
			return text + "|" + str;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00007FE4 File Offset: 0x000061E4
		public static string GetOTPSimCode(string apikey, string id_order, int timeOut = 120)
		{
			string text = "";
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount <= timeOut * 1000)
			{
				string text2 = requestXNet.RequestGet("https://chothuesimcode.com/api?act=code&apik=" + apikey + "&id=" + id_order);
				JObject jobject = JObject.Parse(text2);
				bool flag = jobject["ResponseCode"].ToString() == "0";
				if (flag)
				{
					try
					{
						text = jobject["Result"]["Code"].ToString();
						bool flag2 = text != "";
						if (flag2)
						{
							break;
						}
						Thread.Sleep(3000);
					}
					catch
					{
					}
				}
			}
			return text;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000080D8 File Offset: 0x000062D8
		public static string GetCodeSimThue(string apiKey, string idRequest, int timeout = 60, int services = 1001)
		{
			string text = "";
			bool flag = services == 1001;
			bool flag2 = flag;
			if (flag2)
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
				});
				int tickCount = Environment.TickCount;
				try
				{
					do
					{
						bool flag3 = Environment.TickCount - tickCount >= timeout * 1000;
						bool flag4 = flag3;
						if (flag4)
						{
							break;
						}
						string text2 = requestHTTP.Request("GET", "https://chothuesimcode.com/api?act=code&apik=" + apiKey + "&id=" + idRequest, null, null, true, null, 60000);
						JObject jobject = JObject.Parse(text2);
						Thread.Sleep(TimeSpan.FromSeconds(3.0));
						string a = jobject["ResponseCode"].ToString();
						bool flag5 = a == "0";
						bool flag6 = flag5;
						if (flag6)
						{
							text = jobject["Result"]["Code"].ToString();
						}
					}
					while (text.Equals(""));
				}
				catch
				{
				}
			}
			return text;
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00008228 File Offset: 0x00006428
		public static string GetPhoneSimThue(string apiKey, ref string idRequest, int timeout = 60, int services = 1001)
		{
			string text = "";
			bool flag = services == 1001;
			bool flag2 = flag;
			if (flag2)
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
				});
				int tickCount = Environment.TickCount;
				try
				{
					do
					{
						bool flag3 = Environment.TickCount - tickCount >= timeout * 1000;
						bool flag4 = flag3;
						if (flag4)
						{
							break;
						}
						string text2 = requestHTTP.Request("GET", "https://chothuesimcode.com/api?act=number&apik=" + apiKey + "&appId=1001", null, null, true, null, 60000);
						JObject jobject = JObject.Parse(text2);
						Thread.Sleep(TimeSpan.FromSeconds(3.0));
						string a = jobject["ResponseCode"].ToString();
						bool flag5 = a == "0";
						bool flag6 = flag5;
						if (flag6)
						{
							text = jobject["Result"]["Number"].ToString();
							idRequest = jobject["Result"]["Id"].ToString();
						}
					}
					while (text.Equals(""));
				}
				catch
				{
				}
			}
			return text;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x00008394 File Offset: 0x00006594
		public static string GetPhoneOtpmmo(string apiKey, int timeout = 60)
		{
			string text = "";
			RequestHTTP requestHTTP = new RequestHTTP();
			requestHTTP.SetSSL(SecurityProtocolType.Tls12);
			requestHTTP.SetKeepAlive(true);
			requestHTTP.SetDefaultHeaders(new string[]
			{
				"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
				"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
			});
			int tickCount = Environment.TickCount;
			try
			{
				do
				{
					bool flag = Environment.TickCount - tickCount >= timeout * 1000;
					bool flag2 = flag;
					if (flag2)
					{
						break;
					}
					string text2 = requestHTTP.Request("GET", "https://otpmmo.online/textnow/api.php?apikey=" + apiKey + "&type=getphone&qty=1", null, null, true, null, 60000);
					Thread.Sleep(TimeSpan.FromSeconds(3.0));
					bool flag3 = text2 != "";
					if (flag3)
					{
						text = text2;
					}
				}
				while (text.Equals(""));
			}
			catch
			{
			}
			return text;
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000848C File Offset: 0x0000668C
		[DebuggerStepThrough]
		private static Task<string> GetURI(Uri u)
		{
			Common.<GetURI>d__32 <GetURI>d__ = new Common.<GetURI>d__32();
			<GetURI>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<GetURI>d__.u = u;
			<GetURI>d__.<>1__state = -1;
			<GetURI>d__.<>t__builder.Start<Common.<GetURI>d__32>(ref <GetURI>d__);
			return <GetURI>d__.<>t__builder.Task;
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000084D0 File Offset: 0x000066D0
		public static string RequestGet(string url)
		{
			string result;
			try
			{
				new HttpClient();
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				Task<string> task = Task.Run<string>(() => Common.GetURI(new Uri(url)));
				task.Wait();
				result = task.Result;
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "Request get");
				result = "";
			}
			return result;
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00008558 File Offset: 0x00006758
		public static string CheckIP()
		{
			string result = "";
			try
			{
				RequestXNet requestXNet = new RequestXNet("", "", "", 0);
				string text = requestXNet.RequestGet("http://lumtest.com/myip.json");
				bool flag = JObject.Parse(text).ContainsKey("ip");
				if (flag)
				{
					result = JObject.Parse(text)["ip"].ToString();
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x000085E0 File Offset: 0x000067E0
		public static bool ChangeIP(int typeChangeIP, int typeDcom, string profileDcom, string urlHilink)
		{
			bool result = false;
			try
			{
				switch (typeChangeIP)
				{
				case 0:
					return false;
				case 1:
				{
					bool flag = typeDcom == 0;
					if (flag)
					{
						result = Common.ResetDcom(profileDcom);
					}
					break;
				}
				case 4:
				{
					string b = Common.CheckIP();
					IntPtr intPtr = AutoControl.FindWindowHandle(null, "HMA VPN");
					AutoControl.BringToFront(intPtr);
					AutoControl.SendClickOnPosition(AutoControl.FindHandle(intPtr, "Chrome_RenderWidgetHostHWND", "Chrome Legacy Window"), 464, 366, 0, 1);
					Thread.Sleep(10000);
					string b2 = Common.CheckIP();
					int tickCount = Environment.TickCount;
					string a;
					do
					{
						a = Common.CheckIP();
					}
					while (Environment.TickCount - tickCount <= 20000 && (a == b || a == b2));
					bool flag2 = a != b;
					if (flag2)
					{
						result = true;
					}
					break;
				}
				}
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "Error ChangeIP");
			}
			return result;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00008708 File Offset: 0x00006908
		public static string GetPhoneViotp(string apiKey, ref string idRequest, int timeout = 60, int services = 7)
		{
			string text = "";
			bool flag = services == 7;
			bool flag2 = flag;
			if (flag2)
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
				});
				int tickCount = Environment.TickCount;
				try
				{
					do
					{
						bool flag3 = Environment.TickCount - tickCount >= timeout * 1000;
						bool flag4 = flag3;
						if (flag4)
						{
							break;
						}
						string text2 = requestHTTP.Request("GET", "https://api.viotp.com/request/get?token=" + apiKey + "&serviceId=7", null, null, true, null, 60000);
						JObject jobject = JObject.Parse(text2);
						Thread.Sleep(TimeSpan.FromSeconds(3.0));
						int num = Convert.ToInt32(jobject["status_code"].ToString());
						bool flag5 = num == 200;
						bool flag6 = flag5;
						if (flag6)
						{
							text = jobject["data"]["phone_number"].ToString();
							idRequest = jobject["data"]["request_id"].ToString();
						}
					}
					while (text.Equals(""));
				}
				catch
				{
				}
			}
			return text;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x00008870 File Offset: 0x00006A70
		public static string GetPhoneViotp(string apikey, int timeOut = 60)
		{
			string str = "";
			int num = 0;
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			string text = "";
			for (int i = 0; i < 5; i++)
			{
				try
				{
					string text2 = requestXNet.RequestGet("https://api.viotp.com/request/get?token=" + apikey + "&serviceId=5" + num.ToString());
					JObject jobject = JObject.Parse(text2);
					text = jobject["data"]["request_id"].ToString();
					bool flag = text != "";
					if (flag)
					{
						str = jobject["data"]["phone_number"].ToString();
						break;
					}
					Thread.Sleep(3000);
				}
				catch
				{
					throw;
				}
			}
			return text + "|" + str;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000896C File Offset: 0x00006B6C
		public static string GetPhoneTextNow(string apikey, int timeOut = 60)
		{
			string str = "";
			int num = 0;
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			string text = "";
			for (int i = 0; i < 5; i++)
			{
				try
				{
					string text2 = requestXNet.RequestGet("http://codetextnow.com/api.php?apikey=" + apikey + "&action=create-request&serviceId=1&count=1" + num.ToString());
					JObject jobject = JObject.Parse(text2);
					text = jobject["results"]["data"][0]["requestId"].ToString();
					bool flag = text != "";
					if (flag)
					{
						str = jobject["results"]["data"][0]["sdt"].ToString();
						break;
					}
					Thread.Sleep(3000);
				}
				catch
				{
					throw;
				}
			}
			return text + "|" + str;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x00008A90 File Offset: 0x00006C90
		public static string GetPhoneOTPMMO(string apikey, int timeOut = 60)
		{
			string str = "";
			int num = 0;
			RequestXNet requestXNet = new RequestXNet("", "", "", 0);
			string text = "";
			for (int i = 0; i < 5; i++)
			{
				try
				{
					string text2 = requestXNet.RequestGet("https://otpmmo.xyz/textnow/api.php?apikey=" + apikey + "&type=getphone&qty=1" + num.ToString());
					bool flag = text2 != "";
					if (flag)
					{
						text = text2;
					}
					bool flag2 = text != "";
					if (flag2)
					{
						str = text;
						break;
					}
					Thread.Sleep(3000);
				}
				catch
				{
					throw;
				}
			}
			return text + "|" + str;
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00008B5C File Offset: 0x00006D5C
		public static string GetCodeViotp(string apiKey, string idRequest, int timeout = 60, int services = 7)
		{
			string text = "";
			bool flag = services == 7;
			bool flag2 = flag;
			if (flag2)
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
				});
				int tickCount = Environment.TickCount;
				try
				{
					do
					{
						bool flag3 = Environment.TickCount - tickCount >= timeout * 1000;
						bool flag4 = flag3;
						if (flag4)
						{
							break;
						}
						string text2 = requestHTTP.Request("GET", "https://api.viotp.com/session/get?requestId=" + idRequest + "&token=" + apiKey, null, null, true, null, 60000);
						JObject jobject = JObject.Parse(text2);
						Thread.Sleep(TimeSpan.FromSeconds(3.0));
						int num = Convert.ToInt32(jobject["status_code"].ToString());
						bool flag5 = num == 200;
						bool flag6 = flag5;
						if (flag6)
						{
							text = jobject["data"]["Code"].ToString();
						}
					}
					while (text.Equals(""));
				}
				catch
				{
				}
			}
			return text;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00008CA8 File Offset: 0x00006EA8
		public static void DelayTime(double second)
		{
			Application.DoEvents();
			Thread.Sleep(Convert.ToInt32(second * 1000.0));
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x00008CC8 File Offset: 0x00006EC8
		public static void KillProcess(string nameProcess)
		{
			try
			{
				foreach (Process process in Process.GetProcessesByName(nameProcess))
				{
					process.Kill();
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00008D14 File Offset: 0x00006F14
		public static bool IsNumber(string pValue)
		{
			bool flag = pValue == "";
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				foreach (char c in pValue)
				{
					bool flag2 = !char.IsDigit(c);
					if (flag2)
					{
						return false;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x00008D78 File Offset: 0x00006F78
		public static void FillIndexPossition(ref List<int> lstPossition, int indexPos)
		{
			List<int> list = lstPossition;
			List<int> obj = list;
			lock (obj)
			{
				lstPossition[indexPos] = 0;
			}
		}

		// Token: 0x060000FB RID: 251 RVA: 0x00008DC0 File Offset: 0x00006FC0
		public static string ByPassQRCode(Bitmap bitmap)
		{
			QRCodeDecoder qrcodeDecoder = new QRCodeDecoder();
			return qrcodeDecoder.Decode(new QRCodeBitmapImage(bitmap));
		}

		// Token: 0x060000FC RID: 252 RVA: 0x00008DE4 File Offset: 0x00006FE4
		public static string ReadHTMLCode(string Url)
		{
			string result;
			try
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				result = requestHTTP.Request("GET", Url, null, null, true, null, 60000);
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x00008E30 File Offset: 0x00007030
		public static string GetTotpServer(string input)
		{
			string text = "";
			try
			{
				input = input.Replace(" ", "").Trim();
				string text2 = "http://app.minsoftware.vn/api/2fa1?secret=" + input;
				string text3 = "http://2fa.live/tok/" + input;
				for (int i = 0; i < 5; i++)
				{
					text = "";
					try
					{
						string text4 = Common.ReadHTMLCode(text3);
						bool flag = text4.Contains("token");
						if (flag)
						{
							JObject jobject = JObject.Parse(text4);
							text = jobject["token"].ToString().Trim();
						}
					}
					catch (Exception ex)
					{
						Common.ExportError(ex, text3);
					}
					try
					{
						bool flag2 = text.Trim() == "";
						if (flag2)
						{
							text = Common.ReadHTMLCode(text2);
						}
					}
					catch (Exception ex2)
					{
						Common.ExportError(ex2, text2);
					}
					bool flag3 = !(text != "") || !Common.IsNumber(text);
					if (!flag3)
					{
						for (int j = text.Length; j < 6; j++)
						{
							text = "0" + text;
						}
						break;
					}
					Common.DelayTime(1.0);
				}
			}
			catch
			{
			}
			return text;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x00008FD0 File Offset: 0x000071D0
		public static string GetTotpClient(string input)
		{
			try
			{
				byte[] array = Base32Encoding.ToBytes(input.Trim().Replace(" ", ""));
				Totp totp = new Totp(array, 30, 0, 6, null);
				return totp.ComputeTotp(DateTime.UtcNow);
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "GetTotp(" + input + ")");
			}
			return "";
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000904C File Offset: 0x0000724C
		public static string GetTotp(string input)
		{
			string text = Common.GetTotpServer(input);
			bool flag = text == "";
			if (flag)
			{
				text = Common.GetTotpClient(input);
			}
			return text;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00009080 File Offset: 0x00007280
		public static bool CloseForm(string nameForm)
		{
			try
			{
				FormCollection openForms = Application.OpenForms;
				IEnumerator enumerator = openForms.GetEnumerator();
				while (enumerator.MoveNext())
				{
					Form frm = (Form)enumerator.Current;
					bool flag = frm.Name == nameForm;
					if (flag)
					{
						frm.Invoke(new MethodInvoker(delegate()
						{
							frm.Close();
						}));
						break;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00009114 File Offset: 0x00007314
		public static string convertToUnSign3(string s)
		{
			Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
			string input = s.Normalize(NormalizationForm.FormD);
			return regex.Replace(input, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
		}

		// Token: 0x06000102 RID: 258 RVA: 0x00009160 File Offset: 0x00007360
		public static string CreateRandomPassword(string tienTo)
		{
			tienTo = Common.convertToUnSign3(tienTo);
			tienTo = tienTo.ToLower().Replace(" ", "");
			string text = "0123456789";
			Random random = new Random();
			int num = 4;
			char[] array = new char[4];
			for (int i = 0; i < num; i++)
			{
				tienTo += text[random.Next(0, text.Length)].ToString();
			}
			return tienTo;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x000091E8 File Offset: 0x000073E8
		public static bool DeleteFile(string pathFile)
		{
			try
			{
				File.Delete(pathFile);
				return true;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000921C File Offset: 0x0000741C
		public static List<string> RemoveEmptyItems(List<string> lst)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < lst.Count; i++)
			{
				string text = lst[i].Trim();
				bool flag = text != "";
				if (flag)
				{
					list.Add(text);
				}
			}
			return list;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x00009278 File Offset: 0x00007478
		public static string CreateRandomStringNumber(int lengText, Random rd = null)
		{
			string text = "";
			bool flag = rd == null;
			if (flag)
			{
				rd = new Random();
			}
			string text2 = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			for (int i = 0; i < lengText; i++)
			{
				text += text2[rd.Next(0, text2.Length)].ToString();
			}
			return text;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x000092E4 File Offset: 0x000074E4
		public static string Md5Encode(string text, string type = "X2")
		{
			MD5 md = MD5.Create();
			byte[] array = md.ComputeHash(Encoding.UTF8.GetBytes(text));
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString(type));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000107 RID: 263 RVA: 0x00009348 File Offset: 0x00007548
		public static string CreateRandomNumber(int leng, Random rd = null)
		{
			string text = "";
			bool flag = rd == null;
			if (flag)
			{
				rd = new Random();
			}
			string text2 = "0123456789";
			for (int i = 0; i < leng; i++)
			{
				text += text2[rd.Next(0, text2.Length)].ToString();
			}
			return text;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000093B4 File Offset: 0x000075B4
		public static string Base64Decode(string base64Encoded)
		{
			byte[] bytes = Convert.FromBase64String(base64Encoded);
			return Encoding.UTF8.GetString(bytes);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x000093D8 File Offset: 0x000075D8
		public static void ExportError(Exception ex, string error = "")
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter("log\\log.txt", true))
				{
					streamWriter.WriteLine("-----------------------------------------------------------------------------");
					streamWriter.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
					bool flag = error != "";
					if (flag)
					{
						streamWriter.WriteLine("Error: " + error);
					}
					streamWriter.WriteLine();
					bool flag2 = ex != null;
					if (flag2)
					{
						streamWriter.WriteLine("Type: " + ex.GetType().FullName);
						streamWriter.WriteLine("Message: " + ex.Message);
						streamWriter.WriteLine("StackTrace: " + ex.StackTrace);
						ex = ex.InnerException;
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600010A RID: 266 RVA: 0x000094DC File Offset: 0x000076DC
		public static int GetIndexOfPossitionApp(ref List<int> lstPossition)
		{
			int result = 0;
			List<int> list = lstPossition;
			List<int> obj = list;
			lock (obj)
			{
				for (int i = 0; i < lstPossition.Count; i++)
				{
					bool flag2 = lstPossition[i] == 0;
					if (flag2)
					{
						result = i;
						lstPossition[i] = 1;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x00009564 File Offset: 0x00007764
		public static bool CheckFormIsOpenning(string nameForm)
		{
			try
			{
				FormCollection openForms = Application.OpenForms;
				foreach (object obj in openForms)
				{
					Form form = (Form)obj;
					bool flag = form.Name == nameForm;
					if (flag)
					{
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x04000052 RID: 82
		private static Random rd = new Random();

		// Token: 0x04000053 RID: 83
		public static int getWidthScreen;

		// Token: 0x04000054 RID: 84
		public static int getHeightScreen;
	}
}
