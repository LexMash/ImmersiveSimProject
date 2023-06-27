namespace ImmersiveSimProject.StaticServices
{
    //надо подумать над этим
    public static class StandardOperations
    {
        public static uint UINT_SubtractionClamp(uint currentValue, uint subtractedValue)
        {
            if (currentValue <= subtractedValue)
                return 0;

            return currentValue - subtractedValue;
        }

        public static float Normalize(uint maxValue, uint currentValue) 
            => currentValue / (float)maxValue;

        public static float Normalize(int maxValue, int currentValue) 
            => currentValue / (float)maxValue;
    }
}
