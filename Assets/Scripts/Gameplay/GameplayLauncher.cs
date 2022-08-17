using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Boot;
using SpacePlan.Module.BulletPool;
using SpacePlan.Module.ClickGame;
using SpacePlan.Module.InputSystem;
using SpacePlan.Module.SoundFx;
using SpacePlan.Module.Spaceship.Enemy;
using SpacePlan.Module.Spaceship.Player;

namespace SpacePlan.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName => "Gameplay";

        private ClickGameController _clickGame;
        private SoundFxController _soundFx;
        private PlayerSpaceshipController _playerSpaceshipController;
        private SpaceshipInputController _spaceshipInputController;
        private BulletPoolController _bulletPoolController;
        private EnemySpaceshipController _enemySpaceshipController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
            {
                new ClickGameController(),
                new SoundFxController(),
                new SpaceshipInputController(),
                new PlayerSpaceshipController(),
                new BulletPoolController(),
                new EnemySpaceshipController()
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _clickGame.SetView(_view.ClickGameView);
            _soundFx.SetView(_view.SoundFxView);
            _playerSpaceshipController.SetView(_view.PlayerSpaceshipView);
            _bulletPoolController.SetView(_view.BulletPoolView);
            _enemySpaceshipController.SetView(_view.EnemySpaceshipView);
            yield return null;
        }


        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[]
            {
                new GameplayConnector(),
                new BulletPoolConnector()
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}