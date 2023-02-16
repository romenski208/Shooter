using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionSystem : MonoBehaviour
{
    [Header("Hearing")]
    [SerializeField] private FieldOfHearing _fieldOfHearing;
    [SerializeField] private float _hearingRadius;

    [Header("Vision")]
    [SerializeField] private FieldOfView _fieldOfView;
    [SerializeField] private float _viewRadius = 10;
    [SerializeField] private float _viewAngle = 180;
    [SerializeField] private LayerMask _playerMask;
    [SerializeField] private LayerMask _obstacleMask;

    public event UnityAction PlayerDetected;

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

    private void Start()
    {
        _fieldOfView.Init(_viewRadius, _viewAngle, _playerMask, _obstacleMask);
        _fieldOfHearing.Init(_hearingRadius);
    }

    private void OnPlayerDetected()
    {
        PlayerDetected?.Invoke();
    }
}
