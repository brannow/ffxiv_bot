using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_netBot.Module
{
    public struct Timings
    {
        public int activeMainViewUpdate; // Form1: 89
        public int inactiveMainViewUpdate; // Form1: 124
        public int activeWaypointViewUpdate; // WaypointForm: 230
        public int inactiveWaypointViewUpdate; // WaypointForm: 243
        public int randomKeyPressMin; // coreKeyboard: 66
        public int randomKeyPressMax; // coreKeyboard: 66
        public int movementUpdateTick; // movement: 11
        public int movementRotationSleepUntilMemoryHack; // movement: 165
        public double minMovementDistanceToNextWaypoint; //  movement: 13
        public double minRadianDifferanceToMove; //  movement: 14
        public double minRadianDifferanceToUseKeys; //  movement: 15
        public double minRadianDifferanceToUseMemoryHack; //  movement: 16
    }

    public class RestoreTimingDefault
    {
        public static Timings defaultTimings()
        {
            Timings defaultTimings = new Timings();
            defaultTimings.activeMainViewUpdate = 800;
            defaultTimings.inactiveMainViewUpdate = 2000;
            defaultTimings.activeWaypointViewUpdate = 1000;
            defaultTimings.inactiveWaypointViewUpdate = 2000;
            defaultTimings.randomKeyPressMin = 20;
            defaultTimings.randomKeyPressMax = 80;
            defaultTimings.movementUpdateTick = 100;
            defaultTimings.movementRotationSleepUntilMemoryHack = 50;
            defaultTimings.minMovementDistanceToNextWaypoint = 1.6;
            defaultTimings.minRadianDifferanceToMove = 1.6;
            defaultTimings.minRadianDifferanceToUseKeys = 0.23;
            defaultTimings.minRadianDifferanceToUseMemoryHack = 0.0005;

            return defaultTimings;
        }
    }
}
