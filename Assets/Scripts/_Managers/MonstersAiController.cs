using System.Collections;
using UnityEngine;
/// <summary>
/// Controls the AI of most monsters.
/// </summary>
public class MonstersAiController : AwakeMonoBehaviour
{
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private MonstersSpawn _mSpawn;
    private PlayerCharacter _playerCharacter;
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject _player;

    protected internal AiMonsters[] _aiMonsters;
    protected internal const float _startSpeed = 10;

    private void Start()
    {
        FindGetComponents();
        StartCoroutine(MonsterMoveToPointAndAttack(_aiMonsters));
    }

    private void FindGetComponents()
    {
        _aiMonsters = _mSpawn._aiMonsters;
        _playerCharacter = _player.GetComponent<PlayerCharacter>();
    }

    private IEnumerator MonsterMoveToPointAndAttack(AiMonsters[] aiMonsters)
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
                else if (dist < 2 && aiMonsters[i].monsterAgent.gameObject.activeSelf != false)
                {
                    aiMonsters[i].monsterAgent.speed = 0;
                    float randDamage = Random.Range(1.0f, 5.0f);
                    _playerCharacter._playerHealth -= randDamage;
                }
            }
            yield return null;
        }
    }
}
