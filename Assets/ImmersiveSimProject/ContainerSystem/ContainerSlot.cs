using ImmersiveSimProject.ItemsSystem;
using System;
using UnityEngine;

namespace ImmersiveSimProject.ContainerSystem
{
    public class ContainerSlot : IContainerSlot
    {
        public IItemMeta Item { get; set; }
        public uint Amount { get; set; }
        public bool IsEmpty => Item == null && Amount == 0;
        public bool IsFull => Item.MaxCapacityInSlot == Amount;

        public ContainerSlot(IItemMeta item, uint amount)
        {
            Item = item;
            Amount = amount;
        }
    }
}