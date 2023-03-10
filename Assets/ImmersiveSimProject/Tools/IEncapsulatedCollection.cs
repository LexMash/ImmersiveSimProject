namespace ImmersiveSimProject
{
    public interface IEncapsulatedCollection<Type, Index> : IReadOnlyEncapsulatedCollection<Type, Index>
    {
        public new Type this[Index index] { get; set; }
        public void Remove(Index index);
    }
}
