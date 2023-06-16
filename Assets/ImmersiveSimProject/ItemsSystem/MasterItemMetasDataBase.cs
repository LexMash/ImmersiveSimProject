using System;
using System.Collections.Generic;

namespace ImmersiveSimProject.ItemsSystem
{
    public class MasterItemMetasDataBase : IMasterItemMetasDataBase
    {
        private readonly SortedDictionary<string, IItemMeta> _itemMetasMap = new();

        public MasterItemMetasDataBase(IItemMeta[] itemMetas) 
        { 
            foreach(var item in itemMetas)
            {
                _itemMetasMap[item.NameID] = item;
            }
        }

        public IItemMeta GetItemMetaByNameID(string nameID)
        {
            if (string.IsNullOrEmpty(nameID))
            {
                throw new Exception($"Your nameID request  is null or empty. Master Items DataBase");
            }

            if (_itemMetasMap.ContainsKey(nameID))
            {
                return _itemMetasMap[nameID];
            }

            throw new Exception($"Master Items Data Base not contains item with {nameID}.");
        }
    }
}
