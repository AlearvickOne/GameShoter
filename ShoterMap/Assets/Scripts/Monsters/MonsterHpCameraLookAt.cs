using UnityEngine;
/// <summary>
/// Turns the GUI monster HP front to the camera.
/// </summary>
public class MonsterHpCameraLookAt : AwakeMonoBehaviour
{
    private void Update()
    {
        GUILookAtCamera();
    }

    private void GUILookAtCamera()
    {
        transform.LookAt(Camera.main.transform);
    }
}
