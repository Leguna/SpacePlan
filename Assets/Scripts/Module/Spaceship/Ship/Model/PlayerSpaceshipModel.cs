using SpacePlan.Module.Base;
using SpacePlan.Module.Spaceship.Ship.Interfaces.SpaceshipTypes;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Ship.Model
{
    public class PlayerSpaceshipModel : SpaceshipBaseModel, IPlayerSpaceshipModel
    {
        public PlayerSpaceshipModel()
        {
            BulletPrefab = null;
            FireRate = 1;
            FireRateMax = 1;
            Damage = 1;
            MaxHealth = 1;
            SetDataAsDirty();
        }

        public void Init(GameObject bulletPrefab, float fireRate, float fireRateMax,
            float damage, float maxHealth)
        {
            BulletPrefab = bulletPrefab;
            FireRate = fireRate;
            FireRateMax = fireRateMax;
            Damage = damage;
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
            MoveVelocity = moveLeftVelocity;
        }

        private void MoveRight(Vector2 moveRightVelocity)
        {
            if (!CanMoveRight && moveRightVelocity.x <= 0) return;
            MoveVelocity = moveRightVelocity;
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
            if ((!CanMoveLeft && MoveVelocity.x < 0) || (!CanMoveRight && MoveVelocity.x > 0)) StopMove();
        }

        private void StopMove()
        {
            MoveVelocity = Vector2.zero;
            SetDataAsDirty();
        }

        public GameObject BulletPrefab { get; private set; }
        public float FireRate { get; private set; }
        public float FireRateMax { get; private set; }
        public float Damage { get; private set; }


        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }
        public bool IsDeath => CurrentHealth <= 0;

        public void TakeDamage(float damage)
        {
            Debug.Log($"Player took {damage} damage");
            CurrentHealth -= damage;
            SetDataAsDirty();
        }
    }
}