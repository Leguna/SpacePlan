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

        private void OnMoveSpaceship(InputMessage message)
        {
            _playerSpaceshipController.OnMoveInput(message.Direction);
        }

        protected override void Connect()
        {
            Subscribe<InputMessage>(OnMoveSpaceship);
        }

        protected override void Disconnect()
        {
            Unsubscribe<InputMessage>(OnMoveSpaceship);
        }
    }
}