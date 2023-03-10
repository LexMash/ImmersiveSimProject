namespace ImmersiveSimProject
{
    public interface IClearableEncapsulatedCollection<Type, Index> : IEncapsulatedCollection<Type, Index>
    {
        public void Clear();
    }
}
