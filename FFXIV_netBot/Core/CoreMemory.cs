using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace FFXIV_netBot
{
    public class CoreMemory
    {
        private String processName;
        private Process currentProcess;
        private IntPtr processHandle;

        private Boolean _useable = false;

        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, UIntPtr nSize, ref uint lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(UInt32 dwDesiredAccess, Boolean bInheritHandle, UInt32 dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, int lpBaseAddress, byte[] lpBuffer, int nSize, int lpNumberOfBytesWritten);

        public enum ProcessAccessType : uint
        {
            PROCESS_ALL_ACCESS = PROCESS_CREATE_PROCESS | PROCESS_CREATE_THREAD | PROCESS_DUP_HANDLE | PROCESS_QUERY_INFORMATION |
                               PROCESS_QUERY_LIMITED_INFORMATION | PROCESS_SET_INFORMATION | PROCESS_SET_QUOTA | PROCESS_SUSPEND_RESUME |
                               PROCESS_TERMINATE | PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE,
            PROCESS_READ_WRITE_ACCESS = PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE,
            PROCESS_CREATE_PROCESS = 0x0080,
            PROCESS_CREATE_THREAD = 0x0002,
            PROCESS_DUP_HANDLE = 0x0040,
            PROCESS_QUERY_INFORMATION = 0x0400,
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
            PROCESS_SET_INFORMATION = 0x0200,
            PROCESS_SET_QUOTA = 0x0100,
            PROCESS_SUSPEND_RESUME = 0x0800,
            PROCESS_TERMINATE = 0x0001,
            PROCESS_VM_OPERATION = 0x0008,
            PROCESS_VM_READ = 0x0010,
            PROCESS_VM_WRITE = 0x0020
        }

        public CoreMemory()
        {
        }

        public Boolean isUseable()
        {
            return this._useable;
        }

        public IntPtr processMainWindowHandle()
        {
            return this.currentProcess.MainWindowHandle;
        }

        protected bool attachProcess(String processName) 
        {
            if (this.processName == null || !this.processName.Equals(processName))
                this.processName = processName;

            Boolean useable = this.attachProcess();
            this._useable = useable;
            return useable;
        }

        private bool attachProcess()
        {
            if(this.processName.Length > 0)
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
            // PROCESS_VM_READ (0x0010) ATM read ONLY!
            // only bad guys write in other people memory ;)
            // edit: it was a nice dream T.T ... add write flag
            this.processHandle = OpenProcess((uint)ProcessAccessType.PROCESS_READ_WRITE_ACCESS, true, (uint)this.currentProcess.Id);
            return ((uint)this.processHandle > 0);
        }

        public uint processAddress()
        {
            if (this.currentProcess != null && !this.currentProcess.HasExited)
            {
                return (uint)this.currentProcess.MainModule.BaseAddress;
            } 
            else
            {
                this._useable = false;
                this.processHandle = (IntPtr)0;
                this.currentProcess = null;
            }
            return 0;
        }

        private Byte[] readRawMemory(uint byteSize, uint address, uint offset = 0) 
        {
            if (this.currentProcess == null || this.currentProcess.HasExited)
            {
                this._useable = false;
                this.processHandle = (IntPtr)0;
                this.currentProcess = null;
            }

            // able to read memory? exist processHandle?
            bool canReadMemory = ((uint)this.processHandle > 0);

            // if not try to attach process
            if (!canReadMemory)
                canReadMemory = this.attachProcess();

            byte[] bytes = new byte[byteSize];

            // if nothing worked ... don't read memory
            if (canReadMemory)
            {
                uint rw = 0;

                address += offset;
                ReadProcessMemory(this.processHandle, (IntPtr)address, bytes, (UIntPtr)byteSize, ref rw);
                return bytes;
            }
            return bytes;
        }

        private void writeRawMemory(Byte[] bytes, uint address, uint offset = 0)
        {
            if (this.currentProcess == null || this.currentProcess.HasExited)
            {
                this._useable = false;
                this.processHandle = (IntPtr)0;
                this.currentProcess = null;
            }

            bool canReadMemory = ((uint)this.processHandle > 0);

            // if not try to attach process
            if (!canReadMemory)
                canReadMemory = this.attachProcess();

            if (canReadMemory)
            {
                address += offset;
                WriteProcessMemory(this.processHandle, (int)address, bytes, bytes.Length, 0);
                //System.Diagnostics.Debug.WriteLine("NOTICE: MEMORYWRITE addr:{0:X}", address);
            }
        }

        protected UInt32 readPointer(uint address, uint offset = 0)
        {
            byte[] bytes = this.readRawMemory(24, address, offset);
            return BitConverter.ToUInt32(bytes, 0);
        }

        protected Int32 read4ByteValue(uint address, uint offset = 0)
        {
            byte[] bytes = this.readRawMemory(sizeof(Int32), address, offset);
            return BitConverter.ToInt32(bytes, 0);
        }

        protected Int32 readIntValue(uint address, uint offset = 0)
        {
            return this.read4ByteValue(address, offset);
        }

        protected Single readFloatValue(uint address, uint offset = 0)
        {
            byte[] bytes = this.readRawMemory(sizeof(Single), address, offset);
            Single res = BitConverter.ToSingle(bytes, 0);
            if (res < 0.00001 || res > -0.00001)
                res = (Single)Math.Round(res, 4);
            return res;
        }

        protected Double readDoubleValue(uint address, uint offset = 0)
        {
            byte[] bytes = this.readRawMemory(sizeof(Double), address, offset);
            return BitConverter.ToSingle(bytes, 0);
        }

        protected String readStringValue(uint stringLength, uint address, uint offset = 0)
        {
            byte[] bytes = this.readRawMemory(stringLength, address, offset);

            int subPos = Array.IndexOf(bytes, (byte)0x0);
            if (subPos < 0)
                subPos = bytes.Length;

            byte[] finalByte = new byte[subPos];
            System.Buffer.BlockCopy(bytes, 0, finalByte, 0, finalByte.Length);
            bytes = new ArraySegment<byte>(bytes, 0, subPos).Array;
            return System.Text.Encoding.UTF8.GetString(finalByte);
        }

        protected Boolean readBoolValue(uint address, uint offset = 0)
        {
            byte[] bytes = this.readRawMemory(sizeof(Boolean), address, offset);
            return BitConverter.ToBoolean(bytes, 0);
        }

        protected void writeFloatValue(Single value, uint address, uint offset = 0)
        {
            Byte[] valueByte = BitConverter.GetBytes(value);
            this.writeRawMemory(valueByte, address, offset);
        }
    }
}
