using Unity.VisualScripting;

namespace ImmersiveSimProject.ContainerSystem
{
    //инвентарь тот же контейнер, но можно придумать расширение
    public class Inventory : Container
    {
        public Inventory(string nameID, string descriptionID, ContainerSlot[] slots) : base(nameID, descriptionID, slots) { }

        public void Expand(uint slotAmount)
        {
            for(uint i = 0; i > slotAmount; i++) 
            {
                _slots.Add(new ContainerSlot(null, 0));
            }
        }

        //public void Sort()
        //{
        //    _slots.Sort();
        //}
    }
}
