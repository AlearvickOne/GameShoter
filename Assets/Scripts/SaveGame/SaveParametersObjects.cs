using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveParametersObjects : AwakeMonoBehaviour
{
    #region [SINGLETON ADD]

    public static SaveParametersObjects _singleton;

    private void SingletonActive()
    {
        _singleton = this;

        if (_singleton == null)
        {
            _singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (_singleton != this)
        {
            Destroy(this.gameObject);
        }
    }

    #endregion
    [Header("SceneIndex")]
    [SerializeField] protected internal int _sceneIndex;
    [SerializeField] protected internal bool _newGameIsPlaying;
    [Header("Player Parameters")]
    [SerializeField] protected internal BoxCollider _playerColl;
    [SerializeField] protected internal static float _playerHealth;
    [Header("Weapons is Selected?")]
    [SerializeField] protected internal static bool _wpnPistoletIsSelected;
    [SerializeField] protected internal static bool _wpnAutomatIsSelected;
    [SerializeField] protected internal static bool _wpnRacketnicaIsSelected;
    [Header("Ammo bullets quantity in weapon shop")]
    [SerializeField] protected internal static int _pistoletAmmoQuantity;
    [SerializeField] protected internal static int _automatAmmoQuantity;
    [SerializeField] protected internal static int _racketnicaAmmoQuantity;
    [Header("Medicaments Parameters")]
    [SerializeField] protected internal static int _quantityBints;
    [SerializeField] protected internal static int _quantityAnalgesic;
    [SerializeField] protected internal static int _quantityMedKit;
    [Header("KeysDoors")]
    [SerializeField] protected internal static bool _greenKey;
    [SerializeField] protected internal static bool _redKey;
    [SerializeField] protected internal static bool _blueKey;
    [SerializeField] protected internal static bool _protivogas;

    [System.Serializable]
    public struct SavingStruct
    {
        // SceneIndex.
        public bool newGameIsPlaying;
        public int sceneIndex;
        // Player.
        public float playerHealth;
        // Weapons.
        public bool wpnPistoletIsSelected;
        public bool wpnAutomatIsSelected;
        public bool wpnRacketnicaIsSelected;
        // Weapon Ammo.
        public int pistoletAmmoQuantity;
        public int automatAmmoQuantity;
        public int racketnicaAmmoQuantity;
        // Medicaments
        public int quantityBints;
        public int quantityAnalgesic;
        public int quantityMedKit;
        //Keys Doors
        public bool _greenKey;
        public bool _redKey;
        public bool _blueKey;
        //Inventory
        public bool _protivogas;

    }

    private SavingStruct[] _savingStruct;

    private void Awake()
    {
        _savingStruct = new SavingStruct[1];
        SingletonActive();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6) && _playerHealth > 0)
            CreateAndSavingSaveFile();
        if (Input.GetKeyDown(KeyCode.F7))
            LoadSaveFile();

        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            _sceneIndex = SceneManager.sceneCount;
            _newGameIsPlaying = true;
        }
    }

    private string FileSave
    {
        get { return $"{Application.persistentDataPath} /Save.box"; }
    }

    protected internal void DestroySaveFile()
    {
        File.Delete(FileSave);
    }

    private void CreateAndSavingSaveFile()
    {
        BinaryFormatter binFor = new BinaryFormatter();
        FileStream file = File.Create(FileSave);
        SaveParameters();
        binFor.Serialize(file, _savingStruct[0]);
        file.Close();
        Debug.Log("SAve");
    }

    protected internal void LoadSaveFile()
    {
        if (File.Exists(FileSave))
        {
            BinaryFormatter binFor = new BinaryFormatter();
            FileStream file = File.Open(FileSave, FileMode.Open);
            _savingStruct[0] = (SavingStruct)binFor.Deserialize(file);
            file.Close();
            LoadParameters();
            Debug.Log("Load");
        }
        else if (File.Exists(FileSave))
            return;
    }

    private void SaveParameters()
    {
        _savingStruct[0].newGameIsPlaying = _newGameIsPlaying;
        _savingStruct[0].sceneIndex = _sceneIndex;
        _savingStruct[0].playerHealth = _playerHealth;
        _savingStruct[0].pistoletAmmoQuantity = _pistoletAmmoQuantity;
        _savingStruct[0].automatAmmoQuantity = _automatAmmoQuantity;
        _savingStruct[0].racketnicaAmmoQuantity = _racketnicaAmmoQuantity;
        _savingStruct[0].wpnPistoletIsSelected = _wpnPistoletIsSelected;
        _savingStruct[0].wpnAutomatIsSelected = _wpnAutomatIsSelected;
        _savingStruct[0].wpnRacketnicaIsSelected = _wpnRacketnicaIsSelected;
        _savingStruct[0].quantityBints = _quantityBints;
        _savingStruct[0].quantityAnalgesic = _quantityAnalgesic;
        _savingStruct[0].quantityMedKit = _quantityMedKit;
        _savingStruct[0]._blueKey = _blueKey;
        _savingStruct[0]._redKey = _redKey;
        _savingStruct[0]._greenKey = _greenKey;
        _savingStruct[0]._protivogas = _protivogas;

    }

    private void LoadParameters()
    {
        _newGameIsPlaying = _savingStruct[0].newGameIsPlaying;
        _sceneIndex = _savingStruct[0].sceneIndex;
        _playerHealth = _savingStruct[0].playerHealth;
        _pistoletAmmoQuantity = _savingStruct[0].pistoletAmmoQuantity;
        _automatAmmoQuantity = _savingStruct[0].automatAmmoQuantity;
        _racketnicaAmmoQuantity = _savingStruct[0].racketnicaAmmoQuantity;
        _wpnPistoletIsSelected = _savingStruct[0].wpnPistoletIsSelected;
        _wpnAutomatIsSelected = _savingStruct[0].wpnAutomatIsSelected;
        _wpnRacketnicaIsSelected = _savingStruct[0].wpnRacketnicaIsSelected;
        _quantityBints = _savingStruct[0].quantityBints;
        _quantityAnalgesic = _savingStruct[0].quantityAnalgesic;
        _quantityMedKit = _savingStruct[0].quantityMedKit;
        _blueKey = _savingStruct[0]._blueKey;
        _redKey = _savingStruct[0]._redKey;
        _greenKey = _savingStruct[0]._greenKey;
        _protivogas = _savingStruct[0]._protivogas;
    }

}
