using System;

namespace ImmersiveSimProject.StatsSystem.Data
{
    [Serializable]
    public class Stat<T>
    {
        public T Value;
    }
}
