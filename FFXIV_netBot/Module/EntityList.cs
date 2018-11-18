using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_netBot.Module
{
    class EntityList
    {
        private FinalFantasyXIVMemory memory;
        private List<EntityItem> list;

        public int Count { get { return this.list.Count; } }

        public EntityList(FinalFantasyXIVMemory memory)
        {
            this.list = new List<EntityItem>();
            this.memory = memory;
        }

        public EntityItem itemAtIndex(int index)
        {
            if (this.list.Count > index)
                return this.list[index];
            return null;
        }

        public void update()
        {
            Int32 _count = this.memory.entityCount();
            this.list.Clear();
            for(int i = 0; i < _count; ++i)
            {
                IntPtr ptr = this.memory.entityPointerAtIndex(i);
                EntityItem currItem = this.list.FirstOrDefault(item => item.baseAddress == ptr);
                if (currItem == null)
                {
                    currItem = new EntityItem(ptr, this.memory);
                    this.list.Add(currItem);
                } 
                else 
                {
                    currItem.updateData(this.memory);
                }
            }
            this.list.Sort(new EntityListSort());
        }
    }
}
