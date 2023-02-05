using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Spawn monsters at the beginning of the game and place them in the structure for further work with them.
/// </summary>
public class MonstersSpawn : AwakeMonoBehaviour
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject[] _monsters;
    [Header("                             PARAMETERS")]
    [Space(10)]
    [SerializeField] private int _spawnMonsterQuantity;

    protected internal AiMonsters[] _aiMonsters;

    private void Awake()
    {
        _aiMonsters = new AiMonsters[_spawnMonsterQuantity];
        if (_aiMonsters != null)
        {
            SpawnMonsters(_aiMonsters);
        }
    }

    private void SpawnMonsters(AiMonsters[] aiMonsters)
    {
        for (int i = 0; i < _spawnMonsterQuantity; i++)
        {
            int randomMonsters = Random.Range(0, _monsters.Length);
            GameObject newMonsters = Instantiate(_monsters[randomMonsters], transform.position, Quaternion.identity);
            aiMonsters[i].monsterAnimation = newMonsters.GetComponent<Animator>();
            aiMonsters[i].monsterAgent = newMonsters.GetComponent<NavMeshAgent>();

            newMonsters.transform.parent = transform;

        }
    }
}
