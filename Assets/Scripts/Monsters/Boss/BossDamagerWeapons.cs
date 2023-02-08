using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamagerWeapons : StructsSave
{
    private readonly int MONSTER_ANIM_DEAD = Animator.StringToHash("MonsterDead");

    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Animator _monsterAnimator;

    private void Update()
    {
        BossIsDead();
    }

    private void OnTriggerEnter(Collider other)
    {
        BossDamageWeapons(other);
    }

    private void BossDamageWeapons(Collider other)
    {

        for (int i = 0; i < _weaponsAmmoStructs.Length; i++)
        {
            if (other == _weaponsAmmoStructs[i].bulletColl && _bossIsDead == false)
            {
                switch (_weaponsAmmoStructs[i].ammoType)
                {
                    case AmmoType.ammoPistolet:
                        _bossHP -= Random.Range(5, 10);
                        break;
                    case AmmoType.ammoAutomat:
                        _bossHP -= Random.Range(10, 20);
                        break;
                    case AmmoType.ammoRacketnica:
                        _bossHP -= Random.Range(40, 50);
                        break;
                }
            }
        }
    }

    private void BossIsDead()
    {
        if (_bossHP <= 0 && _bossIsDead == false)
        {
            AmmoAdding();
        }
    }

    private void AmmoAdding()
    {
        StartCoroutine(TimerAnimAndDeactive(3.2f));
        for (int i = 0; i < _ammoShopsStructs.Length; i++)
        {
            if (_ammoShopsStructs[i].ammoShop.gameObject.activeSelf == false)
            {
                _ammoShopsStructs[i].ammoShop.gameObject.SetActive(true);
                _ammoShopsStructs[i].ammoShop.position = this.transform.position;
                break;
            }
        }
        _bossIsDead = true;

    }
    private IEnumerator TimerAnimAndDeactive(float second)
    {
        if (_monsterAnimator != null)
        {
            _monsterAnimator.SetTrigger(MONSTER_ANIM_DEAD);
            yield return new WaitForSeconds(second);
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
