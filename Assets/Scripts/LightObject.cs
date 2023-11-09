using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    private Light _light;
    [SerializeField] private CircleCollider2D _collider;


    public float HealPerSec;
    [SerializeField] private float _maxHeal;
    [SerializeField] private float _currentHeal;
    private float _radius;

    void Awake()
    {
        _light = GetComponentInChildren<Light>();
        _radius = _light.range;
    }

    public void ChangeHealAmount(float diff)
    {
        _currentHeal -= diff;
        if (_currentHeal > 0)
        {
            _light.range = _currentHeal / _maxHeal * _radius;
            _collider.radius = _light.range / 2f;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
