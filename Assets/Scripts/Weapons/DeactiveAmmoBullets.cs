using System.Collections;
using UnityEngine;
/// <summary>
/// If the bullet touches the Colliders, it is deactivated.
/// </summary>
class DeactiveAmmoBullets : AwakeMonoBehaviour
{
    [Header("                             OBJECTS")]
    [Space(10)]
    [SerializeField] private ParticleSystem _partBoom;

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
                this.gameObject.SetActive(false);
        }
    }
}


