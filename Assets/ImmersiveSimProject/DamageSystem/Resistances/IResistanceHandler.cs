using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.Interactions;
using ImmersiveSimProject.StatsSystem;

namespace ImmersiveSimProject.DamageSystem
{
    public interface IResistanceHandler : IStatHandler<Resistance, int>
    {
        public InteractionType DamageType { get; }
    }
}