using UnityEngine;

namespace SpacePlan.Message
{
    public struct InputMessage
    {
        public Vector2 Direction { get; }

        public InputMessage(Vector2 dir)
        {
            Direction = dir;
        }
    }
}