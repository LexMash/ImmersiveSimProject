using ImmersiveSimProject.ItemsSystem;

namespace ImmersiveSimProject.ContainerSystem
{
    //это обёртка на случай, если вы хотите добавить вещам дополнительные свойства
    //например - прочность
    //соответственно в инвентарь и контейнеры уже добавляем обёртку и сохраняем состояние обёртки
    //в виде - ID вещи + данные из обёртки
    public interface ICharacterItem
    {
        public IItem Item { get; }
        public uint Strength { get; } //пример
    }
}
