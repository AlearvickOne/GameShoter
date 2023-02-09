using UnityEngine;
/// <summary>
/// Main characteristics of the weapons.
/// </summary>
public class WeaponCharacters : AwakeMonoBehaviour
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private protected Transform _duloFireTransform;
    [SerializeField] private protected ParticleSystem _firePart;
    [SerializeField] private protected Animator _playerAnim;
    [Header("                             PARAMETERS")]
    [Space(10)]
    [SerializeField] private protected AmmoType _ammoType;
    [SerializeField] private protected float _rpm;
    [SerializeField] private protected float _rpmTimer;
    [SerializeField] protected internal int _ammoShopQuantity;
    [Header("                               AUDIO")]
    [Space(10)]
    [SerializeField] private protected AudioSource _weaponSounds;
    [SerializeField] private protected AudioClip _fireSound;
    [Header("                             SCRIPTS")]
    [Space(10)]
    [SerializeField] private protected AmmoForwardToPoint _ammoForwardToPoint;
    private void RotationPlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPlayer;

        if (Physics.Raycast(ray, out hitPlayer))
        {
            _playerAnim.transform.LookAt(hitPlayer.point);
        }
    }

    private protected void Timers()
    {
        _rpmTimer += Time.deltaTime;
    }

    private protected void FireWeapon(float rpmTimer)
    {
        if (Input.GetMouseButton(0) && _ammoShopQuantity > 0)
        {

            RotationPlayer();

            if (_rpmTimer > rpmTimer)
            {
                RaycastHit hit;
                Vector3 frw = _duloFireTransform.TransformDirection(Vector3.forward);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit))
                {
                    Debug.Log($"RAY {ray.direction}" );

                    Debug.DrawRay(_duloFireTransform.position, frw * 100, Color.green, 1);
                    _firePart.Play();
                    _weaponSounds.PlayOneShot(_fireSound);
                    WeaponAmmoQuantity(1);
                    _ammoForwardToPoint._firePoint = hit.point;
                    _ammoForwardToPoint.FireBulletForward();
                }
                _rpmTimer = 0.0f;
            }
        }
    }

    private protected void WeaponAmmoQuantity(int minusQuantity)
    {
        switch (_ammoType)
        {
            case AmmoType.ammoPistolet:
                _ammoShopQuantity = SaveSceneParametersObjects._singleton._pistoletAmmoQuantity -= minusQuantity;
                break;
            case AmmoType.ammoAutomat:
                _ammoShopQuantity = SaveSceneParametersObjects._singleton._automatAmmoQuantity -= minusQuantity;
                break;
            case AmmoType.ammoRacketnica:
                _ammoShopQuantity = SaveSceneParametersObjects._singleton._racketnicaAmmoQuantity -= minusQuantity;
                break;
        }
    }
}



