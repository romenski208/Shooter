using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour
{
	[SerializeField] private LayerMask _playerMask;
	[SerializeField] private LayerMask _obstacleMask;
	[SerializeField] private float _viewRadius;
	[SerializeField] private float _viewAngle;

	public event UnityAction PlayerDetected;

    private void FixedUpdate()
    {
		FindVisibleTargets();
	}

	private void FindVisibleTargets()
	{
		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, _viewRadius, _playerMask);

		foreach (var target in targetsInViewRadius)
		{
			Vector3 directionToTarget = (target.transform.position - transform.position).normalized;

			if (Vector3.Angle(transform.forward, directionToTarget) < _viewAngle / 2)
			{
				float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

				if (Physics.Raycast(transform.position, directionToTarget, distanceToTarget, _obstacleMask) == false)
				{
					PlayerDetected?.Invoke();
				}
			}
		}
	}
}

