using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Assigns the hp values of the monster to the GUI slider.
/// </summary>
public class MonsterHpSliderPoint : StructsSave
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Slider _hpSlider;
    [SerializeField] private GameObject _parentObj;
    [Header("                             PARAMETERS")]
    private int _nomberObject;

    private void Start()
    {
        FindComponents();
        MonsterHpSliderMaxValue();
    }

    private void FindComponents()
    {
        _hpSlider = GetComponentInChildren<Slider>();
        for (int i = 0; i < _aiMonstersStructs.Length; i++)
        {
            if (_aiMonstersStructs[i].monsterObject == _parentObj)
            {
                _nomberObject = i;
            }
        }
    }

    private void Update()
    {
        MonsterHpSliderValue();
    }

    private void MonsterHpSliderValue()
    {
        for (int i = 0; i < _aiBossStructs.Length; i++)
        {
            if (_parentObj == _aiBossStructs[i].bossObject)
            {
                _hpSlider.value = _aiBossStructs[i].bossHP;
            }
        }


        for (int i = 0; i < _aiMonstersStructs.Length; i++)
        {
            if (_parentObj == _aiMonstersStructs[_nomberObject].monsterObject)
            {
                _hpSlider.value = _aiMonstersStructs[_nomberObject].monsterHP;
            }
        }

    }

    private void MonsterHpSliderMaxValue()
    {
        for (int i = 0; i < _aiBossStructs.Length; i++)
        {
            if (_parentObj == _aiBossStructs[i].bossObject)
            {
                _hpSlider.maxValue = _aiBossStructs[i].bossHP;
            }
        }

        for (int i = 0; i < _aiMonstersStructs.Length; i++)
        {
            if (_parentObj == _aiMonstersStructs[_nomberObject].monsterObject)
            {
                _hpSlider.maxValue = _aiMonstersStructs[_nomberObject].monsterHP;
            }
        }


    }
}
