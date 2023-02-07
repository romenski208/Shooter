using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private int _raysCount;
    [SerializeField] private float _distance;
    [SerializeField] private float _angle;

    public event UnityAction PlayerDetected;

    private bool IsRayHitPlayer(Vector3 direction)
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, direction, out hit, _distance);
        return hit.transform.TryGetComponent(out Player player);
    }

    private bool RayToScan()
    {
        bool a = false;
        bool b = false;
        float j = 0;

        for (int i = 0; i < _raysCount; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += _angle * Mathf.Deg2Rad / _raysCount;

            Vector3 direction = transform.TransformDirection(new Vector3(x, 0, y));

            if (IsRayHitPlayer(direction)) 
                a = true;

            if (x != 0)
            {
                direction = transform.TransformDirection(new Vector3(-x, 0, y));

                if (IsRayHitPlayer(direction)) 
                    b = true;
            }
        }

        return (a || b);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            if (RayToScan())
            {
                PlayerDetected?.Invoke();
            }
        }
    }
}
