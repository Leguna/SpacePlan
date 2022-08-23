using System.Collections.Generic;
using Agate.MVC.Base;
using SpacePlan.Module.Bullet;
using UnityEngine;

namespace SpacePlan.Module.BulletPool
{
    public class BulletPoolModel : BaseModel
    {
        public int PoolSize { get; }
        public BulletView BulletPrefab { get; }
        public List<BulletController> Bullets { get; }
        public Vector3 SpawnPosition { get; private set; }

        public BulletPoolModel()
        {
            Bullets = new List<BulletController>();
            BulletPrefab = Resources.Load<BulletView>("Prefabs/Bullet");
            PoolSize = 4;
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

        public BulletController GetBulletController()
        {
            foreach (var bullet in Bullets)
            {
                if (bullet.Model.IsDeath)
                {
                    return bullet;
                }
            }
            return null;
        }
    }
}