using UnityEngine;

namespace Entities.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        // TODO: Make major refactor of this class
        
        [SerializeField]
        private float max = 20;
        private float current = 0;
        public GameObject[] enemies;


        private void Awake()
        {
            Spawn();
        }

        private void Spawn()
        {
            for (int i = 0; i < max; i++)
            {
                Instantiate(enemies[0], transform.position, Quaternion.identity);
            }

            current = max;
        }
    }
}
