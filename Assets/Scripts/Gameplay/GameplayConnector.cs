using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.SaveGame;
using SpacePlan.Module.SoundFx;
using SpacePlan.Module.Spaceship;
using SpacePlan.Module.Spaceship.Player;

namespace SpacePlan.Gameplay
{
    public class GameplayConnector : BaseConnector
    {
        private SaveDataController _saveData;
        private SoundFxController _soundFx;
        private PlayerSpaceshipController _playerSpaceshipController;

        private void OnUpdateCoin(UpdateCoinMessage message)
        {
            _saveData.OnUpdateCoin(message.Coin);
            _soundFx.OnUpdateCoin();
        }

        private void OnMoveSpaceship(InputMessage message)
        {
            _playerSpaceshipController.OnMoveInput(message.Direction);
        }

        protected override void Connect()
        {
            Subscribe<UpdateCoinMessage>(OnUpdateCoin);
            Subscribe<InputMessage>(OnMoveSpaceship);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateCoinMessage>(OnUpdateCoin);
            Unsubscribe<InputMessage>(OnMoveSpaceship);
        }
    }
}