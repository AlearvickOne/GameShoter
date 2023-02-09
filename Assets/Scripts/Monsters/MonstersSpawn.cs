using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Spawn monsters at the beginning of the game and place them in the structure for further work with them.
/// </summary>
public class MonstersSpawn : StructsSave
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject[] _monsters;
    [SerializeField] private Transform[] _randomSpawnPos;
    [Header("                             PARAMETERS")]
    [Space(10)]
    [SerializeField] private int _spawnMonsterQuantity;

    private void Awake()
    {
        _aiMonstersStructs = new AiMonsters[_spawnMonsterQuantity];
        if (_aiMonstersStructs != null)
        {
            SpawnMonsters();

        }
    }

    private void SpawnMonsters()
    {

        for (int i = 0; i < _spawnMonsterQuantity; i++)
        {
            int randomPos = Random.Range(0, _randomSpawnPos.Length);
            int randomMonsters = Random.Range(0, _monsters.Length);

            Vector3 randomSphereXZ = new Vector3(Random.insideUnitSphere.x * 50, transform.position.y, Random.insideUnitSphere.z * 50);
            Vector3 spawnRandomTransform = _randomSpawnPos[randomPos].position + randomSphereXZ;

            GameObject newMonsters = Instantiate(_monsters[randomMonsters], spawnRandomTransform, Quaternion.identity);

            _aiMonstersStructs[i].monsterAnimation = newMonsters.GetComponent<Animator>();
            _aiMonstersStructs[i].monsterAgent = newMonsters.GetComponent<NavMeshAgent>();
            _aiMonstersStructs[i].monsterColl = newMonsters.GetComponent<BoxCollider>();
            _aiMonstersStructs[i].monsterObject = newMonsters;
            _aiMonstersStructs[i].monsterIsDead = false;
            Debug.LogError(_aiMonstersStructs.Length);
            switch (randomMonsters)
            {
                case 0:
                    MonsterHpAndType(i, MonsterType.greenMonster, 20);
                    break;
                case 1:
                    MonsterHpAndType(i, MonsterType.bigGreenMonster, 40);
                    break;
            }

            newMonsters.transform.parent = transform;
        }
    }

    private void MonsterHpAndType(int i, MonsterType monsterType, float monsterHp)
    {
        _aiMonstersStructs[i].monsterType = monsterType;
        _aiMonstersStructs[i].monsterHP = monsterHp;
    }
}
