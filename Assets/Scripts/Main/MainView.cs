using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using SpacePlan.Main;
using SpacePlan.Module.Leaderboard;

namespace SpacePlan.Main
{
    public class MainView : BaseSceneView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _leaderboardButton;
        [SerializeField] public LeaderboardView leaderboardView;

        public void SetCallbacks(UnityAction onClickPlayButton, UnityAction onClickLeaderboardButton, UnityAction onClickExitButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
            _leaderboardButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickPlayButton);
            _exitButton.onClick.AddListener(onClickExitButton);
            _leaderboardButton.onClick.AddListener(onClickLeaderboardButton);
        }

    }
}