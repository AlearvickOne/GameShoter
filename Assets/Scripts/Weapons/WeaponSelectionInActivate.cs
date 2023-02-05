using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Picking up weapons from the ground and transferring them to inventory.
/// </summary>

public class WeaponSelectionInActivate : AwakeMonoBehaviour
{
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private ButtonsActiveWeaponInPlayer _buttonsActiveWeaponInPlayer;
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Transform _weaponLevelFolder;
    [Header("                             ARRAYS")]
    [Space(10)]
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
