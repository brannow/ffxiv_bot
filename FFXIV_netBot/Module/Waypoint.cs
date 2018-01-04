using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_netBot.Module
{
    public enum WaypointType : uint {
        Default = 1, 
        Fishing = 2, 
        Gathering = 3
    };

    public struct Waypoint
    {
        public uint id;
        public PlayerPosition position;
        public WaypointType type;
        public Single range;
    }
}
