using Agate.MVC.Base;
using SpacePlan.Module.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.PowerUp
{
    public interface IPowerUpModel : ISpaceshipModel
    {
        PowerUpType Type { get; }
        float Value { get; }
        float Duration { get; }
        bool IsDeath { get; }
        Vector2 Velocity { get; }
    }
}