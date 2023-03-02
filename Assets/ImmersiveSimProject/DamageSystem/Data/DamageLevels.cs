using ImmersiveSimProject.DamageSystem.View;
using UnityEngine;

namespace ImmersiveSimProject.DamageSystem.Data
{
    public abstract class DamageLevels<D, V> : ScriptableObject where D : DamageLevelBase<V> where V : DamageLevelViewBase
    {
        [SerializeField] private D[] _levels;
        
        public virtual D this[int index]
        {
            get => _levels[index];
        }

        public int Length => _levels.Length;
    }
}