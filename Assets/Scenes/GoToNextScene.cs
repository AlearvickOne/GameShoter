using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : MonoBehaviour
{
    [SerializeField] int _indexNextScene;

    private void OnTriggerEnter(Collider other)
    {
        LoadNextScene(other);
    }

    private void Start()
    {
        StartCoroutine(TimerSave());
    }

    IEnumerator TimerSave()
    {
        yield return new WaitForSecondsRealtime(2);
        if (SceneManager.GetActiveScene().buildIndex != 0)
            SaveParametersObjects._singleton.CreateAndSavingSaveFile();
    }

    void LoadNextScene(Collider other)
    {
        if(other == SaveParametersObjects._singleton._playerColl)
        {
            SceneManager.LoadScene(_indexNextScene);
        }
    }
}
