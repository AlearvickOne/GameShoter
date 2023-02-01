using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonsActiveWeaponInPlayer : AwakeMonoBehaviour
{
    [SerializeField] protected internal GameObject _weaponFolderInPlayer;
    [Space(10)]
    [SerializeField] private List<GameObject> _weaponsArray;
    [SerializeField] protected internal List<bool> _weaponIsSelect;
    private SelectionAmmoIsGround _selectionAmmoIsGround;
    [Header("Text GUI")]
    [SerializeField] private TMP_Text _ammoQuantityText;

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
        ParametersActivate(KeyCode.Alpha1, _weaponIsSelect[0],0);
        ParametersActivate(KeyCode.Alpha2, _weaponIsSelect[1], 1);
        ParametersActivate(KeyCode.Alpha3, _weaponIsSelect[2], 2);

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
                        AssigningAmmoToText(_selectionAmmoIsGround._pistoletQuantity);
                        break;
                    case 1:
                        AssigningAmmoToText(_selectionAmmoIsGround._automatQuantity);
                        break;
                    case 2:
                        AssigningAmmoToText(_selectionAmmoIsGround._racketinicaQuantity);
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
