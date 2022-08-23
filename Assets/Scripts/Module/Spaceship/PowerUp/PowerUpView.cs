using System;
using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.PowerUp
{
    public class PowerUpView : ObjectView<IPowerUpModel>, IDamageableView
    {
        private Action<IDoingDamage> _onHitEvent;
        private Action<Vector3> _onPositionUpdate;

        [SerializeField] public Rigidbody2D Rigidbody2D;

        public void SetCallbacks(Action<IDoingDamage> onHitEvent, Action<Vector3> onPositionUpdate)
        {
            _onHitEvent = onHitEvent;
            _onPositionUpdate = onPositionUpdate;
        }

        public void OnHitEvent(IDoingDamage damage)
        {
            _onHitEvent?.Invoke(damage);
        }

        public void Update()
        {
            _onPositionUpdate?.Invoke(transform.position);
        }

        protected override void InitRenderModel(IPowerUpModel model)
        {
            Rigidbody2D.velocity = model.Velocity;
        }

        protected override void UpdateRenderModel(IPowerUpModel model)
        {
        }
    }
}