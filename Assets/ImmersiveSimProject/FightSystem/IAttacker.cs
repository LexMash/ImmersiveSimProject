using ImmersiveSimProject.DamageSystem;
using ImmersiveSimProject.DamageSystem.Data;
using System;

namespace ImmersiveSimProject.FightSystem
{
    public interface IAttacker
    {
        public event Action<IAttacker, IDamageable, Damage> Attacked;
        public IWeapon Weapon { get; }
        public void Attack();
    }
}
