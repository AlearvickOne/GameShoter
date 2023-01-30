using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoInfoInGUI : MonoBehaviour
{
    int ANIM_WS = Animator.StringToHash("WeaponSells");

    [Header("Weapon Sells")]
    [SerializeField] Animator weaponSellPistolet;
    [SerializeField] Animator weaponSellAutomat;
    [SerializeField] Animator weaponSellRacketnica;
    [Header("Text GUI")]
    [SerializeField] TMP_Text AmmoQuantityHud;


    void Start()
    {
        weaponSellAutomat.SetBool(ANIM_WS, false);
        weaponSellPistolet.SetBool(ANIM_WS, false);
    }

    void Update()
    {
       // AmmoQuantityInHUdGUI();
    }

   /* void AmmoQuantityInHUdGUI()
    {
        if (scrWpnAutomat.gameObject.activeSelf == true)
        {
            weaponSellAutomat.SetBool(ANIM_WS, true);
            AmmoQuantityHud.text = scrPAAdd.ammoAutomat.ToString();
        }
        else if (scrWpnPistolet.gameObject.activeSelf == true)
        {
            weaponSellPistolet.SetBool(ANIM_WS, true);
            AmmoQuantityHud.text = scrPAAdd.ammoPistolet.ToString();
        }
        else if (scrWpnRacketnica.gameObject.activeSelf == true)
        {
            weaponSellRacketnica.SetBool(ANIM_WS, true);
            AmmoQuantityHud.text = scrPAAdd.ammoRacketnica.ToString();
        }
        else if (scrWpnAutomat.gameObject.activeSelf == false && scrWpnPistolet.gameObject.activeSelf == false
            && scrWpnRacketnica.gameObject.activeSelf == false)
        {
            weaponSellAutomat.SetBool(ANIM_WS, false);
            weaponSellPistolet.SetBool(ANIM_WS, false);
            weaponSellRacketnica.SetBool(ANIM_WS, false);
            AmmoQuantityHud.text = "";
        }

    }*/
}
