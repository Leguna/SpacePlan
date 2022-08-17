using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.BulletPool;

namespace SpacePlan.Module.Bullet.Connector
{
    public class BulletPoolConnector : BaseConnector
    {
        private BulletPoolController _bulletPoolController;

        protected override void Connect()
        {
            Subscribe<SpawnBulletMessage>(_bulletPoolController.OnSpawnBullet);
        }

        protected override void Disconnect()
        {
            Unsubscribe<SpawnBulletMessage>(_bulletPoolController.OnSpawnBullet);
        }
    }
}