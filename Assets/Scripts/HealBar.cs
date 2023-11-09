using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
    
    public Slider slider;
    private float number = Heal.health;


    private void Start()
    {
        
    }

    void FixedUpdate()
    {
        slider.value = Heal.health;

    }

   
    
}
