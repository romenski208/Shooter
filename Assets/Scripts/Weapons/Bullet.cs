using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private Coroutine _coroutine;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
    }

    public void Init(Transform shootPoint, Vector3 direction, float shotPower, float attackRange)
    {
        _rigidbody.velocity = Vector3.zero;
        transform.position = shootPoint.position;
        _rigidbody.velocity = direction * shotPower;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Flying(attackRange, shotPower));
    }

    /*
    private IEnumerator Flying(float attackRange, float shotPower)
    {
        while (attackRange > 0 && shotPower > 0)
        {
            attackRange--;

            RaycastHit hit;
            Physics.Raycast(transform.position, transform.forward, out hit, 1);

            if (hit.collider.TryGetComponent(out DamagableObject damagableObject))
            {
                print(damagableObject.gameObject.name);
                damagableObject.ApplyDamage(shotPower);
                shotPower -= damagableObject.Durability;
            }

            yield return null;
        }

        _coroutine = null;
        gameObject.SetActive(false);
    }
    */

    private IEnumerator Flying(float attackRange, float shotPower)
    {
        while (attackRange > 0 && shotPower > 0)
        {
            attackRange--;

            var hits = Physics.OverlapSphere(transform.position, 0.1f);

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out Health damageableObject))
                {
                    damageableObject.ApplyDamage(shotPower);
                    shotPower -= damageableObject.Durability;
                }
            }

            yield return null;
        }

        _coroutine = null;
        gameObject.SetActive(false);
    }
}
