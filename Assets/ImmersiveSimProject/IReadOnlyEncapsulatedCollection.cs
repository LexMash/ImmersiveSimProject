using System.Collections.Generic;

namespace ImmersiveSimProject
{
    public interface IReadOnlyEncapsulatedCollection<T, I> : IEnumerable<T>
    {
        public int Count { get; }
        public T this[I index] { get; }
    }
}
