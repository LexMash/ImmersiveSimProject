using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.Effects;
using System;

namespace ImmersiveSimProject.DamageSystem
{
    public interface IDamageable
    {      
        public event Action<IDamageable, uint> Damaged;
        public event Action<IDamageable> Died;
        
        public bool IsDestroyed { get; }
        public uint MaxHealth { get; }
        public uint CurrentHealth { get; }       
        public IReadOnlyEncapsulatedCollection<IResistanceHandler, DamageType> ResistanceHandlers { get; }
        public IReadOnlyEncapsulatedCollection<IApplyableEffectHandler, ApplyableEffectType> EffectsHandlers { get; }

        public bool TryMakeDamage(Damage damage);
    }
}