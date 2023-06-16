using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem
{
    public abstract class ItemMeta : ScriptableObject, IItemMeta
    {
        [field: SerializeField] public string NameID { get; private set; }
        [field: SerializeField] public string DescriptionID { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public ItemView Visual { get; private set; }
        [field: SerializeField] public string RecipeNameID { get; private set; }
        [field: SerializeField] public uint Cost { get; private set; }
        [field: SerializeField] public float Weight { get; private set; }
        [field: SerializeField] public uint MaxCapacityInSlot { get; private set; }
    }
}
