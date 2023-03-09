namespace ImmersiveSimProject.Effects
{
    public interface IAffectable
    {
        public IReadOnlyEncapsulatedCollection<IEffectHandler, EffectType> EffectsHandlers { get; }
        public bool TryApplyEffects(params IEffect[] effect);
    }
}