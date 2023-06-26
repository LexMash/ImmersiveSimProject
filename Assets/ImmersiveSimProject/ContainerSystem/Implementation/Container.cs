using ImmersiveSimProject.ContainerSystem.API;
using System.Collections.Generic;

namespace ImmersiveSimProject.ContainerSystem.Implementation
{
    public class Container : IContainer
    {       
        public string NameID { get; }
        public string DescriptionID { get; }
        public IReadOnlyList<IContainerSlot> Slots => _slots;

        protected readonly List<IContainerSlot> _slots = new();

        public Container(string nameID, string descriptionID, IContainerSlotFactory slotFactory, IContainerSlot[] slots, uint defaultCapacity)
        {
            NameID = nameID;
            DescriptionID = descriptionID;

            for(int i = 0; i < defaultCapacity; i++)
            {
                IContainerSlot slot = slots.Length <= i ? slotFactory.GetSlot() : slots[i];

                _slots.Add(slot);
            }
        }       
    }
}
