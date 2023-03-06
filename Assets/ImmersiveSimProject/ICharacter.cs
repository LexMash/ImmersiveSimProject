using ImmersiveSimProject.FightSystem.DamageSystem;
using ImmersiveSimProject.FightSystem.HealthSystem;
using ImmersiveSimProject.FightSystem.HealthSystem.Data;

namespace ImmersiveSimProject
{
    public interface ICharacter : IDamageable, IHealable, IAttacker
    {
        public string NameID { get; }
        public string DescriptionID { get; }
        public Health Health { get; } //можно каждый раз возвращать новый объект с данными из хендлера
    }

    //можно статы разложить в энам и положить в словарь и каждый раз доставать по ключу
    //можно сделать требуемое кол-во полей под них
    //под каждый стат хэндлер
}
