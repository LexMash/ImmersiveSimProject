using ImmersiveSimProject.ContainerSystem.Enums;
using System;
using UnityEngine;

namespace ImmersiveSimProject.ContainerSystem.View
{
    /// <summary>
    /// Пример класса для создания контейнера в сцене.
    /// Интеграция с внешними системами TODO
    /// </summary>
    public class ContainerViewBase : MonoBehaviour, INamed
    {
        [SerializeField] private string _nameID;
        [SerializeField] private string _descriptionID;
        [SerializeField] private ContainerType _type;

        public string NameID => _nameID;
        public string DescriptionID => _descriptionID;
        public ContainerType Type => _type;

        public event Action<string> Opened;
    }
}