using ImmersiveSimProject.ItemsSystem;
using System;
using System.Collections.Generic;

namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс котроллера контейнера, который является обёрткой для работы с IContainer и изменения содержимого в его IContainerSlot
    /// </summary>
    public interface IContainerController
    {
        public event Action<IItemMeta, uint> ItemAdded;
        public event Action<IItemMeta, uint> ItemRemoved;

        /// <summary>
        /// Коллекция только для чтения без возможности изменять содержимое слотов напрямую
        /// </summary>
        public IReadOnlyList<IReadOnlyContainerSlot> Slots { get; }
        public int Capacity { get; }
        public bool IsEmpty { get; }
        public bool IsFull { get; }

        /// <summary>
        /// В случае успеха добавляет предмет в указанном кол-ве в первый свободный слот.
        /// </summary>
        /// <param name="itemMeta"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        public bool TryAddItem(IItemMeta item, uint amount);

        /// <summary>
        /// В случае успеха добавляет предмет в указанном кол-ве в конкретный слот.
        /// </summary>
        /// <param name="itemMeta"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        public bool TryAddItemInSlot(int slotIndex, IItemMeta item, uint amount);

        /// <summary>
        /// В случае успеха удаляет указанный предмет в указанном кол-ве из любого слота
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        public bool TryRemoveItem(IItemMeta item, uint amount);

        /// <summary>
        /// В случае успеха удаляет указанный предмет в указанном кол-ве из указанного слота
        /// </summary>
        /// <param name="slotIndex"></param>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        public bool TryRemoveItemFromSlot(int slotIndex, IItemMeta item, uint amount);

        /// <summary>
        /// Проверяет есть ли предмет в контейнере
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Да/Нет</returns>
        public bool Contains(IItemMeta item);

        /// <summary>
        /// Проверяет есть ли предмет в необходимом кол-ве
        /// </summary>
        /// <param name="itemMeta"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        public bool ContainsAmount(IItemMeta item, uint amount);

        /// <summary>
        /// Полностью очищает слот под указанным индексом
        /// </summary>
        /// <param name="slotIndex"></param>
        public void ClearSlot(int slotIndex);

        /// <summary>
        /// Очищает все слоты контейнера
        /// </summary>
        public void ClearAllSlots();
    }
}
