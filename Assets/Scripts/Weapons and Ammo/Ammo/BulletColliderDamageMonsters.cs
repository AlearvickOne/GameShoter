using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletColliderDamageMonsters : StructsSave
{
    Transform _bullet;
    AmmoType _ammoType;
    LayerMask layer = 1 << 8;

    private void Start()
    {
        FindComponents();
    }

    void FindComponents()
    {
        _bullet = transform;

        for (int i = 0; i < _weaponsAmmoStructs.Length; i++)
        {
            if(_weaponsAmmoStructs[i].bullet == this.gameObject)
            {
                _ammoType = _weaponsAmmoStructs[i].ammoType;
            }
        }
    }

    void NoAoeColliderDetectionDamageMonsters(Collider other)
    {
        for (int i = 0; i < _aiMonstersStructs.Length; i++)
        {
                Debug.Log(_aiMonstersStructs[i].monsterColl);
            if(other == _aiMonstersStructs[i].monsterColl)
            {
                switch (_ammoType)
                {
                    case AmmoType.ammoPistolet:
                        _aiMonstersStructs[i].monsterHP -= Random.Range(5, 10);
                        break;
                    case AmmoType.ammoAutomat:
                        _aiMonstersStructs[i].monsterHP -= Random.Range(10, 25);
                        break;
                }
            }
        }
        for (int i = 0; i < _aiBossStructs.Length; i++)
        {
            if (other == _aiBossStructs[i].bossColl)
            {
                switch (_ammoType)
                {
                    
                    case AmmoType.ammoPistolet:
                        _aiBossStructs[i].bossHP -= Random.Range(5, 10);
                        break;
                    case AmmoType.ammoAutomat:
                        _aiBossStructs[i].bossHP -= Random.Range(10, 25);
                        break;
                }
            }
        }
    }

    void AoeColliderDerectionDamageMonster()
    {
        Collider[] collSphereAoe = Physics.OverlapSphere(_bullet.position, 15, layer, QueryTriggerInteraction.Collide);
  
        for (int i = 0; i < _aiMonstersStructs.Length; i++)
        {
            for (int n = 0; n < collSphereAoe.Length; n++)
            {
                if(_aiMonstersStructs[i].monsterObject == collSphereAoe[n].gameObject)
                {
                    _aiMonstersStructs[i].monsterHP -= Random.Range(50, 80);
                }
            }
        }

        for (int i = 0; i < _aiBossStructs.Length; i++)
        {
            for (int n = 0; n < collSphereAoe.Length; n++)
            {
                if (_aiBossStructs[i].bossObject == collSphereAoe[n].gameObject)
                {
                    _aiBossStructs[i].bossHP -= Random.Range(50, 80);
                }
                    Debug.Log(collSphereAoe[n].gameObject);

                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        NoAoeColliderDetectionDamageMonsters(other);

        if(_ammoType == AmmoType.ammoRacketnica)
        {
            Debug.Log(_ammoType);
            AoeColliderDerectionDamageMonster();
        }
    }

}
