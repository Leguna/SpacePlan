namespace SpacePlan.Module.Spaceship.Ship.Interfaces
{
    public interface IDamageable
    {
        float CurrentHealth { get; }
        float MaxHealth { get; }
        bool IsDeath { get; }
        void TakeDamage(float damage);
    }
}