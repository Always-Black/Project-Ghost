using System;
using UnityEngine;using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Joystik_Control : MonoBehaviour
{
    Image image;
    RectTransform rectTransform;
    
    Vector2 DefautPosition = Vector2.zero; 
    Vector2 positiion = Vector2.zero;

    [SerializeField] 
    Sprite activeSprite;

    [SerializeField] 
    Sprite idleSprite;
    
    [HideInInspector]
    public float speed = 0.0f;
    [HideInInspector]
    public Vector2 direction = Vector2.zero;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }
    
    void Update()
    {
        
    }

    public void OnPointerDown(BaseEventData data)
    {
        PointerEventData pntr = (PointerEventData) data;
        DefautPosition = pntr.position;
        image.sprite = activeSprite;

    }

    private float maxAllowedSize = 100.0f;
    public void OnDrag(BaseEventData data)
    {
        PointerEventData pntr = (PointerEventData)data;
        positiion = pntr.position - DefautPosition;
        float size = positiion.magnitude;
        if (size > maxAllowedSize)
        {
            speed = 1.5f;
            positiion = positiion / size * maxAllowedSize;
        }
        else
        {
            speed = size / maxAllowedSize;
            direction = positiion / size;
            rectTransform.localPosition = positiion;
        }


        direction = positiion / size;
        rectTransform.localPosition = positiion;
        
    }

    public void OnPointerUp(BaseEventData data)
    {
        speed = 0.0f;
        direction = Vector2.zero;
        rectTransform.localPosition = Vector2.zero;
        image.sprite = idleSprite;
    }
}
