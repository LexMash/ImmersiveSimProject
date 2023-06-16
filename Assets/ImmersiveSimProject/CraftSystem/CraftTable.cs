using ImmersiveSimProject.CraftSystem;
using ImmersiveSimProject.ItemsSystem;
using System.Linq;
using UnityEngine;

namespace ImmersiveSimProject.Craft
{
    //как то это шибко примитивно... надо еще подумать над этим

    [CreateAssetMenu(fileName = "CraftTable", menuName = "Immersive/Craft/CraftTable")]
    public class CraftTable : ScriptableObject, ICraftTable<IItemMeta, string>
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [SerializeField] private string _nameID;
        [SerializeField] private string _descriptionID;       
        [SerializeField] private ItemRecipe[] _recipes;

        public string NameID => _nameID;
        public string DescriptionID => _descriptionID;

        public IItemMeta Construct(params string[] ingredientsNameIDs)
        {
            var results = _recipes.Where(i => i.Ingredients.Count == ingredientsNameIDs.Length);

            for (int i = 0; i < ingredientsNameIDs.Length; i++)
            {
                results = results.Where(recipe => recipe.Ingredients.Any(item => item.NameID == ingredientsNameIDs[i]));

                if (results.Count() == 0)
                    return null;
            }

            return results.First().Result;
        }

        public IItemMeta[] Deconstruct(string itemsNameID)
        {
            return _recipes.FirstOrDefault(recipe => recipe.NameID == itemsNameID).Ingredients.ToArray();
        }
    }
}
