using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMenu : AwakeMonoBehaviour
{
    [SerializeField] private GameObject _miniMenu;
    private bool _isActive;

    private void Start()
    {
        _isActive = false;
        _miniMenu.SetActive(_isActive);
    }

    private void Update()
    {
        MiniMenuActive();
    }

    private void MiniMenuActive()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _miniMenu.SetActive(_isActive = !_isActive);
            Debug.Log(_isActive);
        }
    }

    public void ButtonBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
