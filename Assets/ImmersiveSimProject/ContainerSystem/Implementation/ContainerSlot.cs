using ImmersiveSimProject.ContainerSystem.API;
using ImmersiveSimProject.ItemsSystem;

namespace ImmersiveSimProject.ContainerSystem.Implementation
{
    public class ContainerSlot : IContainerSlot, IReadOnlyContainerSlot
    {
        public IItemMeta Item { get; set; }
        public uint Amount { get; set; }
        public bool IsEmpty => Item == null;
        public bool IsFull => Item.MaxCapacityInSlot == Amount;

        public ContainerSlot(IItemMeta item, uint amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}