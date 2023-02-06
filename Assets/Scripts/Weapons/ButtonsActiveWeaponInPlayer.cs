using System.Collections.Generic;
using TMPro;
using UnityEngine;
/// <summary>
/// Responsible for activating the player's weapon when pressing the keys, if it is in the inventory.
/// </summary>
public class ButtonsActiveWeaponInPlayer : AwakeMonoBehaviour
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private TMP_Text _ammoQuantityText;
    [SerializeField] protected internal GameObject _weaponFolderInPlayer;
    [Header("                             SCRIPTS")]
    [Space(10)]
    private SelectionAmmoIsGround _selectionAmmoIsGround;
    [Header("                             ARRAYS")]
    [Space(10)]
    [SerializeField] private List<GameObject> _weaponsArray;
    [SerializeField] protected internal List<bool> _weaponIsSelect;

    private void Start()
    {
        StartFindWeapon();
    }

    private void Update()
    {
        ActivateWeaponButton();
    }

    private void StartFindWeapon()
    {
        _selectionAmmoIsGround = GetComponent<SelectionAmmoIsGround>();
        foreach (Transform child in _weaponFolderInPlayer.transform)
        {
            _weaponsArray.Add(child.gameObject);
            _weaponIsSelect.Add(false);
        }
    }

    private void ActivateWeaponButton()
    {
        int wpnPistolet = 0;
        int wpnAutomat = 1;
        int wpnRacketnica = 2;

        ParametersActivate(KeyCode.Alpha1, SaveSceneParametersObjects._singleton._wpnPistoletIsSelected, wpnPistolet);
        ParametersActivate(KeyCode.Alpha2, SaveSceneParametersObjects._singleton._wpnAutomatIsSelected, wpnAutomat);
        ParametersActivate(KeyCode.Alpha3, SaveSceneParametersObjects._singleton._wpnRacketnicaIsSelected, wpnRacketnica);

        AmmoTextToGUI();
    }

    private void ParametersActivate(KeyCode nomberKeypad, bool weaponSelect, int arrayNomberWeapon)
    {
        if (Input.GetKeyDown(nomberKeypad) && weaponSelect == true)
        {
            if(_weaponsArray[arrayNomberWeapon].activeSelf == true)
            {
                _weaponsArray[arrayNomberWeapon].SetActive(false);
                _ammoQuantityText.text = "";
            }
            else
            {
                _weaponsArray[arrayNomberWeapon].SetActive(true);

            }

            for (int i = 0; i < _weaponsArray.Count; i++)
            {
                if (i == arrayNomberWeapon)
                    continue;
                if (_weaponsArray[i].activeSelf == true)
                    _weaponsArray[i].SetActive(false);
            }
        }    
    }

    #region [GUI TEXT AMMO WEAPONS QUANTITY]
    private void AmmoTextToGUI()
    {
        for (int i = 0; i < _weaponsArray.Count; i++)
        {
            if(_weaponsArray[i].activeSelf == true)
            {
                switch (i)
                {
                    case 0:
                        AssigningAmmoToText(SaveSceneParametersObjects._singleton._pistoletAmmoQuantity);
                        break;
                    case 1:
                        AssigningAmmoToText(SaveSceneParametersObjects._singleton._automatAmmoQuantity);
                        break;
                    case 2:
                        AssigningAmmoToText(SaveSceneParametersObjects._singleton._racketnicaAmmoQuantity);
                        break;
                }
            }
        }
    }

    private void AssigningAmmoToText(int nameWeaponQuantity)
    {
        Debug.Log("LOADED");
        _ammoQuantityText.text = nameWeaponQuantity.ToString();
    }

    #endregion
}
