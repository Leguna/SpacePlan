namespace SpacePlan.Message
{
    public struct AddScoreMessage
    {
        public AddScoreMessage(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}