using ImmersiveSimProject.ContainerSystem.API;

namespace ImmersiveSimProject.ContainerSystem.Implementation
{
    public class ContainerSlotFactory : IContainerSlotFactory
    {
        public IContainerSlot GetSlot()
        {
            return new ContainerSlot(null, 0);
        }
    }
}
