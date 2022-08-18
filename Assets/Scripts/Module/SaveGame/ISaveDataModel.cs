using Agate.MVC.Base;

namespace SpacePlan.Module.SaveGame
{
    public interface ISaveDataModel : IBaseModel
    {
        // TODO @Faisal: Delete coin after implement score player
        public int Coin { get; }

        public struct HighScorePlayer
        {
            public int HighScore { get; } 
            public string PlayerName { get; }
        }
    }
}