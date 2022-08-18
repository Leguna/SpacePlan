using SpacePlan.Module.Base;

namespace SpacePlan.Message
{
    public struct UpdateScoreMessage 
    {
        public EntryHighscore playerScore { get; private set; }

        public UpdateScoreMessage(EntryHighscore scorePlayer)
        {
            playerScore = scorePlayer;
        }
    }
}
