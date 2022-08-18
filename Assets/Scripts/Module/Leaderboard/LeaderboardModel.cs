using System.Collections.Generic;
using Agate.MVC.Base;
using SpacePlan.Module.Base;

namespace SpacePlan.Module.Leaderboard
{
    public class LeaderboardModel : BaseModel, ILeaderboardModel
    {
        public List<ScorePlayer> ScorePlayerList { get; private set; } = new();

        public void SetListScorePlayer(List<ScorePlayer> newScorePlayerList)
        {
            ScorePlayerList = newScorePlayerList;
            SetDataAsDirty();
        }

        public void AddPlayerToLeaderBoard(ScorePlayer scorePlayer)
        {
            ScorePlayerList.Add(scorePlayer);
            ScorePlayerList.Sort();
            SetDataAsDirty();
        }
    }
}