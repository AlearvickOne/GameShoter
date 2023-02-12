using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MousePositionInActKey : AwakeMonoBehaviour, IPointerDownHandler, IPointerExitHandler
{

    enum NameKey { ActLamp, actWpnOne, actWpnTwo, actWpnThree, actBint, actAnalgesic, actMedicament, keyActivity }
    
    private readonly Array keyKodes = Enum.GetValues(typeof(KeyCode));

    void GetKeyCodes()
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

    [SerializeField] private NameKey _nameKeyBoardOptions;
    KeyCode _nameKeyCode;

    private Image _imageKey;
    private Color minAlphaColor = new Color(1,1,1,0.5f);
    private Color maxAlphaColor = new Color(1,1,1,1f);

    [SerializeField] private bool _isActiveReplacement;

    private void Start()
    {
        _imageKey = GetComponent<Image>();
    }

    void Update()
    {

    }

    void CheckNameKey()
    {
        switch (_nameKeyBoardOptions)
        {
            case NameKey.ActLamp:
                GetKeyCodes();
                KeyboardList._singleton._actLamp = _nameKeyCode;
                break;
            case NameKey.actWpnOne:
                GetKeyCodes();
                KeyboardList._singleton._actWpnOne = _nameKeyCode;
                break;
            case NameKey.actWpnTwo:
                GetKeyCodes();
                KeyboardList._singleton._actWpnTwo = _nameKeyCode;
                break;
            case NameKey.actWpnThree:
                GetKeyCodes();
                KeyboardList._singleton._actWpnThree = _nameKeyCode;
                break;
            case NameKey.actBint:
                GetKeyCodes();
                KeyboardList._singleton._actBint = _nameKeyCode;
                break;
            case NameKey.actAnalgesic:
                GetKeyCodes();
                KeyboardList._singleton._actAnalgesic = _nameKeyCode;
                break;
            case NameKey.actMedicament:
                GetKeyCodes();
                KeyboardList._singleton._actMedicament = _nameKeyCode;
                break;
            case NameKey.keyActivity:
                GetKeyCodes();
                KeyboardList._singleton._keyActivity = _nameKeyCode;
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

    IEnumerator ITimer()
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
}
