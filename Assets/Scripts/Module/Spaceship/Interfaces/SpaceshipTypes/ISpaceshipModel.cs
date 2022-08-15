using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Interfaces.Damage;
using SpacePlan.Module.Spaceship.Model;

namespace SpacePlan.Module.Spaceship.Interfaces.SpaceshipTypes
{
    public interface ISpaceshipModel : IBaseModel, IMovable, IShoot, IDamage, IDamageable
    {
    }
}