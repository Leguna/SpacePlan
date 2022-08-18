using Agate.MVC.Base;
using SpacePlan.Module.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SpacePlan.Module.Leaderboard
{
    public class LeaderboardModel : BaseModel, ILeaderboardModel
    {

        public int limitLeaderboard => 10;

        public List<EntryHighscore> entryHighscores{
            get;
            private set;
        } = new List<EntryHighscore>();

        public void AddHighscoreEntry(EntryHighscore candidateHighscore)
        {
            entryHighscores.Add(candidateHighscore);
            entryHighscores.Sort((x,y)=> x.score.CompareTo(y.score));
            SetDataAsDirty();
        }

    
        public void SetListScorePlayer(List<EntryHighscore> highscoreEntryList)
        {
            entryHighscores = highscoreEntryList;
            entryHighscores.Sort((y, x) => x.score.CompareTo(y.score));
            SetDataAsDirty();
        }

    }
}
