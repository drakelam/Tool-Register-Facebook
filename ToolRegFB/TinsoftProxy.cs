using System;
using System.Collections.Generic;
using System.Net;
using HttpRequest;
using Newtonsoft.Json.Linq;

namespace ToolRegFB
{
	// Token: 0x02000050 RID: 80
	internal class TinsoftProxy
	{
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0003A768 File Offset: 0x00038968
		// (set) Token: 0x06000334 RID: 820 RVA: 0x0003A770 File Offset: 0x00038970
		public string api_key { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000335 RID: 821 RVA: 0x0003A779 File Offset: 0x00038979
		// (set) Token: 0x06000336 RID: 822 RVA: 0x0003A781 File Offset: 0x00038981
		public string proxy { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x06000337 RID: 823 RVA: 0x0003A78A File Offset: 0x0003898A
		// (set) Token: 0x06000338 RID: 824 RVA: 0x0003A792 File Offset: 0x00038992
		public string ip { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000339 RID: 825 RVA: 0x0003A79B File Offset: 0x0003899B
		// (set) Token: 0x0600033A RID: 826 RVA: 0x0003A7A3 File Offset: 0x000389A3
		public int port { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x0600033B RID: 827 RVA: 0x0003A7AC File Offset: 0x000389AC
		// (set) Token: 0x0600033C RID: 828 RVA: 0x0003A7B4 File Offset: 0x000389B4
		public int timeout { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600033D RID: 829 RVA: 0x0003A7BD File Offset: 0x000389BD
		// (set) Token: 0x0600033E RID: 830 RVA: 0x0003A7C5 File Offset: 0x000389C5
		public int next_change { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0003A7CE File Offset: 0x000389CE
		// (set) Token: 0x06000340 RID: 832 RVA: 0x0003A7D6 File Offset: 0x000389D6
		public int location { get; set; }

		// Token: 0x06000341 RID: 833 RVA: 0x0003A7E0 File Offset: 0x000389E0
		public TinsoftProxy(string api_key, int limit_theads_use, int location = 0)
		{
			this.api_key = api_key;
			this.proxy = "";
			this.ip = "";
			this.port = 0;
			this.timeout = 0;
			this.next_change = 0;
			this.location = location;
			this.limit_theads_use = limit_theads_use;
			this.dangSuDung = 0;
			this.daSuDung = 0;
			this.canChangeIP = true;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0003A8A0 File Offset: 0x00038AA0
		public string TryToGetMyIP()
		{
			object obj = this.k1;
			object obj2 = obj;
			string result;
			lock (obj2)
			{
				bool flag2 = this.dangSuDung == 0;
				if (flag2)
				{
					bool flag3 = this.daSuDung > 0 && this.daSuDung < this.limit_theads_use;
					if (flag3)
					{
						bool flag4 = this.GetTimeOut() < 30 && !this.ChangeProxy();
						if (flag4)
						{
							return "0";
						}
					}
					else
					{
						bool flag5 = !this.ChangeProxy();
						if (flag5)
						{
							return "0";
						}
					}
				}
				else
				{
					bool flag6 = this.daSuDung >= this.limit_theads_use;
					if (flag6)
					{
						return "2";
					}
					bool flag7 = this.GetTimeOut() < 30 && !this.ChangeProxy();
					if (flag7)
					{
						return "0";
					}
				}
				this.daSuDung++;
				this.dangSuDung++;
				result = "1";
			}
			return result;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0003A9D0 File Offset: 0x00038BD0
		public void DecrementDangSuDung()
		{
			object obj = this.k;
			object obj2 = obj;
			lock (obj2)
			{
				this.dangSuDung--;
				bool flag2 = this.dangSuDung == 0 && this.daSuDung == this.limit_theads_use;
				if (flag2)
				{
					this.daSuDung = 0;
				}
			}
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0003AA48 File Offset: 0x00038C48
		public bool ChangeProxy()
		{
			object obj = this.k;
			object obj2 = obj;
			bool result;
			lock (obj2)
			{
				bool flag2 = this.checkLastRequest();
				if (flag2)
				{
					this.errorCode = "";
					this.next_change = 0;
					this.proxy = "";
					this.ip = "";
					this.port = 0;
					this.timeout = 0;
					string svcontent = this.getSVContent(string.Concat(new object[]
					{
						this.svUrl,
						"/api/changeProxy.php?key=",
						this.api_key,
						"&location=",
						this.location
					}));
					bool flag3 = svcontent != "";
					if (flag3)
					{
						try
						{
							JObject jobject = JObject.Parse(svcontent);
							bool flag4 = bool.Parse(jobject["success"].ToString());
							if (flag4)
							{
								this.proxy = jobject["proxy"].ToString();
								string[] array = this.proxy.Split(new char[]
								{
									':'
								});
								this.ip = array[0];
								this.port = int.Parse(array[1]);
								this.timeout = int.Parse(jobject["timeout"].ToString());
								this.next_change = int.Parse(jobject["next_change"].ToString());
								this.errorCode = "";
								return true;
							}
							this.errorCode = jobject["description"].ToString();
							this.next_change = int.Parse(jobject["next_change"].ToString());
							goto IL_1CE;
						}
						catch
						{
							goto IL_1CE;
						}
					}
					this.errorCode = "request server timeout!";
				}
				else
				{
					this.errorCode = "Request so fast!";
				}
				IL_1CE:
				result = false;
			}
			return result;
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0003AC70 File Offset: 0x00038E70
		public string GetProxy()
		{
			while (!this.CheckStatusProxy())
			{
			}
			return this.proxy;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0003AC9C File Offset: 0x00038E9C
		public int GetTimeOut()
		{
			while (!this.CheckStatusProxy())
			{
			}
			return this.timeout;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0003ACC8 File Offset: 0x00038EC8
		public int GetNextChange()
		{
			while (!this.CheckStatusProxy())
			{
			}
			return this.next_change;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0003ACF4 File Offset: 0x00038EF4
		public bool CheckStatusProxy()
		{
			object obj = this.k;
			object obj2 = obj;
			bool result;
			lock (obj2)
			{
				this.errorCode = "";
				this.next_change = 0;
				this.proxy = "";
				this.ip = "";
				this.port = 0;
				this.timeout = 0;
				string svcontent = this.getSVContent(string.Concat(new object[]
				{
					this.svUrl,
					"/api/getProxy.php?key=",
					this.api_key
				}));
				bool flag2 = svcontent != "";
				if (flag2)
				{
					try
					{
						JObject jobject = JObject.Parse(svcontent);
						bool flag3 = bool.Parse(jobject["success"].ToString());
						if (flag3)
						{
							this.proxy = jobject["proxy"].ToString();
							string[] array = this.proxy.Split(new char[]
							{
								':'
							});
							this.ip = array[0];
							this.port = int.Parse(array[1]);
							this.timeout = int.Parse(jobject["timeout"].ToString());
							this.next_change = int.Parse(jobject["next_change"].ToString());
							this.errorCode = "";
							return true;
						}
						this.errorCode = jobject["description"].ToString();
						bool flag4 = jobject["next_change"] != null;
						if (flag4)
						{
							this.next_change = int.Parse(jobject["next_change"].ToString());
						}
						goto IL_1AF;
					}
					catch (Exception)
					{
						goto IL_1AF;
					}
				}
				this.errorCode = "request server timeout!";
				IL_1AF:
				result = false;
			}
			return result;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0003AEFC File Offset: 0x000390FC
		private bool checkLastRequest()
		{
			try
			{
				DateTime dateTime = new DateTime(2001, 1, 1);
				long ticks = DateTime.Now.Ticks - dateTime.Ticks;
				TimeSpan timeSpan = new TimeSpan(ticks);
				int num = (int)timeSpan.TotalSeconds;
				bool flag = num - this.lastRequest >= 10;
				if (flag)
				{
					this.lastRequest = num;
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0003AF84 File Offset: 0x00039184
		private string getSVContent(string url)
		{
			Console.WriteLine(url);
			string text = "";
			try
			{
				using (WebClient webClient = new WebClient())
				{
					text = webClient.DownloadString(url);
				}
				bool flag = string.IsNullOrEmpty(text);
				if (flag)
				{
					text = "";
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0003B000 File Offset: 0x00039200
		private static string GetSVContent(string url)
		{
			Console.WriteLine(url);
			string text = "";
			try
			{
				using (WebClient webClient = new WebClient())
				{
					text = webClient.DownloadString(url);
				}
				bool flag = string.IsNullOrEmpty(text);
				if (flag)
				{
					text = "";
				}
			}
			catch
			{
				text = "";
			}
			return text;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0003B07C File Offset: 0x0003927C
		public static bool CheckApiProxy(string apiProxy)
		{
			string svcontent = TinsoftProxy.GetSVContent("http://proxy.tinsoftsv.com/api/getKeyInfo.php?key=" + apiProxy);
			bool flag = svcontent != "";
			if (flag)
			{
				JObject jobject = JObject.Parse(svcontent);
				bool flag2 = bool.Parse(jobject["success"].ToString());
				if (flag2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0003B0DC File Offset: 0x000392DC
		public static List<string> GetListKey(string api_user)
		{
			List<string> list = new List<string>();
			try
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(true);
				requestHTTP.SetDefaultHeaders(new string[]
				{
					"content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
					"user-agent: Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) coc_coc_browser/82.0.144 Chrome/76.0.3809.144 Safari/537.36"
				});
				string text = requestHTTP.Request("GET", "http://proxy.tinsoftsv.com/api/getUserKeys.php?key=" + api_user, null, null, true, null, 60000);
				JObject jobject = JObject.Parse(text);
				foreach (JToken jtoken in jobject["data"])
				{
					bool flag = Convert.ToBoolean(jtoken["success"].ToString());
					if (flag)
					{
						list.Add(jtoken["key"].ToString());
					}
				}
			}
			catch
			{
			}
			return list;
		}

		// Token: 0x0600034E RID: 846 RVA: 0x0003B1E8 File Offset: 0x000393E8
		public static List<string> GetListCountryTinsoft()
		{
			return new List<string>
			{
				"0|Random",
				"1|Ha Noi",
				"2|Phu Tho",
				"3|Ho Chi Minh",
				"4|Dak Lak",
				"5|Hai Duong",
				"6|Binh Dinh",
				"7|Nghe An",
				"8|Nam Dinh",
				"10|Thai Binh",
				"11|Ha Tinh"
			};
		}

		// Token: 0x04000358 RID: 856
		private object k1 = new object();

		// Token: 0x04000359 RID: 857
		private object k = new object();

		// Token: 0x0400035A RID: 858
		public string errorCode = "";

		// Token: 0x0400035B RID: 859
		private string svUrl = "http://proxy.tinsoftsv.com";

		// Token: 0x0400035C RID: 860
		private int lastRequest = 0;

		// Token: 0x0400035D RID: 861
		public bool canChangeIP = true;

		// Token: 0x0400035E RID: 862
		public int dangSuDung = 0;

		// Token: 0x0400035F RID: 863
		public int daSuDung = 0;

		// Token: 0x04000360 RID: 864
		public int limit_theads_use = 3;
	}
}
