using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCharacters : AwakeMonoBehaviour
{

    [SerializeField] private protected Transform _duloFireTransform;
    [SerializeField] private protected ParticleSystem _firePart;
    [Header("WeaponCharacters")]
    [SerializeField] private protected AmmoType _ammoType;
    [SerializeField] private protected float _rpm;
    [SerializeField] private protected float _rpmTimer;
    [SerializeField] protected internal int _ammoShopQuantity;
    [Header("Audio")]
    [SerializeField] private protected AudioSource _weaponSounds;
    [SerializeField] private protected AudioClip _fireSound;
    [Header("Animations")]
    [SerializeField] private protected Animator _playerAnim;

    [SerializeField] private protected AmmoForwardToPoint _ammoForwardToPoint;

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
                    Debug.DrawRay(_duloFireTransform.position, frw * 100, Color.green, 1);
                    _firePart.Play();
                    _weaponSounds.PlayOneShot(_fireSound);
                    _ammoShopQuantity--;
                    _ammoForwardToPoint._firePoint = hit.point;
                    _ammoForwardToPoint.FireBulletForward();
                }
                _rpmTimer = 0.0f;
            }
        }
    }

    private void RotationPlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitPlayer;

        if (Physics.Raycast(ray, out hitPlayer))
        {
            _playerAnim.transform.LookAt(hitPlayer.point);
        }
    }
}



