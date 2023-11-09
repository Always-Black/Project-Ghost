using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamagable
{
    [field: SerializeField] public float Health { get; set; }
    [field: SerializeField] public float MaxHealth { get; set; }

    private float speed = 14.0f;

    [SerializeField]
    private Animator anim;

    [SerializeField] 
    private Slider healthSlider;

    [SerializeField]
    private Joystik_Control joystick;

    private float angleOffset = 90f;

    void Awake()
    {
        healthSlider.value = Health;
    }

    void Update()
    {
        if (joystick.speed > 0.0f)
        {
            Vector2 direction = joystick.direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.Translate(direction * speed * joystick.speed * Time.deltaTime, Space.World);
        }
    }
    public void ReceiveDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0.0f)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene);
            Health += 60;
        }
        healthSlider.value = Health;
    }

    public void ReceiveHeal(float heal)
    {
        Health += heal;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }

        healthSlider.value = Health;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "LightObject")
        {
            if(Health < MaxHealth)
            {
                LightObject obj = other.collider.GetComponent<LightObject>();

                float healAmount = obj.HealPerSec * Time.deltaTime;
                ReceiveHeal(healAmount);
                obj.ChangeHealAmount(healAmount);
            }
        }
    }
}
