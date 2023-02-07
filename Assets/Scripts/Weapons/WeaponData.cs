using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Weapon Data", fileName = "New Weapon Data", order = 54)]
public class WeaponData : ScriptableObject 
{
    [SerializeField] private float _attackRange;
    [SerializeField] private float _shotPower;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _spreadSpeedUp;
    [SerializeField] private bool _isSpreading;

    public bool IsSpreading => _isSpreading;
    public float AttackRange => _attackRange;
    public float ShotPower => _shotPower;
    public float FireRate => _fireRate;
    public float SpreatSpeedUp => _spreadSpeedUp;
}
