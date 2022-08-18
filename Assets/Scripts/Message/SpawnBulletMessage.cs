using UnityEngine;

namespace SpacePlan.Message
{
    public struct SpawnBulletMessage
    {
        public Transform SpawnTransform { get; }
        public float Health { get; }
        public float Damage { get; }

        public SpawnBulletMessage(Transform spawnTransform, float damage, float health)
        {
            SpawnTransform = spawnTransform;
            Damage = damage;
            Health = health;
        }
    }
}