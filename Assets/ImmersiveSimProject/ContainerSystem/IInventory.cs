namespace ImmersiveSimProject.ContainerSystem
{
    public interface IInventory : IContainer
    {
        public void Expand(uint slotAmount);
        //public void Sort();
    }
}
