using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : AwakeMonoBehaviour
{
    [Header("Scripts")]
    private PlayerCharacter _pCharacter;
    [SerializeField] private MonstersSpawn _mSpawns;

    [Header("Player Animations")]
    [SerializeField] private Animator _playerAnimator;
    private int PLAYER_ANIM_IDLE = Animator.StringToHash("Player_Idle");
    private int PLAYER_ANIM_RUN = Animator.StringToHash("Player_Run");

    [Header("Monsters Animations")]
    private AiMonsters[] _aiMonsters;
    private int MONSTERGREEN_ANIM_IDLE = Animator.StringToHash("MonsterGreenIdle");
    private int MONSTERGREEN_ANIM_RUN = Animator.StringToHash("MonsterGreenRun");
    private int MONSTERGREENBIG_ANIM_IDLE = Animator.StringToHash("MonsterBigGreenIdle");
    private int MONSTERGREENBIG_ANIM_RUN = Animator.StringToHash("MonsterBigGreenRun");

    [Header("Weapons Animations")]
    [SerializeField] private GameObject[] _weapons;
    private int WEAPON_ANIM_ALL = Animator.StringToHash("Weapons");
    private int WEAPON_PISTOLET_ANIM_FIRE = Animator.StringToHash("PistoletFire");
    private int WEAPON_AUTOMAT_ANIM_FIRE = Animator.StringToHash("AutomatFire");
    private int WEAPON_RACKETNICA_ANIM_FIRE = Animator.StringToHash("AutomatFire");

    private void Start()
    {
        FindGetComponents();
    }

    void FindGetComponents()
    {
        _pCharacter = _playerAnimator.GetComponent<PlayerCharacter>();

        if (_mSpawns._aiMonsters != null)
            _aiMonsters = _mSpawns._aiMonsters;
    }

    private void Update()
    {
        PlayerAnimations(_pCharacter._playerIsMove);

        if (_aiMonsters != null)
            MonstersAnimations(_aiMonsters);
        if (_weapons != null)
            WeaponsAnimations();
    }

    private void PlayerAnimations(bool playerIsMove)
    {
        switch (playerIsMove && _playerAnimator != null)
        {
            case true:
                _playerAnimator.SetTrigger(PLAYER_ANIM_RUN);
                break;
            case false:
                _playerAnimator.SetTrigger(PLAYER_ANIM_IDLE);
                break;
        }
    }

    private void MonstersAnimations(AiMonsters[] aiMonsters)
    {
        for (int i = 0; i < aiMonsters.Length; i++)
        {
            aiMonsters[i].monsterAnimation = _aiMonsters[i].monsterAnimation;
            if (aiMonsters != null)
            {
                float dist = Vector3.Distance(_playerAnimator.transform.position, aiMonsters[i].monsterAnimation.transform.position);

                if (dist < 30 && dist > 5)
                {
                    aiMonsters[i].monsterAnimation.SetTrigger(MONSTERGREEN_ANIM_RUN);
                    aiMonsters[i].monsterAnimation.SetTrigger(MONSTERGREENBIG_ANIM_RUN);
                }
                else if (dist <= 5)
                {
                    aiMonsters[i].monsterAnimation.SetTrigger(MONSTERGREEN_ANIM_IDLE);
                    aiMonsters[i].monsterAnimation.SetTrigger(MONSTERGREENBIG_ANIM_IDLE);
                }
            }
        }
    }

    private void WeaponsAnimations()
    {

        for (int i = 0; i < _weapons.Length; i++)
        {
            switch (i)
            {
                case 0:
                    ActiveWeaponAnim(i, WEAPON_PISTOLET_ANIM_FIRE, true);
                    break;
                case 1:
                    ActiveWeaponAnim(i, WEAPON_AUTOMAT_ANIM_FIRE, true);
                    break;
                case 2:
                    ActiveWeaponAnim(i, WEAPON_RACKETNICA_ANIM_FIRE, true);
                    break;
            }
        }

        for (int i = 0; i < _weapons.Length; i++)
        {
            switch (i)
            {
                case 0:
                    ActiveWeaponAnim(i, WEAPON_PISTOLET_ANIM_FIRE, false);
                    continue;
                case 1:
                    ActiveWeaponAnim(i, WEAPON_AUTOMAT_ANIM_FIRE, false);
                    continue;
                case 2:
                    ActiveWeaponAnim(i, WEAPON_RACKETNICA_ANIM_FIRE, false);
                    break;
            }
        }

        if (_weapons[0].activeSelf == false && _weapons[1].activeSelf == false && _weapons[2].activeSelf == false)
        {
            _playerAnimator.SetBool(WEAPON_ANIM_ALL, false);
        }
    }

    private void ActiveWeaponAnim(int i, int animName, bool isActive)
    {
        if (_weapons[i].activeSelf == isActive)
        {
            _playerAnimator.SetBool(WEAPON_ANIM_ALL, true);
            _playerAnimator.SetBool(animName, isActive);
        }
    }
}
