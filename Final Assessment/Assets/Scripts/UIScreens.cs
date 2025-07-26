using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScreens : MonoBehaviour
{
    //function for the play button in the menu screen
    public void StartPlay()
    {
        SceneManager.LoadScene(1);
    }

    //function for the quit button+
    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    //function to load the main menu
    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //function to save game data
    public void SaveGame()
    {
        PlayerPrefs.SetInt("isSavedData", 1);
        PlayerPrefs.SetFloat("PlayerX", GameManagerScript.thisGameManagerScript.player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", GameManagerScript.thisGameManagerScript.player.transform.position.y);
        PlayerPrefs.SetFloat("Health", GameManagerScript.thisGameManagerScript.currentHealth);
        PlayerPrefs.SetInt("Score", GameManagerScript.thisGameManagerScript.scoreValue);
        PlayerPrefs.Save();
    }

    //function to call load saved game data
    public void LoadGame()
    {
        if (PlayerPrefs.GetInt("isSavedData") == 1)
        {
            PlayerPrefs.SetInt("LoadTheData", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }
        else
        {
            Debug.Log("Save data not found");
        }
    }

    //function to pause the game
    public void PauseButton()
    {
        GameManagerScript.thisGameManagerScript.Pause();
    }

    //function to resume the game if paused
    public void ResumeGame()
    {
        GameManagerScript.thisGameManagerScript.Resume();
    }
}
