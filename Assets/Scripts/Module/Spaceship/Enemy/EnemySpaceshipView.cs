using System;
using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Enemy
{
    public class EnemySpaceshipView : ObjectView<IEnemySpaceshipModel>, IDamageableView
    {
        [SerializeField] public Rigidbody2D enemyRigidbody;
        [SerializeField] public Transform bulletSpawnTransform;
        private Action<IDoingDamage> _onTakeDamage;
        private Action _onMove;
        private Action _onShoot;

        public void SetCallbacks(Action<IDoingDamage> onTakeDamage, Action onMove, Action onShoot)
        {
            _onTakeDamage = onTakeDamage;
            _onMove = onMove;
            _onShoot = onShoot;
        }

        protected override void InitRenderModel(IEnemySpaceshipModel model)
        {
            enemyRigidbody.velocity = model.Velocity;
            InvokeRepeating(nameof(ShootEvent), _model.FireRate, _model.FireRate);
        }

        private void ShootEvent()
        {
            _onShoot?.Invoke();
        }

        protected override void UpdateRenderModel(IEnemySpaceshipModel model)
        {
            enemyRigidbody.velocity = model.Velocity;
        }

        public void OnHitEvent(IDoingDamage damage)
        {
            _onTakeDamage?.Invoke(damage);
        }

        private void Update()
        {
            _onMove?.Invoke();
        }
    }
}