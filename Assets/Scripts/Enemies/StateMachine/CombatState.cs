using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatState : State
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _weaponPoint;

    private Vector3 _rayOffset = new Vector3(0.05f, 0, 0);
    private float _rangeOffset = 0.5f;

    private void Update()
    {
        print("combat");
        return;

        if (CheckShootingPossibility())
        {
            Agent.SetDestination(transform.position);
            // _weapon.TryShoot(Player.transform.position - transform.position);
        }
        else
        {
            Agent.SetDestination(Player.transform.position);
        }
    }

    private bool CheckShootingPossibility()
    {
        Ray2D ray = new Ray2D(_weapon.transform.position - _rayOffset, _weapon.transform.right);
        // RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, _weapon.Data.FireRange - _rangeOffset);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10 - _rangeOffset);

        Debug.DrawRay(ray.origin, ray.direction * 12, Color.green);

        return hit.collider != null && hit.collider.TryGetComponent(out Player player);
    }
}
