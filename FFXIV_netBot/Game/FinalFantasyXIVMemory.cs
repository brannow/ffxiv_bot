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
        public FinalFantasyXIVMemory() 
        {
            this.initConnection();
        }

        public void initConnection()
        {
            this.attachProcess("ffxiv");
        }

        public Int32 playerID()
        {
            uint ptr1 = this.readPointer(this.processAddress(), FFXIVMemoryOffset.PlayerInfo.baseAddress);
            return this.readIntValue(ptr1, FFXIVMemoryOffset.PlayerInfo.ID);
        }

        public String playerName()
        {
            uint ptr1 = this.readPointer(this.processAddress(), FFXIVMemoryOffset.PlayerInfo.baseAddress);
            return this.readStringValue(64, ptr1, FFXIVMemoryOffset.PlayerInfo.name);
        }

        public Boolean fishingAvailable()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.FishingAddress.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.FishingAddress.offset);
            return this.readBoolValue(ptr1, FFXIVMemoryOffset.FishingAddress.available);
        }

        public Int32 fishingStatus()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.FishingAddress.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.FishingAddress.offset);
            return this.readIntValue(ptr1, FFXIVMemoryOffset.FishingAddress.status);
        }

        public Int32 playerHP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.HP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.HP.current);
        }

        public Int32 playerMaxHP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.HP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.HP.max);
        }

        public Int32 playerMP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.MP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.MP.current);
        }

        public Int32 playerMaxMP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.MP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.MP.max);
        }

        public Int32 playerTP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.TP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.TP.current);
        }

        public Int32 playerMaxTP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.TP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.TP.max);
        }

        public Int32 playerCP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.CP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.CP.current);
        }

        public Int32 playerMaxCP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.CP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.CP.max);
        }

        public Int32 playerGP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.GP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.GP.current);
        }

        public Int32 playerMaxGP()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Player.baseAddress);
            uint ptr1 = this.readPointer(baseAddress, FFXIVMemoryOffset.Player.offset1);
            uint ptr2 = this.readPointer(ptr1, FFXIVMemoryOffset.Player.offset2);
            uint ptr3 = this.readPointer(ptr2, FFXIVMemoryOffset.Player.offset3);
            uint ptr4 = this.readPointer(ptr3, FFXIVMemoryOffset.GP.offset1);
            return this.readIntValue(ptr4, FFXIVMemoryOffset.GP.max);
        }

        public PlayerPosition position()
        {
            PlayerPosition pos = new PlayerPosition();
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            pos.r = this.readFloatValue(baseAddress, FFXIVMemoryOffset.Position.rotation);
            pos.x = this.readFloatValue(baseAddress, FFXIVMemoryOffset.Position.x);
            pos.y = this.readFloatValue(baseAddress, FFXIVMemoryOffset.Position.y);
            pos.z = this.readFloatValue(baseAddress, FFXIVMemoryOffset.Position.z);
            return pos;
        }

        public Single rotation()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            return this.readFloatValue(baseAddress, FFXIVMemoryOffset.Position.rotation);
        }

        public void setRotation(Single rotation)
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            this.writeFloatValue(rotation, baseAddress, FFXIVMemoryOffset.Position.rotation);
        }

        public Single positionX()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            return this.readFloatValue(baseAddress, FFXIVMemoryOffset.Position.x);
        }

        public Single positionY()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            return this.readFloatValue(baseAddress, FFXIVMemoryOffset.Position.y);
        }

        public Single positionZ()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.Position.baseAddress);
            return this.readFloatValue(baseAddress, FFXIVMemoryOffset.Position.z);
        }

        public Int32 entityCount()
        {
            Int32 count = this.readIntValue(this.processAddress(), FFXIVMemoryOffset.EntityList.baseAddress);
            return count;
        }

        public uint entityPointerAtIndex(uint index)
        {
            uint offset = FFXIVMemoryOffset.EntityList.listStart + (FFXIVMemoryOffset.EntityList.listOffset * index);
            uint pointer = this.readPointer(this.processAddress(), offset);
            return pointer;
        }

        public String entityName(uint baseAddress)
        {
            return this.readStringValue(64, baseAddress, FFXIVMemoryOffset.EntityItem.name);
        }

        public PlayerPosition entityposition(uint baseAddress)
        {
            PlayerPosition pos = new PlayerPosition();
            pos.r = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.rotation);
            pos.x = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.x);
            pos.y = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.y);
            pos.z = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.z);
            return pos;
        }

        public Int32 entityVisibleStatus(uint baseAddress)
        {
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.hidden);
        }

        public Int32 entityTypeId(uint baseAddress)
        {
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.typeId);
        }

        public Int32 entityUniqueId(uint baseAddress)
        {
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.uniqueId);
        }

        public Int32 entityInteractionId(uint baseAddress)
        {
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.interacrtionId);
        }


        public String targetName()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readStringValue(64, baseAddress, FFXIVMemoryOffset.EntityItem.name);
        }

        public PlayerPosition targetposition()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            PlayerPosition pos = new PlayerPosition();
            pos.r = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.rotation);
            pos.x = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.x);
            pos.y = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.y);
            pos.z = this.readFloatValue(baseAddress, FFXIVMemoryOffset.EntityItem.z);
            return pos;
        }

        public Int32 targetVisibleStatus()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.hidden);
        }

        public Int32 targetTypeId()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.typeId);
        }

        public Int32 targetUniqueId()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.uniqueId);
        }

        public Int32 targetInteractionId()
        {
            uint baseAddress = this.readPointer(this.processAddress(), FFXIVMemoryOffset.BaseAddresses.targetAddress);
            return this.readIntValue(baseAddress, FFXIVMemoryOffset.EntityItem.interacrtionId);
        }
    }
}