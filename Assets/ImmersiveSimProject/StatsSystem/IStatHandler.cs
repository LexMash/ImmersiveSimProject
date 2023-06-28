using ImmersiveSimProject.StatsSystem.Data;
using System;

namespace ImmersiveSimProject.StatsSystem
{
    public interface IStatHandler<TStat,TType> where TStat : Stat<TType>
    {
        public event Action StatValueChanged;

        public TType BaseValue { get; }
        public TType CurrentValue { get; }

        public void AddModificator(TStat modificator);
        public void RemoveModificator(TStat modificator);
        public void IncreaseBaseValue(TType value);
        public void DecreaseBaseValue(TType value);
    }
}