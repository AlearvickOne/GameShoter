using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// The script is responsible for AI and boss animation.
/// </summary>

public class BossAI : StructsSave
{
    private readonly int BOSS_ANIM_IDLE = Animator.StringToHash("BossIdle");
    private readonly int BOSS_ANIM_RUN = Animator.StringToHash("BossRun");
    private readonly int BOSS_ANIM_IDLE_ATTACK = Animator.StringToHash("BossIdleAttack");
    private readonly int BOSS_ANIM_RUN_ATTACK = Animator.StringToHash("BossRunAttack");

    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] protected internal Transform _player;
    [SerializeField] private NavMeshAgent _bossAgent;
    [SerializeField] private Animator _bossAnimator;
    [SerializeField] private Transform _targetScopePoint;
    private Transform _bossTransform;
    [Header("                             PARAMETERS")]
    [Space(10)]
    [SerializeField] private float _bossSpeed;
    protected internal bool _bossSeePlayer;
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private AmmoForwardToPoint _ammoForwardToPoint;

    private void Awake()
    {
        FindComponents();
    }
    private void Update()
    {
        BossMoveToPlayer();
    }

    private void FindComponents()
    {
        _bossTransform = _bossAgent.GetComponent<Transform>();
        _bossHP = 10000;
        _bossIsDead = false;
    }

    private void BossMoveToPlayer()
    {
        float dist = Vector3.Distance(_bossTransform.position, _player.position);
        float bossMinDist = 20;
        float bossMaxDist = 50;
        _bossAgent.stoppingDistance = bossMinDist;

        if (dist <= bossMinDist && _bossIsDead == false)
        {
            _bossTransform.LookAt(_player);
            ActiveAnimations(BOSS_ANIM_IDLE, BOSS_ANIM_IDLE_ATTACK);
        }
        else if (dist > bossMinDist && dist <= bossMaxDist && _bossIsDead == false)
        {
            _bossAgent.speed = _bossSpeed;
            _bossAgent.destination = _player.position;
            _bossTransform.LookAt(_player);
            ActiveAnimations(BOSS_ANIM_RUN, BOSS_ANIM_RUN_ATTACK);
        }
        else if (dist > bossMaxDist && _bossIsDead == false)
        {
            _bossAgent.speed = 0;
            AnimationBossPlay(BOSS_ANIM_IDLE);
        }
    }

    private void ActiveAnimations(int animNoBossAttack, int animBossAttack)
    {
        switch (_bossSeePlayer)
        {
            case true:
                Debug.Log("Boss see player");
                BossAttack(animBossAttack);
                break;
            case false:
                Debug.Log("Boss is not see player");
                AnimationBossPlay(animNoBossAttack);
                break;
        }
    }

    private void AnimationBossPlay(int nameAnim)
    {
        if (_bossAnimator != null)
        {
            _bossAnimator.SetTrigger(nameAnim);
        }
    }
    private void BossAttack(int nameAnim)
    {
        AnimationBossPlay(nameAnim);
    }
}
