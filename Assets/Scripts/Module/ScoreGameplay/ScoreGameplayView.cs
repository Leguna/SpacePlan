using Agate.MVC.Base;
using TMPro;
using UnityEngine;

namespace SpacePlan.Module.ScoreGameplay
{
    public class ScoreGameplayView : ObjectView<IScoreGameplayModel>
    {
        [SerializeField] public TMP_Text scoreText;
        [SerializeField] public TMP_Text playerText;

        protected override void InitRenderModel(IScoreGameplayModel model)
        {
            scoreText.text = $"{model.ScorePlayer.score}";
            playerText.text = $"{model.ScorePlayer.name}";
        }

        protected override void UpdateRenderModel(IScoreGameplayModel model)
        {
            scoreText.text = $"{model.ScorePlayer.score}";
            playerText.text = $"{model.ScorePlayer.name}";
        }
    }
}