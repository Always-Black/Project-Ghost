using UnityEngine;
using UnityEngine.EventSystems;

namespace Entities.Player
{
    public class JoystickControl : MonoBehaviour
    {
        [SerializeField] private RectTransform JoystickHandle;
        [SerializeField] private RectTransform JoystickBackground;
        
        public float Speed { get; private set; }
        public Vector2 Direction { get; private set; } = Vector2.zero;
        public bool IsTouching { get; private set; }

        private float _joystickRadius;
        
        public float Vertical() => IsTouching ? Direction.y * Speed : 0.0f;
        public float Horizontal() => IsTouching ? Direction.x * Speed : 0.0f;

        
        private void Start()
        {
            _joystickRadius = JoystickBackground.sizeDelta.x * 0.5f;
        }
        
        public void OnPointerDown(BaseEventData eventData)
        {
            IsTouching = true;
            UpdateJoystickPosition((PointerEventData) eventData);
        }

        public void OnDrag(BaseEventData eventData)
        {
            UpdateJoystickPosition((PointerEventData) eventData);
        }

        public void OnPointerUp(BaseEventData eventData)
        {
            IsTouching = false;
            Speed = 0.0f;
            Direction = Vector2.zero;
            JoystickHandle.anchoredPosition = Vector2.zero;
        }

        private void UpdateJoystickPosition(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickBackground, 
                eventData.position, eventData.pressEventCamera, out Vector2 touchPos);
            touchPos = Vector2.ClampMagnitude(touchPos, _joystickRadius);
            
            JoystickHandle.anchoredPosition = touchPos;

            Direction = touchPos.normalized;
            Speed = touchPos.magnitude / _joystickRadius;
        }
    }
}
