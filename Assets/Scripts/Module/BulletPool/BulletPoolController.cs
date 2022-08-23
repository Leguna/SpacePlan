using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Bullet;
using UnityEngine;

namespace SpacePlan.Module.BulletPool
{
    public class BulletPoolController : ObjectController<BulletPoolController, BulletPoolModel, BulletPoolView>
    {
        public void OnSpawnBullet(SpawnBulletMessage message)
        {
            var position = message.SpawnPosition;
            SpawnBullet(message.Direction, position, message.Damage, message.Health);
        }

        public override void SetView(BulletPoolView view)
        {
            base.SetView(view);
            BulletPoolSetup();
        }

        private void SpawnBullet(Vector3 dir, Vector3 position, float damage, float health)
        {
            BulletController bulletController = _model.GetBulletController() ?? AddBulletToPool();
            bulletController.Spawn(dir, position, new BulletModel(damage, health));
        }

        private void BulletPoolSetup()
        {
            for (int i = 0; i < _model.PoolSize; i++)
            {
                AddBulletToPool();
            }
        }

        private BulletController AddBulletToPool()
        {
            var bulletController = new BulletController();
            BulletModel bulletModel = new();
            bulletModel.SetPos(_model.SpawnPosition);
            bulletModel.DeSpawn();
            var bulletView = Object.Instantiate(_model.BulletPrefab, _model.SpawnPosition, Quaternion.identity,
                _view.bulletPoolTransform);

            InjectDependencies(bulletController);
            bulletController.Init(bulletView, bulletModel);
            bulletController.Spawn(Vector3.zero, _model.SpawnPosition, bulletModel);
            _model.AddBullet(bulletController);
            bulletView.gameObject.SetActive(false);
            return bulletController;
        }
    }
}