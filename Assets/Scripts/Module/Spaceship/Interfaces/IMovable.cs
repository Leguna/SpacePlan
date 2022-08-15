using UnityEngine;

namespace SpacePlan.Module.Spaceship.Interfaces
{
    public interface IMovable
    {
        Vector2 Position { get; set; }
        float Speed { get; set; }
        Vector2 MoveVelocity { get; }
        void Move(Vector2 moveVelocity);

    }
}