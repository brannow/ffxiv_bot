using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_netBot
{
    class FFXIVMemoryOffset
    {
        public struct BaseAddresses
        {
            public static uint playerStatusAddress = 0xF8BBE0;
            public static uint playerPositionAdress = 0xF8BA14;
            public static uint playerFishingAddress = 0x109A6C4;
            public static uint playerClassAddress = 0x10B8A08;
            public static uint playerInfoAddress = 0xF89ECC;
            public static uint entityListAddress = 0xF89EC8;
            public static uint targetAddress = 0xF87F80;
        }

        public struct PlayerInfo
        {
            public static uint baseAddress = BaseAddresses.playerInfoAddress;
            public static uint name = 0x30;
            public static uint ID = 0x74;
            public static uint targetUseable = 0x10e4; // 2 if useable 
        }

        public struct EntityList
        {
            public static uint baseAddress = BaseAddresses.entityListAddress;
            public static uint listStart = BaseAddresses.entityListAddress + 0x4;
            public static uint listOffset = 0x4;
        }

        public struct EntityItem
        {
            public static uint id = 0x74;
            public static uint hidden = 0x11C; // 128 == hidden
            public static uint name = 0x30;
            public static uint typeId = 0x80;
            public static uint uniqueId = 0x88;
            public static uint interacrtionId = 0x170;
            public static uint rotation = 0xB0;
            public static uint x = 0xA0;
            public static uint y = 0xA8;
            public static uint z = 0xA4;
        }

        public struct FishingAddress
        {
            public static uint baseAddress = BaseAddresses.playerFishingAddress;
            public static uint offset = 0x54;
            public static uint status = 0xFC;
            public static uint available = 0x108;
        }

        public struct Player
        {
            public static uint baseAddress = BaseAddresses.playerStatusAddress;
            public static uint offset1 = 0x14;
            public static uint offset2 = 0x1B4;
            public static uint offset3 = 0x8;
        }

        public struct HP
        {
            public static uint offset1 = 0x188;
            public static uint current = 0xA0;
            public static uint max = 0xE0;
        }

        public struct MP
        {
            public static uint offset1 = 0x18C;
            public static uint current = 0xA0;
            public static uint max = 0xE0;
        }

        public struct TP
        {
            public static uint offset1 = 0x190;
            public static uint current = 0xA0;
            public static uint max = 0xE0;
        }

        public struct CP
        {
            public static uint offset1 = 0x194;
            public static uint current = 0xA0;
            public static uint max = 0xE0;
        }

        public struct GP
        {
            public static uint offset1 = 0x198;
            public static uint current = 0xA0;
            public static uint max = 0xE0;
        }

        public struct Position
        {
            public static uint baseAddress = BaseAddresses.playerPositionAdress;
            public static uint rotation = 0xB0;
            public static uint x = 0xA0;
            public static uint y = 0xA8;
            public static uint z = 0xA4;
        }
    }
}
