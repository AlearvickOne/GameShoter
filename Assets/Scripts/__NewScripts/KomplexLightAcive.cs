using UnityEngine;

public class KomplexLightAcive : MonoBehaviour
{
    private BoxCollider _playerColl;
    [SerializeField] private GameObject _allLightKomplex;
    [SerializeField] private bool _transformatorIsActive = false;

    private void Start()
    {
        _playerColl = SaveParametersObjects._singleton._playerColl;
        ActiveLightKomplex(false);
    }

    private void ActiveButtonVisibleToUi(Collider other, bool isActive)
    {
        if (other == _playerColl && _transformatorIsActive == false)
            KeyboardList._singleton._keyActivatedSpriteUI.gameObject.SetActive(isActive);
        if (other == _playerColl && _transformatorIsActive == true)
            KeyboardList._singleton._keyActivatedSpriteUI.gameObject.SetActive(false);
    }

    private void ActiveLightKomplex(bool setActivaterd)
    {
        if (_transformatorIsActive == false)
        {
            _allLightKomplex.SetActive(setActivaterd);

        }
        if (_allLightKomplex.activeSelf == true)
        {
            _transformatorIsActive = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ActiveButtonVisibleToUi(other, true);

        if (Input.GetKey(KeyboardList._keyActivity) && other == _playerColl)
        {
            ActiveLightKomplex(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ActiveButtonVisibleToUi(other, false);
    }


}
