using UnityEngine;

/// <summary>
/// The script is responsible for causing damage to the target (player) by the boss.
/// </summary>

public class BossBulletDamageToPlayer : StructsSave
{
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private PlayerCharacter _pCharacter;

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _ammoBossStructs.Length; i++)
        {
            Transform bulletBoss = _ammoBossStructs[i].bulletBoss;
            BoxCollider bulletColl = _ammoBossStructs[i].bulletBossCollider;
            if (gameObject != null && other == bulletColl && bulletBoss != false)
            {
                SaveParametersObjects._singleton._playerHealth -= 50;
            }
        }

    }
}
