namespace SpacePlan.Module.Spaceship.Base
{
    public interface IDamageable
    {
        float CurrentHealth { get; }
        float MaxHealth { get; }
        bool IsDeath { get; }
        void TakeDamage(float damage);
    }
}