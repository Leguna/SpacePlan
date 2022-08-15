using UnityEngine;

namespace SpacePlan.Message
{
    public struct MovePlayerShipMessage
    {
        public Vector2 Direction { get; }

        public MovePlayerShipMessage(Vector2 dir)
        {
            Direction = dir;
        }
    }
}