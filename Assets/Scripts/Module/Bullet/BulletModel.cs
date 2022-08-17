using Agate.MVC.Base;
using SpacePlan.Module.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Bullet
{
    public class BulletModel : BaseModel, IMovable, IDamageable, IBulletModel, IDoingDamage
    {
        public float Damage { private set; get; }
        public Vector2 Velocity { get; private set; }
        public Vector2 Position { get; private set; }
        private Limit DeSpawnLimitY { get; }
        public float Speed { get; private set; }

        public bool IsLimitReached => Position.y >= DeSpawnLimitY.Max || Position.y <= DeSpawnLimitY.Min;

        public BulletModel()
        {
            Velocity = Vector2.up;
            Speed = 4;
            MaxHealth = 1;
            CurrentHealth = MaxHealth;
            Position = Vector2.zero;
            Damage = 1;
            DeSpawnLimitY = new Limit { Min = -7, Max = 7 };
        }

        public BulletModel(Vector2 position, float speed, float damageValue, float maxHealth, Vector3 deSpawnPosition)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
            DeSpawnPosition = deSpawnPosition;
            SetPos(position);
            SetSpeed(speed);
            SetDamageValue(damageValue);
        }

        private void SetDamageValue(float damageValue)
        {
            Damage = damageValue;
            SetDataAsDirty();
        }

        public void Move(Vector2 moveVelocity)
        {
            Velocity = moveVelocity;
            SetDataAsDirty();
        }

        public void SetSpeed(float speed)
        {
            Speed = speed;
            SetDataAsDirty();
        }

        public void SetPos(Vector2 pos)
        {
            Position = pos;
            SetDataAsDirty();
        }

        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; }
        public bool IsDeath => CurrentHealth <= 0;
        public Vector3 DeSpawnPosition { get; } = new(-20, 0, 0);

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            SetDataAsDirty();
        }

        public void DeSpawn()
        {
            CurrentHealth = 0;
            Position = DeSpawnPosition;
            Velocity = Vector2.zero;
            SetDataAsDirty();
        }
    }
}