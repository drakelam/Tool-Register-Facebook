using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ToolRegFB
{
	// Token: 0x02000008 RID: 8
	internal class ADBHelper
	{
		// Token: 0x0600000E RID: 14 RVA: 0x0000294C File Offset: 0x00000B4C
		public static string OpenApp(string deviceId, string package)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.OPEN_APP, package), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002990 File Offset: 0x00000B90
		public static string ScreenShot(string deviceId, string filePathToSave)
		{
			string result = "";
			try
			{
				string fileName = Path.GetFileName(filePathToSave);
				ADBHelper.ScreenCap(deviceId, "/sdcard/" + fileName);
				ADBHelper.PullFile(deviceId, "/sdcard/" + fileName, filePathToSave);
				ADBHelper.DeleteFile(deviceId, "/sdcard/" + fileName);
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002A00 File Offset: 0x00000C00
		public static string RemoveHttpProxy(string deviceId)
		{
			try
			{
				ADBHelper.ConnectHttpProxy(deviceId, ":0");
				ADBHelper.RunCMD(deviceId, ADBCommands.DELETE_HTTP_PROXY, 10);
				ADBHelper.RunCMD(deviceId, ADBCommands.DELETE_HTTP_PROXY_HOST, 10);
				ADBHelper.RunCMD(deviceId, ADBCommands.DELETE_HTTP_PROXY_PORT, 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002A68 File Offset: 0x00000C68
		public static string ConnectHttpProxy(string deviceId, string proxy)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.PUT_HTTP_PROXY, proxy), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002AAC File Offset: 0x00000CAC
		public static string DeleteFile(string deviceId, string filePath)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.DELETE_FILE, filePath), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002AF0 File Offset: 0x00000CF0
		public static string SwitchAdbkeyboard(string deviceId)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, ADBCommands.SWITCH_ADBKEYBOARD, 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002B30 File Offset: 0x00000D30
		public static string CloseApp(string deviceId, string package)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.CLOSE_APP, package), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002B74 File Offset: 0x00000D74
		public static string DeleteFolder(string deviceId, string folderPath)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.DELETE_FOLDER, folderPath), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002BB8 File Offset: 0x00000DB8
		public static string Swipe(string deviceId, int x1, int y1, int x2, int y2, int duration = 100)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.INPUT_SWIPE, new object[]
				{
					x1,
					y1,
					x2,
					y2,
					duration
				}), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002C30 File Offset: 0x00000E30
		public static string SwitchAndroidKeyboard(string deviceId, List<string> lstPackage)
		{
			try
			{
				string text = "com.android.inputmethod.pinyin";
				bool flag = lstPackage.Count > 0 && !lstPackage.Contains(text);
				if (flag)
				{
					text = "com.android.emu.inputservice";
				}
				return ADBHelper.RunCMD(deviceId, "shell ime set " + text + "/.InputService", 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002CA0 File Offset: 0x00000EA0
		public static string InputText(string deviceId, string text)
		{
			try
			{
				text = text.Replace(" ", "%s").Replace("&", "\\&").Replace("<", "\\<").Replace(">", "\\>").Replace("?", "\\?").Replace(":", "\\:").Replace("{", "\\{").Replace("}", "\\}").Replace("[", "\\[").Replace("]", "\\]").Replace("|", "\\|");
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.INPUT_TEXT, text), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002D8C File Offset: 0x00000F8C
		public static string PullFile(string deviceId, string fromFilePath, string toFilePath)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.PULL_FILE, fromFilePath, toFilePath), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002DD0 File Offset: 0x00000FD0
		public static string ScreenCap(string deviceId, string filePath)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.SCREENCAP, filePath), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002E14 File Offset: 0x00001014
		public static string Tap(string deviceId, int x, int y)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.TAP, x, y), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002E64 File Offset: 0x00001064
		public static string GetXML(string deviceId)
		{
			string text = "";
			try
			{
				for (int i = 0; i < 3; i++)
				{
					text = ADBHelper.RunCMD(deviceId, "adb shell uiautomator dump && adb shell cat /sdcard/window_dump.xml && adb shell rm /sdcard/window_dump.xml", 10).ToLower();
					bool flag = text.Trim() != "ui hierchary dumped to: /sdcard/window_dump.xml" && text.Trim() != "";
					if (flag)
					{
						break;
					}
					Thread.Sleep(1000);
				}
			}
			catch
			{
			}
			return Regex.Match(text, "<\\?xml(.*?)</hierarchy>").Value;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00002F04 File Offset: 0x00001104
		public static string DumpActivity(string deviceId)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, ADBCommands.DUMP_ACTIVITY, 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00002F44 File Offset: 0x00001144
		public static string ReadFile(string deviceId, string filePath)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.READ_FILE, filePath), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002F88 File Offset: 0x00001188
		public static void QuitDevice(string pathLD, int indexDevice)
		{
			try
			{
				ADBHelper.RunCMD(pathLD + "\\dnconsole.exe quit --index " + indexDevice.ToString(), 10);
			}
			catch
			{
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002FCC File Offset: 0x000011CC
		public static string RunCMD(string deviceId, string cmd, int timeout = 10)
		{
			bool flag = !string.IsNullOrEmpty(deviceId);
			if (flag)
			{
				string newValue = "adb -s " + deviceId;
				bool flag2 = !cmd.StartsWith("adb");
				if (flag2)
				{
					cmd = "adb -s " + deviceId + " " + cmd;
				}
				else
				{
					cmd = cmd.Replace("adb", newValue);
				}
			}
			return ADBHelper.RunCMD(cmd, timeout);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000303C File Offset: 0x0000123C
		public static string InstallApp(string deviceId, string filePathFromComputer)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.INSTALL_APP, filePathFromComputer), 60);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00003080 File Offset: 0x00001280
		public static List<string> GetListPackages(string deviceId)
		{
			List<string> result = new List<string>();
			try
			{
				string text = ADBHelper.RunCMD(deviceId, ADBCommands.LIST_PACKAGES, 10).Replace("package:", "").Trim();
				bool flag = text != "";
				if (flag)
				{
					result = text.Split(new char[]
					{
						'\n'
					}).ToList<string>();
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000030FC File Offset: 0x000012FC
		public static string TapLong(string deviceId, int x, int y, int duration = 100)
		{
			try
			{
				return ADBHelper.RunCMD(deviceId, string.Format(ADBCommands.INPUT_SWIPE, new object[]
				{
					x,
					y,
					x,
					y,
					duration
				}), 10);
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00003174 File Offset: 0x00001374
		public static void AddDevice(string pathLD)
		{
			try
			{
				ADBHelper.RunCMD(pathLD + "\\dnconsole.exe add", 30);
			}
			catch
			{
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000031B0 File Offset: 0x000013B0
		public static void LaunchDevice(string pathLD, int indexDevice)
		{
			try
			{
				ADBHelper.RunCMD(pathLD + "\\dnconsole.exe launch --index " + indexDevice.ToString(), 10);
			}
			catch
			{
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000031F4 File Offset: 0x000013F4
		public static List<string> GetListIndexLDPlayer(string pathLd)
		{
			List<string> list = new List<string>();
			try
			{
				string text = ADBHelper.RunCMD(pathLd + "\\dnconsole.exe list2", 10);
				bool flag = text.Trim() != "";
				if (flag)
				{
					List<string> list2 = text.Trim().Split(new char[]
					{
						'\n'
					}).ToList<string>();
					for (int i = 0; i < list2.Count; i++)
					{
						list.Add(list2[i].Split(new char[]
						{
							','
						})[0]);
					}
				}
			}
			catch (Exception ex)
			{
			}
			return list;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000032AC File Offset: 0x000014AC
		public static List<string> GetDevices()
		{
			List<string> list = new List<string>();
			string text = ADBHelper.RunCMD("adb devices", 10);
			string[] array = text.Replace("List of devices attached", "").Trim().Split(new string[]
			{
				"\n"
			}, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = !array[i].Contains("offline") && array[i].Contains("device");
				if (flag)
				{
					list.Add(array[i].Trim().Split(new char[]
					{
						'\t'
					})[0]);
				}
			}
			return list;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000335C File Offset: 0x0000155C
		public static void DisconnectDevice(string deviceId)
		{
			try
			{
				ADBHelper.RunCMD("adb disconnect " + deviceId, 10);
			}
			catch
			{
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003398 File Offset: 0x00001598
		public static string RunCMD(string cmd, int timeout = 10)
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + cmd;
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

		// Token: 0x0600002A RID: 42 RVA: 0x00003498 File Offset: 0x00001698
		public static void ConnectDevice(string deviceId)
		{
			try
			{
				ADBHelper.RunCMD("adb connect " + deviceId, 10);
			}
			catch
			{
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000034D4 File Offset: 0x000016D4
		public static string GetDeviceByIndex(int IndexDevice)
		{
			string text = "";
			try
			{
				List<string> devices = ADBHelper.GetDevices();
				List<string> lstDeviceIdCheck = new List<string>
				{
					"127.0.0.1:" + (IndexDevice * 2 + 5555).ToString(),
					"emulator-" + (IndexDevice * 2 + 5554).ToString()
				};
				text = (from x in devices
				where lstDeviceIdCheck.Contains(x)
				select x).FirstOrDefault<string>();
				bool flag = string.IsNullOrEmpty(text);
				if (flag)
				{
					for (int i = 0; i < lstDeviceIdCheck.Count; i++)
					{
						ADBHelper.DisconnectDevice(lstDeviceIdCheck[i]);
					}
					ADBHelper.ConnectDevice(lstDeviceIdCheck[0]);
				}
			}
			catch
			{
			}
			return text;
		}
	}
}
