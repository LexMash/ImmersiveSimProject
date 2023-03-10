using ImmersiveSimProject.Effects;
using ImmersiveSimProject.Interactions;
using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem.Items
{
    public abstract class Weapon : ScriptableObject, IWeapon
    {
        [field: SerializeField] public string NameID { get; private set; }
        [field: SerializeField] public string DescriptionID { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public ItemView Visual { get; private set; }
        [field: SerializeField] public string RecipeNameID { get; private set; }
        [field: SerializeField] public uint Cost { get; private set; }
        [field: SerializeField] public float Weight { get; private set; }
        [field: SerializeField] public uint MaxCapacityInSlot { get; private set; } = 1;
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
