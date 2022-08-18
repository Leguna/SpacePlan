using Agate.MVC.Base;
using SpacePlan.Message;

namespace SpacePlan.Module.PowerUpPool
{
    public class PowerUpPoolConnector : BaseConnector
    {
        private PowerUpPoolController _powerUpPoolController;

        protected override void Connect()
        {
            Subscribe<StartGameMessage>(_powerUpPoolController.StartPowerUpEvent);
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartGameMessage>(_powerUpPoolController.StartPowerUpEvent);
        }
    }
}