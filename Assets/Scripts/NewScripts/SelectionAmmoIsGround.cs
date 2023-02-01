using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionAmmoIsGround : MonoBehaviour
{
    [Header("Other Scripts")]
    [SerializeField] private ListSpawnAmmoShops _listSpawnAmmoShops;
    [Space(20)]
    [SerializeField] private Weapons[] _weaponsScripts;

    [Header("All Ammo Quantity Information")]
    [SerializeField] protected internal int _pistoletQuantity;
    [SerializeField] protected internal int _automatQuantity;
    [SerializeField] protected internal int _racketinicaQuantity;

    private void Update()
    {
        AllAmmoQuantityInformation();
    }

    void AllAmmoQuantityInformation()
    {
        _pistoletQuantity = _weaponsScripts[0]._ammoShopQuantity;
        _automatQuantity = _weaponsScripts[1]._ammoShopQuantity;
        _racketinicaQuantity = _weaponsScripts[2]._ammoShopQuantity;
    }

    private void OnTriggerStay(Collider other)
    {
        AmmoAdding(other);
    }

    private void AmmoAdding(Collider other)
    {
        for (int i = 0; i < _listSpawnAmmoShops._ammoShopsStruct.Length; i++)
        {
            if (_listSpawnAmmoShops._ammoShopsStruct[i].ammoShopColl == other)
            {
                switch (_listSpawnAmmoShops._ammoShopsStruct[i].ammoShopType)
                {
                    case AmmoType.ammoPistolet:
                        AddAmmoToShopAndDeactiveObjectAmmoShop(i, 0, 20, 40);
                        break;
                    case AmmoType.ammoAutomat:
                        AddAmmoToShopAndDeactiveObjectAmmoShop(i, 1, 30, 50);
                        break;
                    case AmmoType.ammoRacketnica:
                        AddAmmoToShopAndDeactiveObjectAmmoShop(i, 2, 10, 20);
                        break;
                }
            }
        }
    }

    private void AddAmmoToShopAndDeactiveObjectAmmoShop(int i, int nomberWeapon, int minAmmoRandom, int MaxAmmoRandom)
    {
        _weaponsScripts[nomberWeapon]._ammoShopQuantity += Random.Range(minAmmoRandom, MaxAmmoRandom);
        _listSpawnAmmoShops._ammoShopsStruct[i].ammoShop.gameObject.SetActive(false);

    }
}
