using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace FFXIV_netBot
{
    public class CoreKeyboard
    {
        private String processName;
        private Process currentProcess;
        private IntPtr processHandle;

        private HashSet<Keys> _keySet;

        private uint __keyPressLimit = 3;

        [DllImport("user32.dll")]
        protected static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        public CoreKeyboard()
        {
            this._keySet = new HashSet<Keys>();
        }

        protected bool attachProcess(String processName)
        {
            if (this.processName == null || !this.processName.Equals(processName))
                this.processName = processName;

            return this.attachProcess();
        }

        private bool attachProcess()
        {
            if (this.processName.Length > 0)
            {
                Process[] processes = Process.GetProcessesByName(this.processName);
                if (processes.Length > 0)
                {
                    // get first process of processList
                    this.currentProcess = processes[0];
                    // check if currentProcess not null and can init the Process handle 
                    // process handle is if true in this.processHandle
                    return (this.currentProcess != null && this.initHandle());
                }
            }
            return false;
        }

        private bool initHandle()
        {
            this.processHandle = this.currentProcess.MainWindowHandle;
            return ((uint)this.processHandle > 0);
        }

        protected void pressKey (Keys key, uint interval = 0)
        {
            if (interval < 1)
            {
                Random random = new Random();
                interval = (uint)random.Next(SettingsSingleton.Instance.timings.randomKeyPressMin, SettingsSingleton.Instance.timings.randomKeyPressMax);
            }

            this.pressKeyDown(key);
            System.Threading.Timer timer;
            timer = new System.Threading.Timer(new TimerCallback(_pressedKeyRelease), key, interval, -1);
        }

        // threaded area
        private void _pressedKeyRelease(Object obj)
        {
            Keys key = (Keys)obj;
            this.pressKeyUp(key);
        }

        protected void pressKeyDown(Keys key)
        {
            if (!this._keySet.Contains(key))
            {
                if (this.processHandle != null && this._keySet.Count < this.__keyPressLimit)
                {
                    this._keySet.Add(key);
                    SendMessage(this.processHandle, (uint)0x0100, (IntPtr)key, (IntPtr)0);
                }
            }
        }

        protected void pressKeyUp(Keys key)
        {
            if (this._keySet.Contains(key))
            {
                if (this.processHandle != null)
                {
                    this._keySet.Remove(key);
                    SendMessage(this.processHandle, (uint)0x0101, (IntPtr)key, (IntPtr)0);
                }
            }
        }
    }
}
