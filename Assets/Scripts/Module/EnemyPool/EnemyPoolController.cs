﻿using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Spaceship.Enemy;
using UnityEngine;

namespace SpacePlan.Module.EnemyPool
{
    public class EnemyPoolController : ObjectController<EnemyPoolController, EnemyPoolModel, EnemyPoolView>
    {
        public override void SetView(EnemyPoolView view)
        {
            base.SetView(view);
            PoolSetup();
        }

        private void SpawnEnemy()
        {
            foreach (var enemySpaceshipController in _model.EnemyList)
            {
                enemySpaceshipController.Spawn();
            }
        }

        private void PoolSetup()
        {
            for (int i = 0; i < _model.PoolSize; i++)
            {
                AddObjectToPool(i);
            }
        }

        private EnemySpaceshipController AddObjectToPool(int index)
        {
            var enemySpaceshipController = new EnemySpaceshipController();
            EnemySpaceshipModel enemySpaceshipModel = new();
            enemySpaceshipModel.SetPos(GetSpawnPositionByIndex(index));
            enemySpaceshipModel.DeSpawn();
            var enemySpaceshipView = Object.Instantiate(_model.EnemyView, GetSpawnPositionByIndex(index),
                Quaternion.identity,
                _view.transform);

            InjectDependencies(enemySpaceshipController);
            enemySpaceshipController.Init(enemySpaceshipView, enemySpaceshipModel);
            _model.AddObjectPool(enemySpaceshipController);
            enemySpaceshipView.gameObject.SetActive(false);
            return enemySpaceshipController;
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
    }
}