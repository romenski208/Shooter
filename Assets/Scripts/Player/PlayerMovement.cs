using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _movementSpeed = 5f;

    public void Move(float horizontalInput, float verticalInput)
    {
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;
        _controller.Move(moveDirection * _movementSpeed * Time.deltaTime);
    }
}
