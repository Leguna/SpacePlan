using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Enemy
{
    public interface IEnemySpaceshipModel : ISpaceshipModel, IDamageable, IShoot, IDelayedMove, IMovable
    {
        Vector2 Velocity { get; }
        MoveDirection CurrentMoveDirection { get; }
    }
}