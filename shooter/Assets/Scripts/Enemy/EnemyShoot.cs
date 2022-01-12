using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour 
{
    [SerializeField] Transform GunPosition;
    [SerializeField] Guns Guns;
    [SerializeField] private GameObject _bullet;
    [SerializeField] float FiringTime;
    [SerializeField] float shootRadius;
    private float _distance;
    [SerializeField] private Transform _target;
    private GameObject _bulletToDestroy;
    private Guns guns;
    private bool isShoot;

    private void Start()
    {
        guns = GetComponent<Guns>();
        guns.CurrentAmmo = guns.MaxAmmo;
    }

    private void OnEnable()
    {
        guns.IsReloading = false;
    }

    private void Update()
    {
        if (guns.IsReloading)
            return;
        if (guns.CurrentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if ( isShoot&& Time.time >= guns.NextTimeToFire)
        {
            guns.NextTimeToFire = Time.time + 1f / guns.FireRate;
            Shoot();
        }
        //_distance = Vector3.Distance(_target.position, transform.position);
        //if (_distance <= _lookRadius)
        //{
       // Shoot();
        //}
    }

    private void Shoot()
    {
        if(isShoot)
        {
            guns.CurrentAmmo--;
            StartCoroutine(Attack());
        }     
    }

    IEnumerator Reload()
    {
        guns.IsReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(guns.ReloadTime);
        guns.CurrentAmmo = guns.MaxAmmo;
        guns.IsReloading = false;
    }
    private IEnumerator Attack()
    {
        isShoot = false;
        _bulletToDestroy = Instantiate(_bullet, _target.position, _target.rotation);
        Destroy(_bulletToDestroy, 3);
        yield return new WaitForSeconds(FiringTime);
        isShoot = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(GunPosition.position, _target.position);
    }
}




