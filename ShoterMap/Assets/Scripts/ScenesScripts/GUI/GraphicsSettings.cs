using TMPro;
using UnityEngine;

public class GraphicsSettings : AwakeMonoBehaviour
{
    private FullScreenMode fullScreen;
    [SerializeField] private TMP_Dropdown dropdownFullScreens;
    [SerializeField] private TMP_Dropdown dropdownScreenResolution;

    protected internal static int _dropdownFullScreenValue;
    protected internal static int _dropdownScreenResolutionValue;


    private void Start()
    {
        dropdownFullScreens.value = _dropdownFullScreenValue;
        dropdownScreenResolution.value = _dropdownScreenResolutionValue;
    }

    private void Update()
    {
        DropDownFullScreens();
        DropDownDefaultScreens();
    }

    private void DropDownFullScreens()
    {
        switch (dropdownFullScreens.value)
        {
            case 0:
                FullScreenParameters(FullScreenMode.Windowed);
                break;
            case 1:
                FullScreenParameters(FullScreenMode.FullScreenWindow);
                break;
            case 2:
                FullScreenParameters(FullScreenMode.MaximizedWindow);
                break;
        }

    }

    private void DropDownDefaultScreens()
    {
        switch (dropdownScreenResolution.value)
        {
            case 0:
                ScreenResolutionParameters(800, 600);
                break;
            case 1:
                ScreenResolutionParameters(1024, 768);
                break;
            case 2:
                ScreenResolutionParameters(1152, 864);
                break;
            case 3:
                ScreenResolutionParameters(1280, 720);
                break;
            case 4:
                ScreenResolutionParameters(1280, 768);
                break;
            case 5:
                ScreenResolutionParameters(1280, 1024);
                break;
            case 6:
                ScreenResolutionParameters(1366, 768);
                break;
            case 7:
                ScreenResolutionParameters(1650, 1080);
                break;
            case 8:
                ScreenResolutionParameters(1920, 1080);
                break;
        }
    }


    #region [PARAMETERS]
    private void ScreenResolutionParameters(int width, int height)
    {
        Screen.SetResolution(width, height, fullScreen);
        _dropdownScreenResolutionValue = dropdownScreenResolution.value;
    }

    private void FullScreenParameters(FullScreenMode modeFullScreen)
    {
        Screen.fullScreenMode = modeFullScreen;

        fullScreen = modeFullScreen;
        _dropdownFullScreenValue = dropdownFullScreens.value;
    }
    #endregion
}
