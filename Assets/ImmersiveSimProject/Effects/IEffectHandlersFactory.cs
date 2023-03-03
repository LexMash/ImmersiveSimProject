namespace ImmersiveSimProject.Effects
{
    public interface IEffectHandlersFactory
    {
        public THandle GetHandle<THandle, TEffect>() where THandle : IApplyableEffectHandler where TEffect : IApplyableEffect;
    }
}
