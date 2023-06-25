using System.Collections.Generic;

namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс для контейнера ограниченной емкости
    /// </summary>
    public interface IContainer : INamed
    {       
        public IReadOnlyList<IContainerSlot> Slots { get; }
    }
}