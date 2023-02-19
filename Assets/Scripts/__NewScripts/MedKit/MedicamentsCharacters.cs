using UnityEngine;

public class MedicamentsCharacters : StructsSave
{
    private BoxCollider _playerColl;
    private int _medIndex;

    private void Start()
    {
        _playerColl = SaveParametersObjects._singleton._playerColl;
        FindComponents();
    }

    private void FindComponents()
    {
        for (int i = 0; i < _medicamentStructs.Length; i++)
        {
            if (this.gameObject == _medicamentStructs[i].medGo)
            {
                Debug.Log(i);
                _medIndex = i;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == _playerColl && this.gameObject.activeSelf == true)
        {
            switch (_medicamentStructs[_medIndex].medType)
            {
                case MedicamentsType.bint:
                    SaveParametersObjects._quantityBints += 1;
                    break;
                case MedicamentsType.analgesic:
                    SaveParametersObjects._quantityAnalgesic += 1;
                    break;
                case MedicamentsType.medkit:
                    SaveParametersObjects._quantityMedKit += 1;
                    break;
            }

            this.gameObject.SetActive(false);
        }
    }

}
