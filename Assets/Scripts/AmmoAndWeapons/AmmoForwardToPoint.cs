using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Determines where to move the ammunition after the shot.
/// </summary>
public class AmmoForwardToPoint : StructsSave
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Transform[] _weaponDulo;
    [Header("                             ARRAYS")]
    [Space(10)]
    [SerializeField] private List<Rigidbody> _ammoBulletsRigidbody;

    protected internal Vector3 _firePoint;
    protected internal AmmoType _ammoType;

    private void Start()
    {
        FindComponents();
    }

    private void FindComponents()
    {
        for (int i = 0; i < _weaponsAmmoStructs.Length; i++)
        {
            _ammoBulletsRigidbody.Add(_weaponsAmmoStructs[i].bullet.GetComponent<Rigidbody>());
        }
    }

    protected internal void FireBulletForward()
    {
        switch (_ammoType)
        {
            case AmmoType.ammoPistolet:
                FindBulletOnStruct(AmmoType.ammoPistolet, 0);
                break;
            case AmmoType.ammoAutomat:
                FindBulletOnStruct(AmmoType.ammoAutomat, 1);
                break;
            case AmmoType.ammoRacketnica:
                FindBulletOnStruct(AmmoType.ammoRacketnica, 2);
                break;
        }
    }

    private void FindBulletOnStruct(AmmoType ammoType, int nomberWeapon)
    {
        for (int i = 0; i < _weaponsAmmoStructs.Length; i++)
        {
            if (_weaponsAmmoStructs[i].bullet.activeSelf == false && _weaponsAmmoStructs[i].ammoType == ammoType)
            {
                FireBulletForwardParameters(i, nomberWeapon);
                break;
            }
        }
    }

    private void FireBulletForwardParameters(int i, int weaponIndex)
    {
        _weaponsAmmoStructs[i].bullet.SetActive(true);
        _weaponsAmmoStructs[i].bullet.transform.position = _weaponDulo[weaponIndex].position;

        Vector3 pos = Vector3.MoveTowards(_weaponDulo[weaponIndex].position, _firePoint, 10 * Time.deltaTime);

        _ammoBulletsRigidbody[i].velocity = (_firePoint - pos) * 1;
        _weaponsAmmoStructs[i].bullet.transform.LookAt(pos);

    }
}
