using ImmersiveSimProject.ItemsSystem;

namespace ImmersiveSimProject.ContainerSystem
{
    public interface IContainerSlot
    {
        public IItemMeta Item { get; }
        public uint Amount { get; }
        public bool IsEmpty { get; }
        public bool IsFull { get; }
    }
}
