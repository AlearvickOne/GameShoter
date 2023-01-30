using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsActiveWeaponInPlayer : AwakeMonoBehaviour
{
    [SerializeField] protected internal GameObject _weaponFolderInPlayer;
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
    }

    private void ParametersActivate(KeyCode nomberKeypad, bool weaponSelect, int arrayNomberWeapon)
    {
        if (Input.GetKeyDown(nomberKeypad) && weaponSelect == true)
        {
            if(_weaponsArray[arrayNomberWeapon].activeSelf == true)
                _weaponsArray[arrayNomberWeapon].SetActive(false);
            else
                _weaponsArray[arrayNomberWeapon].SetActive(true);

            for (int i = 0; i < _weaponsArray.Count; i++)
            {
                if (i == arrayNomberWeapon)
                    continue;
                if (_weaponsArray[i].activeSelf == true)
                    _weaponsArray[i].SetActive(false);
            }
        }    
    }
}
