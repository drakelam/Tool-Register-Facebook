using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace ToolRegFB
{
	// Token: 0x02000012 RID: 18
	internal class Chrome
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600008A RID: 138 RVA: 0x000049AD File Offset: 0x00002BAD
		// (set) Token: 0x0600008B RID: 139 RVA: 0x000049B5 File Offset: 0x00002BB5
		public bool HideBrowser { get; set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600008C RID: 140 RVA: 0x000049BE File Offset: 0x00002BBE
		// (set) Token: 0x0600008D RID: 141 RVA: 0x000049C6 File Offset: 0x00002BC6
		public bool Incognito { get; set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000049CF File Offset: 0x00002BCF
		// (set) Token: 0x0600008F RID: 143 RVA: 0x000049D7 File Offset: 0x00002BD7
		public bool DisableImage { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000090 RID: 144 RVA: 0x000049E0 File Offset: 0x00002BE0
		// (set) Token: 0x06000091 RID: 145 RVA: 0x000049E8 File Offset: 0x00002BE8
		public bool DisableSound { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000092 RID: 146 RVA: 0x000049F1 File Offset: 0x00002BF1
		// (set) Token: 0x06000093 RID: 147 RVA: 0x000049F9 File Offset: 0x00002BF9
		public bool AutoPlayVideo { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00004A02 File Offset: 0x00002C02
		// (set) Token: 0x06000095 RID: 149 RVA: 0x00004A0A File Offset: 0x00002C0A
		public string UserAgent { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00004A13 File Offset: 0x00002C13
		// (set) Token: 0x06000097 RID: 151 RVA: 0x00004A1B File Offset: 0x00002C1B
		public string ProfilePath { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00004A24 File Offset: 0x00002C24
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00004A2C File Offset: 0x00002C2C
		public Point Size { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00004A35 File Offset: 0x00002C35
		// (set) Token: 0x0600009B RID: 155 RVA: 0x00004A3D File Offset: 0x00002C3D
		public int Size_Heigh { get; set; }

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00004A46 File Offset: 0x00002C46
		// (set) Token: 0x0600009D RID: 157 RVA: 0x00004A4E File Offset: 0x00002C4E
		public int Size_Width { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00004A57 File Offset: 0x00002C57
		// (set) Token: 0x0600009F RID: 159 RVA: 0x00004A5F File Offset: 0x00002C5F
		public Point Position { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00004A68 File Offset: 0x00002C68
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00004A70 File Offset: 0x00002C70
		public int Position_X { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00004A79 File Offset: 0x00002C79
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00004A81 File Offset: 0x00002C81
		public int Position_Y { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00004A8A File Offset: 0x00002C8A
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00004A92 File Offset: 0x00002C92
		public int TimeWaitForSearchingElement { get; set; }

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00004A9B File Offset: 0x00002C9B
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00004AA3 File Offset: 0x00002CA3
		public int TimeWaitForLoadingPage { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00004AAC File Offset: 0x00002CAC
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00004AB4 File Offset: 0x00002CB4
		public string Proxy { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00004ABD File Offset: 0x00002CBD
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00004AC5 File Offset: 0x00002CC5
		public int TypeProxy { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00004ACE File Offset: 0x00002CCE
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00004AD6 File Offset: 0x00002CD6
		public string App { get; set; }

		// Token: 0x060000AE RID: 174 RVA: 0x00004AE0 File Offset: 0x00002CE0
		public Chrome()
		{
			this.HideBrowser = false;
			this.DisableImage = false;
			this.DisableSound = false;
			this.Incognito = false;
			this.UserAgent = "";
			this.ProfilePath = "";
			this.Size_Heigh = 300;
			this.Size_Width = 300;
			this.Size = new Point(this.Size_Width, this.Size_Heigh);
			this.Position_X = 0;
			this.Position_Y = 0;
			this.Proxy = "";
			this.TypeProxy = 0;
			this.Position = new Point(this.Position_X, this.Position_Y);
			this.TimeWaitForSearchingElement = 0;
			this.TimeWaitForLoadingPage = 5;
			this.App = "";
			this.AutoPlayVideo = false;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00004BC0 File Offset: 0x00002DC0
		public bool Open()
		{
			bool result = false;
			try
			{
				ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
				chromeDriverService.HideCommandPromptWindow = true;
				ChromeOptions chromeOptions = new ChromeOptions();
				chromeOptions.AddArguments(new string[]
				{
					"--disable-notifications",
					"--window-size=" + this.Size.X.ToString() + "," + this.Size.Y.ToString(),
					"--window-position=" + this.Position.X.ToString() + "," + this.Position.Y.ToString(),
					"--no-sandbox",
					"--disable-gpu",
					"--disable-dev-shm-usage",
					"--disable-web-security",
					"--disable-rtc-smoothness-algorithm",
					"--disable-webrtc-hw-decoding",
					"--disable-webrtc-hw-encoding",
					"--disable-webrtc-multiple-routes",
					"--disable-webrtc-hw-vp8-encoding",
					"--enforce-webrtc-ip-permission-check",
					"--force-webrtc-ip-handling-policy",
					"--ignore-certificate-errors",
					"--disable-infobars",
					"--disable-popup-blocking"
				});
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.notifications", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.plugins", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.popups", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.geolocation", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.auto_select_certificate", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.mixed_script", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.media_stream", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.media_stream_mic", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.media_stream_camera", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.protocol_handlers", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.midi_sysex", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.push_messaging", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.ssl_cert_decisions", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.metro_switch_to_desktop", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.protected_media_identifier", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.site_engagement", 1);
				chromeOptions.AddUserProfilePreference("profile.default_content_setting_values.durable_storage", 1);
				chromeOptions.AddUserProfilePreference("useAutomationExtension", true);
				bool disableSound = this.DisableSound;
				if (disableSound)
				{
					chromeOptions.AddArgument("--mute-audio");
				}
				bool flag = !this.HideBrowser;
				if (flag)
				{
					bool disableImage = this.DisableImage;
					if (disableImage)
					{
						chromeOptions.AddArgument("--blink-settings=imagesEnabled=false");
					}
					bool flag2 = !string.IsNullOrEmpty(this.ProfilePath.Trim());
					if (flag2)
					{
						chromeOptions.AddArgument("--user-data-dir=" + this.ProfilePath);
					}
				}
				else
				{
					chromeOptions.AddArgument("--blink-settings=imagesEnabled=false");
					chromeOptions.AddArgument("--headless");
				}
				bool incognito = this.Incognito;
				if (incognito)
				{
					chromeOptions.AddArguments(new string[]
					{
						"--incognito"
					});
				}
				bool flag3 = !string.IsNullOrEmpty(this.Proxy.Trim());
				if (flag3)
				{
					switch (this.Proxy.Split(new char[]
					{
						':'
					}).Count<string>())
					{
					case 1:
					{
						bool flag4 = this.TypeProxy == 0;
						if (flag4)
						{
							chromeOptions.AddArgument("--proxy-server= 127.0.0.1:" + this.Proxy);
						}
						else
						{
							chromeOptions.AddArgument("--proxy-server= socks5://127.0.0.1:" + this.Proxy);
						}
						break;
					}
					case 2:
					{
						bool flag5 = this.TypeProxy == 0;
						if (flag5)
						{
							chromeOptions.AddArgument("--proxy-server= " + this.Proxy);
						}
						else
						{
							chromeOptions.AddArgument("--proxy-server= socks5://" + this.Proxy);
						}
						break;
					}
					case 4:
					{
						bool flag6 = this.TypeProxy == 0;
						if (flag6)
						{
							chromeOptions.AddArgument("--proxy-server= " + this.Proxy.Split(new char[]
							{
								':'
							})[0] + ":" + this.Proxy.Split(new char[]
							{
								':'
							})[1]);
							chromeOptions.AddExtension("extension\\proxy.crx");
						}
						else
						{
							chromeOptions.AddArgument("--proxy-server= socks5://" + this.Proxy.Split(new char[]
							{
								':'
							})[0] + ":" + this.Proxy.Split(new char[]
							{
								':'
							})[1]);
							chromeOptions.AddExtension("extension\\proxy.crx");
						}
						break;
					}
					}
				}
				bool flag7 = !string.IsNullOrEmpty(this.App.Trim());
				if (flag7)
				{
					chromeOptions.AddArgument("--app= " + this.App);
				}
				bool flag8 = this.UserAgent != "";
				if (flag8)
				{
					bool flag9 = this.Proxy.Split(new char[]
					{
						':'
					}).Count<string>() == 4;
					if (flag9)
					{
						chromeOptions.AddArgument(string.Concat(new string[]
						{
							"--user-agent=",
							this.UserAgent,
							"$PC$",
							this.Proxy.Split(new char[]
							{
								':'
							})[2],
							":",
							this.Proxy.Split(new char[]
							{
								':'
							})[3]
						}));
					}
					else
					{
						chromeOptions.AddArgument("--user-agent=" + this.UserAgent);
					}
				}
				bool autoPlayVideo = this.AutoPlayVideo;
				if (autoPlayVideo)
				{
					chromeOptions.AddArgument("--autoplay-policy=no-user-gesture-required");
				}
				this.chrome = new ChromeDriver(chromeDriverService, chromeOptions);
				this.chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((double)this.TimeWaitForSearchingElement);
				this.chrome.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes((double)this.TimeWaitForLoadingPage);
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.Open()");
			}
			return result;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00005234 File Offset: 0x00003434
		public bool SendKeyDown(int typeAttribute, string attributeValue)
		{
			bool result = false;
			try
			{
				switch (typeAttribute)
				{
				case 1:
					this.chrome.FindElementById(attributeValue).SendKeys(Keys.ArrowDown);
					break;
				case 2:
					this.chrome.FindElementByName(attributeValue).SendKeys(Keys.ArrowDown);
					break;
				case 3:
					this.chrome.FindElementByXPath(attributeValue).SendKeys(Keys.ArrowDown);
					break;
				case 4:
					this.chrome.FindElementByCssSelector(attributeValue).SendKeys(Keys.ArrowDown);
					break;
				}
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.SendKeyDown({0},{1})", typeAttribute, attributeValue));
			}
			return result;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x00005304 File Offset: 0x00003504
		public string GetURL()
		{
			try
			{
				return this.chrome.Url;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.GetURL()");
			}
			return "";
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000534C File Offset: 0x0000354C
		public bool GotoURL(string url)
		{
			bool result = false;
			try
			{
				this.chrome.Navigate().GoToUrl(url);
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.GotoURL(" + url + ")");
			}
			return result;
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000053A8 File Offset: 0x000035A8
		public bool Refresh()
		{
			bool result = false;
			try
			{
				this.chrome.Navigate().Refresh();
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.Refresh()");
			}
			return result;
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000053F8 File Offset: 0x000035F8
		public bool GotoBackPage()
		{
			bool result = false;
			try
			{
				this.chrome.Navigate().Back();
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.GotoBackPage()");
			}
			return result;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00005448 File Offset: 0x00003648
		public object ExecuteScript(string script)
		{
			try
			{
				return this.chrome.ExecuteScript(script, Array.Empty<object>());
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.ExecuteScript(" + script + ")");
			}
			return "";
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x000054A4 File Offset: 0x000036A4
		public bool Click(int typeAttribute, string attributeValue)
		{
			bool result = false;
			try
			{
				switch (typeAttribute)
				{
				case 1:
					this.chrome.FindElementById(attributeValue).Click();
					break;
				case 2:
					this.chrome.FindElementByName(attributeValue).Click();
					break;
				case 3:
					this.chrome.FindElementByXPath(attributeValue).Click();
					break;
				case 4:
					this.chrome.FindElementByCssSelector(attributeValue).Click();
					break;
				}
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.Click({0},{1})", typeAttribute, attributeValue));
			}
			return result;
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00005560 File Offset: 0x00003760
		public bool CheckIsLive()
		{
			return !this.CheckChromeClosed();
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000557C File Offset: 0x0000377C
		public int Click(int typeAttribute, string attributeValue, int index = 0, int subTypeAttribute = 0, string subAttributeValue = "", int subIndex = 0, int times = 1)
		{
			bool flag = false;
			bool flag2 = !this.CheckIsLive();
			int result;
			if (flag2)
			{
				result = -2;
			}
			else
			{
				for (int i = 0; i < times; i++)
				{
					try
					{
						bool flag3 = subTypeAttribute == 0;
						if (flag3)
						{
							switch (typeAttribute)
							{
							case 1:
								this.chrome.FindElementsById(attributeValue)[index].Click();
								break;
							case 2:
								this.chrome.FindElementsByName(attributeValue)[index].Click();
								break;
							case 3:
								this.chrome.FindElementsByXPath(attributeValue)[index].Click();
								break;
							case 4:
								this.chrome.FindElementsByCssSelector(attributeValue)[index].Click();
								break;
							}
						}
						else
						{
							switch (typeAttribute)
							{
							case 1:
								this.chrome.FindElementsById(attributeValue)[index].FindElements(By.Id(subAttributeValue))[subIndex].Click();
								break;
							case 2:
								this.chrome.FindElementsByName(attributeValue)[index].FindElements(By.Name(subAttributeValue))[subIndex].Click();
								break;
							case 3:
								this.chrome.FindElementsByXPath(attributeValue)[index].FindElements(By.XPath(subAttributeValue))[subIndex].Click();
								break;
							case 4:
								this.chrome.FindElementsByCssSelector(attributeValue)[index].FindElements(By.CssSelector(subAttributeValue))[subIndex].Click();
								break;
							}
						}
						flag = true;
						break;
					}
					catch (Exception ex)
					{
						Chrome.ExportError(null, ex, string.Format("chrome.Click({0},{1})", typeAttribute, attributeValue));
					}
					this.DelayTime(1.0);
				}
				result = (flag ? 1 : 0);
			}
			return result;
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x000057A0 File Offset: 0x000039A0
		public bool ClickWithAction(int typeAttribute, string attributeValue)
		{
			bool result = false;
			try
			{
				switch (typeAttribute)
				{
				case 1:
					new Actions(this.chrome).Click(this.chrome.FindElementById(attributeValue)).Perform();
					break;
				case 2:
					new Actions(this.chrome).Click(this.chrome.FindElementByName(attributeValue)).Perform();
					break;
				case 3:
					new Actions(this.chrome).Click(this.chrome.FindElementByXPath(attributeValue)).Perform();
					break;
				case 4:
					new Actions(this.chrome).Click(this.chrome.FindElementByCssSelector(attributeValue)).Perform();
					break;
				}
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.ClickWithAction({0},{1})", typeAttribute, attributeValue));
			}
			return result;
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000589C File Offset: 0x00003A9C
		public bool SendKeys(int typeAttribute, string attributeValue, string content, bool isClick = true)
		{
			bool result = false;
			try
			{
				if (isClick)
				{
					this.Click(typeAttribute, attributeValue);
				}
				switch (typeAttribute)
				{
				case 1:
					this.chrome.FindElementById(attributeValue).SendKeys(content);
					break;
				case 2:
					this.chrome.FindElementByName(attributeValue).SendKeys(content);
					break;
				case 3:
					this.chrome.FindElementByXPath(attributeValue).SendKeys(content);
					break;
				case 4:
					this.chrome.FindElementByCssSelector(attributeValue).SendKeys(content);
					break;
				}
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.SendKeys({0},{1},{2},{3})", new object[]
				{
					typeAttribute,
					attributeValue,
					content,
					isClick
				}));
			}
			return result;
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00005988 File Offset: 0x00003B88
		public bool SendKeys(int typeAttribute, string attributeValue, string content, double timeDelay_Second, bool isClick = true)
		{
			bool result = false;
			try
			{
				if (isClick)
				{
					this.Click(typeAttribute, attributeValue);
				}
				for (int i = 0; i < content.Length; i++)
				{
					switch (typeAttribute)
					{
					case 1:
						this.chrome.FindElementById(attributeValue).SendKeys(content[i].ToString());
						break;
					case 2:
						this.chrome.FindElementByName(attributeValue).SendKeys(content[i].ToString());
						break;
					case 3:
						this.chrome.FindElementByXPath(attributeValue).SendKeys(content[i].ToString());
						break;
					case 4:
						this.chrome.FindElementByCssSelector(attributeValue).SendKeys(content[i].ToString());
						break;
					}
					Thread.Sleep(Convert.ToInt32(timeDelay_Second * 1000.0));
				}
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.SendKeys({0},{1},{2},{3},{4})", new object[]
				{
					typeAttribute,
					attributeValue,
					content,
					timeDelay_Second,
					isClick
				}));
			}
			return result;
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00005B00 File Offset: 0x00003D00
		public bool SelectText(int typeAttribute, string attributeValue)
		{
			bool result = false;
			try
			{
				switch (typeAttribute)
				{
				case 1:
					this.chrome.FindElementById(attributeValue).SendKeys(Keys.Control + "a");
					break;
				case 2:
					this.chrome.FindElementByName(attributeValue).SendKeys(Keys.Control + "a");
					break;
				case 3:
					this.chrome.FindElementByXPath(attributeValue).SendKeys(Keys.Control + "a");
					break;
				case 4:
					this.chrome.FindElementByCssSelector(attributeValue).SendKeys(Keys.Control + "a");
					break;
				}
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.SelectText({0},{1})", typeAttribute, attributeValue));
			}
			return result;
		}

		// Token: 0x060000BD RID: 189 RVA: 0x00005BF8 File Offset: 0x00003DF8
		public bool ClearText(int typeAttribute, string attributeValue)
		{
			bool result = false;
			try
			{
				switch (typeAttribute)
				{
				case 1:
					this.chrome.FindElementById(attributeValue).Clear();
					break;
				case 2:
					this.chrome.FindElementByName(attributeValue).Clear();
					break;
				case 3:
					this.chrome.FindElementByXPath(attributeValue).Clear();
					break;
				case 4:
					this.chrome.FindElementByCssSelector(attributeValue).Clear();
					break;
				}
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.ClearText({0},{1})", typeAttribute, attributeValue));
			}
			return result;
		}

		// Token: 0x060000BE RID: 190 RVA: 0x00005CB4 File Offset: 0x00003EB4
		public int CheckExistElement1(string querySelector, double timeWait_Second = 0.0)
		{
			bool flag = true;
			bool flag2 = !this.CheckIsLive();
			int result;
			if (flag2)
			{
				result = -2;
			}
			else
			{
				try
				{
					int tickCount = Environment.TickCount;
					while ((string)this.chrome.ExecuteScript("return document.querySelectorAll('" + querySelector + "').length+''", Array.Empty<object>()) == "0")
					{
						bool flag3 = (double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0;
						if (flag3)
						{
							flag = false;
							break;
						}
						bool flag4 = !this.CheckIsLive();
						if (flag4)
						{
							return -2;
						}
						Thread.Sleep(1000);
					}
				}
				catch (Exception ex)
				{
					Chrome.ExportError(null, ex, string.Format("chrome.CheckExistElement({0},{1})", querySelector, timeWait_Second));
				}
				result = (flag ? 1 : 0);
			}
			return result;
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00005DA0 File Offset: 0x00003FA0
		public bool CheckExistElement(string querySelector, double timeWait_Second = 0.0)
		{
			bool result = true;
			try
			{
				int tickCount = Environment.TickCount;
				while ((string)this.chrome.ExecuteScript("return document.querySelectorAll('" + querySelector + "').length+''", Array.Empty<object>()) == "0")
				{
					bool flag = (double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0;
					if (flag)
					{
						result = false;
						break;
					}
					Thread.Sleep(1000);
				}
			}
			catch (Exception ex)
			{
				result = false;
				Chrome.ExportError(null, ex, string.Format("chrome.CheckExistElement({0},{1})", querySelector, timeWait_Second));
			}
			return result;
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00005E54 File Offset: 0x00004054
		public bool CheckChromeClosed()
		{
			bool result = true;
			try
			{
				string title = this.chrome.Title;
				result = false;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.CheckChromeClosed()");
			}
			return result;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00005EA0 File Offset: 0x000040A0
		public bool WaitForSearchElement(string querySelector, int typeSearch = 0, double timeWait_Second = 0.0)
		{
			bool result = true;
			try
			{
				int tickCount = Environment.TickCount;
				bool flag = typeSearch == 0;
				if (flag)
				{
					while ((string)this.chrome.ExecuteScript("return document.querySelectorAll('" + querySelector + "').length+''", Array.Empty<object>()) == "0")
					{
						bool flag2 = (double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0;
						if (flag2)
						{
							result = false;
							break;
						}
						Thread.Sleep(1000);
					}
				}
				else
				{
					while ((string)this.chrome.ExecuteScript("return document.querySelectorAll('" + querySelector + "').length+''", Array.Empty<object>()) != "0")
					{
						bool flag3 = (double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0;
						if (flag3)
						{
							result = false;
							break;
						}
						Thread.Sleep(1000);
					}
				}
			}
			catch (Exception ex)
			{
				result = false;
				Chrome.ExportError(null, ex, string.Format("chrome.WaitForSearchElement({0},{1},{2})", querySelector, typeSearch, timeWait_Second));
			}
			return result;
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00005FD0 File Offset: 0x000041D0
		public int CheckExistElements(double timeWait_Second = 0.0, params string[] querySelectors)
		{
			int result = 0;
			try
			{
				int tickCount = Environment.TickCount;
				int i;
				for (;;)
				{
					for (i = 0; i < querySelectors.Length; i++)
					{
						bool flag = this.CheckExistElement(querySelectors[i], 0.0);
						if (flag)
						{
							goto Block_3;
						}
					}
					bool flag2 = (double)(Environment.TickCount - tickCount) > timeWait_Second * 1000.0;
					if (flag2)
					{
						goto Block_5;
					}
					Thread.Sleep(1000);
				}
				Block_3:
				return i + 1;
				Block_5:;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.CheckExistElements({0},{1})", timeWait_Second, string.Join("|", querySelectors)));
			}
			return result;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00006094 File Offset: 0x00004294
		public bool SendEnter(int typeAttribute, string attributeValue)
		{
			bool result = false;
			try
			{
				switch (typeAttribute)
				{
				case 1:
					this.chrome.FindElementById(attributeValue).SendKeys(Keys.Enter);
					break;
				case 2:
					this.chrome.FindElementByName(attributeValue).SendKeys(Keys.Enter);
					break;
				case 3:
					this.chrome.FindElementByXPath(attributeValue).SendKeys(Keys.Enter);
					break;
				case 4:
					this.chrome.FindElementByCssSelector(attributeValue).SendKeys(Keys.Enter);
					break;
				}
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.SendEnter({0},{1})", typeAttribute, attributeValue));
			}
			return result;
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00006164 File Offset: 0x00004364
		public bool Scroll(int x, int y)
		{
			bool result = false;
			try
			{
				string text = string.Format("window.scrollTo({0}, {1})", x, y);
				this.chrome.ExecuteScript(text, Array.Empty<object>());
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.Scroll({0},{1})", x, y));
			}
			return result;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000061DC File Offset: 0x000043DC
		public void ScrollSmooth(string JSpath)
		{
			try
			{
				this.chrome.ExecuteScript(JSpath + ".scrollIntoView({ behavior: 'smooth', block: 'center'});", Array.Empty<object>());
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.ScrollSmooth(" + JSpath + ")");
			}
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x00006238 File Offset: 0x00004438
		public void Close()
		{
			try
			{
				this.chrome.Quit();
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.Close()");
			}
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00006278 File Offset: 0x00004478
		public bool ScreenCapture(string imagePath, string fileName)
		{
			bool result = false;
			try
			{
				Screenshot screenshot = this.chrome.GetScreenshot();
				screenshot.SaveAsFile(imagePath + (imagePath.EndsWith("\\") ? "" : "\\") + fileName + ".png");
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Concat(new string[]
				{
					"chrome.ScreenCapture(",
					imagePath,
					",",
					fileName,
					")"
				}));
			}
			return result;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00006314 File Offset: 0x00004514
		public void AddCookieIntoChrome(string cookie, string domain = ".facebook.com")
		{
			try
			{
				string[] array = cookie.Split(new char[]
				{
					';'
				});
				foreach (string text in array)
				{
					bool flag = text.Trim() != "";
					if (flag)
					{
						string[] array3 = text.Split(new char[]
						{
							'='
						});
						bool flag2 = array3.Count<string>() > 1 && array3[0].Trim() != "";
						if (flag2)
						{
							Cookie cookie2 = new Cookie(array3[0].Trim(), text.Substring(text.IndexOf('=') + 1).Trim(), domain, "/", new DateTime?(DateTime.Now.AddDays(10.0)));
							this.chrome.Manage().Cookies.AddCookie(cookie2);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Concat(new string[]
				{
					"chrome.AddCookieIntoChrome(",
					cookie,
					",",
					domain,
					")"
				}));
			}
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00006454 File Offset: 0x00004654
		public string GetCookieFromChrome(string domain = "facebook")
		{
			string text = "";
			try
			{
				Cookie[] array = this.chrome.Manage().Cookies.AllCookies.ToArray<Cookie>();
				foreach (Cookie cookie in array)
				{
					bool flag = cookie.Domain.Contains(domain);
					if (flag)
					{
						text = string.Concat(new string[]
						{
							text,
							cookie.Name,
							"=",
							cookie.Value,
							";"
						});
					}
				}
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.GetCookieFromChrome(" + domain + ")");
			}
			return text;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00006520 File Offset: 0x00004720
		public void OpenNewTab(string url, bool switchToLastTab = true)
		{
			try
			{
				this.chrome.ExecuteScript("window.open('" + url + "', '_blank').focus();", Array.Empty<object>());
				if (switchToLastTab)
				{
					this.chrome.SwitchTo().Window(this.chrome.WindowHandles.Last<string>());
				}
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.OpenNewTab({0},{1})", url, switchToLastTab));
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000065AC File Offset: 0x000047AC
		public void CloseCurrentTab()
		{
			try
			{
				this.chrome.Close();
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.CloseCurrentTab()");
			}
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000065EC File Offset: 0x000047EC
		public void SwitchToFirstTab()
		{
			try
			{
				this.chrome.SwitchTo().Window(this.chrome.WindowHandles.First<string>());
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.SwitchToFirstTab()");
			}
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00006644 File Offset: 0x00004844
		public void SwitchToLastTab()
		{
			try
			{
				this.chrome.SwitchTo().Window(this.chrome.WindowHandles.Last<string>());
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, "chrome.SwitchToLastTab()");
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0000669C File Offset: 0x0000489C
		public void DelayTime(double timeDelay_Seconds)
		{
			try
			{
				Thread.Sleep(Convert.ToInt32(timeDelay_Seconds * 1000.0));
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.DelayTime({0})", timeDelay_Seconds));
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x000066F4 File Offset: 0x000048F4
		public static void ExportError(Chrome chrome, Exception ex, string error = "")
		{
			try
			{
				bool flag = !Directory.Exists("log");
				if (flag)
				{
					Directory.CreateDirectory("log");
				}
				bool flag2 = !Directory.Exists("log\\html");
				if (flag2)
				{
					Directory.CreateDirectory("log\\html");
				}
				bool flag3 = !Directory.Exists("log\\images");
				if (flag3)
				{
					Directory.CreateDirectory("log\\images");
				}
				Random random = new Random();
				string text = string.Concat(new string[]
				{
					DateTime.Now.Day.ToString(),
					"_",
					DateTime.Now.Month.ToString(),
					"_",
					DateTime.Now.Year.ToString(),
					"_",
					DateTime.Now.Hour.ToString(),
					"_",
					DateTime.Now.Minute.ToString(),
					"_",
					DateTime.Now.Second.ToString(),
					"_",
					random.Next(1000, 9999).ToString()
				});
				bool flag4 = chrome != null;
				if (flag4)
				{
					string contents = chrome.ExecuteScript("var markup = document.documentElement.innerHTML;return markup;").ToString();
					chrome.ScreenCapture("log\\images\\", text);
					File.WriteAllText("log\\html\\" + text + ".html", contents);
				}
				using (StreamWriter streamWriter = new StreamWriter("log\\log.txt", true))
				{
					streamWriter.WriteLine("-----------------------------------------------------------------------------");
					streamWriter.WriteLine("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
					streamWriter.WriteLine("File: " + text);
					bool flag5 = error != "";
					if (flag5)
					{
						streamWriter.WriteLine("Error: " + error);
					}
					streamWriter.WriteLine();
					bool flag6 = ex != null;
					if (flag6)
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

		// Token: 0x060000D0 RID: 208 RVA: 0x000069D0 File Offset: 0x00004BD0
		public bool Select(int typeAttribute, string attributeValue, string value)
		{
			bool result = false;
			try
			{
				switch (typeAttribute)
				{
				case 1:
					new SelectElement(this.chrome.FindElementById(attributeValue)).SelectByValue(value);
					break;
				case 2:
					new SelectElement(this.chrome.FindElementByName(attributeValue)).SelectByValue(value);
					break;
				case 3:
					new SelectElement(this.chrome.FindElementByXPath(attributeValue)).SelectByValue(value);
					break;
				case 4:
					new SelectElement(this.chrome.FindElementByCssSelector(attributeValue)).SelectByValue(value);
					break;
				}
				result = true;
			}
			catch (Exception ex)
			{
				Chrome.ExportError(null, ex, string.Format("chrome.Select({0},{1},{2})", typeAttribute, attributeValue, value));
			}
			return result;
		}

		// Token: 0x04000051 RID: 81
		public ChromeDriver chrome;
	}
}
