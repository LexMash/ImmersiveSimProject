using ImmersiveSimProject.DamageSystem.Data;

namespace ImmersiveSimProject.FightSystem
{
    public interface IFinalDamageCalculator
    {
        public Damage Calculate(Damage damage);
    }
}
