using ImmersiveSimProject.Effects;
using ImmersiveSimProject.Interactions;

namespace ImmersiveSimProject.FightSystem
{
    public interface IWeapon
    {
        public string NameID { get; }
        public uint MaxDamage { get; }
        public uint MinDamage { get; }
        public uint CriticalDamagePercent { get; }
        public uint CriticalMultiplier { get; }
        public InteractionType DamageType { get; }
        public IApplyableEffect[] Effect { get; }
        public bool IgnoreResistance { get; }
    }
}