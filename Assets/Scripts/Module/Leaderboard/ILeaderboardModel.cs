using Agate.MVC.Base;
using SpacePlan.Module.Base;
using System.Collections.Generic;
using UnityEngine;

namespace SpacePlan.Module.Leaderboard
{
    public interface ILeaderboardModel : IBaseModel
    {
        List<EntryHighscore> entryHighscores { get; }
        int limitLeaderboard { get; }
    }
}