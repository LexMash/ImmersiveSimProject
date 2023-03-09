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

        //public bool IsFull { get; }

        //непонятно с какой стороны будет проводиться проверка на то, что контейнер полон
        //по этому перестрахуемся и сделаем её и внутри
        public bool TrAddItem(IItem item, uint amount = 1);
        public bool TryRemoveItem(IItem item, uint amount = 1);
        public bool Contains(IItem item);
    }
}
