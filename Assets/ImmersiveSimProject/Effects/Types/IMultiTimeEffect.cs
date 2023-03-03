namespace ImmersiveSimProject.Effects.Types
{
    public interface IMultiTimeEffect : IApplyableEffect
    {
        public uint Count { get; }
        public float TimeInterval { get; }
    }
}
