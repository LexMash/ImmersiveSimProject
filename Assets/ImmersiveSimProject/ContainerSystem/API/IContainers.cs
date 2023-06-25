namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс для всех контейнеров в игре
    /// </summary>
    public interface IContainers : IReadOnlyEncapsulatedCollection<IContainer, string>
    {
    }
}
