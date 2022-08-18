using SpacePlan.Module.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.PowerUp
{
    public class PowerUpModel : SpaceshipBaseModel, IPowerUpModel, IDamageable
    {
        public PowerUpModel(float duration, float value, PowerUpType type, float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            Duration = duration;
            Value = value;
            Type = type;
            SetDataAsDirty();
        }

        public PowerUpModel()
        {
            MaxHealth = 1;
            CurrentHealth = MaxHealth;
            Duration = 5000;
            Value = 2;
            Speed = 1;
            Velocity = Vector2.down * Speed;
            Type = PowerUpType.PlayerBulletHealth;
            SetDataAsDirty();
        }

        public bool IsDeath => CurrentHealth <= 0;

        public PowerUpType Type { get; private set; }
        public float Value { get; private set; }
        public float Duration { get; private set; }

        public void DeSpawn()
        {
            CurrentHealth = 0;
            Velocity = Vector2.zero;
            SetDataAsDirty();
        }

        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; }
        public Limit LimitY { get; } = new() { Min = -7 };

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            SetDataAsDirty();
        }
    }
}