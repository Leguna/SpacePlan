using System;
using System.Collections;

namespace SpacePlan.Module.Spaceship.Base
{
    interface IDelayedMove
    {
        float MoveDelay { get; }
        bool IsMoving { get; }
        IEnumerator SetDelayedMove(float delay, Action repeatedMove);
        void RepeatedMove();
        void StartMove();
        void StopMove();
    }
}