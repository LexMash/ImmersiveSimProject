namespace ImmersiveSimProject.FightSystem
{
    public interface IHitChanceCalculationService
    {
        public bool AttackSuccessful(ICharacter attacker, ICharacter target);
    }
}
