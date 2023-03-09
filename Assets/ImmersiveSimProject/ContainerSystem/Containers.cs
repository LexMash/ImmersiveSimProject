using ImmersiveSimProject.ContainerSystem;
using System.Collections;
using System.Collections.Generic;

namespace FromTheBasement.Data.ContainerSystem
{
    //все контейнеры игры
    //лучше сделать для каждой локи свой
    public class Containers : IContainers
    {
        private readonly SortedDictionary<string, IContainer> _containersMap = new();

        public Containers(IContainer[] containers)
        {
            foreach (IContainer container in containers)
            {
                _containersMap[container.NameID] = container;
            }
        }

        public IContainer this[string nameID]
        {
            get => _containersMap[nameID];
        }

        public int Count => _containersMap.Count;

        public IEnumerator<IContainer> GetEnumerator() => _containersMap.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
