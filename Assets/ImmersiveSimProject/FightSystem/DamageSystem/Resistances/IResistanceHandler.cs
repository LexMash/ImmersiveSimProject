using ImmersiveSimProject.DamageSystem.Data;

namespace ImmersiveSimProject.DamageSystem
{
    public interface IResistanceHandler
    {
        public IResistance BaseResistance { get; }
        public int CurrentValue { get; }
        public void ApplyModificator(IResistance modificator);
        public void RemoveModificator(IResistance modificator);
    }
}