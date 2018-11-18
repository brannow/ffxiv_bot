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
    public class GatheringBot : CoreBot
    {
        private System.Windows.Forms.Timer timer;
        private EntityList entityList;

        private EntityItem targetItem;
        private int _strike;
        private bool _itemFound;
        private int ignoredIndex = -1;
        private int currentIndex;

        public GatheringBot(GatheringConfig config, List<Waypoint> waypointList)
        {
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = SettingsSingleton.Instance.timings.movementUpdateTick;
            this.timer.Tick += new System.EventHandler(this.tickGather);

            this.gatheringConfig = config;
            this.waypointList = waypointList;
            this.gkeys = this.gatheringConfig.movement;
        }

        // DELEGATE

        protected override void fullLoaded()
        {
            this.entityList = new EntityList(this.memory);
        }

        // current reached waypoint
        protected override void waypointReached(int index)
        {
            Console.WriteLine("waypointReached {0}", index);

            if (index == this.ignoredIndex)
            {
                this.ignoredIndex = -1;
                return;
            }

            
            Waypoint currWP = this.waypointList[index];
            if (currWP.type == WaypointType.Gathering)
            {
                this.currentIndex = index;
                this.movement.pause();
                EntityItem item = this.findEntityItemNode(currWP);
                if(item != null)
                    this.startGathering(item);
                else
                    this.movement.resume();
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
            this._strike = 0;
            this._itemFound = false;
            this.keyboard.pressActionKey();
            this.timer.Start();
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

        private bool matchedInteractionItem(int interactionId)
        {
            if (this.gatheringConfig.matureTree == 1 && interactionId == (int)GatheringId.MatureTree)
                return true;
            if (this.gatheringConfig.lushVegetationPatch == 1 && interactionId == (int)GatheringId.LushVegetationPatch)
                return true;
            if (this.gatheringConfig.mineralDeposit == 1 && interactionId == (int)GatheringId.MineralDeposit)
                return true;
            if (this.gatheringConfig.rockyOutcrop == 1 && interactionId == (int)GatheringId.RockyOutcrop)
                return true;
            return false;
        }


        private bool matchedInteractionItem(EntityItem item)
        {
            if (this.gatheringConfig.matureTree == 1 && item.interacrtionId == (int)GatheringId.MatureTree)
                return true;
            if (this.gatheringConfig.lushVegetationPatch == 1 && item.interacrtionId == (int)GatheringId.LushVegetationPatch)
                return true;
            if (this.gatheringConfig.mineralDeposit == 1 && item.interacrtionId == (int)GatheringId.MineralDeposit)
                return true;
            if (this.gatheringConfig.rockyOutcrop == 1 && item.interacrtionId == (int)GatheringId.RockyOutcrop)
                return true;
            return false;
        }

        private EntityItem findEntityItemNode(Waypoint wp)
        {
            this.entityList.update();

            for (int i = 1; i < this.entityList.Count; ++i )
            {
                EntityItem item = this.entityList.itemAtIndex(i);
                if (item.distance < wp.range && this.matchedInteractionItem(item) && item.visibleStatus == 0)
                {
                    return item;
                }
            }
            return null;
        }

        private void startGathering(EntityItem item)
        {
            this.targetItem = item;
            this.movement.singleMoveToPosition(item.position);
        }

        private void tickGather(object sender, EventArgs e)
        {
            this.timer.Stop();

            // break if bot paused
            if (!this.isRunning())
                return;

            Random random = new Random();
            int interval = random.Next(400, 600);
            Thread.Sleep(interval);
            this.keyboard.pressActionKey();

            if (this.memory.targetUniqueId() != this.targetItem.uniqueId)
            {
                if(this._itemFound || !matchedInteractionItem(this.memory.targetInteractionId()) || this.memory.targetVisibleStatus() != 0)
                {
                    this.keyboard.pressESCKey();
                    this.ignoredIndex = this.currentIndex;
                    this.movement.resume();
                    return;
                }

                //this.keyboard.pressESCKey();
                Thread.Sleep(1000);
                this.keyboard.pressActionKey();
                Thread.Sleep(1000);

                this._strike++;   
            }
            else
            {
                this._itemFound = true;
            }

            this.timer.Start();
        }
    }
}
