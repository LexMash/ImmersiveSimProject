namespace ImmersiveSimProject.Effects
{
    public interface IApplyableEffect
    {
        public ApplyableEffectType Type { get; }
        public float TimeOfAction { get; }
        public ApplyableEffectType CancelType { get; }       
    }
}
