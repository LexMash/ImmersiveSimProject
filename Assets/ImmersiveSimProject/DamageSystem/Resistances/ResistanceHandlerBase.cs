using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.Interactions;
using ImmersiveSimProject.StatsSystem;
using System.Linq;

namespace ImmersiveSimProject.DamageSystem
{
    public class ResistanceHandlerBase : StatHandlerBase<Resistance, int>
    {
        public InteractionType DamageType => _resistance.DamageType;

        private readonly Resistance _resistance;

        public ResistanceHandlerBase(Resistance resistance)
        {
            _resistance = resistance;
        }

        public override void IncreaseBaseValue(int value)
        {
            _resistance.Value += value;
            NotificateListeners();
        }

        public override void DecreaseBaseValue(int value)
        {
            _resistance.Value -= value;
            NotificateListeners();
        }

        protected override int CalculateCurrentValue()
        {
            return _resistance.Value + _modificators.Sum(resistance => resistance.Value);
        }
    }
}
