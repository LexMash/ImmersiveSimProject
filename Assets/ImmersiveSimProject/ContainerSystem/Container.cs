using ImmersiveSimProject.ItemsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ImmersiveSimProject.ContainerSystem
{
    public class Container : IContainer
    {
        public event Action<IItem, uint> ItemAdded;
        public event Action<IItem, uint> ItemRemoved;
        public string NameID { get; }
        public string DescriptionID {get; }
        public int Capacity => _slotsMap.Count;
        public IContainerSlot[] Slots => _slotsMap.Values.ToArray();
        public bool IsEmpty => _slotsMap.Count == 0;

        private bool _isFull => _slotsMap.Count == Capacity; 
        private readonly SortedDictionary<string, ContainerSlot> _slotsMap = new();
        
        public Container(string nameID, ContainerSlot[] slots)
        {
            NameID = nameID;

            foreach (var slot in slots)
            {
                _slotsMap[slot.Item.NameID] = slot;
            }
        }

        public bool Contains(IItem item)
        {
            return _slotsMap.ContainsKey(item.NameID);
        }

        public bool TrAddItem(IItem item, uint amount = 1)
        {
            if (Contains(item))
            {
                var slot = _slotsMap[item.NameID];
                slot.AddItemAmount(amount);
            }
            else if (_isFull)
            {
                return false;
            }
            else
            {
                _slotsMap[item.NameID] = new ContainerSlot(item, amount);
            }

            ItemAdded?.Invoke(item, amount);

            return true;
        }

        public bool TryRemoveItem(IItem item, uint amount = 1)
        {
            if (amount == 0)
            {
                Debug.LogWarning($"You try remove 0 {item.NameID} from Container {NameID}");
                return false;
            }               

            if(Contains(item))
            {
                var slot = _slotsMap[item.NameID];

                if (slot.Amount < slot.Amount - amount)
                {
                    Debug.LogWarning($"You try remove more {item.NameID} than you have from Container {NameID}. {amount} = {slot.Amount}");
                    amount = slot.Amount;
                }

                if (slot.Amount - amount == 0)
                {
                    _slotsMap.Remove(item.NameID);
                }
                else
                {
                    slot.RemoveItemAmount(amount);
                }

                ItemRemoved?.Invoke(item, amount);
                return true;
            }

            return false;
        }


        //методы которые могут пригодиться для других реализаций
        //public bool HasEmptyCells()
        //{
        //    return container.ItemCells.Any(c => c.IsEmpty);
        //}

        //public bool IsEmpty()
        //{
        //    return container.ItemCells.All(c => c.IsEmpty);
        //}

        //public bool IsFull()
        //{
        //    return container.ItemCells.All(c => !c.IsEmpty);
        //}
    }
}
