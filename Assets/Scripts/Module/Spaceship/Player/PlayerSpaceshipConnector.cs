using Agate.MVC.Base;
using SpacePlan.Message;

namespace SpacePlan.Module.Spaceship.Player
{
    public class PlayerSpaceshipConnector : BaseConnector
    {
        private PlayerSpaceshipController _playerSpaceshipController;

        protected override void Connect()
        {
            Subscribe<PowerUpMessage>(_playerSpaceshipController.OnGetPowerUpEvent);
        }

        protected override void Disconnect()
        {
            Unsubscribe<PowerUpMessage>(_playerSpaceshipController.OnGetPowerUpEvent);
        }
    }
}