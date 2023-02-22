using UnityEngine;

public class PlayerInventoryObjectsActive : AwakeMonoBehaviour
{
    [SerializeField] private GameObject _protivogas;

    private void Update()
    {
        InventoryObjectsActive(SaveParametersObjects._protivogas);
    }

    private void InventoryObjectsActive(bool invObjIsActive)
    {
        if (invObjIsActive == true)
            _protivogas.SetActive(true);
        else if (invObjIsActive == false)
            _protivogas.SetActive(false);
    }
}
