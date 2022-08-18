using System;
using Agate.MVC.Base;
using UnityEngine;

namespace SpacePlan.Module.Bullet
{
    public class BulletView : ObjectView<IBulletModel>
    {
        private Action<Collider2D> _onTriggerEnterEvent;
        [SerializeField] public Rigidbody2D Rigidbody2D;

        public void SetCallbacks(Action<Collider2D> onTriggerEnterEvent)
        {
            _onTriggerEnterEvent = onTriggerEnterEvent;
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
    }
}