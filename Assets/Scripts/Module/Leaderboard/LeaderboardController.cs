using System.Collections;
using System.Collections.Generic;
using Agate.MVC.Base;
using SpacePlan.Constant;
using SpacePlan.Message;
using SpacePlan.Module.Base;
using UnityEngine;

namespace SpacePlan.Module.Leaderboard
{
    public class LeaderboardController : ObjectController<LeaderboardController, LeaderboardModel, ILeaderboardModel,
        LeaderboardView>
    {
        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            //_model.SetScorePlayer(_saveData.Model.ScorePlayerList);
            LoadData();
        }

        public void OnGameOver(GameOverMessage message)
        {
            _model.AddPlayerToLeaderBoard(message.ScorePlayer);
            SaveData();
        }

        public void OnUpdateLeaderboard(List<ScorePlayer> listScorePlayer)
        {
            _model.SetListScorePlayer(listScorePlayer);
            SaveData();
        }


        private void SaveData()
        {
            PlayerPrefs.SetString(DataBaseConstant.leaderBoard, JsonUtility.ToJson(_model.ScorePlayerList));
            PlayerPrefs.Save();
        }

        private void LoadData()
        {
            string scoreListJson = PlayerPrefs.GetString(DataBaseConstant.leaderBoard);
            List<ScorePlayer> scoreList = JsonUtility.FromJson<List<ScorePlayer>>(scoreListJson);
            _model.SetListScorePlayer(scoreList ?? new List<ScorePlayer>());
        }

        private void OnClickBack()
        {
            _view.HideView();
        }

        public override void SetView(LeaderboardView view)
        {
            base.SetView(view);
            view.SetCallBacks(OnClickBack);
        }
    }
}