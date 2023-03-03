using ImmersiveSimProject.DamageSystem;
using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.FightSystem.HealthSystem;
using ImmersiveSimProject.Interactions;
using System;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    public interface IDamageable : IDying
    {      
        public event Action<IDamageable, Damage> Damaged;
        public IHealth Health { get; }
        public IReadOnlyEncapsulatedCollection<IResistanceHandler, InteractionType> ResistanceHandlers { get; }  
        public bool TryMakeDamage(Damage damage);
    }
}