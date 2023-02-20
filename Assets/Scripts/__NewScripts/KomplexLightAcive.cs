using UnityEngine;

public class KomplexLightAcive : MonoBehaviour
{
    private BoxCollider _playerColl;
    [SerializeField] private GameObject _allLightKomplex;

    private void Start()
    {
        _playerColl = SaveParametersObjects._singleton._playerColl;
        ActiveLightKomplex(false);
    }

    private void ActiveButtonVisibleToUi(Collider other, bool isActive)
    {
        if (other == _playerColl && SaveParametersObjects._transformatorIsLight == false)
            KeyboardList._singleton._keyActivatedSpriteUI.gameObject.SetActive(isActive);
        if (other == _playerColl && SaveParametersObjects._transformatorIsLight == true)
            KeyboardList._singleton._keyActivatedSpriteUI.gameObject.SetActive(false);
    }

    private void ActiveLightKomplex(bool setActivaterd)
    {
        if (SaveParametersObjects._transformatorIsLight == false)
        {
            _allLightKomplex.SetActive(setActivaterd);

        }
        if (_allLightKomplex.activeSelf == true)
        {
            SaveParametersObjects._transformatorIsLight = true;
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
