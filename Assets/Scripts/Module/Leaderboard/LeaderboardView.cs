using Agate.MVC.Base;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace SpacePlan.Module.Leaderboard
{
    public class LeaderboardView : ObjectView<ILeaderboardModel>
    {
        [SerializeField] private Button _backButton;
        [SerializeField] public List<Transform> ListPlayerScoreItem;

        protected override void InitRenderModel(ILeaderboardModel model)
        {
            // SetLeaderboardView(model.ScorePlayerList);
            //_playerHighScoreText.text = $"Player: {model.ScorePlayerList}";
        }

        /*   void SetLeaderboardView(List<ScorePlayer> scorePlayers)
           {
               for (int i = 0; i < scorePlayers.Count; i++)
               {
                   _playerHighScoreText.text = scorePlayers[i].name;
                   _playerHighScoreText.text = scorePlayers[i].score.ToString();
               }
           }*/

        protected override void UpdateRenderModel(ILeaderboardModel model)
        {
            for (int i = 0; i < model.limitLeaderboard; i++)
            {
                if (ListPlayerScoreItem == null) return;
                TMP_Text posText = ListPlayerScoreItem[i]?.Find("pos tmp")?.GetComponent<TMP_Text>();
                TMP_Text scoreText = ListPlayerScoreItem[i]?.Find("score tmp")?.GetComponent<TMP_Text>();
                TMP_Text nameText = ListPlayerScoreItem[i]?.Find("name tmp")?.GetComponent<TMP_Text>();
                ListPlayerScoreItem[i]?.gameObject.SetActive(true);

                if (i >= model.entryHighscores.Count)
                {
                    posText.text = "";
                    scoreText.text = "";
                    nameText.text = "";
                    continue;
                }

                if (model.entryHighscores.Count == 0) break;

                posText.text = $"{i + 1}";
                scoreText.text = model.entryHighscores[i].score.ToString();
                nameText.text = model.entryHighscores[i].name;
            }
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