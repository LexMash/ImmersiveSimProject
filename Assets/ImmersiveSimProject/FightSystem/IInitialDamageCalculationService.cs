using ImmersiveSimProject.DamageSystem.Data;

namespace ImmersiveSimProject.FightSystem
{
    public interface IInitialDamageCalculationService
    {
        public Damage Calculate(ICharacter attacker); 
    }
}
