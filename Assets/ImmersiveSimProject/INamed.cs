namespace ImmersiveSimProject
{
    //пригодится для локализации
    //обходим всю сцену и по айди заменяем всё что нужно
    public interface INamed
    {
        public string NameID { get; }
        public string DescriptionID { get; }
    }
}
