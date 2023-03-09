using System.Collections.Generic;
using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem
{
    //класс используется для первого наполнения контейнера, если нет сохранения

    [CreateAssetMenu(fileName = "ContainerDefaultState", menuName = "Application/Containers/ContainerDefaultState")]
    public class ContainerDefaultState : ScriptableObject
    {
        [SerializeField] private string _nameID;
        [SerializeField] private Item[] _items;

        public string NameID => _nameID;
        public IReadOnlyList<IItem> Items => _items;
    }
}
