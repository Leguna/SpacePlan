using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Boot;
using SpacePlan.Constant;
using UnityEngine;

namespace SpacePlan.Main
{
    public class MainLauncher : SceneLauncher<MainLauncher, MainView>

    {
        public override string SceneName => SceneConstant.mainMenu;

        protected override IController[] GetSceneDependencies()
        {
            return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            _view.SetCallbacks(OnClickPlayButton, OnClickHighScoreButton, OnClickExitButton);
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

        private void OnClickHighScoreButton()
        {
            // TODO @Faisal: Remove this after implementing high score screen.
            Debug.Log("Show Score Board!");
        }

        private void OnClickExitButton()
        {
            // TODO @Faisal: Remove this after implementing exit screen.
            Debug.Log("Quit Game!");
        }
    }
}