using System;
using UnityEngine;

namespace ImmersiveSimProject.ContainerSystem
{
    public class ContainerView : MonoBehaviour, INamed
    {
        public event Action<string> Opened;
        //TODO
        public string NameID => throw new System.NotImplementedException();

        public string DescriptionID => throw new System.NotImplementedException();
    }
}
