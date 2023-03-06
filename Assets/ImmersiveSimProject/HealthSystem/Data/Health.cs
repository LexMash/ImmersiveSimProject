using ImmersiveSimProject.StatsSystem.Data;
using System;

namespace ImmersiveSimProject.FightSystem.HealthSystem.Data
{
    [Serializable]
    public class Health : Stat<uint>
    {
        public uint MaxValue;
    }
}