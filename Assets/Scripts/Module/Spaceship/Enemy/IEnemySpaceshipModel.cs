using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Enemy
{
    public interface IEnemySpaceshipModel : ISpaceshipModel, IDamageable, IShoot, IDelayedMove, IMovable, IDoingDamage
    {
        Vector2 Velocity { get; }
        MoveDirection CurrentMoveDirection { get; }
        public Vector2 SpawnPosition { get; }
    }
}