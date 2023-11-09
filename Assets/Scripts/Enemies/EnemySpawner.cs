using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float max = 20;
    private float current = 0;
    public GameObject[] enemies;


    private void Awake()
    {
        spawn();
    }

    void spawn()
    {
        for (int i = 0; i < max; i++)
        {
            Instantiate(enemies[0], transform.position, Quaternion.identity);
        }

        current = max;
    }
}
