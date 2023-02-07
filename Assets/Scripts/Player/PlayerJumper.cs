using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private Transform _legs;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _legsRadius;

    private bool _onGround;
    private Vector2 _velocity;

    private void Update()
    {
        _onGround = Physics.CheckSphere(_legs.position, _legsRadius, _groundMask);

        if (_onGround && _velocity.y < 0)
        {
            _velocity.y = -2;
        }

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }

    public void TryJump()
    {
        if (_onGround)
        {
            _velocity.y = Mathf.Sqrt(_gravity * _jumpPower * -2); 
        }
    }
}
