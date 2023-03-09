using ImmersiveSimProject.Effects;
using ImmersiveSimProject.Interactions;

namespace ImmersiveSimProject.ItemsSystem
{
    public interface IWeapon : IItem
    {
        public uint MaxDamage { get; }
        public uint MinDamage { get; }
        public uint CriticalDamagePercent { get; }
        public float CriticalMultiplier { get; }
        public InteractionType DamageType { get; }
        public IEffect[] Effect { get; }
        public bool IgnoreResistance { get; }
    }
}