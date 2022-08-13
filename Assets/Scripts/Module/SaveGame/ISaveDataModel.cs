using Agate.MVC.Base;

namespace SpacePlan.Module.SaveGame
{
    public interface ISaveDataModel : IBaseModel
    {
        // TODO @Icankkk: Delete coin after implement score player
        private int Coin { get; }

        public struct HighScorePlayer
        {
            public int HighScore { get; } 
            public string PlayerName { get; }
        }
    }
}