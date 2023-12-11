using UnityEngine;
using Random = UnityEngine.Random;

public class HardSystem : MonoBehaviour
{ 
    
    [SerializeField] private float currently;
    [SerializeField] private float SpawnTime;
    [SerializeField] private float DoubleSpawn;
    
     public GameObject enemis;
     public GameObject player;

     [SerializeField] private float radius;
     
    
    void Start()
    {
        InvokeRepeating("ReloadTime", 5, 15);
        InvokeRepeating("ReloadDouble", DoubleSpawn, 15);
        InvokeRepeating("Amout", 0, 15);
        InvokeRepeating("Double", 30, 3);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    
    private void FixedUpdate()
    {
        Spawn();
    }
    void Spawn()
    {
        if (Time.time > currently + SpawnTime)
        {
            currently = Time.time + SpawnTime;
            Vector2 offset = (Random.insideUnitCircle * radius) + (Vector2)player.transform.position;
            Instantiate(enemis,  offset, Quaternion.identity);
        }
    }

    private void Double()
    {
        int random = Random.Range(0, 4);
        Vector2 offset = (Random.insideUnitCircle * radius) + (Vector2)player.transform.position;
        for (int i = 0; i < random; i++)
        {
            Instantiate(enemis, offset, Quaternion.identity);
        }
    }

    private void ReloadTime()
    {
        SpawnTime -= 0.1f;
        if (SpawnTime > 0.2)
        {
            CancelInvoke("ReloadTime");
        }
    }
    private void ReloadDouble()
    {
        DoubleSpawn -= 0.3f;
        if (DoubleSpawn < 0.6f)
        {
            CancelInvoke("ReloadDouble");
        }
    }
    
}
