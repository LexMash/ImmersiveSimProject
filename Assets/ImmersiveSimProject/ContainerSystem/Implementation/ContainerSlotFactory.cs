using ImmersiveSimProject.ContainerSystem.API;
using ImmersiveSimProject.ItemsSystem;
using ImmersiveSimProject.StaticServices;
using System;

namespace ImmersiveSimProject.ContainerSystem.Implementation
{
    public class ContainerSlotFactory : IContainerSlotFactory
    {
        public IContainerSlot GetSlot(IItemMeta itemMeta, uint amount)
        {
            if (itemMeta != null && amount == 0)
            {
                Exceptions.ArgumentValueIsZero("slot create", GetType());
            }

            if (itemMeta != null && itemMeta.MaxCapacityInSlot < amount)
            {
                throw new ArgumentException("Amount of item cannot be greater than Item.MaxCapacityInSlot value");
            }

            if (itemMeta == null && amount != 0)
                Exceptions.ArgumentValueIsNull("slot create", GetType(), nameof(itemMeta));
             
            return new ContainerSlot(itemMeta, amount);
        }
    }
}
