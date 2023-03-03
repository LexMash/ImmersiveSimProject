using System;

namespace ImmersiveSimProject.FightSystem.HealthSystem
{
    public interface IHealthHandler
    {
        public event Action<uint> ValueChanged;
        public IHealth Health {get; }

        public void Heal(uint value);
        public void ApplyDamage(uint value);
        public void IncreaseMaxHealth(uint value);
        public void DecreaseMaxValue(uint value);
    }
}
