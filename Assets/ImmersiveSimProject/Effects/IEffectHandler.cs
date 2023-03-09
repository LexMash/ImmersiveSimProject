using System;

namespace ImmersiveSimProject.Effects
{
    public interface IEffectHandler
    {
        public event Action<IEffect> EffectTerminated;
        public IEffect Effect { get; }
        public float RemainingTime { get; }

        public void Update(float deltaTime);
        public void Terminate();
        public void IncreaseTime(float time);
        public void DecreaseTime(float time);
    }
}
