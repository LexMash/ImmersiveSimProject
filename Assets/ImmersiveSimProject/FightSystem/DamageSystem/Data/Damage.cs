using ImmersiveSimProject.Effects;
using ImmersiveSimProject.Interactions;

namespace ImmersiveSimProject.DamageSystem.Data
{
    public readonly struct Damage
    {
        public uint Value { get; }
        public InteractionType Type { get; }
        public IApplyableEffect[] Effects { get; }
        public bool IgnoreResistance { get; }
        public bool IsCritical { get; }

        public Damage(uint value, InteractionType type, bool ignoreResistance, bool isCritical = false, params IApplyableEffect[] effect)
        {
            Value = value;
            Type = type;
            Effects = effect;
            IgnoreResistance = ignoreResistance;
            IsCritical = isCritical;
        }
    }
}
