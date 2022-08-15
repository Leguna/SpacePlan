using System;
using SpacePlan.Module.Spaceship.Interfaces.SpaceshipTypes;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Model
{
    [Serializable]
    public struct Limit
    {
        public float Min;
        public float Max;
    }

    public sealed class PlayerSpaceshipModel : SpaceshipBaseModel, IPlayerSpaceshipModel
    {
        public Limit LimitHorizontalMovement { get; set; }

        public void MoveLeft(Vector2 moveLeftVelocity)
        {
            if (!CanMoveLeft && moveLeftVelocity.x >= 0) return;
            MoveVelocity = moveLeftVelocity;
        }

        public void MoveRight(Vector2 moveRightVelocity)
        {
            if (!CanMoveRight && moveRightVelocity.x <= 0) return;
            MoveVelocity = moveRightVelocity;
        }

        private bool CanMoveLeft => Position.x > LimitHorizontalMovement.Min;
        private bool CanMoveRight => Position.x < LimitHorizontalMovement.Max;


        public override void Move(Vector2 moveVelocity)
        {
            var newVelocityDir = new Vector2(moveVelocity.x, 0) * Speed;

            MoveLeft(newVelocityDir);
            MoveRight(newVelocityDir);

            SetDataAsDirty();
        }

        public void CheckMoveBoundaries()
        {
            if ((!CanMoveLeft && MoveVelocity.x < 0) || (!CanMoveRight && MoveVelocity.x > 0)) StopMove();
        }

        private void StopMove()
        {
            MoveVelocity = Vector2.zero;
            SetDataAsDirty();
        }
    }
}