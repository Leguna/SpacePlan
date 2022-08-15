using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Interfaces.SpaceshipTypes;
using SpacePlan.Module.Spaceship.Model;
using UnityEngine;

namespace SpacePlan.Module.Spaceship
{
    public class PlayerSpaceshipView : ObjectView<IPlayerSpaceshipModel>
    {
        [SerializeField] public Rigidbody2D SpaceshipRigidbody;
        [SerializeField] public float Speed;
        [SerializeField] private Limit LimitHorizontalMovement;

        protected override void InitRenderModel(IPlayerSpaceshipModel model)
        {
            model.Speed = Speed;
            model.Position = transform.position;
            model.LimitHorizontalMovement = LimitHorizontalMovement;
        }

        protected override void UpdateRenderModel(IPlayerSpaceshipModel model)
        {
            SpaceshipRigidbody.velocity = model.MoveVelocity;
        }

        private void FixedUpdate()
        {
            if (_model != null)
            {
                _model.Position = transform.position;
                _model.CheckMoveBoundaries();
            }
        }
    }
}