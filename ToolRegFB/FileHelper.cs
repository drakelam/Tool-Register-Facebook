using System;
using System.IO;
using System.Windows.Forms;

namespace ToolRegFB
{
	// Token: 0x02000024 RID: 36
	internal class FileHelper
	{
		// Token: 0x0600019A RID: 410 RVA: 0x0000DC3C File Offset: 0x0000BE3C
		public static string GetPathToCurrentFolder()
		{
			return Path.GetDirectoryName(Application.ExecutablePath);
		}

		// Token: 0x0600019B RID: 411 RVA: 0x0000DC58 File Offset: 0x0000BE58
		public static string SelectFolder()
		{
			string result = "";
			try
			{
				using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
				{
					DialogResult dialogResult = folderBrowserDialog.ShowDialog();
					bool flag = dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath);
					if (flag)
					{
						result = folderBrowserDialog.SelectedPath;
					}
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x0600019C RID: 412 RVA: 0x0000DCD8 File Offset: 0x0000BED8
		public static string SelectFile(string title = "Chọn File txt", string defaultFolder = "C:\\", string filter = "txt Files (*.txt)|*.txt|All files (*.*)|*.*")
		{
			string result = "";
			try
			{
				using (OpenFileDialog openFileDialog = new OpenFileDialog())
				{
					openFileDialog.Filter = filter;
					openFileDialog.InitialDirectory = defaultFolder;
					openFileDialog.Title = title;
					bool flag = openFileDialog.ShowDialog() == DialogResult.OK;
					if (flag)
					{
						result = openFileDialog.FileName;
					}
				}
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x0600019D RID: 413 RVA: 0x0000DD5C File Offset: 0x0000BF5C
		public static bool DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirName);
				bool flag = !directoryInfo.Exists;
				if (flag)
				{
					return false;
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				Directory.CreateDirectory(destDirName);
				FileInfo[] files = directoryInfo.GetFiles();
				foreach (FileInfo fileInfo in files)
				{
					string destFileName = Path.Combine(destDirName, fileInfo.Name);
					fileInfo.CopyTo(destFileName, true);
				}
				if (copySubDirs)
				{
					foreach (DirectoryInfo directoryInfo2 in directories)
					{
						string destDirName2 = Path.Combine(destDirName, directoryInfo2.Name);
						FileHelper.DirectoryCopy(directoryInfo2.FullName, destDirName2, copySubDirs);
					}
				}
				return true;
			}
			catch (Exception)
			{
			}
			return false;
		}

		// Token: 0x0600019E RID: 414 RVA: 0x0000DE40 File Offset: 0x0000C040
		public static void CreateFile(string pathFile)
		{
			try
			{
				File.AppendAllText(pathFile, "");
			}
			catch
			{
			}
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000DE74 File Offset: 0x0000C074
		public static void CreateFolderIfNotExist(string pathFolder)
		{
			try
			{
				Directory.CreateDirectory(pathFolder);
			}
			catch
			{
			}
		}
	}
}
