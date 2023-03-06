using System.Linq;
using ImmersiveSimProject.FightSystem.HealthSystem.Data;
using ImmersiveSimProject.StaticServices;
using ImmersiveSimProject.StatsSystem;

namespace ImmersiveSimProject.FightSystem.HealthSystem
{
    public class HealthHandlerBase : StatHandlerBase<Health, uint>
    {
        private readonly Health _health;

        public HealthHandlerBase(Health health)
        {
            _health = health;
        }

        //перенести в 
        //public virtual void Heal(uint value)
        //{
        //    Math.Clamp(_health.Value += value, 0, _health.MaxValue);
        //    NotificateListeners();
        //}

        //public virtual void ApplyDamage(uint value)
        //{
        //    _health.Value = StandardOperations.UINT_SubtractionClamp(_health.Value, value);
        //    NotificateListeners();
        //}

        public override void IncreaseBaseValue(uint value)
        {
            _health.MaxValue += value;
            NotificateListeners();
        }

        public override void DecreaseBaseValue(uint value)
        {
            _health.MaxValue = StandardOperations.UINT_SubtractionClamp(_health.MaxValue, value);
            NotificateListeners();
        }

        protected override uint CalculateCurrentValue()
        {
            return _health.Value + (uint)_modificators.Sum(health => health.Value);
        }
    }
}
