using ImmersiveSimProject.ItemsSystem;
using System;

namespace ImmersiveSimProject.Interactions
{
    public interface ILockable
    {
        public event Action<string> Unlocked;
        public bool IsLocked { get; }
        public IItem[] Key { get; }
        //public uint LockpickLevel { get; }
        public bool TryUnlock(IItem key);
    }
}
