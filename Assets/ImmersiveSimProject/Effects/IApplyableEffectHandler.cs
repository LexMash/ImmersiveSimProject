using System;

namespace ImmersiveSimProject.Effects
{
    public interface IApplyableEffectHandler
    {
        public event Action<IApplyableEffect> EffectTerminated;
        public IApplyableEffect Effect { get; }
        public float RemainingTime { get; }

        public void Update(float deltaTime);
        public void Terminate();
        public void IncreaseTime(float time);
        public void DecreaseTime(float time);
    }
}
