using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private float _minAngle = -45;
    [SerializeField] private float _maxAngle = 45;
    [SerializeField] private float _mouseSensetivity;

    private float _rotationY;

    public void Rotate(float mouseY)
    {
        mouseY *= _mouseSensetivity * Time.deltaTime;

        _rotationY -= mouseY;
        _rotationY = Mathf.Clamp(_rotationY, _minAngle, _maxAngle);

        transform.localRotation = Quaternion.Euler(_rotationY, 0, 0);
    }

}
