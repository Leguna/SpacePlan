using System.Collections;
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

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
        }

        private void SpawnBullet(Vector3 position)
        {
            BulletController bulletController = new BulletController();
            BulletModel bulletModel = new();
            bulletModel.SetPos(position);

            var bulletView = Object.Instantiate(_model.BulletPrefab, position, Quaternion.identity,
                _view.bulletPoolTransform);

            InjectDependencies(bulletController);
            bulletController.Init(bulletView, bulletModel);
            bulletController.Spawn(position, bulletModel);
        }
    }
}