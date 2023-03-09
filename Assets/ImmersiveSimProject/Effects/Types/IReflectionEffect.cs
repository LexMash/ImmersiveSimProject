using ImmersiveSimProject.Interactions;

namespace ImmersiveSimProject.Effects.Types
{
    public interface IReflectionEffect : IEffect
    {
        public InteractionType DamageType { get; }
        public uint ReflectionPercentage { get; }
    }
}
