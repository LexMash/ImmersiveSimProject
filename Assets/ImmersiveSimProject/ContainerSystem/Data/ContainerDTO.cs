using System;

namespace ImmersiveSimProject.ContainerSystem.Data
{
    [Serializable]
    public struct ContainerDTO
    {
        public string NameID;
        public string DescriptionID;
        public ContainerSlotDTO[] Slots;
    }
}
