using UnityEngine;

/// <summary>
/// Creating bullets at the beginning of the game for their subsequent use.
/// </summary>
public class AmmoSpawnStart : StructsSave
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private GameObject[] bullets;
    [SerializeField] private Transform[] ammoBandoliers;
    [Header("                             PARAMETERS")]
    [Space(10)]
    [SerializeField] private int spawnPistoletAmmoQuantity;
    [SerializeField] private int spawnAutomatAmmoQuantity;
    [SerializeField] private int spawnRacketnicaAmmoQuantity;

    private void Awake()
    {
        int ammoSum1 = spawnAutomatAmmoQuantity + spawnPistoletAmmoQuantity;
        int ammoSum2 = ammoSum1 + spawnRacketnicaAmmoQuantity;
        int allAmmoSpawn = ammoSum2;

        _weaponsAmmoStructs = new WeaponsAmmoStruct[allAmmoSpawn];
        SpawnAmmo();
    }

    private void SpawnAmmo()
    {
        int pistolet = 0;
        int automat = 1;
        int racketnica = 2;

        int ammoSum1 = spawnAutomatAmmoQuantity + spawnPistoletAmmoQuantity;
        int ammoSum2 = ammoSum1 + spawnRacketnicaAmmoQuantity;

        for (int i = 0; i < spawnPistoletAmmoQuantity; i++)
        {
            Spawn(i, pistolet, AmmoType.ammoPistolet);
        }
        for (int i = 0; i < ammoSum1; i++)
        {
            Spawn(i, automat, AmmoType.ammoAutomat);
        }
        for (int i = 0; i < ammoSum2; i++)
        {
            Spawn(i, racketnica, AmmoType.ammoRacketnica);
        }
    }

    private void Spawn(int i, int indexWeapon, AmmoType ammoType)
    {
        if (_weaponsAmmoStructs[i].isFull == false)
        {
            GameObject newSpawn = Instantiate(bullets[indexWeapon], ammoBandoliers[indexWeapon].position, Quaternion.identity);
            newSpawn.transform.parent = ammoBandoliers[indexWeapon];
            _weaponsAmmoStructs[i].bullet = newSpawn.gameObject;
            _weaponsAmmoStructs[i].bulletColl = newSpawn.GetComponent<BoxCollider>();
            _weaponsAmmoStructs[i].ammoType = ammoType;
            _weaponsAmmoStructs[i].bullet.SetActive(false);
            _weaponsAmmoStructs[i].isFull = true;
        }
    }
}
