using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Boot;
using SpacePlan.Constant;
using SpacePlan.Message;
using SpacePlan.Module.BulletPool;
using SpacePlan.Module.ClickGame;
using SpacePlan.Module.EnemyPool;
using SpacePlan.Module.InputSystem;
using SpacePlan.Module.PowerUpPool;
using SpacePlan.Module.SoundFx;
using SpacePlan.Module.Spaceship.Player;
using SpacePlan.Module.Spaceship.PowerUp;

namespace SpacePlan.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => SceneConstant.gamePlay;

        private ClickGameController _clickGame;
        private SoundFxController _soundFx;
        private PlayerSpaceshipController _playerSpaceshipController;
        private SpaceshipInputController _spaceshipInputController;
        private BulletPoolController _bulletPoolController;
        private EnemyPoolController _enemyPoolController;
        private PowerUpPoolController _powerUpPoolController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new ClickGameController(),
                new SoundFxController(),
                new SpaceshipInputController(),
                new PlayerSpaceshipController(),
                new BulletPoolController(),
                new EnemyPoolController(),
                new PowerUpPoolController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _clickGame.SetView(_view.ClickGameView);
            _soundFx.SetView(_view.SoundFxView);
            _playerSpaceshipController.SetView(_view.PlayerSpaceshipView);
            _bulletPoolController.SetView(_view.BulletPoolView);
            _enemyPoolController.SetView(_view.EnemyPoolView);
            _powerUpPoolController.SetView(_view.PowerUpPoolView);
            Publish(new StartGameMessage(true));
            yield return null;
        }


        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new GameplayConnector(),
                new BulletPoolConnector(),
                new EnemyPoolConnector(),
                new PlayerSpaceshipConnector(),
                new PowerUpPoolConnector()
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}