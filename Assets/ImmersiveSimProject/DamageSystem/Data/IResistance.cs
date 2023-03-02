namespace ImmersiveSimProject.DamageSystem.Data
{
    public interface IResistance
    {
        public DamageType Type { get; }
        public int Percentage { get; }
    }
}
