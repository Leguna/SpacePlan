using SpacePlan.Module.Base;

namespace SpacePlan.Message
{
    public struct GameOverMessage
    {
        public GameOverMessage(EntryHighscore scorePlayer)
        {
            ScorePlayer = scorePlayer;
        }

        public EntryHighscore ScorePlayer { get; }
    }
}