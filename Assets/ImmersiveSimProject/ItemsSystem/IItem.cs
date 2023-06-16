namespace ImmersiveSimProject.ItemsSystem
{
    public interface IItem : IUsable
    {
        public IItemMeta Meta { get; }
    }
}
