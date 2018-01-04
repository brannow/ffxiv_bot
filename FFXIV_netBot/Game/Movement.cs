using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using FFXIV_netBot.Bot;
using FFXIV_netBot.Module;

namespace FFXIV_netBot
{
    public class Movement
    {
        private FinalFantasyKeyboard keyboard;
        private FinalFantasyXIVMemory memory;

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Timer _adjustTimer;

        // delegate
        private WaypointReached waypointReached;
        private StartMovingToWaypoint startMovingToWaypoint;
        private MovingStopped movingStopped;
        private MovingToWaypoint movingToWaypoint;
        private SingleMovementFinished singleMovementFinished;

        // datasource
        private bool isDatasourceSetted = false;
        private NumberOfWaypoints numberOfWaypoints;
        private WaypointAtIndex waypointAtIndex;

        private Waypoint nextWaypoint;
        private Waypoint adjustWaypoint;
        private bool isCaneling;
        private bool isPaused;

        private int currentIndex;
        private int waypointCount;

        private int _waypointPasses;
        private int _waypointPassLimit;

        private bool singleMovement = false;
        private PlayerPosition singleTargetPosition;
        private bool useSinglePosition = false;

        public Movement(FinalFantasyXIVMemory memory, FinalFantasyKeyboard keyboard)
        {
            this.timer = new System.Windows.Forms.Timer();
            this.timer.Interval = SettingsSingleton.Instance.timings.movementUpdateTick;
            this.timer.Tick += new System.EventHandler(this.__moving);

            this._adjustTimer = new System.Windows.Forms.Timer();
            this._adjustTimer.Interval = SettingsSingleton.Instance.timings.movementUpdateTick;
            this._adjustTimer.Tick += new System.EventHandler(this.singleAdjusting);

            this.memory = memory;
            this.keyboard = keyboard;
        }

        public void setDelegates(WaypointReached wpr, StartMovingToWaypoint smw, MovingStopped ms, MovingToWaypoint mt, SingleMovementFinished sm)
        {
            this.waypointReached = wpr;
            this.startMovingToWaypoint = smw;
            this.movingStopped = ms;
            this.movingToWaypoint = mt;
            this.singleMovementFinished = sm;
        }

        public void setDataSource(NumberOfWaypoints now, WaypointAtIndex wai)
        {
            this.numberOfWaypoints = now;
            this.waypointAtIndex = wai;
            this.isDatasourceSetted = true;
        }

        public bool isPuased()
        {
            return this.isPaused;
        }

        /**
         * 
         * MOVEMENT INTERFACE 
         * 
         ***/


        public void startMoving()
        {
            if (!this.singleMovement)
            {
                this.currentIndex = 0;
                this.waypointCount = 0;
                this._waypointPasses = 0;
                this._waypointPassLimit = 0;
                this.isCaneling = false;
                this.isPaused = false;
                this.moveToPositionAtIndex(0);
            }
        }

        public void stopMoving()
        {
            if(!this.singleMovement)
            {
                this.cancelMoving();
                this.movingStopped(this.currentIndex);
            }
        }

        public void pause()
        {
            if (!this.isPaused && !this.singleMovement) 
            {
                this.isPaused = true;
                if (this.timer != null)
                {
                    this.timer.Stop();
                }
                this.keyboard.releaseRotateRightKey();
                this.keyboard.releaseRotateLeftKey();
                this.keyboard.releaseForwardKey();
            }
        }

        public void resume()
        {
            if (this.isPaused && !this.singleMovement)
            {
                this.isPaused = false;
                this.moveToPositionAtIndex(this.currentIndex);
            }
        }

        public void cancelMoving()
        {
            this.isCaneling = true;
            if (this.timer != null)
            {
                this.timer.Stop();
            }
            this.currentIndex = 0;
            this.waypointCount = 0;
            this._waypointPasses = 0;
            this._waypointPassLimit = 0;
            this.singleMovement = false;
            this.isPaused = false;
            this.keyboard.releaseRotateRightKey();
            this.keyboard.releaseRotateLeftKey();
            this.keyboard.releaseForwardKey();
        }

        public void lookAt(Waypoint wp)
        {
            if ((this.isCaneling == true || this.isPaused == true) && !this.singleMovement)
            {
                this.adjustWaypoint = wp;
                this.singleAdjusting(null, EventArgs.Empty);
            }
        }

        public void singleMoveToPosition(PlayerPosition pp)
        {
            if ((this.isCaneling == true || this.isPaused == true) && !this.singleMovement)
            {
                this.singleMovement = true;
                this.moveToPosition(pp);

            }
        }

        /**
         * 
         * MOVEMENT CORE 
         * 
         ***/

        private void moveToPositionAtIndex(int index)
        {
            if (this.isDatasourceSetted)
            {
                if (this._waypointPassLimit > 0)
                {
                    ++this._waypointPasses;
                    if (this._waypointPassLimit < this._waypointPasses)
                    {
                        this.cancelMoving();
                        this.movingStopped(this.currentIndex);
                        return;
                    }
                }

                this.waypointCount = this.numberOfWaypoints();
                if (this.waypointCount > index)
                {
                    this.currentIndex = index;
                    Waypoint wp = this.waypointAtIndex(index);
                    this.startMovingToWaypoint(index);
                    this.moveToWaypoint(wp);
                }
                else if (this.waypointCount > 0)
                {
                    this.moveToPositionAtIndex(0);
                }
                else
                {
                    this.cancelMoving();
                    this.movingStopped(this.currentIndex);
                    return;
                }
            }
        }

