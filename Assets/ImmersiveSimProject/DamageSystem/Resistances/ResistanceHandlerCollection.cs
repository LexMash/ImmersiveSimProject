using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace ImmersiveSimProject.DamageSystem
{
    public class ResistanceHandlerCollection : IEncapsulatedCollection<ResistanceHandlerBase, InteractionType>
    {
        public ResistanceHandlerBase this[InteractionType type] 
        {
            get => _handlersMap.FirstOrDefault(resistance => resistance.Value.DamageType == type).Value;
            set => _handlersMap[type] = value;
        }

        public int Count => _handlersMap.Count;

        private readonly Dictionary<InteractionType, ResistanceHandlerBase> _handlersMap = new();

        //получается, что мы не можем удалить сопротивление
        //можем его только обнулить... надо подумать как это убрать
        public void Remove(InteractionType type)
        {
            var resistance = new Resistance
            {
                Value = 0,
                DamageType = type
            };

            _handlersMap[type] = new ResistanceHandlerBase(resistance);
        }

        public IEnumerator<ResistanceHandlerBase> GetEnumerator() => _handlersMap.Values.GetEnumerator();
    }
}
