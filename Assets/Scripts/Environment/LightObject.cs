using System.Collections.Generic;
using Entities;
using Interfaces;
using UnityEngine;

namespace Environment
{
    public class LightObject : MonoBehaviour, IHealingSource
    {
        [field: SerializeField, Range(1f, 100f)] public float Health { get; set; }
        [field: SerializeField] public float TransferTime { get; set; }
    
        private float _initialLightRadius = 10f;
        private float _currentTransferTime;
    
        private Light _light;
        private CircleCollider2D _circleCollider;
    
        private readonly List<Entity> _collidingEntities = new ();

    
        private void Awake()
        {
            _light = GetComponentInChildren<Light>();
            _circleCollider = GetComponentInChildren<CircleCollider2D>();

            _circleCollider.radius = Mathf.Max(_light.range, 0.1f) * 0.5f;
            _initialLightRadius = _light.range;
        }
    
        private void Update()
        {
            if (_collidingEntities.Count > 0)
            {
                Entity[] entitiesCopy = _collidingEntities.ToArray();
                
                foreach (Entity entity in entitiesCopy)
                {
                    if(entity is null || entity.IsFullHealth) return;
                    entity.AdjustHealth(CalculateHealthAmount());
                }
            }
        }
    
        public float CalculateHealthAmount()
        {
            if (_currentTransferTime < TransferTime)
            {
                float deltaRadius = _initialLightRadius / TransferTime * Time.deltaTime;
                
                _light.range = Mathf.Max(_light.range - deltaRadius, 0.25f);
                _circleCollider.radius = Mathf.Max(_circleCollider.radius - deltaRadius / 2f, 0.5f);
            
                _currentTransferTime += Time.deltaTime;
            
                return deltaRadius / _initialLightRadius * Health;
            }

            Destroy(gameObject);
            return 0;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Entity entity)
                && !_collidingEntities.Contains(entity))
            {
                _collidingEntities.Add(entity);
            }
        }
    
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Entity entity)
                && _collidingEntities.Contains(entity))
            {
                _collidingEntities.Remove(entity);
            }
        }
    }
}
