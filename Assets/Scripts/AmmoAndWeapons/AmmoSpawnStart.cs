using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawnStart : AwakeMonoBehaviour
{
    protected internal WeaponsAmmoStruct[] _weaponsAmmoStruct;
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform[] ammoBandoliers;
    [SerializeField] private int spawnPistoletAmmoQuantity;
    [SerializeField] private int spawnAutomatAmmoQuantity;
    [SerializeField] private int spawnRacketnicaAmmoQuantity;

    void Awake()
    {
        int allAmmoSpawn = spawnRacketnicaAmmoQuantity + spawnAutomatAmmoQuantity + spawnRacketnicaAmmoQuantity;
        _weaponsAmmoStruct = new WeaponsAmmoStruct[allAmmoSpawn];
        SpawnAmmo();
    }

    void SpawnAmmo()
    {
        int pistolet = 0;
        int automat = 1;
        int racketnica = 2;

        int ammoSum1 = spawnAutomatAmmoQuantity + spawnPistoletAmmoQuantity;
        int ammoSum2 = ammoSum1 + spawnRacketnicaAmmoQuantity;

        for (int i = 0; i < spawnPistoletAmmoQuantity; i++)
        {
            Spawn(i, pistolet, AmmoType.ammoPistolet);
        }
        for (int i = 0; i < ammoSum1; i++)
        {
            Spawn(i, automat, AmmoType.ammoAutomat);
        }
        for (int i = 0; i < ammoSum2; i++)
        {
            Spawn(i, racketnica, AmmoType.ammoRacketnica);
        }
    }

    void Spawn(int i, int indexWeapon, AmmoType ammoType)
    {
        if (_weaponsAmmoStruct[i].isFull == false)
        {
            GameObject newSpawn = Instantiate(bullets[indexWeapon], ammoBandoliers[indexWeapon].position, Quaternion.identity);
            newSpawn.transform.parent = ammoBandoliers[indexWeapon];
            _weaponsAmmoStruct[i].bullet = newSpawn.gameObject;
            _weaponsAmmoStruct[i].bulletColl = newSpawn.GetComponent<BoxCollider>();
            _weaponsAmmoStruct[i].ammoType = ammoType;
            _weaponsAmmoStruct[i].bullet.SetActive(false);
            _weaponsAmmoStruct[i].isFull = true;
        }
    }
}
