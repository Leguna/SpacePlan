using UnityEngine;

namespace SpacePlan.Module.Spaceship.Model
{
    public sealed class PlayerSpaceshipModel : SpaceshipBaseModel
    {
        public override void Move(Vector2 moveDirection)
        {
            Direction = new Vector2(moveDirection.x, 0) * Speed;
            SetDataAsDirty();
        }
    }
}