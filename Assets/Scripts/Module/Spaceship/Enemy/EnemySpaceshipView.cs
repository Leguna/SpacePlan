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
        private Action<IDamageable> _onHitEvent;

        public void SetCallbacks(Action<IDoingDamage> onTakeDamage)
        {
            _onTakeDamage = onTakeDamage;
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
    }
}