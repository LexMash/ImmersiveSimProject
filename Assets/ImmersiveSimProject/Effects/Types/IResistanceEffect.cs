using ImmersiveSimProject.DamageSystem.Data;

namespace ImmersiveSimProject.Effects
{
    public interface IResistanceEffect : IEffect
    {
        public Resistance ResistanceModificator { get; }
    }
}
