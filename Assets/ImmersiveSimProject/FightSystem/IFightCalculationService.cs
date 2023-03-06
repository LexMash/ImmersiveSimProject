namespace ImmersiveSimProject.FightSystem
{
    public interface IFightCalculationService
    {
        public bool CalculateTheSuccesOFTheAttack(ICharacter attacker, ICharacter target);
    }
}
