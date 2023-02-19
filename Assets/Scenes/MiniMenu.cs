using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMenu : MonoBehaviour
{
    [SerializeField] GameObject _miniMenu;
    bool _isActive;

    void Start()
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
