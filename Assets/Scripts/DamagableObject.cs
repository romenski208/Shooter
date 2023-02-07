using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagableObject : MonoBehaviour
{
    [SerializeField] private float _durability;
    [SerializeField] private float _health;

    public float Durability => _durability;

    public void ApplyDamage(float damage)
    {
        if (_health == -1)
            return;

        _health -= damage;

        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
