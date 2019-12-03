using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject _panelPause;
    [SerializeField] GameObject _panelControlInfo;

    private bool isPause = false;
    private PlayerShip _playerShip;

    private void Start()
    {
        _playerShip = FindObjectOfType<PlayerShip>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            Time.timeScale = 0.0f;
            isPause = true;
            _playerShip.IsActive = false;
            _panelPause.SetActive(true);
        }        
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickContinue();
            _panelControlInfo.SetActive(false);
        }
    }

    public void OnClickContinue()
    {
        Time.timeScale = 1.0f;
        isPause = false;
        _playerShip.IsActive = true;
        _panelPause.SetActive(false);
    }

    public void OnClickControlInfo()
    {
        _panelControlInfo.SetActive(true);
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
