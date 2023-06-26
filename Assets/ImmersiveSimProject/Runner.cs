using UnityEngine;
using ImmersiveSimProject.ContainerSystem.API;
using ImmersiveSimProject.ContainerSystem.Implementation;
using ImmersiveSimProject.ItemsSystem;
using ImmersiveSimProject.ItemsSystem.Data;
using System.Collections.Generic;

public class Runner : MonoBehaviour
{
    IContainerController _controller;
    IItemMeta[] _metas;

    private void Start()
    {
        IContainerSlotFactory containerSlotFactory = new ContainerSlotFactory();
        IContainerSlot[] slots = new ContainerSlot[10];

        ContainerDefaultState[] containerDefaultState = Resources.LoadAll<ContainerDefaultState>("");

        List<IContainer> containerList = new();

        if (containerDefaultState != null && containerDefaultState.Length > 0)
        {
            for (int i = 0; i < containerDefaultState.Length; i++)
            {
                var nameID = containerDefaultState[i].NameID;
                var description = containerDefaultState[i].DescriptionID;
                var loadedSlots = containerDefaultState[i].Slots;

                List<IContainerSlot> containerSlots = new();

                foreach (var loadedSlot in loadedSlots)
                {                 
                    var max = loadedSlot.ItemMeta.MaxCapacityInSlot;
                    var amount = loadedSlot.Amount;
                    var iterationsAmount = amount/max;

                    for(int k = 0; k < iterationsAmount; k++)
                    {
                        var newSlot = containerSlotFactory.GetSlot();

                        bool CanAddInSlot(IContainerSlot slot, IItemMeta itemMeta, uint amount)
                        {
                            if (!slot.IsEmpty)
                            {
                                return slot.Amount + amount <= slot.Item.MaxCapacityInSlot;
                            }
                            else
                            {
                                return itemMeta.MaxCapacityInSlot >= amount;
                            }
                        }

                        if (CanAddInSlot(newSlot, loadedSlot.ItemMeta, amount))
                        {
                            if (newSlot.IsEmpty)
                            {
                                newSlot.Item = loadedSlot.ItemMeta;
                                newSlot.Amount = 0;
                            }

                            newSlot.Amount += amount;
                        }
                        else
                        {
                            if (newSlot.IsEmpty)
                            {
                                newSlot.Item = loadedSlot.ItemMeta;
                                newSlot.Amount = 0;
                            }

                            var canBeAddedAmount = amount > loadedSlot.ItemMeta.MaxCapacityInSlot ? loadedSlot.ItemMeta.MaxCapacityInSlot : amount;
                            newSlot.Amount += canBeAddedAmount;
                            amount -= canBeAddedAmount;
                        }

                        containerSlots.Add(newSlot);
                    }
                }

                containerList.Add(new Container(nameID, description, containerSlotFactory, containerSlots.ToArray(), 9));
            }
        }

        IContainers containers = new Containers(containerList.ToArray());
        IContainerService<string> containerService = new ContainerService(containers);
        _controller = containerService.GetContainer("test1");

        _metas = new Meta[] 
            { new Meta(null, null, "", 1, 2f, 5, "apple", "")
            , new Meta(null, null, "", 1, 2f, 3, "orange", "")
            , new Meta(null, null, "", 1, 2f, 1, "sword", "")
            , new Meta(null, null, "", 1, 2f, 2, "arrow", "")};

        PrintInventory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //var index = Random.Range(0, _metas.Length);
            //uint amount = (uint)Random.Range(1, 10);
            IItemMeta item = _metas[3];

            Debug.Log($"Add item {item.NameID} - {2} - {_controller.TryAddItemInSlot(0,item, 2)}");

            PrintInventory();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //var index = Random.Range(0, _metas.Length);
            //uint amount = (uint)Random.Range(1, 10);
            IItemMeta item = _metas[3];

            Debug.Log($"Remove item {item.NameID} - {1} - {_controller.TryRemoveItemFromSlot(0 ,item, 1)}");

            PrintInventory();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var index = Random.Range(0, _controller.Capacity);
            _controller.ClearSlot(index);

            Debug.Log($"Remove item from slot number {index}");
            PrintInventory();
        }
    }

    private void PrintInventory()
    {
        for (int i = 0; i < _controller.Slots.Count; i++)
        {
            IReadOnlyContainerSlot slot = _controller.Slots[i];

            if (!slot.IsEmpty)
            {
                Debug.Log("slot number " + i + " " + slot.Item.NameID + " " + slot.Amount);
            }
            else
            {
                Debug.Log("slot number " + i + " is empty");
            }
        }
    }
}
