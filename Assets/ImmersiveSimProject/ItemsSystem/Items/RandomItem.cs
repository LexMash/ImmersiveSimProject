using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem
{
    public class RandomItem : ScriptableObject, IItem
    {
        //условия для метода инициализации
        //[SerializeField] private string[] NameIDs;
        //[SerializeField] private uint _statValue;

        public string NameID => GetIRandomItem().NameID;
        public string DescriptionID => GetIRandomItem().DescriptionID;
        public ItemCategory Category => GetIRandomItem().Category;
        public Sprite Icon => GetIRandomItem().Icon;
        public ItemView Visual => GetIRandomItem().Visual;
        public string[] ComponentIDs => GetIRandomItem().ComponentIDs;

        private readonly IItem _item;

        private IItem GetIRandomItem()
        {
            if(_item == null)
            {
                //обращение к фиче и получение случайного чего нибудь
                //_item = ItemsDataBaseFeature.GetRandomItem();
            }

            return _item;
        }
    }
}
