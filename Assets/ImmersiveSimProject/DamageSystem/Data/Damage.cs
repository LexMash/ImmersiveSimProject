using ImmersiveSimProject.Effects;

namespace ImmersiveSimProject.DamageSystem.Data
{
    public readonly struct Damage
    {
        public uint Value { get; }
        public DamageType Type { get; }
        public IApplyableEffect[] Effect { get; }
        public bool IgnoreResistance { get; }

        public Damage(uint value, DamageType type, bool ignoreResistance, params IApplyableEffect[] effect)
        {
            Value = value;
            Type = type;
            Effect = effect;
            IgnoreResistance = ignoreResistance;
        }
    }
}
