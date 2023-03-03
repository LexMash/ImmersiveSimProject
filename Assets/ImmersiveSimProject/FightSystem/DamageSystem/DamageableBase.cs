using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.DamageSystem.View;
using ImmersiveSimProject.Effects;
using System;
using ImmersiveSimProject.StaticServices;
using ImmersiveSimProject.Interactions;

namespace ImmersiveSimProject.DamageSystem
{
    public abstract class DamageableBase<D, V> : IDamageable where D : DamageLevelBase<V> where V : DamageLevelViewBase
    {
        public event Action<IDamageable, uint> Damaged;
        public event Action<IDamageable> Died;
        
        public bool IsDestroyed => CurrentHealth == 0;
        public uint MaxHealth { get; private set; }
        public virtual uint CurrentHealth { get; private set; }  

        public IReadOnlyEncapsulatedCollection<IResistanceHandler, InteractionType> ResistanceHandlers { get; }       
        public IReadOnlyEncapsulatedCollection<IApplyableEffectHandler, ApplyableEffectType> EffectsHandlers { get; }

        protected readonly IEncapsulatedCollection<IResistanceHandler, InteractionType> _resistanceHandlers;
        protected readonly IClearableEncapsulatedCollection<IApplyableEffectHandler, ApplyableEffectType> _effectsHandlers;
        protected readonly DamageLevelsSwitcher<D, V> _damageLevelsSwitcher;

        protected DamageableBase(uint maxHealth, uint currentHealth, DamageLevels<D, V> damageLevels, BaseResistances baseResistances, IApplyableEffect[] effects = null)
        {
            MaxHealth = maxHealth;
            CurrentHealth = currentHealth;

            _damageLevelsSwitcher = new DamageLevelsSwitcher<D, V>(this, damageLevels);
            _resistanceHandlers = new ResistanceHandlerCollection();

            foreach(var resistance in baseResistances)
            {
                IResistanceHandler handler = new ResistanceHandler(resistance);
                _resistanceHandlers[resistance.Type] = handler;
            }

            _effectsHandlers = new EffectHandlerCollection();

            if (effects != null)
            {
                ApplyEffect(effects);
            }
        }

        public virtual bool TryMakeDamage(Damage damage)
        {
            var resultDamage = CalculateDamage(damage);

            if(!damage.IgnoreResistance && resultDamage == 0)
            {
                return false;
            }

            ApplyDamage(damage.Value);

            if (!IsDestroyed)
            {
                ApplyEffect(damage.Effect);
            }

            return true;
        }

        protected virtual void ApplyDamage(uint damage)
        {
            CurrentHealth = StandardOperations.UINTDamageClamp(CurrentHealth, damage);
            Damaged?.Invoke(this, damage);
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

        protected virtual void ApplyEffect(IApplyableEffect[] effect)
        {

        }       
    }
}
