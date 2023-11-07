using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Heal : MonoBehaviour
{
    [Header("Health: ")]  public static float health = 60;
    public GameObject Enemy;
    public GameObject LightObject;
    private bool here = false;
    
     
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        LightObject = GameObject.FindGameObjectWithTag("LightObject");
        


    }
    
    void FixedUpdate()
    {
        if (here == false)
        {
            health -= Time.deltaTime;
        }

        if (health < 0)
        {
            string currentScene = SceneManager.GetActiveScene ().name;
            SceneManager.LoadScene(currentScene);
            health = health + 60;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == LightObject.name && health < 60)
        {

            here = true;
            for (int i = 0; i < 60; i++)
            {
                if(health < 60)
                {
                    health = health += Time.deltaTime * 100;
                }
            }
        }   
        

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.name == LightObject.name)
        {
            here = here == false;
        }
    }
}
