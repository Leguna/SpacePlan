using System;
using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Interfaces;
using SpacePlan.Module.Spaceship.Interfaces.SpaceshipTypes;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Model
{
    public abstract class SpaceshipBaseModel : BaseModel, ISpaceshipModel
    {
        private Vector2 _position;
        public Vector2 MoveVelocity { get; protected set; }

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                SetDataAsDirty();
            }
        }

        public float Speed { get; set; }

        public virtual void Move(Vector2 moveVelocity)
        {
            MoveVelocity = moveVelocity;
            SetDataAsDirty();
        }

        #region NotImplementedYet

        public float Ammo { get; set; }
        public float AmmoMax { get; set; }
        public float FireRate { get; set; }
        public float FireRateMax { get; set; }
        public IDamage Damage { get; set; }

        public void Shoot()
        {
        }

        public float DamageValue { get; set; }

        public void Hit(float damage)
        {
        }

        public float CurrentHealth { get; set; }
        public float MaxHealth { get; set; }
        public Action OnDeath { get; set; }
        public Action<float> OnTakeDamage { get; set; }

        public void TakeDamage(IDamage damage)
        {
            throw new NotImplementedException();
        }

        public void Death()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}