using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Interfaces.SpaceshipTypes;
using SpacePlan.Module.Spaceship.Model;
using UnityEngine;

namespace SpacePlan.Module.Spaceship
{
    class SpaceshipController : ObjectController<SpaceshipController, PlayerSpaceshipModel, IPlayerSpaceshipModel,
        PlayerSpaceshipView>
    {
        public void OnMoveInput(Vector2 messageDirection)
        {
            _model.Move(messageDirection);
        }

    }
}