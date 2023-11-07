using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = Unity.Mathematics.Random;
using Vector2 = System.Numerics.Vector2;

public class Enemy_spawn : MonoBehaviour
{
    private float max = 20;
    private float current = 0;
    public GameObject enemy;
     

    private void Start()
    {
        
    }

    void Update()
    {
            spawn();
            
    }

    void spawn()
    {
        if (current < max)
        {

            GameObject clone = Instantiate(enemy,  transform.position, Quaternion.identity);
            current++;
        }
    }
}
