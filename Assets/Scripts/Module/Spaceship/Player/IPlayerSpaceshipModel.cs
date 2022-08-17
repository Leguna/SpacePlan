using SpacePlan.Module.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Player
{
    public interface IPlayerSpaceshipModel : ISpaceshipModel, IMovable, IShoot, IDamageable,IDoingDamage
    {
        Transform BulletSpawnTransform { get; }
        Limit LimitHorizontalMovement { get; }
        Vector2 MoveVelocity { get; }
        void SetVelocity(Vector2 velocity);
        void SetLimitHorizontalMovement(Limit limit);
        void CheckMoveBoundaries();

        void Init(GameObject bulletPrefab, float fireRate, float fireRateMax,
            float damage, float maxHealth);
    }
}