using Agate.MVC.Base;
using SpacePlan.Message;

namespace SpacePlan.Module.ScoreGameplay
{
    public class ScoreGameplayController : ObjectController<ScoreGameplayController, ScoreGameplayModel,
        IScoreGameplayModel, ScoreGameplayView>
    {
        public void AddScore(AddScoreMessage message)
        {
            _model.AddScore(message.Value);
        }
    }
}