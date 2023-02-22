using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MousePositionInActKey : AwakeMonoBehaviour, IPointerDownHandler, IPointerExitHandler
{
    #region [GET KEYCODES]
    private enum NameKey { ActLamp, actWpnOne, actWpnTwo, actWpnThree, actBint, actAnalgesic, actMedicament, keyActivity }

    private readonly Array keyKodes = Enum.GetValues(typeof(KeyCode));

    private void GetKeyCodes()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in keyKodes)
            {

                if (Input.GetKeyDown(keyCode))
                {
                    _nameKeyCode = keyCode;
                }
            }
        }
    }

    #endregion

    [SerializeField] private NameKey _nameKeyBoardOptions;
    [SerializeField] private bool _isActiveReplacement;
    private KeyCode _nameKeyCode;
    private Image _imageKey;
    private Color minAlphaColor = new Color(1, 1, 1, 0.5f);
    private Color maxAlphaColor = new Color(1, 1, 1, 1f);

    private void Start()
    {
        _imageKey = GetComponent<Image>();
    }

    private IEnumerator ITimer()
    {
        while (true)
        {
            while (_isActiveReplacement == true)
            {
                CheckNameKey();
                _imageKey.color = Color.Lerp(minAlphaColor, maxAlphaColor, Mathf.PingPong(Time.time, 0.5f));
                yield return null;
            }
            yield return null;
        }
    }

    private void CheckNameKey()
    {
        switch (_nameKeyBoardOptions)
        {
            case NameKey.ActLamp:
                GetKeyCodes();
                KeyboardList._actLamp = _nameKeyCode;
                break;
            case NameKey.actWpnOne:
                GetKeyCodes();
                KeyboardList._actWpnOne = _nameKeyCode;
                break;
            case NameKey.actWpnTwo:
                GetKeyCodes();
                KeyboardList._actWpnTwo = _nameKeyCode;
                break;
            case NameKey.actWpnThree:
                GetKeyCodes();
                KeyboardList._actWpnThree = _nameKeyCode;
                break;
            case NameKey.actBint:
                GetKeyCodes();
                KeyboardList._actBint = _nameKeyCode;
                break;
            case NameKey.actAnalgesic:
                GetKeyCodes();
                KeyboardList._actAnalgesic = _nameKeyCode;
                break;
            case NameKey.actMedicament:
                GetKeyCodes();
                KeyboardList._actMedkit = _nameKeyCode;
                break;
            case NameKey.keyActivity:
                GetKeyCodes();
                KeyboardList._keyActivity = _nameKeyCode;
                break;
            default:
                break;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isActiveReplacement = true;
        StartCoroutine(ITimer());
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        _imageKey.color = maxAlphaColor;
        _isActiveReplacement = false;
    }

}
