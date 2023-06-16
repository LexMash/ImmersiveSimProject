using ImmersiveSimProject.ItemsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ImmersiveSimProject.ContainerSystem
{
    public class Container : IContainer
    {
        public event Action<IItemMeta, uint> ItemAdded;
        public event Action<IItemMeta, uint> ItemRemoved;
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

        public bool Contains(IItemMeta item) => _slots.FirstOrDefault(slot => slot.Item.Equals(item)) != null;

        public bool ContainsAmount(IItemMeta itemMeta, uint amount = 1)
        {
            if (amount == 0)
            {
                ZeroAmountWarning("find operation");
                return false;
            }

            var allSlotsContainsItem = _slots.Where(slot => slot.Item.Equals(itemMeta)).ToList();

            if(allSlotsContainsItem != null && allSlotsContainsItem.Count > 0)
            {
                var sumAllValues = allSlotsContainsItem.Sum(slot => slot.Amount);

                return sumAllValues >= amount;
            }
            
            return false;
        }

        public bool TrAddItem(IItemMeta itemMeta, uint amount = 1)
        {
            if (IsFull)
                return false;

            if (amount == 0)
            {
                ZeroAmountWarning("add operation");
                return false;
            }

            var notFullSlots = _slots.Where(slot => (slot.Item.Equals(itemMeta) && !slot.IsFull) || slot.IsEmpty).ToList();

            if (notFullSlots != null && notFullSlots.Count() > 0)
            {
                if(CanAddInSlots(notFullSlots, itemMeta, amount))
                {
                    for (int i = 0; i < notFullSlots.Count(); i++)
                    {
                        var slot = notFullSlots[i];

                        if (CanAddInSlot(slot, itemMeta, amount))
                        {
                            if (slot.IsEmpty)
                            {
                                slot.Item = itemMeta;
                            }

                            slot.Amount += amount;

                            NotificateListeners(itemMeta, amount, ItemAdded);
                            return true;
                        }
                        else
                        {
                            if (slot.IsEmpty)
                            {
                                slot.Item = itemMeta;
                            }

                            var canBeAddedAmount = slot.Item.MaxCapacityInSlot - slot.Amount;
                            slot.Amount += canBeAddedAmount;
                            amount -= canBeAddedAmount;
                        }
                    }
                }            
            }

            return amount == 0;          
        }

        public bool TrAddItemInSlot(int slotIndex, IItemMeta itemMeta, uint amount = 1)
        {
            if (amount == 0)
            {
                ZeroAmountWarning("add operation");
                return false;
            }

            var slot = _slots[slotIndex];

            if (slot.IsFull)
                return false;

            if(slot.IsEmpty || slot.Item.Equals(itemMeta))
            {
                if(CanAddInSlot(slot, itemMeta, amount))
                {
                    if (slot.IsEmpty)
                    {
                        slot.Item = itemMeta;
                    }

                    slot.Amount += amount;

                    NotificateListeners(itemMeta, amount, ItemAdded);
                    return true;
                }              
            }
           
            return false;
        }

        public bool TryRemoveItem(IItemMeta item, uint amount = 1)
        {
            if (amount == 0)
            {
                ZeroAmountWarning("remove operation"); ;
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

                        TryClearSlot(slot);

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

        public bool TryRemoveItemFromSlot(int slotIndex, IItemMeta item, uint amount = 1)
        {
            if (amount == 0)
            {
                ZeroAmountWarning("remove operation"); ;
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

        private bool CanAddInSlot(ContainerSlot slot, IItemMeta itemMeta, uint amount)
        {
            if (!slot.IsEmpty)
            {
                return slot.Amount + amount <= slot.Item.MaxCapacityInSlot;
            }
            else
            {
                return itemMeta.MaxCapacityInSlot <= amount;
            }
        }

        private bool CanAddInSlots(List<ContainerSlot> slots, IItemMeta itemMeta, uint amount)
        {
            for (int i = 0; i < slots.Count(); i++)
            {
                var slot = slots[i];

                if (CanAddInSlot(slot, itemMeta, amount))
                {
                    return true;
                }
                else
                {
                    var canBeAddedAmount = itemMeta.MaxCapacityInSlot - slot.Amount;
                    amount -= canBeAddedAmount;
                }
            }

            return amount == 0;
        }

        private bool CanRemoveFromSlot(ContainerSlot slot, uint amount)
        {
            if (!slot.IsEmpty)
            {
                return slot.Amount >= amount;
            }

            return false;
        }

        private void ZeroAmountWarning(string operation) 
            => Debug.LogWarning($"Amount cannot be 0 -{operation}- Container {NameID}");

        private void NotificateListeners(IItemMeta item, uint amount, Action<IItemMeta, uint> action) 
            => action?.Invoke(item, amount);
    }
}
