using Agate.MVC.Base;
using SpacePlan.Module.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpacePlan.Module.Leaderboard
{
    public class LeaderboardModel : BaseModel, ILeaderboardModel
    {
        public List<ScorePlayer> ScorePlayerList { get;  set; }

        public void SetListScorePlayer(List<ScorePlayer> newScorePlayerList)
        {
            ScorePlayerList = newScorePlayerList;
            SetDataAsDirty();
        }

        public void AddPlayerToLeaderBoard(ScorePlayer scorePlayer)
        {
            ScorePlayerList.Add(scorePlayer);
            ScorePlayerList.Sort();
        }
    }
}
