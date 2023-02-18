using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObjectsAdd : MonoBehaviour
{
    enum InventoryObjectsType { protivogas }

    [SerializeField] InventoryObjectsType _invObjType;
    [SerializeField] BoxCollider _playerColl;


    private void OnTriggerEnter(Collider other)
    {
        InventoryObjectAddParameters(other, InventoryObjectsType.protivogas);
    }

    void InventoryObjectAddParameters(Collider other, InventoryObjectsType invObjType)
    {
        if (other == _playerColl && _invObjType == invObjType)
        {
            InventoryObjectAdd(invObjType);
        }

    }

    void InventoryObjectAdd(InventoryObjectsType invObjType)
    {
        switch (invObjType)
        {
            case InventoryObjectsType.protivogas:
                SaveParametersObjects._singleton._protivogas = true;
                break;
        }
        Destroy(this.gameObject, 0.3f);
    }
}
