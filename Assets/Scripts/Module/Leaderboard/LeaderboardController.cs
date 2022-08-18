using Agate.MVC.Base;
using SpacePlan.Constant;
using SpacePlan.Message;
using SpacePlan.Module.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpacePlan.Module.Leaderboard
{
    public class LeaderboardController : ObjectController<LeaderboardController, LeaderboardModel, ILeaderboardModel, LeaderboardView>
    {


        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            //_model.SetScorePlayer(_saveData.Model.ScorePlayerList);

        }

        public void OnGetNewPlayerScore(UpdateScoreMessage scoreMessage)
        {

        }

        public void OnUpdateLeaderboard(List<EntryHighscore> listScorePlayer)
        {
            _model.SetListScorePlayer(listScorePlayer);
            SaveData();
        }

        private void SaveData()
        {
            PlayerPrefs.SetString(DataBaseConstant.leaderBoard, JsonUtility.ToJson(_model.entryHighscores));
            PlayerPrefs.Save();
        }

        private void LoadData()
        {
            Debug.Log("score loaded");
            string scoreListJson = PlayerPrefs.GetString(DataBaseConstant.leaderBoard);
            List<EntryHighscore> scoreList = JsonUtility.FromJson<List<EntryHighscore>>(scoreListJson);

            if (scoreList == null)
            {
                scoreList = new List<EntryHighscore>
                {
                    new EntryHighscore(){score = 1232, name= "sasa"},
                    new EntryHighscore(){score = 5445, name= "asas"},
                    new EntryHighscore(){score = 7676, name= "etef"},
                    new EntryHighscore(){score = 9898, name= "ksls"},
                    new EntryHighscore(){score = 7676, name= "etef"},
                    new EntryHighscore(){score = 9898, name= "ksls"},
                };
            }
            _model.SetListScorePlayer(scoreList);
        }

        private void OnClickBack()
        {
            _view.HideView();
        }

        public override void SetView(LeaderboardView view)
        {
            base.SetView(view);
            view.SetCallBacks(OnClickBack);
            LoadData();
        }
    }
}