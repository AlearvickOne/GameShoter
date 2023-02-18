using UnityEngine;
using TMPro;

public class MedicamentsActInUI : StructsSave
{
    [SerializeField] GameObject _BintUI;
    [SerializeField] GameObject _analgesicUI;
    [SerializeField] GameObject _medKitUI;

    [SerializeField] TMP_Text _quantityBintsString;

    [SerializeField] TMP_Text _quantityAnalgesicsString;

    [SerializeField] TMP_Text _quantityMedKitsString;


    private void Start()
    {
        FindComponents();
    }

    void FindComponents()
    {
        _quantityBintsString = _BintUI.GetComponentInChildren<TMP_Text>();
        _quantityAnalgesicsString = _analgesicUI.GetComponentInChildren<TMP_Text>();
        _quantityMedKitsString = _medKitUI.GetComponentInChildren<TMP_Text>();

    }

    private void Update()
    {
        ActiveComponentsInUi(SaveParametersObjects._singleton._quantityBints, _BintUI, _quantityBintsString);
        ActiveComponentsInUi(SaveParametersObjects._singleton._quantityAnalgesic, _analgesicUI, _quantityAnalgesicsString);
        ActiveComponentsInUi(SaveParametersObjects._singleton._quantityMedKit, _medKitUI, _quantityMedKitsString);
        ActiveMedicamentsAndHealtPlayer(KeyboardList._actBint, MedicamentsType.bint, SaveParametersObjects._singleton._quantityBints);
        ActiveMedicamentsAndHealtPlayer(KeyboardList._actAnalgesic, MedicamentsType.analgesic, SaveParametersObjects._singleton._quantityAnalgesic);
        ActiveMedicamentsAndHealtPlayer(KeyboardList._actMedkit, MedicamentsType.medkit, SaveParametersObjects._singleton._quantityMedKit);
    }

    void ActiveComponentsInUi(int quantityMed, GameObject medObject, TMP_Text quantityText)
    {
        if (quantityMed <= 0)
        {
            medObject.SetActive(false);
            quantityMed = 0;
        }
        else if (quantityMed >= 0)
            medObject.SetActive(true);

        quantityText.text = quantityMed.ToString();
    }

    void ActiveMedicamentsAndHealtPlayer(KeyCode keyCode, MedicamentsType medType, int quantityMed)
    {
        for (int i = 0; i < _medicamentStructs.Length; i++)
        {
            if (Input.GetKeyDown(keyCode) && _medicamentStructs[i].medType == medType && quantityMed > 0)
            {
                SaveParametersObjects._singleton._playerHealth += _medicamentStructs[i].plusHpQuantity;

                if (_medicamentStructs[i].medType == MedicamentsType.bint)
                    SaveParametersObjects._singleton._quantityBints--;
                else if (_medicamentStructs[i].medType == MedicamentsType.analgesic)
                    SaveParametersObjects._singleton._quantityAnalgesic--;
                else if (_medicamentStructs[i].medType == MedicamentsType.medkit)
                    SaveParametersObjects._singleton._quantityMedKit--;
                break;
            }
        }
    }
}
