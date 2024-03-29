using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Rigidbody _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _reloadTime;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private bool _isShooting;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        var waitForSeconds = new WaitForSeconds(_reloadTime);

        while (_isShooting)
        {
            var direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);

            newBullet.velocity = direction * _bulletSpeed;

            yield return waitForSeconds;
        }
    }
}
