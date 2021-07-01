using System;

namespace CC.FlexiKey
{
	// Token: 0x02000028 RID: 40
	public class MacrokeyContent
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600021E RID: 542 RVA: 0x000198CD File Offset: 0x00017ACD
		// (set) Token: 0x0600021F RID: 543 RVA: 0x000198D5 File Offset: 0x00017AD5
		public int KeyCode { get; set; }

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x06000220 RID: 544 RVA: 0x000198DE File Offset: 0x00017ADE
		// (set) Token: 0x06000221 RID: 545 RVA: 0x000198E6 File Offset: 0x00017AE6
		public int KeysGroup { get; set; }

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000222 RID: 546 RVA: 0x000198EF File Offset: 0x00017AEF
		// (set) Token: 0x06000223 RID: 547 RVA: 0x000198F7 File Offset: 0x00017AF7
		public string KeyDisplay { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000224 RID: 548 RVA: 0x00019900 File Offset: 0x00017B00
		// (set) Token: 0x06000225 RID: 549 RVA: 0x00019908 File Offset: 0x00017B08
		public KeyGlobal.MakeBreak KeyMakeBreak { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000226 RID: 550 RVA: 0x00019911 File Offset: 0x00017B11
		// (set) Token: 0x06000227 RID: 551 RVA: 0x00019919 File Offset: 0x00017B19
		public int KeyDelay { get; set; }
	}
}
