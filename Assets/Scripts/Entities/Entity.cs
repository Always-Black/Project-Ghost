using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public abstract class Entity : MonoBehaviour
    {
        [Header("Attack")] public float Damage = 1;
        public float AttackSpeed = 1;
        
        [Header("Health")] public float Health = 1;
        public float MaxHealth = 1;
        public bool IsFullHealth => Health >= MaxHealth;
        
        private readonly List<Entity> _collidingEntities = new ();
        private float _attackCooldown;
        
        
        private void Update()
        {
            HandleAttackCooldown();
            OnUpdate();
        }

        protected virtual void OnUpdate() { }

        private void HandleAttackCooldown()
        {
            if(_collidingEntities.Count < 1) 
            {
                _attackCooldown = 0.0f;
                return;
            }

            _attackCooldown += Time.deltaTime;
            
            if (_attackCooldown >= AttackSpeed)
            {
                AttackAllEntities();

                _attackCooldown = 0.0f;
            }
        }

        public bool IsAlive => Health > 0.0f;
        
        public virtual void SetHealth(float health)
        {
            Health = health;
            ValidateHealth();
        }
        
        public virtual void AdjustHealth(float health)
        {
            SetHealth(Health + health);
        }
        
        private bool ValidateHealth()
        {
            if (Health <= 0.0f)
            {
                HandleDeath();
                return false;
            }

            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            return true;
        }
        
        protected virtual void HandleDeath()
        {
            Destroy(gameObject);
        }
        
        private void AttackEntity(Entity entity)
        {
            entity.AdjustHealth(-Damage);
        }

        private void AttackAllEntities()
        {
            for (int i = _collidingEntities.Count - 1; i >= 0; i--)
            {
                AttackEntity(_collidingEntities[i]);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Entity entity) && !_collidingEntities.Contains(entity))
            {
                _collidingEntities.Add(entity);
                if(_collidingEntities.Count == 1) AttackEntity(entity);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Entity entity) && _collidingEntities.Contains(entity))
            {
                _collidingEntities.Remove(entity);
            }
        }
    }
}