using UnityEngine;

public class KomplexLightAcive : MonoBehaviour
{
    [SerializeField] BoxCollider _playerColl;
    [SerializeField] GameObject _allLightKomplex;
    [SerializeField] bool _transformatorIsActive;

    private void Start()
    {
        ActiveLightKomplex(false, false);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.LogError(other);
        if (Input.GetKey(KeyboardList._singleton._keyActivity) && other == _playerColl)
            ActiveLightKomplex(false, true);
    }

    void ActiveLightKomplex(bool isActive, bool setActivaterd)
    {
        if (_transformatorIsActive == isActive)
            _allLightKomplex.SetActive(setActivaterd);
    }
}
