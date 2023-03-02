using ImmersiveSimProject.DamageSystem.Data;

namespace ImmersiveSimProject.Effects
{
    public interface IDamageableEffect : IApplyableEffect
    {
        public Damage Damage { get; }
    }
}
