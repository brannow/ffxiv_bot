using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FFXIV_netBot.Module;

namespace FFXIV_netBot
{
    public class FinalFantasyKeyboard : CoreKeyboard
    {
        public GeneralKeys keys;

        public FinalFantasyKeyboard(GeneralKeys gKeySet)
        {
            this.keys = gKeySet;
            this.attachProcess(FinalFantasyXIVMemory.PROCESSNAME);
        }

        public void pressJumpKey()
        {
            this.pressKey(Keys.Space);
        }

        public void pressCustomKey(uint keyCode, uint interval = 0)
        {
            this.pressKey((Keys)keyCode, interval);
        }
        public void pressCustomKey(Keys key, uint interval = 0)
        {
            this.pressKey(key, interval);
        }


        public void pressActionKey()
        {
            this.pressKey((Keys)this.keys.action);
        }

        public void pressTabKey()
        {
            this.pressKey(Keys.Tab);
        }

        public void pressESCKey()
        {
            this.pressKey(Keys.Escape);
        }

        public void holdForwardKey() 
        {
            this.pressKeyDown((Keys)this.keys.forward);
        }
        public void releaseForwardKey()
        {
            this.pressKeyUp((Keys)this.keys.forward);
        }


        public void holdBackwardKey()
        {
            this.pressKeyDown((Keys)this.keys.backward);
        }
        public void releaseBackwardKey()
        {
            this.pressKeyUp((Keys)this.keys.backward);
        }

        public void holdRotateLeftKey()
        {
            this.pressKeyDown((Keys)this.keys.rotateLeft);
        }
        public void releaseRotateLeftKey()
        {
            this.pressKeyUp((Keys)this.keys.rotateLeft);
        }


        public void holdRotateRightKey()
        {
            this.pressKeyDown((Keys)this.keys.rotateRight);
        }
        public void releaseRotateRightKey()
        {
            this.pressKeyUp((Keys)this.keys.rotateRight);
        }
    }
}
