using System;
using Agate.MVC.Base;
using SpacePlan.Module.Bullet.Model;
using SpacePlan.Module.Bullet.View;
using SpacePlan.Module.Spaceship.Ship.Interfaces;
using UnityEngine;

namespace SpacePlan.Module.Bullet.Controller
{
    public class BulletController : ObjectController<BulletController, BulletModel, IBulletModel, BulletView>
    {
        private Action<Collider2D> _onHitEvent;
        private Action<Vector3> _onMoveEvent;

        public void Init(BulletView bulletView, BulletModel bulletModel)
        {
            _onHitEvent = OnHit;
            _onMoveEvent = OnMoveEvent;
            _model = bulletModel;
            SetView(bulletView);
            _model.Move(Vector2.up);
            _view.Rigidbody2D.velocity = _model.Velocity;
            _view.SetCallbacks(_onHitEvent, _onMoveEvent);
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

        public void Spawn(Vector3 position, BulletModel bulletModel)
        {
            _model = bulletModel;
            _view.transform.position = _model.Position;
            _view.gameObject.SetActive(true);
        }

        private void OnHit(Collider2D obj)
        {
            obj.TryGetComponent(out IDamageable damageable);
            if (damageable == null) return;

            damageable.TakeDamage(_model.DamageValue);
            _model.TakeDamage(1);
            if (_model.IsDeath) DeSpawn();
        }

        private void DeSpawn()
        {
            _view.gameObject.SetActive(false);
            _model.TakeDamage(999);
            _view.transform.position = _model.DeSpawnPosition;
        }
    }
}