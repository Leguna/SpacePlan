using System;
using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Enemy
{
    public class EnemySpaceshipView : ObjectView<IEnemySpaceshipModel>, IDamageableView
    {
        [SerializeField] public Rigidbody2D enemyRigidbody;
        private Action<IDoingDamage> _onTakeDamage;
        private Action _onMove;

        public void SetCallbacks(Action<IDoingDamage> onTakeDamage, Action onMove)
        {
            _onTakeDamage = onTakeDamage;
            _onMove = onMove;
        }

        protected override void InitRenderModel(IEnemySpaceshipModel model)
        {
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