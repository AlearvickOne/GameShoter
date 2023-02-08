using UnityEngine;
/// <summary>
/// The script is responsible for attacking the boss on the target.
/// </summary>
public class BossAttack : StructsSave
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _bossLeftWeapon;
    [SerializeField] private Transform _bossRightWeapon;
    [SerializeField] private BossSpawnAmmo _bossSpawnAmmo;
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private BossAI _bossAI;
    [Header("                             PARAMETERS")]
    [Space(10)]
    private float _timeRpm;
    private bool _oneShot = false;
    [Header("                               AUDIO")]
    [Space(10)]
    [SerializeField] private AudioSource _bossAudioSource;
    [SerializeField] private AudioClip _fireAudio;

    private void Update()
    {
        _timeRpm += Time.deltaTime;

        TimeRpmAttack(0.3f, _bossRightWeapon, false);
        TimeRpmAttack(0.6f, _bossLeftWeapon, true);

    }

    private void TimeRpmAttack(float maxTime, Transform weaponBossName, bool oneShot)
    {
        if (_timeRpm > maxTime && _oneShot == oneShot && _bossAI._bossSeePlayer == true && _bossIsDead == false)
        {
            RayCastBossToPlayer(weaponBossName);

            if (oneShot == true)
                _timeRpm = 0;

            _oneShot = !_oneShot;
        }


    }

    private void RayCastBossToPlayer(Transform weaponBossName)
    {
        for (int i = 0; i < _ammoBossStructs.Length; i++)
        {
            if (Physics.Raycast(weaponBossName.position, _playerTransform.position) && _ammoBossStructs[i].bulletBoss.gameObject.activeSelf == false)
            {
                _ammoBossStructs[i].bulletBoss.gameObject.SetActive(true);
                Vector3 towards = Vector3.MoveTowards(weaponBossName.position, _playerTransform.position, 10 * Time.deltaTime);
                Debug.DrawRay(weaponBossName.position, _playerTransform.position);
                _ammoBossStructs[i].bulletBoss.position = weaponBossName.position;
                _ammoBossStructs[i].bulletBoss.position = towards;
                _ammoBossStructs[i].bulletBossRigidbody.velocity = (_playerTransform.position - towards) * 2;
                _bossAudioSource.PlayOneShot(_fireAudio);
                break;
            }
        }
    }
}
