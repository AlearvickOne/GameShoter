using UnityEngine;
using UnityEngine.AI;

public class PlayerCharacter : AwakeMonoBehaviour
{
    private NavMeshAgent _playerAgent;
    private Camera _cam;
    protected internal float _playerHealth = 1000;
    protected internal bool _playerIsMove;

    private void Start()
    {
        FindGetComponents();
    }

    private void FindGetComponents()
    {
        _cam = Camera.main;
        _playerAgent = GetComponent<NavMeshAgent>();
    }

    protected internal void MoveRaycast()
    {
        Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            _playerAgent.destination = hit.point;
        }
    }
}
