namespace ImmersiveSimProject.Effects
{
    public interface IAffectable
    {
        public IReadOnlyEncapsulatedCollection<IApplyableEffectHandler, ApplyableEffectType> EffectsHandlers { get; }
        public bool TryApplyEffects(params IApplyableEffect[] effect);
    }
}