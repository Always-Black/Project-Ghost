using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = Unity.Mathematics.Random;
using Vector2 = System.Numerics.Vector2;

public class Enemy_AI : MonoBehaviour
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
    void FixedUpdate()
    {
        float Exstra_speed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, player.position, Exstra_speed);
        Debug.Log(Heal.health);
        
        
    }
    
        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.name == player.name)
            {
                health_player = Heal.health - 10;
                
            }
        } 
    
}
