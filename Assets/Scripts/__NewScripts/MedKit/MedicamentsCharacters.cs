using UnityEngine;

public class MedicamentsCharacters : StructsSave
{
    [SerializeField] private BoxCollider _playerColl;
    private int _medIndex;

    private void Start()
    {
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
                _playerColl = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
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
                    SaveParametersObjects._singleton._quantityBints += 1;
                    break;
                case MedicamentsType.analgesic:
                    SaveParametersObjects._singleton._quantityAnalgesic += 1;
                    break;
                case MedicamentsType.medkit:
                    SaveParametersObjects._singleton._quantityMedKit += 1;
                    break;
            }

            this.gameObject.SetActive(false);
        }
    }

}
