using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.DamageSystem.View;
using System;

namespace ImmersiveSimProject.DamageSystem
{
    public class DamageLevelsSwitcher<D,V> where D : DamageLevelBase<V> where V : DamageLevelViewBase
    {
        private readonly DamageLevels<D, V> _levels;
        private int _currentLevelIndex;
        
        public DamageLevelsSwitcher(IDamageable damageable, DamageLevels<D,V> levels)
        {
            _levels = levels;

            var currentPercent = CalculatePercent(damageable);

            ActivateLevel(currentPercent);

            for (int i = _currentLevelIndex; i < _levels.Length; i++)
            {
                _levels[i].View.gameObject.SetActive(i == _currentLevelIndex);
            }

            damageable.Damaged += DamageableDamaged;
            damageable.Died += DamageableDestroed;
        }

        private void DamageableDamaged(IDamageable damageable, uint damage)
        {
            var currentPercent = CalculatePercent(damageable);

            ActivateLevel(currentPercent);
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

        private uint CalculatePercent(IDamageable damageable)
        {
            uint currentPercent;

            if (damageable.MaxHealth == damageable.CurrentHealth)
            {
                currentPercent = 100;
            }
            else
            {
                var onePercent = damageable.MaxHealth / 100f;
                currentPercent = (uint)Math.Round(damageable.CurrentHealth / onePercent);
            }

            return currentPercent;
        }

        private int GetNewLevelIndex(uint percent)
        {
            for (int i = _currentLevelIndex; i < _levels.Length; i++)
            {
                if (_levels[i].HealthLevel >= percent)
                    return i;
            }

            return _currentLevelIndex;
        }

        private void DamageableDestroed(IDamageable damageable)
        {
            damageable.Damaged -= DamageableDamaged;
            damageable.Died -= DamageableDestroed;
        }
    }
}
