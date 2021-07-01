using System;
using System.Collections.Generic;

namespace CC.FlexiKey
{
	// Token: 0x0200002D RID: 45
	public class HookKeysTable
	{
		// Token: 0x0600024F RID: 591 RVA: 0x00019C86 File Offset: 0x00017E86
		public HookKeysTable()
		{
			this.KeysTableList = HookKeysTable.CreateScanKeyTable(this.KeysTableList);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00019CA0 File Offset: 0x00017EA0
		public string GetKeyDisplay(int KeyCode)
		{
			int num = this.KeysTableList.FindLastIndex((KeysTableStruct _i) => _i.KeyScanCode.Equals(KeyCode.ToString()));
			if (num != -1)
			{
				return this.KeysTableList[num].KeyDisplay;
			}
			return "";
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00019CF0 File Offset: 0x00017EF0
		public string GetKeyDisplay(string KeyCode)
		{
			int num = this.KeysTableList.FindIndex((KeysTableStruct _i) => _i.KeyScanCode.Equals(KeyCode));
			if (num != -1)
			{
				return this.KeysTableList[num].KeyDisplay;
			}
			return "err_" + KeyCode;
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00019D4C File Offset: 0x00017F4C
		public string GetScanCodeKeysDisplay(string KeyCode)
		{
			int num = this.KeysTableList.FindIndex((KeysTableStruct _i) => _i.KeyScanCode.Equals(KeyCode));
			if (num != -1)
			{
				return this.KeysTableList[num].KeyDisplay;
			}
			return "err_" + KeyCode;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x00019DA8 File Offset: 0x00017FA8
		public int GetKeyCode(string KeyDisplay)
		{
			int num = this.KeysTableList.FindIndex((KeysTableStruct _i) => _i.KeyDisplay.Equals(KeyDisplay));
			if (num != -1)
			{
				return (int)Convert.ToInt16(this.KeysTableList[num].KeyScanCode);
			}
			return -1;
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00019DF8 File Offset: 0x00017FF8
		private static List<KeysTableStruct> CreateScanKeyTable(List<KeysTableStruct> table)
		{
			string language = UiStringTable.GetLanguage();
			table = new List<KeysTableStruct>();
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "1",
					KeyDisplay = "Échap"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "1",
					KeyDisplay = "ESC"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "2",
					KeyDisplay = "&"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "2",
					KeyDisplay = "1"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "3",
					KeyDisplay = "é"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "3",
					KeyDisplay = "2"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "4",
					KeyDisplay = "\""
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "4",
					KeyDisplay = "3"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "5",
					KeyDisplay = "'"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "5",
					KeyDisplay = "4"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "6",
					KeyDisplay = "("
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "6",
					KeyDisplay = "5"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "7",
					KeyDisplay = "-"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "7",
					KeyDisplay = "6"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "8",
					KeyDisplay = "è"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "8",
					KeyDisplay = "7"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "9",
					KeyDisplay = "_"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "9",
					KeyDisplay = "8"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "10",
					KeyDisplay = "ç"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "10",
					KeyDisplay = "9"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "11",
					KeyDisplay = "à"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "11",
					KeyDisplay = "0"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "12",
					KeyDisplay = ")"
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "12",
					KeyDisplay = "*"
				});
			}
			else if (language.Contains("pt"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "12",
					KeyDisplay = "'"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "12",
					KeyDisplay = "'"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "12",
					KeyDisplay = "ß"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "12",
					KeyDisplay = "'"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "12",
					KeyDisplay = "-"
				});
			}
			if (language.Contains("ja"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "13",
					KeyDisplay = "^"
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "13",
					KeyDisplay = "-"
				});
			}
			else if (language.Contains("pt"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "13",
					KeyDisplay = "«"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "13",
					KeyDisplay = "¡"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "13",
					KeyDisplay = "´"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "13",
					KeyDisplay = "ì"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "13",
					KeyDisplay = "="
				});
			}
			if (language.Contains("tr") || language.Contains("pt") || language.Contains("es") || language.Contains("de") || language.Contains("it") || language.Contains("fr") || language == "en-gb")
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "14",
					KeyDisplay = "←BACKSPACE"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "14",
					KeyDisplay = "←BACKSPACE"
				});
			}
			if (language.Contains("tr") || language.Contains("pt") || language.Contains("es") || language.Contains("de") || language.Contains("it") || language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "15",
					KeyDisplay = "↹"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "15",
					KeyDisplay = "TAB ↹"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "16",
					KeyDisplay = "A"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "16",
					KeyDisplay = "Q"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "17",
					KeyDisplay = "Z"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "17",
					KeyDisplay = "W"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "18",
				KeyDisplay = "E"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "19",
				KeyDisplay = "R"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "20",
				KeyDisplay = "T"
			});
			if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "21",
					KeyDisplay = "Z"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "21",
					KeyDisplay = "Y"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "22",
				KeyDisplay = "U"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "23",
				KeyDisplay = "I"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "24",
				KeyDisplay = "O"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "25",
				KeyDisplay = "P"
			});
			if (language.Contains("ja"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "26",
					KeyDisplay = "@"
				});
			}
			else if (language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "26",
					KeyDisplay = "´"
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "26",
					KeyDisplay = "ğ"
				});
			}
			else if (language.Contains("pt-pt"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "26",
					KeyDisplay = "+"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "26",
					KeyDisplay = "`"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "26",
					KeyDisplay = "ü"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "26",
					KeyDisplay = "è"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "26",
					KeyDisplay = "^"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "26",
					KeyDisplay = "["
				});
			}
			if (language.Contains("ja") || language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "27",
					KeyDisplay = "["
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "27",
					KeyDisplay = "ü"
				});
			}
			else if (language.Contains("pt-pt"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "27",
					KeyDisplay = "´"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "27",
					KeyDisplay = "+"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "27",
					KeyDisplay = "+"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "27",
					KeyDisplay = "+"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "27",
					KeyDisplay = "$"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "27",
					KeyDisplay = "]"
				});
			}
			if (language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "28",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "28",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("pt-pt"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "28",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "28",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "28",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "28",
					KeyDisplay = "↵Invio"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "28",
					KeyDisplay = "↲Entrée"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "28",
					KeyDisplay = "↲ENTER"
				});
			}
			if (language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57372",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57372",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("pt-pt"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57372",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57372",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57372",
					KeyDisplay = "↲Enter"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57372",
					KeyDisplay = "↵Invio"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57372",
					KeyDisplay = "↲Entrée"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57372",
					KeyDisplay = "↲ENTER"
				});
			}
			if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "29",
					KeyDisplay = "Strg"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "29",
					KeyDisplay = "LEFT CTRL"
				});
			}
			if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57373",
					KeyDisplay = "Strg"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57373",
					KeyDisplay = "RIGHT CTRL"
				});
			}
			if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "30",
					KeyDisplay = "Q"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "30",
					KeyDisplay = "A"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "31",
				KeyDisplay = "S"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "32",
				KeyDisplay = "D"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "33",
				KeyDisplay = "F"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "34",
				KeyDisplay = "G"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57378",
				KeyDisplay = "Play"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "35",
				KeyDisplay = "H"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "36",
				KeyDisplay = "J"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "37",
				KeyDisplay = "K"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "38",
				KeyDisplay = "L"
			});
			if (language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "39",
					KeyDisplay = "Ç"
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "39",
					KeyDisplay = "Ş"
				});
			}
			else if (language.Contains("pt-pt"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "39",
					KeyDisplay = "Ç"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "39",
					KeyDisplay = "Ñ"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "39",
					KeyDisplay = "Ö"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "39",
					KeyDisplay = "ò"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "39",
					KeyDisplay = "M"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "39",
					KeyDisplay = ";"
				});
			}
			if (language.Contains("ja"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "40",
					KeyDisplay = ":"
				});
			}
			else if (language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "40",
					KeyDisplay = "~"
				});
			}
			else if (language.Contains("pt-pt"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "40",
					KeyDisplay = "º"
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "40",
					KeyDisplay = "İ"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "40",
					KeyDisplay = "´"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "40",
					KeyDisplay = "Ä"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "40",
					KeyDisplay = "à"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "40",
					KeyDisplay = "ù"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "40",
					KeyDisplay = "'"
				});
			}
			if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "41",
					KeyDisplay = "\""
				});
			}
			else if (language.Contains("pt") || language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "41",
					KeyDisplay = "\\"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "41",
					KeyDisplay = "º"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "41",
					KeyDisplay = "^"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "41",
					KeyDisplay = "²"
				});
			}
			else if (language.Contains("ru"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "41",
					KeyDisplay = "Ё"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "41",
					KeyDisplay = "`"
				});
			}
			if (language.Contains("tr") || language.Contains("pt") || language.Contains("es") || language.Contains("de") || language.Contains("it") || language.Contains("fr") || language == "en-gb")
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "42",
					KeyDisplay = "⇧SHIFT"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "42",
					KeyDisplay = "⇧SHIFT"
				});
			}
			if (language == "en-gb" || language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "43",
					KeyDisplay = "#"
				});
			}
			else if (language.Contains("ja") || language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "43",
					KeyDisplay = "]"
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "43",
					KeyDisplay = ","
				});
			}
			else if (language.Contains("pt-pt"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "43",
					KeyDisplay = "~"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "43",
					KeyDisplay = "Ç"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "43",
					KeyDisplay = "ù"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "43",
					KeyDisplay = "*"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "43",
					KeyDisplay = "\\"
				});
			}
			if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "44",
					KeyDisplay = "Y"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "44",
					KeyDisplay = "W"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "44",
					KeyDisplay = "Z"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "45",
				KeyDisplay = "X"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "46",
				KeyDisplay = "C"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "47",
				KeyDisplay = "V"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "48",
				KeyDisplay = "B"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "49",
				KeyDisplay = "N"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "50",
				KeyDisplay = "M"
			});
			if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "51",
					KeyDisplay = "Ö"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "51",
					KeyDisplay = ","
				});
			}
			if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "52",
					KeyDisplay = "Ç"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "52",
					KeyDisplay = ":"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "52",
					KeyDisplay = "."
				});
			}
			if (language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "53",
					KeyDisplay = ";"
				});
			}
			else if (language.Contains("tr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "53",
					KeyDisplay = "."
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "53",
					KeyDisplay = "!"
				});
			}
			else if (language.Contains("pt-pt") || language.Contains("es") || language.Contains("de") || language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "53",
					KeyDisplay = "-"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "53",
					KeyDisplay = "/"
				});
			}
			if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57397",
					KeyDisplay = "÷"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57397",
					KeyDisplay = "/"
				});
			}
			if (language.Contains("tr") || language.Contains("pt") || language.Contains("es") || language.Contains("de") || language.Contains("it") || language.Contains("fr") || language == "en-gb")
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "54",
					KeyDisplay = "⇧SHIFT"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "54",
					KeyDisplay = "⇧SHIFT"
				});
			}
			if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "55",
					KeyDisplay = "×"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "55",
					KeyDisplay = "*"
				});
			}
			if (language == "es")
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57399",
					KeyDisplay = "Imp Pnt"
				});
			}
			else if (language == "de")
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57399",
					KeyDisplay = "Druck"
				});
			}
			else if (language == "it")
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57399",
					KeyDisplay = "Stamp"
				});
			}
			else if (language == "fr")
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57399",
					KeyDisplay = "Impécr"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57399",
					KeyDisplay = "PRTSC"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "56",
				KeyDisplay = "ALT"
			});
			if (language.Contains("tr") || language.Contains("pt") || language.Contains("es") || language.Contains("de") || language.Contains("it") || language.Contains("fr") || language == "en-gb")
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57400",
					KeyDisplay = "Alt Gr"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57400",
					KeyDisplay = "ALT"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57",
				KeyDisplay = "SPACE"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57482",
				KeyDisplay = "Pause/Break"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57386",
				KeyDisplay = "Pause/Break"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57629",
				KeyDisplay = "Pause/Break"
			});
			if (language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "58",
					KeyDisplay = "Fixa"
				});
			}
			else if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "58",
					KeyDisplay = "Bloq mayús"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "58",
					KeyDisplay = "⇩"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "58",
					KeyDisplay = "CAPS LOCK"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "59",
				KeyDisplay = "F1"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "60",
				KeyDisplay = "F2"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "61",
				KeyDisplay = "F3"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "62",
				KeyDisplay = "F4"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "63",
				KeyDisplay = "F5"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "64",
				KeyDisplay = "F6"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "65",
				KeyDisplay = "F7"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "66",
				KeyDisplay = "F8"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "67",
				KeyDisplay = "F9"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "68",
				KeyDisplay = "F10"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "14753093",
				KeyDisplay = "Pause"
			});
			if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "69",
					KeyDisplay = "Bloq Num"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "69",
					KeyDisplay = "Num↓"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "69",
					KeyDisplay = "Bloc Num"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "69",
					KeyDisplay = "Verr num"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "69",
					KeyDisplay = "NUM LOCK"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57414",
				KeyDisplay = "Break"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "70",
				KeyDisplay = "Scr LK"
			});
			if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "71",
					KeyDisplay = "7(Inicio)"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "71",
					KeyDisplay = "7(Pos 1)"
				});
			}
			else if (language.Contains("it") || language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "71",
					KeyDisplay = "7(↖)"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "71",
					KeyDisplay = "7(HOME)"
				});
			}
			if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57415",
					KeyDisplay = "Inicio"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57415",
					KeyDisplay = "Pos 1"
				});
			}
			else if (language.Contains("it") || language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57415",
					KeyDisplay = "↖"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57415",
					KeyDisplay = "HOME"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "72",
				KeyDisplay = "8(↑)"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57416",
				KeyDisplay = "▲"
			});
			if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "73",
					KeyDisplay = "9(Re pág)"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "73",
					KeyDisplay = "9(Bild↑)"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "73",
					KeyDisplay = "9(Pag↑)"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "73",
					KeyDisplay = "9(⇞)"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "73",
					KeyDisplay = "9(PGUP)"
				});
			}
			if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57417",
					KeyDisplay = "Re pág"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57417",
					KeyDisplay = "Bild↑"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57417",
					KeyDisplay = "Pag↑"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57417",
					KeyDisplay = "⇞"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57417",
					KeyDisplay = "PGUP"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "74",
				KeyDisplay = "-"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "75",
				KeyDisplay = "4(←)"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57419",
				KeyDisplay = "◀"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "76",
				KeyDisplay = "5"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "77",
				KeyDisplay = "6(→)"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57421",
				KeyDisplay = "▶"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "78",
				KeyDisplay = "+"
			});
			if (language.Contains("es") || language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "79",
					KeyDisplay = "1(Fin)"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "79",
					KeyDisplay = "1(Ende)"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "79",
					KeyDisplay = "1(Fine)"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "79",
					KeyDisplay = "1(END)"
				});
			}
			if (language.Contains("es") || language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57423",
					KeyDisplay = "Fin"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57423",
					KeyDisplay = "Ende"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57423",
					KeyDisplay = "Fine"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57423",
					KeyDisplay = "END"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "80",
				KeyDisplay = "2(↓)"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57424",
				KeyDisplay = "▼"
			});
			if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "81",
					KeyDisplay = "3(Av pág)"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "81",
					KeyDisplay = "3(Bild↓)"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "81",
					KeyDisplay = "3(Pag↓)"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "81",
					KeyDisplay = "3(⇟)"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "81",
					KeyDisplay = "3(PGDN)"
				});
			}
			if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57425",
					KeyDisplay = "Av pág"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57425",
					KeyDisplay = "Bild↓"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57425",
					KeyDisplay = "Pag↓"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57425",
					KeyDisplay = "⇟"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57425",
					KeyDisplay = "PGDN"
				});
			}
			if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "82",
					KeyDisplay = "0(Einfg)"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "82",
					KeyDisplay = "0(INS)"
				});
			}
			if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57426",
					KeyDisplay = "Einfg"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57426",
					KeyDisplay = "Insérer"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57426",
					KeyDisplay = "INS"
				});
			}
			if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "83",
					KeyDisplay = ".(Supr)"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "83",
					KeyDisplay = ".(Entf)"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "83",
					KeyDisplay = ".(Canc)"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "83",
					KeyDisplay = ".(Suppr)"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "83",
					KeyDisplay = ".(DEL)"
				});
			}
			if (language.Contains("es"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57427",
					KeyDisplay = "Supr"
				});
			}
			else if (language.Contains("de"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57427",
					KeyDisplay = "Entf"
				});
			}
			else if (language.Contains("it"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57427",
					KeyDisplay = "Canc"
				});
			}
			else if (language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57427",
					KeyDisplay = "Suppr"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "57427",
					KeyDisplay = "DEL"
				});
			}
			if (language.Contains("tr") || language.Contains("pt-pt") || language.Contains("es") || language.Contains("de") || language.Contains("it") || language.Contains("fr"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "86",
					KeyDisplay = "<"
				});
			}
			else
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "86",
					KeyDisplay = "\\"
				});
			}
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "87",
				KeyDisplay = "F11"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "88",
				KeyDisplay = "F12"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57435",
				KeyDisplay = "WIN"
			});
			table.Add(new KeysTableStruct
			{
				KeyScanCode = "57437",
				KeyDisplay = "MENU"
			});
			if (language.Contains("ja"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "112",
					KeyDisplay = "カタカナひらがな"
				});
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "115",
					KeyDisplay = "\\"
				});
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "121",
					KeyDisplay = "変換"
				});
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "123",
					KeyDisplay = "無変換"
				});
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "125",
					KeyDisplay = "￥"
				});
			}
			else if (language.Contains("pt-br"))
			{
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "115",
					KeyDisplay = "/"
				});
				table.Add(new KeysTableStruct
				{
					KeyScanCode = "126",
					KeyDisplay = "."
				});
			}
			return table;
		}

		// Token: 0x04000356 RID: 854
		public List<KeysTableStruct> KeysTableList;

		// Token: 0x0200005C RID: 92
		public enum KeyLanguage
		{
			// Token: 0x04000494 RID: 1172
			usa,
			// Token: 0x04000495 RID: 1173
			uk,
			// Token: 0x04000496 RID: 1174
			br,
			// Token: 0x04000497 RID: 1175
			jp
		}
	}
}
