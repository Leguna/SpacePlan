using Agate.MVC.Base;
using SpacePlan.Module.BulletPool;
using SpacePlan.Module.ClickGame;
using SpacePlan.Module.EnemyPool;
using SpacePlan.Module.PowerUpPool;
using SpacePlan.Module.SoundFx;
using SpacePlan.Module.Spaceship.Player;
using SpacePlan.Module.Spaceship.PowerUp;
using UnityEngine;

namespace SpacePlan.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        [SerializeField] public ClickGameView ClickGameView;
        [SerializeField] public SoundFxView SoundFxView;
        [SerializeField] public PlayerSpaceshipView PlayerSpaceshipView;
        [SerializeField] public BulletPoolView BulletPoolView;
        [SerializeField] public EnemyPoolView EnemyPoolView;
        [SerializeField] public PowerUpPoolView PowerUpPoolView;
    }
}