using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using KAutoHelper;

namespace ToolRegFB
{
	// Token: 0x0200000B RID: 11
	internal class AutoControl
	{
		// Token: 0x06000031 RID: 49
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x06000032 RID: 50
		[DllImport("User32.dll")]
		public static extern bool EnumChildWindows(IntPtr hWndParent, AutoControl.CallBack lpEnumFunc, IntPtr lParam);

		// Token: 0x06000033 RID: 51
		[DllImport("User32.dll")]
		public static extern int GetWindowText(IntPtr hWnd, StringBuilder s, int nMaxCount);

		// Token: 0x06000034 RID: 52
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

		// Token: 0x06000035 RID: 53
		[DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
		private static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

		// Token: 0x06000036 RID: 54
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000037 RID: 55
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

		// Token: 0x06000038 RID: 56
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x06000039 RID: 57
		[DllImport("user32.dll")]
		private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);

		// Token: 0x0600003A RID: 58
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

		// Token: 0x0600003B RID: 59
		[DllImport("user32.dll")]
		private static extern IntPtr GetDlgItem(IntPtr hWnd, int nIDDlgItem);

		// Token: 0x0600003C RID: 60
		[DllImport("user32.dll")]
		private static extern bool SetDlgItemTextA(IntPtr hWnd, int nIDDlgItem, string gchar);

