using System;
using Agate.MVC.Base;
using SpacePlan.Module.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Player
{
    public class PlayerSpaceshipView : ObjectView<IPlayerSpaceshipModel>
    {
        [SerializeField] public Transform bulletSpawnTransform;
        [SerializeField] private float Speed;
        [SerializeField] private Limit LimitHorizontalMovement;
        private Action _checkMoveCallback;
        private Action _onSetVelocity;
        private Action _onShoot;
        private Action<float, Limit> _onInitCallback;

        public void SetCallbacks(Action<float, Limit> initCallback, Action onSetVelocity,
            Action checkMoveCallback, Action onShoot
        )
        {
            _onInitCallback = initCallback;
            _onSetVelocity = onSetVelocity;
            _checkMoveCallback = checkMoveCallback;
            _onShoot = onShoot;
        }

        protected override void InitRenderModel(IPlayerSpaceshipModel model)
        {
            _onInitCallback?.Invoke(Speed, LimitHorizontalMovement);
            InvokeRepeating(nameof(ShootRepeat), _model.FireRate, _model.FireRate);
        }

        private void ShootRepeat()
        {
            _onShoot?.Invoke();
        }

        protected override void UpdateRenderModel(IPlayerSpaceshipModel model)
        {
            _onSetVelocity?.Invoke();
        }

        private void FixedUpdate()
        {
            _checkMoveCallback?.Invoke();
        }
    }
}