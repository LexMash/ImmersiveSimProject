using ImmersiveSimProject.ItemsSystem;
using System;

namespace ImmersiveSimProject.ContainerSystem
{
    public interface IContainer : INamed
    {
        public event Action<IItemMeta, uint> ItemAdded;
        public event Action<IItemMeta, uint> ItemRemoved;

        public IContainerSlot[] Slots { get; } //если нет ограничения по ёмкости, меняем тип коллекции
        public int Capacity { get; } //если требуется ограничить ёмкость
        public bool IsEmpty { get; }
        public bool IsFull { get; }

        public bool TrAddItem(IItemMeta item, uint amount = 1);
        public bool TrAddItemInSlot(int slotIndex, IItemMeta item, uint amount = 1);
        public bool TryRemoveItem(IItemMeta item, uint amount = 1);
        public bool TryRemoveItemFromSlot(int slotIndex, IItemMeta item, uint amount = 1);
        public bool Contains(IItemMeta item);
        public bool ContainsAmount(IItemMeta item, uint amount = 1);
        public void RemoveAllFromSlot(int slotIndex);
        public void RemoveAll();
    }
}