		// Token: 0x0600003D RID: 61
		[DllImport("user32.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

		// Token: 0x0600003E RID: 62
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

		// Token: 0x0600003F RID: 63
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool PostMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

		// Token: 0x06000040 RID: 64
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06000041 RID: 65
		[DllImport("user32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

		// Token: 0x06000042 RID: 66
		[DllImport("user32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumChildWindows(IntPtr window, AutoControl.EnumWindowProc callback, IntPtr lParam);

		// Token: 0x06000043 RID: 67
		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
		public static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, UIntPtr dwExtraInfo);

		// Token: 0x06000044 RID: 68
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

		// Token: 0x06000045 RID: 69
		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

		// Token: 0x06000046 RID: 70
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		// Token: 0x06000047 RID: 71 RVA: 0x0000363C File Offset: 0x0000183C
		public static IntPtr BringToFront(string className, string windowName = null)
		{
			IntPtr intPtr = AutoControl.FindWindow(className, windowName);
			AutoControl.SetForegroundWindow(intPtr);
			return intPtr;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003660 File Offset: 0x00001860
		public static IntPtr BringToFront(IntPtr hWnd)
		{
			AutoControl.SetForegroundWindow(hWnd);
			return hWnd;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x0000367C File Offset: 0x0000187C
		public static bool IsWindowVisible_(IntPtr handle)
		{
			return AutoControl.IsWindowVisible(handle);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003694 File Offset: 0x00001894
		public static IntPtr FindWindowHandle(string className, string windowName)
		{
			return AutoControl.FindWindow(className, windowName);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x000036B0 File Offset: 0x000018B0
		public static List<IntPtr> FindWindowHandlesFromProcesses(string className, string windowName, int maxCount = 1)
		{
			Process[] processes = Process.GetProcesses();
			List<IntPtr> list = new List<IntPtr>();
			int num = 0;
			foreach (Process process in from p in processes
			where p.MainWindowHandle != IntPtr.Zero
			select p)
			{
				IntPtr mainWindowHandle = process.MainWindowHandle;
				string className2 = AutoControl.GetClassName(mainWindowHandle);
				string text = AutoControl.GetText(mainWindowHandle);
				bool flag = className2 == className || text == windowName;
				if (flag)
				{
					list.Add(mainWindowHandle);
					bool flag2 = num >= maxCount;
					if (flag2)
					{
						break;
					}
					num++;
				}
			}
			return list;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003788 File Offset: 0x00001988
		public static IntPtr FindWindowHandleFromProcesses(string className, string windowName)
		{
			Process[] processes = Process.GetProcesses();
			IntPtr result = IntPtr.Zero;
			foreach (Process process in from p in processes
			where p.MainWindowHandle != IntPtr.Zero
			select p)
			{
				IntPtr mainWindowHandle = process.MainWindowHandle;
				string className2 = AutoControl.GetClassName(mainWindowHandle);
				string text = AutoControl.GetText(mainWindowHandle);
				bool flag = className2 == className || text == windowName;
				if (flag)
				{
					result = mainWindowHandle;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003840 File Offset: 0x00001A40
		public static IntPtr FindWindowExFromParent(IntPtr parentHandle, string text, string className)
		{
			return AutoControl.FindWindowEx(parentHandle, IntPtr.Zero, className, text);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003860 File Offset: 0x00001A60
		private static IntPtr FindWindowByIndex(IntPtr hWndParent, int index)
		{
			bool flag = index == 0;
			IntPtr result;
			if (flag)
			{
				result = hWndParent;
			}
			else
			{
				int num = 0;
				IntPtr intPtr = IntPtr.Zero;
				do
				{
					intPtr = AutoControl.FindWindowEx(hWndParent, intPtr, "Button", null);
					bool flag2 = intPtr != IntPtr.Zero;
					if (flag2)
					{
						num++;
					}
				}
				while (num < index && intPtr != IntPtr.Zero);
				result = intPtr;
			}
			return result;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000038C8 File Offset: 0x00001AC8
		public static IntPtr GetControlHandleFromControlID(IntPtr parentHandle, int controlId)
		{
			return AutoControl.GetDlgItem(parentHandle, controlId);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000038E4 File Offset: 0x00001AE4
		public static List<IntPtr> GetChildHandle(IntPtr parentHandle)
		{
			List<IntPtr> list = new List<IntPtr>();
			GCHandle value = GCHandle.Alloc(list);
			IntPtr lParam2 = GCHandle.ToIntPtr(value);
			try
			{
				AutoControl.EnumWindowProc callback = delegate(IntPtr hWnd, IntPtr lParam)
				{
					GCHandle gchandle = GCHandle.FromIntPtr(lParam);
					bool flag = gchandle.Target == null;
					bool result;
					if (flag)
					{
						result = false;
					}
					else
					{
						List<IntPtr> list2 = gchandle.Target as List<IntPtr>;
						list2.Add(hWnd);
						result = true;
					}
					return result;
				};
				AutoControl.EnumChildWindows(parentHandle, callback, lParam2);
			}
			finally
			{
				value.Free();
			}
			return list;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00003958 File Offset: 0x00001B58
		public static IntPtr FindHandleWithText(List<IntPtr> handles, string className, string text)
		{
			return handles.Find(delegate(IntPtr ptr)
			{
				string className2 = AutoControl.GetClassName(ptr);
				string text2 = AutoControl.GetText(ptr);
				return className2 == className || text2 == text;
			});
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00003990 File Offset: 0x00001B90
		public static List<IntPtr> FindHandlesWithText(List<IntPtr> handles, string className, string text)
		{
			new List<IntPtr>();
			IEnumerable<IntPtr> source = handles.Where(delegate(IntPtr ptr)
			{
				string className2 = AutoControl.GetClassName(ptr);
				string text2 = AutoControl.GetText(ptr);
				return className2 == className || text2 == text;
			});
			return source.ToList<IntPtr>();
		}

		// Token: 0x06000053 RID: 83 RVA: 0x000039D8 File Offset: 0x00001BD8
		public static IntPtr FindHandle(IntPtr parentHandle, string className, string text)
		{
			return AutoControl.FindHandleWithText(AutoControl.GetChildHandle(parentHandle), className, text);
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000039F8 File Offset: 0x00001BF8
		public static List<IntPtr> FindHandles(IntPtr parentHandle, string className, string text)
		{
			return AutoControl.FindHandlesWithText(AutoControl.GetChildHandle(parentHandle), className, text);
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00003A18 File Offset: 0x00001C18
		public static bool CallbackChild(IntPtr hWnd, IntPtr lParam)
		{
			string text = AutoControl.GetText(hWnd);
			string className = AutoControl.GetClassName(hWnd);
			bool flag = text == "&Options >>" && className.StartsWith("ToolbarWindow32");
			bool result;
			if (flag)
			{
				AutoControl.SendMessage(hWnd, 0, IntPtr.Zero, IntPtr.Zero);
				result = false;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00003A70 File Offset: 0x00001C70
		public static void SendClickOnControlById(IntPtr parentHWND, int controlID)
		{
			IntPtr dlgItem = AutoControl.GetDlgItem(parentHWND, controlID);
			int wParam = 0 | (controlID & 65535);
			AutoControl.SendMessage(parentHWND, 273, wParam, dlgItem);
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00003A9E File Offset: 0x00001C9E
		public static void SendClickOnControlByHandle(IntPtr hWndButton)
		{
			AutoControl.SendMessage(hWndButton, 513, IntPtr.Zero, IntPtr.Zero);
			AutoControl.SendMessage(hWndButton, 514, IntPtr.Zero, IntPtr.Zero);
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00003AD0 File Offset: 0x00001CD0
		public static void SendClickOnPosition(IntPtr controlHandle, int x, int y, EMouseKey mouseButton = 0, int clickTimes = 1)
		{
			int msg = 0;
			int msg2 = 0;
			bool flag = mouseButton == 0;
			if (flag)
			{
				msg = 513;
				msg2 = 514;
			}
			bool flag2 = mouseButton == 1;
			if (flag2)
			{
				msg = 516;
				msg2 = 517;
			}
			IntPtr lParam = AutoControl.MakeLParamFromXY(x, y);
			bool flag3 = mouseButton == null || mouseButton == 1;
			if (flag3)
			{
				for (int i = 0; i < clickTimes; i++)
				{
					AutoControl.PostMessage(controlHandle, 6, new IntPtr(1), lParam);
					AutoControl.PostMessage(controlHandle, msg, new IntPtr(1), lParam);
					AutoControl.PostMessage(controlHandle, msg2, new IntPtr(0), lParam);
				}
			}
			else
			{
				bool flag4 = mouseButton == 2;
				if (flag4)
				{
					msg = 515;
					msg2 = 514;
				}
				bool flag5 = mouseButton == 3;
				if (flag5)
				{
					msg = 518;
					msg2 = 517;
				}
				AutoControl.PostMessage(controlHandle, msg, new IntPtr(1), lParam);
				AutoControl.PostMessage(controlHandle, msg2, new IntPtr(0), lParam);
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00003BC0 File Offset: 0x00001DC0
		public static void SendDragAndDropOnPosition(IntPtr controlHandle, int x, int y, int x2, int y2, int stepx = 10, int stepy = 10, double delay = 0.05)
		{
			int msg = 513;
			int msg2 = 514;
			IntPtr lParam = AutoControl.MakeLParamFromXY(x, y);
			IntPtr lParam2 = AutoControl.MakeLParamFromXY(x2, y2);
			bool flag = x2 < x;
			if (flag)
			{
				stepx *= -1;
			}
			bool flag2 = y2 < y;
			if (flag2)
			{
				stepy *= -1;
			}
			AutoControl.PostMessage(controlHandle, 6, new IntPtr(1), lParam);
			AutoControl.PostMessage(controlHandle, msg, new IntPtr(1), lParam);
			bool flag3 = false;
			bool flag4 = false;
			for (;;)
			{
				AutoControl.PostMessage(controlHandle, 512, new IntPtr(1), AutoControl.MakeLParamFromXY(x, y));
				bool flag5 = stepx <= 0;
				if (flag5)
				{
					bool flag6 = x > x2;
					if (flag6)
					{
						x += stepx;
					}
					else
					{
						flag3 = true;
					}
				}
				else
				{
					bool flag7 = x < x2;
					if (flag7)
					{
						x += stepx;
					}
					else
					{
						flag3 = true;
					}
				}
				bool flag8 = stepy > 0;
				if (flag8)
				{
					bool flag9 = y < y2;
					if (flag9)
					{
						y += stepy;
					}
					else
					{
						flag4 = true;
					}
				}
				else
				{
					bool flag10 = y > y2;
					if (flag10)
					{
						y += stepy;
					}
					else
					{
						flag4 = true;
					}
				}
				bool flag11 = flag3 && flag4;
				if (flag11)
				{
					break;
				}
				Thread.Sleep(TimeSpan.FromSeconds(delay));
			}
			AutoControl.PostMessage(controlHandle, msg2, new IntPtr(0), lParam2);
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00003D10 File Offset: 0x00001F10
		public static void SendClickDownOnPosition(IntPtr controlHandle, int x, int y, EMouseKey mouseButton = 0, int clickTimes = 1)
		{
			int msg = 0;
			bool flag = mouseButton == 0;
			if (flag)
			{
				msg = 513;
			}
			bool flag2 = mouseButton == 1;
			if (flag2)
			{
				msg = 516;
			}
			IntPtr lParam = AutoControl.MakeLParamFromXY(x, y);
			for (int i = 0; i < clickTimes; i++)
			{
				AutoControl.PostMessage(controlHandle, 6, new IntPtr(1), lParam);
				AutoControl.PostMessage(controlHandle, msg, new IntPtr(1), lParam);
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00003D80 File Offset: 0x00001F80
		public static void SendClickUpOnPosition(IntPtr controlHandle, int x, int y, EMouseKey mouseButton = 0, int clickTimes = 1)
		{
			int msg = 0;
			bool flag = mouseButton == 0;
			if (flag)
			{
				msg = 514;
			}
			bool flag2 = mouseButton == 1;
			if (flag2)
			{
				msg = 517;
			}
			IntPtr lParam = AutoControl.MakeLParamFromXY(x, y);
			for (int i = 0; i < clickTimes; i++)
			{
				AutoControl.PostMessage(controlHandle, 6, new IntPtr(1), lParam);
				AutoControl.SendMessage(controlHandle, msg, new IntPtr(0), lParam);
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00003DEF File Offset: 0x00001FEF
		public static void SendText(IntPtr handle, string text)
		{
			AutoControl.SendMessage(handle, 12, 0, text);
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00003E00 File Offset: 0x00002000
		public static void SendKeyBoardPress(IntPtr handle, VKeys key)
		{
			AutoControl.PostMessage(handle, 6, new IntPtr(1), new IntPtr(0));
			AutoControl.PostMessage(handle, 256, new IntPtr(key), new IntPtr(1));
			AutoControl.PostMessage(handle, 257, new IntPtr(key), new IntPtr(0));
		}

		// Token: 0x0600005E RID: 94 RVA: 0x00003E54 File Offset: 0x00002054
		public static void SendKeyBoardPressStepByStep(IntPtr handle, string message, float delay = 0.1f)
		{
			string text = message.ToLower();
			foreach (char c in text)
			{
				VKeys key = 48;
				char c2 = c;
				switch (c2)
				{
				case '0':
					key = 48;
					break;
				case '1':
					key = 49;
					break;
				case '2':
					key = 50;
					break;
				case '3':
					key = 51;
					break;
				case '4':
					key = 52;
					break;
				case '5':
					key = 53;
					break;
				case '6':
					key = 54;
					break;
				case '7':
					key = 55;
					break;
				case '8':
					key = 56;
					break;
				case '9':
					key = 57;
					break;
				default:
					switch (c2)
					{
					case 'a':
						key = 65;
						break;
					case 'b':
						key = 66;
						break;
					case 'c':
						key = 86;
						break;
					case 'd':
						key = 68;
						break;
					case 'e':
						key = 69;
						break;
					case 'f':
						key = 70;
						break;
					case 'g':
						key = 71;
						break;
					case 'h':
						key = 72;
						break;
					case 'i':
						key = 73;
						break;
					case 'j':
						key = 74;
						break;
					case 'k':
						key = 75;
						break;
					case 'l':
						key = 76;
						break;
					case 'm':
						key = 77;
						break;
					case 'n':
						key = 78;
						break;
					case 'o':
						key = 79;
						break;
					case 'p':
						key = 80;
						break;
					case 'q':
						key = 81;
						break;
					case 'r':
						key = 82;
						break;
					case 's':
						key = 83;
						break;
					case 't':
						key = 84;
						break;
					case 'u':
						key = 85;
						break;
					case 'v':
						key = 86;
						break;
					case 'w':
						key = 87;
						break;
					case 'x':
						key = 88;
						break;
					case 'y':
						key = 89;
						break;
					case 'z':
						key = 90;
						break;
					}
					break;
				}
				AutoControl.SendKeyBoardPress(handle, key);
				Thread.Sleep(TimeSpan.FromSeconds((double)delay));
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000404B File Offset: 0x0000224B
		public static void SendKeyBoardUp(IntPtr handle, VKeys key)
		{
			AutoControl.PostMessage(handle, 6, new IntPtr(1), new IntPtr(0));
			AutoControl.PostMessage(handle, 257, new IntPtr(key), new IntPtr(0));
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000407A File Offset: 0x0000227A
		public static void SendKeyChar(IntPtr handle, VKeys key)
		{
			AutoControl.PostMessage(handle, 6, new IntPtr(1), new IntPtr(0));
			AutoControl.PostMessage(handle, 258, new IntPtr(key), new IntPtr(0));
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000040A9 File Offset: 0x000022A9
		public static void SendKeyChar(IntPtr handle, int key)
		{
			AutoControl.PostMessage(handle, 6, new IntPtr(1), new IntPtr(0));
			AutoControl.PostMessage(handle, 258, new IntPtr(key), new IntPtr(0));
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000040D8 File Offset: 0x000022D8
		public static void SendKeyBoardDown(IntPtr handle, VKeys key)
		{
			AutoControl.PostMessage(handle, 6, new IntPtr(1), new IntPtr(0));
			AutoControl.PostMessage(handle, 256, new IntPtr(key), new IntPtr(0));
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00004108 File Offset: 0x00002308
		public static void SendTextKeyBoard(IntPtr handle, string text, float delay = 0.1f)
		{
			string text2 = text.ToLower();
			foreach (char key in text2)
			{
				AutoControl.SendKeyChar(handle, (int)key);
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00004143 File Offset: 0x00002343
		public static void SendKeyFocus(KeyCode key)
		{
			AutoControl.SendKeyPress(key);
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00004150 File Offset: 0x00002350
		public static void SendMultiKeysFocus(KeyCode[] keys)
		{
			foreach (KeyCode keyCode in keys)
			{
				AutoControl.SendKeyDown(keyCode);
			}
			foreach (KeyCode keyCode2 in keys)
			{
				AutoControl.SendKeyUp(keyCode2);
			}
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000041A1 File Offset: 0x000023A1
		public static void SendStringFocus(string message)
		{
			Clipboard.SetText(message);
			AutoControl.SendMultiKeysFocus(new KeyCode[]
			{
				17,
				86
			});
		}

		// Token: 0x06000067 RID: 103 RVA: 0x000041C4 File Offset: 0x000023C4
		public static void SendKeyPress(KeyCode keyCode)
		{
			INPUT input = default(INPUT);
			input.Type = 1U;
			INPUT input2 = input;
			ref MOUSEKEYBDHARDWAREINPUT ptr = ref input2.Data;
			KEYBDINPUT keybdinput = default(KEYBDINPUT);
			keybdinput.Vk = keyCode;
			keybdinput.Scan = 0;
			keybdinput.Flags = 0U;
			keybdinput.Time = 0U;
			keybdinput.ExtraInfo = IntPtr.Zero;
			KEYBDINPUT keyboard = keybdinput;
			ptr.Keyboard = keyboard;
			input = default(INPUT);
			input.Type = 1U;
			INPUT input3 = input;
			ref MOUSEKEYBDHARDWAREINPUT ptr2 = ref input3.Data;
			keybdinput = default(KEYBDINPUT);
			keybdinput.Vk = keyCode;
			keybdinput.Scan = 0;
			keybdinput.Flags = 2U;
			keybdinput.Time = 0U;
			keybdinput.ExtraInfo = IntPtr.Zero;
			keyboard = keybdinput;
			ptr2.Keyboard = keyboard;
			INPUT[] inputs = new INPUT[]
			{
				input2,
				input3
			};
			bool flag = AutoControl.SendInput(2U, inputs, Marshal.SizeOf(typeof(INPUT))) == 0U;
			if (flag)
			{
				throw new Exception();
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x000042C8 File Offset: 0x000024C8
		public static void SendKeyPressStepByStep(string message, double delay = 0.5)
		{
			for (int i = 0; i < message.Length; i++)
			{
				switch (message[i])
				{
				case '0':
					AutoControl.SendKeyPress(48);
					break;
				case '1':
					AutoControl.SendKeyPress(49);
					break;
				case '2':
					AutoControl.SendKeyPress(50);
					break;
				case '3':
					AutoControl.SendKeyPress(51);
					break;
				case '4':
					AutoControl.SendKeyPress(52);
					break;
				case '5':
					AutoControl.SendKeyPress(53);
					break;
				case '6':
					AutoControl.SendKeyPress(54);
					break;
				case '7':
					AutoControl.SendKeyPress(55);
					break;
				case '8':
					AutoControl.SendKeyPress(56);
					break;
				case '9':
					AutoControl.SendKeyPress(57);
					break;
				}
				Thread.Sleep(TimeSpan.FromSeconds(delay));
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000043A0 File Offset: 0x000025A0
		public static void SendKeyDown(KeyCode keyCode)
		{
			INPUT input = default(INPUT);
			input.Type = 1U;
			INPUT input2 = input;
			input2.Data.Keyboard = default(KEYBDINPUT);
			input2.Data.Keyboard.Vk = keyCode;
			input2.Data.Keyboard.Scan = 0;
			input2.Data.Keyboard.Flags = 0U;
			input2.Data.Keyboard.Time = 0U;
			input2.Data.Keyboard.ExtraInfo = IntPtr.Zero;
			INPUT[] inputs = new INPUT[]
			{
				input2
			};
			bool flag = AutoControl.SendInput(1U, inputs, Marshal.SizeOf(typeof(INPUT))) == 0U;
			if (flag)
			{
				throw new Exception();
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00004464 File Offset: 0x00002664
		public static void SendKeyUp(KeyCode keyCode)
		{
			INPUT input = default(INPUT);
			input.Type = 1U;
			INPUT input2 = input;
			input2.Data.Keyboard = default(KEYBDINPUT);
			input2.Data.Keyboard.Vk = keyCode;
			input2.Data.Keyboard.Scan = 0;
			input2.Data.Keyboard.Flags = 2U;
			input2.Data.Keyboard.Time = 0U;
			input2.Data.Keyboard.ExtraInfo = IntPtr.Zero;
			INPUT[] inputs = new INPUT[]
			{
				input2
			};
			bool flag = AutoControl.SendInput(1U, inputs, Marshal.SizeOf(typeof(INPUT))) == 0U;
			if (flag)
			{
				throw new Exception();
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004527 File Offset: 0x00002727
		public static void MouseClick(int x, int y, EMouseKey mouseKey = 0)
		{
			Cursor.Position = new Point(x, y);
			AutoControl.Click(mouseKey);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00004540 File Offset: 0x00002740
		public static void MouseDragX(Point startPoint, int deltaX, bool isNegative = false)
		{
			Cursor.Position = startPoint;
			AutoControl.mouse_event(2U, 0, 0, 0, UIntPtr.Zero);
			for (int i = 0; i < deltaX; i++)
			{
				bool flag = !isNegative;
				if (flag)
				{
					AutoControl.mouse_event(1U, 1, 0, 0, UIntPtr.Zero);
				}
				else
				{
					AutoControl.mouse_event(1U, -1, 0, 0, UIntPtr.Zero);
				}
			}
			AutoControl.mouse_event(32772U, 0, 0, 0, UIntPtr.Zero);
		}

		// Token: 0x0600006D RID: 109 RVA: 0x000045B8 File Offset: 0x000027B8
		public static void MouseDragY(Point startPoint, int deltaY, bool isNegative = false)
		{
			Cursor.Position = startPoint;
			AutoControl.mouse_event(2U, 0, 0, 0, UIntPtr.Zero);
			for (int i = 0; i < deltaY; i++)
			{
				bool flag = !isNegative;
				if (flag)
				{
					AutoControl.mouse_event(1U, 0, 1, 0, UIntPtr.Zero);
				}
				else
				{
					AutoControl.mouse_event(1U, 0, -1, 0, UIntPtr.Zero);
				}
			}
			AutoControl.mouse_event(32772U, 0, 0, 0, UIntPtr.Zero);
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0000462D File Offset: 0x0000282D
		public static void MouseScroll(Point startPoint, int deltaY, bool isNegative = false)
		{
			Cursor.Position = startPoint;
			AutoControl.mouse_event(2048U, 0, 0, deltaY, UIntPtr.Zero);
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0000464A File Offset: 0x0000284A
		public static void MouseClick(Point point, EMouseKey mouseKey = 0)
		{
			Cursor.Position = point;
			AutoControl.Click(mouseKey);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000465C File Offset: 0x0000285C
		public static void Click(EMouseKey mouseKey = 0)
		{
			switch (mouseKey)
			{
			case 0:
				AutoControl.mouse_event(32774U, 0, 0, 0, UIntPtr.Zero);
				break;
			case 1:
				AutoControl.mouse_event(32792U, 0, 0, 0, UIntPtr.Zero);
				break;
			case 2:
				AutoControl.mouse_event(32774U, 0, 0, 0, UIntPtr.Zero);
				AutoControl.mouse_event(32774U, 0, 0, 0, UIntPtr.Zero);
				break;
			case 3:
				AutoControl.mouse_event(32792U, 0, 0, 0, UIntPtr.Zero);
				AutoControl.mouse_event(32792U, 0, 0, 0, UIntPtr.Zero);
				break;
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x00004700 File Offset: 0x00002900
		public static RECT GetWindowRect(IntPtr hWnd)
		{
			RECT result = default(RECT);
			AutoControl.GetWindowRect(hWnd, ref result);
			return result;
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00004724 File Offset: 0x00002924
		public static Point GetGlobalPoint(IntPtr hWnd, Point? point = null)
		{
			Point result = default(Point);
			RECT windowRect = AutoControl.GetWindowRect(hWnd);
			bool flag = point == null;
			if (flag)
			{
				point = new Point?(default(Point));
			}
			result.X = point.Value.X + windowRect.Left;
			result.Y = point.Value.Y + windowRect.Top;
			return result;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x000047A4 File Offset: 0x000029A4
		public static Point GetGlobalPoint(IntPtr hWnd, int x = 0, int y = 0)
		{
			Point result = default(Point);
			RECT windowRect = AutoControl.GetWindowRect(hWnd);
			result.X = x + windowRect.Left;
			result.Y = y + windowRect.Top;
			return result;
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000047E8 File Offset: 0x000029E8
		public static string GetText(IntPtr hWnd)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			AutoControl.GetWindowText(hWnd, stringBuilder, 256);
			return stringBuilder.ToString().Trim();
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004820 File Offset: 0x00002A20
		public static string GetClassName(IntPtr hWnd)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			AutoControl.GetClassName(hWnd, stringBuilder, 256);
			return stringBuilder.ToString().Trim();
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00004858 File Offset: 0x00002A58
		public static IntPtr MakeLParam(int LoWord, int HiWord)
		{
			return (IntPtr)(HiWord << 16 | (LoWord & 65535));
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000487C File Offset: 0x00002A7C
		public static IntPtr MakeLParamFromXY(int x, int y)
		{
			return (IntPtr)(y << 16 | x);
		}

		// Token: 0x0200000C RID: 12
		// (Invoke) Token: 0x0600007A RID: 122
		public delegate bool CallBack(IntPtr hwnd, IntPtr lParam);

		// Token: 0x0200000D RID: 13
		// (Invoke) Token: 0x0600007E RID: 126
		private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);

		// Token: 0x0200000E RID: 14
		[Flags]
		public enum MouseEventFlags : uint
		{
			// Token: 0x0400002A RID: 42
			LEFTDOWN = 2U,
			// Token: 0x0400002B RID: 43
			LEFTUP = 4U,
			// Token: 0x0400002C RID: 44
			MIDDLEDOWN = 32U,
			// Token: 0x0400002D RID: 45
			MIDDLEUP = 64U,
			// Token: 0x0400002E RID: 46
			MOVE = 1U,
			// Token: 0x0400002F RID: 47
			ABSOLUTE = 32768U,
			// Token: 0x04000030 RID: 48
			RIGHTDOWN = 8U,
			// Token: 0x04000031 RID: 49
			RIGHTUP = 16U,
			// Token: 0x04000032 RID: 50
			WHEEL = 2048U,
			// Token: 0x04000033 RID: 51
			XDOWN = 128U,
			// Token: 0x04000034 RID: 52
			XUP = 256U,
			// Token: 0x04000035 RID: 53
			XBUTTON1 = 1U,
			// Token: 0x04000036 RID: 54
			XBUTTON2 = 2U
		}
	}
}
