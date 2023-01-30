using System.Collections.Generic;
using UnityEngine;

public class CameraInPlayer : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> objectRayCast = new List<GameObject>();

    int layerMask = 1 << 6;

    private void Awake()
    {
        layerMask = ~layerMask;
        cam = Camera.main;
    }

    private void LateUpdate()
    { 
        RayCastCameraPlayer();
        transform.position = new Vector3(player.transform.position.x +4, 30, player.transform.position.z + 20);
    }

    MeshRenderer render;
    private void RayCastCameraPlayer()
    {
        RaycastHit hit;
        Vector3 nVector = new Vector3(312, 181, 0);
        Ray ray = cam.ScreenPointToRay(nVector);


        if(Physics.Raycast(ray.origin, ray.direction, out hit, 20, layerMask, QueryTriggerInteraction.Collide))
        {
            Debug.DrawRay(ray.origin, ray.direction * 30, Color.red);

            objectRayCast.Add(hit.collider.gameObject);
            render = hit.collider.GetComponent<MeshRenderer>();
            render.enabled = false;
            if(objectRayCast.Count > 5)
            {

                objectRayCast.Clear();
            }

        }
        else if (objectRayCast.Count != default)
        {
            render.enabled = true;
        }
    }
}
