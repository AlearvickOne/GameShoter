using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructsSave : AwakeMonoBehaviour
{
    protected internal static AiMonsters[] _aiMonstersStructs;
    protected internal static WeaponsAmmoStruct[] _weaponsAmmoStructs;
    protected internal static AmmoShopsStruct[] _ammoShopsStructs;
    protected internal static AmmoBossStruct[] _ammoBossStructs;

    // No Structs
    protected internal static float _bossHP;
    protected internal static bool _bossIsDead;
}
