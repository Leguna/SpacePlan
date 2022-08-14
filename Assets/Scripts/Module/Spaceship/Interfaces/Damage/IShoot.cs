using SpacePlan.Module.Spaceship.Interfaces.Damage;

namespace SpacePlan.Module.Spaceship.Interfaces
{
    public interface IShoot
    {
        float Ammo { get; set; }
        float AmmoMax { get; set; }
        float FireRate { get; set; }
        float FireRateMax { get; set; }
        IDamage Damage { get; set; }

        void Shoot();
    }
}