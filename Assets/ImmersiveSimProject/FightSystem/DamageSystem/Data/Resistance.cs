using ImmersiveSimProject.Interactions;
using System;
using UnityEngine;

namespace ImmersiveSimProject.DamageSystem.Data
{
    [Serializable]
    public class Resistance : IResistance
    {
        [SerializeField] private InteractionType _type;
        [SerializeField] private int _percentage = 0;

        public InteractionType Type => _type;
        public int Percentage => _percentage;

        public Resistance(InteractionType type, int percentage = 0)
        {
            _type = type;
            _percentage = percentage;
        }
    }
}
