namespace SpacePlan.Message
{
    public struct PlayerNameChanged
    {
        public PlayerNameChanged(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}