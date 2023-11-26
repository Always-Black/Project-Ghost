using UnityEngine;

namespace Entities.Enemies
{
    public class EnemyAI : Entity
    {
        // todo after adding environment make a try of a real AI
        private Transform _playerReference;
        [SerializeField] private float Speed = 5;


        private void Start()
        {
            _playerReference = Player.Player.Instance.transform;
        }

        protected override void OnUpdate()
        {
            float extraSpeed = Speed * Time.deltaTime;
                        transform.position = Vector3.MoveTowards(transform.position, 
                            _playerReference.position, extraSpeed);
        }
    }
}
