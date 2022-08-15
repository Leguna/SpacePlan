using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Leaderboard;
using SpacePlan.Module.SoundFx;

namespace SpacePlan.Gameplay
{
    public class GameplayConnector : BaseConnector
    {
        private LeaderboardController _leaderboard;
        private SoundFxController _soundFx;

        // TODO @faisal implement pubsub & subscribe message

        public void OnUpdateScorePlayer(UpdateScoreMessage message)
        {
            _leaderboard.OnUpdateLeaderboard(message.playerScore);
        }

        protected override void Connect()
        {
            Subscribe<UpdateScoreMessage>(OnUpdateScorePlayer);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateScoreMessage>(OnUpdateScorePlayer);
        }

        /*public void OnUpdateCoin(UpdateCoinMessage message)
        {
           // _saveData.OnUpdateCoin(message.Coin);
            _soundFx.OnUpdateCoin();
        } */
    }
}