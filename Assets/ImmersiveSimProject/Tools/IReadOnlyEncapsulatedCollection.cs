using System.Collections.Generic;

namespace ImmersiveSimProject
{
    public interface IReadOnlyEncapsulatedCollection<Type, Index> : IEnumerable<Type>
    {
        public int Count { get; }
        public Type this[Index index] { get; }
    }
}
