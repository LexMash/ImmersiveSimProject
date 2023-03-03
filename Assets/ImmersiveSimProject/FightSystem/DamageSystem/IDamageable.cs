using ImmersiveSimProject.DamageSystem;
using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.Interactions;
using System;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    public interface IDamageable : IDying
    {      
        public event Action<IDamageable, Damage> Damaged;    
        public IReadOnlyEncapsulatedCollection<IResistanceHandler, InteractionType> ResistanceHandlers { get; }  
        public bool TryMakeDamage(Damage damage);
    }
}