using Agate.MVC.Base;
using SpacePlan.Message;

namespace SpacePlan.Module.Leaderboard
{
    public class LeaderboardConnector : BaseConnector
    {
        private LeaderboardController _controller;

        protected override void Connect()
        {
            Subscribe<GameOverMessage>(_controller.OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(_controller.OnGameOver);
        }
    }
}