using Entities;
using Extensions;
using Resources;
using UnityEngine;

namespace Environment
{
    public class Breakable : MonoBehaviour
    {
        public float Health = 25;
        public float KnockbackForce = 25;
        
        public DroppingParameters[] Droppables;
        
        public void Hit(Entity hitter)
        {
            Health -= hitter.Damage;
            
            Vector2 direction = hitter.transform.position - transform.position;
            direction.Normalize();
            
            hitter.Rigidbody.AddForce(direction * KnockbackForce, ForceMode2D.Impulse);
            
            if (Health <= 0.0f)
            {
                HandleDeath(hitter);
            }
        }

        private void HandleDeath(Entity killer)
        {
            foreach (DroppingParameters parameter in Droppables)
            {
                parameter.Drop(transform.position);
            }
            
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.IsEntity(out Entity entity))
            {
                Hit(entity);
            }
        }
    }
}