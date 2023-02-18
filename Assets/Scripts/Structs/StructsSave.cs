using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructsSave : AwakeMonoBehaviour
{
   [SerializeField] protected internal static AiMonsters[] _aiMonstersStructs;
    protected internal static AiBoss[] _aiBossStructs;
    protected internal static WeaponsAmmoStruct[] _weaponsAmmoStructs;
    protected internal static AmmoShopsStruct[] _ammoShopsStructs;
    protected internal static AmmoBossStruct[] _ammoBossStructs;
    protected internal static MedicamentStruct[] _medicamentStructs;

    // No Struct.
    protected internal static bool _playerIsMove;


}
