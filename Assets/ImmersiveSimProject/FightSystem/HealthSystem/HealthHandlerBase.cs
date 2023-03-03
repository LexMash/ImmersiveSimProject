using System;
using ImmersiveSimProject.FightSystem.HealthSystem.Data;
using ImmersiveSimProject.StaticServices;

namespace ImmersiveSimProject.FightSystem.HealthSystem
{
    public class HealthHandlerBase : IHealthHandler
    {
        public event Action<uint> ValueChanged;
        public IHealth Health => _health;

        private readonly Health _health;

        public HealthHandlerBase(Health health)
        {
            _health = health;
        }

        public virtual void Heal(uint value)
        {
            Math.Clamp(_health.CurrentValue += value, 0, _health.MaxValue);
            NotificateListeners();
        }

        public virtual void ApplyDamage(uint value)
        {
            _health.CurrentValue = StandardOperations.UINT_SubtractionClamp(_health.CurrentValue, value);
            NotificateListeners();
        }
        
        public void IncreaseMaxHealth(uint value)
        {
            _health.MaxValue += value;
            NotificateListeners();
        }

        public void DecreaseMaxValue(uint value)
        {
            _health.MaxValue = StandardOperations.UINT_SubtractionClamp(_health.MaxValue, value);
            NotificateListeners();
        }

        private void NotificateListeners() => ValueChanged?.Invoke(_health.Current);
    }
}
