using UnityEngine;

public class SlotWeaponActivatedGUI : AwakeMonoBehaviour
{
    [SerializeField] private GameObject[] _weapons;
    [SerializeField] private Animator[] _GUIAnimator;

    int ANIM_ACTIVE_SLOT = Animator.StringToHash("WeaponSells");

    void Update()
    {
        SlotAndAnimationRatio();
    }

    void SlotAndAnimationRatio()
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

    private void AnimSlotActive(int index ,bool isActive)
    {
        _GUIAnimator[index].SetBool(ANIM_ACTIVE_SLOT, isActive);
    }
}

