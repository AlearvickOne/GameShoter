using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// If the bullet touches the Colliders, it is deactivated.
/// </summary>
class AmmoDeactiveBulletsInContactsColliders : AwakeMonoBehaviour
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private ParticleSystem _partBoom;
    [Header("                               AUDIO")]
    [Space(10)]
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _audioClipBoom;

    LayerMask _layerNoTriggerWeapons = 7;

    private void OnTriggerEnter(Collider other)
    {
        Deactive(other);
    }


    WaitForSeconds _waitForSeconds;
    private IEnumerator ITimerDeactive()
    {
        yield return _waitForSeconds = new WaitForSeconds(0.1f);
        this._partBoom.Stop();
        AudioAllSettings._weaponsAudio.PlayOneShot(_audioClipBoom);
        this.transform.position = Vector3.zero;
        yield return _waitForSeconds = new WaitForSeconds(6f);
        this.gameObject.SetActive(false);
    }

    private void Deactive(Collider other)
    {
        if (other.gameObject.layer != _layerNoTriggerWeapons)
        {
            if (_partBoom != null)
            {
                this._partBoom.Play();
                StartCoroutine(ITimerDeactive());
            }
            else
            {
                this.gameObject.SetActive(false);
                this.transform.position = Vector3.zero;
            }

        }
    }
}


