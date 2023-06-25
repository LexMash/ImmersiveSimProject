using ImmersiveSimProject.ItemsSystem;

namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс для слота контейнеров ограниченной ёмкости только для чтения
    /// </summary>
    public interface IReadOnlyContainerSlot
    {
        public IItemMeta Item { get; }
        public uint Amount { get; }
        public bool IsEmpty { get; }
        public bool IsFull { get; }
    }
}
