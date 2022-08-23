using System;
using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Bullet
{
    public class BulletController : ObjectController<BulletController, BulletModel, IBulletModel, BulletView>
    {
        private Action<Collider2D> _onHitEvent;

        public void Init(BulletView bulletView, BulletModel bulletModel)
        {
            _onHitEvent = OnHit;
            SetView(bulletView);
            _model = bulletModel;
            _view.SetCallbacks(_onHitEvent, OnMoveEvent);
        }

        private void OnMoveEvent(Vector3 pos)
        {
            _model.SetPos(pos);
            CheckDeSpawnPos(pos);
        }

        private void CheckDeSpawnPos(Vector3 pos)
        {
            if (_model.IsLimitReached) DeSpawn();
        }

        public void Spawn(Vector3 dir, Vector3 position, BulletModel bulletModel)
        {
            _model = bulletModel;
            _view.transform.position = position;
            _view.gameObject.SetActive(true);
            _model.Move(dir * _model.Speed);
            _view.Rigidbody2D.velocity = _model.Velocity;
        }

        private void OnHit(Collider2D obj)
        {
            obj.TryGetComponent(out IDamageableView damageableView);
            damageableView?.OnHitEvent(_model);

            _model.TakeDamage(1);
            if (_model.IsDeath) DeSpawn();
        }

        private void DeSpawn()
        {
            _model.DeSpawn();
            _view.gameObject.SetActive(false);
            _view.transform.position = _model.DeSpawnPosition;
        }
    }
}