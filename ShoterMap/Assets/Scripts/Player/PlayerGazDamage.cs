using UnityEngine;

public class PlayerGazDamage : AwakeMonoBehaviour
{
    private BoxCollider _playerColl;
    [SerializeField] private float _timeDamage;
    private float _timer;

    private void Start()
    {
        _timer = _timeDamage;
        _playerColl = SaveParametersObjects._singleton._playerColl;
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerGazZoneDamage(other);
    }

    private void PlayerGazZoneDamage(Collider other)
    {
        _timer -= Time.deltaTime;
        if (other == _playerColl && _timer <= 0 && SaveParametersObjects._protivogas == false)
        {
            SaveParametersObjects._playerHealth -= 10;
            _timer = _timeDamage;
        }
    }
}
