using ImmersiveSimProject.DamageSystem.Data;

namespace ImmersiveSimProject.Effects.Types
{
    public interface IDamageableEffect : IMultiTimeEffect
    {
        public Damage Damage { get; }
    }
}
