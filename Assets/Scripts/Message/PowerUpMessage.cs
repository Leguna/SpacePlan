using SpacePlan.Module.Base;

namespace SpacePlan.Message
{
    public struct PowerUpMessage
    {
        public PowerUpMessage(float duration, PowerUpType powerUpType, float powerUpValue)
        {
            Duration = duration;
            PowerUpType = powerUpType;
            PowerUpValue = powerUpValue;
        }

        public float Duration { get; }
        public PowerUpType PowerUpType { get; }
        public float PowerUpValue { get; }
    }
}