        /**
         * 
         * MOVEMENT CORE 
         *  THREAD START
         *  
         ***/
        private void moveToWaypoint(Waypoint wp)
        {
            if (this.timer != null)
            {
                this.useSinglePosition = false;
                this.nextWaypoint = wp;
                this.timer.Interval = SettingsSingleton.Instance.timings.movementUpdateTick;
                this.timer.Start();
            }
        }

        private void moveToPosition(PlayerPosition pp)
        {
            if (this.timer != null)
            {
                this.useSinglePosition = true;
                this.singleTargetPosition = pp;
                this.timer.Interval = SettingsSingleton.Instance.timings.movementUpdateTick;
                this.timer.Start();
            }
        }

        private void finishWaypointMovement()
        {
            if (this.timer != null)
            {
                this.timer.Stop();
            }

            if (this.singleMovement)
            {
                this.singleMovement = false;
                this.singleMovementFinished();
            }
            else
            {
                this.waypointReached(this.currentIndex);

                if (!this.isCaneling && !this.isPaused)
                {
                    this.moveToPositionAtIndex(this.currentIndex + 1);
                }
            }           
        }

        private void __moving(object sender, EventArgs e)
        {

            this.timer.Stop();

                PlayerPosition target = this.nextWaypoint.position;
                if (this.useSinglePosition)
                    target = this.singleTargetPosition;

                PlayerPosition currentPosition = this.memory.position();

                Double angle = currentPosition.angleBetweenPosition(target);
                Double distance = currentPosition.distanceBetweenPosition(target);

                this.movingToWaypoint(this.currentIndex, distance);

                // final radian to target
                double targetRadian = currentPosition.r - angle;
                targetRadian = MathEx.normalizeAngle(targetRadian);

                Int32 waypointsLeft = this.waypointCount - this.currentIndex;


                // core movement logic            
                // move to waypoint if distance lower then minDistanceToMove
                if (distance > SettingsSingleton.Instance.timings.minMovementDistanceToNextWaypoint && !this.isCaneling && (!this.isPaused || this.singleMovement))
                {
                    // adjust view direction to target
                    this.__adjustToTarget(angle, targetRadian);

                    // walk only if angle < (-+) min limit
                    if (MathEx.isInRange(angle, SettingsSingleton.Instance.timings.minRadianDifferanceToMove, -SettingsSingleton.Instance.timings.minRadianDifferanceToMove))
                    {
                        // avoid running idiot circle bug
                        if (distance < 5 && !MathEx.isInRange(angle, 0.2, -0.2))
                        {
                            this.keyboard.releaseForwardKey();
                        } 
                        else
                        {
                            this.keyboard.holdForwardKey();
                        }
                        // move forward
                    }
                    else
                    {
                        this.keyboard.releaseForwardKey();
                    }
                }
                else
                {
                    // release all keys and dispose current waypoint moving
                    // release forward moving not On waypoint walking  ... smoother look
                    if (waypointsLeft < 2 || this.singleMovement)
                    {
                        this.keyboard.releaseForwardKey();
                    }
                    this.keyboard.releaseRotateRightKey();
                    this.keyboard.releaseRotateLeftKey();
                    this.finishWaypointMovement();
                    return;
                }
                this.timer.Start();
        }

        private int __adjustToTarget(Double angle, Double targetRadian)
        {
            if (!MathEx.isInRange(angle, SettingsSingleton.Instance.timings.minRadianDifferanceToUseKeys, -SettingsSingleton.Instance.timings.minRadianDifferanceToUseKeys))
            {
                if (angle >= 0)
                {
                    this.keyboard.releaseRotateLeftKey();
                    this.keyboard.holdRotateRightKey();
                }
                else if (angle < 0)
                {
                    this.keyboard.releaseRotateRightKey();
                    this.keyboard.holdRotateLeftKey();
                }
                return 2;
            }
            else if (!MathEx.isInRange(angle, SettingsSingleton.Instance.timings.minRadianDifferanceToUseMemoryHack, -SettingsSingleton.Instance.timings.minRadianDifferanceToUseMemoryHack))
            {
                this.keyboard.releaseRotateRightKey();
                this.keyboard.releaseRotateLeftKey();
                Thread.Sleep(SettingsSingleton.Instance.timings.movementRotationSleepUntilMemoryHack);
                this.memory.setRotation(Convert.ToSingle(targetRadian));
                return 1;
            }
            else
            {
                this.keyboard.releaseRotateRightKey();
                this.keyboard.releaseRotateLeftKey();
                return 0;
            }
        }

        private void singleAdjusting(object sender, EventArgs e)
        {
            //this._adjustTimer.Stop();

            PlayerPosition target = this.adjustWaypoint.position;
            PlayerPosition currentPosition = this.memory.position();

            Double angle = currentPosition.angleBetweenPosition(target);

            double targetRadian = currentPosition.r - angle;
            targetRadian = MathEx.normalizeAngle(targetRadian);

            this.memory.setRotation(Convert.ToSingle(targetRadian));

            //this._adjustTimer.Start();
        } 
    }
}
