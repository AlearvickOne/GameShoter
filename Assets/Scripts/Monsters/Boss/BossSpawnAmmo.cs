using UnityEngine;

/// <summary>
/// Spawn bullets for the boss at the beginning of the game.
/// </summary>

public class BossSpawnAmmo : StructsSave
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject _bulletBoss;
    [SerializeField] private Transform _bulletBossBandolier;
    [Header("                             PARAMETERS")]
    [Space(10)]
    [SerializeField] private int _ammoBossQuantity;

    private void Start()
    {
        _ammoBossStructs = new AmmoBossStruct[_ammoBossQuantity];
        StartSpawn();
    }

    private void StartSpawn()
    {
        for (int i = 0; i < _ammoBossStructs.Length; i++)
        {
            GameObject newSpawn = Instantiate(_bulletBoss, _bulletBossBandolier.position, Quaternion.identity);
            newSpawn.transform.parent = _bulletBossBandolier;
            _ammoBossStructs[i].bulletBoss = newSpawn.transform;
            _ammoBossStructs[i].bulletBossRigidbody = newSpawn.GetComponent<Rigidbody>();
            _ammoBossStructs[i].bulletBossCollider = newSpawn.GetComponent<BoxCollider>();
            newSpawn.SetActive(false);
        }
    }
}
