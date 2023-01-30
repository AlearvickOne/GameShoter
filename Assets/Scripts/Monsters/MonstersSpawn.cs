using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonstersSpawn : AwakeMonoBehaviour
{
    [SerializeField] private GameObject[] _monsters;
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
