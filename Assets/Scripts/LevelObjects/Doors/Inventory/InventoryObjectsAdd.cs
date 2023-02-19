using UnityEngine;

public class InventoryObjectsAdd : MonoBehaviour
{
    private enum InventoryObjectsType { protivogas }

    [SerializeField] private InventoryObjectsType _invObjType;
    private BoxCollider _playerColl;

    private void Start()
    {
        _playerColl = SaveParametersObjects._singleton._playerColl;
    }

    private void OnTriggerEnter(Collider other)
    {
        InventoryObjectAddParameters(other, InventoryObjectsType.protivogas);
    }

    private void InventoryObjectAddParameters(Collider other, InventoryObjectsType invObjType)
    {
        if (other == _playerColl && _invObjType == invObjType)
        {
            InventoryObjectAdd(invObjType);
        }

    }

    private void InventoryObjectAdd(InventoryObjectsType invObjType)
    {
        switch (invObjType)
        {
            case InventoryObjectsType.protivogas:
                SaveParametersObjects._protivogas = true;
                break;
        }
        Destroy(this.gameObject, 0.3f);
    }
}
