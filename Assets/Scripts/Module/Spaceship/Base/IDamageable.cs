namespace SpacePlan.Module.Spaceship.Base
{
    public interface IDamageable
    {
        float CurrentHealth { get; }
        float MaxHealth { get; }
        bool IsDeath => CurrentHealth <= 0;
        void TakeDamage(float damage);
    }
}