using SpacePlan.Module.Spaceship.Base;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Enemy
{
    public class EnemySpaceshipModel : SpaceshipBaseModel, IEnemySpaceshipModel
    {
        public MoveDirection CurrentMoveDirection { get; private set; }

        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; }

        public bool IsDeath => CurrentHealth <= 0;

        public Vector3 DeSpawnPosition { get; } = new Vector3(0, -13, 0);

        public EnemySpaceshipModel()
        {
            MaxHealth = 1;
            Speed = 0.3f;
            CurrentHealth = MaxHealth;
        }

        public EnemySpaceshipModel(float damage) : this()
        {
            Damage = damage;
        }

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            SetDataAsDirty();
        }

        public void DeSpawn()
        {
            CurrentHealth = 0;
            SetPos(DeSpawnPosition);
            SetDataAsDirty();
        }

        public GameObject BulletPrefab { get; }
        public float FireRate { get; }
        public IDoingDamage DoingDamage { get; }
        public float Damage { get; }
        public float MoveDelayTime => 2;
        public float CurrentTime { get; private set; }
        public bool IsMoving { get; }
        public int ScoreValue => 10;

        public void DelayedMove()
        {
            CurrentTime += Time.deltaTime;
            if (CurrentTime >= MoveDelayTime)
            {
                CurrentTime = 0;
                NextMove();
            }
        }

        public void NextMove()
        {
            switch (CurrentMoveDirection)
            {
                case MoveDirection.None:
                    Move(MoveDirection.Right, Vector3.right * Speed);
                    break;
                case MoveDirection.Up:
                    Move(MoveDirection.Right, Vector3.right * Speed);
                    break;
                case MoveDirection.Right:
                    Move(MoveDirection.Down, Vector3.down * Speed);
                    break;
                case MoveDirection.Down:
                    Move(MoveDirection.Left, Vector3.left * Speed);
                    break;
                case MoveDirection.Left:
                    Move(MoveDirection.Up, Vector3.up * Speed);
                    break;
                default:
                    Move(MoveDirection.None, Vector3.zero);
                    break;
            }
        }

        public void Move(MoveDirection moveDirection, Vector3 velocity)
        {
            Velocity = velocity;
            CurrentMoveDirection = moveDirection;
            SetDataAsDirty();
        }

        public void StopMove()
        {
            Move(MoveDirection.None, Vector3.zero);
        }
    }
}