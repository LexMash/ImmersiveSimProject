﻿using ImmersiveSimProject.Effects;
using ImmersiveSimProject.Interactions;

namespace ImmersiveSimProject.DamageSystem.Data
{
    public readonly struct Damage
    {
        public object Attacker { get; } //пока object - потом заменим
        public uint Value { get; }
        public InteractionType Type { get; }
        public IEffect[] Effects { get; }
        public bool IgnoreResistance { get; }
        public bool IsCritical { get; }

        public Damage(object attacker, uint value, InteractionType type, bool ignoreResistance, bool isCritical = false, params IEffect[] effect)
        {
            Attacker = attacker;
            Value = value;
            Type = type;
            Effects = effect;
            IgnoreResistance = ignoreResistance;
            IsCritical = isCritical;
        }
    }
}
