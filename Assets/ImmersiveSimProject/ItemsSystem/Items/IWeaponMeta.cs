using ImmersiveSimProject.Effects;
using ImmersiveSimProject.Interactions;
using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem
{
    public interface IWeaponMeta : IItemMeta
    {
        public uint MaxDamage { get; }
        public uint MinDamage { get; }
        public uint CriticalDamagePercent { get; }
        public float CriticalMultiplier { get; }
        public InteractionType DamageType { get; }
        public IEffect[] Effects { get; }
        public bool IgnoreResistance { get; }
        public Vector3 GripPosition { get; }
        public AnimationClip IdleAnimation { get; }
        public AnimationClip AttackAnimation { get; }
        public AnimationClip MoveAnimation { get; }
        //и еще куча других анимаций, которые необходимы
    }
}