using ImmersiveSimProject.Effects;
using ImmersiveSimProject.Interactions;
using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem.Items
{
    public abstract class WeaponMeta : ItemMeta, IWeaponMeta
    {
        [field:SerializeField] public uint MaxDamage { get; private set; }
        [field:SerializeField] public uint MinDamage { get; private set; }
        [field:SerializeField] public uint CriticalDamagePercent { get; private set; }
        [field:SerializeField] public float CriticalMultiplier { get; private set; }
        [field:SerializeField] public InteractionType DamageType { get; private set; }
        [field:SerializeField] public bool IgnoreResistance { get; private set; }
        [field:SerializeField] public IEffect[] Effects { get; private set; } //тут надо что то думать...
        [field:SerializeField] public Vector3 GripPosition { get; private set; }
        [field:SerializeField] public AnimationClip IdleAnimation { get; private set; }
        [field:SerializeField] public AnimationClip AttackAnimation { get; private set; }
        [field:SerializeField] public AnimationClip MoveAnimation { get; private set; }
    }
}
