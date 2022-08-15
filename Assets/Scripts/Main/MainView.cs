using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using SpacePlan.Main;

namespace SpacePlan.Main
{
    public class MainView : BaseSceneView
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _higscoreButton;

        public void SetCallbacks(UnityAction onClickPlayButton, UnityAction onClickHigsScoreButton, UnityAction onClickExitButton)
        {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(onClickPlayButton);
            _exitButton.onClick.RemoveAllListeners();
            _exitButton.onClick.AddListener(onClickExitButton);
            _higscoreButton.onClick.RemoveAllListeners();
            _higscoreButton.onClick.AddListener(onClickHigsScoreButton);
        }

    }
}