namespace ImmersiveSimProject.ItemsSystem
{
    public interface IWeapon : IUsable
    {
        public IWeaponMeta Meta { get; }
    }
}
