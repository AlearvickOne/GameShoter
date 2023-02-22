using UnityEngine;

public class SpawnMedicamentsToStart : StructsSave
{
    [SerializeField] private GameObject[] _spawnMedicaments;
    private Transform _objectSpawnTransform;

    private void Start()
    {
        StartSpawnMedicaments();
    }

    private void StartSpawnMedicaments()
    {
        _objectSpawnTransform = transform;
        _medicamentStructs = new MedicamentStruct[10];
        for (int i = 0; i < _medicamentStructs.Length; i++)
        {
            int medIndex = Random.Range(0, _spawnMedicaments.Length);
            GameObject newSpawn = Instantiate(_spawnMedicaments[medIndex], _objectSpawnTransform.position, Quaternion.identity);
            newSpawn.transform.parent = _objectSpawnTransform;
            _medicamentStructs[i].medGo = newSpawn;

            switch (medIndex)
            {
                case 0:
                    _medicamentStructs[i].medType = MedicamentsType.bint;
                    _medicamentStructs[i].plusHpQuantity = 50;
                    break;
                case 1:
                    _medicamentStructs[i].medType = MedicamentsType.analgesic;
                    _medicamentStructs[i].plusHpQuantity = 100;
                    break;
                case 2:
                    _medicamentStructs[i].medType = MedicamentsType.medkit;
                    _medicamentStructs[i].plusHpQuantity = 150;
                    break;
            }

            newSpawn.SetActive(false);
        }
    }
}
