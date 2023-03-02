using ImmersiveSimProject.DamageSystem.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ImmersiveSimProject.DamageSystem
{
    public class ResistanceHandlerCollection : IEncapsulatedCollection<IResistanceHandler, DamageType>
    {
        public IResistanceHandler this[DamageType type] 
        {
            get => _handlersMap.FirstOrDefault(resistance => resistance.Value.BaseResistance.Type == type).Value;
            set => _handlersMap[type] = value;
        }

        public int Count => _handlersMap.Count;

        private readonly Dictionary<DamageType, IResistanceHandler> _handlersMap = new Dictionary<DamageType, IResistanceHandler>();

        //что то мне это всё не нравится...
        public void Remove(DamageType type)
        {
            _handlersMap[type] = new ResistanceHandler(new Resistance(type, 0));
        }

        public IEnumerator<IResistanceHandler> GetEnumerator() => _handlersMap.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
