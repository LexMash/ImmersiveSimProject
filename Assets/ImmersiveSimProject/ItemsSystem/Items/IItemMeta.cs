using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem
{
    public interface IItemMeta : INamed
    {
        public Sprite Icon { get; }
        public ItemView Visual { get; }     
        public string RecipeNameID { get; }
        public uint Cost { get; }
        public float Weight { get; }
        public uint MaxCapacityInSlot { get; } 
    }
}
