using UnityEngine;

namespace SpacePlan.Module.Spaceship.Ship.Interfaces
{
    public interface IShoot
    {
        GameObject BulletPrefab { get; }
        float FireRate { get; }
        float FireRateMax { get; }
        float Damage { get; }

    }
}