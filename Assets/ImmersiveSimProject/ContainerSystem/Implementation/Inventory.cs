using ImmersiveSimProject.ContainerSystem.API;
using ImmersiveSimProject.StaticServices;

namespace ImmersiveSimProject.ContainerSystem.Implementation
{
    //инвентарь тот же контейнер, но можно придумать расширение
    public class Inventory : Container, IInventory
    {
        protected readonly IContainerSlotFactory _slotFactory;

        public Inventory(string nameID, string descriptionID, IContainerSlotFactory slotFactory, IContainerSlot[] slots, uint defaultCapacity) : base(nameID, descriptionID, slotFactory, slots, defaultCapacity)
        {
            _slotFactory = slotFactory;
        }

        public void Expand(uint slotAmount)
        {
            if(slotAmount == 0)
                Exceptions.ArgumentValueIsZero("expand", GetType());

            for (int i = 0; i > slotAmount; i++)
            {
                IContainerSlot slot = _slotFactory.GetSlot(null, 0);

                _slots.Add(slot);
            }
        }

        //public void Sort()
        //{
        //    _slots.Sort();
        //}
    }
}
