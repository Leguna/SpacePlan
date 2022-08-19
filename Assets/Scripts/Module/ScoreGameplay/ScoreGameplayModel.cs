using Agate.MVC.Base;
using SpacePlan.Module.Base;

namespace SpacePlan.Module.ScoreGameplay
{
    public class ScoreGameplayModel : BaseModel, IScoreGameplayModel
    {
        public EntryHighscore ScorePlayer { get; private set; }

        public ScoreGameplayModel()
        {
            ScorePlayer = new EntryHighscore { score = 0, name = "Player 1" };
        }

        public ScoreGameplayModel(EntryHighscore scorePlayer)
        {
            ScorePlayer = scorePlayer;
        }

        public void AddScore(int value)
        {
            ScorePlayer = new EntryHighscore { name = ScorePlayer.name, score = ScorePlayer.score + value };
            SetDataAsDirty();
        }
    }
}