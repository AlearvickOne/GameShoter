using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectionInActivate : AwakeMonoBehaviour
{
    [SerializeField] private ButtonsActiveWeaponInPlayer _buttonsActiveWeaponInPlayer;
    [SerializeField] private Transform _weaponLevelFolder;
    [SerializeField] private List<BoxCollider> _weaponsLevelColliders;

    private void Start()
    {
        if (_buttonsActiveWeaponInPlayer._weaponFolderInPlayer.transform != null)
        {
            foreach (Transform childColl in _weaponLevelFolder)
            {
                _weaponsLevelColliders.Add(childColl.GetComponent<BoxCollider>());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i = 0; i < _weaponsLevelColliders.Count; i++)
        {
            switch (i)
            {
                case 0:
                case 1:
                case 2:

                    if (other == _weaponsLevelColliders[i])
                    {
                        _buttonsActiveWeaponInPlayer._weaponIsSelect[i] = true;
                        Destroy(_weaponsLevelColliders[i].gameObject);
                    }

                    break;
            }
        }
    }
}
