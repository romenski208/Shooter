using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _mouseSensetivity;

    public void Rotate(float mouseX)
    {
        mouseX *= _mouseSensetivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
    }
}
