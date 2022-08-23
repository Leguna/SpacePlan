using Agate.MVC.Base;
using SpacePlan.Message;

namespace SpacePlan.Module.ScoreGameplay
{
    public class ScoreGameplayConnector : BaseConnector
    {
        private ScoreGameplayController _scoreGameplayController;

        protected override void Connect()
        {
            Subscribe<AddScoreMessage>(_scoreGameplayController.AddScore);
        }

        protected override void Disconnect()
        {
            Unsubscribe<AddScoreMessage>(_scoreGameplayController.AddScore);
        }
    }
}