using UnityEngine;

public class PlayerGazDamage : MonoBehaviour
{
    [SerializeField] BoxCollider _playerColl;
    [SerializeField] float _timeDamage;
    float _timer;

    private void Start()
    {
        _timer = _timeDamage;
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerGazZoneDamage(other);
    }

    void PlayerGazZoneDamage(Collider other)
    {
        _timer -= Time.deltaTime;
        if(other == _playerColl && _timer <= 0 && SaveParametersObjects._singleton._protivogas == false)
        {
            SaveParametersObjects._singleton._playerHealth -= 10;
            _timer = _timeDamage;
        }
    }
}
