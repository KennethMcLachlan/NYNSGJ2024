using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPage;
    public void LoadGame()
    {
        SceneManager.LoadScene("Intro Scene");
    }

    public void SettingsPage()
    {
        _settingsPage.SetActive(true);
        PlayerPrefs.Save();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
