using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera and Player Interaction Settings.
/// </summary>
public class CameraInPlayer : AwakeMonoBehaviour
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject player;
    private MeshRenderer render;
    [Header("                             ARRAYS")]
    [Space(10)]
    [SerializeField] private List<GameObject> objectRayCast = new List<GameObject>();
    private int layerMask = 1 << 6;

    private void Awake()
    {
        FindComponents();
    }

    private void LateUpdate()
    { 
        RayCastCameraPlayer();
        CameraPosToPlayer();
    }

    void FindComponents()
    {
        layerMask = ~layerMask;
    }

    private void CameraPosToPlayer()
    {
        transform.position = new Vector3(player.transform.position.x + 4, 30, player.transform.position.z + 20);
    }

    private void RayCastCameraPlayer()
    {
        RaycastHit hit;
        Vector3 nVector = new Vector3(312, 181, 0);
        Ray ray = Camera.main.ScreenPointToRay(nVector);


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
