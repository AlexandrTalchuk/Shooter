using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwith : MonoBehaviour
{
    private int _selectedWeapon = 0;
    private int _previousSelectedWeapon;
    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        _previousSelectedWeapon = _selectedWeapon;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _selectedWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _selectedWeapon = 2;
        }
        if (_previousSelectedWeapon!=_selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
        transform.GetChild(_selectedWeapon).gameObject.SetActive(true);
    }
}