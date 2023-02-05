using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Determines where to move the ammunition after the shot.
/// </summary>
public class AmmoForwardToPoint : AwakeMonoBehaviour
{
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private AmmoSpawnStart _ammoSpawnStart;
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Transform[] _weaponDulo;
    [Header("                             ARRAYS")]
    [Space(10)]
    [SerializeField] private List<Rigidbody> _ammoBulletsRigidbody;

    private WeaponsAmmoStruct[] _weaponsAmmoStruct;
    protected internal Vector3 _firePoint;
    protected internal AmmoType _ammoType;

    private void Start()
    {
        FindComponents();
    }

    private void FindComponents()
    {
        _weaponsAmmoStruct = _ammoSpawnStart._weaponsAmmoStruct;
        for (int i = 0; i < _weaponsAmmoStruct.Length; i++)
        {
            _ammoBulletsRigidbody.Add(_weaponsAmmoStruct[i].bullet.GetComponent<Rigidbody>());
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
        for (int i = 0; i < _ammoSpawnStart._weaponsAmmoStruct.Length; i++)
        {
            if (_weaponsAmmoStruct[i].bullet.activeSelf == false && _weaponsAmmoStruct[i].ammoType == ammoType)
            {
                FireBulletForwardParameters(i, nomberWeapon);
                break;
            }
        }
    }

    private void FireBulletForwardParameters(int i, int weaponIndex)
    {
        _ammoSpawnStart._weaponsAmmoStruct[i].bullet.SetActive(true);
        _ammoSpawnStart._weaponsAmmoStruct[i].bullet.transform.position = _weaponDulo[weaponIndex].position;

        Vector3 pos = Vector3.MoveTowards(_weaponDulo[weaponIndex].position, _firePoint, 10 * Time.deltaTime);

        _ammoBulletsRigidbody[i].velocity = (_firePoint - pos) * 1;
        _ammoSpawnStart._weaponsAmmoStruct[i].bullet.transform.LookAt(pos);

    }
}
