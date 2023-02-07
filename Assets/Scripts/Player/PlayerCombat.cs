using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;

    public event UnityAction Shooted;

    public void Shoot()
    {
        if (_currentWeapon.TryShoot())
            Shooted?.Invoke();
    }
}
