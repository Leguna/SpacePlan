namespace SpacePlan.Message
{
    public struct EnemyCountMessage
    {
        public EnemyCountMessage(int count)
        {
            Count = count;
        }

        public int Count { get; }
    }
}