using SpacePlan.Module.Spaceship.Model;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Interfaces.SpaceshipTypes
{
    public interface IPlayerSpaceshipModel : ISpaceshipModel
    {
        Limit LimitHorizontalMovement { get; set; }
        void MoveLeft(Vector2 moveLeftVelocity);
        void MoveRight(Vector2 moveRightVelocity);
        void CheckMoveBoundaries();
    }
}