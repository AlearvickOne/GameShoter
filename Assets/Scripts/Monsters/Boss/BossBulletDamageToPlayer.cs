using UnityEngine;

/// <summary>
/// The script is responsible for causing damage to the target (player) by the boss.
/// </summary>

public class BossBulletDamageToPlayer : MonoBehaviour
{
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private PlayerCharacter _pCharacter;
    [SerializeField] private BossSpawnAmmo _bossSpawnAmmo;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _bossSpawnAmmo._ammoBossStruct.Length; i++)
        {
            Transform bulletBoss = _bossSpawnAmmo._ammoBossStruct[i].bulletBoss;
            BoxCollider bulletColl = _bossSpawnAmmo._ammoBossStruct[i].bulletBossCollider;
            if (gameObject != null && other == bulletColl && bulletBoss != false)
            {
                SaveSceneParametersObjects._singleton._playerHealth -= 50;
            }
        }

    }
}
