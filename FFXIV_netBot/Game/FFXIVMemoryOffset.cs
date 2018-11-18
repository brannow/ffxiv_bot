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
            public static int playerInfoAddress = 0x18AB9C0;  // UPDATED
            public static int playerStatusAddress = 0x18AB9C0; // UPDATED
            public static int targetAddress = 0xF87F80; // 018A7780 018A77B0 018A77B8

            public static int entityListAddress = 0x18A8BB8;


            public static int playerFishingAddress = 0x109A6C4;
            
            
        }

        public struct PlayerInfo // UPDATED
        {
            public static int baseAddress = BaseAddresses.playerInfoAddress;
            public static int name = 0x30;
            public static int ID = 0x74;
            //public static uint targetUseable = 0x10e4; // 2 if useable 
        }

        public struct Player
        {
            public static int baseAddress = BaseAddresses.playerStatusAddress;
            public static int offset1 = 0x570;
            public static int offset2 = 0x10;
            public static int offset3 = 0x370;
        }

        public struct HP // Health points
        {
            public static int offset1 = 0x6F8;
            public static int current = 0xEE8;
            public static int max = 0xEEC;
        }

        public struct MP // magic points
        {
            public static int offset1 = 0x6F8;
            public static int current = 0xEF0;
            public static int max = 0xEF4;
        }

        public struct TP // target points
        {
            public static int offset1 = 0x6F8;
            public static int current = 0xEF8;
            public static int max = 0xEF6;
        }

        public struct CP // crafting points
        {
            public static int offset1 = 0x6F8;
            public static int current = 0xEFE;
            public static int max = 0xF00;
        }

        public struct GP // Gathering Points
        {
            public static int offset1 = 0x6F8;
            public static int current = 0xEFA;
            public static int max = 0xEFC;
        }

        public struct Position  // UPDATED
        {
            public static int baseAddress = BaseAddresses.playerInfoAddress;
            public static int rotation = 0xB0;
            public static int x = 0xA0;
            public static int y = 0xA8;
            public static int z = 0xA4;
        }


        public struct EntityList
        {
            public static int baseAddress = BaseAddresses.entityListAddress;
            public static int listStart = BaseAddresses.entityListAddress + 0x4;
            public static int listOffset = 0x8;
        }

        public struct EntityItem
        {
            public static int id = 0x74;
            public static int hidden = 0x104; // 128 == hidden
            public static int name = 0x30;
            public static int typeId = 0x80;
            public static int uniqueId = 0x88;
            public static int interacrtionId = 0x140;
            public static int rotation = 0xB0;
            public static int x = 0xA0;
            public static int y = 0xA8;
            public static int z = 0xA4;
        }

        public struct FishingAddress
        {
            public static int baseAddress = BaseAddresses.playerFishingAddress;
            public static int offset = 0x54;
            public static int status = 0xFC;
            public static int available = 0x108;
        }
    }
}
