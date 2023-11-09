using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
public class hellbar : MonoBehaviour
{
    public Image image;
    void Start()
    {
        
    }
    void Update()
    {
        image.fillAmount -= Time.deltaTime;
    }
}
