using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Interfaces.Damage;

namespace SpacePlan.Module.Spaceship.Interfaces.SpaceshipTypes
{
    public interface ISpaceshipModel : IBaseModel, IMovable, IShoot, IDamage, IDamageable
    {
    }
}