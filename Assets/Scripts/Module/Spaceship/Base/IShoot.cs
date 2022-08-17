using UnityEngine;

namespace SpacePlan.Module.Spaceship.Base
{
    public interface IShoot
    {
        GameObject BulletPrefab { get; }
        float FireRate { get; }

    }
}