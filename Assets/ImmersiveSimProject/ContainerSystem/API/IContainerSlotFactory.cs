using ImmersiveSimProject.ItemsSystem;

namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс для фабрики создающей слоты контейнеров
    /// </summary>
    public interface IContainerSlotFactory
    {
        IContainerSlot GetSlot(IItemMeta itemMeta, uint amount);
    }
}
