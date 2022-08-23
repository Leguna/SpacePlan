using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.PowerUp
{
    public class
        PowerUpController : ObjectController<PowerUpController, PowerUpModel, IPowerUpModel,
            PowerUpView>
    {
        public override void SetView(PowerUpView view)
        {
            base.SetView(view);
            _view.SetCallbacks(OnHitEvent, OnPositionUpdate);
        }

        private void OnPositionUpdate(Vector3 obj)
        {
            _model.SetPos(obj);
            if (obj.y <= _model.LimitY.Min)
            {
                _model.DeSpawn();
                _view.gameObject.SetActive(false);
            }
        }

        private void OnHitEvent(IDoingDamage doingDamage)
        {
            _model.TakeDamage(doingDamage.DamageValue);
            if (_model.IsDeath)
            {
                _view.gameObject.SetActive(false);
                _model.DeSpawn();
                Publish(new PowerUpMessage(_model.Duration, _model.Type, _model.Value));
            }
        }

        public void Init(PowerUpView powerUpView, PowerUpModel powerUpModel)
        {
            _model = powerUpModel;
            SetView(powerUpView);
        }

        public void Spawn(PowerUpModel model, Vector2 position)
        {
            _view.gameObject.SetActive(true);
            _model = model;
            _model.Move(Vector2.down * _model.Speed);
            _view.transform.position = position;
            _view.Rigidbody2D.velocity = model.Velocity;
        }
    }
}