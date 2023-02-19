using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [Header("MainMenu")]
    [SerializeField] private GameObject _mainMenu;

    [Header("MainMenuButtons")]
    [SerializeField] private GameObject _continueGameButton;

    [Header("OptionMenu")]
    [SerializeField] private GameObject _optionsMenuActive;
    [SerializeField] private GameObject _keyboardMenuOptions;
    [SerializeField] private GameObject _graphicMenuOptions;
    [SerializeField] private GameObject _soundMenuOptions;
    private void Awake()
    {
        LoadKeyboardsSetting();
        LoadSoundParameters();
    }

    private void ActivateButtons(bool activeMenu, bool menuOptionsPanel, bool keyboardMenuOptions, bool graphicMenuOption, bool soundsMenuOption)
    {
        _mainMenu.SetActive(activeMenu);
        _optionsMenuActive.SetActive(menuOptionsPanel);
        _keyboardMenuOptions.SetActive(keyboardMenuOptions);
        _graphicMenuOptions.SetActive(graphicMenuOption);
        _soundMenuOptions.SetActive(soundsMenuOption);
    }

    #region [BUTTONS MENU]

    private void Update()
    {
        ButtonContinueIsActive();
    }

    private void ButtonContinueIsActive()
    {
        SaveParametersObjects._singleton.LoadSaveFile();

        if (SaveParametersObjects._singleton._newGameIsPlaying == true)
            _continueGameButton.SetActive(true);
        else if (SaveParametersObjects._singleton._newGameIsPlaying == false)
            _continueGameButton.SetActive(false);
    }

    public void NewGameLoadScene()
    {
        SaveParametersObjects._singleton.DestroySaveFile();
        SceneManager.LoadScene(1);
    }

    public void ContinueGameButton()
    {
        if (SaveParametersObjects._singleton._newGameIsPlaying == true)
            SceneManager.LoadScene(SaveParametersObjects._singleton._sceneIndex);
        else if (SaveParametersObjects._singleton._newGameIsPlaying == false)
            return;
    }

    public void ButtonOpenMainMenu()
    {
        SaveKeyboardsSetting();
        SavesSoundParameters();
        ActivateButtons(true, false, false, false, false);
    }

    public void ButtonOpenKeyboardsMenuOptions()
    {
        ActivateButtons(false, true, true, false, false);
    }

    public void ButtonOpenGraphicMenuOptions()
    {
        ActivateButtons(false, true, false, true, false);
    }
    public void ButtonOpenSoundsMenuOptions()
    {
        ActivateButtons(false, true, false, false, true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    #endregion


    #region [SAVE AND LOAD OPTIONS]

    private void SaveKeyboardsSetting()
    {
        PlayerPrefs.SetString("actLamp", KeyboardList._actLamp.ToString());
        PlayerPrefs.SetString("actWeaponOne", KeyboardList._actWpnOne.ToString());
        PlayerPrefs.SetString("actWeaponTwo", KeyboardList._actWpnTwo.ToString());
        PlayerPrefs.SetString("actWeaponThree", KeyboardList._actWpnThree.ToString());
        PlayerPrefs.SetString("actBint", KeyboardList._actBint.ToString());
        PlayerPrefs.SetString("actAnalgesic", KeyboardList._actAnalgesic.ToString());
        PlayerPrefs.SetString("actMedicament", KeyboardList._actMedkit.ToString());
        PlayerPrefs.SetString("keyActivity", KeyboardList._keyActivity.ToString());
    }

    private void SavesSoundParameters()
    {
        PlayerPrefs.SetFloat("soundMusicBackground", AudioAllSettings._volumeMusicToFloat);
        PlayerPrefs.SetFloat("soundWeapons", AudioAllSettings._volumeWeaponToFloat);
    }

    private void LoadKeyboardsSetting()
    {
        KeyboardList._actLamp = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("actLamp"));
        KeyboardList._actWpnOne = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("actWeaponOne"));
        KeyboardList._actWpnTwo = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("actWeaponTwo"));
        KeyboardList._actWpnThree = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("actWeaponThree"));
        KeyboardList._actBint = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("actBint"));
        KeyboardList._actAnalgesic = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("actAnalgesic"));
        KeyboardList._actMedkit = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("actMedicament"));
        KeyboardList._keyActivity = (KeyCode)Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("keyActivity"));
    }

    private void LoadSoundParameters()
    {
        AudioAllSettings._volumeMusicToFloat = PlayerPrefs.GetFloat("soundMusicBackground");
        AudioAllSettings._volumeWeaponToFloat = PlayerPrefs.GetFloat("soundWeapons");
    }

    #endregion
}

