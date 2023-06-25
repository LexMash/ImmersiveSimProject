namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс для инвентаря с возможностью расширения
    /// </summary>
    public interface IInventory : IContainer
    {
        public void Expand(uint slotAmount);
        //public void Sort();
    }
}
