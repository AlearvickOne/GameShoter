using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : WeaponCharacters
{
    void OnEnable()
    {
        _ammoForwardToPoint._ammoType = _ammoType;
        _weaponSounds = GetComponent<AudioSource>();
    }

    void Update()
    {
        Timers();
        FireWeapon(_rpm);
    }
}
