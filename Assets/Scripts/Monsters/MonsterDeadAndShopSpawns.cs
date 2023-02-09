using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Spawn loot as bullet magazines, after the death of the monster.
/// </summary>
public class MonsterDeadAndShopSpawns : StructsSave
{
    private readonly int MONSTER_ANIM_DEAD = Animator.StringToHash("MonsterDead");

    [Header("                             PARAMETERS")]
    [Space(10)]
    private int _nomberObject;
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Animator _monsterAnimator;

    private void Start()
    {
        FindComponents();
    }

    private void FindComponents()
    {
        for (int n = 0; n < _aiMonstersStructs.Length; n++)
        {
            if (_aiMonstersStructs[n].monsterObject == gameObject)
            {
                _nomberObject = n;
            }
        }
    }

    private void Update()
    {
        MonsterIsDead();
    }

    private void MonsterIsDead()
    {
        while (_aiMonstersStructs[_nomberObject].monsterHP <= 0)
        {
            AmmoAdding();
            return;
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
        _aiMonstersStructs[_nomberObject].monsterIsDead = true;

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

