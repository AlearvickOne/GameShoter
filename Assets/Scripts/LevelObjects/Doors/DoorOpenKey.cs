using UnityEngine;

/// <summary>
/// Script for opening and closing doors when contacting a player, if the player has a key.
/// </summary>
public class DoorOpenKey : MonoBehaviour
{
    private int ANIM_DOOR_OPEN = Animator.StringToHash("DoorOpen");
    private int ANIM_DOOR_CLOSE = Animator.StringToHash("DoorClose");

    [SerializeField] private BoxCollider _player;
    [SerializeField] private Animator _doorAnim;
    [SerializeField] private bool _doorKey = false;

    private void OnTriggerEnter(Collider other)
    {
        DoorOpenOrClose(other, ANIM_DOOR_OPEN);
    }

    private void OnTriggerExit(Collider other)
    {
        DoorOpenOrClose(other, ANIM_DOOR_CLOSE);
    }

    private void DoorOpenOrClose(Collider other, int AnimName)
    {
        if (other == _player && _doorKey == true)
        {
            _doorAnim.SetTrigger(AnimName);
        }
    }

}
