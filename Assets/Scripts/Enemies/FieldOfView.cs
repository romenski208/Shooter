using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] public int _raysCount;
    [SerializeField] public int _distance;
    [SerializeField] public float _angle;
    [SerializeField] public Transform _target;
    [SerializeField] public NavMeshAgent _ai;

    private bool IsRayHitTarget(Vector3 direction)
    {
        Physics.Raycast(transform.position, direction, out RaycastHit hit, _distance);

        return hit.transform == _target; 
    }

    bool RayToScan()
    {
        bool a = false;
        bool b = false;
        float j = 0;

        for (int i = 0; i < _raysCount; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += +_angle * Mathf.Deg2Rad / _raysCount;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));

            if (IsRayHitTarget(dir)) 
                a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));

                if (IsRayHitTarget(dir)) 
                    b = true;
            }
        }

        return (a || b);

    }

    private void OnTriggerStay(Collider other)
    {
        if (_ai.enabled == true)
            return;

        if (RayToScan())
        {
            _ai.enabled = true;
        }
    }

    private void Update()
    {
        if (_ai.enabled)
            _ai.SetDestination(_target.position);
    }
}
