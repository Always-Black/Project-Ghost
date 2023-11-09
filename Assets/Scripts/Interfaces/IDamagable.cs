using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public float Health { get; set; }
    public float MaxHealth { get; set; }

    public void ReceiveDamage(float damage);
    public void ReceiveHeal(float heal);
}
