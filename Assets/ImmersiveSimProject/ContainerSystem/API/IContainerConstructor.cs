using ImmersiveSimProject.ContainerSystem.Data;
using ImmersiveSimProject.ItemsSystem.Data;

namespace ImmersiveSimProject.ContainerSystem.API
{
    /// <summary>
    /// Основной интерфейс сборщика контейнера из сохранённого состояния или из состояния по умолчанию
    /// </summary>
    public interface IContainerConstructor
    {
        /// <summary>
        /// Собирает контейнер из состояния по умолчанию
        /// </summary>
        /// <param name="defaultState"></param>
        /// <returns></returns>
        IContainer CreateFromDefaultState(ContainerDefaultState defaultState);

        /// <summary>
        /// Собирает контейнер из сохранённого состояния
        /// </summary>
        /// <param name="containerDTO"></param>
        /// <returns></returns>
        IContainer CreateFromSaveData(ContainerDTO containerDTO);
    }
}
