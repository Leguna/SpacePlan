using Agate.MVC.Base;
using SpacePlan.Module.Base;
using System.Collections.Generic;

namespace SpacePlan.Module.Leaderboard
{
    public interface ILeaderboardModel : IBaseModel
    {
        public List<ScorePlayer> ScorePlayerList { get; }
    }
}