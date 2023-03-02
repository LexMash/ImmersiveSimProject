namespace ImmersiveSimProject.StaticServices
{
    //надо подумать над этим
    public static class StandardOperations
    {
        public static uint UINTDamageClamp(uint health, uint damage)
        {
            if (health <= damage)
                return 0;

            return health - damage;
        }
    }
}
