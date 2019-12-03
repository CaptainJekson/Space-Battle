using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ToggleGroup _toggleGroup;

    private void Awake()
    {
        Cursor.visible = true;
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        IEnumerable<Toggle> togglesActive = _toggleGroup.ActiveToggles();

        foreach (var toggle in togglesActive)
        {
            PlayerPrefs.SetString("SelectedShip", toggle.name);
        }
    }

    public void OnClickGo()
    {
        SceneManager.LoadScene("Nova B");
    }

    public void OnClickClose()
    {
        Application.Quit();
    }
}
