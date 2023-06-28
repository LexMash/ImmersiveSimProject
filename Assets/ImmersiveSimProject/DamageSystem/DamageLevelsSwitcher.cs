using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.DamageSystem.View;
using ImmersiveSimProject.FightSystem.HealthSystem;
using ImmersiveSimProject.StaticServices;
using System;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    /// <summary>
    /// Устанавливает визуал в зависимости от состояния здоровья
    /// </summary>
    /// <typeparam name="D"></typeparam>
    /// <typeparam name="V"></typeparam>
    public class DamageLevelsSwitcher<D,V> where D : DamageLevelBase<V> where V : DamageLevelViewBase
    {
        private readonly DamageLevels<D, V> _levels;
        private int _currentLevelIndex;
        private readonly HealthHandlerBase _handler;

        public DamageLevelsSwitcher(HealthHandlerBase handler, DamageLevels<D,V> levels)
        {
            _handler = handler;
            _levels = levels;

            var currentPercent = CalculatePercent();

            ActivateLevel(currentPercent);

            for (int i = _currentLevelIndex; i < _levels.Length; i++)
            {
                _levels[i].View.gameObject.SetActive(i == _currentLevelIndex);
            }

            _handler.StatValueChanged += HealthValueChanged;
        }

        private void HealthValueChanged()
        {
            if(IsNotDestroy())
            {
                var currentPercent = CalculatePercent();

                ActivateLevel(currentPercent);
            }
            else
            {
                _handler.StatValueChanged -= HealthValueChanged;
            }
        }

        private void ActivateLevel(uint percent)
        {
            var newIndex = GetNewLevelIndex(percent);

            if (newIndex == _currentLevelIndex)
                return;

            _levels[_currentLevelIndex].View.gameObject.SetActive(false);
            _levels[newIndex].View.gameObject.SetActive(true);

            _currentLevelIndex = newIndex;
        }

        private uint CalculatePercent()
        {
            uint currentPercent;

            if (_handler.BaseValue == _handler.CurrentValue)
            {
                currentPercent = 100;
            }
            else
            {
                float normalize = StandardOperations.Normalize(_handler.BaseValue, _handler.CurrentValue);
                currentPercent = (uint)Math.Round(normalize * 100, 0);
            }

            return currentPercent;
        }

        private int GetNewLevelIndex(uint percent)
        {
            for (int i = _currentLevelIndex; i < _levels.Length; i++)
            {
                if (_levels[i].HealthLevel >= percent)
                {
                    return i;
                }                  
            }

            return _currentLevelIndex;
        }

        private bool IsNotDestroy()
        {
            return _currentLevelIndex != _levels.Length - 1;
        }
    }
}
