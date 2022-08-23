using Agate.MVC.Base;
using SpacePlan.Module.Base;

namespace SpacePlan.Module.ScoreGameplay
{
    public interface IScoreGameplayModel : IBaseModel
    {
        public EntryHighscore ScorePlayer { get; }
    }
}