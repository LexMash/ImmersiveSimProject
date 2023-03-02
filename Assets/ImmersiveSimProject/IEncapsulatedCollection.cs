namespace ImmersiveSimProject
{
    public interface IEncapsulatedCollection<T, I> : IReadOnlyEncapsulatedCollection<T, I>
    {
        public new T this[I index] { get; set; }
        public void Remove(I index);
    }
}
