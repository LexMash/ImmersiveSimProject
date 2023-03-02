namespace ImmersiveSimProject.DamageSystem
{
    public interface IHealeable
    {
        public bool TryHealing(uint value);
    }
}
