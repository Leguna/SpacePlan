using System;
using System.Collections;

namespace SpacePlan.Module.Spaceship.Base
{
    public interface IDelayedMove
    {
        float MoveDelayTime { get; }
        bool IsMoving { get; }
        IEnumerator SetDelayedMove(float delay, Action repeatedMove);
    }
}