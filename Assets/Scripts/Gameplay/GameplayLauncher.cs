using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Boot;
using SpacePlan.Constant;
using SpacePlan.Message;
using SpacePlan.Module.Base;
using SpacePlan.Module.BulletPool;
using SpacePlan.Module.EnemyPool;
using SpacePlan.Module.InputSystem;
using SpacePlan.Module.PowerUpPool;
using SpacePlan.Module.ScoreGameplay;
using SpacePlan.Module.SoundFx;
using SpacePlan.Module.Spaceship.Player;

namespace SpacePlan.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => SceneConstant.gamePlay;

        private SoundFxController _soundFx;
        private PlayerSpaceshipController _playerSpaceshipController;
        private SpaceshipInputController _spaceshipInputController;
        private BulletPoolController _bulletPoolController;
        private EnemyPoolController _enemyPoolController;
        private PowerUpPoolController _powerUpPoolController;
        private ScoreGameplayController _scoreGameplayController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new SoundFxController(),
                new SpaceshipInputController(),
                new PlayerSpaceshipController(),
                new BulletPoolController(),
                new EnemyPoolController(),
                new PowerUpPoolController(),
                new ScoreGameplayController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _playerSpaceshipController.SetView(_view.PlayerSpaceshipView);
            _bulletPoolController.SetView(_view.BulletPoolView);
            _enemyPoolController.SetView(_view.EnemyPoolView);
            _powerUpPoolController.SetView(_view.PowerUpPoolView);
            _scoreGameplayController.SetView(_view.ScoreGameplayView);
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
                new PowerUpPoolConnector(),
                new ScoreGameplayConnector()
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}