using System;
using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Enemy
{
    public class EnemySpaceshipView : ObjectView<IEnemySpaceshipModel>
    {
        [SerializeField] public Rigidbody2D enemyRigidbody;
        private Action<Collider2D> _onCollision;
        private Action<IDoingDamage> _onTakeDamage;

        public void SetCallbacks(Action<Collider2D> onCollision, Action<IDoingDamage> onTakeDamage)
        {
            _onCollision = onCollision;
            _onTakeDamage = onTakeDamage;
        }

        protected override void InitRenderModel(IEnemySpaceshipModel model)
        {
        }

        protected override void UpdateRenderModel(IEnemySpaceshipModel model)
        {
            enemyRigidbody.velocity = model.Velocity;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            _onCollision?.Invoke(col);
        }

        public void OnHitEvent(IDoingDamage damage)
        {
            _onTakeDamage?.Invoke(damage);
        }
    }
}