using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GalacticMap : MonoBehaviour
{
    private ToggleGroup _toggleGroup;
    private string _starSystemName;

    private void Awake()
    {
        _toggleGroup = GetComponent<ToggleGroup>();
    }

    private void Update()
    {
        IEnumerable<Toggle> togglesActive = _toggleGroup.ActiveToggles();

        foreach (var toggle in togglesActive)
        {
            _starSystemName = toggle.name;
        }
    }

    public void OnClickWarp()
    {
        if(SceneManager.GetActiveScene().name != _starSystemName)
        SceneManager.LoadScene(_starSystemName);
    }
}
