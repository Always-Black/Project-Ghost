using UnityEngine;

namespace Entities.Enemies
{
    public class EnemyAI : Entity
    {
        private Transform _playerReference;
        [SerializeField] private float Speed = 5;


        private void Start()
        {
            _playerReference = Player.Player.Instance.transform;
        }

        protected override void OnUpdate()
        {
            // todo make a try of a real AI
            float extraSpeed = Speed * Time.deltaTime;
                        transform.position = Vector3.MoveTowards(transform.position, 
                            _playerReference.position, extraSpeed);
        }
    }
}
