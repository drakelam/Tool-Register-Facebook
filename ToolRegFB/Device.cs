using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Newtonsoft.Json.Linq;
using ToolRegFB.Properties;

namespace ToolRegFB
{
	// Token: 0x02000021 RID: 33
	internal class Device
	{
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00009FB4 File Offset: 0x000081B4
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00009FBC File Offset: 0x000081BC
		public string DeviceId { get; set; }

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00009FC5 File Offset: 0x000081C5
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00009FCD File Offset: 0x000081CD
		public string PathLDPlayer { get; set; }

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00009FD6 File Offset: 0x000081D6
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00009FDE File Offset: 0x000081DE
		public string LinkAvartar { get; set; }

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00009FE7 File Offset: 0x000081E7
		// (set) Token: 0x06000133 RID: 307 RVA: 0x00009FEF File Offset: 0x000081EF
		public Process process { get; set; }

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00009FF8 File Offset: 0x000081F8
		// (set) Token: 0x06000135 RID: 309 RVA: 0x0000A000 File Offset: 0x00008200
		private Random rd { get; set; }

		// Token: 0x06000136 RID: 310 RVA: 0x0000A00C File Offset: 0x0000820C
		public Device(string pathLDPlayer, string indexDevice, string linkAvartar)
		{
			this.IndexDevice = Convert.ToInt32(indexDevice);
			this.PathLDPlayer = pathLDPlayer;
			this.LinkAvartar = linkAvartar;
			this.rd = new Random();
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000A09C File Offset: 0x0000829C
		public bool TapByImage(string imagePath, Bitmap bitmap_screen = null, int timeWait = 0)
		{
			try
			{
				this.LoadStatusLD("Find Img: " + imagePath.Substring(imagePath.LastIndexOf('\\') + 1));
				string boundsByImage = this.GetBoundsByImage(imagePath, bitmap_screen, timeWait);
				bool flag = boundsByImage != "";
				if (flag)
				{
					this.LoadStatusLD("Click Img: " + imagePath.Substring(imagePath.LastIndexOf('\\') + 1));
					return this.TapByBounds(boundsByImage, "");
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000A134 File Offset: 0x00008334
		public bool ConnectProxy(string proxy)
		{
			bool flag = !this.CheckIsLive();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = false;
				bool flag3 = !string.IsNullOrEmpty(proxy.Trim());
				if (flag3)
				{
					int num = proxy.Split(new char[]
					{
						':'
					}).Count<string>();
					int num2 = num;
					int num3 = num2;
					bool flag4 = num3 != 2;
					if (flag4)
					{
						bool flag5 = num3 != 4;
						if (flag5)
						{
						}
					}
					else
					{
						this.ConnectHttpProxy(proxy);
						flag2 = true;
					}
				}
				result = flag2;
			}
			return result;
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000A1C4 File Offset: 0x000083C4
		private string ConnectHttpProxy(string proxy)
		{
			return ADBHelper.ConnectHttpProxy(this.DeviceId, proxy);
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000A1E4 File Offset: 0x000083E4
		public void RemoveProxy()
		{
			bool flag = this.CheckIsLive();
			if (flag)
			{
				ADBHelper.RemoveHttpProxy(this.DeviceId);
			}
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000A20C File Offset: 0x0000840C
		public bool TapByTextWithPopupAppear(int countCheck, string textCheck, string[] arrText)
		{
			bool result = false;
			for (int i = 0; i < countCheck; i++)
			{
				string html = this.GetHtml();
				List<string> list = new List<string>
				{
					textCheck
				};
				list.AddRange(arrText);
				int num = this.CheckExistTexts(html, 0.0, list.ToArray());
				bool flag = num != 0;
				if (flag)
				{
					this.TapByText(list[num - 1], html, 0);
				}
				bool flag2 = num == 1;
				if (flag2)
				{
					return true;
				}
				this.DelayTime(1.0);
			}
			return result;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000A2B4 File Offset: 0x000084B4
		public bool GotoFriendSuggest()
		{
			this.GotoNewFeedQuick();
			int num = 1;
			bool flag;
			for (;;)
			{
				flag = this.TapByImage("DataClick\\image\\menu", null, 5);
				for (;;)
				{
					num++;
					bool flag2 = !flag;
					if (flag2)
					{
						goto Block_1;
					}
					switch (num)
					{
					case 1:
						goto IL_57;
					case 2:
						flag = this.TapByImage("DataClick\\image\\banbe", null, 5);
						continue;
					case 3:
					{
						int num2 = this.CheckExistTexts("", 5.0, new string[]
						{
							"\"suggestions\"",
							"as a friend\""
						});
						int num3 = num2;
						int num4 = num3;
						bool flag3 = num4 != 1;
						if (flag3)
						{
							flag = (num4 == 2);
							continue;
						}
						flag = this.TapByText("\"suggestions\"", "", 0);
						continue;
					}
					}
					goto Block_2;
				}
				IL_57:;
			}
			Block_1:
			return flag;
			Block_2:
			return flag;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000A39C File Offset: 0x0000859C
		public bool ClickReactions(int typeReaction = 1)
		{
			try
			{
				List<string> list = new List<string>
				{
					"like",
					"love",
					"haha",
					"wow",
					"sad",
					"angry"
				};
				bool flag = typeReaction == 6;
				if (flag)
				{
					typeReaction = this.GetRandomInt(0, 4);
				}
				this.TapByImage("DataClick\\image\\reaction\\" + list[typeReaction], null, 0);
				return true;
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000A448 File Offset: 0x00008648
		public bool CheckOpenedDevice(int timeout = 60)
		{
			try
			{
				List<string> list = new List<string>();
				for (int i = 0; i < timeout; i++)
				{
					bool flag = !this.CheckIsLive();
					if (flag)
					{
						break;
					}
					List<string> devices = ADBHelper.GetDevices();
					List<string> lstDeviceIdCheck = new List<string>
					{
						"127.0.0.1:" + (this.IndexDevice * 2 + 5555).ToString(),
						"emulator-" + (this.IndexDevice * 2 + 5554).ToString()
					};
					list = (from x in devices
					where lstDeviceIdCheck.Contains(x)
					select x).ToList<string>();
					bool flag2 = list.Count > 0;
					if (flag2)
					{
						this.DeviceId = list[0];
						for (int j = 0; j < 60; j++)
						{
							bool flag3 = !this.CheckIsLive();
							if (flag3)
							{
								return false;
							}
							string activity = this.GetActivity();
							bool flag4 = activity == "com.android.launcher3/com.android.launcher3.Launcher" || activity != "";
							if (flag4)
							{
								return true;
							}
							Thread.Sleep(1000);
						}
					}
					bool flag5 = i == 30;
					if (flag5)
					{
						for (int k = 0; k < lstDeviceIdCheck.Count; k++)
						{
							ADBHelper.DisconnectDevice(lstDeviceIdCheck[k]);
						}
						ADBHelper.ConnectDevice(lstDeviceIdCheck[0]);
					}
					this.DelayTime(1.0);
				}
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000A62C File Offset: 0x0000882C
		public void GotoProfileQuick(string uid = "")
		{
			this.ExecuteCMD(string.Format(ADBCommands.VIEW, this.link_profile + ((uid == "") ? "" : ("/" + uid)), "com.facebook.katana"), 10);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000A67C File Offset: 0x0000887C
		public string GetTokenCookie()
		{
			string text = "";
			string text2 = "";
			try
			{
				string input = this.ReadFile("data/data/com.facebook.katana/app_light_prefs/com.facebook.katana/authentication");
				text = Regex.Match(input, "EAAAAU\\S+").Value;
				string value = Regex.Match(text, "\u0005(.*?)$").Value;
				text = text.Replace(value, "");
				string text3 = "{\"data\": [" + Regex.Match(input, "\\[(.*?)\\]").Groups[1].Value + "]}";
				JObject jobject = JObject.Parse(text3);
				for (int i = 0; i < jobject["data"].Count<JToken>(); i++)
				{
					text2 = string.Concat(new string[]
					{
						text2,
						jobject["data"][i]["name"].ToString(),
						"=",
						jobject["data"][i]["value"].ToString(),
						";"
					});
				}
			}
			catch
			{
			}
			return text + "|" + text2;
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000A7DC File Offset: 0x000089DC
		public int GetRandomInt(int from, int to)
		{
			int result;
			try
			{
				result = this.rd.Next(from, to + 1);
			}
			catch
			{
				result = (from + to) / 2;
			}
			return result;
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000A820 File Offset: 0x00008A20
		public void GotoNotificationQuick()
		{
			this.ExecuteCMD(string.Format(ADBCommands.VIEW, this.link_notifications, "com.facebook.katana"), 10);
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000A844 File Offset: 0x00008A44
		public void DelayRandom(double timeFrom, double timeTo)
		{
			bool flag = this.CheckIsLive();
			if (flag)
			{
				Thread.Sleep(this.rd.Next(Convert.ToInt32(timeFrom * 1000.0), Convert.ToInt32(timeTo * 1000.0 + 1.0)));
				Application.DoEvents();
			}
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000A8A0 File Offset: 0x00008AA0
		public string GetTokenCookieInsta()
		{
			string text = "";
			string text2 = "";
			try
			{
				string input = this.ReadFile("data/data/com.instagram.android/app_light_prefs/com.instagram.android/authentication");
				text = Regex.Match(input, "EAAAAU\\S+").Value;
				string value = Regex.Match(text, "\u0005(.*?)$").Value;
				text = text.Replace(value, "");
				string text3 = "{\"data\": [" + Regex.Match(input, "\\[(.*?)\\]").Groups[1].Value + "]}";
				JObject jobject = JObject.Parse(text3);
				for (int i = 0; i < jobject["data"].Count<JToken>(); i++)
				{
					text2 = string.Concat(new string[]
					{
						text2,
						jobject["data"][i]["name"].ToString(),
						"=",
						jobject["data"][i]["value"].ToString(),
						";"
					});
				}
			}
			catch
			{
			}
			return text + "|" + text2;
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000AA00 File Offset: 0x00008C00
		public string ReadFile(string filePath)
		{
			return ADBHelper.ReadFile(this.DeviceId, filePath);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x0000AA20 File Offset: 0x00008C20
		public void GrantPermission()
		{
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.READ_CALENDAR", 10);
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.READ_CONTACTS", 10);
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.READ_LOCATION", 10);
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.ACCESS_BACKGROUND_LOCATION", 10);
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.ACCESS_COARSE_LOCATION", 10);
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.ACCESS_FINE_LOCATION", 10);
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.RECORD_AUDIO", 10);
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.CALL_PHONE", 10);
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.READ_EXTERNAL_STORAGE", 10);
			this.ExecuteCMD("shell pm grant com.facebook.katana android.permission.WRITE_EXTERNAL_STORAGE", 10);
		}

		// Token: 0x06000147 RID: 327 RVA: 0x0000AABC File Offset: 0x00008CBC
		public void GrantPermissionInsta()
		{
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.READ_CALENDAR", 10);
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.READ_CONTACTS", 10);
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.READ_LOCATION", 10);
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.ACCESS_BACKGROUND_LOCATION", 10);
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.ACCESS_COARSE_LOCATION", 10);
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.ACCESS_FINE_LOCATION", 10);
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.RECORD_AUDIO", 10);
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.CALL_PHONE", 10);
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.READ_EXTERNAL_STORAGE", 10);
			this.ExecuteCMD("shell pm grant com.instagram.android android.permission.WRITE_EXTERNAL_STORAGE", 10);
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0000AB58 File Offset: 0x00008D58
		public string CreateRandomString(int lengText = 32, string format = "0_a_A", Random random = null)
		{
			string text = "";
			string[] source = format.Split(new char[]
			{
				'_'
			});
			bool flag = source.Contains("A");
			if (flag)
			{
				text += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			}
			bool flag2 = source.Contains("a");
			if (flag2)
			{
				text += "abcdefghijklmnopqrstuvwxyz";
			}
			bool flag3 = source.Contains("0");
			if (flag3)
			{
				text += "0123456789";
			}
			char[] array = new char[lengText];
			bool flag4 = random == null;
			if (flag4)
			{
				random = this.rd;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[random.Next(text.Length)];
			}
			return new string(array);
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0000AC30 File Offset: 0x00008E30
		public string PullFile(string fromFilePath, string toFilePath)
		{
			return ADBHelper.PullFile(this.DeviceId, fromFilePath, toFilePath);
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0000AC50 File Offset: 0x00008E50
		public string ScreenShoot(string pathFolder = "", string fileName = "*.png")
		{
			try
			{
				bool flag = !string.IsNullOrEmpty(pathFolder);
				if (flag)
				{
					Directory.CreateDirectory(pathFolder);
				}
				fileName = Path.GetFileNameWithoutExtension(fileName) + Path.GetExtension(fileName);
				ADBHelper.ScreenCap(this.DeviceId, "/sdcard/" + fileName);
				bool flag2 = string.IsNullOrEmpty(pathFolder);
				if (flag2)
				{
					pathFolder = FileHelper.GetPathToCurrentFolder();
				}
				this.PullFile("/sdcard/" + fileName, pathFolder);
				this.ExecuteCMD("shell rm /sdcard/*.png", 10);
				return pathFolder + "\\" + fileName;
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x0600014B RID: 331 RVA: 0x0000AD00 File Offset: 0x00008F00
		private Bitmap GetBitmapFromFile(string fileName, bool isDeleteFile = true)
		{
			Bitmap result = null;
			try
			{
				using (FileStream fileStream = File.OpenRead(fileName))
				{
					result = (Bitmap)Image.FromStream(fileStream);
				}
			}
			catch
			{
			}
			if (isDeleteFile)
			{
				Common.DeleteFile(fileName);
			}
			return result;
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0000AD6C File Offset: 0x00008F6C
		public Bitmap ScreenShoot()
		{
			Bitmap result = null;
			try
			{
				string fileName = this.ScreenShoot("", this.CreateRandomString(10, "a", null) + ".png");
				result = this.GetBitmapFromFile(fileName, true);
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0000ADC8 File Offset: 0x00008FC8
		public bool TapLongByBounds(string bounds, string onlyInBounds = "")
		{
			try
			{
				Point locationFromBounds = this.GetLocationFromBounds(bounds);
				int x = locationFromBounds.X;
				int y = locationFromBounds.Y;
				bool flag = onlyInBounds == "" || this.CheckBoundsContainLocation(onlyInBounds, x, y);
				if (flag)
				{
					return this.TapLong(x, y, 3000);
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0000AE40 File Offset: 0x00009040
		public void GotoWatchQuick()
		{
			this.ExecuteCMD(string.Format(ADBCommands.VIEW, this.link_watch, "com.facebook.katana"), 10);
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0000AE64 File Offset: 0x00009064
		public bool TapLong(int x, int y, int duration = -1)
		{
			bool flag = this.CheckBoundsContainLocation("[0,0][320,480]", x, y);
			bool result;
			if (flag)
			{
				bool flag2 = duration == -1;
				if (flag2)
				{
					duration = this.GetRandomInt(1000, 3000);
				}
				ADBHelper.TapLong(this.DeviceId, x, y, duration);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0000AEC0 File Offset: 0x000090C0
		private Point? FindOutPoint(Bitmap mainBitmap, Bitmap subBitmap, double percent = 0.9)
		{
			Point? result;
			try
			{
				Image<Bgr, byte> image = new Image<Bgr, byte>(mainBitmap);
				Image<Bgr, byte> image2 = new Image<Bgr, byte>(subBitmap);
				Point? point = null;
				using (Image<Gray, float> image3 = image.MatchTemplate(image2, 5))
				{
					double[] array;
					double[] array2;
					Point[] array3;
					Point[] array4;
					image3.MinMax(ref array, ref array2, ref array3, ref array4);
					bool flag = array2[0] > percent;
					if (flag)
					{
						point = new Point?(array4[0]);
					}
				}
				result = point;
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x0000AF5C File Offset: 0x0000915C
		public string GetBoundsByImage(Bitmap bitmap, Bitmap bitmap_screen = null, int timeWait_Second = 0)
		{
			try
			{
				int tickCount = Environment.TickCount;
				Point value;
				for (;;)
				{
					bool flag = bitmap_screen == null;
					if (flag)
					{
						bitmap_screen = this.ScreenShoot();
					}
					Point? point = null;
					point = this.FindOutPoint(bitmap_screen, bitmap, 0.9);
					bool flag2 = point != null;
					if (flag2)
					{
						value = point.Value;
						bool flag3 = value.X != 0 && value.Y != 0;
						if (flag3)
						{
							break;
						}
					}
					bool flag4 = Environment.TickCount - tickCount >= timeWait_Second * 1000;
					if (flag4)
					{
						goto Block_6;
					}
					this.DelayTime(1.0);
					bitmap_screen = this.ScreenShoot();
				}
				return string.Format("[{0},{1}][{2},{3}]", new object[]
				{
					value.X,
					value.Y,
					value.X + bitmap.Width,
					value.Y + bitmap.Height
				});
				Block_6:;
			}
			catch (Exception)
			{
			}
			return "";
		}

		// Token: 0x06000152 RID: 338 RVA: 0x0000B0A4 File Offset: 0x000092A4
		public string GetBoundsByImage(string ImagePath, Bitmap bitmap_screen = null, int timeWait_Second = 0)
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(ImagePath);
				FileInfo[] files = directoryInfo.GetFiles();
				int tickCount = Environment.TickCount;
				Bitmap bitmap;
				Point value;
				for (;;)
				{
					bool flag = bitmap_screen == null;
					if (flag)
					{
						bitmap_screen = this.ScreenShoot();
					}
					Point? point = null;
					foreach (FileInfo fileInfo in files)
					{
						bitmap = (Bitmap)Image.FromFile(fileInfo.FullName);
						point = this.FindOutPoint(bitmap_screen, bitmap, 0.9);
						bool flag2 = point != null;
						if (flag2)
						{
							value = point.Value;
							bool flag3 = value.X != 0 && value.Y != 0;
							if (flag3)
							{
								goto Block_5;
							}
						}
					}
					bool flag4 = Environment.TickCount - tickCount >= timeWait_Second * 1000;
					if (flag4)
					{
						goto Block_7;
					}
					this.DelayTime(1.0);
					bitmap_screen = this.ScreenShoot();
				}
				Block_5:
				return string.Format("[{0},{1}][{2},{3}]", new object[]
				{
					value.X,
					value.Y,
					value.X + bitmap.Width,
					value.Y + bitmap.Height
				});
				Block_7:;
			}
			catch (Exception)
			{
			}
			return "";
		}

		// Token: 0x06000153 RID: 339 RVA: 0x0000B230 File Offset: 0x00009430
		public bool CheckExistImage(string imagePath, Bitmap bitmap_screen = null, int timeWait = 0)
		{
			try
			{
				string boundsByImage = this.GetBoundsByImage(imagePath, bitmap_screen, timeWait);
				return boundsByImage != "";
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x0000B274 File Offset: 0x00009474
		public bool ClosePopup(ref string html)
		{
			bool flag = this.ClosePopup(html);
			bool result;
			if (flag)
			{
				html = this.GetHtml();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x0000B2A8 File Offset: 0x000094A8
		public static List<string> GetListTextClosePopup()
		{
			return new List<string>
			{
				"\"close\"",
				"\"skip\"",
				"\"cancel\"",
				"\"got it\""
			};
		}

		// Token: 0x06000156 RID: 342 RVA: 0x0000B2F0 File Offset: 0x000094F0
		public bool ClosePopup(string html = "")
		{
			bool flag = false;
			bool flag2 = this.CheckExistImage("DataClick\\image\\x", null, 0);
			if (flag2)
			{
				this.TapByImageWait("DataClick\\image\\x", 0, 3);
				flag = true;
			}
			else
			{
				bool flag3 = html == "";
				if (flag3)
				{
					html = this.GetHtml();
				}
				string text = this.CheckExistTextsV2(html, 0.0, Device.GetListTextClosePopup().ToArray());
				bool flag4 = text != "" && (!(text == "\"cancel\"") || !this.CheckExistText("request sent", html, 0.0));
				if (flag4)
				{
					this.TapByText(text, html, 0);
				}
			}
			bool flag5 = flag;
			if (flag5)
			{
				this.DelayTime(1.0);
				bool flag6 = this.CheckExistImage("DataClick\\image\\stop", null, 0);
				if (flag6)
				{
					this.TapByImageWait("DataClick\\image\\stop", 0, 10);
				}
				else
				{
					html = this.GetHtml();
					bool flag7 = this.CheckExistText("\"stop\"", html, 0.0);
					if (flag7)
					{
						this.TapByText("\"stop\"", html, 0);
					}
					bool flag8 = this.CheckExistText("\"dừng\"", html, 0.0);
					if (flag8)
					{
						this.TapByText("\"dừng\"", html, 0);
					}
				}
			}
			return flag;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x0000B454 File Offset: 0x00009654
		public string CheckExistTextsV2(string html, double timeWait_Second, params string[] text)
		{
			try
			{
				int tickCount = Environment.TickCount;
				int i;
				for (;;)
				{
					bool flag = html == "";
					if (flag)
					{
						html = this.GetHtml();
					}
					for (i = 0; i < text.Length; i++)
					{
						bool flag2 = Regex.IsMatch(html, text[i] + "(.*?)/>");
						if (flag2)
						{
							goto Block_3;
						}
					}
					bool flag3 = (double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0;
					if (flag3)
					{
						goto Block_5;
					}
					this.DelayTime(1.0);
					html = this.GetHtml();
				}
				Block_3:
				return text[i];
				Block_5:;
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000158 RID: 344 RVA: 0x0000B524 File Offset: 0x00009724
		public bool TapByImageWait(string imagePath, int timeWaitSearch = 0, int times = 10)
		{
			try
			{
				int tickCount = Environment.TickCount;
				while (this.CheckIsLive())
				{
					this.LoadStatusLD("Find Img: " + imagePath.Substring(imagePath.LastIndexOf('\\') + 1));
					string boundsByImage = this.GetBoundsByImage(imagePath, null, 0);
					bool flag = boundsByImage != "";
					if (flag)
					{
						this.LoadStatusLD("Click Img: " + imagePath.Substring(imagePath.LastIndexOf('\\') + 1));
						for (int i = 0; i < times; i++)
						{
							bool flag2 = !this.CheckIsLive();
							if (flag2)
							{
								goto IL_128;
							}
							this.TapByBounds(boundsByImage, "");
							this.DelayTime(1.0);
							string boundsByImage2 = this.GetBoundsByImage(imagePath, null, 0);
							bool flag3 = boundsByImage2 == "" || boundsByImage2 != boundsByImage;
							if (flag3)
							{
								return true;
							}
						}
					}
					bool flag4 = Environment.TickCount - tickCount >= timeWaitSearch * 1000;
					if (flag4)
					{
						break;
					}
					this.DelayTime(1.0);
				}
			}
			catch
			{
			}
			IL_128:
			return false;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0000B680 File Offset: 0x00009880
		private List<string> GetListActivityCheckpointFacebook()
		{
			return new List<string>
			{
				"com.facebook.katana/com.facebook.checkpoint.CheckpointActivity",
				"checkpoint"
			};
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0000B6B0 File Offset: 0x000098B0
		private List<string> GetListActivityNotLoginFacebook()
		{
			return new List<string>
			{
				"com.facebook.katana/com.facebook.katana.dbl.activity.DeviceBasedLoginActivity"
			};
		}

		// Token: 0x0600015B RID: 347 RVA: 0x0000B6D4 File Offset: 0x000098D4
		private int CheckStringContainText(string sChuoi, Dictionary<int, List<string>> dic)
		{
			foreach (KeyValuePair<int, List<string>> keyValuePair in dic)
			{
				foreach (string text in keyValuePair.Value)
				{
					bool flag = Regex.IsMatch(sChuoi, text) || sChuoi.Contains(text);
					if (flag)
					{
						return keyValuePair.Key;
					}
				}
			}
			return 0;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0000B78C File Offset: 0x0000998C
		private static List<string> GetListTextCheckpointFacebook()
		{
			return new List<string>
			{
				"your account is temporarily unavailable",
				"your account is temporarily locked",
				"your account has been disabled",
				"your account has been locked",
				"\"learn more\"",
				"download your information",
				"go to community standards",
				"choose a security check",
				"provide your birthday",
				"identify photos of friends",
				"get a code sent to your email",
				"enter number",
				"check the login details shown. was it you?"
			};
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0000B840 File Offset: 0x00009A40
		public int CheckStatusDevice(ref string html, bool isAllowClickImageX = true)
		{
			try
			{
				bool flag = !this.CheckIsLive();
				if (flag)
				{
					return -2;
				}
				Bitmap bitmap_screen = this.ScreenShoot();
				bool flag2 = this.CheckExistImage("DataClick\\image\\logout", bitmap_screen, 0);
				if (flag2)
				{
					return -11;
				}
				bool flag3 = this.CheckExistImage("DataClick\\image\\checkpoint", bitmap_screen, 0);
				if (flag3)
				{
					return 2;
				}
				bool flag4 = this.CheckExistImage("DataClick\\image\\openappagain", bitmap_screen, 0);
				if (flag4)
				{
					this.countOpenAppAgain++;
					bool flag5 = this.countOpenAppAgain >= 3;
					if (flag5)
					{
						return -4;
					}
					this.TapByImageWait("DataClick\\image\\openappagain", 0, 10);
					return 1;
				}
				else
				{
					string activity = this.GetActivity();
					bool flag6 = activity.Contains("Launcher");
					if (flag6)
					{
						this.OpenAppFacebook();
						return 1;
					}
					bool flag7 = activity == "Application";
					if (flag7)
					{
						return -4;
					}
					Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>
					{
						{
							1,
							this.GetListActivityCheckpointFacebook()
						},
						{
							2,
							this.GetListActivityNotLoginFacebook()
						}
					};
					int num = this.CheckStringContainText(activity, dic);
					int num2 = num;
					int num3 = num2;
					bool flag8 = num3 == 1;
					if (flag8)
					{
						return 2;
					}
					bool flag9 = num3 == 2;
					if (flag9)
					{
						return -12;
					}
					html = this.GetHtml();
					this.ClosePopup(ref html);
					List<string> listText = this.GetListText(html, 0);
					bool flag10 = listText.Count == 2 && listText.Contains("back") && (listText.Contains("search") || listText.Contains("web view"));
					if (flag10)
					{
						return -13;
					}
					bool flag11 = listText.Count == 3 && listText.Contains("back") && listText.Contains("facebook") && listText.Contains("web view");
					if (flag11)
					{
						return -14;
					}
					Dictionary<int, List<string>> dic2 = new Dictionary<int, List<string>>
					{
						{
							1,
							Device.GetListTextCheckpointFacebook()
						},
						{
							4,
							new List<string>
							{
								"session expired",
								"please log in again."
							}
						}
					};
					switch (this.CheckStringContainText(html, dic2))
					{
					case 1:
						return 2;
					case 2:
						return -4;
					case 3:
						return 7;
					case 4:
						return -15;
					default:
					{
						int i = 0;
						while (i < 2)
						{
							html = this.GetHtml();
							bool flag12 = this.CheckExistText("\"tap to retry\"", html, 0.0);
							if (flag12)
							{
								this.TapByText("\"tap to retry\"", html, 0);
								this.DelayTime(1.0);
								i++;
							}
							else
							{
								bool flag13 = false;
								bool flag14 = !flag13;
								if (flag14)
								{
									this.demDisconnect = 0;
								}
								else
								{
									bool flag15 = this.demDisconnect < this.maxDisconnect;
									if (flag15)
									{
										this.demDisconnect++;
										flag13 = false;
									}
								}
								bool flag16 = flag13;
								if (flag16)
								{
									return 7;
								}
								break;
							}
						}
						break;
					}
					}
				}
			}
			catch
			{
			}
			return 0;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x0000BBA8 File Offset: 0x00009DA8
		public string OpenFacebookAndCheckStatusLogin(int timeout = 120)
		{
			string result = "0|";
			try
			{
				string text = "";
				int num = -1;
				int tickCount = Environment.TickCount;
				while (this.CheckIsLive())
				{
					string activity = this.GetActivity();
					bool flag = activity.Contains("Launcher");
					if (flag)
					{
						this.OpenAppFacebook();
					}
					else
					{
						bool flag2 = activity == "Application";
						if (flag2)
						{
							return "2|";
						}
						bool flag3 = activity == "";
						if (flag3)
						{
							bool flag4 = !this.ClosePopup(text);
							if (flag4)
							{
								bool flag5 = this.CheckExistText("\"close", text, 0.0);
								if (flag5)
								{
									this.TapByText("\"close", text, 0);
									this.TapByText("\"back\"", "", 0);
								}
								else
								{
									this.OpenAppFacebook();
								}
							}
						}
						else
						{
							List<string> list = new List<string>
							{
								"com.facebook.katana/com.facebook.katana.app.FacebookSplashScreenActivity",
								"com.facebook.katana/com.facebook.deeplinking.activity.StoryDeepLinkLoadingActivity",
								"com.facebook.katana/com.facebook.resources.impl.WaitingForStringsActivity"
							};
							bool flag6 = !list.Contains(activity);
							if (flag6)
							{
								Bitmap bitmap_screen = this.ScreenShoot();
								string boundsByImage = this.GetBoundsByImage("DataClick\\image\\phoneoremail", bitmap_screen, 0);
								string boundsByImage2 = this.GetBoundsByImage("DataClick\\image\\password", bitmap_screen, 0);
								string boundsByImage3 = this.GetBoundsByImage("DataClick\\image\\login", bitmap_screen, 0);
								bool flag7 = boundsByImage != "" && boundsByImage2 != "" && boundsByImage3 != "";
								if (flag7)
								{
									return "1|0";
								}
								bool flag8 = this.CheckExistImage("DataClick\\image\\checkpoint", null, 0);
								if (flag8)
								{
									num = 2;
								}
								else
								{
									text = "";
									bool flag9 = this.CheckExistImage("DataClick\\image\\ok", null, 0) && !this.CheckExistImage("DataClick\\image\\facebook", null, 0);
									if (flag9)
									{
										this.TapByImageWait("DataClick\\image\\ok", 0, 10);
									}
									else
									{
										bool flag10 = this.CheckExistText("\"ok\"", ref text, 0.0);
										if (flag10)
										{
											this.TapByText("\"ok\"", text, 0);
										}
										else
										{
											bool flag11 = !this.ClosePopup(text) && this.CheckExistText("\"close", text, 0.0);
											if (flag11)
											{
												this.TapByText("\"close", text, 0);
												this.TapByText("\"back\"", "", 0);
											}
										}
									}
									num = this.CheckStatusLoginFacebookByActivity(activity);
									bool flag12 = num == -1;
									if (flag12)
									{
										text = this.GetHtml();
										num = this.CheckStatusLoginFacebookByText(text);
									}
								}
								bool flag13 = Environment.TickCount - tickCount >= timeout * 1000;
								if (flag13)
								{
									break;
								}
							}
						}
					}
					bool flag14 = num == -1;
					if (!flag14)
					{
						bool flag15 = num != -1;
						if (flag15)
						{
							result = "1|" + num.ToString();
						}
						return result;
					}
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0000BECC File Offset: 0x0000A0CC
		public bool CheckExistText(string text, ref string html, double timeWait_Second = 0.0)
		{
			try
			{
				int tickCount = Environment.TickCount;
				for (;;)
				{
					bool flag = string.IsNullOrEmpty(html);
					if (flag)
					{
						html = this.GetHtml();
					}
					bool flag2 = Regex.IsMatch(html, text + "(.*?)/>");
					if (flag2)
					{
						break;
					}
					bool flag3 = (double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0;
					if (flag3)
					{
						goto Block_4;
					}
					this.DelayTime(1.0);
					html = this.GetHtml();
				}
				return true;
				Block_4:;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x0000BF74 File Offset: 0x0000A174
		private static List<string> GetListTextLoginedFacebook()
		{
			return new List<string>
			{
				"\"search facebook\"",
				"\"go to profile\"",
				"\"make a post on facebook\"",
				"\"live\"",
				"\"messaging\"",
				"\"photo\"",
				"\"check in\"",
				"\"stories\"",
				"\"marketplace\"",
				"\"notifications,",
				"\"save your login info\""
			};
		}

		// Token: 0x06000161 RID: 353 RVA: 0x0000C010 File Offset: 0x0000A210
		private static List<string> GetListTextLoginedNoveryFacebook()
		{
			return new List<string>
			{
				"\"confirmation code\"",
				"\"change phone number\"",
				"\"confirm by email\"",
				"\"change email address\"",
				"\"confirm by phone number\""
			};
		}

		// Token: 0x06000162 RID: 354 RVA: 0x0000C064 File Offset: 0x0000A264
		private int CheckStatusLoginFacebookByText(string xml)
		{
			int result = 0;
			try
			{
				bool flag = xml == "";
				if (flag)
				{
					xml = this.GetHtml();
				}
				this.ClosePopup(ref xml);
				bool flag2 = this.CheckExistTexts(xml, 0.0, Device.GetListTextLoginedFacebook().ToArray()) != 0;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					bool flag3 = this.CheckExistTexts(xml, 0.0, Device.GetListTextCheckpointFacebook().ToArray()) != 0;
					if (flag3)
					{
						result = 2;
					}
					else
					{
						bool flag4 = this.CheckExistTexts(xml, 0.0, Device.GetListTextLoginedNoveryFacebook().ToArray()) != 0;
						if (flag4)
						{
							result = 8;
						}
						else
						{
							bool flag5 = this.CheckExistTexts(xml, 0.0, new string[]
							{
								"session expired",
								"please log in again."
							}) != 0;
							if (flag5)
							{
								result = 11;
							}
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x0000C164 File Offset: 0x0000A364
		private bool CheckItemIsExistInList(string item, List<string> lst)
		{
			for (int i = 0; i < lst.Count; i++)
			{
				bool flag = item.Contains(lst[i]);
				if (flag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0000C1A4 File Offset: 0x0000A3A4
		private List<string> GetListActivityLoginedFacebook()
		{
			return new List<string>
			{
				"com.facebook.katana/com.facebook.katana.activity.FbMainTabActivity",
				"com.facebook.katana/com.facebook.location.optin.DeviceLocationSettingsOptInActivity",
				"com.facebook.katana/com.facebook.location.optin.AccountLocationSettingsOptInActivity",
				"com.facebook.katana/com.facebook.account.switcher.nux.ActivateDeviceBasedLoginNuxActivity"
			};
		}

		// Token: 0x06000165 RID: 357 RVA: 0x0000C1EC File Offset: 0x0000A3EC
		private List<string> GetListActivityLoginedNoveryFacebook()
		{
			return new List<string>
			{
				"com.facebook.confirmation.activity.SimpleConfirmAccountActivity"
			};
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0000C210 File Offset: 0x0000A410
		private int CheckStatusLoginFacebookByActivity(string activity)
		{
			int result = -1;
			try
			{
				bool flag = this.CheckItemIsExistInList(activity, this.GetListActivityLoginedFacebook());
				if (flag)
				{
					result = 1;
				}
				else
				{
					bool flag2 = this.CheckItemIsExistInList(activity, this.GetListActivityCheckpointFacebook());
					if (flag2)
					{
						result = 2;
					}
					else
					{
						bool flag3 = this.CheckItemIsExistInList(activity, this.GetListActivityLoginedNoveryFacebook());
						if (flag3)
						{
							result = 8;
						}
						else
						{
							bool flag4 = this.CheckItemIsExistInList(activity, this.GetListActivityNotLoginFacebook());
							if (flag4)
							{
								result = 0;
							}
						}
					}
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0000C29C File Offset: 0x0000A49C
		public void Close()
		{
			try
			{
				ADBHelper.QuitDevice(this.PathLDPlayer, this.IndexDevice);
			}
			catch
			{
			}
		}

		// Token: 0x06000168 RID: 360 RVA: 0x0000C2D8 File Offset: 0x0000A4D8
		public void CloseAppFacebook()
		{
			this.CloseApp("com.facebook.katana");
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000C2E7 File Offset: 0x0000A4E7
		public void CloseAppInstagram()
		{
			this.CloseApp("com.instagram.android");
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000C2F8 File Offset: 0x0000A4F8
		public void CloseApp(string package)
		{
			bool flag = this.CheckIsLive();
			if (flag)
			{
				ADBHelper.CloseApp(this.DeviceId, package);
			}
		}

		// Token: 0x0600016B RID: 363 RVA: 0x0000C320 File Offset: 0x0000A520
		public void GotoBack(int times = 1, double timeDelay_seconds = 0.0)
		{
			for (int i = 0; i < times; i++)
			{
				this.InputKey(Device.KeyEvent.KEYCODE_BACK);
				this.DelayTime(timeDelay_seconds);
			}
		}

		// Token: 0x0600016C RID: 364 RVA: 0x0000C350 File Offset: 0x0000A550
		public bool WaitForTextDisappear(double timeWait_Second = 0.0, params string[] text)
		{
			try
			{
				int tickCount = Environment.TickCount;
				for (;;)
				{
					string html = this.GetHtml();
					for (int i = 0; i < text.Length; i++)
					{
						bool flag = !Regex.IsMatch(html, text[i] + "(.*?)/>");
						if (flag)
						{
							goto Block_2;
						}
					}
					bool flag2 = (double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0;
					if (flag2)
					{
						goto Block_4;
					}
					this.DelayTime(1.0);
				}
				Block_2:
				return true;
				Block_4:;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x0600016D RID: 365 RVA: 0x0000C3FC File Offset: 0x0000A5FC
		public List<string> GetListBoundsByText(string text, string html = "", int timeWait_Second = 0)
		{
			List<string> list = new List<string>();
			try
			{
				int tickCount = Environment.TickCount;
				for (;;)
				{
					bool flag = html == "";
					if (flag)
					{
						html = this.GetHtml();
					}
					MatchCollection matchCollection = Regex.Matches(html, text.Replace("[", "\\[").Replace("]", "\\]") + "(.*?)/>");
					for (int i = 0; i < matchCollection.Count; i++)
					{
						list.Add(Regex.Match(matchCollection[i].Value, "bounds=\"(.*?)\"").Groups[1].Value);
					}
					bool flag2 = list.Count > 0 || Environment.TickCount - tickCount >= timeWait_Second * 1000;
					if (flag2)
					{
						break;
					}
					this.DelayTime(1.0);
					html = this.GetHtml();
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		// Token: 0x0600016E RID: 366 RVA: 0x0000C518 File Offset: 0x0000A718
		public Bitmap Crop(Bitmap bm, string bounds)
		{
			string[] array = bounds.Split(new char[]
			{
				'[',
				',',
				']'
			});
			return bm.Clone(new Rectangle(Convert.ToInt32(array[1]), Convert.ToInt32(array[2]), Convert.ToInt32(array[4]) - Convert.ToInt32(array[1]), Convert.ToInt32(array[5]) - Convert.ToInt32(array[2])), bm.PixelFormat);
		}

		// Token: 0x0600016F RID: 367 RVA: 0x0000C585 File Offset: 0x0000A785
		public void Swipe(int x1, int y1, int x2, int y2, int duration = 100)
		{
			ADBHelper.Swipe(this.DeviceId, x1, y1, x2, y2, duration);
		}

		// Token: 0x06000170 RID: 368 RVA: 0x0000C59C File Offset: 0x0000A79C
		public bool SwipeByBounds(string bounds1, string bounds2, int duration = 100)
		{
			try
			{
				Point locationFromBounds = this.GetLocationFromBounds(bounds1);
				int x = locationFromBounds.X;
				int y = locationFromBounds.Y;
				Point locationFromBounds2 = this.GetLocationFromBounds(bounds2);
				int x2 = locationFromBounds2.X;
				int y2 = locationFromBounds2.Y;
				this.Swipe(x, y, x2, y2, duration);
				return true;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x06000171 RID: 369 RVA: 0x0000C60C File Offset: 0x0000A80C
		public bool ScrollAndCheckScreenNotChange(int timeScroll = 1000, int typeScroll = 1, string bounds1 = "[100,391][219,423]", string bounds2 = "[181,195][286,226]", string boundsCheck = "[72,165][216,294]")
		{
			try
			{
				int num = 3;
				Bitmap bitmap = this.ScreenShoot();
				bool flag = bitmap != null;
				if (flag)
				{
					Bitmap bitmap2 = this.Crop(bitmap, boundsCheck);
					for (int i = 0; i < num; i++)
					{
						bool flag2 = typeScroll == 1;
						if (flag2)
						{
							this.SwipeByBounds(bounds1, bounds2, timeScroll);
						}
						else
						{
							this.SwipeByBounds(bounds2, bounds1, timeScroll);
						}
						this.DelayTime(1.0);
						string boundsByImage = this.GetBoundsByImage(bitmap2, null, 0);
						bool flag3 = boundsCheck != boundsByImage;
						if (flag3)
						{
							return false;
						}
					}
				}
				else
				{
					for (int j = 0; j < num; j++)
					{
						string html = this.GetHtml();
						bool flag4 = typeScroll == 1;
						if (flag4)
						{
							this.SwipeByBounds(bounds1, bounds2, timeScroll);
						}
						else
						{
							this.SwipeByBounds(bounds2, bounds1, timeScroll);
						}
						string html2 = this.GetHtml();
						bool flag5 = html != html2;
						if (flag5)
						{
							return false;
						}
					}
				}
			}
			catch (Exception)
			{
			}
			return true;
		}

		// Token: 0x06000172 RID: 370 RVA: 0x0000C730 File Offset: 0x0000A930
		public bool CheckExistText(string text, string html = "", double timeWait_Second = 0.0)
		{
			try
			{
				int tickCount = Environment.TickCount;
				for (;;)
				{
					bool flag = html == "";
					if (flag)
					{
						html = this.GetHtml();
					}
					bool flag2 = Regex.IsMatch(html, text + "(.*?)/>");
					if (flag2)
					{
						break;
					}
					bool flag3 = (double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0;
					if (flag3)
					{
						goto Block_4;
					}
					this.DelayTime(1.0);
					html = this.GetHtml();
				}
				return true;
				Block_4:;
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x06000173 RID: 371 RVA: 0x0000C7D8 File Offset: 0x0000A9D8
		public int CheckExistTexts(string html = "", double timeWait_Second = 0.0, params string[] text)
		{
			int result = 0;
			try
			{
				int tickCount = Environment.TickCount;
				int i;
				for (;;)
				{
					bool flag = html == "";
					if (flag)
					{
						html = this.GetHtml();
					}
					for (i = 0; i < text.Length; i++)
					{
						bool flag2 = Regex.IsMatch(html, text[i] + "(.*?)/>");
						if (flag2)
						{
							goto Block_4;
						}
					}
					bool flag3 = (double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0;
					if (flag3)
					{
						goto Block_6;
					}
					this.DelayTime(1.0);
					html = this.GetHtml();
				}
				Block_4:
				return i + 1;
				Block_6:;
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000174 RID: 372 RVA: 0x0000C8A8 File Offset: 0x0000AAA8
		public string ExecuteCMD(string cmd, int timeout = 10)
		{
			bool flag = !this.CheckIsLive();
			string result;
			if (flag)
			{
				result = "";
			}
			else
			{
				bool flag2 = this.GetActivity() != "com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity" && cmd.Contains(ADBCommands.VIEW.Substring(0, ADBCommands.VIEW.IndexOf("\"")));
				if (flag2)
				{
					this.ClosePopup("");
				}
				result = ADBHelper.RunCMD(this.DeviceId, cmd, timeout);
			}
			return result;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x0000C92C File Offset: 0x0000AB2C
		public void OpenApp(string package)
		{
			bool flag = this.CheckIsLive();
			if (flag)
			{
				ADBHelper.OpenApp(this.DeviceId, package);
			}
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0000C954 File Offset: 0x0000AB54
		public string GetActivity()
		{
			try
			{
				bool flag = !this.CheckIsLive();
				if (flag)
				{
					return "";
				}
				return ADBHelper.DumpActivity(this.DeviceId).Split(new char[]
				{
					'{',
					'}'
				})[1].Split(new char[]
				{
					' '
				})[2];
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000C9D0 File Offset: 0x0000ABD0
		public Point GetLocationFromBounds(string bounds)
		{
			try
			{
				string[] array = bounds.Split(new char[]
				{
					'[',
					',',
					']'
				});
				int x = this.rd.Next(Convert.ToInt32(array[1]), Convert.ToInt32(array[4]));
				int y = this.rd.Next(Convert.ToInt32(array[2]), Convert.ToInt32(array[5]));
				return new Point(x, y);
			}
			catch
			{
			}
			return default(Point);
		}

		// Token: 0x06000178 RID: 376 RVA: 0x0000CA5C File Offset: 0x0000AC5C
		public bool TapByBounds(string bounds, string onlyInBounds = "")
		{
			try
			{
				Point locationFromBounds = this.GetLocationFromBounds(bounds);
				int x = locationFromBounds.X;
				int y = locationFromBounds.Y;
				bool flag = onlyInBounds == "" || this.CheckBoundsContainLocation(onlyInBounds, x, y);
				if (flag)
				{
					return this.Tap(x, y, 1);
				}
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x06000179 RID: 377 RVA: 0x0000CAD0 File Offset: 0x0000ACD0
		public bool Tap(int x, int y, int delay = 1)
		{
			bool flag = this.CheckBoundsContainLocation("[0,0][320,480]", x, y);
			bool result;
			if (flag)
			{
				ADBHelper.Tap(this.DeviceId, x, y);
				this.DelayTime((double)delay);
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600017A RID: 378 RVA: 0x0000CB18 File Offset: 0x0000AD18
		public bool CheckBoundsContainLocation(string bounds, int x, int y)
		{
			string[] array = bounds.Split(new char[]
			{
				'[',
				',',
				']'
			});
			return x >= Convert.ToInt32(array[1]) && x <= Convert.ToInt32(array[4]) && y >= Convert.ToInt32(array[2]) && y <= Convert.ToInt32(array[5]);
		}

		// Token: 0x0600017B RID: 379 RVA: 0x0000CB74 File Offset: 0x0000AD74
		public string GetHtml()
		{
			string result = "";
			try
			{
				bool flag = this.GetActivity().Contains("com.facebook.katana/com.facebook.video.channelfeed.activity.ChannelFeedActivity");
				if (flag)
				{
					return "";
				}
				result = ADBHelper.GetXML(this.DeviceId);
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x0600017C RID: 380 RVA: 0x0000CBD0 File Offset: 0x0000ADD0
		public bool OpenAppFacebook1(int timeout = 180)
		{
			bool flag = false;
			int tickCount = Environment.TickCount;
			while (!flag)
			{
				bool flag2 = Environment.TickCount - tickCount < timeout * 1000 && this.CheckIsLive();
				if (flag2)
				{
					string activity = this.GetActivity();
					bool flag3 = activity.Contains("Launcher");
					if (flag3)
					{
						this.OpenAppFacebook();
					}
					else
					{
						List<string> list = new List<string>
						{
							"",
							"com.facebook.katana/com.facebook.deeplinking.activity.StoryDeepLinkLoadingActivity",
							"com.facebook.katana/com.facebook.katana.app.FacebookSplashScreenActivity",
							"com.facebook.katana/com.facebook.resources.impl.WaitingForStringsActivity"
						};
						bool flag4 = list.Contains(activity);
						if (flag4)
						{
							bool flag5 = !(activity == "com.facebook.katana/com.facebook.resources.impl.WaitingForStringsActivity") && activity == "";
							if (flag5)
							{
								this.ClosePopup("");
							}
						}
						else
						{
							bool flag6 = activity == "com.facebook.katana/com.facebook.account.login.activity.SimpleLoginActivity";
							if (flag6)
							{
								flag = true;
								break;
							}
						}
					}
				}
			}
			return flag;
		}

		// Token: 0x0600017D RID: 381 RVA: 0x0000CCE4 File Offset: 0x0000AEE4
		public int CheckExistTexts(string html, double timeWait_Second, Dictionary<int, List<string>> dic)
		{
			int result = 0;
			try
			{
				int tickCount = Environment.TickCount;
				for (;;)
				{
					bool flag = html == "";
					if (flag)
					{
						html = this.GetHtml();
					}
					foreach (KeyValuePair<int, List<string>> keyValuePair in dic)
					{
						foreach (string str in keyValuePair.Value)
						{
							bool flag2 = Regex.IsMatch(html, str + "(.*?)/>");
							if (flag2)
							{
								return keyValuePair.Key;
							}
						}
					}
					bool flag3 = (double)(Environment.TickCount - tickCount) >= timeWait_Second * 1000.0;
					if (flag3)
					{
						break;
					}
					this.DelayTime(1.0);
					html = this.GetHtml();
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x0600017E RID: 382 RVA: 0x0000CE1C File Offset: 0x0000B01C
		public string GetBoundsByText(string text, string html = "", int timeWait_Second = 0)
		{
			try
			{
				this.LoadStatusLD("Find Text: " + text);
				int tickCount = Environment.TickCount;
				while (this.CheckIsLive())
				{
					bool flag = html == "";
					if (flag)
					{
						html = this.GetHtml();
					}
					string value = Regex.Match(html, text.Replace("[", "\\[").Replace("]", "\\]") + "(.*?)/>").Groups[1].Value;
					bool flag2 = value != "";
					if (flag2)
					{
						return Regex.Match(value, "bounds=\"(.*?)\"").Groups[1].Value;
					}
					bool flag3 = Environment.TickCount - tickCount >= timeWait_Second * 1000;
					if (flag3)
					{
						break;
					}
					this.DelayTime(1.0);
					html = this.GetHtml();
				}
			}
			catch (Exception)
			{
			}
			return "";
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000CF38 File Offset: 0x0000B138
		public bool CheckBoundsContainLocation(string bounds, Point point)
		{
			int x = point.X;
			int y = point.Y;
			return this.CheckBoundsContainLocation(bounds, x, y);
		}

		// Token: 0x06000180 RID: 384 RVA: 0x0000CF64 File Offset: 0x0000B164
		public bool TapByText(string text, string html = "", int timeWait_Second = 0)
		{
			string boundsByText = this.GetBoundsByText(text, html, timeWait_Second);
			bool flag = !string.IsNullOrEmpty(boundsByText);
			bool result;
			if (flag)
			{
				this.LoadStatusLD("Click Text: " + text);
				result = this.TapByBounds(boundsByText, "");
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x0000CFB8 File Offset: 0x0000B1B8
		public void InputTextWithUnicode(string text, double timeDelay = 0.0)
		{
			ADBHelper.SwitchAdbkeyboard(this.DeviceId);
			this.LoadStatusLD("Send: " + text);
			bool flag = timeDelay == 0.0;
			if (flag)
			{
				this.ExecuteCMD("shell am broadcast -a ADB_INPUT_B64 --es msg '" + Convert.ToBase64String(Encoding.UTF8.GetBytes(text.ToString())) + "'", 10);
			}
			else
			{
				timeDelay = ((timeDelay > 0.35) ? (timeDelay - 0.35) : 0.0);
				for (int i = 0; i < text.Length; i++)
				{
					this.ExecuteCMD("shell am broadcast -a ADB_INPUT_B64 --es msg '" + Convert.ToBase64String(Encoding.UTF8.GetBytes(text[i].ToString())) + "'", 10);
					this.DelayTime(timeDelay);
				}
			}
			ADBHelper.SwitchAndroidKeyboard(this.DeviceId, this.lstPackages);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x0000D0B2 File Offset: 0x0000B2B2
		public void InputKey(Device.KeyEvent key)
		{
			this.ExecuteCMD("shell input keyevent " + key.ToString(), 10);
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0000D0D5 File Offset: 0x0000B2D5
		public void InputText(string text)
		{
			this.LoadStatusLD("Send: " + text);
			ADBHelper.InputText(this.DeviceId, text);
		}

		// Token: 0x06000184 RID: 388 RVA: 0x0000D0F8 File Offset: 0x0000B2F8
		public void OpenAppFacebook()
		{
			try
			{
				this.GrantPermission();
				this.OpenApp("com.facebook.katana");
				for (int i = 0; i < 10; i++)
				{
					string activity = this.GetActivity();
					bool flag = activity.Contains("com.facebook.katana");
					if (flag)
					{
						break;
					}
					bool flag2 = activity.Contains("Launcher");
					if (flag2)
					{
						this.TapByText("facebook", "", 0);
					}
					else
					{
						this.OpenApp("com.facebook.katana");
					}
					this.DelayTime(3.0);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x0000D1A4 File Offset: 0x0000B3A4
		public void OpenAppInstagram()
		{
			this.GrantPermissionInsta();
			this.OpenApp("com.instagram.android");
			for (int i = 0; i < 10; i++)
			{
				string activity = this.GetActivity();
				bool flag = activity.Contains("com.instagram.android");
				if (flag)
				{
					break;
				}
				bool flag2 = activity.Contains("Launcher");
				if (flag2)
				{
					this.TapByText("instagram", "", 0);
				}
				else
				{
					this.OpenApp("com.instagram.android");
				}
				this.DelayTime(3.0);
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x0000D238 File Offset: 0x0000B438
		public List<string> GetListPackages()
		{
			return ADBHelper.GetListPackages(this.DeviceId);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x0000D258 File Offset: 0x0000B458
		public bool InstallApp(string fileApkFromComputer)
		{
			bool flag = !this.CheckIsLive();
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				ADBHelper.InstallApp(this.DeviceId, fileApkFromComputer);
				result = true;
			}
			return result;
		}

		// Token: 0x06000188 RID: 392 RVA: 0x0000D290 File Offset: 0x0000B490
		public void RestoreConfigDevice(string uid)
		{
			string sourceFileName = FileHelper.GetPathToCurrentFolder() + "\\device\\" + uid + "\\config";
			File.Copy(sourceFileName, this.PathLDPlayer + "\\vms\\config\\leidian" + this.IndexDevice.ToString() + ".config", true);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x0000D2DC File Offset: 0x0000B4DC
		public void LoadHanhDongLD(string content)
		{
			bool flag = frmViewLD.remote != null;
			if (flag)
			{
				frmViewLD.remote.LoadHanhDong(this.IndexDevice, content);
			}
		}

		// Token: 0x0600018A RID: 394 RVA: 0x0000D30C File Offset: 0x0000B50C
		private List<string> GetListInfoDevice()
		{
			new List<string>();
			string text = Common.Base64Decode("QXN1c3xBbGNhdGVsIFBpeGkgNCAoNSkqQXN1c3xBc3VzIFJPRyBQaG9uZSpBc3VzfEFzdXMgWmVuZm9uZSAyIExhc2VyKkFzdXN8QXN1cyBaZW5Gb25lIDMqQXN1c3xBc3VzIFplbmZvbmUgMypBc3VzfEFzdXMgWmVuZm9uZSAzIERlbHV4ZSA1LjUqQXN1c3xBc3VzIFplbmZvbmUgMyBMYXNlcipBc3VzfEFzdXMgWmVuZm9uZSAzIE1heCpBc3VzfEFzdXMgWmVuZm9uZSAzIFVsdHJhKkFzdXN8QXN1cyBaZW5mb25lIDMgWm9vbSpBc3VzfEFzdXMgWmVuZm9uZSAzcyBNYXgqQXN1c3xBc3VzIFplbkZvbmUgNCAoWkU1NTRLTCkqQXN1c3xBc3VzIFplbkZvbmUgNCBNYXgqQXN1c3xBc3VzIFplbkZvbmUgNCBNYXggUHJvIChaQzU1NEtMKSpBc3VzfEFzdXMgWmVuRm9uZSA0IFBybypBc3VzfEFzdXMgWmVuRm9uZSA0IFNlbGZpZSAoWkQ1NTNLTCkqQXN1c3xBc3VzIFplbkZvbmUgNCBTZWxmaWUgUHJvIChaRDU1MktMKSpBc3VzfEFzdXMgWmVuZm9uZSA1KkFzdXN8QXN1cyBaZW5mb25lIDUgTGl0ZSpBc3VzfEFzdXMgWmVuZm9uZSA1USpBc3VzfEFzdXMgWmVuZm9uZSA1WipBc3VzfEFzdXMgWmVuZm9uZSBBUipBc3VzfEFzdXMgWmVuZm9uZSBHbypBc3VzfEFzdXMgWmVuZm9uZSBHbyAoWkI1NTJLTCkqQXN1c3xBc3VzIFplbkZvbmUgTGl2ZSAoTDEpIFpBNTUwS0wqQXN1c3xBc3VzIFplbmZvbmUgTGl2ZSAoWkI1MDFLTCkqQXN1c3xBc3VzIFplbmZvbmUgTWF4KkFzdXN8QXN1cyBaZW5mb25lIE1heCAoTTEpIFpCNTU1S0wqQXN1c3xBc3VzIFplbmZvbmUgTWF4IFBsdXMgKE0xKSBaQjU3MFRMKkFzdXN8QXN1cyBaZW5mb25lIE1heCBQcm8gKE0xKSBaQjYwMUtMKkFzdXN8QXN1cyBaZW5mb25lIE1heCBQcm8gTTEqQXN1c3xBc3VzIFplbkZvbmUgTWF4IFBybyBNMSpBc3VzfEFzdXMgWmVuZm9uZSBWIFY1MjBLTCpBc3VzfEFzdXMgWmVuUGFkIDNzIDEwKkFzdXN8QXN1cyBaZW5QYWQgM3MgOC4wKkFzdXN8QXN1cyBaZW5QYWQgWjEwKkFzdXN8QXN1cyBaZW5wYWQgWjhzIChaVDU4MktMKSpBc3VzfEJsdWJvbyBENipBc3VzfEJRIEFxdWFyaXMgTTUqQXN1c3xEb29nZWUgWDUgTWF4KkFzdXN8RWxlcGhvbmUgVSBQcm8qQXN1c3xFc3NlbnRpYWwgUGhvbmUgUEgtMSpBc3VzfEdlbmVyYWwgTW9iaWxlIEdNIDUqR29vZ2xlfEdvb2dsZSBOZXh1cyAxMCpHb29nbGV8R29vZ2xlIE5leHVzIDQqR29vZ2xlfEdvb2dsZSBOZXh1cyA1Kkdvb2dsZXxHb29nbGUgTmV4dXMgNipHb29nbGV8R29vZ2xlIE5leHVzIDZQKkdvb2dsZXxHb29nbGUgUGl4ZWwqR29vZ2xlfEdvb2dsZSBQaXhlbCAyKkdvb2dsZXxHb29nbGUgUGl4ZWwgMiBYTCpHb29nbGV8R29vZ2xlIFBpeGVsIEMqR29vZ2xlfEdvb2dsZSBQaXhlbCBYTCpIVEN8SFRDIDEwKkhUQ3xIVEMgMTAgRXZvKkhUQ3xIVEMgMTAgTGlmZXN0eWxlKkhUQ3xIVEMgRGVzaXJlIDEwIExpZmVzdHlsZSpIVEN8SFRDIERlc2lyZSAxMCBQcm8qSFRDfEhUQyBEZXNpcmUgMTIqSFRDfEhUQyBEZXNpcmUgMTIrKkhUQ3xIVEMgT25lIE04KkhUQ3xIVEMgT25lIE05KkhUQ3xIVEMgVSBQbGF5KkhUQ3xIVEMgVSBVbHRyYSpIVEN8SFRDIFUxMSpIVEN8SFRDIFUxMSBFeWVzKkhUQ3xIVEMgVTExIExpZmUqSFRDfEhUQyBVMTErKkhUQ3xIVEMgVTEyIGxpZmUqSFRDfEhUQyBVMTIrKkh1YXdlaXxIdWF3ZWkgR1IzICgyMDE3KSpIdWF3ZWl8SHVhd2VpIEhvbm9yIDEwKkh1YXdlaXxIdWF3ZWkgSG9ub3IgNlgqSHVhd2VpfEh1YXdlaSBIb25vciA3QSpIdWF3ZWl8SHVhd2VpIEhvbm9yIDdzKkh1YXdlaXxIdWF3ZWkgSG9ub3IgN1gqSHVhd2VpfEh1YXdlaSBIb25vciA4IExpdGUqSHVhd2VpfEh1YXdlaSBIb25vciA4IFBybypIdWF3ZWl8SHVhd2VpIEhvbm9yIDkqSHVhd2VpfEh1YXdlaSBIb25vciA5IExpdGUqSHVhd2VpfEh1YXdlaSBIb25vciA5TiAoOWkpKkh1YXdlaXxIdWF3ZWkgSG9ub3IgTm90ZSAxMCpIdWF3ZWl8SHVhd2VpIEhvbm9yIFBsYXkqSHVhd2VpfEh1YXdlaSBIb25vciBWaWV3IDEwKkh1YXdlaXxIdWF3ZWkgTWF0ZSAxMCpIdWF3ZWl8SHVhd2VpIE1hdGUgMTAgTGl0ZSpIdWF3ZWl8SHVhd2VpIE1hdGUgMTAgUHJvKkh1YXdlaXxIdWF3ZWkgTWF0ZSAyMCBMaXRlKkh1YXdlaXxIdWF3ZWkgTWF0ZSA4Kkh1YXdlaXxIdWF3ZWkgTWF0ZSA5Kkh1YXdlaXxIdWF3ZWkgTWF0ZSA5IFBvcnNjaGUgRGVzaWduKkh1YXdlaXxIdWF3ZWkgTWF0ZSA5IFBybypIdWF3ZWl8SHVhd2VpIE5vdmEgMipIdWF3ZWl8SHVhd2VpIE5vdmEgMiBQbHVzKkh1YXdlaXxIdWF3ZWkgTm92YSAyaSpIdWF3ZWl8SHVhd2VpIG5vdmEgMypIdWF3ZWl8SHVhd2VpIE5vdmEgM2UqSHVhd2VpfEh1YXdlaSBub3ZhIDNpKkh1YXdlaXxIdWF3ZWkgTm92YSBMaXRlKkh1YXdlaXxIdWF3ZWkgUCBzbWFydCpIdWF3ZWl8SHVhd2VpIFAgU21hcnQrKkh1YXdlaXxIdWF3ZWkgUDEwKkh1YXdlaXxIdWF3ZWkgUDEwIExpdGUqSHVhd2VpfEh1YXdlaSBQMTAgUGx1cypIdWF3ZWl8SHVhd2VpIFAyMCpIdWF3ZWl8SHVhd2VpIFAyMCBMaXRlKkh1YXdlaXxIdWF3ZWkgUDIwIFBybypIdWF3ZWl8SHVhd2VpIFA4IExpdGUgKDIwMTcpKkh1YXdlaXxIdWF3ZWkgUDggTGl0ZSAyMDE3Kkh1YXdlaXxIdWF3ZWkgUDkgTGl0ZSpIdWF3ZWl8SHVhd2VpIFA5IExpdGUgKDIwMTcpKkh1YXdlaXxIdWF3ZWkgUDkgTGl0ZSAyMDE3Kkh1YXdlaXxIdWF3ZWkgWTMgKDIwMTgpKkh1YXdlaXxIdWF3ZWkgWTUgUHJpbWUgKDIwMTgpKkh1YXdlaXxIdWF3ZWkgWTYgKDIwMTgpKkh1YXdlaXxIdWF3ZWkgWTcgKDIwMTgpKkh1YXdlaXxIdWF3ZWkgWTcgUHJpbWUqSHVhd2VpfEh1YXdlaSBZNyBQcmltZSAyMDE4Kkh1YXdlaXxIdWF3ZWkgWTcgUHJvICgyMDE4KSpIdWF3ZWl8SVVOSSBVMipMZUVjb3xMZUVjbyBMZSAxcypMZUVjb3xMZUVjbyBMZSAyKkxlRWNvfExlRWNvIExlIE1heCAyKkxlRWNvfExlRWNvIExlIFBybyAzKkxlbm92b3xMZW5vdm8gQTUqTGVub3ZvfExlbm92byBBNjAwMCpMZW5vdm98TGVub3ZvIEE2MDAwIFBsdXMqTGVub3ZvfExlbm92byBBNjYwMCBQbHVzKkxlbm92b3xMZW5vdm8gSzMyMHQqTGVub3ZvfExlbm92byBLNSpMZW5vdm98TGVub3ZvIEs1IE5vdGUgKDIwMTgpKkxlbm92b3xMZW5vdm8gSzUgcGxheSpMZW5vdm98TGVub3ZvIEs2Kkxlbm92b3xMZW5vdm8gSzYgTm90ZSpMZW5vdm98TGVub3ZvIEs2IFBvd2VyKkxlbm92b3xMZW5vdm8gSzgqTGVub3ZvfExlbm92byBLOCBOb3RlKkxlbm92b3xMZW5vdm8gSzggUGx1cypMZW5vdm98TGVub3ZvIFAyKkxlbm92b3xMZW5vdm8gUzUqTGVub3ZvfExlbm92byBaNSpMZW5vdm98TGVub3ZvIFp1ayBFZGdlKkxlbm92b3xMZW5vdm8gWnVrIFoxKkxlbm92b3xMZW5vdm8gWnVrIFoyKkxlbm92b3xMZW5vdm8gWlVLIFoyIChQbHVzKSpMZW5vdm98TGVub3ZvIFp1ayBaMiBQcm8qTEd8TEcgQXJpc3RvIDIqTEd8TEcgRzIqTEd8TEcgRzMqTEd8TEcgRzUqTEd8TEcgRzYqTEd8TEcgRzcgRml0KkxHfExHIEc3IE9uZSpMR3xMRyBHNyBUaGluUSpMR3xMRyBHNyBUaGluUSBQbHVzKkxHfExHIEsxMCAyMDE4KkxHfExHIEsxMSBQbHVzKkxHfExHIEszMCpMR3xMRyBLOCAyMDE4KkxHfExHIE5leHVzIDVYKkxHfExHIFBhZCBJViA4LjAqTEd8TEcgUSBTdHlsdXMqTEd8TEcgUTYqTEd8TEcgUTcqTEd8TEcgUTgqTEd8TEcgVjEwKkxHfExHIFYyMCpMR3xMRyBWMzAqTEd8TEcgVjMwUyBUaGluUSpMR3xMRyBWMzUgVGhpblEqTEd8TEcgWCBWZW50dXJlKkxHfExHIFpvbmUgNCpNb3Rvcm9sYXxNb3RvIEMqTW90b3JvbGF8TW90byBFIDIwMTUqTW90b3JvbGF8TW90byBFNCpNb3Rvcm9sYXxNb3RvIEU0IFBsdXMqTW90b3JvbGF8TW90byBFNSpNb3Rvcm9sYXxNb3RvIEU1IFBsYXkqTW90b3JvbGF8TW90byBFNSBQbGF5IEdvKk1vdG9yb2xhfE1vdG8gRTUgUGx1cypNb3Rvcm9sYXxNb3RvIEcgMjAxMypNb3Rvcm9sYXxNb3RvIEcgMjAxNCpNb3Rvcm9sYXxNb3RvIEcgMjAxNSpNb3Rvcm9sYXxNb3RvIEc0Kk1vdG9yb2xhfE1vdG8gRzQgUGx1cypNb3Rvcm9sYXxNb3RvIEc1Kk1vdG9yb2xhfE1vdG8gRzUgUGx1cypNb3Rvcm9sYXxNb3RvIEc1UypNb3Rvcm9sYXxNb3RvIEc1UyBQbHVzKk1vdG9yb2xhfE1vdG8gRzYqTW90b3JvbGF8TW90byBHNiBQbGF5Kk1vdG9yb2xhfE1vdG8gRzYgUGx1cypNb3Rvcm9sYXxNb3RvIE0qTW90b3JvbGF8TW90byBYIFB1cmUqTW90b3JvbGF8TW90byBYNCpNb3Rvcm9sYXxNb3RvIFoqTW90b3JvbGF8TW90byBaIEZvcmNlKk1vdG9yb2xhfE1vdG8gWiBQbGF5Kk1vdG9yb2xhfE1vdG8gWjIgRm9yY2UqTW90b3JvbGF8TW90byBaMiBQbGF5Kk1vdG9yb2xhfE1vdG8gWjMqTW90b3JvbGF8TW90byBaMyBQbGF5Kk1vdG9yb2xhfE1vdG9yb2xhIE1vdG8gRTQqTW90b3JvbGF8TW90b3JvbGEgTW90byBHNiBQbHVzKk1vdG9yb2xhfE1vdG9yb2xhIE1vdG8gWCBQbGF5Kk1vdG9yb2xhfE1vdG9yb2xhIE9uZSBQb3dlcipNb3Rvcm9sYXxNb3Rvcm9sYSBQMzAqTW90b3JvbGF8TmV4dXMgNVgqTW90b3JvbGF8TmV4dXMgNlAqTW90b3JvbGF8TmV4dXMgUGxheWVyKk5va2lhfE5va2lhIDEqTm9raWF8Tm9raWEgMipOb2tpYXxOb2tpYSAyLjEqTm9raWF8Tm9raWEgMypOb2tpYXxOb2tpYSAzLjEqTm9raWF8Tm9raWEgNSpOb2tpYXxOb2tpYSA1LjEqTm9raWF8Tm9raWEgNS4xIFBsdXMqTm9raWF8Tm9raWEgNipOb2tpYXxOb2tpYSA2LjEqTm9raWF8Tm9raWEgNi4xIFBsdXMqTm9raWF8Tm9raWEgNypOb2tpYXxOb2tpYSA3IFBsdXMqTm9raWF8Tm9raWEgNy4xKk5va2lhfE5va2lhIDgqTm9raWF8Tm9raWEgOCBTaXJvY2NvKk5va2lhfE5va2lhIFg1Kk5va2lhfE5va2lhIFg2Kk5va2lhfE51YmlhIFoxNypPbmVQbHVzfE9uZVBsdXMgMipPbmVQbHVzfE9uZVBsdXMgMypPbmVQbHVzfE9uZVBsdXMgM1QqT25lUGx1c3xPbmVQbHVzIDUqT25lUGx1c3xPbmVQbHVzIDUvNVQqT25lUGx1c3xPbmVQbHVzIDVUKk9uZVBsdXN8T25lUGx1cyBPbmUqT25lUGx1c3xPbmVQbHVzIFgqUmVkbWl8UmVkbWkgM3MvM3gvUHJpbWUqUmVkbWl8UmVkbWkgNCBQcmltZSpSZWRtaXxSZWRtaSA0WCpSZWRtaXxSZWRtaSA1IFBsdXMqUmVkbWl8UmVkbWkgTm90ZSA1KlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTMgKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTUgKDIwMTYpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTUgKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTYgMjAxOCpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEE2KyAyMDE4KlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTcgKDIwMTYpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTcgKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTggKDIwMTYpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTggKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgQTggMjAxOCpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEE4IFN0YXIqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBBOCsgMjAxOCpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEE5IFBybypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEE5IFN0YXIqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBBbHBoYSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEM3IFBybypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEM5IFBybypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEdyYW5kIFByaW1lKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSipTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEoyIENvcmUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKMiBQcm8gKDIwMTgpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjMgKDIwMTgpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjQgKDIwMTgpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNSAoMjAxNykqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNiAoMjAxOCkqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNyAoMjAxOCkqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNyBEdW8qU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNyBNYXggKDIwMTcpKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjcgUHJpbWUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKNyBQcmltZSAyKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgSjcgUHJvICgyMDE3KSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IEo3IFYqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBKOCAoMjAxOCkqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBNZWdhIDYuMypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IE5vdGUgMypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IE5vdGUgOCpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IE5vdGUgOSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IE5vdGUgRkUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBPbjYqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTMipTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFM0KlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgUzQgTWluaSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFM1IFtrbHRlXSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFM2KlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgUzcqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTNyBBY3RpdmUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTNyBFZGdlKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgUzgqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTOCBBY3RpdmUqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTOCBQbHVzKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgUzkqU2Ftc3VuZ3xTYW1zdW5nIEdhbGF4eSBTOSBQbHVzKlNhbXN1bmd8U2Ftc3VuZyBHYWxheHkgVGFiIEEgMTAuNSpTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFRhYiBBIDkuNypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFRhYiBFIDkuNipTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFRhYiBTMypTYW1zdW5nfFNhbXN1bmcgR2FsYXh5IFRhYiBTNCAxMC41KlNvbnl8U29ueSBYcGVyaWEgRTUqU29ueXxTb255IFhwZXJpYSBMMSpTb255fFNvbnkgWHBlcmlhIFIxIChQbHVzKSpTb255fFNvbnkgWHBlcmlhIFRvdWNoKlNvbnl8U29ueSBYcGVyaWEgWCpTb255fFNvbnkgWHBlcmlhIFggQ29tcGFjdCpTb255fFNvbnkgWHBlcmlhIFggUGVyZm9ybWFuY2UqU29ueXxTb255IFhwZXJpYSBYQSpTb255fFNvbnkgWHBlcmlhIFhBIFVsdHJhKlNvbnl8U29ueSBYcGVyaWEgWEExKlNvbnl8U29ueSBYcGVyaWEgWEExIFBsdXMqU29ueXxTb255IFhwZXJpYSBYQTEgVWx0cmEqU29ueXxTb255IFhwZXJpYSBYQTIqU29ueXxTb255IFhwZXJpYSBYQTIgUGx1cypTb255fFNvbnkgWHBlcmlhIFhBMiBVbHRyYSpTb255fFNvbnkgWHBlcmlhIFhaKlNvbnl8U29ueSBYcGVyaWEgWFogUHJlbWl1bSpTb255fFNvbnkgWHBlcmlhIFhaMSpTb255fFNvbnkgWHBlcmlhIFhaMSBDb21wYWN0KlNvbnl8U29ueSBYcGVyaWEgWFoyKlNvbnl8U29ueSBYcGVyaWEgWFoyIENvbXBhY3QqU29ueXxTb255IFhwZXJpYSBYWjIgUHJlbWl1bSpTb255fFNvbnkgWHBlcmlhIFhacypTb255fFNvbnkgWHBlcmlhIFoxKlNvbnl8U29ueSBYcGVyaWEgWjUqU29ueXxTb255IFhwZXJpYSBaNSBQcmVtaXVtKlNvbnl8U3ByaW50IEdhbGF4eSBUYWIgRSA4LjAqVml2b3x2aXZvIE5FWCpWaXZvfHZpdm8gTkVYIEEqVml2b3x2aXZvIE5FWCBTKlZpdm98dml2byBWMTEqVml2b3x2aXZvIFYxMSBQcm8qVml2b3x2aXZvIFYxMWkqVml2b3x2aXZvIFY3KlZpdm98dml2byBWNyBQbHVzKlZpdm98dml2byBWOSpWaXZvfHZpdm8gVjkgWW91dGgqVml2b3x2aXZvIFgyMCpWaXZvfHZpdm8gWDIwIFBsdXMqVml2b3x2aXZvIFgyMCBVRCpWaXZvfHZpdm8gWDIxKlZpdm98dml2byBYMjEgVUQqVml2b3x2aXZvIFgyMWkqVml2b3x2aXZvIFgyMypWaXZvfFZpdm8gWDkqVml2b3xWaXZvIFg5IFBsdXMqVml2b3xWaXZvIFg5cypWaXZvfFZpdm8gWDlzIFBsdXMqVml2b3x2aXZvIFk1M2kqVml2b3x2aXZvIFk3MSpWaXZvfHZpdm8gWTcxaSpWaXZvfHZpdm8gWTgxKlZpdm98dml2byBZODMqVml2b3x2aXZvIFk4MyBQcm8qVml2b3x2aXZvIFk5NypWaXZvfHZpdm8gWjEqVml2b3x2aXZvIFoxaSpWaXZvfFdpbGV5Zm94IFN3aWZ0KlhpYW9taXxYaWFvbWkgTWkgMypYaWFvbWl8WGlhb21pIE1pIDQqWGlhb21pfFhpYW9taSBNaSA1KlhpYW9taXxYaWFvbWkgTWkgNipYaWFvbWl8WGlhb21pIE1pIEExKlhpYW9taXxYaWFvbWkgTWkgQTIgTGl0ZSpYaWFvbWl8WGlhb21pIE1pIE1heCpYaWFvbWl8WGlhb21pIFBvY28gRjEqWGlhb21pfFhpYW9taSBSZWRtaSAyKlhpYW9taXxYaWFvbWkgUmVkbWkgNCBQcmltZSpYaWFvbWl8WGlhb21pIFJlZG1pIDRYKlhpYW9taXxYaWFvbWkgUmVkbWkgTm90ZSAzKlhpYW9taXxYaWFvbWkgUmVkbWkgTm90ZSA0KlhpYW9taXxYaWFvbWkgUmVkbWkgTm90ZSA1KlhpYW9taXxYaWFvbWkgUmVkbWkgTm90ZSA1IFBsdXMqWGlhb21pfFhpYW9taSBSZWRtaSBOb3RlIDUgUHJvKllVfFl1IEFjZSpZVXxZdSBZdW5pY29ybipZVXxZVSBZdW5pcXVlKllVfFl1IFl1bmlxdWUgMipZVXxZVSBZdXBob3JpYSpZVXxZVSBZdXJla2EqWVV8WVUgWXVyZWthIEJsYWNrKllVfFl1IFl1cmVrYSBOb3RlKllVfFl1IFl1cmVrYSBTKlpURXxaVEUgQXhvbiA3KlpURXxaVEUgQXhvbiA3IE1pbmkqWlRFfFpURSBBeG9uIDdzKlpURXxaVEUgQXhvbiA5IFBybypaVEV8WlRFIEF4b24gRWxpdGUqWlRFfFpURSBBeG9uIE1pbmkqWlRFfFpURSBBeG9uIFBybypaVEV8WlRFIEJsYWRlIEEzKlpURXxaVEUgQmxhZGUgQTYqWlRFfFpURSBCbGFkZSBWNypaVEV8WlRFIEJsYWRlIFY4KlpURXxaVEUgQmxhZGUgVjkqWlRFfFpURSBCbGFkZSBWOSBNaW5pKlpURXxaVEUgTWF2ZW4gMipaVEV8WlRFIE1heCBYTCpaVEV8WlRFIE51YmlhIFoxNypaVEV8WlRFIFRlbXBvIEdvKnhpYW9taXx4aWFvbWkgNipnb29nbGV8Z29vZ2xlIFBpeGVsIDIqeGlhb21pfHhpYW9taSA4Kmh1YXdlaXxodWF3ZWkgSG9ub3IgVjkqdml2b3x2aXZvIFg5IFBsdXMqb3Bwb3xvcHBvIHIxMSpvcHBvfG9wcG8gcjExIHBsdXMqb3Bwb3xvcHBvIFIxMSBQbHVzKm9wcG98b3BwbyBSMTcgUHJvKm1laXp1fG1laXp1IFBSTyA3IFBsdXMqbWVpenV8bWVpenUgUFJPIDYgUGx1cyp4aWFvbWl8eGlhb21pIG1peCp4aWFvbWl8bWkgMw==");
			return text.Split(new char[]
			{
				'*'
			}).ToList<string>();
		}

		// Token: 0x0600018B RID: 395 RVA: 0x0000D348 File Offset: 0x0000B548
		public string getDeviceModelName()
		{
			try
			{
				string result = string.Empty;
				JSON_Settings json_Settings = new JSON_Settings("configLDPlayer", false);
				string path = this.PathLDPlayer + "/vms/config/leidian" + this.IndexDevice.ToString() + ".config";
				string text = File.ReadAllText(path);
				try
				{
					JObject jobject = JObject.Parse(text);
					result = jobject["propertySettings.phoneModel"].ToString();
				}
				catch
				{
					JObject jobject = new JObject();
				}
				return result;
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x0600018C RID: 396 RVA: 0x0000D3EC File Offset: 0x0000B5EC
		public bool SetShareFolder(string linkFolder)
		{
			try
			{
				JSON_Settings json_Settings = new JSON_Settings("configLDPlayer", false);
				string path = this.PathLDPlayer + "/vms/config/leidian" + this.IndexDevice.ToString() + ".config";
				string text = File.ReadAllText(path);
				JObject jobject;
				try
				{
					jobject = JObject.Parse(text);
				}
				catch
				{
					jobject = new JObject();
				}
				jobject["statusSettings.sharedPictures"] = linkFolder;
				File.WriteAllText(path, jobject.ToString());
				return true;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x0000D494 File Offset: 0x0000B694
		public bool ChangeFileConfig()
		{
			try
			{
				JSON_Settings json_Settings = new JSON_Settings("configLDPlayer", false);
				string path = this.PathLDPlayer + "/vms/config/leidian" + this.IndexDevice.ToString() + ".config";
				string text = File.ReadAllText(path);
				JObject jobject;
				try
				{
					jobject = JObject.Parse(text);
				}
				catch
				{
					jobject = new JObject();
				}
				jobject["statusSettings.playerName"] = "LDPlayer-" + this.IndexDevice.ToString();
				int num = (Settings.Default.SizeLDFrom != 320) ? Settings.Default.SizeLDFrom : 320;
				int num2 = (Settings.Default.SizeLDTo != 480) ? Settings.Default.SizeLDFrom : 480;
				int num3 = (Settings.Default.DPILD != 120) ? Settings.Default.SizeLDFrom : 120;
				int num4 = Convert.ToInt32(Settings.Default.CpuLD.Split(new char[]
				{
					' '
				})[0]);
				int num5 = Convert.ToInt32(Settings.Default.RamLD.Split(new char[]
				{
					'M'
				})[0]);
				bool flag = !jobject.ContainsKey("advancedSettings.resolution");
				if (flag)
				{
					JObject jobject2 = jobject;
					string text2 = "advancedSettings.resolution";
					JObject jobject3 = new JObject();
					jobject3.Add("width", num);
					jobject3.Add("height", num2);
					jobject2.Add(text2, jobject3);
				}
				else
				{
					jobject["advancedSettings.resolution"]["width"] = num;
					jobject["advancedSettings.resolution"]["height"] = num2;
				}
				jobject["advancedSettings.resolutionDpi"] = num3;
				jobject["advancedSettings.cpuCount"] = num4;
				jobject["advancedSettings.memorySize"] = num5;
				jobject["statusSettings.sharedPictures"] = this.LinkAvartar;
				bool isAdbDebug = Settings.Default.isAdbDebug;
				if (isAdbDebug)
				{
					jobject["basicSettings.adbDebug"] = 1;
				}
				File.WriteAllText(path, jobject.ToString());
				return true;
			}
			catch
			{
			}
			return false;
		}

		// Token: 0x0600018E RID: 398 RVA: 0x0000D710 File Offset: 0x0000B910
		public void ChangeHardwareLDPlayer2()
		{
			Random random = new Random();
			List<string> listInfoDevice = this.GetListInfoDevice();
			string text = listInfoDevice[random.Next(0, listInfoDevice.Count)];
			string text2 = text.Split(new char[]
			{
				'|'
			})[1];
			string text3 = text.Split(new char[]
			{
				'|'
			})[0];
			string text4 = "86516602" + Common.CreateRandomNumber(7, random);
			string text5 = "46000" + Common.CreateRandomNumber(10, random);
			string text6 = "898600" + Common.CreateRandomNumber(14, random);
			string text7 = Common.Md5Encode(Common.CreateRandomStringNumber(32, random), "x2").Substring(random.Next(0, 16), 16);
			string[] array = "+8486|+8496|+8497|+8498|+8432|+8433|+8434|+8435|+8436|+8437|+8438|+8439|+8488|+8491|+8494|+8483|+8484|+8485|+8481|+8482|+8489|+8490|+8493|+8470|+8479|+8477|+8476|+8478|+8492|+8456|+8458|+8499|+8459".Split(new char[]
			{
				'|'
			});
			string text8 = array[random.Next(array.Length)] + Common.CreateRandomNumber(7, random);
			string arguments = string.Concat(new object[]
			{
				"modify --index ",
				this.IndexDevice,
				" --imei ",
				text4,
				" --model \"",
				text2,
				"\" --manufacturer ",
				text3,
				" --pnumber ",
				text8,
				" --imsi ",
				text5,
				" --simserial ",
				text6,
				" --androidid ",
				text7,
				" --mac"
			});
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				FileName = this.PathLDPlayer + "\\dnconsole.exe",
				Arguments = arguments,
				UseShellExecute = false,
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				RedirectStandardError = true,
				RedirectStandardOutput = true
			};
			process.Start();
			process.WaitForExit(5000);
		}

		// Token: 0x0600018F RID: 399 RVA: 0x0000D8F8 File Offset: 0x0000BAF8
		public void Open(int timeout = 120)
		{
			ADBHelper.LaunchDevice(this.PathLDPlayer, this.IndexDevice);
			int tickCount = Environment.TickCount;
			try
			{
				int num = 0;
				do
				{
					this.process = (from x in Process.GetProcessesByName("dnplayer")
					where x.MainWindowTitle.Equals("LDPlayer-" + this.IndexDevice.ToString())
					select x).FirstOrDefault<Process>();
					bool flag = this.process != null;
					if (flag)
					{
						break;
					}
					num++;
					bool flag2 = num % 5 == 0;
					if (flag2)
					{
						ADBHelper.LaunchDevice(this.PathLDPlayer, this.IndexDevice);
					}
					this.DelayTime(1.0);
				}
				while (Environment.TickCount - tickCount <= timeout * 1000);
			}
			catch
			{
			}
		}

		// Token: 0x06000190 RID: 400 RVA: 0x0000D9C0 File Offset: 0x0000BBC0
		private List<string> GetListRegexGroup1(string input, string pattern)
		{
			List<string> list = new List<string>();
			try
			{
				MatchCollection matchCollection = Regex.Matches(input, pattern);
				for (int i = 0; i < matchCollection.Count; i++)
				{
					bool flag = !string.IsNullOrEmpty(matchCollection[i].Groups[1].Value);
					if (flag)
					{
						list.Add(matchCollection[i].Groups[1].Value);
					}
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		// Token: 0x06000191 RID: 401 RVA: 0x0000DA58 File Offset: 0x0000BC58
		public List<string> GetListText(string html = "", int type = 0)
		{
			bool flag = html == "";
			if (flag)
			{
				html = this.GetHtml();
			}
			List<string> listRegexGroup = this.GetListRegexGroup1(html, "text=\"(.*?)\"");
			List<string> listRegexGroup2 = this.GetListRegexGroup1(html, "content-desc=\"(.*?)\"");
			List<string> listRegexGroup3 = this.GetListRegexGroup1(html, "text='(.*?)'");
			List<string> listRegexGroup4 = this.GetListRegexGroup1(html, "content-desc='(.*?)'");
			List<string> list = new List<string>();
			switch (type)
			{
			case 0:
				list.AddRange(listRegexGroup);
				list.AddRange(listRegexGroup2);
				list.AddRange(listRegexGroup3);
				list.AddRange(listRegexGroup4);
				break;
			case 1:
				list.AddRange(listRegexGroup);
				list.AddRange(listRegexGroup3);
				break;
			case 2:
				list.AddRange(listRegexGroup2);
				list.AddRange(listRegexGroup4);
				break;
			}
			return list;
		}

		// Token: 0x06000192 RID: 402 RVA: 0x0000DB30 File Offset: 0x0000BD30
		public void DelayTime(double second)
		{
			bool flag = this.CheckIsLive();
			if (flag)
			{
				Application.DoEvents();
				Thread.Sleep(Convert.ToInt32(second * 1000.0));
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x0000DB66 File Offset: 0x0000BD66
		public void GotoNewFeedQuick()
		{
			this.ExecuteCMD(string.Format(ADBCommands.VIEW, this.link_feed, "com.facebook.katana"), 3);
		}

		// Token: 0x06000194 RID: 404 RVA: 0x0000DB88 File Offset: 0x0000BD88
		public bool CheckIsLive()
		{
			return this.process == null || !this.process.HasExited;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0000DBB4 File Offset: 0x0000BDB4
		public void LoadStatusLD(string content)
		{
			bool flag = frmViewLD.remote != null;
			if (flag)
			{
				frmViewLD.remote.LoadStatus(this.IndexDevice, content);
			}
		}

		// Token: 0x06000196 RID: 406 RVA: 0x0000DBE4 File Offset: 0x0000BDE4
		public string DeleteFolder(string folderPath)
		{
			return ADBHelper.DeleteFolder(this.DeviceId, folderPath);
		}

		// Token: 0x04000085 RID: 133
		public int IndexDevice = -1;

		// Token: 0x04000086 RID: 134
		public List<string> lstPackages = new List<string>();

		// Token: 0x04000087 RID: 135
		private string link_profile = "fb://profile";

		// Token: 0x04000088 RID: 136
		private string link_feed = "fb://feed";

		// Token: 0x04000089 RID: 137
		private string link_notifications = "fb://notifications";

		// Token: 0x0400008A RID: 138
		private string link_watch = "fb://watch";

		// Token: 0x0400008B RID: 139
		private int countOpenAppAgain = 0;

		// Token: 0x0400008C RID: 140
		public int demDisconnect = 0;

		// Token: 0x0400008D RID: 141
		public int maxDisconnect = 3;

		// Token: 0x02000022 RID: 34
		public enum KeyEvent
		{
			// Token: 0x0400008F RID: 143
			KEYCODE_0,
			// Token: 0x04000090 RID: 144
			KEYCODE_SOFT_LEFT,
			// Token: 0x04000091 RID: 145
			KEYCODE_SOFT_RIGHT,
			// Token: 0x04000092 RID: 146
			KEYCODE_HOME,
			// Token: 0x04000093 RID: 147
			KEYCODE_BACK,
			// Token: 0x04000094 RID: 148
			KEYCODE_CALL,
			// Token: 0x04000095 RID: 149
			KEYCODE_ENDCALL,
			// Token: 0x04000096 RID: 150
			KEYCODE_0_,
			// Token: 0x04000097 RID: 151
			KEYCODE_1,
			// Token: 0x04000098 RID: 152
			KEYCODE_2,
			// Token: 0x04000099 RID: 153
			KEYCODE_3,
			// Token: 0x0400009A RID: 154
			KEYCODE_4,
			// Token: 0x0400009B RID: 155
			KEYCODE_5,
			// Token: 0x0400009C RID: 156
			KEYCODE_6,
			// Token: 0x0400009D RID: 157
			KEYCODE_7,
			// Token: 0x0400009E RID: 158
			KEYCODE_8,
			// Token: 0x0400009F RID: 159
			KEYCODE_9,
			// Token: 0x040000A0 RID: 160
			KEYCODE_STAR,
			// Token: 0x040000A1 RID: 161
			KEYCODE_POUND,
			// Token: 0x040000A2 RID: 162
			KEYCODE_DPAD_UP,
			// Token: 0x040000A3 RID: 163
			KEYCODE_DPAD_DOWN,
			// Token: 0x040000A4 RID: 164
			KEYCODE_DPAD_LEFT,
			// Token: 0x040000A5 RID: 165
			KEYCODE_DPAD_RIGHT,
			// Token: 0x040000A6 RID: 166
			KEYCODE_DPAD_CENTER,
			// Token: 0x040000A7 RID: 167
			KEYCODE_VOLUME_UP,
			// Token: 0x040000A8 RID: 168
			KEYCODE_VOLUME_DOWN,
			// Token: 0x040000A9 RID: 169
			KEYCODE_POWER,
			// Token: 0x040000AA RID: 170
			KEYCODE_CAMERA,
			// Token: 0x040000AB RID: 171
			KEYCODE_CLEAR,
			// Token: 0x040000AC RID: 172
			KEYCODE_A,
			// Token: 0x040000AD RID: 173
			KEYCODE_B,
			// Token: 0x040000AE RID: 174
			KEYCODE_C,
			// Token: 0x040000AF RID: 175
			KEYCODE_D,
			// Token: 0x040000B0 RID: 176
			KEYCODE_E,
			// Token: 0x040000B1 RID: 177
			KEYCODE_F,
			// Token: 0x040000B2 RID: 178
			KEYCODE_G,
			// Token: 0x040000B3 RID: 179
			KEYCODE_H,
			// Token: 0x040000B4 RID: 180
			KEYCODE_I,
			// Token: 0x040000B5 RID: 181
			KEYCODE_J,
			// Token: 0x040000B6 RID: 182
			KEYCODE_K,
			// Token: 0x040000B7 RID: 183
			KEYCODE_L,
			// Token: 0x040000B8 RID: 184
			KEYCODE_M,
			// Token: 0x040000B9 RID: 185
			KEYCODE_N,
			// Token: 0x040000BA RID: 186
			KEYCODE_O,
			// Token: 0x040000BB RID: 187
			KEYCODE_P,
			// Token: 0x040000BC RID: 188
			KEYCODE_Q,
			// Token: 0x040000BD RID: 189
			KEYCODE_R,
			// Token: 0x040000BE RID: 190
			KEYCODE_S,
			// Token: 0x040000BF RID: 191
			KEYCODE_T,
			// Token: 0x040000C0 RID: 192
			KEYCODE_U,
			// Token: 0x040000C1 RID: 193
			KEYCODE_V,
			// Token: 0x040000C2 RID: 194
			KEYCODE_W,
			// Token: 0x040000C3 RID: 195
			KEYCODE_X,
			// Token: 0x040000C4 RID: 196
			KEYCODE_Y,
			// Token: 0x040000C5 RID: 197
			KEYCODE_Z,
			// Token: 0x040000C6 RID: 198
			KEYCODE_COMMA,
			// Token: 0x040000C7 RID: 199
			KEYCODE_PERIOD,
			// Token: 0x040000C8 RID: 200
			KEYCODE_ALT_LEFT,
			// Token: 0x040000C9 RID: 201
			KEYCODE_ALT_RIGHT,
			// Token: 0x040000CA RID: 202
			KEYCODE_SHIFT_LEFT,
			// Token: 0x040000CB RID: 203
			KEYCODE_SHIFT_RIGHT,
			// Token: 0x040000CC RID: 204
			KEYCODE_TAB,
			// Token: 0x040000CD RID: 205
			KEYCODE_SPACE,
			// Token: 0x040000CE RID: 206
			KEYCODE_SYM,
			// Token: 0x040000CF RID: 207
			KEYCODE_EXPLORER,
			// Token: 0x040000D0 RID: 208
			KEYCODE_ENVELOPE,
			// Token: 0x040000D1 RID: 209
			KEYCODE_ENTER,
			// Token: 0x040000D2 RID: 210
			KEYCODE_DEL,
			// Token: 0x040000D3 RID: 211
			KEYCODE_GRAVE,
			// Token: 0x040000D4 RID: 212
			KEYCODE_MINUS,
			// Token: 0x040000D5 RID: 213
			KEYCODE_EQUALS,
			// Token: 0x040000D6 RID: 214
			KEYCODE_LEFT_BRACKET,
			// Token: 0x040000D7 RID: 215
			KEYCODE_RIGHT_BRACKET,
			// Token: 0x040000D8 RID: 216
			KEYCODE_BACKSLASH,
			// Token: 0x040000D9 RID: 217
			KEYCODE_SEMICOLON,
			// Token: 0x040000DA RID: 218
			KEYCODE_APOSTROPHE,
			// Token: 0x040000DB RID: 219
			KEYCODE_SLASH,
			// Token: 0x040000DC RID: 220
			KEYCODE_AT,
			// Token: 0x040000DD RID: 221
			KEYCODE_NUM,
			// Token: 0x040000DE RID: 222
			KEYCODE_HEADSETHOOK,
			// Token: 0x040000DF RID: 223
			KEYCODE_FOCUS,
			// Token: 0x040000E0 RID: 224
			KEYCODE_PLUS,
			// Token: 0x040000E1 RID: 225
			KEYCODE_MENU,
			// Token: 0x040000E2 RID: 226
			KEYCODE_NOTIFICATION,
			// Token: 0x040000E3 RID: 227
			KEYCODE_APP_SWITCH = 187
		}
	}
}
