using ImmersiveSimProject.ItemsSystem;

namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс для слота контейнеров ограниченной ёмкости
    /// </summary>
    public interface IContainerSlot
    {
        public IItemMeta Item { get; set; }
        public uint Amount { get; set; }
        public bool IsEmpty { get; }
        public bool IsFull { get; }
    }
}
