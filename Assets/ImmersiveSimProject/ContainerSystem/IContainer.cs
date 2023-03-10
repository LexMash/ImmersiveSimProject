using ImmersiveSimProject.ItemsSystem;
using System;

namespace ImmersiveSimProject.ContainerSystem
{
    public interface IContainer : INamed
    {
        public event Action<IItem, uint> ItemAdded;
        public event Action<IItem, uint> ItemRemoved;

        public IContainerSlot[] Slots { get; } //если нет ограничения по ёмкости, меняем тип коллекции
        public int Capacity { get; } //если требуется ограничить ёмкость
        public bool IsEmpty { get; }
        public bool IsFull { get; }

        public bool TrAddItem(IItem item, uint amount = 1);
        public bool TrAddItemInSlot(int slotIndex, IItem item, uint amount = 1);
        public bool TryRemoveItem(IItem item, uint amount = 1);
        public bool TryRemoveItemFromSlot(int slotIndex, IItem item, uint amount = 1);
        public bool Contains(IItem item);
        public bool ContainsAmount(IItem item, uint amount = 1);
        public void RemoveAllFromSlot(int slotIndex);
        public void RemoveAll();
    }
}