using System;
using System.Collections.Generic;

namespace ImmersiveSimProject.ItemsSystem
{
    public class MasterItemsDataBase : IMasterItemsDataBase
    {
        private readonly SortedDictionary<string, IItem> _itemsMap = new();

        public MasterItemsDataBase(IItem[] items) 
        { 
            foreach(var item in items)
            {
                _itemsMap[item.NameID] = item;
            }
        }

        public IItem GetItemByNameID(string nameID)
        {
            if (string.IsNullOrEmpty(nameID))
            {
                throw new Exception($"Your nameID request  is null or empty. Master Items DataBase");
            }

            if (_itemsMap.ContainsKey(nameID))
            {
                return _itemsMap[nameID];
            }

            throw new Exception($"Master Items Data Base not contains item with {nameID}.");
        }
    }
}
