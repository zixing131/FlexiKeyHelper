using System;

namespace CC.FlexiKey
{
	// Token: 0x02000026 RID: 38
	public class KeyGlobal
	{
		// Token: 0x04000336 RID: 822
		public static HookKeysTable hookKeysTable;

		// Token: 0x04000337 RID: 823
		public static int MacroKeyMax = 24;

		// Token: 0x02000057 RID: 87
		public enum KbColorPart
		{
			// Token: 0x04000477 RID: 1143
			kball,
			// Token: 0x04000478 RID: 1144
			left,
			// Token: 0x04000479 RID: 1145
			mid,
			// Token: 0x0400047A RID: 1146
			right,
			// Token: 0x0400047B RID: 1147
			touchpad,
			// Token: 0x0400047C RID: 1148
			lightbar,
			// Token: 0x0400047D RID: 1149
			allpart,
			// Token: 0x0400047E RID: 1150
			a_cover
		}

		// Token: 0x02000058 RID: 88
		public enum KeyActionType
		{
			// Token: 0x04000480 RID: 1152
			none,
			// Token: 0x04000481 RID: 1153
			keypress,
			// Token: 0x04000482 RID: 1154
			launch,
			// Token: 0x04000483 RID: 1155
			text,
			// Token: 0x04000484 RID: 1156
			disable
		}

		// Token: 0x02000059 RID: 89
		public enum DeviceType
		{
			// Token: 0x04000486 RID: 1158
			none,
			// Token: 0x04000487 RID: 1159
			keyboard,
			// Token: 0x04000488 RID: 1160
			mouse
		}

		// Token: 0x0200005A RID: 90
		public enum MakeBreak
		{
			// Token: 0x0400048A RID: 1162
			KeyMake,
			// Token: 0x0400048B RID: 1163
			KeyBreak
		}

		// Token: 0x0200005B RID: 91
		public enum StaLevel
		{
			// Token: 0x0400048D RID: 1165
			Sta1 = 1,
			// Token: 0x0400048E RID: 1166
			Sta2,
			// Token: 0x0400048F RID: 1167
			Sta3,
			// Token: 0x04000490 RID: 1168
			Sta4,
			// Token: 0x04000491 RID: 1169
			Sta5,
			// Token: 0x04000492 RID: 1170
			StaDisable = 9
		}
	}
}
