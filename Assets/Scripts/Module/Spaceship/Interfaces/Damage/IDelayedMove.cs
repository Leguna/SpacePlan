using System.Collections;

namespace SpacePlan.Module.Spaceship.Interfaces
{
    interface IDelayedMove
    {
        float MoveDelay { get; set; }

        IEnumerator DelayMove(float delay);
    }

}