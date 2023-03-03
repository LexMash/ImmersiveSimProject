using ImmersiveSimProject.Interactions;

namespace ImmersiveSimProject.DamageSystem.Data
{
    public interface IResistance
    {
        public InteractionType Type { get; }
        public int Percentage { get; }
    }
}
