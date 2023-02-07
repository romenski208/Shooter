using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private int _raysCount;
    [SerializeField] private int _distance;
    [SerializeField] private float _angle;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _ai;

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 position = transform.position + _offset;
        if (Physics.Raycast(position, dir, out hit, _distance))
        {
            if (hit.transform == _target)
            {
                result = true;
                Debug.DrawLine(position, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(position, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(position, dir * _distance, Color.red);
        }
        return result;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;

        for (int i = 0; i < _raysCount; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += +_angle * Mathf.Deg2Rad / _raysCount;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, _target.position) < _distance)
        {
            if (RayToScan())
            {
                _ai.enabled = true;
                _ai.SetDestination(_target.position);
            }
        }
    }
}
