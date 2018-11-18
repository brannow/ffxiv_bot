using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_netBot
{
    public struct PlayerPosition
    {
        public Single x;
        public Single y;
        public Single z;
        public Single r;

        public Double distanceBetweenPosition(PlayerPosition p)
        {
            return Math.Sqrt((p.x - this.x) * (p.x - this.x) + (p.y - this.y) * (p.y - this.y));
        }

        public Double angle()
        {
            if (this.y == 0.0)
            {
                if (this.x > 0.0)
                {
                    return 0.0;
                }
                return Math.PI;
            }

            double alpha = Math.Acos(this.x / Math.Sqrt(Math.Pow(this.x, 2) + Math.Pow(this.y, 2)));
            alpha = alpha * this.y / Math.Abs(this.y);
            return alpha;
        }

        public Double angleBetweenPosition(PlayerPosition p)
        {
            PlayerPosition d = new PlayerPosition();
            d.x = p.x - this.x;
            d.y = p.y - this.y;
            d.z = p.z - this.z;

            double alpha = d.angle();
            double beta = this.r - MathEx.PI_2;

            double gamma = alpha + beta;
            double result = MathEx.normalizeAngle(gamma);
            return result; 
        }
    }


    public class FinalFantasyXIVMemory : CoreMemory
    {
        public const string PROCESSNAME = "ffxiv_dx11";

        public FinalFantasyXIVMemory() 
        {
            this.initConnection();
        }

        public void initConnection()
        {
            this.attachProcess(FinalFantasyXIVMemory.PROCESSNAME);
        }

        public Int32 playerID()
        {
            IntPtr ptr1 = this.readPointer(this.processAddress(), FFXIVMemoryOffset.PlayerInfo.baseAddress);
            return this.readIntValue((IntPtr)ptr1, FFXIVMemoryOffset.PlayerInfo.ID);
        }

        public String playerName()
        {
            IntPtr ptr1 = this.readPointer(this.processAddress(), FFXIVMemoryOffset.PlayerInfo.baseAddress);
            return this.readStringValue(64, (IntPtr)ptr1, FFXIVMemoryOffset.PlayerInfo.name);
        }

        public Boolean fishingAvailable()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.FishingAddress.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.FishingAddress.offset);
            return this.readBoolValue((IntPtr)ptr1, FFXIVMemoryOffset.FishingAddress.available);
        }

        public Int32 fishingStatus()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.FishingAddress.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.FishingAddress.offset);
            return this.readInt2Value((IntPtr)ptr1, FFXIVMemoryOffset.FishingAddress.status);
        }

        public Int32 playerHP()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.Player.offset1);
            IntPtr ptr2 = this.readPointer((IntPtr)ptr1, FFXIVMemoryOffset.Player.offset2);
            IntPtr ptr3 = this.readPointer((IntPtr)ptr2, FFXIVMemoryOffset.Player.offset3);
            IntPtr ptr4 = this.readPointer((IntPtr)ptr3, FFXIVMemoryOffset.HP.offset1);
            return this.readIntValue((IntPtr)ptr4, FFXIVMemoryOffset.HP.current);
        }

        public Int32 playerMaxHP()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.Player.offset1);
            IntPtr ptr2 = this.readPointer((IntPtr)ptr1, FFXIVMemoryOffset.Player.offset2);
            IntPtr ptr3 = this.readPointer((IntPtr)ptr2, FFXIVMemoryOffset.Player.offset3);
            IntPtr ptr4 = this.readPointer((IntPtr)ptr3, FFXIVMemoryOffset.HP.offset1);
            return this.readInt2Value((IntPtr)ptr4, FFXIVMemoryOffset.HP.max);
        }

        public Int32 playerMP()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.Player.offset1);
            IntPtr ptr2 = this.readPointer((IntPtr)ptr1, FFXIVMemoryOffset.Player.offset2);
            IntPtr ptr3 = this.readPointer((IntPtr)ptr2, FFXIVMemoryOffset.Player.offset3);
            IntPtr ptr4 = this.readPointer((IntPtr)ptr3, FFXIVMemoryOffset.MP.offset1);
            return this.readInt2Value((IntPtr)ptr4, FFXIVMemoryOffset.MP.current);
        }

        public Int32 playerMaxMP()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.Player.offset1);
            IntPtr ptr2 = this.readPointer((IntPtr)ptr1, FFXIVMemoryOffset.Player.offset2);
            IntPtr ptr3 = this.readPointer((IntPtr)ptr2, FFXIVMemoryOffset.Player.offset3);
            IntPtr ptr4 = this.readPointer((IntPtr)ptr3, FFXIVMemoryOffset.MP.offset1);
            return this.readInt2Value((IntPtr)ptr4, FFXIVMemoryOffset.MP.max);
        }

        public Int32 playerTP()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.Player.offset1);
            IntPtr ptr2 = this.readPointer((IntPtr)ptr1, FFXIVMemoryOffset.Player.offset2);
            IntPtr ptr3 = this.readPointer((IntPtr)ptr2, FFXIVMemoryOffset.Player.offset3);
            IntPtr ptr4 = this.readPointer((IntPtr)ptr3, FFXIVMemoryOffset.TP.offset1);
            return this.readInt2Value((IntPtr)ptr4, FFXIVMemoryOffset.TP.current);
        }

        public Int32 playerMaxTP()
        {
            return 1000;
        }

        public Int32 playerCP()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.Player.offset1);
            IntPtr ptr2 = this.readPointer((IntPtr)ptr1, FFXIVMemoryOffset.Player.offset2);
            IntPtr ptr3 = this.readPointer((IntPtr)ptr2, FFXIVMemoryOffset.Player.offset3);
            IntPtr ptr4 = this.readPointer((IntPtr)ptr3, FFXIVMemoryOffset.CP.offset1);
            return this.readInt2Value((IntPtr)ptr4, FFXIVMemoryOffset.CP.current);
        }

        public Int32 playerMaxCP()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.Player.offset1);
            IntPtr ptr2 = this.readPointer((IntPtr)ptr1, FFXIVMemoryOffset.Player.offset2);
            IntPtr ptr3 = this.readPointer((IntPtr)ptr2, FFXIVMemoryOffset.Player.offset3);
            IntPtr ptr4 = this.readPointer((IntPtr)ptr3, FFXIVMemoryOffset.CP.offset1);
            return this.readInt2Value((IntPtr)ptr4, FFXIVMemoryOffset.CP.max);
        }

        public Int32 playerGP()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.Player.offset1);
            IntPtr ptr2 = this.readPointer((IntPtr)ptr1, FFXIVMemoryOffset.Player.offset2);
            IntPtr ptr3 = this.readPointer((IntPtr)ptr2, FFXIVMemoryOffset.Player.offset3);
            IntPtr ptr4 = this.readPointer((IntPtr)ptr3, FFXIVMemoryOffset.GP.offset1);
            return this.readInt2Value((IntPtr)ptr4, FFXIVMemoryOffset.GP.current);
        }

        public Int32 playerMaxGP()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            IntPtr ptr1 = this.readPointer((IntPtr)baseAddress, FFXIVMemoryOffset.Player.offset1);
            IntPtr ptr2 = this.readPointer((IntPtr)ptr1, FFXIVMemoryOffset.Player.offset2);
            IntPtr ptr3 = this.readPointer((IntPtr)ptr2, FFXIVMemoryOffset.Player.offset3);
            IntPtr ptr4 = this.readPointer((IntPtr)ptr3, FFXIVMemoryOffset.GP.offset1);
            return this.readInt2Value((IntPtr)ptr4, FFXIVMemoryOffset.GP.max);
        }

        public PlayerPosition position()
        {
            PlayerPosition pos = new PlayerPosition();
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            pos.r = this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.Position.rotation);
            pos.x = this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.Position.x);
            pos.y = this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.Position.y);
            pos.z = this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.Position.z);
            return pos;
        }

        public Single rotation()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            return this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.Position.rotation);
        }

        public void setRotation(Single rotation)
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            this.writeFloatValue(rotation, (IntPtr)baseAddress, FFXIVMemoryOffset.Position.rotation);
        }

        public Single positionX()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            return this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.Position.x);
        }

        public Single positionY()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            return this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.Position.y);
        }

        public Single positionZ()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            return this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.Position.z);
        }

        public Int32 entityCount()
        {
            Int32 count = this.readInt2Value(this.processAddress(), FFXIVMemoryOffset.EntityList.baseAddress);
            return count;
        }

        public IntPtr entityPointerAtIndex(int index)
        {
            int offset = FFXIVMemoryOffset.BaseAddresses.entityListAddress + (FFXIVMemoryOffset.EntityList.listOffset * (index + 1));
            return this.readPointer(this.processAddress(), offset);
        }

        public String entityName(IntPtr baseAddress)
        {
            return this.readStringValue(64, baseAddress, FFXIVMemoryOffset.EntityItem.name);
        }

        public PlayerPosition entityposition(IntPtr baseAddress)
        {
            PlayerPosition pos = new PlayerPosition();
            pos.r = this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.EntityItem.rotation);
            pos.x = this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.EntityItem.x);
            pos.y = this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.EntityItem.y);
            pos.z = this.readFloatValue((IntPtr)baseAddress, FFXIVMemoryOffset.EntityItem.z);
            return pos;
        }

        public Int32 entityVisibleStatus(IntPtr baseAddress)
        {
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.hidden);
        }

        public Int32 entityTypeId(IntPtr baseAddress)
        {
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.typeId);
        }

        public Int32 entityUniqueId(IntPtr baseAddress)
        {
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.uniqueId);
        }

        public Int32 entityInteractionId(IntPtr baseAddress)
        {
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.interacrtionId);
        }


        public String targetName()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readStringValue(64, baseAddress, FFXIVMemoryOffset.EntityItem.name);
        }

        public PlayerPosition targetposition()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            PlayerPosition pos = new PlayerPosition();
            pos.r = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.rotation);
            pos.x = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.x);
            pos.y = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.y);
            pos.z = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.z);
            return pos;
        }

        public Int32 targetVisibleStatus()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.hidden);
        }

        public Int32 targetTypeId()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.typeId);
        }

        public Int32 targetUniqueId()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.uniqueId);
        }

        public Int32 targetInteractionId()
        {
            IntPtr baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.interacrtionId);
        }
    }
}