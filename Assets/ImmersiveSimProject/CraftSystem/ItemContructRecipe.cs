using ImmersiveSimProject.ItemsSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ImmersiveSimProject.Craft
{
    [Serializable]
    public class ItemContructRecipe
    {
        [field: SerializeField] public Item Result { get; private set; }
        [field: SerializeField] public List<Item> Ingredients { get; private set; }

        public string NameID => Result.NameID;
        public string DescriptionID => Result.DescriptionID;
        
    }
}
