using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.DamageSystem.View;
using System;
using ImmersiveSimProject.Interactions;
using ImmersiveSimProject.DamageSystem;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    public abstract class DamageableBase<D, V> : IDamageable where D : DamageLevelBase<V> where V : DamageLevelViewBase
    {
        public event Action<IDamageable, Damage> Damaged;

        protected readonly IReadOnlyEncapsulatedCollection<IResistanceHandler, InteractionType> _resistanceHandlers;

        protected DamageableBase(IReadOnlyEncapsulatedCollection<IResistanceHandler, InteractionType> resistanceHandlers)
        {
            _resistanceHandlers = resistanceHandlers;
        }

        public virtual bool TryMakeDamage(Damage damage)
        {
            var resultDamageValue = CalculateMainDamage(damage);

            NotificateListeners(damage, resultDamageValue);

            if (resultDamageValue == 0)
            {
                return false;
            }

            return true;
        }

        protected virtual uint CalculateMainDamage(Damage damage)
        {
            uint resultDamage;

            if (damage.IgnoreResistance)
            {
                resultDamage = damage.Value;
            }
            else
            {
                var resistance = _resistanceHandlers[damage.Type];
                resultDamage = (uint)Math.Round(damage.Value - (damage.Value / 100f) * resistance.CurrentValue, MidpointRounding.AwayFromZero);
            }

            return resultDamage;
        }      

        protected virtual void NotificateListeners(Damage damage, uint resultDamageValue) 
        {
            var result = new Damage(damage.Attacker, resultDamageValue, damage.Type, damage.IgnoreResistance, damage.IsCritical, damage.Effects);

            Damaged?.Invoke(this, result);
        }
    }
}