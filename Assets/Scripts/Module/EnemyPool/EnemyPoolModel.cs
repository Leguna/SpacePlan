using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Enemy;
using UnityEngine;

namespace SpacePlan.Module.EnemyPool
{
    public class EnemyPoolModel : BaseModel
    {
        public int PoolSize { get; }
        public EnemySpaceshipView EnemyView { get; }
        public List<EnemySpaceshipController> EnemyList { get; }
        public Vector3 SpawnPosition { get; private set; }

        public Vector3 Offset { get; } = new(-7, 2, 0);
        public float Gap => 1;
        public int Column => 15;

        public EnemyPoolModel()
        {
            EnemyList = new List<EnemySpaceshipController>();
            EnemyView = Resources.Load<EnemySpaceshipView>("Prefabs/Enemy");
            PoolSize = 60;
        }

        public void AddObjectPool(EnemySpaceshipController enemySpaceship)
        {
            EnemyList.Add(enemySpaceship);
            SetDataAsDirty();
        }

        public void RemoveBullet(EnemySpaceshipController enemySpaceship)
        {
            EnemyList.Remove(enemySpaceship);
            SetDataAsDirty();
        }

        public void SetSpawnPosition(Vector3 position)
        {
            SpawnPosition = position;
            SetDataAsDirty();
        }

        public EnemySpaceshipController GetObjectController()
        {
            return EnemyList.FirstOrDefault(enemySpaceshipController => enemySpaceshipController.Model.IsDeath);
        }

        public int AliveCount()
        {
            int count = 0;
            foreach (var enemySpaceshipController in EnemyList)
            {
                if (!enemySpaceshipController.Model.IsDeath) count++;
            }

            Debug.Log($"Alive count: {count}");
            return count;
        }
    }
}