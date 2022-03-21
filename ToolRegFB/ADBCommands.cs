using System;

namespace ToolRegFB
{
	// Token: 0x02000007 RID: 7
	internal class ADBCommands
	{
		// Token: 0x04000008 RID: 8
		public static string VIEW = "shell am start -W -a android.intent.action.VIEW -d \"{0}\" {1}";

		// Token: 0x04000009 RID: 9
		public static string OPEN_LINK = "shell am start -n {0}";

		// Token: 0x0400000A RID: 10
		public static string PUT_HTTP_PROXY = "shell settings put global http_proxy {0}";

		// Token: 0x0400000B RID: 11
		public static string DELETE_HTTP_PROXY = "shell settings delete global http_proxy";

		// Token: 0x0400000C RID: 12
		public static string DELETE_HTTP_PROXY_HOST = "shell settings delete global global_http_proxy_host";

		// Token: 0x0400000D RID: 13
		public static string DELETE_HTTP_PROXY_PORT = "shell settings delete global global_http_proxy_port";

		// Token: 0x0400000E RID: 14
		public static string CURL = "shell curl {0}";

		// Token: 0x0400000F RID: 15
		public static string SCREENCAP = "shell screencap -p \"{0}\"";

		// Token: 0x04000010 RID: 16
		public static string CLEAR_DATA_APP = "shell pm clear {0}";

		// Token: 0x04000011 RID: 17
		public static string PUSH_FILE = "push \"{0}\" \"{1}\"";

		// Token: 0x04000012 RID: 18
		public static string PULL_FILE = "pull \"{0}\" \"{1}\"";

		// Token: 0x04000013 RID: 19
		public static string DELETE_FILE = "shell rm \"{0}\"";

		// Token: 0x04000014 RID: 20
		public static string DELETE_FOLDER = "shell rm -r \"{0}\"";

		// Token: 0x04000015 RID: 21
		public static string DUMP_SCREEN = "shell uiautomator dump {0}";

		// Token: 0x04000016 RID: 22
		public static string READ_FILE = "shell cat {0}";

		// Token: 0x04000017 RID: 23
		public static string IMPORT_CONTACT = "shell am start -t \"text/vcard\" -d \"file://{0}\" -a android.intent.action.VIEW com.android.contacts";

		// Token: 0x04000018 RID: 24
		public static string ZIP_FILE = "shell tar -cvzf {0} {1}";

		// Token: 0x04000019 RID: 25
		public static string UNZIP_FILE = "shell tar -xvzf {0} -C /";

		// Token: 0x0400001A RID: 26
		public static string INPUT_SWIPE = "shell input touchscreen swipe {0} {1} {2} {3} {4}";

		// Token: 0x0400001B RID: 27
		public static string INPUT_KEYEVENT = "shell input keyevent {0}";

		// Token: 0x0400001C RID: 28
		public static string INPUT_TEXT = "shell input text \"{0}\"";

		// Token: 0x0400001D RID: 29
		public static string TAP = "shell input tap {0} {1}";

		// Token: 0x0400001E RID: 30
		public static string SWITCH_ADBKEYBOARD = "shell ime set com.android.adbkeyboard/.AdbIME";

		// Token: 0x0400001F RID: 31
		public static string SWITCH_ANDROID_KEYBOARD = "shell ime set com.android.inputmethod.pinyin/.InputService";

		// Token: 0x04000020 RID: 32
		public static string DUMP_ACTIVITY = "shell \"dumpsys window windows | grep -E 'mCurrentFocus'\"";

		// Token: 0x04000021 RID: 33
		public static string OPEN_APP = "shell monkey -p {0} -c android.intent.category.LAUNCHER 1";

		// Token: 0x04000022 RID: 34
		public static string CLOSE_APP = "shell am force-stop {0}";

		// Token: 0x04000023 RID: 35
		public static string INSTALL_APP = "install {0}";

		// Token: 0x04000024 RID: 36
		public static string UNINSTALL_APP = "uninstall {0}";

		// Token: 0x04000025 RID: 37
		public static string LIST_PACKAGES = "shell pm list packages";

		// Token: 0x04000026 RID: 38
		public static string LIST_PACKAGES_USER_INSTALL = "shell pm list packages -3\" | cut - f 2 -d \":";
	}
}
