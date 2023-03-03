using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.DamageSystem.View;
using System;
using ImmersiveSimProject.Interactions;
using ImmersiveSimProject.DamageSystem;
using ImmersiveSimProject.FightSystem.HealthSystem;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    public abstract class DamageableBase<D, V> : IDamageable where D : DamageLevelBase<V> where V : DamageLevelViewBase
    {
        public event Action<IDamageable, Damage> Damaged;
        public event Action<IDying> Died;
        public bool IsDied => Health.Current == 0;
        public IHealth Health => _healthHandler.Health;
        public IReadOnlyEncapsulatedCollection<IResistanceHandler, InteractionType> ResistanceHandlers { get; }

        protected readonly IEncapsulatedCollection<IResistanceHandler, InteractionType> _resistanceHandlers;
        protected readonly DamageLevelsSwitcher<D, V> _damageLevelsSwitcher;
        protected readonly HealthHandlerBase _healthHandler;

        protected DamageableBase(HealthHandlerBase healthHandler, DamageLevels<D, V> damageLevels, BaseResistances baseResistances)
        {
            _healthHandler = healthHandler;
            _healthHandler.ValueChanged += HealthValueChanged;

            _damageLevelsSwitcher = new DamageLevelsSwitcher<D, V>(_healthHandler, damageLevels);
            _resistanceHandlers = new ResistanceHandlerCollection();

            foreach(var resistance in baseResistances)
            {
                IResistanceHandler handler = new ResistanceHandler(resistance);
                _resistanceHandlers[resistance.Type] = handler;
            }
        }

        public virtual bool TryMakeDamage(Damage damage)
        {
            if (!IsDied)
            {
                var resultDamageValue = CalculateMainDamage(damage);

                NotificateListeners(damage, resultDamageValue);

                if (!damage.IgnoreResistance && resultDamageValue == 0)
                {
                    return false;
                }

                _healthHandler.ApplyDamage(resultDamageValue);
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
                var resistance = ResistanceHandlers[damage.Type];
                resultDamage = (uint)Math.Round(damage.Value - (damage.Value / 100f) * resistance.CurrentValue, MidpointRounding.AwayFromZero);
            }

            return resultDamage;
        }      

        protected virtual void NotificateListeners(Damage damage, uint resultDamageValue) 
        {
            var result = new Damage(resultDamageValue, damage.Type, damage.IgnoreResistance, damage.IsCritical);

            Damaged?.Invoke(this, result);
        }

        private void HealthValueChanged(uint value)
        {
            if (_healthHandler.Health.Current == 0)
            {
                Died?.Invoke(this);
            }
        }
    }
}