using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardList : AwakeMonoBehaviour
{
    #region [SINGLETON ACTIVE]
    public static KeyboardList _singleton;

    private void SingletonActive()
    {
        _singleton = this;

        if (_singleton == null)
        {
            _singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (_singleton != this)
            Destroy(this.gameObject);
    }
    #endregion

    [SerializeField] protected internal static KeyCode _actLamp;

    [SerializeField] protected internal static KeyCode _actWpnOne;
    [SerializeField] protected internal static KeyCode _actWpnTwo;
    [SerializeField] protected internal static KeyCode _actWpnThree;

    [SerializeField] protected internal static KeyCode _actBint;
    [SerializeField] protected internal static KeyCode _actAnalgesic;
    [SerializeField] protected internal static KeyCode _actMedkit;

    [SerializeField] protected internal static KeyCode _keyActivity;

    [Header("UISpritesKeyToOptionMenu")]
    [SerializeField] private Image _keyActLampSpriteUI;
    [SerializeField] private Image _keyActWpnOneSpriteUI;
    [SerializeField] private Image _keyActWpnTwoSpriteUI;
    [SerializeField] private Image _keyActWpnTreeSpriteUI;
    [SerializeField] private Image _keyActBintSpriteUI;
    [SerializeField] private Image _keyActAnalgesicSpriteUI;
    [SerializeField] private Image _keyActMedicamentSpriteUI;
    [SerializeField] protected internal Image _keyActivatedSpriteUI;


    [Header("KeyButtonsListArray")]
    [SerializeField] private List<SpriteRenderer> _keyButtonsSpriteList = new List<SpriteRenderer>();

    private void Start()
    {
        StartKeyBoardParameters();
        SingletonActive();
        SpritesKeyButtonsToListArray();
    }

    private void StartKeyBoardParameters()
    {
        if (_actLamp == KeyCode.None || _actLamp == KeyCode.Mouse0)
        {
            _actLamp = KeyCode.L;
            _actWpnOne = KeyCode.Alpha1;
            _actWpnTwo = KeyCode.Alpha2;
            _actWpnThree = KeyCode.Alpha3;
            _actBint = KeyCode.F1;
            _actAnalgesic = KeyCode.F2;
            _actMedkit = KeyCode.F3;
            _keyActivity = KeyCode.F;
        }
    }

    private void Update()
    {
        if (_keyActLampSpriteUI != null)
        {
            SpritesKeyButtons(_actLamp, _keyActLampSpriteUI);
            SpritesKeyButtons(_actWpnOne, _keyActWpnOneSpriteUI);
            SpritesKeyButtons(_actWpnTwo, _keyActWpnTwoSpriteUI);
            SpritesKeyButtons(_actWpnThree, _keyActWpnTreeSpriteUI);
            SpritesKeyButtons(_actBint, _keyActBintSpriteUI);
            SpritesKeyButtons(_actAnalgesic, _keyActAnalgesicSpriteUI);
            SpritesKeyButtons(_actMedkit, _keyActMedicamentSpriteUI);

        }
        SpritesKeyButtons(_keyActivity, _keyActivatedSpriteUI);
    }

    private void SpritesKeyButtonsToListArray()
    {
        foreach (Transform key in transform.GetComponentInChildren<Transform>())
        {
            _keyButtonsSpriteList.Add(key.GetComponent<SpriteRenderer>());
        }
    }

    private void SpritesKeyButtons(KeyCode keyName, Image keyButtonUI)
    {
        for (int i = 0; i < _keyButtonsSpriteList.Count; i++)
        {
            switch (keyName)
            {
                case KeyCode.Backspace:
                    keyButtonUI.sprite = _keyButtonsSpriteList[0].sprite;
                    break;
                case KeyCode.Tab:
                    keyButtonUI.sprite = _keyButtonsSpriteList[1].sprite;
                    break;
                case KeyCode.Pause:
                    keyButtonUI.sprite = _keyButtonsSpriteList[2].sprite;
                    break;
                case KeyCode.Escape:
                    keyButtonUI.sprite = _keyButtonsSpriteList[3].sprite;
                    break;
                case KeyCode.Space:
                    keyButtonUI.sprite = _keyButtonsSpriteList[4].sprite;
                    break;
                case KeyCode.UpArrow:
                    keyButtonUI.sprite = _keyButtonsSpriteList[5].sprite;
                    break;
                case KeyCode.DownArrow:
                    keyButtonUI.sprite = _keyButtonsSpriteList[6].sprite;
                    break;
                case KeyCode.RightArrow:
                    keyButtonUI.sprite = _keyButtonsSpriteList[7].sprite;
                    break;
                case KeyCode.LeftArrow:
                    keyButtonUI.sprite = _keyButtonsSpriteList[8].sprite;
                    break;
                case KeyCode.F1:
                    keyButtonUI.sprite = _keyButtonsSpriteList[9].sprite;
                    break;
                case KeyCode.F2:
                    keyButtonUI.sprite = _keyButtonsSpriteList[10].sprite;
                    break;
                case KeyCode.F3:
                    keyButtonUI.sprite = _keyButtonsSpriteList[11].sprite;
                    break;
                case KeyCode.F4:
                    keyButtonUI.sprite = _keyButtonsSpriteList[12].sprite;
                    break;
                case KeyCode.F5:
                    keyButtonUI.sprite = _keyButtonsSpriteList[13].sprite;
                    break;
                case KeyCode.F6:
                    keyButtonUI.sprite = _keyButtonsSpriteList[14].sprite;
                    break;
                case KeyCode.F7:
                    keyButtonUI.sprite = _keyButtonsSpriteList[15].sprite;
                    break;
                case KeyCode.F8:
                    keyButtonUI.sprite = _keyButtonsSpriteList[16].sprite;
                    break;
                case KeyCode.F9:
                    keyButtonUI.sprite = _keyButtonsSpriteList[17].sprite;
                    break;
                case KeyCode.F10:
                    keyButtonUI.sprite = _keyButtonsSpriteList[18].sprite;
                    break;
                case KeyCode.F11:
                    keyButtonUI.sprite = _keyButtonsSpriteList[19].sprite;
                    break;
                case KeyCode.F12:
                    keyButtonUI.sprite = _keyButtonsSpriteList[20].sprite;
                    break;
                case KeyCode.Alpha0:
                    keyButtonUI.sprite = _keyButtonsSpriteList[21].sprite;
                    break;
                case KeyCode.Alpha1:
                    keyButtonUI.sprite = _keyButtonsSpriteList[22].sprite;
                    break;
                case KeyCode.Alpha2:
                    keyButtonUI.sprite = _keyButtonsSpriteList[23].sprite;
                    break;
                case KeyCode.Alpha3:
                    keyButtonUI.sprite = _keyButtonsSpriteList[24].sprite;
                    break;
                case KeyCode.Alpha4:
                    keyButtonUI.sprite = _keyButtonsSpriteList[25].sprite;
                    break;
                case KeyCode.Alpha5:
                    keyButtonUI.sprite = _keyButtonsSpriteList[26].sprite;
                    break;
                case KeyCode.Alpha6:
                    keyButtonUI.sprite = _keyButtonsSpriteList[27].sprite;
                    break;
                case KeyCode.Alpha7:
                    keyButtonUI.sprite = _keyButtonsSpriteList[28].sprite;
                    break;
                case KeyCode.Alpha8:
                    keyButtonUI.sprite = _keyButtonsSpriteList[29].sprite;
                    break;
                case KeyCode.Alpha9:
                    keyButtonUI.sprite = _keyButtonsSpriteList[30].sprite;
                    break;
                case KeyCode.A:
                    keyButtonUI.sprite = _keyButtonsSpriteList[31].sprite;
                    break;
                case KeyCode.B:
                    keyButtonUI.sprite = _keyButtonsSpriteList[32].sprite;
                    break;
                case KeyCode.C:
                    keyButtonUI.sprite = _keyButtonsSpriteList[33].sprite;
                    break;
                case KeyCode.D:
                    keyButtonUI.sprite = _keyButtonsSpriteList[34].sprite;
                    break;
                case KeyCode.E:
                    keyButtonUI.sprite = _keyButtonsSpriteList[35].sprite;
                    break;
                case KeyCode.F:
                    keyButtonUI.sprite = _keyButtonsSpriteList[36].sprite;
                    break;
                case KeyCode.G:
                    keyButtonUI.sprite = _keyButtonsSpriteList[37].sprite;
                    break;
                case KeyCode.H:
                    keyButtonUI.sprite = _keyButtonsSpriteList[38].sprite;
                    break;
                case KeyCode.I:
                    keyButtonUI.sprite = _keyButtonsSpriteList[39].sprite;
                    break;
                case KeyCode.J:
                    keyButtonUI.sprite = _keyButtonsSpriteList[40].sprite;
                    break;
                case KeyCode.K:
                    keyButtonUI.sprite = _keyButtonsSpriteList[41].sprite;
                    break;
                case KeyCode.L:
                    keyButtonUI.sprite = _keyButtonsSpriteList[42].sprite;
                    break;
                case KeyCode.M:
                    keyButtonUI.sprite = _keyButtonsSpriteList[43].sprite;
                    break;
                case KeyCode.N:
                    keyButtonUI.sprite = _keyButtonsSpriteList[44].sprite;
                    break;
                case KeyCode.O:
                    keyButtonUI.sprite = _keyButtonsSpriteList[45].sprite;
                    break;
                case KeyCode.P:
                    keyButtonUI.sprite = _keyButtonsSpriteList[46].sprite;
                    break;
                case KeyCode.Q:
                    keyButtonUI.sprite = _keyButtonsSpriteList[47].sprite;
                    break;
                case KeyCode.R:
                    keyButtonUI.sprite = _keyButtonsSpriteList[48].sprite;
                    break;
                case KeyCode.S:
                    keyButtonUI.sprite = _keyButtonsSpriteList[49].sprite;
                    break;
                case KeyCode.T:
                    keyButtonUI.sprite = _keyButtonsSpriteList[50].sprite;
                    break;
                case KeyCode.U:
                    keyButtonUI.sprite = _keyButtonsSpriteList[51].sprite;
                    break;
                case KeyCode.V:
                    keyButtonUI.sprite = _keyButtonsSpriteList[52].sprite;
                    break;
                case KeyCode.W:
                    keyButtonUI.sprite = _keyButtonsSpriteList[53].sprite;
                    break;
                case KeyCode.X:
                    keyButtonUI.sprite = _keyButtonsSpriteList[54].sprite;
                    break;
                case KeyCode.Y:
                    keyButtonUI.sprite = _keyButtonsSpriteList[55].sprite;
                    break;
                case KeyCode.Z:
                    keyButtonUI.sprite = _keyButtonsSpriteList[56].sprite;
                    break;
                case KeyCode.LeftShift:
                    keyButtonUI.sprite = _keyButtonsSpriteList[57].sprite;
                    break;
                case KeyCode.LeftControl:
                    keyButtonUI.sprite = _keyButtonsSpriteList[58].sprite;
                    break;
                case KeyCode.LeftAlt:
                    keyButtonUI.sprite = _keyButtonsSpriteList[59].sprite;
                    break;
                default:
                    keyButtonUI.sprite = _keyButtonsSpriteList[60].sprite;
                    break;
            }
        }
    }

}
