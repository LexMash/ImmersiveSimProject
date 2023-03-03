namespace ImmersiveSimProject.StaticServices
{
    //надо подумать над этим
    public static class StandardOperations
    {
        public static uint UINT_SubtractionClamp(uint health, uint damage)
        {
            if (health <= damage)
                return 0;

            return health - damage;
        }
    }
}
