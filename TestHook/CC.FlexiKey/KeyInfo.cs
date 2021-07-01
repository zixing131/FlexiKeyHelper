using System;
using System.Collections.Generic;

namespace CC.FlexiKey
{
	// Token: 0x0200002A RID: 42
	public class KeyInfo
	{
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600022C RID: 556 RVA: 0x00019951 File Offset: 0x00017B51
		// (set) Token: 0x0600022D RID: 557 RVA: 0x00019959 File Offset: 0x00017B59
		public KeyGlobal.DeviceType Device { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600022E RID: 558 RVA: 0x00019962 File Offset: 0x00017B62
		// (set) Token: 0x0600022F RID: 559 RVA: 0x0001996A File Offset: 0x00017B6A
		public int KeyCode { get; set; }

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000230 RID: 560 RVA: 0x00019973 File Offset: 0x00017B73
		// (set) Token: 0x06000231 RID: 561 RVA: 0x0001997B File Offset: 0x00017B7B
		public string KeyName { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000232 RID: 562 RVA: 0x00019984 File Offset: 0x00017B84
		// (set) Token: 0x06000233 RID: 563 RVA: 0x0001998C File Offset: 0x00017B8C
		public string CheckBoxName { get; set; }

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000234 RID: 564 RVA: 0x00019995 File Offset: 0x00017B95
		// (set) Token: 0x06000235 RID: 565 RVA: 0x0001999D File Offset: 0x00017B9D
		public string KeyDisplay { get; set; }

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000236 RID: 566 RVA: 0x000199A6 File Offset: 0x00017BA6
		// (set) Token: 0x06000237 RID: 567 RVA: 0x000199AE File Offset: 0x00017BAE
		public string Tip { get; set; }

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000238 RID: 568 RVA: 0x000199B7 File Offset: 0x00017BB7
		// (set) Token: 0x06000239 RID: 569 RVA: 0x000199BF File Offset: 0x00017BBF
		public KeyGlobal.KeyActionType ActionType { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x0600023A RID: 570 RVA: 0x000199C8 File Offset: 0x00017BC8
		// (set) Token: 0x0600023B RID: 571 RVA: 0x000199D0 File Offset: 0x00017BD0
		public bool IsSelected { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600023C RID: 572 RVA: 0x000199D9 File Offset: 0x00017BD9
		// (set) Token: 0x0600023D RID: 573 RVA: 0x000199E1 File Offset: 0x00017BE1
		public bool IsKeypressDelay { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600023E RID: 574 RVA: 0x000199EA File Offset: 0x00017BEA
		// (set) Token: 0x0600023F RID: 575 RVA: 0x000199F2 File Offset: 0x00017BF2
		public int MacroKeyGruopFlag { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000240 RID: 576 RVA: 0x000199FB File Offset: 0x00017BFB
		// (set) Token: 0x06000241 RID: 577 RVA: 0x00019A03 File Offset: 0x00017C03
		public string AppPath { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000242 RID: 578 RVA: 0x00019A0C File Offset: 0x00017C0C
		// (set) Token: 0x06000243 RID: 579 RVA: 0x00019A14 File Offset: 0x00017C14
		public int AppEventId { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000244 RID: 580 RVA: 0x00019A1D File Offset: 0x00017C1D
		// (set) Token: 0x06000245 RID: 581 RVA: 0x00019A25 File Offset: 0x00017C25
		public string TextContent { get; set; }

		// Token: 0x0400034D RID: 845
		public List<MacrokeyContent> MacroKey = new List<MacrokeyContent>();

		// Token: 0x04000351 RID: 849
		public List<MacrokeyContent> StartKey = new List<MacrokeyContent>();

		// Token: 0x04000352 RID: 850
		public List<MacrokeyContent> SendKey = new List<MacrokeyContent>();
	}
}
