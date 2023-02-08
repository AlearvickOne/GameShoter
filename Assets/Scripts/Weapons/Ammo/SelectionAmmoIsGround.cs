using UnityEngine;
/// <summary>
/// Responsible for the selection of bullet magazines in contact with the player 
/// and their subsequent distribution by weapon.
/// </summary>
public class SelectionAmmoIsGround : StructsSave
{
    [Header("                             ARRAYS")]
    [Space(10)]
    [SerializeField] private Weapons[] _weaponsScripts;

    private void OnTriggerStay(Collider other)
    {
        AmmoAdding(other);
    }

    private void AmmoAdding(Collider other)
    {
        for (int i = 0; i < _ammoShopsStructs.Length; i++)
        {
            if (_ammoShopsStructs[i].ammoShopColl == other)
            {
                switch (_ammoShopsStructs[i].ammoShopType)
                {
                    case AmmoType.ammoPistolet:
                        SaveSceneParametersObjects._singleton._pistoletAmmoQuantity += RandomQuantity(i, 10, 15);
                        break;
                    case AmmoType.ammoAutomat:
                         SaveSceneParametersObjects._singleton._automatAmmoQuantity += RandomQuantity(i, 30, 50);
                        break;
                    case AmmoType.ammoRacketnica:
                        SaveSceneParametersObjects._singleton._racketnicaAmmoQuantity += RandomQuantity(i, 30, 50);
                        break;
                }
            }
        }
    }

    private int RandomQuantity(int i, int minAmmoRandom, int MaxAmmoRandom)
    {
        int ammoQuantity = Random.Range(minAmmoRandom, MaxAmmoRandom);
        _ammoShopsStructs[i].ammoShop.gameObject.SetActive(false);
        return ammoQuantity;
    }
}
