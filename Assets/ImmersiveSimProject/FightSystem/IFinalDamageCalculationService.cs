using ImmersiveSimProject.DamageSystem.Data;

namespace ImmersiveSimProject.FightSystem
{
    public interface IFinalDamageCalculationService
    {
        public Damage Calculate(ICharacter target, Damage damage);
    }
}
