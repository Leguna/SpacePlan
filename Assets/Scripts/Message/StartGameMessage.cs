namespace SpacePlan.Message
{
    public struct StartGameMessage
    {
        public StartGameMessage(bool isPlaying)
        {
            IsPlaying = isPlaying;
        }

        public bool IsPlaying { get; }
    }
}