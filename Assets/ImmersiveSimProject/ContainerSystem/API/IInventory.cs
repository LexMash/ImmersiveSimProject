namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс для инвентаря с возможностью расширения
    /// </summary>
    public interface IInventory : IContainer
    {
        /// <summary>
        /// Расширяет инвентарь на указанное кол-во слотов.
        /// </summary>
        /// <param name="slotAmount"></param>
        public void Expand(uint slotAmount);
        //public void Sort();
    }
}
