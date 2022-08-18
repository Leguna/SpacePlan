using System;
using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.PowerUp;
using UnityEngine;

namespace SpacePlan.Module.PowerUpPool
{
    public class PowerUpPoolView : ObjectView<IPowerUpPoolModel>
    {
        private float _time;
        private Action _spawnPowerUp;

        public void SetCallback(Action spawnPowerUp)
        {
            Debug.Log("TES");
            _spawnPowerUp = spawnPowerUp;
        }

        private void Update()
        {
            if (_model == null) return;
            Debug.Log(_model);

            _time += Time.deltaTime;
            if (_time >= _model.SpawnTime)
            {
                _time = 0;
                _spawnPowerUp?.Invoke();
            }
        }


        protected override void InitRenderModel(IPowerUpPoolModel model)
        {
        }

        protected override void UpdateRenderModel(IPowerUpPoolModel model)
        {
        }
    }
}