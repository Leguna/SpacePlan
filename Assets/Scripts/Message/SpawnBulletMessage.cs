using UnityEngine;

namespace SpacePlan.Message
{
    public struct SpawnBulletMessage
    {
        public Transform SpawnTransform { get; }

        public SpawnBulletMessage(Transform spawnTransform)
        {
            SpawnTransform = spawnTransform;
        }
    }
}