using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem
{
    //класс что бы нельзя было в SO Item засунуть любой GameObject
    public class ItemView : MonoBehaviour, INamed
    {
        //TODO
        public string NameID => throw new System.NotImplementedException();
        public string DescriptionID => throw new System.NotImplementedException();
    }
}
