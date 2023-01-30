using UnityEngine;

public class MonsterHpCameraLookAt : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.LookAt(cam.transform);
    }
}
