using System;

namespace ImmersiveSimProject.FightSystem.DamageSystem
{
    public interface IDying
    {
        public event Action<IDying> Died;
        public bool IsDied { get; }
    }
}
