using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Assigns the hp values of the monster to the GUI slider.
/// </summary>
public class MonsterHpSliderPoint : AwakeMonoBehaviour
{
    [Header("                             SCRIPTS")]
    private MonsterDamagerAndShopSpawns _script_MDaSS;
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private Slider _hpSlider;

    private void Start()
    {
        _script_MDaSS = GetComponentInParent<MonsterDamagerAndShopSpawns>();
        _hpSlider = GetComponentInChildren<Slider>();
        _hpSlider.maxValue = _script_MDaSS._monsterHp;
    }

    private void Update()
    {
        HpSliderEquatedHpMonster();
    }

    private void HpSliderEquatedHpMonster()
    {
        _hpSlider.value = _script_MDaSS._monsterHp;
    }
}
