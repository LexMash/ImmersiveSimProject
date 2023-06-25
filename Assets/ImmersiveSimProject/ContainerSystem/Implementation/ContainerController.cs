﻿using ImmersiveSimProject.ContainerSystem.API;
using ImmersiveSimProject.ItemsSystem;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ImmersiveSimProject.ContainerSystem.Implementation
{
    public class ContainerController : IContainerController
    {
        public event Action<IItemMeta, uint> ItemAdded;
        public event Action<IItemMeta, uint> ItemRemoved;

        public int Capacity => _container.Slots.Count;
        public IReadOnlyList<IReadOnlyContainerSlot> Slots => (IReadOnlyList<IReadOnlyContainerSlot>)_container.Slots;
        public bool IsEmpty => _container.Slots.All(slot => slot.IsEmpty);
        public bool IsFull => _container.Slots.All(slot => slot.IsFull);        

        private readonly IContainer _container;

        public ContainerController(IContainer container)
        {
            _container = container;
        }
        
        public bool Contains(IItemMeta item) 
            => _container.Slots.FirstOrDefault(slot => slot.Item.Equals(item)) != null;

        public bool ContainsAmount(IItemMeta itemMeta, uint amount)
        {
            if (amount == 0)
            {
                ZeroAmountWarning("find operation");
                return false;
            }

            var allSlotsContainsItem = _container.Slots.Where(slot => slot.Item.Equals(itemMeta)).ToList();

            if (allSlotsContainsItem != null && allSlotsContainsItem.Count > 0)
            {
                var sumAllValues = allSlotsContainsItem.Sum(slot => slot.Amount);

                return sumAllValues >= amount;
            }

            return false;
        }

        /// <summary>
        /// В случае успеха добавляет предмет в указанном кол-ве в первый свободный слот.
        /// В случае необходимости кол-во распределяется по свободным слотам.
        /// </summary>
        /// <param name="itemMeta"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        public bool TryAddItem(IItemMeta itemMeta, uint amount)
        {
            if (IsFull)
                return false;

            if (amount == 0)
            {
                ZeroAmountWarning("add operation");
                return false;
            }

            var notFullSlots = _container.Slots.Where(slot => (slot.Item.Equals(itemMeta) && !slot.IsFull) || slot.IsEmpty).ToList();

            if (notFullSlots != null && notFullSlots.Count() > 0)
            {
                if (CanAddInFreeSlots(notFullSlots, itemMeta, amount))
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

        public bool TryAddItemInSlot(int slotIndex, IItemMeta itemMeta, uint amount)
        {
            if (amount == 0)
            {
                ZeroAmountWarning("add operation");
                return false;
            }

            var slot = _container.Slots[slotIndex];

            if (slot.IsFull)
                return false;

            if (slot.IsEmpty || slot.Item.Equals(itemMeta))
            {
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
            }

            return false;
        }

        /// <summary>
        /// В случае успеха удаляет указанный предмет в указанном кол-ве.
        /// В случае необходимости обходит все слоты содержащие предмет.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        public bool TryRemoveItem(IItemMeta item, uint amount)
        {
            if (amount == 0)
            {
                ZeroAmountWarning("remove operation"); ;
                return false;
            }

            if (ContainsAmount(item, amount))
            {
                var containsSlots = _container.Slots.Where(slot => (slot.Item.Equals(item))).ToList();

                for (int i = 0; i < containsSlots.Count; i++)
                {
                    var slot = containsSlots[i];

                    if (CanRemoveFromSlot(slot, amount))
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

        public bool TryRemoveItemFromSlot(int slotIndex, IItemMeta item, uint amount)
        {
            if (amount == 0)
            {
                ZeroAmountWarning("remove operation"); ;
                return false;
            }

            var slot = _container.Slots[slotIndex];

            if (slot.Item.Equals(item) && slot.Amount >= amount)
            {
                slot.Amount -= amount;

                TryClearSlot(slot);

                NotificateListeners(item, amount, ItemRemoved);
                return true;
            }

            return false;
        }

        public void ClearSlot(int slotIndex)
        {
            var item = _container.Slots[slotIndex].Item;
            var amount = _container.Slots[slotIndex].Amount;

            _container.Slots[slotIndex].Item = null;
            _container.Slots[slotIndex].Amount = 0;

            NotificateListeners(item, amount, ItemRemoved);
        }
      
        public void ClearAllSlots()
        {
            for (int i = 0; i < _container.Slots.Count; i++)
            {
                ClearSlot(i);
            }
        }

        /// <summary>
        /// Проверяет нужно ли присвоить полю Item null, если кол-во в слоте уже равно 0
        /// </summary>
        /// <param name="slot"></param>
        /// <returns>Да/Нет</returns>
        private bool TryClearSlot(IContainerSlot slot)
        {
            if (slot.Amount == 0)
            {
                slot.Item = null;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяет возможность добавить необходимое кол-во предметов в указанный слот
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="itemMeta"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        private bool CanAddInSlot(IContainerSlot slot, IItemMeta itemMeta, uint amount)
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

        /// <summary>
        /// Проверяет можно ли добавить в свободные слоты предмет в нужном кол-ве
        /// </summary>
        /// <param name="freeSlots"></param>
        /// <param name="itemMeta"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        private bool CanAddInFreeSlots(List<IContainerSlot> freeSlots, IItemMeta itemMeta, uint amount)
        {
            for (int i = 0; i < freeSlots.Count(); i++)
            {
                var slot = freeSlots[i];

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

        /// <summary>
        /// Проверяет можно ли удалить нужное кол-во из слота
        /// </summary>
        /// <param name="slot"></param>
        /// <param name="amount"></param>
        /// <returns>Да/Нет</returns>
        private bool CanRemoveFromSlot(IContainerSlot slot, uint amount)
        {
            if (!slot.IsEmpty)
            {
                return slot.Amount >= amount;
            }
            return false;
        }

        /// <summary>
        /// Бросает исключение, если при выполнении операции в метод был передано нулевое кол-во
        /// </summary>
        /// <param name="operation"></param>
        private void ZeroAmountWarning(string operation)
            => new ArgumentException($"Amount cannot be 0 -{operation}- Container {_container.NameID}");

        /// <summary>
        /// Активирует необходимый эвент уведомляя подписчика о проведённой операции
        /// </summary>
        /// <param name="item"></param>
        /// <param name="amount"></param>
        /// <param name="action"></param>
        private void NotificateListeners(IItemMeta item, uint amount, Action<IItemMeta, uint> action)
            => action?.Invoke(item, amount);
    }
}