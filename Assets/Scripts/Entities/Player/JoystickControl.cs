using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Entities.Player
{
    public class JoystickControl : MonoBehaviour
    {
        // TODO: Make major refactor of this class
        
        Image image;
        RectTransform rectTransform;
    
        Vector2 DefautPosition = Vector2.zero; 
        Vector2 pos = Vector2.zero;

        [SerializeField] 
        Sprite activeSprite;

        [SerializeField] 
        Sprite idleSprite;
    
        [HideInInspector]
        public float speed;
        [HideInInspector]
        public Vector2 direction = Vector2.zero;

        void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            image = GetComponent<Image>();
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
            pos = pntr.position - DefautPosition;
            float size = pos.magnitude;
            if (size > maxAllowedSize)
            {
                speed = 1.5f;
                pos = pos / size * maxAllowedSize;
            }
            else
            {
                speed = size / maxAllowedSize;
                direction = pos / size;
                rectTransform.anchoredPosition = pos;
            }


            direction = pos / size;
            rectTransform.anchoredPosition = pos;
        }

        public void OnPointerUp(BaseEventData data)
        {
            speed = 0.0f;
            direction = Vector2.zero;
            rectTransform.anchoredPosition = Vector2.zero;
            image.sprite = idleSprite;
        }
    }
}
