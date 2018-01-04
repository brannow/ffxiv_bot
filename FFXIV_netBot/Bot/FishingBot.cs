using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using FFXIV_netBot.Module;
using System.Windows.Forms;

namespace FFXIV_netBot.Bot
{
    public enum FishingStatus : int
    {
        FishingStatusNone = 0,
        FishingStatusFishing = 1,
        FishingStatusEndFishingProcess = 2,
        FishingStatusCancel = 3,
        FishingStatusIdle = 4,
        FishingStatusBiteing = 5,
        FishingStatusCatching = 6,
    }

    public class FishingBot : CoreBot
    {
        private System.Windows.Forms.Timer timer;
        private int _lastFishingStatus;

        private int _strike = 0;

        public FishingBot(FishingConfig config, List<Waypoint> waypointList)
        {
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = SettingsSingleton.Instance.timings.movementUpdateTick;
            this.timer.Tick += new System.EventHandler(this.tickFishing);

            this.fishingConfig = config;
            this.waypointList = waypointList;
            this.gkeys = this.fishingConfig.movement;
        }

        // DELEGATE

        protected override void fullLoaded()
        {

        }

        // current reached waypoint
        protected override void waypointReached(int index)
        {
            Console.WriteLine("waypointReached {0}", index);
            Waypoint currWP = this.waypointList[index];
            if(currWP.type == WaypointType.Fishing)
            {
                this.movement.pause();
                this.movement.lookAt(currWP);
                this.startFishing();
            }
        }

        // next (target) waypoint
        protected override void startMovingToWaypoint(int index)
        {
            Console.WriteLine("startMovingToWaypoint {0}", index);
        }

        // target waypoint index
        protected override void movingStopped(int index)
        {
            Console.WriteLine("movingStopped {0}", index);
        }

        // moving waypoint calltick with target index and Distance
        protected override void movingToWaypoint(int index, Double distance) 
        {
           // Console.WriteLine("movingToWaypoint {0} {1}", index, distance);
        }

        protected override void singleMovementFinished()
        {

        }


        // DATASOURCE

        protected override Int32 numberOfWaypoints()
        {
            if (this.waypointList != null)
                return this.waypointList.Count;
            return 0;
        }

        protected override Waypoint waypointAtIndex(int index)
        {
            if (this.waypointList != null && this.waypointList.Count > 0)
                return this.waypointList[index];
            return new Waypoint();
        }

        private void startFishing()
        {
            Thread.Sleep(100);
            this.keyboard.pressCustomKey((Keys)this.fishingConfig.movement.forward, 273);
            Thread.Sleep(1000);
            bool isAvailable = this.memory.fishingAvailable();
            if(isAvailable)
            {
                this.keyboard.pressCustomKey((Keys)this.fishingConfig.fishing.startFishing);
                Thread.Sleep(1000);
                this._lastFishingStatus = 0;
                this._strike = 0;
                this.timer.Start();
            } 
            else
            {
                this.movement.resume();
            }
        }

        private void tickFishing(object sender, EventArgs e)
        {
            this.timer.Stop();
            // break if bot paused
            if (!this.isRunning())
                return;

            int status = this.memory.fishingStatus();
            FishingStatus fs = (FishingStatus)status;

            if(status != this._lastFishingStatus)
            {
                this._lastFishingStatus = status;
                this._strike = 0;
                if (fs == FishingStatus.FishingStatusIdle)
                {
                    Thread.Sleep(1000);
                    this.keyboard.pressCustomKey((Keys)this.fishingConfig.fishing.startFishing);
                    Thread.Sleep(1000);
                }
                else if (fs == FishingStatus.FishingStatusBiteing)
                {
                    Thread.Sleep(this.fishingConfig.biteDelay);
                    this.keyboard.pressCustomKey((Keys)this.fishingConfig.fishing.catchFish);
                }
            }
            else if (fs == FishingStatus.FishingStatusIdle)
            {
                if(this._strike > 3)
                {
                    this.movement.resume();
                    return;
                }
                this._strike++;
                this.keyboard.pressCustomKey((Keys)this.fishingConfig.fishing.startFishing);
                Thread.Sleep(2000);
            }

            if (fs == FishingStatus.FishingStatusNone)
            {
                this.movement.resume();
                return;
            }

            this.timer.Start();
        }
    }
}
