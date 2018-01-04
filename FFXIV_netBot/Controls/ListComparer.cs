using System;
using System.Collections;
using System.Collections.Generic;

using FFXIV_netBot.Module;


namespace FFXIV_netBot
{
    public class EntityListSort : IComparer<EntityItem>
    {
        public int Compare(EntityItem x, EntityItem y)
        {
            if (x.distance > y.distance)
                return 1;
            else if (x.distance == y.distance)
                return 0;
            return -1;
        }
    }
}
