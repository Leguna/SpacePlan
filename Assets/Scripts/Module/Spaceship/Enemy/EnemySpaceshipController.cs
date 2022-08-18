using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Enemy
{
    public class
        EnemySpaceshipController : ObjectController<EnemySpaceshipController, EnemySpaceshipModel, IEnemySpaceshipModel,
            EnemySpaceshipView>
    {
        public override void SetView(EnemySpaceshipView view)
        {
            base.SetView(view);
            _view.SetCallbacks(OnTakeDamageEvent, OnMoveEvent);
        }

        private void OnMoveEvent()
        {
            _model.DelayedMove();
        }

        public void OnTakeDamageEvent(IDoingDamage doingDamage)
        {
            _model.TakeDamage(doingDamage.DamageValue);
            if (_model.IsDeath)
            {
                Publish(new AddScoreMessage(_model.ScoreValue));
                DeSpawn();

            }
        }

        public void OnSpawn(Vector3 spawnPos)
        {
            _model = new EnemySpaceshipModel();
            _model.SetPos(spawnPos);
            _view.gameObject.SetActive(true);
        }

        private void DeSpawn()
        {
            _model.DeSpawn();
            _view.gameObject.SetActive(false);
        }

        public void Init(EnemySpaceshipView enemySpaceshipView, EnemySpaceshipModel enemySpaceshipModel)
        {
            _model = enemySpaceshipModel;
            SetView(enemySpaceshipView);
        }

        public void Spawn()
        {
            _view.gameObject.SetActive(true);
        }

        public void Move(MoveDirection moveDir)
        {
        }

        public void StartMove()
        {
        }
    }
}