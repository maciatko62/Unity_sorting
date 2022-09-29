using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject finalMessage;
    public PickUp sound;

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

    public void FinalMessageOn()
    {
        sound.audio.clip = sound.clip[2];
        sound.audio.Play();
        finalMessage.SetActive(true);
    }
    public void FinalMessageOff()
    {
        
        finalMessage.SetActive(false);
    }

    public void Choose1()
    {
        PlayerPrefs.SetInt("Sort", 1);
    }
    
    public void Choose2()
    {
        PlayerPrefs.SetInt("Sort", 2);
    }
    
    public void Choose3()
    {
        PlayerPrefs.SetInt("Sort", 3);
    }
}
