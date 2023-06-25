namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс для всех сервиса контейнеров
    /// </summary>
    public interface IContainerService<I>
    {
        IContainerController GetContainer(I identificator);
    }
}