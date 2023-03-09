using ImmersiveSimProject.ItemsSystem;

namespace ImmersiveSimProject.ContainerSystem
{
    public interface IContainerSlot
    {
        public IItem Item { get; }
        public uint Amount { get; }
        
        //public bool IsEmpty { get; }
    }
}
