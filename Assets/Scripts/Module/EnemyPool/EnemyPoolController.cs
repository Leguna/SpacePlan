using System.Timers;
using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Spaceship.Enemy;
using UnityEngine;

namespace SpacePlan.Module.EnemyPool
{
    public class EnemyPoolController : ObjectController<EnemyPoolController, EnemyPoolModel, EnemyPoolView>
    {
        private Timer _timer = new();

        public override void SetView(EnemyPoolView view)
        {
            base.SetView(view);
            PoolSetup();
        }

        private void SpawnEnemy()
        {
            foreach (var enemySpaceshipController in _model.EnemyList)
            {
                enemySpaceshipController.Spawn(enemySpaceshipController.Model.SpawnPosition);
            }
        }

        private void PoolSetup()
        {
            for (int i = 0; i < _model.PoolSize; i++)
            {
                AddObjectToPool(i);
            }
        }

        private void AddObjectToPool(int index)
        {
            var enemySpaceshipController = new EnemySpaceshipController();
            EnemySpaceshipModel enemySpaceshipModel = new(GetSpawnPositionByIndex(index));
            var enemySpaceshipView = Object.Instantiate(_model.EnemyView, GetSpawnPositionByIndex(index),
                Quaternion.identity,
                _view.transform);

            InjectDependencies(enemySpaceshipController);
            enemySpaceshipController.Init(enemySpaceshipView, enemySpaceshipModel);
            _model.AddObjectPool(enemySpaceshipController);
            enemySpaceshipModel.DeSpawn();
            enemySpaceshipView.gameObject.SetActive(false);
        }

        private Vector3 GetSpawnPositionByIndex(int index)
        {
            var spawnPos = _view.transform.position + _model.Offset;
            spawnPos += new Vector3((_model.Gap * (index % _model.Column)),
                -(_model.Gap * (int)((float)index / _model.Column)));

            return spawnPos;
        }

        public void SpawnEnemyEvent(StartGameMessage message)
        {
            if (!message.IsPlaying) return;

            SpawnEnemy();
        }

        public void OnEnemyDestroyed(EnemyDestroyedMessage message)
        {
            if (_model.AliveCount() <= 0)
            {
                // TODO @Leguna: Implement respawn when enemy can shoot
                // SpawnEnemy();
                Publish(new EnemyCountMessage(_model.AliveCount()));
            }
        }
    }
}