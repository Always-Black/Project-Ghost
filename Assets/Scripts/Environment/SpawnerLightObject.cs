using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnerLightObject : MonoBehaviour
{
    public GameObject light;
    
    [SerializeField] private float nexttime;
    [SerializeField] private float spawnDeley;
    
     private float positionX;
     private float positionY;
     
     
    void Update()
    {
        
        positionX = Random.Range(-100, 100);
        positionY = Random.Range(-100, 100);
        spawn();
        
    }

    private void Awake()
    {
        Vector2 offset = new Vector2(positionX, positionY);
        Instantiate(light, offset, Quaternion.identity);
    }


    void spawn()
    {
        if (Time.time > nexttime + spawnDeley) 
        {
            nexttime = Time.time + spawnDeley;
            Vector2 offset = new Vector2(positionX, positionY);
            Instantiate(light, offset, Quaternion.identity);
        }

    } 
} 

