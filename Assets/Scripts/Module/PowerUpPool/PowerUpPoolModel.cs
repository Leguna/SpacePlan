using System.Collections.Generic;
using System.Linq;
using Agate.MVC.Base;
using SpacePlan.Module.Base;
using SpacePlan.Module.Spaceship.PowerUp;
using UnityEngine;

namespace SpacePlan.Module.PowerUpPool
{
    public class PowerUpPoolModel : BaseModel, IPowerUpPoolModel
    {
        public int PoolSize { get; }
        public PowerUpView PowerUpView { get; }
        public List<PowerUpController> PowerUpList { get; }
        public Vector3 SpawnPosition { get; private set; }

        public Limit LimitSpawnX { get; }
        public Limit RandomPowerUpSpawnDelay { get; }

        public PowerUpPoolModel()
        {
            RandomPowerUpSpawnDelay = new Limit { Min = 7, Max = 15 };
            SpawnTime = GetRandomSpawnTime();
            LimitSpawnX = new Limit { Min = -4, Max = 7 };
            PowerUpList = new List<PowerUpController>();
            PowerUpView = Resources.Load<PowerUpView>("Prefabs/PowerUp");
            PoolSize = 4;
        }

        private float GetRandomSpawnTime()
        {
            return Random.Range(RandomPowerUpSpawnDelay.Min, RandomPowerUpSpawnDelay.Max);
        }

        public void AddObjectPool(PowerUpController powerUpController)
        {
            PowerUpList.Add(powerUpController);
            SetDataAsDirty();
        }

        public PowerUpController GetObjectController()
        {
            return PowerUpList.FirstOrDefault(powerUpController => powerUpController.Model.IsDeath);
        }

        public float SpawnTime { get; }

        public void SetStart(bool isPlaying)
        {
            IsPlaying = isPlaying;
        }

        public bool IsPlaying { private set; get; }
    }
}