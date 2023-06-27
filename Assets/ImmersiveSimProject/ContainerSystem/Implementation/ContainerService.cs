using ImmersiveSimProject.ContainerSystem.API;

namespace ImmersiveSimProject.ContainerSystem.Implementation
{
    public class ContainerService : IContainerService<string>
    {
        private readonly IContainers _containers;

        public ContainerService(IContainers containers)
        {
            _containers = containers;
        }

        public IContainerController GetContainer(string nameID)
        {
            IContainer container = _containers[nameID];

            return new ContainerController(container);
        }
    }
}
