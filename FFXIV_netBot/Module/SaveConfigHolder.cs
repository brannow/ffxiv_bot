using System;
using System.Runtime.InteropServices;

namespace FFXIV_netBot.Module
{
    public enum ConfigType: byte
    {
        None        = 0,
        Combat      = 1 << 0,
        Fishing     = 1 << 1,
        Gathering   = 1 << 2
    }

    public class SaveConfigHolder
    {
        // Byte type 0x0 
        // combat = 1
        // fishing = 2
        // gathering = 3
        public FishingConfig fishingConfig;
        public CombatConfig combatConfig;
        public GatheringConfig gatheringConfig;
        public ConfigType type = ConfigType.None;

        public String fileName = "";

        public void parseBytes(byte[] arr, bool withType)
        {
            byte[] rawbytes = arr;
            if (withType)
            {
                this.type = this.configTypeFromBytes(arr);
                rawbytes = this.byteWithoutTypeByteFlag(arr);
            }

            if(this.type != ConfigType.None)
            {
                if (this.type == ConfigType.Fishing)
                {
                    this.fishingConfig = this.fishingConfigFromBytes(rawbytes);
                }
                else if (this.type == ConfigType.Combat)
                {
                    this.combatConfig = this.combatConfigFromBytes(rawbytes);
                }
                else if (this.type == ConfigType.Gathering)
                {
                    this.gatheringConfig = this.gatheringConfigFromBytes(rawbytes);
                }
            }
        }

        public byte[] byteWithoutTypeByteFlag(byte[] arr) 
        {
            byte[] bytes;
            int enumSize = Marshal.SizeOf(Enum.GetUnderlyingType(typeof(ConfigType)));
            int byteLenght = arr.Length - enumSize;
            if (byteLenght > 0)
            {
                bytes = new byte[byteLenght];
                System.Buffer.BlockCopy(arr, enumSize, bytes, 0, byteLenght);
            } 
            else
            {
                bytes = arr;
            }
            return bytes;
        }

        public ConfigType configTypeFromBytes(byte[] arr)
        {
            int enumSize = Marshal.SizeOf(Enum.GetUnderlyingType(typeof(ConfigType)));
            byte[] typeByte = new byte[enumSize];
            System.Buffer.BlockCopy(arr, 0, typeByte, 0, typeByte.Length);
            if (typeByte.Length > 0)
            {
                return (ConfigType)typeByte[0];
            }
            return ConfigType.None;
        }

        public FishingConfig fishingConfigFromBytes(byte[] arr)
        {
            FishingConfig str = new FishingConfig();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (FishingConfig)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        public CombatConfig combatConfigFromBytes(byte[] arr)
        {
            CombatConfig str = new CombatConfig();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (CombatConfig)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        public GatheringConfig gatheringConfigFromBytes(byte[] arr)
        {
            GatheringConfig str = new GatheringConfig();

            int size = Marshal.SizeOf(str);
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arr, 0, ptr, size);

            str = (GatheringConfig)Marshal.PtrToStructure(ptr, str.GetType());
            Marshal.FreeHGlobal(ptr);

            return str;
        }

        public byte[] currentConfigToByte()
        {
            byte[] currByte = null, finalByte = null;
            if (this.type > 0)
            {
                if (this.type == ConfigType.Combat)
                {
                    currByte = this.combatConfigToByte();
                }
                if (this.type == ConfigType.Fishing)
                {
                    currByte = this.fishingConfigToByte();
                }
                if (this.type == ConfigType.Gathering)
                {
                    currByte = this.gatheringConfigToByte();
                }
            }

            byte[] enumByte = {(byte)this.type};
            if (enumByte.Length > 0 && currByte.Length > 0)
            {
                finalByte = new byte[enumByte.Length + currByte.Length];
                System.Buffer.BlockCopy(enumByte, 0, finalByte, 0, enumByte.Length);
                System.Buffer.BlockCopy(currByte, 0, finalByte, enumByte.Length, currByte.Length);
            }
            return finalByte;
        }

        public byte[] fishingConfigToByte()
        {
            int size = Marshal.SizeOf(this.fishingConfig);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(this.fishingConfig, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        public byte[] combatConfigToByte()
        {
            int size = Marshal.SizeOf(this.combatConfig);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(this.combatConfig, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        public byte[] gatheringConfigToByte()
        {
            int size = Marshal.SizeOf(this.gatheringConfig);
            byte[] arr = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(this.gatheringConfig, ptr, true);
            Marshal.Copy(ptr, arr, 0, size);
            Marshal.FreeHGlobal(ptr);

            return arr;
        }
    }
}
