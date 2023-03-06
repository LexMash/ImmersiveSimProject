using ImmersiveSimProject.Interactions;

namespace ImmersiveSimProject.Effects.Types
{
    public interface IReflectionEffect : IApplyableEffect
    {
        public InteractionType DamageType { get; }
        public uint ReflectionPercentage { get; }
    }
}
