using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData _data;
    [SerializeField] private Clip _clip;
    [SerializeField] private Transform _shootPoint;

    private WaitForSeconds _internalReloading;
    private float _spreadPower;
    private Coroutine _coroutine;

    private void Start()
    {
        _internalReloading = new WaitForSeconds(1 / _data.FireRate);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (_spreadPower > 0 && _coroutine == null)
            _spreadPower -= _data.SpreatSpeedUp;
    }

    public bool TryShoot()
    {
        if (_coroutine != null)
            return false;

        Bullet bullet = _clip.TryGetBullet();

        if (bullet == null)
            return false;

        _coroutine = StartCoroutine(Shooting(bullet));
        return true;
    }

    private IEnumerator Shooting(Bullet bullet)
    {
        _spreadPower += _data.SpreatSpeedUp;

        Vector2 spread = new Vector2(
            Random.Range(-_spreadPower, _spreadPower),
            Random.Range(-_spreadPower, _spreadPower)
            ) * System.Convert.ToInt32(_data.IsSpreading);

        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2) + spread); 

        Vector3 direction = ray.direction;

        bullet.gameObject.SetActive(true);
        bullet.Init(_shootPoint, direction, _data.ShotPower, _data.AttackRange); 

        yield return _internalReloading;

        _coroutine = null;
    }
}
