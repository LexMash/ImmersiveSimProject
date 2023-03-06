using ImmersiveSimProject.Interactions;
using ImmersiveSimProject.StatsSystem.Data;
using System;

namespace ImmersiveSimProject.DamageSystem.Data
{
    [Serializable]
    public class Resistance : Stat<int>
    {
        public InteractionType DamageType;
    }
}
