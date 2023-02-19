using UnityEngine;

public class PlayerGazDamage : MonoBehaviour
{
    BoxCollider _playerColl;
    [SerializeField] float _timeDamage;
    float _timer;

    private void Start()
    {
        _timer = _timeDamage;
        _playerColl = SaveParametersObjects._singleton._playerColl;
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerGazZoneDamage(other);
    }

    void PlayerGazZoneDamage(Collider other)
    {
        _timer -= Time.deltaTime;
        if(other == _playerColl && _timer <= 0 && SaveParametersObjects._protivogas == false)
        {
            SaveParametersObjects._playerHealth -= 10;
            _timer = _timeDamage;
        }
    }
}
