using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript thisGameManagerScript; //to access this script in other scripts

    public float maxHealth = 100; //maximum health value of the player
    public float currentHealth; //current health value of the player
    public GameObject player; //player gameObject

    public int scoreValue; //to be referenced to the player score value

    public GameObject pauseScreen; //pause UI screen
    public GameObject youWinScreen; //win UI screen
    public GameObject gameOverScreen; //game over UI screen
    public GameObject pauseButton; //pause button in the UI
    public GameObject playerScoreUI; //player score 
    public bool isPaused; //to keep track if the game is paused

    // Awake is called before the start of the game
    void Awake()
    {
        //assigning the game manager script to be referenced in other scripts if its not assigned earlier
        if (thisGameManagerScript == null)
        {
            thisGameManagerScript = this;
        }

        //if the player had chosem to load previos game data from a menu option before, loading saved data as current data
        //data which loaded here are player health, score, and position
        if (PlayerPrefs.GetInt("LoadTheData") == 1)
        {
            PlayerPrefs.SetInt("LoadTheData", 0);
            PlayerPrefs.Save();
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;

            pX = PlayerPrefs.GetFloat("PlayerX");
            pY = PlayerPrefs.GetFloat("PlayerY");
            player.transform.position = new Vector2(pX, pY);

            currentHealth = PlayerPrefs.GetFloat("Health");
            scoreValue = PlayerPrefs.GetInt("Score");
        }
        else
        {
            currentHealth = maxHealth; //resetting the health value of the player
            scoreValue = 0; //resetting the player score value
        }

        //starting the inputs,functions and animations of the game if its been paused on a previous menu
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }

        //setting UI screens
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        youWinScreen.SetActive(false);
        

    }

    // Start is called before the Update of the first frame of the game
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            PlayerController.playerControllerScript.PlayerDead();
        }

        //calling pause and resume function when the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                Resume();
            }
            else if (isPaused == false)
            {
                Pause();
            }
        }
    }

    //function to resume the game
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseScreen.SetActive(false);
        isPaused = false;
    }

    //function to pause the game
    public void Pause()
    {
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
        isPaused = true;
    }

    //game over screen calling function
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }

    public void YouWin()
    {
        Time.timeScale = 0f;
        youWinScreen.SetActive(true);
    }
}
