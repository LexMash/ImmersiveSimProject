using ImmersiveSimProject.ItemsSystem;
using UnityEngine;

namespace ImmersiveSimProject.ContainerSystem.Implementation
{
    /// <summary>
    /// Класс для тестирования
    /// </summary>
    public class Meta : IItemMeta
    {
        public Sprite Icon { get; private set; }

        public ItemView Visual { get; private set; }

        public string RecipeNameID { get; private set; }

        public uint Cost { get; private set; }

        public float Weight { get; private set; }

        public uint MaxCapacityInSlot { get; private set; }

        public string NameID { get; private set; }

        public string DescriptionID { get; private set; }

        public Meta(Sprite icon, ItemView visual, string recipeNameID, uint cost, float weight, uint maxCapacityInSlot, string nameID, string descriptionID)
        {
            Icon = icon;
            Visual = visual;
            RecipeNameID = recipeNameID;
            Cost = cost;
            Weight = weight;
            MaxCapacityInSlot = maxCapacityInSlot;
            NameID = nameID;
            DescriptionID = descriptionID;
        }
    }
}
