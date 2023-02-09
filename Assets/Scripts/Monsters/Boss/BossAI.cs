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
    [SerializeField] private Transform _targetScopePoint;
    [Header("                             PARAMETERS")]
    [Space(10)]
    [SerializeField] private float _bossSpeed;
    protected internal bool _bossSeePlayer;
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private AmmoForwardToPoint _ammoForwardToPoint;

    private void Awake()
    {
        FindComponentsAddStructs();
    }
    private void Update()
    {
        for (int i = 0; i < _aiBossStructs.Length; i++)
        {
            BossMoveToPlayer(i);
        }
    }

    private void FindComponentsAddStructs()
    {
        _aiBossStructs = new AiBoss[1];
        for (int i = 0; i < _aiBossStructs.Length; i++)
        {
            _aiBossStructs[i].bossObject = gameObject;
            _aiBossStructs[i].bossTransform = gameObject.transform;
            _aiBossStructs[i].bossAgent = gameObject.GetComponent<NavMeshAgent>();
            _aiBossStructs[i].bossAnimator = gameObject.GetComponent<Animator>();
            _aiBossStructs[i].bossColl = gameObject.GetComponent<BoxCollider>();
            _aiBossStructs[i].bossHP = 10000;
            _aiBossStructs[i].bossIsDead = false;
        }
    }

    private void BossMoveToPlayer(int i)
    {
        float dist = Vector3.Distance(_aiBossStructs[i].bossTransform.position, _player.position);
        float bossMinDist = 20;
        float bossMaxDist = 50;
        _aiBossStructs[i].bossAgent.stoppingDistance = bossMinDist;

        if (dist <= bossMinDist && _aiBossStructs[i].bossIsDead == false)
        {
            _aiBossStructs[i].bossTransform.LookAt(_player);
            ActiveAnimations(i, BOSS_ANIM_IDLE, BOSS_ANIM_IDLE_ATTACK);
        }
        else if (dist > bossMinDist && dist <= bossMaxDist && _aiBossStructs[i].bossIsDead == false)
        {
            _aiBossStructs[i].bossAgent.speed = _bossSpeed;
            _aiBossStructs[i].bossAgent.destination = _player.position;
            _aiBossStructs[i].bossTransform.LookAt(_player);
            ActiveAnimations(i, BOSS_ANIM_RUN, BOSS_ANIM_RUN_ATTACK);
        }
        else if (dist > bossMaxDist && _aiBossStructs[i].bossIsDead == false)
        {
            _aiBossStructs[i].bossAgent.speed = 0;
            AnimationBossPlay(i, BOSS_ANIM_IDLE);
        }
    }

    private void ActiveAnimations(int i, int animNoBossAttack, int animBossAttack)
    {
        switch (_bossSeePlayer)
        {
            case true:
                Debug.Log("Boss see player");
                BossAttack(i, animBossAttack);
                break;
            case false:
                Debug.Log("Boss is not see player");
                AnimationBossPlay(i, animNoBossAttack);
                break;
        }
    }

    private void AnimationBossPlay(int i, int nameAnim)
    {
        if (_aiBossStructs[i].bossAnimator != null)
        {
            _aiBossStructs[i].bossAnimator.SetTrigger(nameAnim);
        }
    }
    private void BossAttack(int i, int nameAnim)
    {
        AnimationBossPlay(i, nameAnim);
    }
}
