using UnityEngine;

namespace SpacePlan.Module.Spaceship.Base
{
    public interface IMovable
    {
        Vector2 Position { get; }
        void SetPos(Vector2 pos);
        float Speed { get; }
        void SetSpeed(float speed);
        void Move(Vector2 moveVelocity);
    }
}