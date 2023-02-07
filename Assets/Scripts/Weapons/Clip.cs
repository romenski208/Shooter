using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Clip : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _capacity;

    private List<Bullet> _bullets = new List<Bullet>();
    private int _currentBulletIndex = 0;

    public Bullet TryGetBullet()
    {
        if (_currentBulletIndex >= _capacity) 
            return null;

        _currentBulletIndex++;

        Bullet bullet = _bullets.FirstOrDefault(b => b.gameObject.activeSelf == false);

        if (bullet == null)
        {
            bullet = Instantiate(_bullet);
            _bullets.Add(bullet);
        }

        return bullet;
    }
}
