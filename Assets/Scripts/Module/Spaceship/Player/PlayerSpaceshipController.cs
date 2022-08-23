using System;
using System.Timers;
using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Player
{
    class PlayerSpaceshipController : ObjectController<PlayerSpaceshipController, PlayerSpaceshipModel,
        IPlayerSpaceshipModel,
        PlayerSpaceshipView>
    {
        private Rigidbody2D _rigidbody2D;

        private Timer Timer { get; } = new();

        public override void SetView(PlayerSpaceshipView view)
        {
            view.SetCallbacks(Init, SetVelocity, OnMove, OnShoot);
            view.gameObject.SetActive(true);
            view.TryGetComponent(out _rigidbody2D);
            base.SetView(view);
        }

        private void OnShoot()
        {
            Publish(new SpawnBulletMessage(_view.bulletSpawnTransform.position, _model.DamageValue, _model.BulletHealth,
                Vector3.up));
        }

        private void Init(float speed, Limit limit)
        {
            _model.SetSpeed(speed);
            _model.SetPos(_view.transform.position);
            _model.SetLimitHorizontalMovement(limit);
        }

        public void OnGetPowerUpEvent(PowerUpMessage message)
        {
            if (message.PowerUpType == PowerUpType.PlayerBulletHealth)
            {
                void OnStart() => _model.SetBulletHealth(message.PowerUpValue);

                void OnFinish()
                {
                    _model.SetBulletHealth(1);
                }

                StartPowerUpBulletHealth(message.Duration, OnStart, OnFinish);
            }
        }

        private void StartPowerUpBulletHealth(float interval, Action onStart, Action onFinish)
        {
            onStart?.Invoke();
            Timer.Interval = interval;
            Timer.Elapsed += (sender, args) => onFinish?.Invoke();
            Timer.Start();
        }

        private void SetVelocity()
        {
            _rigidbody2D.velocity = _model.Velocity;
        }

        private void OnMove()
        {
            if (_model == null) return;

            var position = _view.transform.position;
            _model.SetPos(position);
            _model.CheckMoveBoundaries();
        }

        public void OnMoveInput(Vector2 messageDirection)
        {
            _model.Move(messageDirection);
        }
    }
}