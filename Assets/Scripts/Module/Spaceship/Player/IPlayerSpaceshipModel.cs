using SpacePlan.Module.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Player
{
    public interface IPlayerSpaceshipModel : ISpaceshipModel, IMovable, IShoot, IDamageable,IDoingDamage
    {
        Transform BulletSpawnTransform { get; }
        Limit LimitHorizontalMovement { get; }
        void SetLimitHorizontalMovement(Limit limit);
        void CheckMoveBoundaries();

    }
}