using ImmersiveSimProject.ItemsSystem;
using System;
using UnityEngine;

namespace ImmersiveSimProject.ContainerSystem
{
    [Serializable]
    public class ContainerSlot : IContainerSlot
    {
        [SerializeField] private Item _item;
        [field: SerializeField] public uint Amount { get; private set; }
        public IItem Item {get; private set;}
        
        public ContainerSlot(IItem item, uint amount)
        {
            Item = _item == null ? item : _item; //костыль, что бы использовать один класс и в SO и внутри кода, потому что интерфейсы не сериализуются в инспекторе
            Amount = amount;
        }

        public void AddItemAmount(uint amount) => Amount += amount;
        public void RemoveItemAmount(uint amount) => Amount -= amount;
    }
}