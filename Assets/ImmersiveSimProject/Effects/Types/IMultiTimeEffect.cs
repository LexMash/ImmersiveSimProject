namespace ImmersiveSimProject.Effects.Types
{
    public interface IMultiTimeEffect : IEffect
    {
        public uint Count { get; }
        public float TimeInterval { get; }
    }
}
