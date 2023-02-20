using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

/// <summary>
/// Basic Player Settings.
/// </summary>

public class PlayerCharacter : AwakeMonoBehaviour
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Slider _playerHpSliderGUI;
    protected internal NavMeshAgent _playerAgent;

    private void Start()
    {
        FindGetComponents();
    }

    private void Update()
    {
        PlayeHpInSliderHp();
        PlayerHeathCheck();
    }

    private void FindGetComponents()
    {
        _playerHpSliderGUI.maxValue = 1000;
        SaveParametersObjects._playerHealth = _playerHpSliderGUI.maxValue;
        _playerAgent = GetComponent<NavMeshAgent>();
    }

    protected internal void MoveRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            _playerAgent.destination = hit.point;
        }
    }

    private void PlayeHpInSliderHp()
    {
        _playerHpSliderGUI.value = SaveParametersObjects._playerHealth;
    }

    private void PlayerHeathCheck()
    {
        if (SaveParametersObjects._playerHealth < 0)
            SaveParametersObjects._playerHealth = 0;
        else if(SaveParametersObjects._playerHealth > _playerHpSliderGUI.maxValue)
        {
            SaveParametersObjects._playerHealth = _playerHpSliderGUI.maxValue;
            _playerHpSliderGUI.value = _playerHpSliderGUI.maxValue;
        }
    }
}
