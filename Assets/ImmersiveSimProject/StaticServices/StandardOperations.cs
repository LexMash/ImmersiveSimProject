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

        public static float Normalize(uint maxValue, uint currentValue)
        {
            return currentValue / (float)maxValue;
        }

        public static float Normalize(int maxValue, int currentValue)
        {
            return currentValue / (float)maxValue;
        }
    }
}
