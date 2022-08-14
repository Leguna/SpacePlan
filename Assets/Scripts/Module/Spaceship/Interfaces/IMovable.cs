using UnityEngine;

namespace SpacePlan.Module.Spaceship.Interfaces
{
    public interface IMovable
    {
        float Speed { get; set; }
        Vector2 Direction { get; }
        void Move(Vector2 moveDirection);
    }
}