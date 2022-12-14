using Agate.MVC.Base;
using SpacePlan.Message;

namespace SpacePlan.Module.EnemyPool
{
    public class EnemyPoolConnector : BaseConnector
    {
        private EnemyPoolController _enemyPoolController;

        protected override void Connect()
        {
            Subscribe<StartGameMessage>(_enemyPoolController.SpawnEnemyEvent);
            Subscribe<EnemyDestroyedMessage>(_enemyPoolController.OnEnemyDestroyed);
        }

        protected override void Disconnect()
        {
            Unsubscribe<StartGameMessage>(_enemyPoolController.SpawnEnemyEvent);
            Unsubscribe<EnemyDestroyedMessage>(_enemyPoolController.OnEnemyDestroyed);
        }
    }
}