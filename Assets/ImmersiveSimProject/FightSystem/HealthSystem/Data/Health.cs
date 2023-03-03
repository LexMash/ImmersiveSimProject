namespace ImmersiveSimProject.FightSystem.HealthSystem.Data
{
    public class Health : IHealth
    {
        public uint Max => MaxValue;
        public uint Current => CurrentValue;
        public float NormalizeValue => Current/Max;

        public uint MaxValue;
        public uint CurrentValue;

        public Health(uint maxValue, uint currentValue) 
        {
            MaxValue = maxValue;
            CurrentValue = currentValue;
        }
    }
}
