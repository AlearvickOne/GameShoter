using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonstersAiController : AwakeMonoBehaviour
{
    [SerializeField] private MonstersSpawn _mSpawn;
    [SerializeField] private GameObject _player;
    private PlayerCharacter _playerCharacter;

    protected internal AiMonsters[] _aiMonsters;
    protected internal const float _startSpeed = 10;

    void Start()
    {
        FindGetComponents();
        StartCoroutine(MonsterMoveToPointAndAttack(_aiMonsters));
    }

    void FindGetComponents()
    {
        _aiMonsters = _mSpawn._aiMonsters;
        _playerCharacter = _player.GetComponent<PlayerCharacter>();
    }

    IEnumerator MonsterMoveToPointAndAttack(AiMonsters[] aiMonsters)
    {
        while (true)
        {
            for (int i = 0; i < aiMonsters.Length; i++)
            {
                float dist = Vector3.Distance(aiMonsters[i].monsterAgent.transform.position, _player.transform.position);
                if (dist > 2 && aiMonsters[i].monsterAgent.gameObject.activeSelf != false)
                {
                    aiMonsters[i].monsterAgent.speed = _startSpeed;
                    aiMonsters[i].monsterAgent.destination = _player.transform.position;
                }
                else if (dist < 2)
                {
                    aiMonsters[i].monsterAgent.speed = 0;
                    float randDamage = Random.Range(1.0f, 5.0f);
                    _playerCharacter._playerHealth -= randDamage;
                    Debug.Log(randDamage);
                    Debug.Log("HP " + _playerCharacter._playerHealth);
                }
            }
            yield return null;
        }
    }
}
