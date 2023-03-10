using UnityEngine;

namespace ImmersiveSimProject.CraftSystem
{
    public interface ICraftTable<TResult, TIngredient> : INamed
    {
        public Sprite Icon { get; }
        public TResult Construct(params TIngredient[] ingridients);
        public TResult[] Deconstruct(TIngredient target);
    }
}
