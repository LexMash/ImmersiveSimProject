namespace ImmersiveSimProject
{
    public interface IClearableEncapsulatedCollection<T, I> : IEncapsulatedCollection<T, I>
    {
        public void Clear();
    }
}
