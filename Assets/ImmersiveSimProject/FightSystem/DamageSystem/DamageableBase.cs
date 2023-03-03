using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.DamageSystem.View;
using System;
using ImmersiveSimProject.StaticServices;
using ImmersiveSimProject.Interactions;
using ImmersiveSimProject.DamageSystem;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    public abstract class DamageableBase<D, V> : IDamageable where D : DamageLevelBase<V> where V : DamageLevelViewBase
    {
        public event Action<IDamageable, Damage> Damaged;
        public event Action<IDying> Died;
        public bool IsDied => CurrentHealth == 0;
        public uint MaxHealth { get; private set; }
        public virtual uint CurrentHealth 
        { 
            get => _currentHealth;
            private set
            {
                if(value == 0)
                {
                    _currentHealth = 0;
                    Died?.Invoke(this);
                }
            }
        }  
        public IReadOnlyEncapsulatedCollection<IResistanceHandler, InteractionType> ResistanceHandlers { get; }       

        protected readonly IEncapsulatedCollection<IResistanceHandler, InteractionType> _resistanceHandlers;
        protected readonly DamageLevelsSwitcher<D, V> _damageLevelsSwitcher;
        private uint _currentHealth;

        protected DamageableBase(uint maxHealth, uint currentHealth, DamageLevels<D, V> damageLevels, BaseResistances baseResistances)
        {
            MaxHealth = maxHealth;
            _currentHealth = currentHealth;

            _damageLevelsSwitcher = new DamageLevelsSwitcher<D, V>(this, damageLevels);
            _resistanceHandlers = new ResistanceHandlerCollection();

            foreach(var resistance in baseResistances)
            {
                IResistanceHandler handler = new ResistanceHandler(resistance);
                _resistanceHandlers[resistance.Type] = handler;
            }
        }

        public virtual bool TryMakeDamage(Damage damage)
        {
            var resultDamageValue = CalculateDamage(damage);

            if(!damage.IgnoreResistance && resultDamageValue == 0)
            {
                return false;
            }

            ApplyDamage(resultDamageValue);
            Notificate(damage, resultDamageValue);
            
            return true;
        }

        protected virtual void ApplyDamage(uint value)
        {
            CurrentHealth = StandardOperations.UINTDamageClamp(CurrentHealth, value);           
        }

        protected virtual uint CalculateDamage(Damage damage)
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

        protected virtual void Notificate(Damage damage, uint resultDamageValue) 
        {
            var result = new Damage(resultDamageValue, damage.Type, damage.IgnoreResistance, damage.IsCritical, damage.Effects);

            Damaged?.Invoke(this, result);
        }
    }
}
