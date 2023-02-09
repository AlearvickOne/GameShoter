using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeadAndShopSpawn : StructsSave
{
    private readonly int MONSTER_ANIM_DEAD = Animator.StringToHash("MonsterDead");

    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Animator _monsterAnimator;

    private void Update()
    {
        for (int k = 0; k < _aiBossStructs.Length; k++)
        {
            BossIsDead(k);

        }
    }

    private void BossIsDead(int k)
    {
        if (_aiBossStructs[k].bossHP <= 0 && _aiBossStructs[k].bossIsDead == false)
        {
            AmmoAdding(k);
        }
    }

    private void AmmoAdding(int k)
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
        _aiBossStructs[k].bossIsDead = true;

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
