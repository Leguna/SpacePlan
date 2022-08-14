using System;

namespace SpacePlan.Module.Spaceship.Interfaces.Damage
{
    public interface IDamageable
    {
        float CurrentHealth { get; set; }
        float MaxHealth { get; set; }

        Action OnDeath { get; set; }
        Action<float> OnTakeDamage { get; set; }

        void TakeDamage(IDamage damage);
        void Death();
    }
}