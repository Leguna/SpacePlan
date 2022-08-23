using System;

namespace SpacePlan.Module.Spaceship.Base
{
    public interface IDelayedMove
    {
        float MoveDelayTime { get; }
        float CurrentTime { get; }
        bool IsMoving { get; }
        void DelayedMove();
    }
}