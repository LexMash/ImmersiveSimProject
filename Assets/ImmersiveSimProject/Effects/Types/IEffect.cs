namespace ImmersiveSimProject.Effects
{
    public interface IEffect
    {
        public EffectType Type { get; }
        public float TimeOfAction { get; }
        public EffectType CancelType { get; }       
    }
}
