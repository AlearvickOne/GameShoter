using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [Header("MainMenu")]
    [SerializeField] private GameObject _mainMenu;

    [Header("OptionMenu")]
    [SerializeField] private GameObject _optionsMenuActive;
    [SerializeField] private GameObject _keyboardMenuOptions;
    [SerializeField] private GameObject _graphicMenuOptions;

    void ActivateButtons(bool activeMenu, bool menuOptionsPanel, bool keyboardMenuOptions, bool graphicMenuOption)
    {
        _mainMenu.SetActive(activeMenu);
        _optionsMenuActive.SetActive(menuOptionsPanel);
        _keyboardMenuOptions.SetActive(keyboardMenuOptions);
        _graphicMenuOptions.SetActive(graphicMenuOption);
    }

    public void ButtonOpenMainMenu()
    {
        ActivateButtons(true, false, false, false);
    }

    public void ButtonOpenKeyboardsMenuOptions()
    {
        ActivateButtons(false, true, true, false);
    }

    public void ButtonOpenGraphicMenuOptions()
    {
        ActivateButtons(false, true, false, true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
