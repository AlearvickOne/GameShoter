using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSceneParametersObjects : AwakeMonoBehaviour
{
    #region [SINGLETON ADD]

    public static SaveSceneParametersObjects _singleton;

    void SingletonActive()
    {
        _singleton = this;

        if (_singleton == null)
        {
            _singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (_singleton != this)
        {
            Debug.LogError("Add ");
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

    private void Awake()
    {
        SingletonActive();
        LoadParameters();
    }

    void SaveParameters()
    {
        Debug.Log("SAve");
        // Player.
        PlayerPrefs.SetFloat("PlayerHp", _playerHealth);
        // Weapons is Selected?
        PlayerPrefs.SetInt("wpnPistoletAct", _wpnPistoletIsSelected ? 1 : 0);
        PlayerPrefs.SetInt("wpnAutomatAct", _wpnAutomatIsSelected ? 1 : 0);
        PlayerPrefs.SetInt("wpnRacketnicaAct", _wpnRacketnicaIsSelected ? 1 : 0);
        // Ammo Shop Quantity.
        PlayerPrefs.SetInt("wpnPistoletAmmo", _pistoletAmmoQuantity);
        PlayerPrefs.SetInt("wpnAutomatAmmo", _automatAmmoQuantity);
        PlayerPrefs.SetInt("wpnRacketnica", _racketnicaAmmoQuantity);

        PlayerPrefs.Save();
    }

    void LoadParameters()
    {
        Debug.Log("Load");      
        // Player.
        _playerHealth = PlayerPrefs.GetFloat("PlayerHp");
        // Weapons is Selected?
        _wpnPistoletIsSelected = PlayerPrefs.GetInt("wpnPistoletAct") == 1 ? true : false;
        _wpnAutomatIsSelected = PlayerPrefs.GetInt("wpnAutomatAct") == 1 ? true : false;
        _wpnRacketnicaIsSelected = PlayerPrefs.GetInt("wpnRacketnicaAct") == 1 ? true : false;
        // Ammo Shop Quantity.
        _pistoletAmmoQuantity = PlayerPrefs.GetInt("wpnPistoletAmmo");
        _automatAmmoQuantity =  PlayerPrefs.GetInt("wpnAutomatAmmo");
        _racketnicaAmmoQuantity = PlayerPrefs.GetInt("wpnRacketnica");
    }

    private void OnApplicationQuit()
    {
        SaveParameters();
    }
}
