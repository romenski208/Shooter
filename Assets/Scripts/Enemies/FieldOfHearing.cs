using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class FieldOfHearing : MonoBehaviour
{
    private BoxCollider _collider;

    public event UnityAction PlayerDetected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCombat player))
        {
            print("hearing enter");
            player.Shooted += OnPlayerShooted;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerCombat player))
        {
            print("hearing exit");
            player.Shooted -= OnPlayerShooted;
        }
    }

    private void OnPlayerShooted()
    {
        PlayerDetected?.Invoke();
    }

    public void Init(float hearingRadius)
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
        _collider.size = new Vector3(hearingRadius, hearingRadius, hearingRadius);
    }
}
