using ImmersiveSimProject.ContainerSystem.API;
using ImmersiveSimProject.ContainerSystem.Data;
using ImmersiveSimProject.ItemsSystem;
using ImmersiveSimProject.ItemsSystem.Data;
using ImmersiveSimProject.StaticServices;
using System;
using System.Collections.Generic;

namespace ImmersiveSimProject.ContainerSystem.Implementation
{
    public class ContainerContructor : IContainerConstructor
    {
        private readonly IContainerSlotFactory _slotFactory;
        private readonly uint _containerDefaultCapacity;
        private readonly IMasterItemMetasDataBase _itemsDataBase;

        public ContainerContructor(IContainerSlotFactory slotFactory, IMasterItemMetasDataBase itemsDataBase, uint containerDefaultCapacity)
        {
            if(containerDefaultCapacity == 0)
                Exceptions.ArgumentValueIsZero("class contruction", GetType());

            _slotFactory = slotFactory;
            _itemsDataBase = itemsDataBase;
            _containerDefaultCapacity = containerDefaultCapacity;
        }

        public IContainer CreateFromDefaultState(ContainerDefaultState defaultState)
        {
            CheckInputCapacity(defaultState.GetType(), defaultState.NameID, defaultState.Slots.Length);

            SOSlot[] soSlots = defaultState.Slots;

            List<IContainerSlot> containerSlots = new();

            for (int i = 0; i < soSlots.Length; i++)
            {
                CreateAndFillSlot(defaultState, soSlots, containerSlots, i);
            }

            var nameID = defaultState.NameID;
            var descriptionID = defaultState.DescriptionID;

            return GetContainer(containerSlots, nameID, descriptionID);
        }              

        public IContainer CreateFromSaveData(ContainerDTO containerDTO)
        {
            CheckInputCapacity(containerDTO.GetType(), containerDTO.NameID, containerDTO.Slots.Length);

            List<IContainerSlot> containerSlots = new();

            for (int i = 0; i < containerDTO.Slots.Length; i++)
            {
                var slot = containerDTO.Slots[i];
                var itemName = slot.ItemNameID;
                var amount = slot.Amount;

                IItemMeta itemMeta = _itemsDataBase.GetItemMetaByNameID(itemName);

                CheckAmountOfItemInSlot(containerDTO.GetType(), itemName, containerDTO.NameID, amount / itemMeta.MaxCapacityInSlot);

                IContainerSlot newSlot = _slotFactory.GetSlot(itemMeta, amount);

                containerSlots.Add(newSlot);
            }

            var nameID = containerDTO.NameID;
            var descriptionID = containerDTO.DescriptionID;

            return GetContainer(containerSlots, nameID, descriptionID);
        }

        private IContainer GetContainer(List<IContainerSlot> containerSlots, string nameID, string descriptionID)
        {
            return new Container(nameID, descriptionID, _slotFactory, containerSlots.ToArray(), _containerDefaultCapacity);
        }

        private void CreateAndFillSlot(ContainerDefaultState defaultState, SOSlot[] soSlots, List<IContainerSlot> containerSlots, int i)
        {
            SOSlot loadedSlot = soSlots[i];

            var maxCapacity = loadedSlot.ItemMeta.MaxCapacityInSlot;
            var amount = loadedSlot.Amount;
            var itemMeta = loadedSlot.ItemMeta;
            var slotsNeeded = amount / maxCapacity;

            CheckAmountOfItemInSlot(defaultState.GetType(), loadedSlot.ItemMeta.NameID, defaultState.NameID, slotsNeeded);

            for (int k = 0; k < slotsNeeded; k++)
            {
                IContainerSlot newSlot = _slotFactory.GetSlot(null, 0);

                newSlot.Item = itemMeta;

                var canBeAddedAmount = amount > maxCapacity ? maxCapacity : amount;
                newSlot.Amount += canBeAddedAmount;
                amount -= canBeAddedAmount;

                containerSlots.Add(newSlot);
            }       
        }

        private void CheckAmountOfItemInSlot(Type type, string itemName, string containerName, uint slotNeeded)
        {
            if (slotNeeded > _containerDefaultCapacity)
            {
                throw new ArgumentException(
                    $"{type} - the number of items {itemName} " +
                    $"in the SOSlot from Container {containerName} " +
                    $"cannot be allocated to the container");
            }
        }

        private void CheckInputCapacity(Type type, string nameID, int capacity)
        {
            if (capacity > _containerDefaultCapacity)
            {
                throw new ArgumentException(
                    $"{type} - Container {nameID} " +
                    $"have more slots then containerDefaultCapacity");
            }
        }
    }
}
