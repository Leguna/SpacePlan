using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Enemy
{
    public class
        EnemySpaceshipController : ObjectController<EnemySpaceshipController, EnemySpaceshipModel, IEnemySpaceshipModel,
            EnemySpaceshipView>
    {
        public override void SetView(EnemySpaceshipView view)
        {
            base.SetView(view);
            _view.SetCallbacks(OnCollisionEvent, OnTakeDamageEvent);
        }

        public void OnTakeDamageEvent(IDoingDamage doingDamage)
        {
            _model.TakeDamage(doingDamage.DamageValue);
        }

        public void OnCollisionEvent(Collider2D col)
        {
        }

        public void OnSpawn(Vector3 spawnPos)
        {
            _view.gameObject.SetActive(true);
        }

        public void OnDespawn()
        {
            _view.gameObject.SetActive(false);
        }
    }
}