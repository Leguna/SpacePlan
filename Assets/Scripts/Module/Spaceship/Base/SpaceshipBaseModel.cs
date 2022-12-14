using Agate.MVC.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Base
{
    public abstract class SpaceshipBaseModel : BaseModel, ISpaceshipModel
    {
        public Vector2 Velocity { get; protected set; }

        public Vector2 Position { get; private set; }
        public float Speed { get; internal set; } = 1;

        public void SetSpeed(float speed)
        {
            Speed = speed;
            SetDataAsDirty();
        }

        public void SetPos(Vector2 pos)
        {
            Position = pos;
            SetDataAsDirty();
        }

        public virtual void Move(Vector2 moveVelocity)
        {
            SetVelocity(moveVelocity);
        }

        private void SetVelocity(Vector2 moveVelocity)
        {
            Velocity = moveVelocity;
            SetDataAsDirty();
        }


    }
}