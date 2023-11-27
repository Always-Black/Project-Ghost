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
        private Vector2 _defaultPos;
        
        public float Vertical() => Direction.y * Speed;
        public float Horizontal() => Direction.x * Speed;

        
        private void Start()
        {
            _joystickRadius = JoystickBackground.sizeDelta.x * 0.5f;
        }

        public void OnPointerDown(BaseEventData data)
        {
            IsTouching = true;
            _defaultPos = ((PointerEventData) data).position;
        }

        public void OnDrag(BaseEventData data)
        {
            Vector2 touchPos = ((PointerEventData) data).position;
            Direction = (touchPos - _defaultPos).normalized;
            Speed = Mathf.Clamp(Vector2.Distance(_defaultPos, touchPos) / _joystickRadius, 0.0f, 1.0f);
            JoystickHandle.anchoredPosition = Direction * _joystickRadius * Speed;
        }

        public void OnPointerUp(BaseEventData data)
        {
            IsTouching = false;
            Speed = 0.0f;
            Direction = Vector2.zero;
            JoystickHandle.anchoredPosition = Vector2.zero;
        }
    }
}
