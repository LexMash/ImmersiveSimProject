using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ImmersiveSimProject.DamageSystem.Data
{
    [CreateAssetMenu(fileName = "BaseResistanceConfig", menuName = "Immersive/DamageSystem/BaseResistanceConfig")]
    public class BaseResistances : ScriptableObject, IReadOnlyEncapsulatedCollection<Resistance, int>
    {
        [SerializeField] private List<Resistance> _resistances;

        public Resistance this[int index] => _resistances[index];
        public int Count => _resistances.Count;
        public IEnumerator<Resistance> GetEnumerator() => _resistances.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
