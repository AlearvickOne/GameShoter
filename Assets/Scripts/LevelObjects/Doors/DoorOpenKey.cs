using UnityEngine;
using TMPro;

/// <summary>
/// Script for opening and closing doors when contacting a player, if the player has a key.
/// </summary>
public class DoorOpenKey : AwakeMonoBehaviour
{
    enum KeyType { nullKey, greenKey, redKey, blueKey}

    private int ANIM_DOOR_OPEN = Animator.StringToHash("DoorOpen");
    private int ANIM_DOOR_CLOSE = Animator.StringToHash("DoorClose");

    [SerializeField] private BoxCollider _player;
    [SerializeField] private Animator _doorAnim;
    [SerializeField] private KeyType _keyDoorType;
    [SerializeField] private TMP_Text _textKeyDoorInformator;

    private void OnTriggerEnter(Collider other)
    {
        DoorOpenOrClose(other, ANIM_DOOR_OPEN, true, KeyType.nullKey, true);
        DoorOpenOrClose(other, ANIM_DOOR_OPEN, SaveParametersObjects._singleton._blueKey, KeyType.blueKey, true);
        DoorOpenOrClose(other, ANIM_DOOR_OPEN, SaveParametersObjects._singleton._redKey, KeyType.redKey, true);
        DoorOpenOrClose(other, ANIM_DOOR_OPEN, SaveParametersObjects._singleton._greenKey, KeyType.greenKey, true);
    }

    private void OnTriggerExit(Collider other)
    {
        DoorOpenOrClose(other, ANIM_DOOR_CLOSE, true, KeyType.nullKey, false);
        DoorOpenOrClose(other, ANIM_DOOR_CLOSE, SaveParametersObjects._singleton._blueKey, KeyType.blueKey, false);
        DoorOpenOrClose(other, ANIM_DOOR_CLOSE, SaveParametersObjects._singleton._redKey, KeyType.redKey, false);
        DoorOpenOrClose(other, ANIM_DOOR_CLOSE, SaveParametersObjects._singleton._greenKey, KeyType.greenKey, false);
    }

    private void DoorOpenOrClose(Collider other, int AnimName, bool keyIsSelect, KeyType keyType, bool textIsActive)
    {
        if (other == _player && keyIsSelect == true && _keyDoorType == keyType)
        {
            _doorAnim.SetTrigger(AnimName);
        }
        else if (other == _player && keyIsSelect == false && _keyDoorType == keyType)
        {
            switch (keyType)
            {
                case KeyType.nullKey:
                    break;
                case KeyType.greenKey:
                    _textKeyDoorInformator.gameObject.SetActive(textIsActive);
                    _textKeyDoorInformator.text = "Need a green key";
                    break;
                case KeyType.redKey:
                    _textKeyDoorInformator.gameObject.SetActive(textIsActive);
                    _textKeyDoorInformator.text = "Need a red key";
                    break;
                case KeyType.blueKey:
                    _textKeyDoorInformator.gameObject.SetActive(textIsActive);
                    _textKeyDoorInformator.text = "Need a blue key";
                    break;
            }
            
        }
    }

}

