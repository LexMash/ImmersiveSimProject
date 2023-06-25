using System.Collections.Generic;
using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem.Data
{
    /// <summary>
    /// Кофигурация базового состояния контейнера для первичной инициализации, если нет сохраннёных данных
    /// </summary>
    [CreateAssetMenu(fileName = "ContainerDefaultState", menuName = "Application/Containers/ContainerDefaultState")]
    public class ContainerDefaultState : ScriptableObject
    {
        [SerializeField] private string _nameID;
        [SerializeField] private string _descriptionID;
        [SerializeField] private ItemMeta[] _items;

        public string NameID => _nameID;
        public string DescriptionID => _descriptionID;
        public IReadOnlyList<IItemMeta> Items => _items;
    }
}
