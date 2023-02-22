using UnityEngine;

/// <summary>
/// Camera and Player Interaction Settings.
/// </summary>
public class CameraInPlayer : AwakeMonoBehaviour
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject player;

    private void LateUpdate()
    {
        CameraPosToPlayer();
    }

    private void CameraPosToPlayer()
    {
        transform.position = new Vector3(player.transform.position.x + 4, 30, player.transform.position.z + 20);
    }

}
