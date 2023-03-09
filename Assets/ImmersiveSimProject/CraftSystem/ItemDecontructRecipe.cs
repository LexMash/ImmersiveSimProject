using ImmersiveSimProject.ItemsSystem;
using System.Collections.Generic;
using UnityEngine;

namespace ImmersiveSimProject.CraftSystem
{
    public class ItemDecontructRecipe
    {
        [field: SerializeField] public Item Ingredient { get; private set; }
        [field: SerializeField] public List<Item> Results { get; private set; }

        public string NameID => Ingredient.NameID;
        public string DescriptionID => Ingredient.DescriptionID;
    }
}
