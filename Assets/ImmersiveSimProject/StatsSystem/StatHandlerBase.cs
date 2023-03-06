using ImmersiveSimProject.StatsSystem.Data;
using System;
using System.Collections.Generic;

namespace ImmersiveSimProject.StatsSystem
{
    public abstract class StatHandlerBase<TStat, T> : IStatHandler<TStat, T> where TStat : Stat<T>
    {
        public event Action StatValueChanged;

        public T BaseValue { get; }
        public T CurrentValue => CalculateCurrentValue();

        protected readonly List<TStat> _modificators;

        public virtual void AddModificator(TStat modificator)
        {
            _modificators.Add(modificator);
            NotificateListeners();
        }

        public virtual void RemoveModificator(TStat modificator)
        {
            _modificators.Remove(modificator);
            NotificateListeners();
        }

        public abstract void DecreaseBaseValue(T value);
        public abstract void IncreaseBaseValue(T value);
        protected abstract T CalculateCurrentValue();
        protected void NotificateListeners() => StatValueChanged?.Invoke();
    }
}
