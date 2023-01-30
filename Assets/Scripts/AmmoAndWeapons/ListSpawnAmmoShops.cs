using UnityEngine;

public class ListSpawnAmmoShops : AwakeMonoBehaviour
{
    [SerializeField] private GameObject[] _ammoShops;
    [Space(10)]
    protected internal AmmoShopsStruct[] _ammoShopsStruct;

    void Start()
    {
        StartSpawnAmmoShops();
    }

    void StartSpawnAmmoShops()
    {
        _ammoShopsStruct = new AmmoShopsStruct[20];
        for (int i = 0; i < _ammoShopsStruct.Length; i++)
        {
            int indexSpawn = Random.Range(0, _ammoShops.Length);
            GameObject newSpawn = Instantiate(_ammoShops[indexSpawn], transform.position, Quaternion.identity);
            newSpawn.transform.parent = transform;
            _ammoShopsStruct[i].ammoShop = newSpawn.transform;
            _ammoShopsStruct[i].ammoShopColl = newSpawn.GetComponent<BoxCollider>();

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

    void AmmoShopsSpawnType(int i ,AmmoType ammoType)
    {
        _ammoShopsStruct[i].ammoShopType = ammoType;
    }
}
