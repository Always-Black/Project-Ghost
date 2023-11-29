using UnityEngine;

namespace Entities.Enemies
{
    public class EnemyAI : Entity
    {
        // todo after adding environment make a try of a real AI
        private Transform _playerReference;
        
        
        private void Start()
        {
            _playerReference = Player.Player.Instance.transform;
        }

        protected void FixedUpdate()
        {
            if (_playerReference is null) return;
            
            Rigidbody.AddForce((_playerReference.position - transform.position).normalized * (100f * Speed));
        }
    }
}
