using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextScene : AwakeMonoBehaviour
{
    [SerializeField] private int _indexNextScene;

    private void OnTriggerEnter(Collider other)
    {
        LoadNextScene(other);
    }

    private void Start()
    {
        StartCoroutine(TimerSave());
    }

    private IEnumerator TimerSave()
    {
        yield return new WaitForSecondsRealtime(2);
        if (SceneManager.GetActiveScene().buildIndex != 0)
            SaveParametersObjects._singleton.CreateAndSavingSaveFile();
    }

    private void LoadNextScene(Collider other)
    {
        if (other == SaveParametersObjects._singleton._playerColl)
        {
            SceneManager.LoadScene(_indexNextScene);
        }
    }
}
