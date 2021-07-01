using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace FlexiKeyHelper
{
    class KeyboardHookLib
    {
        //钩子类型：键盘  
        private const int WH_KEYBOARD_LL = 13;

        //自己创建窗口按键  
        public const int WM_KEYDOWN = 0x100;

        //全局系统按键  
        public const int WM_SYSKEYDOWN = 0x104;

        //键盘处理事件委托.  
        private delegate int HookHandle(int nCode, int wParam, IntPtr lParam);


        //客户端键盘处理事件  
        public delegate void ProcessKeyHandle(HookStruct param, out bool handle);


        //接收SetWindowsHookEx返回值  
        private static int _hHookValue = 0;


        //勾子程序处理事件  
        private static HookHandle _KeyBoardHookProcedure;


        //Hook结构  
        [StructLayout(LayoutKind.Sequential)]
        public class HookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }


        //设置钩子  
        [DllImport("user32.dll")]
        private static extern int SetWindowsHookEx(int idHook, HookHandle lpfn, IntPtr hInstance, int

threadId);


        //取消钩子  
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention =

CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);


        //调用下一个钩子  
        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);


        //获取当前线程ID  
        [DllImport("kernel32.dll")]
        private static extern int GetCurrentThreadId();


        //获取关联进程的主模块  
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string name);


        private IntPtr _hookWindowPtr = IntPtr.Zero;


        //构造器  
        public KeyboardHookLib() { }


        //外部调用的键盘处理事件,如果需要调用自己窗口建立的函数，则需要这行代码  
        private static ProcessKeyHandle _clientMethod = null;

        /// 安装勾子  
        //如果需要调用自己窗口建立的函数，则需要这行代码  
        public void InstallHook(ProcessKeyHandle clientMethod)
        {
            //{  
            //如果需要调用自己窗口建立的函数，则需要这行代码  
            _clientMethod = clientMethod;
            /*  
             * _clientMethod 相当于一个发射的工具，  
             * 从钩子代码这儿调用到你自己窗口建立的函数那儿  
             * 我做的是个最简单的辅助，  
             * 所以不需要调用到自己的函数那儿，  
             * 所以就没有把创建它  
              */
            //public void InstallHook()
            //{

            // 安装键盘钩子  
            if (_hHookValue == 0)
            {
                //GetHookProc 是钩子内部调用的函数，当按下键盘时，  
                //会调用到这儿来，可以改变名字  
                _KeyBoardHookProcedure = new HookHandle(GetHookProc);

                //得到线程  
                _hookWindowPtr = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);


                _hHookValue = SetWindowsHookEx(
                    WH_KEYBOARD_LL,
                    _KeyBoardHookProcedure,
                    _hookWindowPtr,
                    0);


                //如果设置钩子失败.  
                if (_hHookValue == 0)


                    UninstallHook();
            }
        }


        //取消钩子事件  
        public void UninstallHook()
        {
            if (_hHookValue != 0)
            {
                bool ret = UnhookWindowsHookEx(_hHookValue);
                if (ret) _hHookValue = 0;
            }
        }
        //钩子事件内部调用,调用_clientMethod方法转发到客户端应用。  
        private static int GetHookProc(int nCode, int wParam, IntPtr lParam)
        {
            //当nCode大于0，并且是按下事件时为1  
            if (nCode >= 0 && (wParam == WM_KEYDOWN) || (wParam == WM_SYSKEYDOWN))
            {

                //转换结构  
                HookStruct hookStruct = (HookStruct)Marshal.PtrToStructure(lParam, typeof(HookStruct));

                //是否拦截按键的标识符，默认不拦截  
                bool handle = false;

                //switch ((Keys)hookStruct.vkCode)
                //{
                //    //将拦截标识符置为拦截,向当前窗口发送一个回车，  
                //    //再发送greenisgood 10000，再发送一个回车  
                //    case Keys.F1: handle = true; SendKeys.Send("{ENTER}"); SendKeys.Send("greenisgood 10000"); SendKeys.Send("{ENTER}"); break;
                //}

                if (_clientMethod != null)
                {
                    //调用客户提供的事件处理程序。  
                    _clientMethod(hookStruct, out handle);
                    if (handle) return 1; //1:表示拦截键盘,return 退出  
                }
                if (handle) return 1;
            }
            return CallNextHookEx(_hHookValue, nCode, wParam, lParam);
        }
    }
}
