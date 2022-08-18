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
            _view.SetCallbacks(OnTakeDamageEvent, OnMoveEvent, Shoot);
        }

        private void OnMoveEvent()
        {
            _model.SetPos(_view.transform.position);
            _model.DelayedMove();
        }

        private void Shoot()
        {
            // TODO @Leguna: Implement Enemy Shoot
            // Debug.Log($"Shoot");
            // if (CheckIsFrontEnemy()) return;
            // Publish(new SpawnBulletMessage(_view.transform.position + Vector3.down, _model.DamageValue,
            //     _model.BulletHealth,
            //     Vector2.down));
        }

        private bool CheckIsFrontEnemy()
        {
            int layerMask = ~(LayerMask.GetMask("Enemy"));

            var raycastHit2D = Physics2D.Raycast(_view.transform.position, Vector2.down, 10f,
                layerMask);
            if (raycastHit2D) return raycastHit2D.collider.gameObject.CompareTag("Enemy");
            return false;
        }

        public void OnTakeDamageEvent(IDoingDamage doingDamage)
        {
            _model.TakeDamage(doingDamage.DamageValue);
            if (_model.IsDeath)
            {
                DeSpawn();
                Publish(new AddScoreMessage(_model.ScoreValue));
                Publish(new EnemyDestroyedMessage());
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

        public void Spawn(Vector2 pos)
        {
            _model = new EnemySpaceshipModel(pos);
            _view.transform.position = pos;
            _model.DelayedMove();
            _view.SetModel(_model);
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