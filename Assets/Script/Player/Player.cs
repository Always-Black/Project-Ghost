using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 14.0f;
    private Animator aim;

    private float angleOffset = 90f;

    private void Start()
    {
        aim = GetComponent<Animator>();
    }

    [SerializeField]
    Joystik_Control joystick;

    void FixedUpdate()
    {
        if (joystick.speed > 0.0f)
        {
            Vector2 direction = joystick.direction;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.Translate(direction * speed * joystick.speed * Time.deltaTime, Space.World);
            
        }
    }
    
}
