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
        public int Capacity => _slots.Count;
        public IContainerSlot[] Slots => _slots.ToArray();
        public bool IsEmpty => _slots.All(slot => slot.IsEmpty);
        public bool IsFull => _slots.All(slot => slot.IsFull);

        protected readonly List<ContainerSlot> _slots = new();

        public Container(string nameID, string descriptionID, ContainerSlot[] slots)
        {
            NameID = nameID;
            DescriptionID = descriptionID;

            foreach (var slot in slots)
            {
                _slots.Add(slot);
            }
        }

        public bool Contains(IItem item) => _slots.FirstOrDefault(slot => slot.Item.Equals(item)) != null;

        public bool ContainsAmount(IItem item, uint amount = 1)
        {
            if (amount == 0)
            {
                ZeroValueWarning(" find operation ");
                return false;
            }

            var allSlotsContainsItem = _slots.Where(slot => slot.Item.Equals(item)).ToList();

            if(allSlotsContainsItem != null && allSlotsContainsItem.Count > 0)
            {
                var sumAllValues = allSlotsContainsItem.Sum(slot => slot.Amount);

                return sumAllValues >= amount;
            }
            
            return false;
        }

        public bool TrAddItem(IItem item, uint amount = 1)
        {
            if (IsFull)
                return false;

            if (amount == 0)
            {
                ZeroValueWarning(" add operation ");
                return false;
            }

            var notFullSlots = _slots.Where(slot => (slot.Item.Equals(item) && !slot.IsFull) || slot.IsEmpty).ToList();

            if (notFullSlots != null && notFullSlots.Count() > 0)
            {
                for(int i = 0;  i < notFullSlots.Count(); i++)
                {
                    var slot = notFullSlots[i];

                    if (CanAddToSlot(slot, amount))
                    {
                        if (slot.IsEmpty)
                        {
                            slot.Item = item;
                        }

                        slot.Amount += amount;

                        NotificateListeners(item, amount, ItemAdded);
                        return true;
                    }
                    else
                    {
                        var possibleAmount = slot.Item.MaxCapacityInSlot - slot.Amount;                       
                        slot.Amount += possibleAmount;
                        amount -= possibleAmount;
                    }

                    if (IsFull)
                        break;
                }
            }

            return false;          
        }

        public bool TrAddItemInSlot(int slotIndex, IItem item, uint amount = 1)
        {
            if (amount == 0)
            {
                ZeroValueWarning(" add operation ");
                return false;
            }

            var slot = _slots[slotIndex];

            if (slot.IsFull)
                return false;

            if(slot.Item.Equals(item) && CanAddToSlot(slot, amount))
            {
                slot.Amount += amount;

                NotificateListeners(item, amount, ItemAdded);
                return true;
            }

            return false;
        }

        public bool TryRemoveItem(IItem item, uint amount = 1)
        {
            if (amount == 0)
            {
                ZeroValueWarning(" remove operation "); ;
                return false;
            }

            if (ContainsAmount(item, amount))
            {
                var containsSlots = _slots.Where(slot => (slot.Item.Equals(item))).ToList();

                for(int i = 0; i < containsSlots.Count; i++)
                {
                    var slot = containsSlots[i];

                    if(CanRemoveFromSlot(slot, amount))
                    { 
                        slot.Amount -= amount;

                        NotificateListeners(item, amount, ItemRemoved);
                        return true;
                    }
                    else
                    {
                        amount -= slot.Amount;
                        slot.Amount = 0;
                    }

                    TryClearSlot(slot);
                }
            }

            return false;
        }

        public bool TryRemoveItemFromSlot(int slotIndex, IItem item, uint amount = 1)
        {
            if (amount == 0)
            {
                ZeroValueWarning(" remove operation "); ;
                return false;
            }

            var slot = _slots[slotIndex];

            if(slot.Item.Equals(item) && slot.Amount >= amount)
            {
                slot.Amount -= amount;

                TryClearSlot(slot);

                NotificateListeners(item, amount, ItemRemoved);
                return true;
            }

            return false;
        }

        public void RemoveAllFromSlot(int slotIndex)
        {
            var item = _slots[slotIndex].Item;
            var amount = _slots[slotIndex].Amount;

            _slots[slotIndex].Item = null;
            _slots[slotIndex].Amount = 0;

            NotificateListeners(item, amount, ItemRemoved);
        }

        public void RemoveAll()
        {
            for(int i = 0; i < _slots.Count; i++) 
            {
                RemoveAllFromSlot(i);
            }
        }


        private bool TryClearSlot(ContainerSlot slot)
        {
            if (slot.Amount == 0)
            {
                slot.Item = null;
                return true;
            }

            return false;
        }

        private bool CanAddToSlot(ContainerSlot slot, uint amount)
        {
            if (!slot.IsEmpty)
            {
                return slot.Amount + amount <= slot.Item.MaxCapacityInSlot;
            }

            return true;
        }

        private bool CanRemoveFromSlot(ContainerSlot slot, uint amount)
        {
            if (!slot.IsEmpty)
            {
                return slot.Amount >= amount;
            }

            return false;
        }

        private void ZeroValueWarning(string operation) => Debug.LogWarning($"Amount cannot be 0 -{operation}- Container {NameID}");
        private void NotificateListeners(IItem item, uint amount, Action<IItem, uint> action) => action?.Invoke(item, amount);

        //public bool HasEmptyCells()
        //{
        //    return _slots.Any(slot => slot.IsEmpty);
        //}
    }
}
