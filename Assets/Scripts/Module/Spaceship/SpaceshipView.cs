using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Interfaces.SpaceshipTypes;
using UnityEngine;

namespace SpacePlan.Module.Spaceship
{
    public class SpaceshipView : ObjectView<ISpaceshipModel>
    {
        [SerializeField] public Rigidbody2D SpaceshipRigidbody;
        [SerializeField] public float Speed;

        protected override void InitRenderModel(ISpaceshipModel model)
        {
            model.Speed = Speed;
        }

        protected override void UpdateRenderModel(ISpaceshipModel model)
        {
            SpaceshipRigidbody.velocity = model.Direction;
        }
    }
}