using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Leaderboard;
using SpacePlan.Module.SoundFx;
using SpacePlan.Module.Spaceship.Player;
using UnityEngine.SceneManagement;

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
            // TODO @faisal: Error nih
            // _leaderboard.OnUpdateLeaderboard(message.playerScore);
        }

        private void OnMoveSpaceship(InputMessage message)
        {
            _playerSpaceshipController.OnMoveInput(message.Direction);
        }

        protected override void Connect()
        {
            Subscribe<UpdateScoreMessage>(OnUpdateScorePlayer);
            Subscribe<InputMessage>(OnMoveSpaceship);
            Subscribe<GameOverMessage>(OnGameOver);
        }


        protected override void Disconnect()
        {
            Unsubscribe<UpdateScoreMessage>(OnUpdateScorePlayer);
            Unsubscribe<InputMessage>(OnMoveSpaceship);
            Unsubscribe<GameOverMessage>(OnGameOver);
        }

        /*public void OnUpdateCoin(UpdateCoinMessage message)
        {
           // _saveData.OnUpdateCoin(message.Coin);
            _soundFx.OnUpdateCoin();
        } */

        public void OnGameOver(GameOverMessage message)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}