using ImmersiveSimProject.CraftSystem;
using ImmersiveSimProject.ItemsSystem;
using System.Linq;
using UnityEngine;

namespace ImmersiveSimProject.Craft
{
    //как то это шибко примитивно... надо еще подумать над этим

    [CreateAssetMenu(fileName = "CraftTable", menuName = "Immersive/Converter/CraftTable")]
    public class CraftTable : ScriptableObject, ICraftTable<IItem, string>
    {
        [field: SerializeField] public Sprite Icon { get; private set; }
        [SerializeField] private string _nameID;
        [SerializeField] private string _descriptionID;       
        [SerializeField] private ItemContructRecipe[] _recipes;

        public string NameID => _nameID;
        public string DescriptionID => _descriptionID;

        public IItem Construct(params string[] itemsNameIDs)
        {
            var results = _recipes.Where(i => i.Ingredients.Count == itemsNameIDs.Length).ToList();

            for (int i = 0; i < itemsNameIDs.Length; i++)
            {
                //требуется получить доступ к базе данных всех предметов

                //var itemByID = GetItemByID();
                //results = results.Where(recipe => recipe.Targets.Contains() == true;

                //if (results.Count() == 0)
                //    return null;

                //results = results.ToList();
            }

            return results.First().Result;
        }

        public IItem[] Deconstruct(string itemsNameID)
        {
            return _recipes.FirstOrDefault(recipe => recipe.Result.NameID == itemsNameID).Ingredients.ToArray();
        }
    }
}
