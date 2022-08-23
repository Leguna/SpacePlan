using SpacePlan.Module.Base;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Player
{
    public class PlayerSpaceshipModel : SpaceshipBaseModel, IPlayerSpaceshipModel
    {
        public PlayerSpaceshipModel()
        {
            FireRate = 1;
            DamageValue = 1;
            MaxHealth = 1;
            SetDataAsDirty();
        }

        public void Init(GameObject bulletPrefab, float fireRate, float fireRateMax, float maxHealth,
            IDoingDamage doingDamage)
        {
            FireRate = fireRate;
            DoingDamage = doingDamage;
            MaxHealth = maxHealth;
            SetDataAsDirty();
        }

        public Transform BulletSpawnTransform { get; private set; }

        public void SetBulletTransform(Transform bulletTransform)
        {
            BulletSpawnTransform = bulletTransform;
            SetDataAsDirty();
        }

        public Limit LimitHorizontalMovement { get; private set; }
        public Vector2 MoveVelocity { get; }

        public void SetVelocity(Vector2 velocity)
        {
        }

        public void SetLimitHorizontalMovement(Limit limit)
        {
            LimitHorizontalMovement = limit;
        }

        private void MoveLeft(Vector2 moveLeftVelocity)
        {
            if (!CanMoveLeft && moveLeftVelocity.x >= 0) return;
            Velocity = moveLeftVelocity;
        }

        private void MoveRight(Vector2 moveRightVelocity)
        {
            if (!CanMoveRight && moveRightVelocity.x <= 0) return;
            Velocity = moveRightVelocity;
        }

        private bool CanMoveLeft => Position.x > LimitHorizontalMovement.Min;
        private bool CanMoveRight => Position.x < LimitHorizontalMovement.Max;


        public override void Move(Vector2 moveVelocity)
        {
            var newVelocityDir = new Vector2(moveVelocity.x, 0) * Speed;

            MoveLeft(newVelocityDir);
            MoveRight(newVelocityDir);

            SetDataAsDirty();
        }

        public void CheckMoveBoundaries()
        {
            if ((!CanMoveLeft && Velocity.x < 0) || (!CanMoveRight && Velocity.x > 0)) StopMove();
        }

        private void StopMove()
        {
            Velocity = Vector2.zero;
            SetDataAsDirty();
        }

        public float FireRate { get; private set; }
        public IDoingDamage DoingDamage { get; private set; }
        public float DamageValue { get; private set; }
        public float BulletHealth { get; private set; } = 1;

        public void SetBulletHealth(float health)
        {
            BulletHealth = health;
            SetDataAsDirty();
        }

        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }
        public bool IsDeath => CurrentHealth <= 0;

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            SetDataAsDirty();
        }
    }
}