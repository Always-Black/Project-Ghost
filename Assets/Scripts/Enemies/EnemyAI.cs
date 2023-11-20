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
    [SerializeField] private float health = 20; 
    public GameObject delusion;
    public GameObject light;
    public GameObject money;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        health_player = Heal.health;
       
    }
    void Update()
    {
        float Exstra_speed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, Exstra_speed);

        if (health < 1)
        {
            Instantiate(delusion, transform.position * 2, Quaternion.identity);
            Instantiate(money, transform.position * 1, Quaternion.identity);
            Instantiate(light, transform.position * 3, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player") 
             health =- 20;
    } 
}
