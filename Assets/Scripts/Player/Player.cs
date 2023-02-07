using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerRotator _rotator;
    [SerializeField] private CameraRotator _cameraRotator;
    [SerializeField] private PlayerJumper _jumper;
    [SerializeField] private PlayerCombat _combat;

    private void OnEnable()
    {
        _input.MoveKeysPressing += OnMoveKeysPressing;
        _input.MouseRotating += OnMouseRotating;
        _input.JumpKeyPressed += OnJumpKeyPressed;
        _input.ShootKeyPressing += OnShootKeyPressed;
    }

    private void OnDisable()
    {
        _input.MoveKeysPressing -= OnMoveKeysPressing;
        _input.MouseRotating -= OnMouseRotating;
        _input.JumpKeyPressed -= OnJumpKeyPressed;
        _input.ShootKeyPressing -= OnShootKeyPressed;
    }

    private void OnMoveKeysPressing(float horizontalInput, float verticalInput)
    {
        _movement.Move(horizontalInput, verticalInput);
    }

    private void OnMouseRotating(float mouseX, float mouseY)
    {
        _rotator.Rotate(mouseX);
        _cameraRotator.Rotate(mouseY);
    }

    private void OnJumpKeyPressed()
    {
        _jumper.TryJump();
    }

    private void OnShootKeyPressed()
    {
        _combat.Shoot();
    }
}
