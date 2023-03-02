using System.Numerics;

namespace ImmersiveSimProject.Interactions
{
    public interface ILiftable : IInteractable, IMovable
    {
        public float Weight { get; }
        public uint MinForce { get; }
        public bool IsLifted { get; }
        public bool TryLift(uint force);
        public void Throw(Vector3 direction, float force);
    }
}
