using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerLightObject : MonoBehaviour
{
    public GameObject light;
    
    [SerializeField] private float nexttime;
    [SerializeField] private float spawnDeley;

    [SerializeField] private float max;
    
    public GameObject player;

    [SerializeField] private float radius;
     
    void Update()
    {
        
        spawn();
    }

    private void Awake()
    {
        Vector2 offset = (Random.insideUnitCircle * radius) + (Vector2)player.transform.position;
        Instantiate(light, offset, Quaternion.identity);
        player = GameObject.FindGameObjectWithTag("Player");
        
    }


    void spawn()
    {
        if (Time.time > nexttime + spawnDeley) 
        {
            nexttime = Time.time + spawnDeley;
            Vector2 offset = (Random.insideUnitCircle * radius) + (Vector2)player.transform.position;
            Instantiate(light,  offset, Quaternion.identity);
        }

    } 
} 

