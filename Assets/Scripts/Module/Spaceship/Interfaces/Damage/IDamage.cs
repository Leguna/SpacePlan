namespace SpacePlan.Module.Spaceship.Interfaces
{
    public interface IDamage
    {
        float DamageValue { get; set; }

        void Hit(float damage);
    }
}