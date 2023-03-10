using System;
using UnityEngine;

namespace ImmersiveSimProject.ContainerSystem
{
    public class ContainerView : MonoBehaviour, INamed
    {
        [SerializeField] private string _nameID;
        [SerializeField] private string _descriptionID;
        public string NameID => _nameID;
        public string DescriptionID => _descriptionID;

        public event Action<string> Opened;
    }
}