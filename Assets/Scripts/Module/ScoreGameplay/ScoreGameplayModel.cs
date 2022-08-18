using Agate.MVC.Base;
using SpacePlan.Module.Base;

namespace SpacePlan.Module.ScoreGameplay
{
    public class ScoreGameplayModel : BaseModel, IScoreGameplayModel
    {
        public ScorePlayer ScorePlayer { get; private set; }

        public ScoreGameplayModel()
        {
            ScorePlayer = new ScorePlayer { Score = 0, PlayerName = "Player 1" };
        }

        public ScoreGameplayModel(ScorePlayer scorePlayer)
        {
            ScorePlayer = scorePlayer;
        }

        public void AddScore(int value)
        {
            ScorePlayer = new ScorePlayer { PlayerName = ScorePlayer.PlayerName, Score = ScorePlayer.Score + value };
            SetDataAsDirty();
        }
    }
}