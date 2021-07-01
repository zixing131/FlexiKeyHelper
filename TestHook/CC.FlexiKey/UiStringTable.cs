using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace CC.FlexiKey
{
	// Token: 0x02000030 RID: 48
	public class UiStringTable
	{
		// Token: 0x06000283 RID: 643
		[DllImport("kernel32", CharSet = CharSet.Unicode)]
		public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retStr, int bufferSize, string filePath);

		// Token: 0x06000284 RID: 644 RVA: 0x0001E190 File Offset: 0x0001C390
		public static bool GetSupport3LedKB()
		{
			return Convert.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\hotkey\\", "Support3LedKB", "0")) == "1";
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0001E1BA File Offset: 0x0001C3BA
		public static bool GetSupportTpColor()
		{
			return Convert.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\hotkey\\", "SupportTpColor", "0")) == "1";
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0001E1E4 File Offset: 0x0001C3E4
		public static bool GetSupportLightbar()
		{
			return Convert.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\hotkey\\", "SupportLightbar", "0")) == "1";
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0001E20E File Offset: 0x0001C40E
		public static bool GetSupportLogoColor()
		{
			return Convert.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\hotkey\\", "SupportLogoColor", "0")) == "1";
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0001E238 File Offset: 0x0001C438
		public static string GetLanguage()
		{
			string text = Convert.ToString(Registry.GetValue("HKEY_CURRENT_USER\\Software\\ComboKey\\", "language", ""));
			if (text == "")
			{
				return CultureInfo.CurrentCulture.Name.ToLower();
			}
			return text;
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0001E280 File Offset: 0x0001C480
		public static HookKeysTable.KeyLanguage GetLayout(string lang)
		{
			if (lang.Contains("en-gb"))
			{
				return HookKeysTable.KeyLanguage.uk;
			}
			if (lang.Contains("en-") || lang.Contains("zh-") || lang.Contains("ko") || lang.Contains("th") || lang.Contains("vi"))
			{
				return HookKeysTable.KeyLanguage.usa;
			}
			if (lang.Contains("ja"))
			{
				return HookKeysTable.KeyLanguage.jp;
			}
			if (lang.Contains("pt-br"))
			{
				return HookKeysTable.KeyLanguage.br;
			}
			return HookKeysTable.KeyLanguage.uk;
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0001E300 File Offset: 0x0001C500
		public static string UpdateLbl(string path, string name)
		{
			string text = UiStringTable.GetLanguage();
			if (text.Contains("en-"))
			{
				text = "en";
			}
			else if (text.Contains("es"))
			{
				text = "es";
			}
			else if (text.Contains("de"))
			{
				text = "de";
			}
			else if (text.Contains("it"))
			{
				text = "it";
			}
			else if (text.Contains("ja"))
			{
				text = "ja";
			}
			else if (text.Contains("ko"))
			{
				text = "ko";
			}
			else if (text.Contains("th-th"))
			{
				text = "th-th";
			}
			else if (text.Contains("tr-tr"))
			{
				text = "tr-tr";
			}
			else if (text.Contains("vi-vn"))
			{
				text = "vi-vn";
			}
			StringBuilder stringBuilder = new StringBuilder(1024);
			string def = "null";
			int bufferSize = 1024;
			UiStringTable.GetPrivateProfileString(text, name, def, stringBuilder, bufferSize, path);
			string text2 = stringBuilder.ToString();
			if (text2 == "null")
			{
				UiStringTable.GetPrivateProfileString("en", name, def, stringBuilder, bufferSize, path);
				text2 = stringBuilder.ToString();
			}
			return text2;
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0001E42C File Offset: 0x0001C62C
		public static string UpdateBacklightLbl(string path, string name)
		{
			string text = UiStringTable.GetLanguage();
			if (text.Contains("en-"))
			{
				text = "en";
			}
			else if (text.Contains("es"))
			{
				text = "es";
			}
			else if (text.Contains("de"))
			{
				text = "de";
			}
			else if (text.Contains("it"))
			{
				text = "it";
			}
			else if (text.Contains("ja"))
			{
				text = "ja";
			}
			else if (text.Contains("ko"))
			{
				text = "ko";
			}
			else if (text.Contains("th-th"))
			{
				text = "th-th";
			}
			else if (text.Contains("tr-tr"))
			{
				text = "tr-tr";
			}
			else if (text.Contains("vi-vn"))
			{
				text = "vi-vn";
			}
			StringBuilder stringBuilder = new StringBuilder(1024);
			string def = "null";
			int bufferSize = 1024;
			UiStringTable.GetPrivateProfileString(text, name, def, stringBuilder, bufferSize, path);
			string text2 = stringBuilder.ToString();
			if (text2 == "null")
			{
				UiStringTable.GetPrivateProfileString("en", name, def, stringBuilder, bufferSize, path);
				text2 = stringBuilder.ToString();
			}
			return text2;
		}
	}
}
