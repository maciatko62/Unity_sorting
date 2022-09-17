using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void QuiteGame()
    {
        Debug.Log("Quit :(");
        Application.Quit();
    }

    /*
    public void SoundMenuOn()
    {
        PlayerPrefs.SetInt("MenuSound", 1);
    }
    public void SoundMenuOff()
    {
        PlayerPrefs.SetInt("MenuSound", 0);
    }
    */
}
