using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private KeyCode _shootKey = KeyCode.Mouse0;

    public event UnityAction<float, float> MoveKeysPressing;
    public event UnityAction<float, float> MouseRotating;
    public event UnityAction ShootKeyPressing;
    public event UnityAction JumpKeyPressed;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontalInput) != 0 || Mathf.Abs(verticalInput) != 0)
        {
            MoveKeysPressing(horizontalInput, verticalInput);
        }

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (Mathf.Abs(mouseX) != 0 || Mathf.Abs(mouseY) != 0)
        {
            MouseRotating(mouseX, mouseY);
        }

        if (Input.GetKeyDown(_jumpKey))
        {
            JumpKeyPressed?.Invoke();
        }

        if (Input.GetKey(_shootKey))
        {
            ShootKeyPressing?.Invoke();
        }
    }
}
