using ImmersiveSimProject.DamageSystem.Data;

namespace ImmersiveSimProject.Effects
{
    public interface IResistanceEffect : IApplyableEffect
    {
        public Resistance ResistanceModificator { get; }
    }
}
