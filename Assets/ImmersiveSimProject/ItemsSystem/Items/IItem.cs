using UnityEngine;

namespace ImmersiveSimProject.ItemsSystem
{
    public interface IItem : INamed
    {
        public ItemCategory Category { get; }
        public Sprite Icon { get; }
        public ItemView Visual { get; }     
        public string[] ComponentIDs { get; }

        //public uint Cost {get; }
        //public uint Weight {get; }

        //если вы хотите ограничить кол-во предметов в слоте
        //яблок - 5, денег - unit.MaxValue() и тд
        //public uint MaxCapacity {get; } 
    }
}
