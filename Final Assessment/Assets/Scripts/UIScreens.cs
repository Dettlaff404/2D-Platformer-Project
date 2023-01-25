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

    //function for the quit button
    public void QuitApplication()
    {
        Application.Quit();
    }
}
