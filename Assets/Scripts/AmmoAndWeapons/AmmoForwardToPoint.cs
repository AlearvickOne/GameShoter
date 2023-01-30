using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoForwardToPoint : AwakeMonoBehaviour
{

    [SerializeField] private AmmoSpawnStart _ammoSpawnStart;
    [SerializeField] private Transform[] _weaponDulo;
    [SerializeField] private List<Rigidbody> _ammoBulletsRigidbody;
    WeaponsAmmoStruct[] _weaponsAmmoStruct;
    protected internal Vector3 _firePoint;
    protected internal AmmoType _ammoType;

    void Start()
    {
        _weaponsAmmoStruct = _ammoSpawnStart._weaponsAmmoStruct;
        for (int i = 0; i < _weaponsAmmoStruct.Length; i++)
        {
            _ammoBulletsRigidbody.Add(_weaponsAmmoStruct[i].bullet.GetComponent<Rigidbody>());
        }
    }

    public void FireBulletForward()
    {
        Debug.Log(_ammoType);
        switch (_ammoType)
        {
            case AmmoType.ammoPistolet:
                for (int i = 0; i < _ammoSpawnStart._weaponsAmmoStruct.Length; i++)
                {
                    if (_weaponsAmmoStruct[i].bullet.activeSelf == false && _weaponsAmmoStruct[i].ammoType == AmmoType.ammoPistolet)
                    {
                        FireBulletForwardParameters(i, 0);
                        break;
                    }
                }
                break;
            case AmmoType.ammoAutomat:
                for (int i = 0; i < _ammoSpawnStart._weaponsAmmoStruct.Length; i++)
                {
                    if (_weaponsAmmoStruct[i].bullet.activeSelf == false && _weaponsAmmoStruct[i].ammoType == AmmoType.ammoAutomat)
                    {
                        FireBulletForwardParameters(i, 1);
                        break;
                    }
                }
                break;
            case AmmoType.ammoRacketnica:
                for (int i = 0; i < _ammoSpawnStart._weaponsAmmoStruct.Length; i++)
                {
                    if (_weaponsAmmoStruct[i].bullet.activeSelf == false && _weaponsAmmoStruct[i].ammoType == AmmoType.ammoRacketnica)
                    {
                        FireBulletForwardParameters(i, 2);
                        break;
                    }
                }
                break;
        }

    }

    void FireBulletForwardParameters(int i, int weaponIndex)
    {
        Debug.Log("rack");
        _ammoSpawnStart._weaponsAmmoStruct[i].bullet.SetActive(true);
        _ammoSpawnStart._weaponsAmmoStruct[i].bullet.transform.position = _weaponDulo[weaponIndex].position;
        Vector3 pos = Vector3.MoveTowards(_weaponDulo[weaponIndex].position, _firePoint, 10 * Time.deltaTime);
        _ammoBulletsRigidbody[i].velocity = (_firePoint - pos);
        _ammoSpawnStart._weaponsAmmoStruct[i].bullet.transform.LookAt(pos);
    }
}
