﻿using System;
using Agate.MVC.Base;
using SpacePlan.Module.Bullet.Model;
using SpacePlan.Module.Bullet.View;
using SpacePlan.Module.Spaceship.Base;
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
            SetView(bulletView);
            _model = bulletModel;
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
            _view.transform.position = position;
            _view.gameObject.SetActive(true);
            _model.Move(Vector2.up * _model.Speed);
            _view.Rigidbody2D.velocity = _model.Velocity;
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
            _model.DeSpawn();
            _view.gameObject.SetActive(false);
            _view.transform.position = _model.DeSpawnPosition;
        }
    }
}