using ImmersiveSimProject.StatsSystem.Data;
using System;
using System.Collections.Generic;

namespace ImmersiveSimProject.StatsSystem
{
    public abstract class StatHandlerBase<TStat, TType> : IStatHandler<TStat, TType> where TStat : Stat<TType>
    {
        public event Action StatValueChanged;

        public TType BaseValue { get; }
        public TType CurrentValue => CalculateCurrentValue();

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

        public abstract void DecreaseBaseValue(TType value);
        public abstract void IncreaseBaseValue(TType value);
        protected abstract TType CalculateCurrentValue();
        protected void NotificateListeners() => StatValueChanged?.Invoke();
    }
}
