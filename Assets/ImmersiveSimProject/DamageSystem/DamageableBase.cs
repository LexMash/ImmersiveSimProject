using ImmersiveSimProject.DamageSystem.Data;
using System;
using ImmersiveSimProject.Interactions;
using ImmersiveSimProject.DamageSystem;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    public abstract class DamageableBase : IDamageable
    {
        public event Action<IDamageable, Damage> Damaged;

        public IReadOnlyEncapsulatedCollection<ResistanceHandlerBase, InteractionType> ResistanceHandlers { get; private set; }

        protected DamageableBase(IReadOnlyEncapsulatedCollection<ResistanceHandlerBase, InteractionType> resistanceHandlers)
        {
            ResistanceHandlers = resistanceHandlers;
        }

        public void ApplyDamage(Damage damage)
        {
            //дать доступ к данным

            Damaged?.Invoke(this, damage);
        }


        //TODO перенести во внешнюю систему
        //public virtual bool TryMakeDamage(Damage damage)
        //{
        //    var resultDamageValue = CalculateMainDamage(damage);

        //    NotificateListeners(damage, resultDamageValue);

        //    if (resultDamageValue == 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        //protected virtual uint CalculateMainDamage(Damage damage)
        //{
        //    uint resultDamage;

        //    if (damage.IgnoreResistance)
        //    {
        //        resultDamage = damage.Value;
        //    }
        //    else
        //    {
        //        var resistance = ResistanceHandlers[damage.Type];
        //        resultDamage = (uint)Math.Round(damage.Value - (damage.Value / 100f) * resistance.CurrentValue, MidpointRounding.AwayFromZero);
        //    }

        //    return resultDamage;
        //}      

        //protected virtual void NotificateListeners(Damage damage, uint resultDamageValue) 
        //{
        //    var result = new Damage(damage.Attacker, resultDamageValue, damage.Type, damage.IgnoreResistance, damage.IsCritical, damage.Effects);

        //    Damaged?.Invoke(this, result);
        //}
    }
}