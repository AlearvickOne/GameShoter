using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerCharacter : AwakeMonoBehaviour
{
    protected internal NavMeshAgent _playerAgent;
    private Camera _cam;
    protected internal float _playerHealth = 1000;
    [SerializeField] private Slider _playerHpSliderGUI;
    [SerializeField] protected internal bool _playerIsMove;

    private void Start()
    {
        FindGetComponents();
    }

    private void Update()
    {
        PlayeHpInSliderHp();
    }

    private void FindGetComponents()
    {
        _playerHpSliderGUI.maxValue = _playerHealth;
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

    private void PlayeHpInSliderHp()
    {
        _playerHpSliderGUI.value = _playerHealth;
    }
}
