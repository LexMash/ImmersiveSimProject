using ImmersiveSimProject.DamageSystem;

namespace ImmersiveSimProject.Effects
{
    public class ResistanceEffectHandler: EffectHandlerBase<IResistanceEffect>
    {
        private readonly IResistanceHandler _resistanceHandler;

        public ResistanceEffectHandler(IResistanceEffect effect, IResistanceHandler resistanceHandler) : base(effect)
        {
            _resistanceHandler = resistanceHandler;
            _resistanceHandler.ApplyModificator(_effect.ResistanceModificator);
        }

        public override void Terminate()
        {
            _resistanceHandler.RemoveModificator(_effect.ResistanceModificator);
            base.Terminate();
        }
    }
}
