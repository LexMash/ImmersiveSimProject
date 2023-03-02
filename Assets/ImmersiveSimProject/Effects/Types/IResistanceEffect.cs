using ImmersiveSimProject.DamageSystem.Data;

namespace ImmersiveSimProject.Effects
{
    public interface IResistanceEffect : IApplyableEffect
    {
        public IResistance ResistanceModificator { get; }
    }
}
