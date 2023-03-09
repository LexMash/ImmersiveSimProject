using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ImmersiveSimProject.Effects
{
    public class EffectHandlerCollection : IClearableEncapsulatedCollection<IEffectHandler, EffectType>
    {
        public int Count => _handlersMap.Count;
        public IEffectHandler this[EffectType type]
        {
            get => _handlersMap.FirstOrDefault(handler => handler.Value.Effect.Type == type).Value;
            set => Set(type, value);
        }

        private readonly Dictionary<EffectType, IEffectHandler> _handlersMap = new();

        public void Remove(EffectType type)
        {
            _handlersMap[type].EffectTerminated -= HandlerEffectTerminated;
            _handlersMap.Remove(type);
        }

        public void Clear()
        {
            foreach(var handler in _handlersMap)
            {
                Remove(handler.Key);
            }

            _handlersMap.Clear();
        }

        public IEnumerator<IEffectHandler> GetEnumerator() => _handlersMap.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void Set(EffectType type, IEffectHandler handler)
        {
            if (_handlersMap.ContainsKey(type))
            {
                _handlersMap[type].IncreaseTime(handler.Effect.TimeOfAction);
            }
            else
            {
                TryCancelEffects(handler.Effect);

                handler.EffectTerminated += HandlerEffectTerminated;
                _handlersMap[type] = handler;
            }          
        }

        private void HandlerEffectTerminated(IEffect effect)
        {
            Remove(effect.Type);
        }

        private bool TryCancelEffects(IEffect effect)
        {
            var canceledEffects = _handlersMap.Where(handler => handler.Value.Effect.CancelType == effect.Type);

            if (canceledEffects.Count() > 0)
            {
                foreach (var canceledEffect in canceledEffects)
                {
                    Remove(canceledEffect.Value.Effect.Type);
                }

                return true;
            }

            return false;
        }
    }
}