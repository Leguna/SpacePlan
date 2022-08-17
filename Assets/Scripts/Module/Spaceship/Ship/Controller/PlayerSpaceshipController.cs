using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Base;
using SpacePlan.Module.Bullet.Controller;
using SpacePlan.Module.Bullet.Model;
using SpacePlan.Module.Bullet.View;
using SpacePlan.Module.Spaceship.Ship.Interfaces.SpaceshipTypes;
using SpacePlan.Module.Spaceship.Ship.Model;
using SpacePlan.Module.Spaceship.Ship.View;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Ship.Controller
{
    class PlayerSpaceshipController : ObjectController<PlayerSpaceshipController, PlayerSpaceshipModel,
        IPlayerSpaceshipModel,
        PlayerSpaceshipView>
    {
        private Rigidbody2D _rigidbody2D;

        public override void SetView(PlayerSpaceshipView view)
        {
            view.SetCallbacks(Init, SetVelocity, OnMove, OnShoot);
            view.gameObject.SetActive(true);
            view.TryGetComponent(out _rigidbody2D);
            base.SetView(view);
        }

        private void OnShoot()
        {
            Publish(new SpawnBulletMessage(_view.bulletSpawnTransform));
        }

        private void Init(float speed, Limit limit)
        {
            _model.SetSpeed(speed);
            _model.SetPos(_view.transform.position);
            _model.SetLimitHorizontalMovement(limit);
        }


        private void SetVelocity()
        {
            _rigidbody2D.velocity = _model.MoveVelocity;
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