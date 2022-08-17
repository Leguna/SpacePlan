using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Message
{
    public struct DoingDamageMessage
    {
        public IDoingDamage Damage { get; }
        public GameObject DamagedObject { get; }

        public DoingDamageMessage(IDoingDamage damage, GameObject damagedObject)
        {
            Damage = damage;
            DamagedObject = damagedObject;
        }
    }
}