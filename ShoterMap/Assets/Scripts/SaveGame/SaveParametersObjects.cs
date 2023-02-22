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
    [SerializeField] private Texture2D _cursorTexture;

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
    [Header("LevelLights")]
    [SerializeField] protected internal static bool _transformatorIsLight;
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
        // Level Lights.
        public bool _transformatorIsLight;

    }

    private SavingStruct[] _savingStruct;

    private void Awake()
    {
        _savingStruct = new SavingStruct[1];
        SingletonActive();
    }

    private void Update()
    {
        if (_playerHealth <= 0 && SceneManager.GetActiveScene().buildIndex != 0)
        {
            LoadSaveFile();
            SceneManager.LoadScene(_sceneIndex);
        }

        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            _sceneIndex = SceneManager.GetActiveScene().buildIndex;
            _newGameIsPlaying = true;
            Cursor.SetCursor(_cursorTexture, Vector2.zero, CursorMode.Auto);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0) { Cursor.SetCursor(default, Vector2.zero, CursorMode.Auto); }
    }

    private string FileSave
    {
        get { return $"{Application.persistentDataPath} /Save.box"; }
    }

    protected internal void DestroySaveFile()
    {
        File.Delete(FileSave);
        _playerHealth = 1000;
        _pistoletAmmoQuantity = 0;
        _automatAmmoQuantity = 0;
        _racketnicaAmmoQuantity = 0;
        _wpnPistoletIsSelected = false;
        _wpnAutomatIsSelected = false;
        _wpnRacketnicaIsSelected = false;
        _quantityBints = 0;
        _quantityAnalgesic = 0;
        _quantityMedKit = 0;
        _blueKey = false;
        _redKey = false;
        _greenKey = false;
        _protivogas = false;
        _transformatorIsLight = false;

    }

    protected internal void CreateAndSavingSaveFile()
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
        // SceneIndex.
        _savingStruct[0].newGameIsPlaying = _newGameIsPlaying;
        _savingStruct[0].sceneIndex = _sceneIndex;
        // Player.
        _savingStruct[0].playerHealth = _playerHealth;
        // Weapon Ammo.
        _savingStruct[0].pistoletAmmoQuantity = _pistoletAmmoQuantity;
        _savingStruct[0].automatAmmoQuantity = _automatAmmoQuantity;
        _savingStruct[0].racketnicaAmmoQuantity = _racketnicaAmmoQuantity;
        // Weapons.
        _savingStruct[0].wpnPistoletIsSelected = _wpnPistoletIsSelected;
        _savingStruct[0].wpnAutomatIsSelected = _wpnAutomatIsSelected;
        _savingStruct[0].wpnRacketnicaIsSelected = _wpnRacketnicaIsSelected;
        // Medicaments.
        _savingStruct[0].quantityBints = _quantityBints;
        _savingStruct[0].quantityAnalgesic = _quantityAnalgesic;
        _savingStruct[0].quantityMedKit = _quantityMedKit;
        // Keys Doors.
        _savingStruct[0]._blueKey = _blueKey;
        _savingStruct[0]._redKey = _redKey;
        _savingStruct[0]._greenKey = _greenKey;
        // Imventory.
        _savingStruct[0]._protivogas = _protivogas;
        // Level Lights.
        _savingStruct[0]._transformatorIsLight = _transformatorIsLight;
    }

    private void LoadParameters()
    {
        // SceneIndex.
        _newGameIsPlaying = _savingStruct[0].newGameIsPlaying;
        _sceneIndex = _savingStruct[0].sceneIndex;
        // Player.
        _playerHealth = _savingStruct[0].playerHealth;
        // Weapon Ammo.
        _pistoletAmmoQuantity = _savingStruct[0].pistoletAmmoQuantity;
        _automatAmmoQuantity = _savingStruct[0].automatAmmoQuantity;
        _racketnicaAmmoQuantity = _savingStruct[0].racketnicaAmmoQuantity;
        // Weapons.
        _wpnPistoletIsSelected = _savingStruct[0].wpnPistoletIsSelected;
        _wpnAutomatIsSelected = _savingStruct[0].wpnAutomatIsSelected;
        _wpnRacketnicaIsSelected = _savingStruct[0].wpnRacketnicaIsSelected;
        // Medicaments.
        _quantityBints = _savingStruct[0].quantityBints;
        _quantityAnalgesic = _savingStruct[0].quantityAnalgesic;
        _quantityMedKit = _savingStruct[0].quantityMedKit;
        // Keys Doors.
        _blueKey = _savingStruct[0]._blueKey;
        _redKey = _savingStruct[0]._redKey;
        _greenKey = _savingStruct[0]._greenKey;
        // Imventory.
        _protivogas = _savingStruct[0]._protivogas;
        // Level Lights.
        _transformatorIsLight = _savingStruct[0]._transformatorIsLight;
    }

}
