using UnityEngine;
/// <summary>
/// The scenario determines that if a player enters the boss's field of view,
/// then the boss is given a signal to attack the player.
/// </summary>
public class TargetScopeTrigger : AwakeMonoBehaviour
{
    [Header("                             SCRIPTS")]
    [Space(10)]
    private BossAI _bossAI;
    [Header("                             OBJECTS")]
    [Space(10)]
    private BoxCollider _playerColl;

    private void Start()
    {
        _bossAI = GetComponentInParent<BossAI>();
        _playerColl = SaveParametersObjects._singleton._playerColl;

    }

    private void ColliderTriggerBossEyes(Collider other, bool bossEyesPlayer)
    {
        if (other == _playerColl)
        {
            _bossAI._bossSeePlayer = bossEyesPlayer;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ColliderTriggerBossEyes(other, true);
    }

    private void OnTriggerExit(Collider other)
    {
        ColliderTriggerBossEyes(other, false);
    }
}
