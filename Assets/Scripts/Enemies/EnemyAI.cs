using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    public Transform[] move;
    private int random_move;
    private float speed = 5;
    public float health_player;
    private Vector2 position2D = new Vector2(0,0);
    private float distance = 0;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health_player = Heal.health;
       
    }
    void Update()
    {
        float Exstra_speed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, Exstra_speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player") 
            health_player = Heal.health - 10;
    } 
}
