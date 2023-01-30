using UnityEngine;
using UnityEngine.UI;

public class MonsterHpSliderPoint : AwakeMonoBehaviour
{
    private MonsterDamagerAndShopSpawns _script_MDaSS;
    [SerializeField] private Slider _hpSlider;

    void Start()
    {
        _script_MDaSS = GetComponentInParent<MonsterDamagerAndShopSpawns>();
        _hpSlider = GetComponentInChildren<Slider>();
        _hpSlider.maxValue = _script_MDaSS._monsterHp;
    }

    void Update()
    {
        HpSliderEquatedHpMonster();
    }

    void HpSliderEquatedHpMonster()
    {
        _hpSlider.value = _script_MDaSS._monsterHp;
    }
}
