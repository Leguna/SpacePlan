using System.Timers;
using Agate.MVC.Base;
using SpacePlan.Message;
using SpacePlan.Module.Spaceship.PowerUp;
using UnityEngine;

namespace SpacePlan.Module.PowerUpPool
{
    public class PowerUpPoolController : ObjectController<PowerUpPoolController, PowerUpPoolModel, IPowerUpPoolModel,
        PowerUpPoolView>
    {
        private Timer Timer { get; } = new();

        public override void SetView(PowerUpPoolView view)
        {
            base.SetView(view);
            _view.SetCallback(SpawnPowerUp);
            PoolSetup();
        }

        private void SpawnPowerUp()
        {
            if (!_model.IsPlaying) return;
            var objectController = _model.GetObjectController() ?? AddObjectToPool();
            objectController.Spawn(new PowerUpModel(), GetRandomPos());
        }

        private Vector2 GetRandomPos()
        {
            var randomX = Random.Range(minInclusive: _model.LimitSpawnX.Min, maxInclusive: _model.LimitSpawnX.Max);
            return new Vector2(randomX, _view.transform.position.y);
        }

        public void StartPowerUpEvent(StartGameMessage message)
        {
            _model.SetStart(true);
        }

        void OnStart()
        {
            Debug.Log("Start Power Up");
            var objectController = _model.GetObjectController() ?? AddObjectToPool();
            objectController.Spawn(new PowerUpModel(), GetRandomPos());
        }

        private void PoolSetup()
        {
            for (int i = 0; i < _model.PoolSize; i++)
            {
                AddObjectToPool();
            }
        }

        private PowerUpController AddObjectToPool()
        {
            var powerUpController = new PowerUpController();
            PowerUpModel powerUpModel = new();
            powerUpModel.SetPos(GetRandomPos());
            powerUpModel.DeSpawn();
            PowerUpView spaceshipView =
                Object.Instantiate(_model.PowerUpView, GetRandomPos(), Quaternion.identity, _view.transform);

            InjectDependencies(powerUpController);
            powerUpController.Init(spaceshipView, powerUpModel);
            _model.AddObjectPool(powerUpController);
            spaceshipView.gameObject.SetActive(false);
            return powerUpController;
        }
    }
}