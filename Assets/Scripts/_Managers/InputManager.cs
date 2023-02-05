using UnityEngine;

/// <summary>
/// A script for assigning control to a character and everything related to it.
/// </summary>

public class InputManager : AwakeMonoBehaviour
{
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private PlayerCharacter _pCharacter;

    private void Update()
    {
        PlayerMovePosition();
    }
    private void PlayerMovePosition()
    {
        if (Input.GetMouseButton(1))
        {
            _pCharacter.MoveRaycast();
            _pCharacter._playerIsMove = true;
        }
        else if (_pCharacter._playerAgent.remainingDistance <= _pCharacter._playerAgent.stoppingDistance)
        {
            _pCharacter._playerIsMove = false;
        }
    }
}
