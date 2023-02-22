/// <summary>
/// Setting up characteristics for a specific weapon.
/// </summary>
public class Weapons : WeaponCharacters
{
    private void OnEnable()
    {
        _ammoForwardToPoint._ammoType = _ammoType;
        _weaponSounds = AudioAllSettings._weaponsAudio;
    }

    private void Update()
    {
        Timers();
        FireWeapon(_rpm);
        WeaponAmmoQuantity(0);
    }
}
