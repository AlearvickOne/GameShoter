using System.Collections;
using UnityEngine;
/// <summary>
/// Controls the AI of most monsters.
/// </summary>
public class MonstersAiController : StructsSave
{
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private MonstersSpawn _mSpawn;
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject _player;
    protected internal const float _startSpeed = 10;

    private void Start()
    {
        StartCoroutine(MonsterMoveToPointAndAttack());
    }

    private void MonsterDeactiveFarAway(int i, float dist)
    {
        if (dist > 100 && _aiMonstersStructs[i].monsterObject.activeSelf == true && _aiMonstersStructs[i].monsterHP > 0)
        {

            _aiMonstersStructs[i].monsterObject.SetActive(false);
        }
        if(dist < 100 && _aiMonstersStructs[i].monsterObject.activeSelf == false && _aiMonstersStructs[i].monsterHP > 0)
        {
           _aiMonstersStructs[i].monsterObject.SetActive(true);
        }
    }

    private IEnumerator MonsterMoveToPointAndAttack()
    {
        while (_aiMonstersStructs != null)
        { 
            for (int i = 0; i < _aiMonstersStructs.Length; i++)
            {
                float dist = Vector3.Distance(_aiMonstersStructs[i].monsterObject.transform.position, _player.transform.position);
                MonsterDeactiveFarAway(i, dist);

                if (dist > 2 && dist < 50 &&  _aiMonstersStructs[i].monsterObject.activeSelf != false)
                {
                    _aiMonstersStructs[i].monsterAgent.speed = _startSpeed;
                    _aiMonstersStructs[i].monsterAgent.destination = _player.transform.position;
                }
                else if (dist < 2 && _aiMonstersStructs[i].monsterObject.activeSelf != false)
                {
                    _aiMonstersStructs[i].monsterAgent.speed = 0;
                    float randDamage = Random.Range(1.0f, 5.0f);
                    SaveParametersObjects._playerHealth -= randDamage;
                }
            }
            yield return null;
        }
    }
}
