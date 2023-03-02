using System;
using UnityEngine;

namespace ImmersiveSimProject.DamageSystem.Data
{
    [Serializable]
    public class Resistance : IResistance
    {
        [SerializeField] private DamageType _type;
        [SerializeField] private int _percentage = 0;

        public DamageType Type => _type;
        public int Percentage => _percentage;

        public Resistance(DamageType type, int percentage = 0)
        {
            _type = type;
            _percentage = percentage;
        }
    }
}
