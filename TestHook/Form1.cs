using CC.FlexiKey;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlexiKeyHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _keyboardHook = new KeyboardHookLib();
            _keyboardHook.InstallHook(this.newKeyPress);

            this.Load += Form1_Load;
            this.FormClosed += Form1_FormClosed;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(_keyboardHook!=null)
            {
                _keyboardHook.UninstallHook();
            }
            if(notifyIcon1!=null)
            { 
                notifyIcon1.Visible = false;
            } 
        }

        private void newKeyPress(KeyboardHookLib.HookStruct hookStruct, out bool handle)
        {
            handle = false;
            Keys key = (Keys)hookStruct.vkCode;
            if (key == Keys.F7)
            {
                switchStatus();
                handle = true;
            } 
        }

        public struct COPYDATASTRUCT
        {
            // Token: 0x040007B0 RID: 1968
            public int dwData;

            // Token: 0x040007B1 RID: 1969
            public int cbData;

            // Token: 0x040007B2 RID: 1970
            public uint lpData;
        }

        NotifyIcon notifyIcon1;
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                setkb = new Set2Driver();
                getStatus();
                notifyIcon1 = new NotifyIcon();
                notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
                notifyIcon1.ContextMenu = new ContextMenu();
                notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("显示",(s1,e1)=> {
                    this.WindowState = FormWindowState.Minimized;
                    this.WindowState = FormWindowState.Normal;
                }));

                notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("退出", (s1, e1) => {
                    this.Close();
                }));

                notifyIcon1.Icon = this.Icon;
                notifyIcon1.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("发生错误：" + ex.Message);
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;
        }

        private static KeyboardHookLib _keyboardHook = null;
         
         
        private int GetKeyboardStatus()
        {
            byte[] array = new byte[4];
            ReadAppSettings(1, 8, 1, ref array[0]);
            var KeyboardStatus = BitConverter.ToInt32(array, 0);
            return KeyboardStatus;
        }

        // Token: 0x0600001C RID: 28
        [DllImport("InsydeDCHU_x86.dll")]
        public static extern int ReadAppSettings(int page, int offset, int length, ref byte buffer);


        private void SetKeyboardStatus(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteAppSettings(1, 8, 1, ref bytes[0]);
            if (value == 1)
            {
                label1.Text = "当前FlexiKey状态：开";
                this.setkb.SetKbEnableFilter();
            }
            else
            {
                label1.Text = "当前FlexiKey状态：关";
                this.setkb.SetKbDisableFilter();
            }

            showNotify(label1.Text,value);
        }  

        private void showNotify(string tips,int value)
        { 
            notifyIcon1.ShowBalloonTip(1000, "FlexiKey状态改变通知", tips, value == 1? ToolTipIcon .Info: ToolTipIcon.Error);
        }

        [DllImport("InsydeDCHU_x86.dll")]
        public static extern int WriteAppSettings(int page, int offset, int length, ref byte buffer);
        private Set2Driver setkb;

        private void switchStatus()
        {
            try
            { 
                var status = GetKeyboardStatus();
                SetKeyboardStatus(status == 1 ? 0 : 1);
            }
            catch(Exception ex)
            {
                MessageBox.Show("发生错误："+ex.Message);
            }
        }

        private void getStatus()
        {
            var status = GetKeyboardStatus();
            if (status == 1)
            {
                label1.Text = "当前FlexiKey状态：开"; 
            }
            else
            {
                label1.Text = "当前FlexiKey状态：关"; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switchStatus();
        }
    }
}
