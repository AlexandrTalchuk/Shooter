using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{
    [Header("Weapon Properties")]
    [SerializeField] private float _range;
    [SerializeField] private float _damage;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _currentAmmo;
    [SerializeField] private float _reloadTime;
    private float _nextTimeToFire = 0f;
    private bool _isReloading = false;


    [Header("Directions of the shot")]
    [SerializeField] private float _scatterAngle;
    private float _xScatter;
    private float _yScatter;
    private float _zScatter;

    public float Range
    {
        get=> _range;
        set => _range = value;
    }
    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }
    public float FireRate
    {
        get => _fireRate;
        set => _fireRate = value;
    }
    public int MaxAmmo
    {
        get => _maxAmmo;
        set => _maxAmmo = value;
    }
    public int CurrentAmmo
    {
        get => _currentAmmo;
        set => _currentAmmo = value;
    }
    public float ReloadTime
    {
        get => _reloadTime;
        set => _reloadTime = value;
    }
    public float NextTimeToFire
    {
        get => _nextTimeToFire;
        set => _nextTimeToFire = value;
    }
    public bool IsReloading
    {
        get => _isReloading;
        set => _isReloading = value;
    }
    public float ScatterAngle
    {
        get => _scatterAngle;
        set => _scatterAngle = value;
    }

    public float X
    {
        get => _xScatter;
        set => _xScatter = value;
    }
    public float Y
    {
        get => _yScatter;
        set => _yScatter = value;
    }
    public float Z
    {
        get => _zScatter;
        set => _zScatter = value;
    }

}
   