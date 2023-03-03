using ImmersiveSimProject.DamageSystem.Data;
using ImmersiveSimProject.Interactions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ImmersiveSimProject.DamageSystem
{
    public class ResistanceHandlerCollection : IEncapsulatedCollection<IResistanceHandler, InteractionType>
    {
        public IResistanceHandler this[InteractionType type] 
        {
            get => _handlersMap.FirstOrDefault(resistance => resistance.Value.BaseResistance.Type == type).Value;
            set => _handlersMap[type] = value;
        }

        public int Count => _handlersMap.Count;

        private readonly Dictionary<InteractionType, IResistanceHandler> _handlersMap = new Dictionary<InteractionType, IResistanceHandler>();

        //получается, что мы не можем удалить сопротивление
        //можем его только обнулить... надо подумать как это убрать
        public void Remove(InteractionType type)
        {
            _handlersMap[type] = new ResistanceHandler(new Resistance(type, 0));
        }

        public IEnumerator<IResistanceHandler> GetEnumerator() => _handlersMap.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
