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
    private int WEAPON_PISTOLET_ANIM_IDLE = Animator.StringToHash("PistoletIdle");
    private int WEAPON_AUTOMAT_ANIM_IDLE = Animator.StringToHash("AutomatIdle");
    private int WEAPON_RACKETNICA_ANIM_IDLE = Animator.StringToHash("RacketnicaIdle");
    //________________________________________________________________________________
    private int WEAPON_PISTOLET_ANIM_RUN = Animator.StringToHash("PistoletRun");
    private int WEAPON_AUTOMAT_ANIM_RUN = Animator.StringToHash("AutomatRun");
    private int WEAPON_RACKETNICA_ANIM_RUN = Animator.StringToHash("RacketnicaRun");

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

    #region [PLAYER ANIMATIONS]
    private void PlayerAnimations(bool playerIsMove)
    {
        if (playerIsMove == true)
            _playerAnimator.SetTrigger(PLAYER_ANIM_RUN);
        if (playerIsMove == false)
            _playerAnimator.SetTrigger(PLAYER_ANIM_IDLE);


    }
    #endregion

    #region [MONSTERS ANIMATIONS]

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
    #endregion

    #region [WEAPONS ANIMATIONS]
    private void WeaponsAnimations()
    {

        for (int i = 0; i < _weapons.Length; i++)
        {
            switch (i)
            {
                case 0:
                    ActiveWeaponAnim(i, WEAPON_PISTOLET_ANIM_IDLE, WEAPON_RACKETNICA_ANIM_RUN, true);
                    break;
                case 1:
                    ActiveWeaponAnim(i, WEAPON_AUTOMAT_ANIM_IDLE, WEAPON_AUTOMAT_ANIM_RUN, true);
                    break;
                case 2:
                    ActiveWeaponAnim(i, WEAPON_RACKETNICA_ANIM_IDLE, WEAPON_PISTOLET_ANIM_RUN, true);
                    break;
            }
        }

        for (int i = 0; i < _weapons.Length; i++)
        {
            switch (i)
            {
                case 0:
                    ActiveWeaponAnim(i, WEAPON_PISTOLET_ANIM_IDLE, default, false);
                    continue;
                case 1:
                    ActiveWeaponAnim(i, WEAPON_AUTOMAT_ANIM_IDLE, default, false);
                    continue;
                case 2:
                    ActiveWeaponAnim(i, WEAPON_RACKETNICA_ANIM_IDLE, default, false);
                    break;
            }
        }

        if (_weapons[0].activeSelf == false && _weapons[1].activeSelf == false && _weapons[2].activeSelf == false)
        {
            _playerAnimator.SetBool(WEAPON_ANIM_ALL, false);
        }
    }

    private void ActiveWeaponAnim(int i, int animNameIdle, int animNameRun, bool isActive)
    {

        if (_weapons[i].activeSelf == isActive)
        {
            _playerAnimator.SetBool(WEAPON_ANIM_ALL, true);
            _playerAnimator.SetBool(animNameIdle, isActive);
        }

        if (_pCharacter._playerIsMove == true)
            _playerAnimator.SetBool(animNameRun, true);
        else if (_pCharacter._playerIsMove == false)
            _playerAnimator.SetBool(animNameRun, false);
    }

    #endregion
}
