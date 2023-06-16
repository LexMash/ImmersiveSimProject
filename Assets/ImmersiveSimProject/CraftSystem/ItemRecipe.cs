using ImmersiveSimProject.ItemsSystem;
using System.Collections.Generic;
using UnityEngine;

namespace ImmersiveSimProject.Craft
{
    [CreateAssetMenu(fileName = "ItemRecipe", menuName = "Immersive/Craft/ItemRecipe")]
    public class ItemRecipe : ScriptableObject, INamed
    {
        [field: SerializeField] public ItemMeta Result { get; private set; }
        [field: SerializeField] public List<ItemMeta> Ingredients { get; private set; }

        public string NameID => Result.NameID;
        public string DescriptionID => Result.DescriptionID;       
    }
}