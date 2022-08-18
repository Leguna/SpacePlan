using System;
using System.Collections;
using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Enemy
{
    public class EnemySpaceshipModel : SpaceshipBaseModel, IEnemySpaceshipModel
    {
        public Vector2 Velocity { get; set; }

        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; }

        public EnemySpaceshipModel()
        {
            MaxHealth = 1;
            CurrentHealth = MaxHealth;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            SetDataAsDirty();
        }

        public GameObject BulletPrefab { get; }
        public float FireRate { get; }
        public float Damage { get; }
        public float MoveDelayTime { get; }
        public bool IsMoving { get; }

        public IEnumerator SetDelayedMove(float delay, Action repeatedMove)
        {
            yield return new WaitForSeconds(delay);
            repeatedMove();
        }

        public void StopMove()
        {
            MoveVelocity = Vector3.zero;
            SetDataAsDirty();
        }
    }
}