using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MedicamentsActInUI : StructsSave
{
    [SerializeField] GameObject _BintUI;
    [SerializeField] GameObject _analgesicUI;
    [SerializeField] GameObject _medKitUI;

    [SerializeField] TMP_Text _quantityBintsString;
    protected internal static int _quantityBints;
    [SerializeField] TMP_Text _quantityAnalgesicsString;
    protected internal static int _quantityAnalgesic;
    [SerializeField] TMP_Text _quantityMedKitsString;
    protected internal static int _quantityMedKit;

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
        ActiveComponentsInUi(_quantityBints, _BintUI, _quantityBintsString);
        ActiveComponentsInUi(_quantityAnalgesic, _analgesicUI, _quantityAnalgesicsString);
        ActiveComponentsInUi(_quantityMedKit, _medKitUI, _quantityMedKitsString);
        ActiveMedicamentsAndHealtPlayer(KeyboardList._actBint, MedicamentsType.bint, _quantityBints);
        ActiveMedicamentsAndHealtPlayer(KeyboardList._actAnalgesic, MedicamentsType.analgesic, _quantityAnalgesic);
        ActiveMedicamentsAndHealtPlayer(KeyboardList._actMedkit, MedicamentsType.medkit, _quantityMedKit);
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
                SaveSceneParametersObjects._singleton._playerHealth += _medicamentStructs[i].plusHpQuantity;

                if (_medicamentStructs[i].medType == MedicamentsType.bint)
                {
                    _quantityBints--;
                }
                else if (_medicamentStructs[i].medType == MedicamentsType.analgesic)
                {
                    _quantityAnalgesic--;
                }
                else if (_medicamentStructs[i].medType == MedicamentsType.medkit)
                {
                    _quantityMedKit--;
                }
                break;
            }
        }
    }
}
