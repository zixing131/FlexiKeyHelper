using System;

namespace CC.FlexiKey
{
	// Token: 0x02000027 RID: 39
	public class KbStaClass
	{
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000215 RID: 533 RVA: 0x00019889 File Offset: 0x00017A89
		// (set) Token: 0x06000216 RID: 534 RVA: 0x00019891 File Offset: 0x00017A91
		public int KeyCode { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000217 RID: 535 RVA: 0x0001989A File Offset: 0x00017A9A
		// (set) Token: 0x06000218 RID: 536 RVA: 0x000198A2 File Offset: 0x00017AA2
		public int KeyCount { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000219 RID: 537 RVA: 0x000198AB File Offset: 0x00017AAB
		// (set) Token: 0x0600021A RID: 538 RVA: 0x000198B3 File Offset: 0x00017AB3
		public int StaLevel { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x0600021B RID: 539 RVA: 0x000198BC File Offset: 0x00017ABC
		// (set) Token: 0x0600021C RID: 540 RVA: 0x000198C4 File Offset: 0x00017AC4
		public bool IsDisable { get; set; }
	}
}
