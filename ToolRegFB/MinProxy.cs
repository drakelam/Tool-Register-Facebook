using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ToolRegFB
{
	// Token: 0x02000047 RID: 71
	internal class MinProxy
	{
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000300 RID: 768 RVA: 0x00037B88 File Offset: 0x00035D88
		// (set) Token: 0x06000301 RID: 769 RVA: 0x00037B90 File Offset: 0x00035D90
		public string api_key { get; set; }

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000302 RID: 770 RVA: 0x00037B99 File Offset: 0x00035D99
		// (set) Token: 0x06000303 RID: 771 RVA: 0x00037BA1 File Offset: 0x00035DA1
		public string proxy { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000304 RID: 772 RVA: 0x00037BAA File Offset: 0x00035DAA
		// (set) Token: 0x06000305 RID: 773 RVA: 0x00037BB2 File Offset: 0x00035DB2
		public int typeProxy { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000306 RID: 774 RVA: 0x00037BBB File Offset: 0x00035DBB
		// (set) Token: 0x06000307 RID: 775 RVA: 0x00037BC3 File Offset: 0x00035DC3
		public string ip { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000308 RID: 776 RVA: 0x00037BCC File Offset: 0x00035DCC
		// (set) Token: 0x06000309 RID: 777 RVA: 0x00037BD4 File Offset: 0x00035DD4
		public int timeout { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x0600030A RID: 778 RVA: 0x00037BDD File Offset: 0x00035DDD
		// (set) Token: 0x0600030B RID: 779 RVA: 0x00037BE5 File Offset: 0x00035DE5
		public int port { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x0600030C RID: 780 RVA: 0x00037BEE File Offset: 0x00035DEE
		// (set) Token: 0x0600030D RID: 781 RVA: 0x00037BF6 File Offset: 0x00035DF6
		public int next_change { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x0600030E RID: 782 RVA: 0x00037BFF File Offset: 0x00035DFF
		// (set) Token: 0x0600030F RID: 783 RVA: 0x00037C07 File Offset: 0x00035E07
		public string ip_allow { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000310 RID: 784 RVA: 0x00037C10 File Offset: 0x00035E10
		// (set) Token: 0x06000311 RID: 785 RVA: 0x00037C18 File Offset: 0x00035E18
		public string your_ip { get; set; }

		// Token: 0x06000312 RID: 786 RVA: 0x00037C24 File Offset: 0x00035E24
		public MinProxy(string api_key, int typeProxy, int limit_theads_use)
		{
			this.api_key = api_key;
			this.proxy = "";
			this.ip = "";
			this.port = 0;
			this.next_change = 0;
			this.typeProxy = typeProxy;
			this.limit_theads_use = limit_theads_use;
			this.lastRequest = 0;
			this.dangSuDung = 0;
			this.daSuDung = 0;
			this.ip_allow = "";
			this.your_ip = "";
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00037CE4 File Offset: 0x00035EE4
		public static bool CheckApiProxy(string apiProxy)
		{
			string text = MinProxy.RequestGet("http://dash.minproxy.vn/api/rotating/v1/proxy/get-status?api_key=" + apiProxy);
			bool flag = text != "";
			if (flag)
			{
				try
				{
					JObject jobject = JObject.Parse(text);
					bool flag2 = jobject.ContainsKey("code");
					if (flag2)
					{
						bool flag3 = jobject["code"].ToString() == "1";
						if (flag3)
						{
							return true;
						}
					}
				}
				catch
				{
					throw;
				}
			}
			return false;
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00037D74 File Offset: 0x00035F74
		public string TryToGetMyIP()
		{
			object obj = this.k1;
			string result;
			lock (obj)
			{
				bool flag2 = this.dangSuDung == 0;
				if (flag2)
				{
					bool flag3 = this.daSuDung > 0 && this.daSuDung < this.limit_theads_use;
					if (flag3)
					{
						bool flag4 = this.GetTimeOut() < 30 && this.ChangeProxy() != 1;
						if (flag4)
						{
							return "0";
						}
					}
					else
					{
						bool flag5 = this.ChangeProxy() != 1;
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
					bool flag7 = this.GetTimeOut() < 30 && this.ChangeProxy() != 1;
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

		// Token: 0x06000315 RID: 789 RVA: 0x00037EA0 File Offset: 0x000360A0
		public int GetTimeOut()
		{
			this.CheckStatusProxy();
			return this.timeout;
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00037EC0 File Offset: 0x000360C0
		public void DecrementDangSuDung()
		{
			object obj = this.k;
			lock (obj)
			{
				this.dangSuDung--;
				bool flag2 = this.dangSuDung == 0 && this.daSuDung == this.limit_theads_use;
				if (flag2)
				{
					this.daSuDung = 0;
				}
			}
		}

		// Token: 0x06000317 RID: 791 RVA: 0x00037F34 File Offset: 0x00036134
		public int ChangeProxy()
		{
			this.proxy = "";
			this.ip = "";
			this.port = 0;
			string text = MinProxy.RequestGet("http://dash.minproxy.vn/api/rotating/v1/proxy/get-new-proxy?api_key=" + this.api_key);
			bool flag = text != "";
			if (flag)
			{
				bool flag2 = text.Contains("api expired");
				if (flag2)
				{
					return -1;
				}
				bool flag3 = text.Contains("api wrong") || text.Contains("error");
				if (flag3)
				{
					return -2;
				}
				try
				{
					JObject jobject = JObject.Parse(text);
					bool flag4 = jobject.ContainsKey("data");
					if (flag4)
					{
						string value = Regex.Match(jobject["data"]["next_request"].ToString(), "\\d+").Value;
						this.next_change = ((!(value == "")) ? int.Parse(value) : 0);
						bool flag5 = jobject.ContainsKey("code");
						if (flag5)
						{
							bool flag6 = jobject["code"].ToString() == "2";
							if (flag6)
							{
								this.ip_allow = jobject["data"]["ip_allow"].ToString();
								this.your_ip = jobject["data"]["your_ip"].ToString();
								bool flag7 = this.typeProxy == 0;
								if (flag7)
								{
									this.proxy = jobject["data"]["http_proxy"].ToString();
									string[] array = this.proxy.Split(new char[]
									{
										':'
									});
									this.ip = array[0];
									this.port = int.Parse(array[1]);
								}
								else
								{
									this.proxy = jobject["data"]["socks5"].ToString();
									string[] array2 = this.proxy.Split(new char[]
									{
										':'
									});
									this.ip = array2[0];
									this.port = int.Parse(array2[1]);
								}
								return 1;
							}
						}
					}
					return 0;
				}
				catch
				{
				}
			}
			this.next_change = 0;
			return 0;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000381B0 File Offset: 0x000363B0
		private bool checkLastRequest()
		{
			try
			{
				DateTime dateTime = new DateTime(2001, 1, 1);
				long ticks = DateTime.Now.Ticks - dateTime.Ticks;
				int num = (int)new TimeSpan(ticks).TotalSeconds;
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

		// Token: 0x06000319 RID: 793 RVA: 0x00038238 File Offset: 0x00036438
		public bool CheckStatusProxy()
		{
			this.next_change = 0;
			this.proxy = "";
			this.ip = "";
			this.port = 0;
			this.timeout = 0;
			string text = MinProxy.RequestGet("http://dash.minproxy.vn/api/rotating/v1/proxy/get-current-proxy?api_key=" + this.api_key);
			bool flag = text != "";
			if (flag)
			{
				try
				{
					JObject jobject = JObject.Parse(text);
					bool flag2 = jobject.ContainsKey("code");
					if (flag2)
					{
						bool flag3 = jobject["code"].ToString() == "1";
						if (flag3)
						{
							bool flag4 = jobject.ContainsKey("data");
							if (flag4)
							{
								this.next_change = Convert.ToInt32(jobject["data"]["next_request"].ToString());
								this.timeout = Convert.ToInt32(jobject["data"]["timeout"].ToString());
								this.ip_allow = jobject["data"]["ip_allow"].ToString();
								this.your_ip = jobject["data"]["your_ip"].ToString();
								bool flag5 = this.typeProxy == 0;
								if (flag5)
								{
									this.proxy = jobject["data"]["http_proxy"].ToString();
									string[] array = this.proxy.Split(new char[]
									{
										':'
									});
									this.ip = array[0];
									this.port = int.Parse(array[1]);
								}
								else
								{
									this.proxy = jobject["data"]["socks5"].ToString();
									string[] array2 = this.proxy.Split(new char[]
									{
										':'
									});
									this.ip = array2[0];
									this.port = int.Parse(array2[1]);
								}
								return true;
							}
						}
					}
				}
				catch
				{
				}
			}
			return false;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00038474 File Offset: 0x00036674
		public string GetProxy()
		{
			while (!this.CheckStatusProxy())
			{
			}
			return this.proxy;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x000384A0 File Offset: 0x000366A0
		private static string RequestPost(string url, string data)
		{
			string result;
			try
			{
				new HttpClient();
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				HttpContent c = null;
				Task<string> task = Task.Run<string>(() => MinProxy.PostURI(new Uri(url), c));
				task.Wait();
				result = task.Result;
			}
			catch (Exception ex)
			{
				Common.ExportError(ex, "Request Post");
				result = "";
			}
			return result;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0003853C File Offset: 0x0003673C
		public static string RequestGet(string url)
		{
			string result;
			try
			{
				new HttpClient();
				ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				Task<string> task = Task.Run<string>(() => MinProxy.GetURI(new Uri(url)));
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

		// Token: 0x0600031D RID: 797 RVA: 0x000385C4 File Offset: 0x000367C4
		[DebuggerStepThrough]
		private static Task<string> PostURI(Uri u, HttpContent c)
		{
			MinProxy.<PostURI>d__54 <PostURI>d__ = new MinProxy.<PostURI>d__54();
			<PostURI>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<PostURI>d__.u = u;
			<PostURI>d__.c = c;
			<PostURI>d__.<>1__state = -1;
			<PostURI>d__.<>t__builder.Start<MinProxy.<PostURI>d__54>(ref <PostURI>d__);
			return <PostURI>d__.<>t__builder.Task;
		}

		// Token: 0x0600031E RID: 798 RVA: 0x00038610 File Offset: 0x00036810
		[DebuggerStepThrough]
		private static Task<string> GetURI(Uri u)
		{
			MinProxy.<GetURI>d__55 <GetURI>d__ = new MinProxy.<GetURI>d__55();
			<GetURI>d__.<>t__builder = AsyncTaskMethodBuilder<string>.Create();
			<GetURI>d__.u = u;
			<GetURI>d__.<>1__state = -1;
			<GetURI>d__.<>t__builder.Start<MinProxy.<GetURI>d__55>(ref <GetURI>d__);
			return <GetURI>d__.<>t__builder.Task;
		}

		// Token: 0x04000327 RID: 807
		private Random rd = new Random();

		// Token: 0x04000328 RID: 808
		private object k1 = new object();

		// Token: 0x04000329 RID: 809
		private object k = new object();

		// Token: 0x0400032A RID: 810
		private int lastRequest = 0;

		// Token: 0x0400032B RID: 811
		public int dangSuDung = 0;

		// Token: 0x0400032C RID: 812
		public int daSuDung = 0;

		// Token: 0x0400032D RID: 813
		public int limit_theads_use = 3;
	}
}
