using SpacePlan.Module.Base;

namespace SpacePlan.Message
{
    public struct UpdateScoreMessage 
    {
        public ScorePlayer playerScore { get; private set; }

        public UpdateScoreMessage(ScorePlayer scorePlayer)
        {
            playerScore = scorePlayer;
        }
    }
}
