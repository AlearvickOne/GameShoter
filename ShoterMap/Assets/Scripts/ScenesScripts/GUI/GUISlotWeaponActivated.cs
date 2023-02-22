using UnityEngine;

/// <summary>
/// Activation of weapon icons in the GUI, if it is activated by the player.
/// </summary>
public class GUISlotWeaponActivated : AwakeMonoBehaviour
{
    private int ANIM_ACTIVE_SLOT = Animator.StringToHash("WeaponSells");

    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private Animator[] _GUIAnimator;

    private void Update()
    {
        SlotAndAnimationRatio();
    }

    private void SlotAndAnimationRatio()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            if (_weapons[i].activeSelf == true)
                AnimSlotActive(i, true);
        }

        for (int n = 0; n < _weapons.Length; n++)
        {
            if (_weapons[n].activeSelf == false)
                AnimSlotActive(n, false);
        }
    }

    private void AnimSlotActive(int index, bool isActive)
    {
        _GUIAnimator[index].SetBool(ANIM_ACTIVE_SLOT, isActive);
    }
}

