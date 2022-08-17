using Agate.MVC.Base;
using SpacePlan.Module.BulletPool;
using SpacePlan.Module.ClickGame;
using SpacePlan.Module.SoundFx;
using SpacePlan.Module.Spaceship.Ship.View;
using UnityEngine;

namespace SpacePlan.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField] public ClickGameView ClickGameView;
        [SerializeField] public SoundFxView SoundFxView;
        [SerializeField] public PlayerSpaceshipView PlayerSpaceshipView;
        [SerializeField] public BulletPoolView BulletPoolView;
    }
}