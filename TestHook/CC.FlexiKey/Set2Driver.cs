using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace CC.FlexiKey
{
	// Token: 0x0200002F RID: 47
	public class Set2Driver
	{
		// Token: 0x06000264 RID: 612
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr LoadLibrary(string name);

		// Token: 0x06000265 RID: 613
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string name);

		// Token: 0x06000266 RID: 614
		[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool FreeLibrary(IntPtr hModule);

		// Token: 0x06000267 RID: 615 RVA: 0x0001CD81 File Offset: 0x0001AF81
		public Set2Driver()
		{
			this.InitialEventLog();
		}

		// Token: 0x17000051 RID: 81
		// (set) Token: 0x06000268 RID: 616 RVA: 0x0001CD96 File Offset: 0x0001AF96
		public bool IsHidMouseExist
		{
			set
			{
				this.bIsHidMouseExist = value;
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0001CDA0 File Offset: 0x0001AFA0
		public bool SetMacroKey(KeyInfo info)
		{
			bool result = false;
			if (info.Device == KeyGlobal.DeviceType.keyboard)
			{
				result = this.SetKbMacroKeyEx(info);
			}
			else if (info.Device == KeyGlobal.DeviceType.mouse)
			{
				result = this.SetMouseMacroKeyEx(info);
			}
			return result;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0001CDD4 File Offset: 0x0001AFD4
		public bool SetLaunchApp(KeyInfo info)
		{
			bool result = false;
			if (info.Device == KeyGlobal.DeviceType.keyboard)
			{
				result = this.SetKbLaunchApp(info);
			}
			else if (info.Device == KeyGlobal.DeviceType.mouse)
			{
				result = this.SetMouseLaunchApp(info);
			}
			return result;
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0001CE08 File Offset: 0x0001B008
		public bool SetTextMacro(KeyInfo info)
		{
			bool result = false;
			if (info.Device == KeyGlobal.DeviceType.keyboard)
			{
				result = this.SetKbTextMacro(info);
			}
			else if (info.Device == KeyGlobal.DeviceType.mouse)
			{
				result = this.SetMouseTextMacro(info);
			}
			return result;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0001CE3C File Offset: 0x0001B03C
		public bool SetKeyDisable(KeyInfo info)
		{
			bool result = false;
			if (info.Device == KeyGlobal.DeviceType.keyboard)
			{
				result = this.SetKbKeyDisable(info);
			}
			else if (info.Device == KeyGlobal.DeviceType.mouse)
			{
				result = this.SetMouseKeyDisable(info);
			}
			return result;
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0001CE70 File Offset: 0x0001B070
		public bool SetKbEnableFilter()
		{
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "EnableFilter");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.EnableFilter)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.EnableFilter)))();
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0001CEF8 File Offset: 0x0001B0F8
		public bool SetKbDisableFilter()
		{
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "DisableFilter");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.DisableFilter)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.DisableFilter)))();
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600026F RID: 623 RVA: 0x0001CF80 File Offset: 0x0001B180
		public bool SetKbCleanFilter()
		{
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "ClearFilterMacro");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.ClearFilterMacro)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.ClearFilterMacro)))();
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000270 RID: 624 RVA: 0x0001D008 File Offset: 0x0001B208
		private bool SetKbMacroKeyEx(KeyInfo keyInfo)
		{
			try
			{
				Set2Driver.ClevoKB[] array = new Set2Driver.ClevoKB[2];
				Set2Driver.ClevoKeyEx[] array2 = new Set2Driver.ClevoKeyEx[255];
				array[0].VK_Key = keyInfo.KeyCode;
				bool isKeypressDelay = keyInfo.IsKeypressDelay;
				array2 = this.SetupMacroKeyEx(keyInfo.MacroKey, isKeypressDelay);
				string text = "After SetupMacroKeyEx \r\n";
				for (int i = 0; i < keyInfo.MacroKey.Count; i++)
				{
					text = string.Concat(new string[]
					{
						text,
						"macrokey[",
						i.ToString(),
						"].key=",
						array2[i].key.ToString(),
						", status=",
						array2[i].status.ToString(),
						", delaytime=",
						array2[i].DelayTime.ToString(),
						"\r\n"
					});
				}
				this.outlog.WriteEntry(text);
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateMacroKeyEx");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				Set2Driver.CreateMacroKeyEx createMacroKeyEx = (Set2Driver.CreateMacroKeyEx)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateMacroKeyEx));
				createMacroKeyEx(array, array2);
				array[0].VK_Key = 57463;
				array[1].VK_Key = keyInfo.KeyCode;
				createMacroKeyEx(array, array2);
				array[0].VK_Key = 57464;
				array[1].VK_Key = keyInfo.KeyCode;
				createMacroKeyEx(array, array2);
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000271 RID: 625 RVA: 0x0001D1F8 File Offset: 0x0001B3F8
		private bool SetKbMacroKey(KeyInfo keyInfo)
		{
			try
			{
				Set2Driver.ClevoKB[] array = new Set2Driver.ClevoKB[2];
				Set2Driver.ClevoKB[] macrokey = new Set2Driver.ClevoKB[16];
				array[0].VK_Key = keyInfo.KeyCode;
				bool isKeypressDelay = keyInfo.IsKeypressDelay;
				macrokey = this.SetupMacroKey(keyInfo.MacroKey, 16, isKeypressDelay);
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateMacroKey");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.CreateMacroKey)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateMacroKey)))(array, macrokey);
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000272 RID: 626 RVA: 0x0001D2C4 File Offset: 0x0001B4C4
		private bool SetKbTextMacro(KeyInfo keyInfo)
		{
			IntPtr intPtr = IntPtr.Zero;
			intPtr = Set2Driver.LoadLibrary("kb.dll");
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateStringKey");
			if (procAddress == IntPtr.Zero)
			{
				return false;
			}
			Set2Driver.CreateStringKey createStringKey = (Set2Driver.CreateStringKey)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateStringKey));
			Set2Driver.ClevoKB[] array = new Set2Driver.ClevoKB[2];
			Set2Driver.ClevoKB[] startkey = new Set2Driver.ClevoKB[6];
			Set2Driver.ClevoKB[] endkey = new Set2Driver.ClevoKB[6];
			array[0].VK_Key = keyInfo.KeyCode;
			startkey = this.SetupMacroKey(keyInfo.StartKey, 6, false);
			endkey = this.SetupMacroKey(keyInfo.SendKey, 6, false);
			string textContent = keyInfo.TextContent;
			byte[] bytes = Encoding.Unicode.GetBytes(textContent);
			createStringKey(array, startkey, bytes, endkey);
			array[0].VK_Key = 57463;
			array[1].VK_Key = keyInfo.KeyCode;
			createStringKey(array, startkey, bytes, endkey);
			array[0].VK_Key = 57464;
			array[1].VK_Key = keyInfo.KeyCode;
			createStringKey(array, startkey, bytes, endkey);
			Set2Driver.FreeLibrary(intPtr);
			return true;
		}

		// Token: 0x06000273 RID: 627 RVA: 0x0001D3F4 File Offset: 0x0001B5F4
		private bool SetKbLaunchApp(KeyInfo keyInfo)
		{
			try
			{
				Set2Driver.ClevoKB[] array = new Set2Driver.ClevoKB[2];
				array[0].VK_Key = keyInfo.KeyCode;
				int appEventId = keyInfo.AppEventId;
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateFilterSysEvent");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				Set2Driver.CreateFilterSysEvent createFilterSysEvent = (Set2Driver.CreateFilterSysEvent)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateFilterSysEvent));
				createFilterSysEvent(array, appEventId);
				array[0].VK_Key = 57463;
				array[1].VK_Key = keyInfo.KeyCode;
				createFilterSysEvent(array, appEventId);
				array[0].VK_Key = 57464;
				array[1].VK_Key = keyInfo.KeyCode;
				createFilterSysEvent(array, appEventId);
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000274 RID: 628 RVA: 0x0001D504 File Offset: 0x0001B704
		private bool SetKbKeyDisable(KeyInfo keyInfo)
		{
			try
			{
				Set2Driver.ClevoKB[] array = new Set2Driver.ClevoKB[2];
				Set2Driver.ClevoKB[] array2 = new Set2Driver.ClevoKB[16];
				array[0].VK_Key = keyInfo.KeyCode;
				array2[0].VK_Key = 0;
				array2[0].UpDelay = 0;
				array2[0].DownDelay = 0;
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateMacroKey");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				Set2Driver.CreateMacroKey createMacroKey = (Set2Driver.CreateMacroKey)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateMacroKey));
				createMacroKey(array, array2);
				array[0].VK_Key = 57463;
				array[1].VK_Key = keyInfo.KeyCode;
				createMacroKey(array, array2);
				array[0].VK_Key = 57464;
				array[1].VK_Key = keyInfo.KeyCode;
				createMacroKey(array, array2);
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000275 RID: 629 RVA: 0x0001D644 File Offset: 0x0001B844
		public static bool StartKbSta()
		{
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "StartFilterLog");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.StartFilterLog)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.StartFilterLog)))();
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000276 RID: 630 RVA: 0x0001D6CC File Offset: 0x0001B8CC
		public static bool StopKbSta()
		{
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "StopFilterLog");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.StopFilterLog)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.StopFilterLog)))();
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0001D754 File Offset: 0x0001B954
		public static List<KbStaClass> GetKbStaLog()
		{
			List<KbStaClass> list = new List<KbStaClass>();
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return list;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CountFilterLog");
				if (procAddress == IntPtr.Zero)
				{
					return list;
				}
				int num = ((Set2Driver.CountFilterLog)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CountFilterLog)))();
				procAddress = Set2Driver.GetProcAddress(intPtr, "GetFilterLog");
				if (procAddress == IntPtr.Zero)
				{
					return list;
				}
				Set2Driver.GetFilterLog getFilterLog = (Set2Driver.GetFilterLog)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.GetFilterLog));
				Set2Driver.KeyboardFilterLog keyboardFilterLog = default(Set2Driver.KeyboardFilterLog);
				for (int i = 0; i < num; i++)
				{
					getFilterLog(i, ref keyboardFilterLog);
					KbStaClass kbStaClass = new KbStaClass();
					kbStaClass.KeyCode = ((int)keyboardFilterLog.KeyCode & 65535);
					kbStaClass.KeyCount = (int)keyboardFilterLog.BreakCount;
					if (kbStaClass.KeyCount <= 4)
					{
						kbStaClass.StaLevel = 1;
					}
					else if (kbStaClass.KeyCount > 4 && kbStaClass.KeyCount <= 8)
					{
						kbStaClass.StaLevel = 2;
					}
					else if (kbStaClass.KeyCount > 8 && kbStaClass.KeyCount <= 12)
					{
						kbStaClass.StaLevel = 3;
					}
					else if (kbStaClass.KeyCount > 12 && kbStaClass.KeyCount <= 16)
					{
						kbStaClass.StaLevel = 4;
					}
					else if (kbStaClass.KeyCount > 16)
					{
						kbStaClass.StaLevel = 5;
					}
					kbStaClass.IsDisable = false;
					list.Add(kbStaClass);
				}
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
			}
			return list;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0001D914 File Offset: 0x0001BB14
		public bool SetMouseEnableFilter()
		{
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "EnableFilter_Mouse");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.EnableFilter_Mouse)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.EnableFilter_Mouse)))();
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000279 RID: 633 RVA: 0x0001D99C File Offset: 0x0001BB9C
		public bool SetMouseDisableFilter()
		{
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "DisableFilter_Mouse");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.DisableFilter_Mouse)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.DisableFilter_Mouse)))();
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600027A RID: 634 RVA: 0x0001DA24 File Offset: 0x0001BC24
		public bool SetMouseCleanFilter()
		{
			try
			{
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "ClearFilterMacro_Mouse");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.ClearFilterMacro_Mouse)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.ClearFilterMacro_Mouse)))();
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600027B RID: 635 RVA: 0x0001DAAC File Offset: 0x0001BCAC
		private bool SetMouseMacroKeyEx(KeyInfo keyInfo)
		{
			try
			{
				int keyCode = keyInfo.KeyCode;
				Set2Driver.ClevoKeyEx[] macrokey = new Set2Driver.ClevoKeyEx[255];
				bool isKeypressDelay = keyInfo.IsKeypressDelay;
				macrokey = this.SetupMacroKeyEx(keyInfo.MacroKey, isKeypressDelay);
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateMacroKey_MouseEx");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.CreateMacroKey_MouseEx)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateMacroKey_MouseEx)))(keyCode, macrokey);
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600027C RID: 636 RVA: 0x0001DB68 File Offset: 0x0001BD68
		private bool SetMouseMacroKey(KeyInfo keyInfo)
		{
			try
			{
				Set2Driver.ClevoKB[] macrokey = new Set2Driver.ClevoKB[16];
				int keyCode = keyInfo.KeyCode;
				bool isKeypressDelay = keyInfo.IsKeypressDelay;
				macrokey = this.SetupMacroKey(keyInfo.MacroKey, 16, isKeypressDelay);
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateMacroKey_Mouse");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.CreateMacroKey_Mouse)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateMacroKey_Mouse)))(keyCode, macrokey);
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600027D RID: 637 RVA: 0x0001DC24 File Offset: 0x0001BE24
		private bool SetMouseTextMacro(KeyInfo keyInfo)
		{
			IntPtr intPtr = IntPtr.Zero;
			intPtr = Set2Driver.LoadLibrary("kb.dll");
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateStringKey_Mouse");
			if (procAddress == IntPtr.Zero)
			{
				return false;
			}
			Set2Driver.CreateStringKey_Mouse createStringKey_Mouse = (Set2Driver.CreateStringKey_Mouse)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateStringKey_Mouse));
			Set2Driver.ClevoKB[] startkey = new Set2Driver.ClevoKB[6];
			Set2Driver.ClevoKB[] endkey = new Set2Driver.ClevoKB[6];
			int keyCode = keyInfo.KeyCode;
			startkey = this.SetupMacroKey(keyInfo.StartKey, 6, false);
			endkey = this.SetupMacroKey(keyInfo.SendKey, 6, false);
			string textContent = keyInfo.TextContent;
			byte[] bytes = Encoding.Unicode.GetBytes(textContent);
			createStringKey_Mouse(keyCode, startkey, bytes, endkey);
			Set2Driver.FreeLibrary(intPtr);
			return true;
		}

		// Token: 0x0600027E RID: 638 RVA: 0x0001DCE0 File Offset: 0x0001BEE0
		private bool SetMouseLaunchApp(KeyInfo keyInfo)
		{
			try
			{
				int keyCode = keyInfo.KeyCode;
				int appEventId = keyInfo.AppEventId;
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateFilterSysEvent_Mouse");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.CreateFilterSysEvent_Mouse)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateFilterSysEvent_Mouse)))(keyCode, appEventId);
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x0600027F RID: 639 RVA: 0x0001DD80 File Offset: 0x0001BF80
		private bool SetMouseKeyDisable(KeyInfo keyInfo)
		{
			try
			{
				Set2Driver.ClevoKB[] array = new Set2Driver.ClevoKB[16];
				int keyCode = keyInfo.KeyCode;
				array[0].VK_Key = 0;
				array[0].UpDelay = 0;
				array[0].DownDelay = 0;
				IntPtr intPtr = IntPtr.Zero;
				intPtr = Set2Driver.LoadLibrary("kb.dll");
				if (intPtr == IntPtr.Zero)
				{
					return false;
				}
				IntPtr procAddress = Set2Driver.GetProcAddress(intPtr, "CreateMacroKey_Mouse");
				if (procAddress == IntPtr.Zero)
				{
					return false;
				}
				((Set2Driver.CreateMacroKey_Mouse)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(Set2Driver.CreateMacroKey_Mouse)))(keyCode, array);
				Set2Driver.FreeLibrary(intPtr);
			}
			catch
			{
				return false;
			}
			return true;
		}

		// Token: 0x06000280 RID: 640 RVA: 0x0001DE44 File Offset: 0x0001C044
		private Set2Driver.ClevoKeyEx[] SetupMacroKeyEx(List<MacrokeyContent> macroKeys, bool bTimeRecord)
		{
			int num;
			if (macroKeys.Count > 32)
			{
				num = 32;
			}
			else
			{
				num = macroKeys.Count;
			}
			Set2Driver.ClevoKeyEx[] array = new Set2Driver.ClevoKeyEx[255];
			array[0].key = macroKeys[0].KeyCode;
			array[0].status = 1;
			array[0].DelayTime = macroKeys[1].KeyDelay;
			int num2 = 1;
			for (int i = 1; i < num - 1; i++)
			{
				if (macroKeys[i].KeyCode != 0)
				{
					array[i].key = macroKeys[i].KeyCode;
					if (macroKeys[i].KeyMakeBreak == KeyGlobal.MakeBreak.KeyMake)
					{
						array[i].status = 1;
					}
					else
					{
						array[i].status = 0;
					}
					if (bTimeRecord)
					{
						if (i + 1 >= macroKeys.Count)
						{
							array[i].DelayTime = 0;
						}
						else
						{
							array[i].DelayTime = macroKeys[i + 1].KeyDelay;
						}
					}
					else
					{
						array[i].DelayTime = 0;
					}
					num2++;
				}
			}
			array[num2].key = macroKeys[num2].KeyCode;
			array[num2].status = 0;
			array[num2].DelayTime = 0;
			return array;
		}

		// Token: 0x06000281 RID: 641 RVA: 0x0001DF98 File Offset: 0x0001C198
		private Set2Driver.ClevoKB[] SetupMacroKey(List<MacrokeyContent> macroKeys, int length, bool bTimeRecord)
		{
			List<Set2Driver.ClevoKB> list = new List<Set2Driver.ClevoKB>();
			Set2Driver.ClevoKB[] array = new Set2Driver.ClevoKB[length];
			int num;
			if (macroKeys.Count > length * 2)
			{
				num = length * 2;
			}
			else
			{
				num = macroKeys.Count;
			}
			if (macroKeys[0].KeyCode == 0)
			{
				Set2Driver.ClevoKB clevoKB = default(Set2Driver.ClevoKB);
				clevoKB.DownDelay = 0;
				clevoKB.UpDelay = 0;
				clevoKB.VK_Key = 0;
			}
			else
			{
				for (int i = 0; i < num; i++)
				{
					if (macroKeys[i].KeyMakeBreak != KeyGlobal.MakeBreak.KeyBreak)
					{
						Set2Driver.ClevoKB item = default(Set2Driver.ClevoKB);
						item.VK_Key = macroKeys[i].KeyCode;
						if (i + 1 >= macroKeys.Count)
						{
							item.DownDelay = 0;
						}
						else
						{
							item.DownDelay = macroKeys[i + 1].KeyDelay;
						}
						if (i + 2 >= num)
						{
							item.UpDelay = 0;
						}
						else
						{
							item.UpDelay = macroKeys[i + 2].KeyDelay;
						}
						list.Add(item);
					}
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				array[j].VK_Key = list[j].VK_Key;
				if (bTimeRecord)
				{
					array[j].DownDelay = list[j].DownDelay;
					array[j].UpDelay = list[j].UpDelay;
				}
				else
				{
					array[j].DownDelay = 0;
					array[j].UpDelay = 0;
				}
			}
			return array;
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0001E124 File Offset: 0x0001C324
		private void InitialEventLog()
		{
			this.outlog = new EventLog();
			try
			{
				this.outlog.Source = "PowerBIOSServer_Out";
				this.outlog.Log = "OutLog";
			}
			catch (Exception ex)
			{
				this.outlog.WriteEntry(ex.Message);
			}
			this.outlog.EnableRaisingEvents = true;
		}

		// Token: 0x0400035F RID: 863
		private const int _iExkeyLimitCount = 16;

		// Token: 0x04000360 RID: 864
		private bool bIsHidMouseExist = true;

		// Token: 0x04000361 RID: 865
		private EventLog outlog;

		// Token: 0x02000061 RID: 97
		// (Invoke) Token: 0x060002D2 RID: 722
		private delegate int EnableFilter();

		// Token: 0x02000062 RID: 98
		// (Invoke) Token: 0x060002D6 RID: 726
		private delegate int DisableFilter();

		// Token: 0x02000063 RID: 99
		// (Invoke) Token: 0x060002DA RID: 730
		private delegate int ClearFilterMacro();

		// Token: 0x02000064 RID: 100
		// (Invoke) Token: 0x060002DE RID: 734
		private delegate int CreateMacroKey(Set2Driver.ClevoKB[] Hotkey, Set2Driver.ClevoKB[] Macrokey);

		// Token: 0x02000065 RID: 101
		// (Invoke) Token: 0x060002E2 RID: 738
		private delegate int CreateStringKey(Set2Driver.ClevoKB[] Hotkey, Set2Driver.ClevoKB[] Startkey, byte[] mystring, Set2Driver.ClevoKB[] Endkey);

		// Token: 0x02000066 RID: 102
		// (Invoke) Token: 0x060002E6 RID: 742
		private delegate int CreateFilterSysEvent(Set2Driver.ClevoKB[] Hotkey, int EventID);

		// Token: 0x02000067 RID: 103
		// (Invoke) Token: 0x060002EA RID: 746
		private delegate int RemoveMacroKey(Set2Driver.ClevoKB[] Hotkey);

		// Token: 0x02000068 RID: 104
		// (Invoke) Token: 0x060002EE RID: 750
		private delegate int SimulateKey(int key, int status);

		// Token: 0x02000069 RID: 105
		// (Invoke) Token: 0x060002F2 RID: 754
		private delegate int CreateMacroKey_Mouse(int MyBtn, Set2Driver.ClevoKB[] Macrokey);

		// Token: 0x0200006A RID: 106
		// (Invoke) Token: 0x060002F6 RID: 758
		private delegate int CreateStringKey_Mouse(int MyBtn, Set2Driver.ClevoKB[] Startkey, byte[] mystring, Set2Driver.ClevoKB[] Endkey);

		// Token: 0x0200006B RID: 107
		// (Invoke) Token: 0x060002FA RID: 762
		private delegate int RemoveMacroKey_Mouse(int MyBtn);

		// Token: 0x0200006C RID: 108
		// (Invoke) Token: 0x060002FE RID: 766
		private delegate int CreateFilterSysEvent_Mouse(int MyBtn, int EventID);

		// Token: 0x0200006D RID: 109
		// (Invoke) Token: 0x06000302 RID: 770
		private delegate int EnableFilter_Mouse();

		// Token: 0x0200006E RID: 110
		// (Invoke) Token: 0x06000306 RID: 774
		private delegate int DisableFilter_Mouse();

		// Token: 0x0200006F RID: 111
		// (Invoke) Token: 0x0600030A RID: 778
		private delegate int ClearFilterMacro_Mouse();

		// Token: 0x02000070 RID: 112
		// (Invoke) Token: 0x0600030E RID: 782
		private delegate int SimulateMouse(int Button, int status);

		// Token: 0x02000071 RID: 113
		// (Invoke) Token: 0x06000312 RID: 786
		private delegate int CreateMacroKeyEx(Set2Driver.ClevoKB[] Hotkey, Set2Driver.ClevoKeyEx[] Macrokey);

		// Token: 0x02000072 RID: 114
		// (Invoke) Token: 0x06000316 RID: 790
		private delegate int CreateMacroKey_MouseEx(int MyBtn, Set2Driver.ClevoKeyEx[] Macrokey);

		// Token: 0x02000073 RID: 115
		// (Invoke) Token: 0x0600031A RID: 794
		private delegate int ImmediateMacroKey(Set2Driver.ClevoKeyEx[] Macrokey);

		// Token: 0x02000074 RID: 116
		// (Invoke) Token: 0x0600031E RID: 798
		private delegate int StartFilterLog();

		// Token: 0x02000075 RID: 117
		// (Invoke) Token: 0x06000322 RID: 802
		private delegate int StopFilterLog();

		// Token: 0x02000076 RID: 118
		// (Invoke) Token: 0x06000326 RID: 806
		private delegate int CountFilterLog();

		// Token: 0x02000077 RID: 119
		// (Invoke) Token: 0x0600032A RID: 810
		private delegate int GetFilterLog(int count, ref Set2Driver.KeyboardFilterLog MyLog);

		// Token: 0x02000078 RID: 120
		public struct ClevoKB
		{
			// Token: 0x0400049C RID: 1180
			public int VK_Key;

			// Token: 0x0400049D RID: 1181
			public int DownDelay;

			// Token: 0x0400049E RID: 1182
			public int UpDelay;
		}

		// Token: 0x02000079 RID: 121
		public struct ClevoKeyEx
		{
			// Token: 0x0400049F RID: 1183
			public int key;

			// Token: 0x040004A0 RID: 1184
			public int status;

			// Token: 0x040004A1 RID: 1185
			public int DelayTime;
		}

		// Token: 0x0200007A RID: 122
		public struct KeyboardFilterLog
		{
			// Token: 0x040004A2 RID: 1186
			public short KeyCode;

			// Token: 0x040004A3 RID: 1187
			public short Reserved;

			// Token: 0x040004A4 RID: 1188
			public short MakeCount;

			// Token: 0x040004A5 RID: 1189
			public short BreakCount;
		}

		// Token: 0x0200007B RID: 123
		public enum ClevoMouse
		{
			// Token: 0x040004A7 RID: 1191
			HKFLTRBTN_LEFT = 1,
			// Token: 0x040004A8 RID: 1192
			HKFLTRBTN_RIGHT = 4,
			// Token: 0x040004A9 RID: 1193
			HKFLTRBTN_MIDDLE = 16,
			// Token: 0x040004AA RID: 1194
			HKFLTRBTN_BACKWARD = 64,
			// Token: 0x040004AB RID: 1195
			HKFLTRBTN_FORWARD = 256
		}

		// Token: 0x0200007C RID: 124
		[StructLayout(LayoutKind.Sequential)]
		public class OSVersionInfo
		{
			// Token: 0x040004AC RID: 1196
			public int dwOSVersionInfoSize;

			// Token: 0x040004AD RID: 1197
			public int dwMajorVersion;

			// Token: 0x040004AE RID: 1198
			public int dwMinorVersion;

			// Token: 0x040004AF RID: 1199
			public int dwBuildNumber;

			// Token: 0x040004B0 RID: 1200
			public int dwPlatformId;

			// Token: 0x040004B1 RID: 1201
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string szCSDVersion;
		}
	}
}
