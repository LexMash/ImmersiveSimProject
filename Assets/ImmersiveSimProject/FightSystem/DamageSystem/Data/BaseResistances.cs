using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ImmersiveSimProject.DamageSystem.Data
{
    [CreateAssetMenu(fileName = "BaseResistanceConfig", menuName = "Immersive/DamageSystem/BaseResistanceConfig")]
    public class BaseResistances : ScriptableObject, IReadOnlyEncapsulatedCollection<IResistance, int>
    {
        [SerializeField] private List<Resistance> _resistances;

        public IResistance this[int index] => _resistances[index];
        public int Count => _resistances.Count;
        public IEnumerator<IResistance> GetEnumerator() => _resistances.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
