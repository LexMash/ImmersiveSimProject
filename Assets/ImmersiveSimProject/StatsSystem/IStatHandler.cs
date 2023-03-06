using ImmersiveSimProject.StatsSystem.Data;
using System;

namespace ImmersiveSimProject.StatsSystem
{
    public interface IStatHandler<TStat,T> where TStat : Stat<T>
    {
        public event Action StatValueChanged;

        public T BaseValue { get; }
        public T CurrentValue { get; }

        public void AddModificator(TStat modificator);
        public void RemoveModificator(TStat modificator);
        public void IncreaseBaseValue(T value);
        public void DecreaseBaseValue(T value);
    }
}