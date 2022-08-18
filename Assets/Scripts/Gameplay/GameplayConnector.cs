using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Leaderboard;
using SpacePlan.Module.SoundFx;
using SpacePlan.Module.Spaceship;
using SpacePlan.Module.Spaceship.Player;

namespace SpacePlan.Gameplay
{
    public class GameplayConnector : BaseConnector
    {
        private LeaderboardController _leaderboard;
        private SoundFxController _soundFx;
        private PlayerSpaceshipController _playerSpaceshipController;

        // TODO @faisal implement pubsub & subscribe message
        public void OnUpdateScorePlayer(UpdateScoreMessage message)
        {
            _leaderboard.OnUpdateLeaderboard(message.playerScore);
        private void OnMoveSpaceship(InputMessage message)
        {
            _playerSpaceshipController.OnMoveInput(message.Direction);
        }

        protected override void Connect()
        {
            Subscribe<UpdateScoreMessage>(OnUpdateScorePlayer);

            Subscribe<InputMessage>(OnMoveSpaceship);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateScoreMessage>(OnUpdateScorePlayer);
            Unsubscribe<InputMessage>(OnMoveSpaceship);
        }

        /*public void OnUpdateCoin(UpdateCoinMessage message)
        {
           // _saveData.OnUpdateCoin(message.Coin);
            _soundFx.OnUpdateCoin();
        } */
    }
}