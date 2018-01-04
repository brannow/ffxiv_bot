using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FFXIV_netBot.Module;

namespace FFXIV_netBot.Bot
{
    // delegate
    public delegate void WaypointReached(Int32 index);
    public delegate void StartMovingToWaypoint(Int32 index);
    public delegate void MovingStopped(Int32 index);
    public delegate void MovingToWaypoint(Int32 index, Double distance);
    public delegate void SingleMovementFinished();

    // datasource
    public delegate Int32 NumberOfWaypoints();
    public delegate Waypoint WaypointAtIndex(Int32 index);

    public abstract class CoreBot
    {
        protected FishingConfig fishingConfig;
        protected CombatConfig combatConfig;
        protected GatheringConfig gatheringConfig;

        protected List<Waypoint> waypointList;

        protected Boolean _isRunning = false;

        protected Movement movement;
        protected FinalFantasyXIVMemory memory;
        protected FinalFantasyKeyboard keyboard;

        protected GeneralKeys gkeys;

        public void setCoreObjects(FinalFantasyXIVMemory mem)
        {
            this.memory = mem;
            this.keyboard = new FinalFantasyKeyboard(this.gkeys);

            // configure movement
            this.movement = new Movement(this.memory, this.keyboard);
            this.movement.setDelegates(this.waypointReached, this.startMovingToWaypoint, this.movingStopped, this.movingToWaypoint, this.singleMovementFinished);
            this.movement.setDataSource(this.numberOfWaypoints, this.waypointAtIndex);

            this.fullLoaded();
        }

        protected abstract void fullLoaded();

        public void run()
        {
            if (!this.isRunning())
            {
                this._isRunning = true;
                this.movement.startMoving();
            }
            else if (this.movement.isPuased())
            {
                this._isRunning = true;
                this.movement.resume();
            }
        }

        public void stop()
        {
            if (this.isRunning())
            {
                this.movement.cancelMoving();
                this._isRunning = false;
            }
        }

        public void pause()
        {
            if (this.isRunning())
            {
                this.movement.pause();
                this._isRunning = false;
            }
        }

        public bool isRunning()
        {
            return this._isRunning;
        }

        /**
         * 
         *
         *    MOVEMENT
         * 
         * 
         **/

        // DELEGATE

        protected abstract void waypointReached(int index); // current reached waypoint
        protected abstract void startMovingToWaypoint(int index); // next (target) waypoint
        protected abstract void movingStopped(int index); // target waypoint index
        protected abstract void movingToWaypoint(int index, Double distance); // moving waypoint calltick with target index and Distance
        protected abstract void singleMovementFinished(); // moving waypoint calltick with target index and Distance
        // DATASOURCE
        protected abstract Waypoint waypointAtIndex(int index);
        protected abstract Int32 numberOfWaypoints();
    }
}
