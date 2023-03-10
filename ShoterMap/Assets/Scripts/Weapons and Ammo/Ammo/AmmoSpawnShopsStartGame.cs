using UnityEngine;
/// <summary>
/// Creating bullet magazines at the beginning of the game for later use.
/// </summary>
public class AmmoSpawnShopsStartGame : StructsSave
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject[] _ammoShops;

    private void Start()
    {
        StartSpawnAmmoShops();
    }

    private void StartSpawnAmmoShops()
    {
        _ammoShopsStructs = new AmmoShopsStruct[20];
        for (int i = 0; i < _ammoShopsStructs.Length; i++)
        {
            int indexSpawn = Random.Range(0, _ammoShops.Length);
            GameObject newSpawn = Instantiate(_ammoShops[indexSpawn], transform.position, Quaternion.identity);
            newSpawn.transform.parent = transform;
            _ammoShopsStructs[i].ammoShop = newSpawn.transform;
            _ammoShopsStructs[i].ammoShopColl = newSpawn.GetComponent<BoxCollider>();

            switch (indexSpawn)
            {
                case 0:
                    AmmoShopsSpawnType(i, AmmoType.ammoPistolet);
                    break;
                case 1:
                    AmmoShopsSpawnType(i, AmmoType.ammoAutomat);
                    break;
                case 2:
                    AmmoShopsSpawnType(i, AmmoType.ammoRacketnica);
                    break;
            }

            newSpawn.SetActive(false);
        }
    }

    private void AmmoShopsSpawnType(int i, AmmoType ammoType)
    {
        _ammoShopsStructs[i].ammoShopType = ammoType;
    }
}
