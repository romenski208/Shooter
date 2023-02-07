using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyBehaivor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _target;
    [SerializeField] private FieldOfHearing _fieldOfHearing;
    [SerializeField] private FieldOfView _fieldOfView;

    private void OnEnable()
    {
        _fieldOfHearing.PlayerDetected += OnPlayerDetected;
        _fieldOfView.PlayerDetected += OnPlayerDetected;
    }

    private void OnDisable()
    {
        _fieldOfHearing.PlayerDetected -= OnPlayerDetected;
        _fieldOfView.PlayerDetected -= OnPlayerDetected;
    }

    private void OnPlayerDetected()
    {
        _agent.enabled = true;

        /*
        _fieldOfHearing.PlayerDetected -= OnPlayerDetected;
        _fieldOfView.PlayerDetected -= OnPlayerDetected;
        _fieldOfHearing.enabled = false;
        _fieldOfView.enabled = false;
        */
    }

    private void Update()
    {
        if (_agent.enabled)
            _agent.SetDestination(_target.position);
    }
}
