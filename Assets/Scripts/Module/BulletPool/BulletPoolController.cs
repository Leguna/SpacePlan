using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Bullet.Controller;
using SpacePlan.Module.Bullet.Model;
using UnityEngine;

namespace SpacePlan.Module.BulletPool
{
    public class BulletPoolController : ObjectController<BulletPoolController, BulletPoolModel, BulletPoolView>
    {
        public void OnSpawnBullet(SpawnBulletMessage message)
        {
            var position = message.SpawnTransform.position;
            SpawnBullet(position);
        }

        public override void SetView(BulletPoolView view)
        {
            base.SetView(view);
            BulletPoolSetup();
        }

        private void SpawnBullet(Vector3 position)
        {
            BulletController bulletController = _model.GetBulletController();
            bulletController.Spawn(position, new BulletModel());
        }

        private void BulletPoolSetup()
        {
            for (int i = 0; i < _model.PoolSize; i++)
            {
                BulletController bulletController = new BulletController();
                BulletModel bulletModel = new();
                bulletModel.SetPos(_model.SpawnPosition);
                bulletModel.DeSpawn();
                var bulletView = Object.Instantiate(_model.BulletPrefab, _model.SpawnPosition, Quaternion.identity,
                    _view.bulletPoolTransform);

                InjectDependencies(bulletController);
                bulletController.Init(bulletView, bulletModel);
                bulletController.Spawn(_model.SpawnPosition, bulletModel);
                _model.AddBullet(bulletController);
                bulletView.gameObject.SetActive(false);
            }
        }
    }
}