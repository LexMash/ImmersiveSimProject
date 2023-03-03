using ImmersiveSimProject.DamageSystem.Data;
using System.Collections.Generic;
using System.Linq;

namespace ImmersiveSimProject.DamageSystem
{
    public class ResistanceHandler : IResistanceHandler
    {
        public IResistance BaseResistance { get; }
        public int CurrentValue => GetCurrentValue();

        private readonly List<IResistance> _resistanceModificators = new List<IResistance>();

        public ResistanceHandler(IResistance baseResistance)
        {
            BaseResistance = baseResistance;
        }

        public void ApplyModificator(IResistance modificator)
        {
            _resistanceModificators.Add(modificator);
        }

        public void RemoveModificator(IResistance modificator)
        {
            _resistanceModificators.Remove(modificator);
        }

        private int GetCurrentValue()
        {
            return BaseResistance.Percentage + _resistanceModificators.Sum(resistance => resistance.Percentage);
        }
    }
}
