using Agate.MVC.Base;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using SpacePlan.Module.Base;
using System.Collections.Generic;

namespace SpacePlan.Module.Leaderboard
{
    public class LeaderboardView : ObjectView<ILeaderboardModel>
    {
        [SerializeField] private TMP_Text _playerHighScoreText;
        [SerializeField] private TMP_Text _playerNameText;
        [SerializeField] private Button _backButton;
        
        // TODO Remove this
        [SerializeField] public List<ScorePlayer> dummyScorePlayers;

        protected override void InitRenderModel(ILeaderboardModel model)
        {
             SetLeaderboardView(dummyScorePlayers);
            // SetLeaderboardView(model.ScorePlayerList);
            //_playerHighScoreText.text = $"Player: {model.ScorePlayerList}";
        }
 
        void SetLeaderboardView(List<ScorePlayer> scorePlayers)
        {
            for (int i = 0; i < scorePlayers.Count; i++)
            {
                _playerHighScoreText.text = scorePlayers[i].PlayerName;
                _playerHighScoreText.text = scorePlayers[i].Score.ToString();
            }

        }

        protected override void UpdateRenderModel(ILeaderboardModel model)
        {
          
        }

        public void SetCallBacks(UnityAction onClickBack)
        {
            _backButton.onClick.RemoveAllListeners();
            _backButton.onClick.AddListener(onClickBack);
        }

        public void HideView()
        {
            gameObject.SetActive(false);
        }

        public void ShowView()
        {
            gameObject.SetActive(true);
        }
    }
}