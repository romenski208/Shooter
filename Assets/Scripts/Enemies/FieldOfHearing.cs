using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldOfHearing : MonoBehaviour
{
    public event UnityAction PlayerDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCombat playerCombat))
        {
            playerCombat.Shooted += OnPlayerShooted;         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerCombat playerCombat))
        {
            playerCombat.Shooted -= OnPlayerShooted;
        }
    }

    private void OnPlayerShooted()
    {
        PlayerDetected?.Invoke();
    }
}
