using System.Collections.Generic;
using Agate.MVC.Base;
using SpacePlan.Module.Bullet.Controller;
using SpacePlan.Module.Bullet.View;
using UnityEngine;

namespace SpacePlan.Module.BulletPool
{
    public class BulletPoolModel : BaseModel
    {
        public BulletView BulletPrefab { get; }
        public List<BulletController> Bullets { get; }
        public Vector3 SpawnPosition { get; private set; }
        public Vector3 DeSpawnPosition { get; } = new(-20, 0, 0);

        public BulletPoolModel()
        {
            Bullets = new List<BulletController>();
            BulletPrefab = Resources.Load<BulletView>("Prefabs/Bullet");
        }

        public void AddBullet(BulletController bullet)
        {
            Bullets.Add(bullet);
            SetDataAsDirty();
        }

        public void RemoveBullet(BulletController bullet)
        {
            Bullets.Remove(bullet);
            SetDataAsDirty();
        }

        public void SetSpawnPosition(Vector3 position)
        {
            SpawnPosition = position;
            SetDataAsDirty();
        }

        public BulletController GetPoolController()
        {
            return new BulletController();
            foreach (var bullet in Bullets)
            {
                if (bullet.Model.IsDeath)
                {
                }
            }
        }
    }
}