using UnityEngine;

public class InputManager : AwakeMonoBehaviour
{
    [SerializeField] private PlayerCharacter _pCharacter;

    private void Update()
    {
        PlayerMovePosition();
    }

    void PlayerMovePosition()
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
