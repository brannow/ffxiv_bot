using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXIV_netBot.Module
{
    public class EntityItem
    {
        public uint baseAddress;
        public String name;
        public PlayerPosition position;
        public Int32 visibleStatus;
        public Int32 typeId;
        public Int32 uniqueId;
        public Int32 interacrtionId;
        public Single distance = -1;

        public EntityItem(uint baseAddress, FinalFantasyXIVMemory mem)
        {
            this.baseAddress = baseAddress;
            this.updateData(mem);
        }

        public void updateData(FinalFantasyXIVMemory mem)
        {
            
            this.name = mem.entityName(baseAddress);
            this.position = mem.entityposition(baseAddress);
            this.visibleStatus = mem.entityVisibleStatus(baseAddress);
            this.typeId = mem.entityTypeId(baseAddress);
            this.uniqueId = mem.entityUniqueId(baseAddress);
            this.interacrtionId = mem.entityInteractionId(baseAddress);
            
            PlayerPosition pos = mem.position();
            this.distance = (Single)pos.distanceBetweenPosition(this.position);
        }
    }
}
