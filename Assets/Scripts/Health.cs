using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private float _durability;
    [SerializeField] private float _health;

    public float Durability => _durability;

    public event UnityAction Overed;

    public void ApplyDamage(float damage)
    {
        if (_health == -1)
            return;

        _health -= damage;

        if (_health < 0)
        {
            Overed?.Invoke();
        }
    }
}
