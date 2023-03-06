using ImmersiveSimProject.DamageSystem;
using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.Interactions;
using System;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    public interface IDamageable
    {      
        public event Action<IDamageable, Damage> Damaged;

        public IReadOnlyEncapsulatedCollection<ResistanceHandlerBase, InteractionType> ResistanceHandlers { get; }
        //public bool TryMakeDamage(Damage damage);
        public void ApplyDamage(Damage damage);
    }
}