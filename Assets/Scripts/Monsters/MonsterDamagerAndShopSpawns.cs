using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamagerAndShopSpawns : AwakeMonoBehaviour
{
    [SerializeField] private AmmoSpawnStart _ammoSpawnStart;
    [SerializeField] private ListSpawnAmmoShops _listSpawnAmmoShops;

    [SerializeField] protected internal float _monsterHp;

    private void Start()
    {
        FindComponents();
    }

    void FindComponents()
    {
        _ammoSpawnStart = GameObject.FindGameObjectWithTag("AmmoSpawns").GetComponent<AmmoSpawnStart>();
        _listSpawnAmmoShops = GameObject.FindGameObjectWithTag("listSpawnAmmoShop").GetComponent<ListSpawnAmmoShops>();
    }

    private void Update()
    {
        AmmoAddingMonsterisDead();
    }

    void OnTriggerEnter(Collider other)
    {
        MonsterDamageWeapons(other);
    }
     
    void MonsterDamageWeapons(Collider other)
    {
        for (int i = 0; i < _ammoSpawnStart._weaponsAmmoStruct.Length; i++)
        {
            if (other == _ammoSpawnStart._weaponsAmmoStruct[i].bulletColl)
            {
                switch (_ammoSpawnStart._weaponsAmmoStruct[i].ammoType)
                {
                    case AmmoType.ammoPistolet:
                        _monsterHp -= Random.Range(5, 10);
                        break;   
                    case AmmoType.ammoAutomat:
                        _monsterHp -= Random.Range(10, 20);
                        break;   
                    case AmmoType.ammoRacketnica:
                        _monsterHp -= Random.Range(40, 50);
                        break;
                }
            }
        }
    }

    void AmmoAddingMonsterisDead()
    {
        if(this._monsterHp <= 0)
        {
            this.gameObject.SetActive(false);
            for (int i = 0; i < _listSpawnAmmoShops._ammoShopsStruct.Length; i++)
            {
                if(_listSpawnAmmoShops._ammoShopsStruct[i].ammoShop.gameObject.activeSelf == false)
                {
                    _listSpawnAmmoShops._ammoShopsStruct[i].ammoShop.gameObject.SetActive(true);
                    _listSpawnAmmoShops._ammoShopsStruct[i].ammoShop.position = this.transform.position;
                    break;
                }
            }
        }
    }
}

