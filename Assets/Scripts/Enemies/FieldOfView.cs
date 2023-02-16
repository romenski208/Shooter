using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class FieldOfView : MonoBehaviour
{
    private BoxCollider _collider;
    private float _viewRadius;
    private float _viewAngle;
    private LayerMask _playerMask;
    private LayerMask _obstacleMask;

    public event UnityAction PlayerDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCombat player))
        {
            StartCoroutine(Viewing());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerCombat player))
        {
            StopCoroutine(Viewing());
        }
    }

    private IEnumerator Viewing()
    {
        while (true)
        {
            DetectPlayer();
            yield return null;
        }
    }

    private void DetectPlayer()
    {
        var targetsInViewRadius = Physics.OverlapSphere(transform.position, _viewRadius, _playerMask);

        foreach (var target in targetsInViewRadius)
        {
            Vector3 directionToTarget = (target.transform.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < _viewAngle / 2)
            {
                float distantionToTarget = Vector3.Distance(transform.position, target.transform.position);

                if (Physics.Raycast(transform.position, directionToTarget, distantionToTarget, _obstacleMask) == false)
                {
                    PlayerDetected?.Invoke();
                }
            }
        }
    }

    public void Init(float viewRadius, float viewAngle, LayerMask playerMask, LayerMask obstacleMask)
    {
        _viewRadius = viewRadius;
        _viewAngle = viewAngle;
        _playerMask = playerMask;
        _obstacleMask = obstacleMask;

        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
        _collider.size = new Vector3(viewRadius, viewRadius, viewRadius);
    }

}
