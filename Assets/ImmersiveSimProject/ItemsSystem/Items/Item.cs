using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem
{
    [CreateAssetMenu(fileName = "Item", menuName = "Immersive/Items/Item")]
    public class Item : ScriptableObject, IItem
    {
        [SerializeField] private string _nameID;
        [SerializeField] private string _descriprionID;
        [SerializeField] private ItemCategory _category;

        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemView _visual;
        
        [SerializeField] private string[] _componentIDs; //возможно стоит заменить на Item, что бы не ошибаться в ID

        public string NameID => _nameID;
        public string DescriptionID => _descriprionID;
        public ItemCategory Category => _category;
        public Sprite Icon => _icon;
        public ItemView Visual => _visual;       
        public string[] ComponentIDs => _componentIDs;       
    }
}
