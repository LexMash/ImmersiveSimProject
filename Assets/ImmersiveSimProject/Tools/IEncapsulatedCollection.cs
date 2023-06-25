namespace ImmersiveSimProject
{
    public interface IEncapsulatedCollection<Type, Index>
    {
        public Type this[Index index] { get; set; }
        public void Remove(Index index);
    }
}
