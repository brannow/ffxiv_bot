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

    public enum GatheringId : int
    {
        MatureTree = 60433,
        LushVegetationPatch = 60432,
        MineralDeposit = 60438,
        RockyOutcrop = 60437,
    }

    public class CombatBot : CoreBot
    {
        private System.Windows.Forms.Timer timer;
        private EntityList entityList;

        private EntityItem targetItem;
        private int _strike;
        private bool _itemFound;
        private int lastAttackedMob = 0;

        public CombatBot(CombatConfig config ,List<Waypoint> waypointList)
        {
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = 400;
            this.timer.Tick += new System.EventHandler(this.tickCombat);

            this.combatConfig = config;
            this.waypointList = waypointList;
            this.gkeys = this.combatConfig.movement;
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
            EntityItem item = this.findEntityItemNode();
            if(item != null)
            {
                this.movement.pause();
                this.startCombat(item);
            }
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


        private bool matchedInteractionItem(EntityItem item)
        {
            if (item.uniqueId == this.lastAttackedMob)
                return false;

            if (item.typeId == 132 || item.typeId == 731)
                return true;
            return false;
        }

        private EntityItem findEntityItemNode()
        {
            this.entityList.update();

            for (int i = 1; i < this.entityList.Count; ++i )
            {
                EntityItem item = this.entityList.itemAtIndex(i);
                if (item.distance < 20 && this.matchedInteractionItem(item) && item.visibleStatus == 0)
                {
                    return item;
                }
            }
            return null;
        }

        private void startCombat(EntityItem item)
        {
            this.targetItem = item;
            Waypoint tmpWp = new Waypoint();
            tmpWp.position = item.position;
            this.movement.lookAt(tmpWp);

            this.keyboard.holdBackwardKey();
            Thread.Sleep(300);
            this.keyboard.releaseBackwardKey();
            this._strike = 0;
            this._itemFound = false;
            this.keyboard.pressTabKey();
            this.keyboard.pressCustomKey(Keys.R);
            Thread.Sleep(2550);
            this.keyboard.pressCustomKey(Keys.D2);
            Thread.Sleep(300);
            this.timer.Start();
        }

        private void tickCombat(object sender, EventArgs e)
        {
            this.timer.Stop();

            // break if bot paused
            if (!this.isRunning())
                return;

            int targetTypeId = this.memory.targetTypeId();

            if (targetTypeId != this.targetItem.typeId)
            {
                if (this._itemFound || this._strike > 3)
                {
                    if (this.memory.playerMP() < 400)
                        Thread.Sleep(5000);
                    Thread.Sleep(3000);
                    this.movement.resume();
                    return;
                }
                if (!this._itemFound) { 
                    this.keyboard.pressTabKey();
                    Thread.Sleep(1000);
                }

                this._strike++;
            }
            else
            {
                this.lastAttackedMob = this.targetItem.uniqueId;
                if(this.memory.playerHP() < 600)
                {
                    this.keyboard.pressCustomKey(Keys.E);
                }
                else
                {
                    this.keyboard.pressCustomKey(Keys.D1);
                }
                this._itemFound = true;
            }

            this.timer.Start();
        }
    }
}
