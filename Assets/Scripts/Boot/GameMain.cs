using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using SpacePlan.Module.Leaderboard;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpacePlan.Boot
{
    public class GameMain : BaseMain<GameMain>, IMain
    {
        protected override IController[] GetDependencies()
        {
            return new IController[]{
                new LeaderboardController()
            };
        }

        protected override IEnumerator StartInit()
        {
            CreateEventSystem();
            yield return null;
        }

        protected override IConnector[] GetConnectors()
        {
            return null;
        }

        private void CreateEventSystem()
        {
            GameObject obj = new("Event System");
            obj.AddComponent<EventSystem>();
            obj.AddComponent<StandaloneInputModule>();
            GameObject.DontDestroyOnLoad(obj);
        }
    }
}