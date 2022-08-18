using SpacePlan.Module.Base;

namespace SpacePlan.Message
{
    public struct GameOverMessage
    {
        public GameOverMessage(ScorePlayer scorePlayer)
        {
            ScorePlayer = scorePlayer;
        }

        public ScorePlayer ScorePlayer { get; }
    }
}