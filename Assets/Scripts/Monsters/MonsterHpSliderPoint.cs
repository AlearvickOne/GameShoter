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
    [SerializeField] private GameObject _bossObj;
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
        if(_parentObj == _bossObj)
        {
            _hpSlider.value = _bossHP;
        }
        else if(this.gameObject != _bossObj)
        {
            _hpSlider.value = _aiMonstersStructs[_nomberObject].monsterHP;
        }
    }

    private void MonsterHpSliderMaxValue()
    {
        if (_parentObj == _bossObj)
        {
            _hpSlider.maxValue = _bossHP;
        }
        else if (this.gameObject != _bossObj)
        {
            _hpSlider.maxValue = _aiMonstersStructs[_nomberObject].monsterHP;
        }
    }
}
