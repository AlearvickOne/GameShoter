using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryObjectsActive : MonoBehaviour
{
    [SerializeField] GameObject _protivogas;

    void Update()
    {
        InventoryObjectsActive(SaveParametersObjects._singleton._protivogas);
    }

    void InventoryObjectsActive(bool invObjIsActive)
    {
        if(invObjIsActive == true)
            _protivogas.SetActive(true);
        else if (invObjIsActive == false)
            _protivogas.SetActive(false);
    }
}
