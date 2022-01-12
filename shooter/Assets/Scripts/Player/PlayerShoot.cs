using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _bullet;
    private GameObject _bulletToDestroy;
    private Guns guns;


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
        if (Input.GetMouseButton(0) && Time.time >= guns.NextTimeToFire)
        {
            guns.NextTimeToFire = Time.time + 1f / guns.FireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        guns.CurrentAmmo--;
        RaycastHit hit;
        guns.X = Random.Range(-guns.ScatterAngle, guns.ScatterAngle);
        guns.Y = Random.Range(-guns.ScatterAngle, guns.ScatterAngle);
        guns.Z = Random.Range(-guns.ScatterAngle, guns.ScatterAngle);
        Vector3 Direction = _playerCamera.transform.TransformDirection(Vector3.forward + new Vector3(guns.X, guns.Y, guns.Z));
        if (Physics.Raycast(_playerCamera.transform.position, Direction, out hit, guns.Range))
        {
            //Debug.Log(hit.transform.name);
            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(guns.Damage);
            }
            _bulletToDestroy = Instantiate(_bullet, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
            Destroy(_bulletToDestroy, 0.05f);
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

}

