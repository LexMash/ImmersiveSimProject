using FromTheBasement.Data.ContainerSystem;

namespace ImmersiveSimProject.ContainerSystem
{
    //инвентарь тот же контейнер, но можно придумать расширение
    public class Inventory : Container
    {
        public Inventory(ContainerSlot[] slots, string nameID = "Inventory") : base(nameID, slots) { }
    }
}
