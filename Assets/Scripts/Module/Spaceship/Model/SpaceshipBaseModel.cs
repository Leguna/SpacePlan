using System;
using Agate.MVC.Base;
using SpacePlan.Module.Spaceship.Interfaces;
using SpacePlan.Module.Spaceship.Interfaces.SpaceshipTypes;
using UnityEngine;

namespace SpacePlan.Module.Spaceship.Model
{
    public abstract class SpaceshipBaseModel : BaseModel, ISpaceshipModel
    {
        public float Speed { get; set; }
        public Vector2 Direction { get; protected set; }

        public virtual void Move(Vector2 moveDirection)
        {
            Direction = moveDirection;
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