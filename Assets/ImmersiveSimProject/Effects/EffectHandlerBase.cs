using System;

namespace ImmersiveSimProject.Effects
{
    public abstract class EffectHandlerBase<E> : IApplyableEffectHandler where E : IApplyableEffect
    {
        public event Action<IApplyableEffect> EffectTerminated;
        public IApplyableEffect Effect => _effect;
        public float RemainingTime { get; private set; }

        protected readonly E _effect;

        public EffectHandlerBase(E effect)
        {
            _effect = effect;
            RemainingTime = effect.TimeOfAction;
        }

        public virtual void Update(float deltaTime)
        {
            RemainingTime -= deltaTime;

            TryTerminate();
        }

        public virtual void Terminate()
        {
            EffectTerminated?.Invoke(_effect);
        }

        public virtual void IncreaseTime(float time)
        {
            RemainingTime += time;
        }

        public virtual void DecreaseTime(float time)
        {
            RemainingTime -= time;

            TryTerminate();
        }

        protected virtual bool TryTerminate()
        {
            if (RemainingTime <= 0)
            {
                Terminate();
                return true;
            }

            return false;
        }
    }
}
