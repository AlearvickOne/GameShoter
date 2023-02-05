using System.Collections;
using UnityEngine;

/// <summary>
/// Spawn loot as bullet magazines, after the death of the monster.
/// </summary>
public class MonsterDamagerAndShopSpawns : AwakeMonoBehaviour
{
    int MONSTER_ANIM_DEAD = Animator.StringToHash("MonsterDead");

    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private AmmoSpawnStart _ammoSpawnStart;
    [SerializeField] private ListSpawnAmmoShops _listSpawnAmmoShops;
    [Header("                             PARAMETERS")]
    [Space(10)]
    [SerializeField] protected internal float _monsterHp;
    protected internal bool _monsterIsDead = false;
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Animator _monsterAnimator;

    private void Start()
    {
        FindComponents();
    }

    private void FindComponents()
    {
        _ammoSpawnStart = GameObject.FindGameObjectWithTag("AmmoSpawns").GetComponent<AmmoSpawnStart>();
        _listSpawnAmmoShops = GameObject.FindGameObjectWithTag("listSpawnAmmoShop").GetComponent<ListSpawnAmmoShops>();
    }

    private void Update()
    {
        AmmoAddingMonsterisDead();
    }

    private void OnTriggerEnter(Collider other)
    {
        MonsterDamageWeapons(other);
    }

    private void MonsterDamageWeapons(Collider other)
    {
        for (int i = 0; i < _ammoSpawnStart._weaponsAmmoStruct.Length; i++)
        {
            if (other == _ammoSpawnStart._weaponsAmmoStruct[i].bulletColl && this._monsterIsDead == false)
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

    private void AmmoAddingMonsterisDead()
    {
        if(this._monsterHp <= 0 && this._monsterIsDead == false)
        {
            StartCoroutine(TimerAnimAndDeactive(3.2f));
            for (int i = 0; i < _listSpawnAmmoShops._ammoShopsStruct.Length; i++)
            {
                if(_listSpawnAmmoShops._ammoShopsStruct[i].ammoShop.gameObject.activeSelf == false)
                {
                    _listSpawnAmmoShops._ammoShopsStruct[i].ammoShop.gameObject.SetActive(true);
                    _listSpawnAmmoShops._ammoShopsStruct[i].ammoShop.position = this.transform.position;
                    break;
                }
            }
            this._monsterIsDead = true;
        }
    }

    private IEnumerator TimerAnimAndDeactive(float second)
    {
        if(_monsterAnimator != null)
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

