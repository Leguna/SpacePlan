using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Boot;
using SpacePlan.Constant;
using SpacePlan.Module.Leaderboard;
using UnityEngine; 

namespace SpacePlan.Main
{
    public class MainLauncher : SceneLauncher<MainLauncher, MainView>

    {
        public override string SceneName => SceneConstant.mainMenu;

        private LeaderboardController _leaderBoardController;

        protected override IController[] GetSceneDependencies()
        {
            return new IController[]
           {
                new LeaderboardController()
           };
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.SetCallbacks(OnClickPlayButton, OnClickLeaderboardButton, OnClickExitButton);
            _leaderBoardController.SetView(_view.leaderboardView);
            yield return null;
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }


        private void OnClickPlayButton()
        {
            SceneLoader.Instance.LoadScene("Gameplay");
        }

        private void OnClickLeaderboardButton()
        {
            // TODO @Faisal: Remove this after implementing high score screen.
            Debug.Log("Show Score Board!");
            _view.leaderboardView.ShowView();
        }

        private void OnClickExitButton()
        {
            // TODO @Faisal: Remove this after implementing exit screen.
            Debug.Log("Quit Game!");
        }

    }
}