using System;
using Agate.MVC.Base;
using UnityEngine;

namespace SpacePlan.Module.Bullet
{
    public class BulletView : ObjectView<IBulletModel>
    {
        private Action<Collider2D> _onTriggerEnterEvent;
        [SerializeField] public Rigidbody2D Rigidbody2D;
        private Action<Vector3> _onMoveEvent;

        public void SetCallbacks(Action<Collider2D> onTriggerEnterEvent, Action<Vector3> onMoveEvent)
        {
            _onTriggerEnterEvent = onTriggerEnterEvent;
            _onMoveEvent = onMoveEvent;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            _onTriggerEnterEvent?.Invoke(col);
        }

        protected override void InitRenderModel(IBulletModel model)
        {
        }

        protected override void UpdateRenderModel(IBulletModel model)
        {
        }

        private void FixedUpdate()
        {
            _onMoveEvent?.Invoke(transform.position);
        }
    }
}