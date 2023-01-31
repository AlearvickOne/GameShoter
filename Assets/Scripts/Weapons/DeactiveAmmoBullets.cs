using System.Collections;
using UnityEngine;
class DeactiveAmmoBullets : AwakeMonoBehaviour
{
    [SerializeField] private ParticleSystem _partBoom;
    [SerializeField] private float _timerDeactive;

    private void OnTriggerEnter(Collider other)
    {

        Deactive();
    }

    WaitForSeconds _waitForSeconds;
    IEnumerator ITimerDeactive()
    {
        yield return _waitForSeconds = new WaitForSeconds(0.1f);
        this._partBoom.Stop();
        this.gameObject.SetActive(false);
    }

    void Deactive()
    {
        if (_partBoom != null)
        {
            this._partBoom.Play();
            StartCoroutine(ITimerDeactive());
        }
        else
        {
            this.gameObject.SetActive(false);
        }

    }
}


