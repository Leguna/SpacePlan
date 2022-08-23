using UnityEngine;

namespace SpacePlan.Message
{
    public struct SpawnBulletMessage
    {
        public Vector3 Direction;
        public Vector3 SpawnPosition { get; }
        public float Health { get; }
        public float Damage { get; }

        public SpawnBulletMessage(Vector3 spawnPosition, float damage, float health, Vector3 direction)
        {
            SpawnPosition = spawnPosition;
            Damage = damage;
            Health = health;
            Direction = direction;
        }
    }
}