using System.Collections;
using Agate.MVC.Base;
using SpacePlan.Message;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpacePlan.Module.InputSystem
{
    public class SpaceshipInputController : BaseController<SpaceshipInputController>
    {
        private SpaceshipInputManager _inputManager = new();

        public override IEnumerator Initialize()
        {
            yield return base.Initialize();
            _inputManager.Movement.Enable();
            _inputManager.Movement.Move.performed += OnMoveInput;
        }

        private void OnMoveInput(InputAction.CallbackContext ctx)
        {
            Publish(new InputMessage(ctx.ReadValue<Vector2>()));
        }

        public override IEnumerator Terminate()
        {
            _inputManager.Movement.Disable();
            yield return base.Terminate();
        }
    }
}