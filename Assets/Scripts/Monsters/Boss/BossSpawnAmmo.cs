using UnityEngine;

/// <summary>
/// Spawn bullets for the boss at the beginning of the game.
/// </summary>

public class BossSpawnAmmo : AwakeMonoBehaviour
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject _bulletBoss;
    [SerializeField] private Transform _bulletBossBandolier;
    [Header("                             PARAMETERS")]
    [Space(10)]
    [SerializeField] private int _ammoBossQuantity;

    public struct AmmoBossStruct
    {
        public Transform bulletBoss;
        public Rigidbody bulletBossRigidbody;
        public BoxCollider bulletBossCollider;
    }

    protected internal AmmoBossStruct[] _ammoBossStruct;

    private void Start()
    {
        _ammoBossStruct = new AmmoBossStruct[_ammoBossQuantity];
        StartSpawn();
    }

    private void StartSpawn()
    {
        for (int i = 0; i < _ammoBossStruct.Length; i++)
        {
            GameObject newSpawn = Instantiate(_bulletBoss, _bulletBossBandolier.position, Quaternion.identity);
            newSpawn.transform.parent = _bulletBossBandolier;
            _ammoBossStruct[i].bulletBoss = newSpawn.transform;
            _ammoBossStruct[i].bulletBossRigidbody = newSpawn.GetComponent<Rigidbody>();
            _ammoBossStruct[i].bulletBossCollider = newSpawn.GetComponent<BoxCollider>();
        }
    }
}
