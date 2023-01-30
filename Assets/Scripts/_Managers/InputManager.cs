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
        else
            _pCharacter._playerIsMove = false;
    }
}
