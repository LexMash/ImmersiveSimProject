using ImmersiveSimProject.ItemsSystem;

namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс для фабрики создающей слоты контейнеров
    /// </summary>
    public interface IContainerSlotFactory
    {
        /// <summary>
        /// Создаёт новый слот с указанными параметрами
        /// </summary>
        /// <param name="itemMeta"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        IContainerSlot GetSlot(IItemMeta itemMeta, uint amount);
    }
}
