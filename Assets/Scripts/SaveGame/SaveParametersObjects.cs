using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

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

    [Header("Player Parameters")]
    [SerializeField] protected internal float _playerHealth;
    [Header("Weapons is Selected?")]
    [SerializeField] protected internal bool _wpnPistoletIsSelected;
    [SerializeField] protected internal bool _wpnAutomatIsSelected;
    [SerializeField] protected internal bool _wpnRacketnicaIsSelected;
    [Header("Ammo bullets quantity in weapon shop")]
    [SerializeField] protected internal int _pistoletAmmoQuantity;
    [SerializeField] protected internal int _automatAmmoQuantity;
    [SerializeField] protected internal int _racketnicaAmmoQuantity;
    [Header("Medicaments Parameters")]
    [SerializeField] protected internal int _quantityBints;
    [SerializeField] protected internal int _quantityAnalgesic;
    [SerializeField] protected internal int _quantityMedKit;
    [Header("KeysDoors")]
    [SerializeField] protected internal bool _greenKey;
    [SerializeField] protected internal bool _redKey;
    [SerializeField] protected internal bool _blueKey;
    [SerializeField] protected internal bool _protivogas;

    [System.Serializable]
    public struct MyStruct
    {
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

    private MyStruct[] saveStruct;

    [Multiline]
    public string _saveToJson;

    private void Awake()
    {
        saveStruct = new MyStruct[1];
        SingletonActive();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F6) && _playerHealth > 0)
            CreateAndSavingSaveFile();
        if (Input.GetKeyDown(KeyCode.F7))
            LoadSaveFile();
    }

    private void CreateAndSavingSaveFile()
    {
        BinaryFormatter binFor = new BinaryFormatter();
        FileStream file = File.Create($"{Application.persistentDataPath} /Save.box");
        SaveParameters();
        binFor.Serialize(file, saveStruct[0]);
        file.Close();
        Debug.Log("SAve");
    }

    private void LoadSaveFile()
    {
        if (File.Exists($"{Application.persistentDataPath} /Save.box"))
        {
            BinaryFormatter binFor = new BinaryFormatter();
            FileStream file = File.Open($"{Application.persistentDataPath} /Save.box", FileMode.Open);
            saveStruct[0] = (MyStruct)binFor.Deserialize(file);
            file.Close();
            LoadParameters(); 
            Debug.Log("Load");
        }
        else
            Debug.Log("NotSaveFile");
    }

    private void SaveParameters()
    {
        saveStruct[0].playerHealth = _playerHealth;
        saveStruct[0].pistoletAmmoQuantity = _pistoletAmmoQuantity;
        saveStruct[0].automatAmmoQuantity = _automatAmmoQuantity;
        saveStruct[0].racketnicaAmmoQuantity = _racketnicaAmmoQuantity;
        saveStruct[0].wpnPistoletIsSelected = _wpnPistoletIsSelected;
        saveStruct[0].wpnAutomatIsSelected = _wpnAutomatIsSelected;
        saveStruct[0].wpnRacketnicaIsSelected = _wpnRacketnicaIsSelected;
        saveStruct[0].quantityBints = _quantityBints;
        saveStruct[0].quantityAnalgesic = _quantityAnalgesic;
        saveStruct[0].quantityMedKit = _quantityMedKit;
        saveStruct[0]._blueKey = _blueKey;
        saveStruct[0]._redKey = _redKey;
        saveStruct[0]._greenKey = _greenKey;
        saveStruct[0]._protivogas = _protivogas;

    }

    private void LoadParameters()
    {
        _playerHealth = saveStruct[0].playerHealth;
        _pistoletAmmoQuantity = saveStruct[0].pistoletAmmoQuantity;
        _automatAmmoQuantity = saveStruct[0].automatAmmoQuantity;
        _racketnicaAmmoQuantity = saveStruct[0].racketnicaAmmoQuantity;
        _wpnPistoletIsSelected = saveStruct[0].wpnPistoletIsSelected;
        _wpnAutomatIsSelected = saveStruct[0].wpnAutomatIsSelected;
        _wpnRacketnicaIsSelected = saveStruct[0].wpnRacketnicaIsSelected;
        _quantityBints = saveStruct[0].quantityBints;
        _quantityAnalgesic = saveStruct[0].quantityAnalgesic;
        _quantityMedKit = saveStruct[0].quantityMedKit;
        _blueKey = saveStruct[0]._blueKey;
        _redKey = saveStruct[0]._redKey;
        _greenKey = saveStruct[0]._greenKey;
        _protivogas = saveStruct[0]._protivogas;
    }

}
