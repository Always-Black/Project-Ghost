using System.Collections.Generic;
using Extensions;
using Resources;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
    public abstract class Entity : MonoBehaviour
    {
        [Header("Attack"), Min(0)] public float Damage = 1;
        [Tooltip("Determined in seconds"), Min(0)] public float AttackSpeed = 1;
        [Tooltip("Knockback strength"), Min(0)] public float KnockbackForce = 25;
        
        [Header("Health"), Min(0)] public float Health = 1;
        [Min(0)] public float MaxHealth = 1;
        
        [Header("Movement"), Min(0)] public float Speed = 8.0f;
        
        [Header("Loot")] public DroppingParameters[] Droppables;
        
        public Rigidbody2D Rigidbody { get; private set; }
        
        public bool IsFullHealth => Health >= MaxHealth;
        public bool IsAlive => Health > 0.0f;
        
        private readonly List<Entity> _collidingEntities = new ();
        private float _attackCooldown;
        
        
        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            OnAwake();
        }
        
        private void Update()
        {
            HandleAttackCooldown();
            OnUpdate();
        }

        protected virtual void OnAwake() { }
        
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
            foreach (DroppingParameters parameter in Droppables)
            {
                parameter.Drop(transform.position);
            }
            
            Destroy(gameObject);
        }

        protected virtual void HandleAttacked(Entity attacker)
        {
            AdjustHealth(-attacker.Damage);
            
            Vector2 direction = attacker.transform.position - transform.position;
            direction.Normalize();
            
            attacker.Rigidbody.AddForce(direction * KnockbackForce, ForceMode2D.Impulse);
        }
        
        private void AttackEntity(Entity entity)
        {
            entity.HandleAttacked(this);
        }

        private void AttackAllEntities()
        {
            for (int i = _collidingEntities.Count - 1; i >= 0; i--)
            {
                AttackEntity(_collidingEntities[i]);
            }
        }

        public virtual void OnDropCollected(Droppable droppable) { }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.IsEntity(out Entity entity) && !_collidingEntities.Contains(entity))
            {
                _collidingEntities.Add(entity);
                if(_collidingEntities.Count == 1) AttackEntity(entity);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.IsEntity(out Entity entity) && _collidingEntities.Contains(entity))
            {
                _collidingEntities.Remove(entity);
            }
        }
    }
}