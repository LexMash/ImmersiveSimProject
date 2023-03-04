using ImmersiveSimProject.DamageSystem.Data;
using System;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    public interface IDamageable
    {      
        public event Action<IDamageable, Damage> Damaged;
        public bool TryMakeDamage(Damage damage);
    }
}