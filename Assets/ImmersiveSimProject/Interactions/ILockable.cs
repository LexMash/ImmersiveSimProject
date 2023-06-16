using ImmersiveSimProject.ItemsSystem;
using System;

namespace ImmersiveSimProject.Interactions
{
    public interface ILockable
    {
        public event Action<string> Unlocked;
        public bool IsLocked { get; }
        public IItemMeta[] Key { get; }
        //public uint LockpickLevel { get; }
        public bool TryUnlock(IItemMeta key);
    }
}
